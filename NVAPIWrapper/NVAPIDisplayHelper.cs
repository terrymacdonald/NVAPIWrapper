using System;
using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <summary>
    /// Facade helper for an NVIDIA display handle.
    /// </summary>
    public sealed class NVAPIDisplayHelper : IDisposable
    {
        private const uint NvApiIdGetPhysicalGpusFromDisplay = 0x34EF9506;
        private const uint NvApiIdGetLogicalGpuFromDisplay = 0xEE1370CF;

        private readonly NVAPIApiHelper _apiHelper;
        private readonly IntPtr _handle;
        private bool _disposed;

        internal NVAPIDisplayHelper(NVAPIApiHelper apiHelper, IntPtr handle)
        {
            _apiHelper = apiHelper;
            _handle = handle;
        }

        /// <summary>
        /// Get physical GPUs associated with this display.
        /// </summary>
        /// <returns>Array of physical GPU helpers, or empty if unavailable.</returns>
        public unsafe NVAPIPhysicalGpuHelper[] GetPhysicalGpusFromDisplay()
        {
            ThrowIfDisposed();

            var getPhysical = GetDelegate<NvApiGetPhysicalGpusFromDisplayDelegate>(
                NvApiIdGetPhysicalGpusFromDisplay,
                "NvAPI_GetPhysicalGPUsFromDisplay");

            var handles = stackalloc NvPhysicalGpuHandle__*[NVAPI.NVAPI_MAX_PHYSICAL_GPUS];
            uint count = 0;

            var status = getPhysical(GetHandle(), handles, &count);
            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return Array.Empty<NVAPIPhysicalGpuHelper>();

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            if (count == 0)
                return Array.Empty<NVAPIPhysicalGpuHelper>();

            var max = (int)Math.Min(count, NVAPI.NVAPI_MAX_PHYSICAL_GPUS);
            var result = new NVAPIPhysicalGpuHelper[max];
            for (var i = 0; i < max; i++)
            {
                result[i] = new NVAPIPhysicalGpuHelper(_apiHelper, (IntPtr)handles[i]);
            }

            return result;
        }

        /// <summary>
        /// Get the logical GPU associated with this display.
        /// </summary>
        /// <returns>Logical GPU helper, or null if unavailable.</returns>
        public unsafe NVAPILogicalGpuHelper? GetLogicalGpuFromDisplay()
        {
            ThrowIfDisposed();

            var getLogical = GetDelegate<NvApiGetLogicalGpuFromDisplayDelegate>(
                NvApiIdGetLogicalGpuFromDisplay,
                "NvAPI_GetLogicalGPUFromDisplay");

            NvLogicalGpuHandle__* logical;
            var status = getLogical(GetHandle(), &logical);
            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            return new NVAPILogicalGpuHelper(_apiHelper, (IntPtr)logical);
        }

        private unsafe NvDisplayHandle__* GetHandle()
        {
            return (NvDisplayHandle__*)_handle;
        }

        private T GetDelegate<T>(uint id, string name) where T : Delegate
        {
            var functionPtr = _apiHelper.Api.TryGetFunctionPointer(id);
            if (functionPtr == IntPtr.Zero)
            {
                throw new NVAPIException(_NvAPI_Status.NVAPI_NO_IMPLEMENTATION, $"NVAPI function '{name}' (0x{id:X8}) not available.");
            }

            return Marshal.GetDelegateForFunctionPointer<T>(functionPtr);
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(NVAPIDisplayHelper));

            _apiHelper.ThrowIfDisposed();
        }

        /// <summary>
        /// Dispose the helper and prevent further use.
        /// </summary>
        public void Dispose()
        {
            if (_disposed)
                return;

            _disposed = true;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGetPhysicalGpusFromDisplayDelegate(NvDisplayHandle__* hNvDisp, NvPhysicalGpuHandle__** nvGPUHandle, uint* pGpuCount);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGetLogicalGpuFromDisplayDelegate(NvDisplayHandle__* hNvDisp, NvLogicalGpuHandle__** pLogicalGPU);
    }
}
