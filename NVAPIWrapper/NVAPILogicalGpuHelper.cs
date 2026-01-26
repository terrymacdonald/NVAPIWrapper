using System;
using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <summary>
    /// Facade helper for a logical GPU.
    /// </summary>
    public sealed class NVAPILogicalGpuHelper : IDisposable
    {
        private const uint NvApiIdGetPhysicalGpusFromLogicalGpu = 0xAEA3FA32;

        private readonly NVAPIApiHelper _apiHelper;
        private readonly IntPtr _handle;
        private bool _disposed;

        internal NVAPILogicalGpuHelper(NVAPIApiHelper apiHelper, IntPtr handle)
        {
            _apiHelper = apiHelper;
            _handle = handle;
        }

        /// <summary>
        /// Get physical GPUs that make up this logical GPU.
        /// </summary>
        /// <returns>Array of physical GPU helpers, or empty if unavailable.</returns>
        public unsafe NVAPIPhysicalGpuHelper[] GetPhysicalGpusFromLogicalGpu()
        {
            ThrowIfDisposed();

            var getPhysical = GetDelegate<NvApiGetPhysicalGpusFromLogicalGpuDelegate>(
                NvApiIdGetPhysicalGpusFromLogicalGpu,
                "NvAPI_GetPhysicalGPUsFromLogicalGPU");

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

        private unsafe NvLogicalGpuHandle__* GetHandle()
        {
            return (NvLogicalGpuHandle__*)_handle;
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
                throw new ObjectDisposedException(nameof(NVAPILogicalGpuHelper));

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
        private unsafe delegate _NvAPI_Status NvApiGetPhysicalGpusFromLogicalGpuDelegate(NvLogicalGpuHandle__* hLogicalGpu, NvPhysicalGpuHandle__** hPhysicalGpu, uint* pGpuCount);
    }
}
