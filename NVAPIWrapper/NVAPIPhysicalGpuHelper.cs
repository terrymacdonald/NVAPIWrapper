using System;
using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <summary>
    /// Facade helper for a physical GPU.
    /// </summary>
    public sealed class NVAPIPhysicalGpuHelper : IDisposable
    {
        private const uint NvApiIdGpuGetFullName = 0xCEEE8E9F;
        private const uint NvApiIdGpuGetGpuType = 0xC33BAEB1;
        private const uint NvApiIdGpuGetBusType = 0x1BB18724;
        private const uint NvApiIdGpuGetBusId = 0x1BE0B8E5;
        private const uint NvApiIdEnumNvidiaDisplayHandle = 0x9ABDD40D;
        private const uint NvApiIdGetPhysicalGpusFromDisplay = 0x34EF9506;

        private readonly NVAPIApiHelper _apiHelper;
        private readonly IntPtr _handle;
        private bool _disposed;

        internal NVAPIPhysicalGpuHelper(NVAPIApiHelper apiHelper, IntPtr handle)
        {
            _apiHelper = apiHelper;
            _handle = handle;
        }

        /// <summary>
        /// Get the full name of the GPU.
        /// </summary>
        /// <returns>GPU name string, or null if unavailable.</returns>
        public unsafe string? GetFullName()
        {
            ThrowIfDisposed();

            var getFullName = GetDelegate<NvApiGpuGetFullNameDelegate>(NvApiIdGpuGetFullName, "NvAPI_GPU_GetFullName");
            Span<sbyte> buffer = stackalloc sbyte[NVAPI.NVAPI_SHORT_STRING_MAX];
            buffer[0] = 0;

            fixed (sbyte* pBuffer = buffer)
            {
                var status = getFullName(GetHandle(), pBuffer);
                if (status == _NvAPI_Status.NVAPI_OK)
                    return Marshal.PtrToStringAnsi((IntPtr)pBuffer);

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return null;

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Get the PCI bus ID for the GPU.
        /// </summary>
        /// <returns>Bus ID, or null if unavailable.</returns>
        public unsafe uint? GetBusId()
        {
            ThrowIfDisposed();

            var getBusId = GetDelegate<NvApiGpuGetBusIdDelegate>(NvApiIdGpuGetBusId, "NvAPI_GPU_GetBusId");
            uint busId = 0;
            var status = getBusId(GetHandle(), &busId);
            if (status == _NvAPI_Status.NVAPI_OK)
                return busId;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the GPU bus type.
        /// </summary>
        /// <returns>Bus type, or null if unavailable.</returns>
        public unsafe _NV_GPU_BUS_TYPE? GetBusType()
        {
            ThrowIfDisposed();

            var getBusType = GetDelegate<NvApiGpuGetBusTypeDelegate>(NvApiIdGpuGetBusType, "NvAPI_GPU_GetBusType");
            _NV_GPU_BUS_TYPE busType = default;
            var status = getBusType(GetHandle(), &busType);
            if (status == _NvAPI_Status.NVAPI_OK)
                return busType;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the GPU type.
        /// </summary>
        /// <returns>GPU type, or null if unavailable.</returns>
        public unsafe _NV_GPU_TYPE? GetGpuType()
        {
            ThrowIfDisposed();

            var getGpuType = GetDelegate<NvApiGpuGetGpuTypeDelegate>(NvApiIdGpuGetGpuType, "NvAPI_GPU_GetGPUType");
            _NV_GPU_TYPE gpuType = default;
            var status = getGpuType(GetHandle(), &gpuType);
            if (status == _NvAPI_Status.NVAPI_OK)
                return gpuType;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Enumerate NVIDIA display handles associated with this GPU.
        /// </summary>
        /// <returns>Array of display helpers, or empty if none are found.</returns>
        public unsafe NVAPIDisplayHelper[] EnumerateNvidiaDisplayHandles()
        {
            ThrowIfDisposed();

            var enumDisplays = GetDelegate<NvApiEnumNvidiaDisplayHandleDelegate>(
                NvApiIdEnumNvidiaDisplayHandle,
                "NvAPI_EnumNvidiaDisplayHandle");
            var getPhysicalFromDisplay = GetDelegate<NvApiGetPhysicalGpusFromDisplayDelegate>(
                NvApiIdGetPhysicalGpusFromDisplay,
                "NvAPI_GetPhysicalGPUsFromDisplay");

            var helpers = new NVAPIDisplayHelper[NVAPI.NVAPI_MAX_DISPLAYS];
            var count = 0;

            for (uint index = 0; index < NVAPI.NVAPI_MAX_DISPLAYS; index++)
            {
                NvDisplayHandle__* displayHandle;
                var status = enumDisplays(index, &displayHandle);

                if (status == _NvAPI_Status.NVAPI_END_ENUMERATION)
                    break;

                if (status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND || status == _NvAPI_Status.NVAPI_NOT_SUPPORTED)
                    return Array.Empty<NVAPIDisplayHelper>();

                if (status != _NvAPI_Status.NVAPI_OK)
                    throw new NVAPIException(status);

                var gpuHandles = stackalloc NvPhysicalGpuHandle__*[NVAPI.NVAPI_MAX_PHYSICAL_GPUS];
                uint gpuCount = 0;
                status = getPhysicalFromDisplay(displayHandle, gpuHandles, &gpuCount);

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return Array.Empty<NVAPIDisplayHelper>();

                if (status == _NvAPI_Status.NVAPI_INVALID_HANDLE || status == _NvAPI_Status.NVAPI_HANDLE_INVALIDATED)
                    continue;

                if (status != _NvAPI_Status.NVAPI_OK)
                    throw new NVAPIException(status);

                var max = (int)Math.Min(gpuCount, NVAPI.NVAPI_MAX_PHYSICAL_GPUS);
                for (var i = 0; i < max; i++)
                {
                    if ((IntPtr)gpuHandles[i] == _handle)
                    {
                        helpers[count++] = new NVAPIDisplayHelper(_apiHelper, (IntPtr)displayHandle);
                        break;
                    }
                }
            }

            if (count == 0)
                return Array.Empty<NVAPIDisplayHelper>();

            var result = new NVAPIDisplayHelper[count];
            Array.Copy(helpers, result, count);
            return result;
        }

        private unsafe NvPhysicalGpuHandle__* GetHandle()
        {
            return (NvPhysicalGpuHandle__*)_handle;
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
                throw new ObjectDisposedException(nameof(NVAPIPhysicalGpuHelper));

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
        private unsafe delegate _NvAPI_Status NvApiGpuGetFullNameDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, sbyte* szName);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetBusIdDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, uint* pBusId);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetBusTypeDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, _NV_GPU_BUS_TYPE* pBusType);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetGpuTypeDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, _NV_GPU_TYPE* pGpuType);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiEnumNvidiaDisplayHandleDelegate(uint thisEnum, NvDisplayHandle__** pNvDispHandle);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGetPhysicalGpusFromDisplayDelegate(NvDisplayHandle__* hNvDisp, NvPhysicalGpuHandle__** nvGPUHandle, uint* pGpuCount);
    }
}
