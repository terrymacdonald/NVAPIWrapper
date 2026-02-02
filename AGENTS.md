# AGENTS Guide for NVAPIWrapper

This file captures the essential rules and context for agents working on this NVAPIWrapper repository. 

## Project Scope
- Purpose: Safe C# wrapper over NVIDIA NVAPI (function-pointer lookup via NvAPI_QueryInterface; some COM-style interfaces exist in headers) for Windows x64 targeting .NET 10.0 and higher.
- Structure: 
    - Root `NVAPIWrapper/` project (helpers + `cs_generated/` bindings),
    - `NVAPIWrapper.NativeTests/` xUnit native test suite,
    - `NVAPIWrapper.FacadeTests/` xUnit facade test suite,
    - `Samples/`, scripts for prepare/build/test.
- Two API Levels: There are two levels of NVAPIWRapper API available for users to use. 
    - Native: This level is low level and use the C# equivalent functions in NVAPIWrapper that were created by ClangSharpPInvokeGenerator, and are found in `../NVAPIWrapper/cs_generated`. These are the functions that are the C# equivalent of the C++ NVIDIA NVAPI SDK described in the `nvapi\*.h` headers, so please look there if you need to know what they are.
    - Facade: This level uses helper functions to abstract away any memory management, and to make it very easy and simple to access the information provided by the NVAPI SDK.

## Core Development Rules
- ALWAYS MAKE SURE THAT YOU TELL THE USER YOUR PLAN BEFORE YOU MAKE ANY CHANGES TO FILES AND GIVE THE USER A CHANCE TO REVIEW. ONLY MAKE CHANGS ONCE THE USER HAS GIVEN THEIR APPROVAL. The user can tell you to perform multiple steps of a plan if you want to.
- When PLANNING, if you think you will get confused and lose track of where you are in your plan, then please write it down into a PLAN.md document. Keep the PLAN.md updated as you go, and make sure that the information you store in the PLAN.md is very descriptive and detailed, so that if you lose track in the future you can review the PLAN.md and you will know what to do and will do it well. Do not be overly concise as you lose a lot of nuance that will be important.
- DO NOT MAKE THINGS UP. Always check the NVIDIA NVAPI SDK header files in `NVAPI\`, or the NVIDIA NVAPI SDK docs in `NVAPI\docs`, or the NVAPIWrapper code in `NVAPIWrapper` if you need more information. If you are unsure then tell the user. The user wants you to only use facts - not conjecture. Tune your temperature to the lowest you can. You must be factual in your answers - DO NOT INVENT OR MAKJE ANYTHING UP. ACCURACY IS THE MOST IMPORTANT THING.
- Write code that tries to be robust and cope with problems getting the information requested, but without causing an exception or a crash. 
- Naming/patterns: Preserve established coding patterns and styles across this project. Ask the user for permission if you need to deviate from those styles.
- Preserve established helper naming (`NVAPI<Feature>ServicesHelper`, `Get<Feature>ServicesNative()`, `Get<Feature>Services()`). Replicate existing helper/test patterns for new features. Consistently of API is key. The user has spent a long time trying to keep everything standard and consistent, so make sure new creations align with existing patterns. Ask for permission for anything that does not align.
- Platform: Windows-only, x64; relies on NVIDIA drivers. Lightweight check is `IsNVAPIDllAvailable`.
- Any initialisation code generated needs to avoid it or handle it when getting an NVAPI_ALREADY_INITIALIZED exception when trying to initialise NVAPI a second time, and avoid or handle NVAPI_NOT_SUPPORTED exceptions on optional functions.
- Always make sure that the XML Comments that describe a function are always added to any functions and structs/enums so that XML documents can be generated for the DLL , so that they will be available in Intellisense when the VSCode or Visual Studio IDE is used.
- If you need to run scripts, note that all development is being done on Windows 11 x64 machines, and within Powershell terminals. You MUST make sure that your scripts will run in a powershell environment on a Windows 11 x64 machine.

## ClangSharpPInvokeGenerator development rules
- If you need to change the ClangSharp created functions or tests, then the only way to modify them is by tweaking the ClangSharpConfig.rsp file within the `NVAPIWrapper\` folder.
- Make sure that you only provide valid commands that can be used by ClangSharpPInvokeGenerator. Make sure the commands are valid before using them.

## Core Native-specific Development Rules
- Follow the usage patterns shown in the NVIDIA NVAPI SDK Samples as closely as possible to ensure that the C# Native functions will work. The NVAPI SDK Samples can be found in `nvapi\Sample_Code`. Please also look at the `nvapi\*.h` headers and `nvapi\docs` for more information about how the NVAPI SDK works. 
- Generated code: Do not hand-edit `cs_generated/`. Changes come from headers/config used by `ClangSharpPInvokeGenerator` (`GenerateBindings` target in `NVAPIWrapper.csproj`).
- The Native level functions should always be developed and tested first. Those low level functions will be used by Facade level functions, so its important that we make sure that they Native functinos work before moving up to the higher-level Facade functions.
- Initialization (Native): Use `using var NVAPI = NVAPIApi.Initialize();`.  `NVAPIApi.Initialize()` calls `NVAPI_Initialize()` and unloads the DLL;Wrap returned pointers for lifetime safety if needed.
- Disposal (Native): Dispose any system services and child pointers before disposing `NVAPI`. `NVAPIApi.Dispose` calls `NVAPI_Unload` and unloads the DLL; any call after disposal should throw `ObjectDisposedException`.

## Core Facade-Specific Development Rules
- Facade level objects should handle all underlying Native level memory management themselves. The user should not need to worry about it. This includes memory creation, disposal when objects are deleted, and handling functions being called multiple times in threads. Our aim is to never have memory leaks when using Facades.
- The Facade functions should (in general) return Helper objects that represent the relevant objects within the underlying NVAPI SDK, for example NVAPIDesktop. Each returned Facade object should have properties that store the information contained within the underlying Native objects e.g. NativeResolutionWidth, and Access to any underlying functions that are offered by the Native objects e.g. NVAPIDisplayServicesHelper providing an EnumerateDisplays() function that returns a list of Displays currently known to Windows.
- The Facade functions can also offer some additional functions that provide an advanced user with access to the underlying Native objects, or Native pointers to the underlying objects if it makes sense to do so. 
 - Facade DTO Pattern: Helpers are stateful wrappers around NVAPI handles and lifetime checks; getter methods return DTO snapshots for persistence/equality control; setter methods accept DTOs and apply settings via native calls; DTOs define the equality/storage boundary while helpers manage interop and memory.
- Direct3D/DX-specific NVAPI entry points (e.g., `NvAPI_D3D*`, `NvAPI_Direct*`) are **native-only** and are **not** wrapped by the facade.
- Initialization (Facade): Use `using var NVAPI = NVAPIApiHelper.Initialize();` as the standard entry point. Retrieve system services via `using var system = NVAPI.GetSystemServices();` and work with facade helpers (pointer-free for consumers).
- Disposal (Facade): Dispose facade system services and returned facade objects before disposing `NVAPI`. Underlying `ComPtr` ownership is handled internally; do not manually release native pointers owned by helpers. `NVAPIApiHelper` disposal should result in `ObjectDisposedException` on use-after-dispose.
- Vtable interop: Generated interfaces/enums in `NVAPIWrapper/cs_generated/`. When calling vtable functions directly, use `Marshal.GetDelegateForFunctionPointer` with `StdCall`. Make sure that the vtable is up to date and aligns with the generated code created by ClangSharpPInvokeGenerator.

## Build and Scripts
- Prepare: `./prepare_nvapi.ps1` (downloads/validates NVAPI SDK headers into `nvapi/`).
- Build: `./build_nvapi.ps1` (restores, cleans, builds solution; version from `VERSION` + git commit count). Direct build: `dotnet build NVAPIWrapper/NVAPIWrapper.csproj`.
- Release ZIP: `./create_nvapi_release_zip.ps1` (produces artifacts/NVAPIwrapper-<version>-Release.zip).

## Testing Expectations
- CRITICAL: The tests are designed to find errors in the NVAPIWrapper library. DO NOT PATCH TESTS SO THAT THEY RUN SUCCESSFULLY TO AVOID UNDERLYING ERRORS IN THE NVAPIWRAPPER LIBRARY. THE WHOLE POINT OF TESTING IS TO FIND UNDERLYING ERRORS IN THE NVAPIWRAPPER LIBRARY SO THAT THEY CAN BE FIXED. Any tests for 
- Unsupported functionality: THere may be some features that are offered by the NVAPI SDK that are not supported by our tests hardware or the version of the driver we are using. ANY OPTIONAL FEATURES SHOULD BE GATED BYT TESTS THAT CONFIRM THEIR SUPPORT BEFORE THEY ARE RUN. Unsupported features should be skipped using xUnit.Skip.
- Suites: xUnit in `NVAPIWrapper.NativeTests` (Native) and `NVAPIWrapper.FacadeTests` (Facade) targeting `net10.0`; hardware-aware and read-only (no tuning changes). Global xUnit parallelization is disabled.
- Test one feature per individual test case, as we want to keep good visibility for the user as to which test fails.
- Run (Native first): `dotnet test NVAPIWrapper.NativeTests/NVAPIWrapper.NativeTests.csproj --verbosity normal` (or from tests folder), or `./test_NVAPI.ps1`. Then run facades with `dotnet test NVAPIWrapper.FacadeTests/NVAPIWrapper.FacadeTests.csproj --verbosity normal`.
- Both Native and Facade tests should test the full range of the NVIDIA NVAPI API. 
- Test Filenames should align with each of the feature areas being tested. e.g. 
  - NVAPIDesktopServicesNativeTests.cs should be where the Native tests that exercise the INVAPIDesktop objects live, and 
  - NVAPIDesktopSErvicesHelperFacadeTests.cs should be where the Facade tests that exercise the NVAPIServicesDesktopHelper live.
  - This structure will keep the files small to make it easier for LLMs to edit them, and make it easier for humans to find the functions when they need fixing.
- Native vs Facade tests:
  - Native (`*NativeTests.cs`): Use only ClangSharp-generated APIs in `NVAPIWrapper/cs_generated`; never call facades as they will be tested in the Facade tests. THe Native tests should be able to run and pass successfully even if all the NVAPIWrapper Facade functions were removed.
  - Facade (`*FacadeTests.cs`): Exercise helper/facade ergonomics built on native APIs.
- Test creation: Write Native tests first to validate low-level APIs, then Facade tests. If NVAPI marks features optional or provides `IsSupported`, gate tests accordingly; skip only when unsupported. Fix underlying wrapper bugs rather than skipping failing coverage. Shared fixtures for bootstrapping NVAPI are acceptable; keep initialization/disposal safe across tests.
- Hardware skip: Tests that need NVIDIA GPU/driver or NVAPI DLL gracefully skip when missing.

## Usage Notes
- DLL loading: `NVAPIApi` dynamically loads `nvapi64.dll` via `LoadLibraryEx`; keep `NVAPINative.GetDllName()` and `NVAPIApi.LoadNVAPIDll()` in sync if names/paths change; surface errors via `NVAPIException`.
- Function lookup: NVAPI uses `NvAPI_QueryInterface` IDs listed in `nvapi\nvapi_interface.h`; treat missing IDs as unsupported when resolving function pointers.
- Handles: NVAPI handles are opaque and can be invalidated by display/GPU reconfiguration; on `NVAPI_HANDLE_INVALIDATED`, discard handles and re-enumerate.
- Struct versions: Always initialize structure version fields using the NVAPI macros (e.g., `NV_XXX.version = NV_XXX_VER`) before calling into NVAPI.
- Data shapes: Helpers expose serializable `Info` structs (e.g., `GpuInfo`, `DisplayInfo`) and support apply/restore flows.
- Samples: See `NVAPIWrapper/README.md` and `Samples/` for usage patterns (enumeration, capability checks, event listeners).

## Versioning
- Version scheme: `VERSION` provides MAJOR.MINOR; PATCH computed from git commit count via `SetVersionFromGit` and `build_NVAPI.ps1`. Update `VERSION` when bumping MAJOR/MINOR.

## Expectations for Agents
- Keep APIs and helpers consistent with existing conventions; avoid breaking established patterns. Consistentcy is key across the whole codebase. Do not deviate from this consistency without first requesting permission from the user. 
- Respect disposal and pointer ownership rules; ensure safe lifetime handling.
- Prefer generated enums (e.g., `NVAPI_VRAM_TYPE`) over custom ones to align with NVAPI updates.
- Maintain optional-feature gating and hardware skip behavior in tests and helpers.
