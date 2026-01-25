# NVAPIWrapper

A modern C# wrapper for NVIDIA's NVAPI, providing easy access to NVIDIA GPU features and settings.

## Features

- IntPtr-based API surface; no custom handle types to manage
- Automatic cleanup via `IDisposable` (SafeHandle-backed)
- Strongly typed structs/enums matching NVAPI headers
- Helper methods for common adapter/display queries
- Facade DTOs for bool-friendly helper results, with `*Native()` accessors when you need raw structs
- ClangSharp-generated bindings kept in sync with the SDK
- Tests skip gracefully when hardware is absent
- Split test suites:
  - `NVAPIWrapper.NativeTests` exercises only ClangSharp-generated APIs.
  - `NVAPIWrapper.FacadeTests` exercises the new facade helpers.

## Quick Start

### Prerequisites
- NVIDIA GPU with NVAPI support
- Windows 10/11 x64
- .NET 10.0 SDK
- NVIDIA drivers

### Build the wrapper
```powershell
git clone https://github.com/terrymacdonald/NVAPIWrapper.git
cd NVAPIWrapper

./prepare_NVAPI.ps1   # pulls the NVAPI SDK
./build_NVAPI.ps1     # restores, regenerates bindings, builds, tests
```

### Install / consume the wrapper
- Local build artifacts: after `./build_NVAPI.ps1`, reference `NVAPIWrapper\bin\Debug\net10.0\NVAPIWrapper.dll` (or `Release` if you build release) from your project.
- Add as a project reference: add `NVAPIWrapper/NVAPIWrapper.csproj` to your solution and reference it.
- Requirements at runtime: Windows x64, NVIDIA GPU/driver, and NVAPI DLLs available (the wrapper dynamically loads `ControlLib` from the installed NVIDIA drivers).

### Basic usage (facade)
```csharp
using NVAPIWrapper;

using var api = NVAPIApiHelper.Initialize();
var adapters = api.EnumerateAdapters();
Console.WriteLine($"Found {adapters.Count} NVIDIA GPU(s)");

foreach (var adapter in adapters)
{
    var props = adapter.GetProperties();
    Console.WriteLine($"\nGPU: {adapter.Name}");
    Console.WriteLine($"Device ID: 0x{props.pci_device_id:X}");

    foreach (var display in adapter.GetDisplays())
    {
        if (!display.IsActive()) continue;
        var (width, height) = display.GetResolution();
        var refresh = display.GetRefreshRateHz();
        Console.WriteLine($"  {width}x{height} @ {refresh:F2} Hz");
    }
}
```

### Error handling
```csharp
try
{
    using var NVAPI = NVAPIApi.Initialize();
    // use the API
}
catch (NVAPIException ex)
{
    Console.WriteLine($"NVAPI Error: {ex.Result} - {ex.Message}");
}
catch (DllNotFoundException)
{
    Console.WriteLine("NVAPI DLL not found. Install NVIDIA Graphics drivers.");
}
```

## Working with the facade helpers (NVAPIApiHelper)
Use the facade helpers to avoid manual struct sizing/handle management.
DTO-returning helpers use `bool` properties; call `*Native()` variants when you need the raw structs.
Get/Set operations are split into `Get*()` and `Set*()` helpers; `GetSet*Native()` remains for direct NVAPI calls.

### List active display resolutions
```csharp
using NVAPIWrapper;

using var api = NVAPIApiHelper.Initialize();
foreach (var adapter in api.EnumerateAdapters())
{
    foreach (var display in adapter.GetDisplays())
    {
        if (!display.IsActive()) continue;
        var (w, h) = display.GetResolution();
        var hz = display.GetRefreshRateHz();
        Console.WriteLine($"{adapter.Name}: {w}x{h} @ {hz:F2} Hz");
    }
}
```

### List only combined displays
```csharp
using NVAPIWrapper;
using System.Linq;

using var api = NVAPIApiHelper.Initialize();
foreach (var adapter in api.EnumerateAdapters())
{
    var displayHelper = adapter.GetDisplays().First();
    var result = displayHelper.GetCombinedDisplay();
    if (result.IsSupported && result.NumOutputs > 0)
    {
        Console.WriteLine($"Adapter {adapter.Name} has a combined display with {result.NumOutputs} outputs.");
    }
}
```

### Get current temperature
```csharp
using NVAPIWrapper;

using var api = NVAPIApiHelper.Initialize();
foreach (var adapter in api.EnumerateAdapters())
{
    var tempHelper = api.GetTemperatureHelper(adapter);
    var sensor = tempHelper.EnumTemperatureSensors().FirstOrDefault();
    if (sensor != IntPtr.Zero)
    {
        var tempC = tempHelper.TemperatureGetState(sensor);
        Console.WriteLine($"{adapter.Name}: {tempC:F1} C");
    }
}
```

### Wait for a property change on an adapter
```csharp
using NVAPIWrapper;

using var api = NVAPIApiHelper.Initialize();
var adapter = api.EnumerateAdapters().First();
var args = new ctl_wait_property_change_args_t
{
    Size = (uint)sizeof(ctl_wait_property_change_args_t),
    Version = 0,
    PropertyType = ctl_property_type_flags_t.CTL_PROPERTY_TYPE_FLAG_DISPLAY,
    TimeOutMilliSec = 5_000 // 5 seconds
};
adapter.WaitForPropertyChange(args);
Console.WriteLine("Property change observed or timeout reached.");
```

## Doing the same with the native API
If you prefer direct P/Invoke access, use `NVAPIApi` and the generated structs/functions.

### List active display resolutions (native)
```csharp
using NVAPIWrapper;

using var NVAPI = NVAPIApi.Initialize();
foreach (var adapter in NVAPI.EnumerateAdapters())
{
    var displays = NVAPI.EnumerateDisplays(adapter);
    foreach (var display in displays)
    {
        var props = new ctl_display_properties_t { Size = (uint)sizeof(ctl_display_properties_t), Version = 0 };
        if (NVAPI.ctlGetDisplayProperties((_ctl_display_output_handle_t*)display, &props) != ctl_result_t.CTL_RESULT_SUCCESS)
            continue;
        var timing = props.Display_Timing_Info;
        if (timing.HActive == 0 || timing.VActive == 0) continue;
        Console.WriteLine($"{timing.HActive}x{timing.VActive} @ {timing.RefreshRate / 1000.0:F2} Hz");
    }
}
```

### List only combined displays (native)
```csharp
using NVAPIWrapper;

using var NVAPI = NVAPIApi.Initialize();
foreach (var adapter in NVAPI.EnumerateAdapters())
{
    var args = new ctl_combined_display_args_t
    {
        Size = (uint)sizeof(ctl_combined_display_args_t),
        Version = 0,
        OpType = ctl_combined_display_optype_t.CTL_COMBINED_DISPLAY_OPTYPE_QUERY_CONFIG
    };
    var result = NVAPI.ctlGetSetCombinedDisplay((_ctl_device_adapter_handle_t*)adapter, &args);
    if (result == ctl_result_t.CTL_RESULT_SUCCESS && args.IsSupported && args.NumOutputs > 0)
    {
        Console.WriteLine("Combined display present.");
    }
}
```

### Get current temperature (native)
```csharp
using NVAPIWrapper;

using var NVAPI = NVAPIApi.Initialize();
foreach (var adapter in NVAPI.EnumerateAdapters())
{
    uint count = 0;
    if (NVAPI.ctlEnumTemperatureSensors((_ctl_device_adapter_handle_t*)adapter, &count, null) != ctl_result_t.CTL_RESULT_SUCCESS || count == 0)
        continue;

    var sensors = new IntPtr[count];
    unsafe
    {
        fixed (IntPtr* pSensors = sensors)
        {
            if (NVAPI.ctlEnumTemperatureSensors((_ctl_device_adapter_handle_t*)adapter, &count, (_ctl_temp_handle_t**)pSensors) != ctl_result_t.CTL_RESULT_SUCCESS)
                continue;
        }

        double temp = 0;
        if (NVAPI.ctlTemperatureGetState((_ctl_temp_handle_t*)sensors[0], &temp) == ctl_result_t.CTL_RESULT_SUCCESS)
        {
            Console.WriteLine($"{temp:F1} C");
        }
    }
}
```

## Testing
Tests require NVIDIA GPU hardware and the NVAPI DLLs present. They skip gracefully if not available.
```powershell
./test_NVAPI.ps1
# or
dotnet test NVAPIWrapper.NativeTests/NVAPIWrapper.NativeTests.csproj
dotnet test NVAPIWrapper.FacadeTests/NVAPIWrapper.FacadeTests.csproj
```

## Updating bindings
When NVIDIA releases a new NVAPI:
```powershell
./prepare_NVAPI.ps1   # update SDK bits
./build_NVAPI.ps1     # regenerates bindings via ClangSharp and rebuilds
```

## Project structure
- `NVAPIWrapper/` - main wrapper
  - `cs_generated/` - ClangSharp output (auto-generated)
  - `NVAPIApi.cs` - high-level API
  - `NVAPIExtensions.cs` - helpers for common ops
- `NVAPIWrapper.NativeTests/` - native test suite
- `NVAPIWrapper.FacadeTests/` - facade test suite
- `Samples/` - sample apps
- `drivers.gpu.control-library/` - NVAPI SDK payload (populated by prepare script)

## Usage notes
- Always dispose `NVAPIApi` (use `using`); SafeHandle + finalizer backstops leaks.
- Handles returned from enumerate calls are opaque; pass them back to NVAPI or helper methods.
- Facade helpers return DTOs with `bool` properties; use `*Native()` helper methods to access raw structs.
- Struct `Version` fields are bytes in native structs; use `(byte)0/1` in native code paths.

## Contributing
PRs welcome-please add/keep tests passing and let the generator own `cs_generated`.



