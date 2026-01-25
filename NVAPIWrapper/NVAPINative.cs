using System;
using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <summary>
    /// Manual P/Invoke declarations and helpers for loading nvapi64.dll and resolving NvAPI_QueryInterface.
    /// </summary>
    internal static class NVAPINative
    {
        private const string NVAPI_DLL_NAME_64 = "nvapi64.dll";
        private const string NVAPI_DLL_NAME_32 = "nvapi.dll";

        /// <summary>
        /// Get the NVAPI DLL name for the current process bitness.
        /// </summary>
        public static string GetDllName()
        {
            return Environment.Is64BitProcess ? NVAPI_DLL_NAME_64 : NVAPI_DLL_NAME_32;
        }

        /// <summary>
        /// Delegate for the nvapi_QueryInterface export.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr NvApiQueryInterfaceDelegate(uint id);

        // Windows API functions for dynamic loading
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr LoadLibraryEx(
            string lpFileName,
            IntPtr hFile,
            uint dwFlags);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        // LoadLibraryEx flags
        public const uint LOAD_LIBRARY_SEARCH_USER_DIRS = 0x00000400;
        public const uint LOAD_LIBRARY_SEARCH_APPLICATION_DIR = 0x00000200;
        public const uint LOAD_LIBRARY_SEARCH_DEFAULT_DIRS = 0x00001000;
        public const uint LOAD_LIBRARY_SEARCH_SYSTEM32 = 0x00000800;

        /// <summary>
        /// Resolve the nvapi_QueryInterface export and return a delegate.
        /// </summary>
        public static NvApiQueryInterfaceDelegate GetQueryInterface(IntPtr module)
        {
            var functionPtr = GetProcAddress(module, "nvapi_QueryInterface");
            if (functionPtr == IntPtr.Zero)
            {
                functionPtr = GetProcAddress(module, "NvAPI_QueryInterface");
            }

            if (functionPtr == IntPtr.Zero)
            {
                throw new EntryPointNotFoundException("nvapi_QueryInterface not found in NVAPI DLL.");
            }

            return Marshal.GetDelegateForFunctionPointer<NvApiQueryInterfaceDelegate>(functionPtr);
        }
    }
}
