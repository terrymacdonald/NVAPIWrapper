using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <summary>
    /// Main NVAPI wrapper providing safe access to NVIDIA NVAPI through QueryInterface.
    /// </summary>
    public sealed class NVAPIApi : IDisposable
    {
        private const uint NvApiIdInitialize = 0x0150e828;
        private const uint NvApiIdUnload = 0xD22BDD7E;
        private const uint NvApiIdGetErrorMessage = 0x6C2D048C;
        private const uint NvApiIdGetInterfaceVersionString = 0x01053FA5;
        private const uint NvApiIdEnumPhysicalGPUs = 0xE5AC921F;
        private const uint NvApiIdEnumLogicalGPUs = 0x48B3EA59;
        private const uint NvApiIdEnumNvidiaDisplayHandle = 0x9ABDD40D;

        private readonly NVAPINative.NvApiQueryInterfaceDelegate _queryInterface;
        private IntPtr _module;
        private bool _disposed;
        private bool _initialized;

        private NVAPIApi(IntPtr module, NVAPINative.NvApiQueryInterfaceDelegate queryInterface)
        {
            _module = module;
            _queryInterface = queryInterface;
        }

        ~NVAPIApi()
        {
            Dispose(false);
        }

        /// <summary>
        /// Initialize NVAPI and return a wrapper that owns the library lifetime.
        /// </summary>
        /// <returns>Initialized NVAPI wrapper.</returns>
        public static NVAPIApi Initialize()
        {
            var module = NVAPINative.LoadLibraryEx(
                NVAPINative.GetDllName(),
                IntPtr.Zero,
                NVAPINative.LOAD_LIBRARY_SEARCH_USER_DIRS |
                NVAPINative.LOAD_LIBRARY_SEARCH_APPLICATION_DIR |
                NVAPINative.LOAD_LIBRARY_SEARCH_DEFAULT_DIRS |
                NVAPINative.LOAD_LIBRARY_SEARCH_SYSTEM32);

            if (module == IntPtr.Zero)
            {
                var error = Marshal.GetLastWin32Error();
                throw new DllNotFoundException($"NVAPI DLL '{NVAPINative.GetDllName()}' could not be loaded (Error: {error}).");
            }

            NVAPIApi? api = null;
            try
            {
                var queryInterface = NVAPINative.GetQueryInterface(module);
                api = new NVAPIApi(module, queryInterface);

                var initialize = api.GetRequiredFunction<NvApiInitializeDelegate>(NvApiIdInitialize, "NvAPI_Initialize");
                var status = initialize();
                if (status != _NvAPI_Status.NVAPI_OK)
                {
                    var message = api.TryGetErrorMessage(status);
                    throw new NVAPIException(status, message);
                }

                api._initialized = true;
                return api;
            }
            catch
            {
                if (api != null)
                {
                    api.Dispose();
                }
                else
                {
                    NVAPINative.FreeLibrary(module);
                }
                throw;
            }
        }

        /// <summary>
        /// Check if the NVAPI DLL is available in the DLL search path.
        /// </summary>
        /// <param name="errorMessage">Details about why the DLL could not be loaded.</param>
        /// <returns>True if DLL can be loaded; otherwise, false.</returns>
        public static bool IsNVAPIDllAvailable(out string errorMessage)
        {
            IntPtr handle = NVAPINative.LoadLibraryEx(
                NVAPINative.GetDllName(),
                IntPtr.Zero,
                NVAPINative.LOAD_LIBRARY_SEARCH_USER_DIRS |
                NVAPINative.LOAD_LIBRARY_SEARCH_APPLICATION_DIR |
                NVAPINative.LOAD_LIBRARY_SEARCH_DEFAULT_DIRS |
                NVAPINative.LOAD_LIBRARY_SEARCH_SYSTEM32);

            if (handle == IntPtr.Zero)
            {
                var error = Marshal.GetLastWin32Error();
                errorMessage = $"NVAPI DLL '{NVAPINative.GetDllName()}' not found in DLL search path (Error: {error}).";
                return false;
            }

            NVAPINative.FreeLibrary(handle);
            errorMessage = string.Empty;
            return true;
        }

        /// <summary>
        /// Get the NVAPI interface version string.
        /// </summary>
        /// <returns>Version string, or null if unavailable.</returns>
        public unsafe string? GetInterfaceVersionString()
        {
            ThrowIfDisposed();
            var functionPtr = TryGetFunctionPointer(NvApiIdGetInterfaceVersionString);
            if (functionPtr == IntPtr.Zero)
                return null;

            var getVersion = Marshal.GetDelegateForFunctionPointer<NvApiGetInterfaceVersionStringDelegate>(functionPtr);
            Span<sbyte> buffer = stackalloc sbyte[NVAPI.NVAPI_SHORT_STRING_MAX];
            buffer[0] = 0;
            fixed (sbyte* pBuffer = buffer)
            {
                var status = getVersion(pBuffer);
                if (status != _NvAPI_Status.NVAPI_OK)
                    return null;

                return Marshal.PtrToStringAnsi((IntPtr)pBuffer);
            }
        }

        /// <summary>
        /// Enumerate NVAPI function IDs and indicate which are available in the loaded driver.
        /// </summary>
        /// <returns>List of function info entries.</returns>
        public unsafe IReadOnlyList<NVAPIFunctionInfo> GetAvailableFunctions()
        {
            ThrowIfDisposed();

            var table = NVAPIInterfaceTable.Entries;
            var functions = new List<NVAPIFunctionInfo>(table.Length);

            foreach (var entry in table)
            {
                if (string.IsNullOrEmpty(entry.Name))
                    continue;

                var available = TryGetFunctionPointer(entry.Id) != IntPtr.Zero;
                functions.Add(new NVAPIFunctionInfo(entry.Name, entry.Id, available));
            }

            return functions;
        }

        /// <summary>
        /// Enumerate physical GPU handles.
        /// </summary>
        /// <returns>Array of physical GPU handles, or empty if none are found.</returns>
        public unsafe NvPhysicalGpuHandle__*[] EnumeratePhysicalGpus()
        {
            ThrowIfDisposed();

            var enumPhysical = GetRequiredFunction<NvApiEnumPhysicalGPUsDelegate>(NvApiIdEnumPhysicalGPUs, "NvAPI_EnumPhysicalGPUs");
            var handles = stackalloc NvPhysicalGpuHandle__*[NVAPI.NVAPI_MAX_PHYSICAL_GPUS];
            uint count = 0;

            var status = enumPhysical(handles, &count);
            if (status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND || status == _NvAPI_Status.NVAPI_NOT_SUPPORTED)
                return new NvPhysicalGpuHandle__*[0];

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status, TryGetErrorMessage(status));

            if (count == 0)
                return new NvPhysicalGpuHandle__*[0];

            var max = (int)Math.Min(count, NVAPI.NVAPI_MAX_PHYSICAL_GPUS);
            var result = new NvPhysicalGpuHandle__*[max];
            for (var i = 0; i < max; i++)
            {
                result[i] = handles[i];
            }

            return result;
        }

        /// <summary>
        /// Enumerate logical GPU handles.
        /// </summary>
        /// <returns>Array of logical GPU handles, or empty if none are found.</returns>
        public unsafe NvLogicalGpuHandle__*[] EnumerateLogicalGpus()
        {
            ThrowIfDisposed();

            var enumLogical = GetRequiredFunction<NvApiEnumLogicalGPUsDelegate>(NvApiIdEnumLogicalGPUs, "NvAPI_EnumLogicalGPUs");
            var handles = stackalloc NvLogicalGpuHandle__*[NVAPI.NVAPI_MAX_LOGICAL_GPUS];
            uint count = 0;

            var status = enumLogical(handles, &count);
            if (status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND || status == _NvAPI_Status.NVAPI_NOT_SUPPORTED)
                return new NvLogicalGpuHandle__*[0];

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status, TryGetErrorMessage(status));

            if (count == 0)
                return new NvLogicalGpuHandle__*[0];

            var max = (int)Math.Min(count, NVAPI.NVAPI_MAX_LOGICAL_GPUS);
            var result = new NvLogicalGpuHandle__*[max];
            for (var i = 0; i < max; i++)
            {
                result[i] = handles[i];
            }

            return result;
        }

        /// <summary>
        /// Enumerate NVIDIA display handles.
        /// </summary>
        /// <returns>Array of display handles, or empty if none are found.</returns>
        public unsafe NvDisplayHandle__*[] EnumerateNvidiaDisplayHandles()
        {
            ThrowIfDisposed();

            var enumDisplays = GetRequiredFunction<NvApiEnumNvidiaDisplayHandleDelegate>(NvApiIdEnumNvidiaDisplayHandle, "NvAPI_EnumNvidiaDisplayHandle");
            var handles = new NvDisplayHandle__*[NVAPI.NVAPI_MAX_DISPLAYS];
            var count = 0;

            for (uint index = 0; index < NVAPI.NVAPI_MAX_DISPLAYS; index++)
            {
                NvDisplayHandle__* handle;
                var status = enumDisplays(index, &handle);

                if (status == _NvAPI_Status.NVAPI_END_ENUMERATION)
                    break;

                if (status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND || status == _NvAPI_Status.NVAPI_NOT_SUPPORTED)
                    return new NvDisplayHandle__*[0];

                if (status != _NvAPI_Status.NVAPI_OK)
                    throw new NVAPIException(status, TryGetErrorMessage(status));

                handles[count++] = handle;
            }

            if (count == 0)
                return new NvDisplayHandle__*[0];

            var result = new NvDisplayHandle__*[count];
            Array.Copy(handles, result, count);
            return result;
        }

        /// <summary>
        /// Dispose the NVAPI wrapper and release native resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (_initialized)
            {
                try
                {
                    var unload = GetRequiredFunction<NvApiUnloadDelegate>(NvApiIdUnload, "NvAPI_Unload");
                    unload();
                }
                catch
                {
                    // Avoid throwing during dispose.
                }

                _initialized = false;
            }

            if (_module != IntPtr.Zero)
            {
                NVAPINative.FreeLibrary(_module);
                _module = IntPtr.Zero;
            }

            _disposed = true;
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(NVAPIApi));
        }

        internal IntPtr TryGetFunctionPointer(uint id)
        {
            ThrowIfDisposed();
            return _queryInterface(id);
        }

        private T GetRequiredFunction<T>(uint id, string name) where T : Delegate
        {
            var functionPtr = TryGetFunctionPointer(id);
            if (functionPtr == IntPtr.Zero)
            {
                throw new NVAPIException(_NvAPI_Status.NVAPI_NO_IMPLEMENTATION, $"NVAPI function '{name}' (0x{id:X8}) not available.");
            }
            return Marshal.GetDelegateForFunctionPointer<T>(functionPtr);
        }

        private unsafe string? TryGetErrorMessage(_NvAPI_Status status)
        {
            var functionPtr = TryGetFunctionPointer(NvApiIdGetErrorMessage);
            if (functionPtr == IntPtr.Zero)
                return null;

            var getErrorMessage = Marshal.GetDelegateForFunctionPointer<NvApiGetErrorMessageDelegate>(functionPtr);
            Span<sbyte> buffer = stackalloc sbyte[NVAPI.NVAPI_SHORT_STRING_MAX];
            buffer[0] = 0;
            fixed (sbyte* pBuffer = buffer)
            {
                var result = getErrorMessage(status, pBuffer);
                if (result != _NvAPI_Status.NVAPI_OK)
                    return null;

                return Marshal.PtrToStringAnsi((IntPtr)pBuffer);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate _NvAPI_Status NvApiInitializeDelegate();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate _NvAPI_Status NvApiUnloadDelegate();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGetErrorMessageDelegate(_NvAPI_Status status, sbyte* description);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGetInterfaceVersionStringDelegate(sbyte* description);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiEnumPhysicalGPUsDelegate(NvPhysicalGpuHandle__** nvGPUHandle, uint* pGpuCount);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiEnumLogicalGPUsDelegate(NvLogicalGpuHandle__** nvGPUHandle, uint* pGpuCount);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiEnumNvidiaDisplayHandleDelegate(uint thisEnum, NvDisplayHandle__** pNvDispHandle);
    }
}
