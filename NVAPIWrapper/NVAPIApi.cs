using System;
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
    }
}
