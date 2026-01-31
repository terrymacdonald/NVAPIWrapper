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
        private const uint NvApiIdGpuGetPciIdentifiers = 0x2DDFB66E;
        private const uint NvApiIdGpuGetBusSlotId = 0x2A0A350F;
        private const uint NvApiIdGpuGetVbiosVersionString = 0xA561FD7D;
        private const uint NvApiIdGpuGetPhysicalFrameBufferSize = 0x46FBEB03;
        private const uint NvApiIdGpuGetVirtualFrameBufferSize = 0x5A04B644;
        private const uint NvApiIdGpuGetTachReading = 0x5F608315;
        private const uint NvApiIdGpuGetMemoryInfo = 0x07F9B368;
        private const uint NvApiIdGpuGetMemoryInfoEx = 0xC0599498;
        private const uint NvApiIdSysGetDisplayIdFromGpuAndOutputId = 0x08F2BAB4;
        private const uint NvApiIdEnumNvidiaDisplayHandle = 0x9ABDD40D;
        private const uint NvApiIdGetPhysicalGpusFromDisplay = 0x34EF9506;
        private const uint NvApiIdGpuGetShaderSubPipeCount = 0x0BE17923;
        private const uint NvApiIdGpuGetGpuCoreCount = 0xC7026A87;
        private const uint NvApiIdGpuGetSystemType = 0xBAAABFCC;
        private const uint NvApiIdGpuGetActiveOutputs = 0xE3E89B6F;
        private const uint NvApiIdGpuGetConnectedDisplayIds = 0x0078DBA2;
        private const uint NvApiIdGpuGetAllDisplayIds = 0x785210A2;
        private const uint NvApiIdGpuGetPerfDecreaseInfo = 0x7F7F4600;
        private const uint NvApiIdGpuGetPstates20 = 0x6FF81213;
        private const uint NvApiIdGpuGetCurrentPstate = 0x927DA4F6;
        private const uint NvApiIdGpuGetDynamicPstatesInfoEx = 0x60DED2ED;
        private const uint NvApiIdGpuGetThermalSettings = 0xE3640A56;
        private const uint NvApiIdGpuGetAllClockFrequencies = 0xDCB616C3;
        private const uint NvApiIdGpuQueryIlluminationSupport = 0xA629DA31;
        private const uint NvApiIdGpuGetIllumination = 0x9A1B9365;
        private const uint NvApiIdGpuSetIllumination = 0x0254A187;
        private const uint NvApiIdGpuClientIllumDevicesGetInfo = 0xD4100E58;
        private const uint NvApiIdGpuClientIllumDevicesGetControl = 0x73C01D58;
        private const uint NvApiIdGpuClientIllumDevicesSetControl = 0x57024C62;
        private const uint NvApiIdGpuClientIllumZonesGetInfo = 0x4B81241B;
        private const uint NvApiIdGpuClientIllumZonesGetControl = 0x3DBF5764;
        private const uint NvApiIdGpuClientIllumZonesSetControl = 0x197D065E;
        private const uint NvApiIdGpuGetVirtualizationInfo = 0x44E022A9;
        private const uint NvApiIdGpuGetLicensableFeatures = 0x3FC596AA;
        private const uint NvApiIdGpuGetEncoderStatistics = 0xF0A9AEEB;
        private const uint NvApiIdGpuGetEncoderSessionsInfo = 0xD8A72CE5;
        private const uint NvApiIdGpuGetVrReadyData = 0x81D629C5;
        private const uint NvApiIdGpuGetGspFeatures = 0x581C4391;
        private const uint NvApiIdGpuNvlinkGetCaps = 0xBEF1119D;
        private const uint NvApiIdGpuNvlinkGetStatus = 0xC72A38E3;
        private const uint NvApiIdGpuGetGpuInfo = 0xAFD1B02C;
        private const uint NvApiIdI2CRead = 0x2FDE12C5;
        private const uint NvApiIdI2CWrite = 0xE812EB07;

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
        /// Get PCI identifiers for the GPU.
        /// </summary>
        /// <returns>PCI identifiers, or null if unavailable.</returns>
        public unsafe NVAPIPciIdentifiers? GetPCIIdentifiers()
        {
            ThrowIfDisposed();

            var getPci = GetDelegate<NvApiGpuGetPciIdentifiersDelegate>(NvApiIdGpuGetPciIdentifiers, "NvAPI_GPU_GetPCIIdentifiers");
            uint deviceId = 0;
            uint subSystemId = 0;
            uint revisionId = 0;
            uint extDeviceId = 0;

            var status = getPci(GetHandle(), &deviceId, &subSystemId, &revisionId, &extDeviceId);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIPciIdentifiers.FromNative(deviceId, subSystemId, revisionId, extDeviceId);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the PCI bus slot ID for the GPU.
        /// </summary>
        /// <returns>Bus slot ID, or null if unavailable.</returns>
        public unsafe uint? GetBusSlotId()
        {
            ThrowIfDisposed();

            var getBusSlotId = GetDelegate<NvApiGpuGetBusSlotIdDelegate>(NvApiIdGpuGetBusSlotId, "NvAPI_GPU_GetBusSlotId");
            uint busSlotId = 0;
            var status = getBusSlotId(GetHandle(), &busSlotId);
            if (status == _NvAPI_Status.NVAPI_OK)
                return busSlotId;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the VBIOS version string.
        /// </summary>
        /// <returns>VBIOS version string, or null if unavailable.</returns>
        public unsafe string? GetVbiosVersionString()
        {
            ThrowIfDisposed();

            var getVbios = GetDelegate<NvApiGpuGetVbiosVersionStringDelegate>(NvApiIdGpuGetVbiosVersionString, "NvAPI_GPU_GetVbiosVersionString");
            Span<sbyte> buffer = stackalloc sbyte[NVAPI.NVAPI_SHORT_STRING_MAX];
            buffer[0] = 0;

            fixed (sbyte* pBuffer = buffer)
            {
                var status = getVbios(GetHandle(), pBuffer);
                if (status == _NvAPI_Status.NVAPI_OK)
                    return Marshal.PtrToStringAnsi((IntPtr)pBuffer);

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return null;

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Get the physical frame buffer size in kilobytes.
        /// </summary>
        /// <returns>Physical frame buffer size in KB, or null if unavailable.</returns>
        public unsafe uint? GetPhysicalFrameBufferSize()
        {
            ThrowIfDisposed();

            var getPhysical = GetDelegate<NvApiGpuGetPhysicalFrameBufferSizeDelegate>(
                NvApiIdGpuGetPhysicalFrameBufferSize,
                "NvAPI_GPU_GetPhysicalFrameBufferSize");
            uint size = 0;
            var status = getPhysical(GetHandle(), &size);
            if (status == _NvAPI_Status.NVAPI_OK)
                return size;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the virtual frame buffer size in kilobytes.
        /// </summary>
        /// <returns>Virtual frame buffer size in KB, or null if unavailable.</returns>
        public unsafe uint? GetVirtualFrameBufferSize()
        {
            ThrowIfDisposed();

            var getVirtual = GetDelegate<NvApiGpuGetVirtualFrameBufferSizeDelegate>(
                NvApiIdGpuGetVirtualFrameBufferSize,
                "NvAPI_GPU_GetVirtualFrameBufferSize");
            uint size = 0;
            var status = getVirtual(GetHandle(), &size);
            if (status == _NvAPI_Status.NVAPI_OK)
                return size;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the GPU tachometer reading.
        /// </summary>
        /// <returns>Tachometer value, or null if unavailable.</returns>
        public unsafe uint? GetTachReading()
        {
            ThrowIfDisposed();

            var getTach = GetDelegate<NvApiGpuGetTachReadingDelegate>(NvApiIdGpuGetTachReading, "NvAPI_GPU_GetTachReading");
            uint value = 0;
            var status = getTach(GetHandle(), &value);
            if (status == _NvAPI_Status.NVAPI_OK)
                return value;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get display driver memory info (legacy).
        /// </summary>
        /// <returns>Memory info, or null if unavailable.</returns>
        public unsafe NVAPIDisplayDriverMemoryInfoDto? GetMemoryInfo()
        {
            ThrowIfDisposed();

            var getMemoryInfo = GetDelegate<NvApiGpuGetMemoryInfoDelegate>(NvApiIdGpuGetMemoryInfo, "NvAPI_GPU_GetMemoryInfo");
            var info = CreateDisplayDriverMemoryInfo();

            var status = getMemoryInfo(GetHandle(), &info);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIDisplayDriverMemoryInfoDto.FromNative(info);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get extended GPU memory info.
        /// </summary>
        /// <returns>Extended memory info, or null if unavailable.</returns>
        public unsafe NVAPIGpuMemoryInfoExDto? GetMemoryInfoEx()
        {
            ThrowIfDisposed();

            var getMemoryInfo = GetDelegate<NvApiGpuGetMemoryInfoExDelegate>(NvApiIdGpuGetMemoryInfoEx, "NvAPI_GPU_GetMemoryInfoEx");
            var info = CreateGpuMemoryInfoEx();

            var status = getMemoryInfo(GetHandle(), &info);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGpuMemoryInfoExDto.FromNative(info);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Convert a GPU output ID to a display ID.
        /// </summary>
        /// <param name="outputId">Output ID (single bit set).</param>
        /// <returns>Display ID, or null if unavailable.</returns>
        public unsafe uint? GetDisplayIdFromGpuAndOutputId(uint outputId)
        {
            ThrowIfDisposed();

            var getDisplayId = GetDelegate<NvApiSysGetDisplayIdFromGpuAndOutputIdDelegate>(
                NvApiIdSysGetDisplayIdFromGpuAndOutputId,
                "NvAPI_SYS_GetDisplayIdFromGpuAndOutputId");

            uint displayId = 0;
            var status = getDisplayId(GetHandle(), outputId, &displayId);

            if (status == _NvAPI_Status.NVAPI_OK)
                return displayId;

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

            var gpuHandles = stackalloc NvPhysicalGpuHandle__*[NVAPI.NVAPI_MAX_PHYSICAL_GPUS];

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

        /// <summary>
        /// Get the number of shader sub-pipes.
        /// </summary>
        /// <returns>Shader sub-pipe count, or null if unavailable.</returns>
        public unsafe uint? GetShaderSubPipeCount()
        {
            ThrowIfDisposed();

            var getCount = GetDelegate<NvApiGpuGetShaderSubPipeCountDelegate>(
                NvApiIdGpuGetShaderSubPipeCount,
                "NvAPI_GPU_GetShaderSubPipeCount");
            uint count = 0;
            var status = getCount(GetHandle(), &count);
            if (status == _NvAPI_Status.NVAPI_OK)
                return count;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the number of GPU cores.
        /// </summary>
        /// <returns>GPU core count, or null if unavailable.</returns>
        public unsafe uint? GetGpuCoreCount()
        {
            ThrowIfDisposed();

            var getCount = GetDelegate<NvApiGpuGetGpuCoreCountDelegate>(
                NvApiIdGpuGetGpuCoreCount,
                "NvAPI_GPU_GetGpuCoreCount");
            uint count = 0;
            var status = getCount(GetHandle(), &count);
            if (status == _NvAPI_Status.NVAPI_OK)
                return count;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the system type for this GPU.
        /// </summary>
        /// <returns>System type, or null if unavailable.</returns>
        public unsafe NV_SYSTEM_TYPE? GetSystemType()
        {
            ThrowIfDisposed();

            var getSystemType = GetDelegate<NvApiGpuGetSystemTypeDelegate>(
                NvApiIdGpuGetSystemType,
                "NvAPI_GPU_GetSystemType");
            NV_SYSTEM_TYPE systemType = default;
            var status = getSystemType(GetHandle(), &systemType);
            if (status == _NvAPI_Status.NVAPI_OK)
                return systemType;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the active outputs bitmask for this GPU.
        /// </summary>
        /// <returns>Active outputs mask, or null if unavailable.</returns>
        public unsafe uint? GetActiveOutputs()
        {
            ThrowIfDisposed();

            var getActiveOutputs = GetDelegate<NvApiGpuGetActiveOutputsDelegate>(
                NvApiIdGpuGetActiveOutputs,
                "NvAPI_GPU_GetActiveOutputs");
            uint mask = 0;
            var status = getActiveOutputs(GetHandle(), &mask);
            if (status == _NvAPI_Status.NVAPI_OK)
                return mask;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get connected display IDs for this GPU.
        /// </summary>
        /// <param name="flags">Optional flags passed to NvAPI_GPU_GetConnectedDisplayIds.</param>
        /// <returns>Connected display IDs, or empty if unavailable.</returns>
        public unsafe NVAPIGpuDisplayIdDto[] GetConnectedDisplayIds(uint flags = 0)
        {
            ThrowIfDisposed();

            var getDisplayIds = GetDelegate<NvApiGpuGetConnectedDisplayIdsDelegate>(
                NvApiIdGpuGetConnectedDisplayIds,
                "NvAPI_GPU_GetConnectedDisplayIds");

            var native = CreateDisplayIdArray(NVAPI.NVAPI_MAX_DISPLAYS);
            uint count = (uint)native.Length;

            fixed (_NV_GPU_DISPLAYIDS* pNative = native)
            {
                var status = getDisplayIds(GetHandle(), pNative, &count, flags);
                if (status == _NvAPI_Status.NVAPI_OK)
                    return NVAPIGpuDisplayIdDto.FromNative(native, count);

                if (status == _NvAPI_Status.NVAPI_INSUFFICIENT_BUFFER && count > native.Length)
                    return GetConnectedDisplayIdsWithCapacity(flags, count);

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return Array.Empty<NVAPIGpuDisplayIdDto>();

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Get all display IDs for this GPU.
        /// </summary>
        /// <returns>Display IDs, or empty if unavailable.</returns>
        public unsafe NVAPIGpuDisplayIdDto[] GetAllDisplayIds()
        {
            ThrowIfDisposed();

            var getDisplayIds = GetDelegate<NvApiGpuGetAllDisplayIdsDelegate>(
                NvApiIdGpuGetAllDisplayIds,
                "NvAPI_GPU_GetAllDisplayIds");

            var native = CreateDisplayIdArray(NVAPI.NVAPI_MAX_DISPLAYS);
            uint count = (uint)native.Length;

            fixed (_NV_GPU_DISPLAYIDS* pNative = native)
            {
                var status = getDisplayIds(GetHandle(), pNative, &count);
                if (status == _NvAPI_Status.NVAPI_OK)
                    return NVAPIGpuDisplayIdDto.FromNative(native, count);

                if (status == _NvAPI_Status.NVAPI_INSUFFICIENT_BUFFER && count > native.Length)
                    return GetAllDisplayIdsWithCapacity(count);

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return Array.Empty<NVAPIGpuDisplayIdDto>();

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Get the performance decrease reason flags.
        /// </summary>
        /// <returns>Performance decrease flags, or null if unavailable.</returns>
        public unsafe _NVAPI_GPU_PERF_DECREASE? GetPerfDecreaseInfo()
        {
            ThrowIfDisposed();

            var getPerfDecrease = GetDelegate<NvApiGpuGetPerfDecreaseInfoDelegate>(
                NvApiIdGpuGetPerfDecreaseInfo,
                "NvAPI_GPU_GetPerfDecreaseInfo");
            uint flags = 0;
            var status = getPerfDecrease(GetHandle(), &flags);
            if (status == _NvAPI_Status.NVAPI_OK)
                return (_NVAPI_GPU_PERF_DECREASE)flags;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the current performance state ID.
        /// </summary>
        /// <returns>Current P-state ID, or null if unavailable.</returns>
        public unsafe _NV_GPU_PERF_PSTATE_ID? GetCurrentPstate()
        {
            ThrowIfDisposed();

            var getPstate = GetDelegate<NvApiGpuGetCurrentPstateDelegate>(
                NvApiIdGpuGetCurrentPstate,
                "NvAPI_GPU_GetCurrentPstate");
            _NV_GPU_PERF_PSTATE_ID pstate = default;
            var status = getPstate(GetHandle(), &pstate);
            if (status == _NvAPI_Status.NVAPI_OK)
                return pstate;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get detailed P-state information (Pstates20).
        /// </summary>
        /// <returns>P-state details DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuPerfPstates20InfoDto? GetPstates20Info()
        {
            ThrowIfDisposed();

            var getPstates = GetDelegate<NvApiGpuGetPstates20Delegate>(
                NvApiIdGpuGetPstates20,
                "NvAPI_GPU_GetPstates20");
            var info = CreateGpuPerfPstates20Info();
            var status = getPstates(GetHandle(), &info);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGpuPerfPstates20InfoDto.FromNative(info);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get dynamic P-state utilization information.
        /// </summary>
        /// <returns>Dynamic P-state utilization DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuDynamicPstatesInfoExDto? GetDynamicPstatesInfoEx()
        {
            ThrowIfDisposed();

            var getDynamic = GetDelegate<NvApiGpuGetDynamicPstatesInfoExDelegate>(
                NvApiIdGpuGetDynamicPstatesInfoEx,
                "NvAPI_GPU_GetDynamicPstatesInfoEx");
            var info = CreateDynamicPstatesInfoEx();
            var status = getDynamic(GetHandle(), &info);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGpuDynamicPstatesInfoExDto.FromNative(info);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get thermal settings for this GPU.
        /// </summary>
        /// <param name="sensorIndex">Sensor index (0 for all).</param>
        /// <returns>Thermal settings DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuThermalSettingsDto? GetThermalSettings(uint sensorIndex = 0)
        {
            ThrowIfDisposed();

            var getThermal = GetDelegate<NvApiGpuGetThermalSettingsDelegate>(
                NvApiIdGpuGetThermalSettings,
                "NvAPI_GPU_GetThermalSettings");
            var settings = CreateThermalSettings();
            var status = getThermal(GetHandle(), sensorIndex, &settings);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGpuThermalSettingsDto.FromNative(settings);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get all clock frequencies for this GPU.
        /// </summary>
        /// <param name="clockType">Clock type selection.</param>
        /// <returns>Clock frequencies DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuClockFrequenciesDto? GetAllClockFrequencies(NV_GPU_CLOCK_FREQUENCIES_CLOCK_TYPE clockType = NV_GPU_CLOCK_FREQUENCIES_CLOCK_TYPE.NV_GPU_CLOCK_FREQUENCIES_CURRENT_FREQ)
        {
            ThrowIfDisposed();

            var getClocks = GetDelegate<NvApiGpuGetAllClockFrequenciesDelegate>(
                NvApiIdGpuGetAllClockFrequencies,
                "NvAPI_GPU_GetAllClockFrequencies");
            var clocks = CreateClockFrequencies(clockType);
            var status = getClocks(GetHandle(), &clocks);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGpuClockFrequenciesDto.FromNative(clocks);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Query illumination support for an attribute.
        /// </summary>
        /// <param name="attribute">Illumination attribute.</param>
        /// <returns>Illumination support DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuIlluminationSupportDto? QueryIlluminationSupport(_NV_GPU_ILLUMINATION_ATTRIB attribute)
        {
            ThrowIfDisposed();

            var query = GetDelegate<NvApiGpuQueryIlluminationSupportDelegate>(
                NvApiIdGpuQueryIlluminationSupport,
                "NvAPI_GPU_QueryIlluminationSupport");

            var request = CreateIlluminationSupportRequest(attribute);
            var status = query(&request);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGpuIlluminationSupportDto.FromNative(request);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get illumination value for an attribute.
        /// </summary>
        /// <param name="attribute">Illumination attribute.</param>
        /// <returns>Illumination DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuIlluminationDto? GetIllumination(_NV_GPU_ILLUMINATION_ATTRIB attribute)
        {
            ThrowIfDisposed();

            var getIllum = GetDelegate<NvApiGpuGetIlluminationDelegate>(
                NvApiIdGpuGetIllumination,
                "NvAPI_GPU_GetIllumination");

            var request = CreateIlluminationGetRequest(attribute);
            var status = getIllum(&request);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGpuIlluminationDto.FromNative(request);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Set illumination value for an attribute.
        /// </summary>
        /// <param name="illumination">Illumination settings DTO.</param>
        /// <returns>True if applied, false if unavailable or unchanged.</returns>
        public unsafe bool SetIllumination(NVAPIGpuIlluminationDto illumination)
        {
            ThrowIfDisposed();

            var current = GetIllumination(illumination.Attribute);
            if (current == null)
                return false;

            if (current.Value.Equals(illumination))
                return true;

            var setIllum = GetDelegate<NvApiGpuSetIlluminationDelegate>(
                NvApiIdGpuSetIllumination,
                "NvAPI_GPU_SetIllumination");

            var native = illumination.ToNative();
            native.hPhysicalGpu = GetHandle();
            var status = setIllum(&native);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get illumination device info for this GPU.
        /// </summary>
        /// <returns>Illumination device info DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuIllumDeviceInfoParamsDto? GetIlluminationDevicesInfo()
        {
            ThrowIfDisposed();

            var getInfo = GetDelegate<NvApiGpuClientIllumDevicesGetInfoDelegate>(
                NvApiIdGpuClientIllumDevicesGetInfo,
                "NvAPI_GPU_ClientIllumDevicesGetInfo");
            var info = CreateIllumDeviceInfoParams();
            var status = getInfo(GetHandle(), &info);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGpuIllumDeviceInfoParamsDto.FromNative(info);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get illumination device control settings for this GPU.
        /// </summary>
        /// <returns>Illumination device control DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuIllumDeviceControlParamsDto? GetIlluminationDevicesControl()
        {
            ThrowIfDisposed();

            var getControl = GetDelegate<NvApiGpuClientIllumDevicesGetControlDelegate>(
                NvApiIdGpuClientIllumDevicesGetControl,
                "NvAPI_GPU_ClientIllumDevicesGetControl");
            var control = CreateIllumDeviceControlParams();
            var status = getControl(GetHandle(), &control);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGpuIllumDeviceControlParamsDto.FromNative(control);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Set illumination device control settings for this GPU.
        /// </summary>
        /// <param name="control">Control DTO.</param>
        /// <returns>True if applied, false if unavailable or unchanged.</returns>
        public unsafe bool SetIlluminationDevicesControl(NVAPIGpuIllumDeviceControlParamsDto control)
        {
            ThrowIfDisposed();

            var current = GetIlluminationDevicesControl();
            if (current == null)
                return false;

            if (current.Value.Equals(control))
                return true;

            var setControl = GetDelegate<NvApiGpuClientIllumDevicesSetControlDelegate>(
                NvApiIdGpuClientIllumDevicesSetControl,
                "NvAPI_GPU_ClientIllumDevicesSetControl");

            var native = control.ToNative();
            var status = setControl(GetHandle(), &native);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get illumination zone info for this GPU.
        /// </summary>
        /// <returns>Illumination zone info DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuIllumZoneInfoParamsDto? GetIlluminationZonesInfo()
        {
            ThrowIfDisposed();

            var getInfo = GetDelegate<NvApiGpuClientIllumZonesGetInfoDelegate>(
                NvApiIdGpuClientIllumZonesGetInfo,
                "NvAPI_GPU_ClientIllumZonesGetInfo");
            var info = CreateIllumZoneInfoParams();
            var status = getInfo(GetHandle(), &info);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGpuIllumZoneInfoParamsDto.FromNative(info);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get illumination zone control for this GPU.
        /// </summary>
        /// <returns>Illumination zone control DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuIllumZoneControlParamsDto? GetIlluminationZonesControl()
        {
            ThrowIfDisposed();

            var getControl = GetDelegate<NvApiGpuClientIllumZonesGetControlDelegate>(
                NvApiIdGpuClientIllumZonesGetControl,
                "NvAPI_GPU_ClientIllumZonesGetControl");
            var control = CreateIllumZoneControlParams();
            var status = getControl(GetHandle(), &control);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGpuIllumZoneControlParamsDto.FromNative(control);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Set illumination zone control for this GPU.
        /// </summary>
        /// <param name="control">Zone control DTO.</param>
        /// <returns>True if applied, false if unavailable or unchanged.</returns>
        public unsafe bool SetIlluminationZonesControl(NVAPIGpuIllumZoneControlParamsDto control)
        {
            ThrowIfDisposed();

            var current = GetIlluminationZonesControl();
            if (current == null)
                return false;

            if (current.Value.Equals(control))
                return true;

            var setControl = GetDelegate<NvApiGpuClientIllumZonesSetControlDelegate>(
                NvApiIdGpuClientIllumZonesSetControl,
                "NvAPI_GPU_ClientIllumZonesSetControl");

            var native = control.ToNative();
            var status = setControl(GetHandle(), &native);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get virtualization information for this GPU.
        /// </summary>
        /// <returns>Virtualization info DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuVirtualizationInfoDto? GetVirtualizationInfo()
        {
            ThrowIfDisposed();

            var getInfo = GetDelegate<NvApiGpuGetVirtualizationInfoDelegate>(
                NvApiIdGpuGetVirtualizationInfo,
                "NvAPI_GPU_GetVirtualizationInfo");
            var info = CreateVirtualizationInfo();
            var status = getInfo(GetHandle(), &info);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGpuVirtualizationInfoDto.FromNative(info);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get licensable features for this GPU.
        /// </summary>
        /// <returns>Licensable features DTO, or null if unavailable.</returns>
        public unsafe NVAPILicensableFeaturesDto? GetLicensableFeatures()
        {
            ThrowIfDisposed();

            var getFeatures = GetDelegate<NvApiGpuGetLicensableFeaturesDelegate>(
                NvApiIdGpuGetLicensableFeatures,
                "NvAPI_GPU_GetLicensableFeatures");
            var features = CreateLicensableFeatures();
            var status = getFeatures(GetHandle(), &features);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPILicensableFeaturesDto.FromNative(features);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get encoder statistics for this GPU.
        /// </summary>
        /// <returns>Encoder statistics DTO, or null if unavailable.</returns>
        public unsafe NVAPIEncoderStatisticsDto? GetEncoderStatistics()
        {
            ThrowIfDisposed();

            var getStats = GetDelegate<NvApiGpuGetEncoderStatisticsDelegate>(
                NvApiIdGpuGetEncoderStatistics,
                "NvAPI_GPU_GetEncoderStatistics");
            var stats = CreateEncoderStatistics();
            var status = getStats(GetHandle(), &stats);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIEncoderStatisticsDto.FromNative(stats);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get encoder sessions info for this GPU.
        /// </summary>
        /// <returns>Encoder sessions info DTO, or null if unavailable.</returns>
        public unsafe NVAPIEncoderSessionsInfoDto? GetEncoderSessionsInfo()
        {
            ThrowIfDisposed();

            var getInfo = GetDelegate<NvApiGpuGetEncoderSessionsInfoDelegate>(
                NvApiIdGpuGetEncoderSessionsInfo,
                "NvAPI_GPU_GetEncoderSessionsInfo");
            var info = CreateEncoderSessionsInfo();
            var status = getInfo(GetHandle(), &info);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIEncoderSessionsInfoDto.FromNative(info);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get VR Ready data for this GPU.
        /// </summary>
        /// <returns>VR Ready DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuVrReadyDto? GetVrReadyData()
        {
            ThrowIfDisposed();

            var getVr = GetDelegate<NvApiGpuGetVrReadyDataDelegate>(
                NvApiIdGpuGetVrReadyData,
                "NvAPI_GPU_GetVRReadyData");
            var vr = CreateVrReadyData();
            var status = getVr(GetHandle(), &vr);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGpuVrReadyDto.FromNative(vr);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get GSP features for this GPU.
        /// </summary>
        /// <returns>GSP features DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuGspInfoDto? GetGspFeatures()
        {
            ThrowIfDisposed();

            var getGsp = GetDelegate<NvApiGpuGetGspFeaturesDelegate>(
                NvApiIdGpuGetGspFeatures,
                "NvAPI_GPU_GetGspFeatures");
            var gsp = CreateGspInfo();
            var status = getGsp(GetHandle(), &gsp);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGpuGspInfoDto.FromNative(gsp);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get NVLINK capabilities for this GPU.
        /// </summary>
        /// <returns>NVLINK caps DTO, or null if unavailable.</returns>
        public unsafe NVAPINvLinkCapsDto? GetNvlinkCaps()
        {
            ThrowIfDisposed();

            var getCaps = GetDelegate<NvApiGpuNvlinkGetCapsDelegate>(
                NvApiIdGpuNvlinkGetCaps,
                "NvAPI_GPU_NVLINK_GetCaps");
            var caps = CreateNvlinkCaps();
            var status = getCaps(GetHandle(), &caps);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPINvLinkCapsDto.FromNative(caps);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get NVLINK status for this GPU.
        /// </summary>
        /// <returns>NVLINK status DTO, or null if unavailable.</returns>
        public unsafe NVAPINvLinkStatusDto? GetNvlinkStatus()
        {
            ThrowIfDisposed();

            var getStatus = GetDelegate<NvApiGpuNvlinkGetStatusDelegate>(
                NvApiIdGpuNvlinkGetStatus,
                "NvAPI_GPU_NVLINK_GetStatus");
            var statusInfo = CreateNvlinkStatus();
            var status = getStatus(GetHandle(), &statusInfo);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPINvLinkStatusDto.FromNative(statusInfo);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get GPU info for this GPU.
        /// </summary>
        /// <returns>GPU info DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuInfoDto? GetGpuInfo()
        {
            ThrowIfDisposed();

            var getInfo = GetDelegate<NvApiGpuGetGpuInfoDelegate>(
                NvApiIdGpuGetGpuInfo,
                "NvAPI_GPU_GetGPUInfo");
            var info = CreateGpuInfo();
            var status = getInfo(GetHandle(), &info);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGpuInfoDto.FromNative(info);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Read data via I2C from a DDC port.
        /// </summary>
        /// <param name="request">I2C request DTO (data buffer length defines read size).</param>
        /// <returns>Result DTO with read data, or null if unsupported.</returns>
        public unsafe NVAPII2CInfoDto? I2CRead(NVAPII2CInfoDto request)
        {
            ThrowIfDisposed();

            var read = GetDelegate<NvApiI2CReadDelegate>(NvApiIdI2CRead, "NvAPI_I2CRead");
            var regAddress = request.RegisterAddress ?? Array.Empty<byte>();
            var data = request.Data ?? Array.Empty<byte>();
            var native = request.ToNative();

            native.regAddrSize = (uint)regAddress.Length;
            native.cbSize = (uint)data.Length;

            fixed (byte* pReg = regAddress)
            fixed (byte* pData = data)
            {
                native.pbI2cRegAddress = regAddress.Length > 0 ? pReg : null;
                native.pbData = data.Length > 0 ? pData : null;

                var status = read(GetHandle(), &native);
                if (status == _NvAPI_Status.NVAPI_OK)
                {
                    var regOut = regAddress.Length > 0 ? (byte[])regAddress.Clone() : Array.Empty<byte>();
                    var dataOut = data.Length > 0 ? (byte[])data.Clone() : Array.Empty<byte>();
                    return new NVAPII2CInfoDto(
                        native.displayMask,
                        native.bIsDDCPort != 0,
                        native.i2cDevAddress,
                        regOut,
                        dataOut,
                        native.i2cSpeed,
                        native.i2cSpeedKhz,
                        native.portId,
                        native.bIsPortIdSet != 0);
                }

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED ||
                    status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION ||
                    status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                {
                    return null;
                }

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Write data via I2C to a DDC port.
        /// </summary>
        /// <param name="request">I2C request DTO containing data to write.</param>
        /// <returns>True if written, or null if unsupported.</returns>
        public unsafe bool? I2CWrite(NVAPII2CInfoDto request)
        {
            ThrowIfDisposed();

            var write = GetDelegate<NvApiI2CWriteDelegate>(NvApiIdI2CWrite, "NvAPI_I2CWrite");
            var regAddress = request.RegisterAddress ?? Array.Empty<byte>();
            var data = request.Data ?? Array.Empty<byte>();
            var native = request.ToNative();

            native.regAddrSize = (uint)regAddress.Length;
            native.cbSize = (uint)data.Length;

            fixed (byte* pReg = regAddress)
            fixed (byte* pData = data)
            {
                native.pbI2cRegAddress = regAddress.Length > 0 ? pReg : null;
                native.pbData = data.Length > 0 ? pData : null;

                var status = write(GetHandle(), &native);
                if (status == _NvAPI_Status.NVAPI_OK)
                    return true;

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED ||
                    status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION ||
                    status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                {
                    return null;
                }

                throw new NVAPIException(status);
            }
        }

        private unsafe NVAPIGpuDisplayIdDto[] GetConnectedDisplayIdsWithCapacity(uint flags, uint capacity)
        {
            var getDisplayIds = GetDelegate<NvApiGpuGetConnectedDisplayIdsDelegate>(
                NvApiIdGpuGetConnectedDisplayIds,
                "NvAPI_GPU_GetConnectedDisplayIds");

            var native = CreateDisplayIdArray((int)capacity);
            uint count = capacity;

            fixed (_NV_GPU_DISPLAYIDS* pNative = native)
            {
                var status = getDisplayIds(GetHandle(), pNative, &count, flags);
                if (status == _NvAPI_Status.NVAPI_OK)
                    return NVAPIGpuDisplayIdDto.FromNative(native, count);

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return Array.Empty<NVAPIGpuDisplayIdDto>();

                throw new NVAPIException(status);
            }
        }

        private unsafe NVAPIGpuDisplayIdDto[] GetAllDisplayIdsWithCapacity(uint capacity)
        {
            var getDisplayIds = GetDelegate<NvApiGpuGetAllDisplayIdsDelegate>(
                NvApiIdGpuGetAllDisplayIds,
                "NvAPI_GPU_GetAllDisplayIds");

            var native = CreateDisplayIdArray((int)capacity);
            uint count = capacity;

            fixed (_NV_GPU_DISPLAYIDS* pNative = native)
            {
                var status = getDisplayIds(GetHandle(), pNative, &count);
                if (status == _NvAPI_Status.NVAPI_OK)
                    return NVAPIGpuDisplayIdDto.FromNative(native, count);

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return Array.Empty<NVAPIGpuDisplayIdDto>();

                throw new NVAPIException(status);
            }
        }

        private static NV_DISPLAY_DRIVER_MEMORY_INFO_V3 CreateDisplayDriverMemoryInfo()
        {
            return new NV_DISPLAY_DRIVER_MEMORY_INFO_V3 { version = NVAPI.NV_DISPLAY_DRIVER_MEMORY_INFO_VER };
        }

        private static NV_GPU_MEMORY_INFO_EX_V1 CreateGpuMemoryInfoEx()
        {
            return new NV_GPU_MEMORY_INFO_EX_V1 { version = NVAPI.NV_GPU_MEMORY_INFO_EX_VER };
        }

        private static _NV_GPU_DISPLAYIDS[] CreateDisplayIdArray(int count)
        {
            var items = new _NV_GPU_DISPLAYIDS[count];
            for (var i = 0; i < items.Length; i++)
                items[i].version = NVAPI.NV_GPU_DISPLAYIDS_VER;
            return items;
        }

        private static _NV_GPU_PERF_PSTATES20_INFO_V2 CreateGpuPerfPstates20Info()
        {
            return new _NV_GPU_PERF_PSTATES20_INFO_V2 { version = NVAPI.NV_GPU_PERF_PSTATES20_INFO_VER };
        }

        private static NV_GPU_DYNAMIC_PSTATES_INFO_EX CreateDynamicPstatesInfoEx()
        {
            return new NV_GPU_DYNAMIC_PSTATES_INFO_EX { version = NVAPI.NV_GPU_DYNAMIC_PSTATES_INFO_EX_VER };
        }

        private static NV_GPU_THERMAL_SETTINGS_V2 CreateThermalSettings()
        {
            return new NV_GPU_THERMAL_SETTINGS_V2 { version = NVAPI.NV_GPU_THERMAL_SETTINGS_VER };
        }

        private static NV_GPU_CLOCK_FREQUENCIES_V2 CreateClockFrequencies(NV_GPU_CLOCK_FREQUENCIES_CLOCK_TYPE clockType)
        {
            var clocks = new NV_GPU_CLOCK_FREQUENCIES_V2 { version = NVAPI.NV_GPU_CLOCK_FREQUENCIES_VER };
            clocks.ClockType = (uint)clockType;
            return clocks;
        }

        private unsafe _NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_V1 CreateIlluminationSupportRequest(_NV_GPU_ILLUMINATION_ATTRIB attribute)
        {
            return new _NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_V1
            {
                version = NVAPI.NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_VER,
                hPhysicalGpu = GetHandle(),
                Attribute = attribute,
                bSupported = 0
            };
        }

        private unsafe _NV_GPU_GET_ILLUMINATION_PARM_V1 CreateIlluminationGetRequest(_NV_GPU_ILLUMINATION_ATTRIB attribute)
        {
            return new _NV_GPU_GET_ILLUMINATION_PARM_V1
            {
                version = NVAPI.NV_GPU_GET_ILLUMINATION_PARM_VER,
                hPhysicalGpu = GetHandle(),
                Attribute = attribute,
                Value = 0
            };
        }

        private static _NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_V1 CreateIllumDeviceInfoParams()
        {
            return new _NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_V1 { version = NVAPI.NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_VER };
        }

        private static NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_V1 CreateIllumDeviceControlParams()
        {
            return new NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_V1 { version = NVAPI.NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_VER };
        }

        private static _NV_GPU_CLIENT_ILLUM_ZONE_INFO_PARAMS_V1 CreateIllumZoneInfoParams()
        {
            return new _NV_GPU_CLIENT_ILLUM_ZONE_INFO_PARAMS_V1 { version = NVAPI.NV_GPU_CLIENT_ILLUM_ZONE_INFO_PARAMS_VER };
        }

        private static _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1 CreateIllumZoneControlParams()
        {
            return new _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1 { version = NVAPI.NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_VER };
        }

        private static _NV_GPU_VIRTUALIZATION_INFO CreateVirtualizationInfo()
        {
            return new _NV_GPU_VIRTUALIZATION_INFO { version = NVAPI.NV_GPU_VIRTUALIZATION_INFO_VER };
        }

        private static _NV_LICENSABLE_FEATURES_V4 CreateLicensableFeatures()
        {
            return new _NV_LICENSABLE_FEATURES_V4 { version = NVAPI.NV_LICENSABLE_FEATURES_VER };
        }

        private static _NV_ENCODER_STATISTICS_V1 CreateEncoderStatistics()
        {
            return new _NV_ENCODER_STATISTICS_V1 { version = NVAPI.NNV_ENCODER_STATISTICS_VER };
        }

        private static _NV_ENCODER_SESSIONS_INFO_V1 CreateEncoderSessionsInfo()
        {
            return new _NV_ENCODER_SESSIONS_INFO_V1 { version = NVAPI.NV_ENCODER_SESSIONS_INFO_VER };
        }

        private static _NV_GPU_VR_READY_V1 CreateVrReadyData()
        {
            return new _NV_GPU_VR_READY_V1 { version = NVAPI.NV_GPU_VR_READY_VER };
        }

        private static _NV_GPU_GSP_INFO_V1 CreateGspInfo()
        {
            return new _NV_GPU_GSP_INFO_V1 { version = NVAPI.NV_GPU_GSP_INFO_VER };
        }

        private static NVLINK_GET_CAPS_V1 CreateNvlinkCaps()
        {
            return new NVLINK_GET_CAPS_V1 { version = NVAPI.NVLINK_GET_CAPS_VER };
        }

        private static NVLINK_GET_STATUS_V2 CreateNvlinkStatus()
        {
            return new NVLINK_GET_STATUS_V2 { version = NVAPI.NVLINK_GET_STATUS_VER };
        }

        private static _NV_GPU_INFO_V2 CreateGpuInfo()
        {
            return new _NV_GPU_INFO_V2 { version = NVAPI.NV_GPU_INFO_VER };
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
        private unsafe delegate _NvAPI_Status NvApiGpuGetPciIdentifiersDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, uint* pDeviceId, uint* pSubSystemId, uint* pRevisionId, uint* pExtDeviceId);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetBusSlotIdDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, uint* pBusSlotId);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetVbiosVersionStringDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, sbyte* szBiosRevision);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetPhysicalFrameBufferSizeDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, uint* pSize);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetVirtualFrameBufferSizeDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, uint* pSize);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetTachReadingDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, uint* pValue);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetMemoryInfoDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, NV_DISPLAY_DRIVER_MEMORY_INFO_V3* pMemoryInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetMemoryInfoExDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, NV_GPU_MEMORY_INFO_EX_V1* pMemoryInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiSysGetDisplayIdFromGpuAndOutputIdDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, uint outputId, uint* displayId);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiEnumNvidiaDisplayHandleDelegate(uint thisEnum, NvDisplayHandle__** pNvDispHandle);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGetPhysicalGpusFromDisplayDelegate(NvDisplayHandle__* hNvDisp, NvPhysicalGpuHandle__** nvGPUHandle, uint* pGpuCount);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetShaderSubPipeCountDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, uint* pCount);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetGpuCoreCountDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, uint* pCount);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetSystemTypeDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, NV_SYSTEM_TYPE* pSystemType);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetActiveOutputsDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, uint* pOutputsMask);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetConnectedDisplayIdsDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, _NV_GPU_DISPLAYIDS* pDisplayIds, uint* pDisplayIdCount, uint flags);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetAllDisplayIdsDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, _NV_GPU_DISPLAYIDS* pDisplayIds, uint* pDisplayIdCount);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetPerfDecreaseInfoDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, uint* pPerfDecreaseInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetPstates20Delegate(NvPhysicalGpuHandle__* hPhysicalGpu, _NV_GPU_PERF_PSTATES20_INFO_V2* pPstatesInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetCurrentPstateDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, _NV_GPU_PERF_PSTATE_ID* pCurrentPstate);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetDynamicPstatesInfoExDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, NV_GPU_DYNAMIC_PSTATES_INFO_EX* pDynamicPstatesInfoEx);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetThermalSettingsDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, uint sensorIndex, NV_GPU_THERMAL_SETTINGS_V2* pThermalSettings);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetAllClockFrequenciesDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, NV_GPU_CLOCK_FREQUENCIES_V2* pClkFreqs);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuQueryIlluminationSupportDelegate(_NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_V1* pIlluminationSupportInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetIlluminationDelegate(_NV_GPU_GET_ILLUMINATION_PARM_V1* pIlluminationInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuSetIlluminationDelegate(_NV_GPU_SET_ILLUMINATION_PARM_V1* pIlluminationInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuClientIllumDevicesGetInfoDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, _NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_V1* pIllumDevicesInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuClientIllumDevicesGetControlDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_V1* pClientIllumDevicesControl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuClientIllumDevicesSetControlDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_V1* pClientIllumDevicesControl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuClientIllumZonesGetInfoDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, _NV_GPU_CLIENT_ILLUM_ZONE_INFO_PARAMS_V1* pIllumZonesInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuClientIllumZonesGetControlDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1* pIllumZonesControl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuClientIllumZonesSetControlDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1* pIllumZonesControl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetVirtualizationInfoDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, _NV_GPU_VIRTUALIZATION_INFO* pVirtualizationInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetLicensableFeaturesDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, _NV_LICENSABLE_FEATURES_V4* pLicensableFeatures);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetEncoderStatisticsDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, _NV_ENCODER_STATISTICS_V1* pEncoderStatistics);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetEncoderSessionsInfoDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, _NV_ENCODER_SESSIONS_INFO_V1* pEncoderSessionsInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetVrReadyDataDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, _NV_GPU_VR_READY_V1* pGpuVrReadyData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetGspFeaturesDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, _NV_GPU_GSP_INFO_V1* pGspInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuNvlinkGetCapsDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, NVLINK_GET_CAPS_V1* pCaps);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuNvlinkGetStatusDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, NVLINK_GET_STATUS_V2* pStatus);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetGpuInfoDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, _NV_GPU_INFO_V2* pGpuInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiI2CReadDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, NV_I2C_INFO_V3* pI2cInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiI2CWriteDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, NV_I2C_INFO_V3* pI2cInfo);
    }

    /// <summary>
    /// PCI identifiers reported by NVAPI.
    /// </summary>
    public readonly struct NVAPIPciIdentifiers : IEquatable<NVAPIPciIdentifiers>
    {
        /// <summary>PCI device ID.</summary>
        public uint DeviceId { get; }

        /// <summary>PCI subsystem ID.</summary>
        public uint SubSystemId { get; }

        /// <summary>PCI revision ID.</summary>
        public uint RevisionId { get; }

        /// <summary>PCI extended device ID.</summary>
        public uint ExtDeviceId { get; }

        /// <summary>Create a PCI identifier set.</summary>
        public NVAPIPciIdentifiers(uint deviceId, uint subSystemId, uint revisionId, uint extDeviceId)
        {
            DeviceId = deviceId;
            SubSystemId = subSystemId;
            RevisionId = revisionId;
            ExtDeviceId = extDeviceId;
        }

        /// <summary>Create a DTO from native PCI identifier values.</summary>
        public static NVAPIPciIdentifiers FromNative(uint deviceId, uint subSystemId, uint revisionId, uint extDeviceId)
        {
            return new NVAPIPciIdentifiers(deviceId, subSystemId, revisionId, extDeviceId);
        }

        public bool Equals(NVAPIPciIdentifiers other)
        {
            return DeviceId == other.DeviceId
                && SubSystemId == other.SubSystemId
                && RevisionId == other.RevisionId
                && ExtDeviceId == other.ExtDeviceId;
        }

        public override bool Equals(object? obj)
        {
            return obj is NVAPIPciIdentifiers other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = DeviceId.GetHashCode();
                hash = (hash * 31) + SubSystemId.GetHashCode();
                hash = (hash * 31) + RevisionId.GetHashCode();
                hash = (hash * 31) + ExtDeviceId.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIPciIdentifiers left, NVAPIPciIdentifiers right) => left.Equals(right);
        public static bool operator !=(NVAPIPciIdentifiers left, NVAPIPciIdentifiers right) => !left.Equals(right);
    }

    /// <summary>
    /// I2C request/response DTO for NVAPI I2C operations.
    /// </summary>
    public readonly struct NVAPII2CInfoDto : IEquatable<NVAPII2CInfoDto>
    {
        public uint DisplayMask { get; }
        public bool IsDDCPort { get; }
        public byte I2cDevAddress { get; }
        public byte[] RegisterAddress { get; }
        public byte[] Data { get; }
        public uint I2cSpeed { get; }
        public NV_I2C_SPEED I2cSpeedKhz { get; }
        public byte PortId { get; }
        public bool IsPortIdSet { get; }

        public NVAPII2CInfoDto(
            uint displayMask,
            bool isDDCPort,
            byte i2cDevAddress,
            byte[] registerAddress,
            byte[] data,
            uint i2cSpeed,
            NV_I2C_SPEED i2cSpeedKhz,
            byte portId,
            bool isPortIdSet)
        {
            DisplayMask = displayMask;
            IsDDCPort = isDDCPort;
            I2cDevAddress = i2cDevAddress;
            RegisterAddress = registerAddress ?? Array.Empty<byte>();
            Data = data ?? Array.Empty<byte>();
            I2cSpeed = i2cSpeed;
            I2cSpeedKhz = i2cSpeedKhz;
            PortId = portId;
            IsPortIdSet = isPortIdSet;
        }

        /// <summary>
        /// Create a DTO from a native struct. Note: pointer-backed buffers are not copied.
        /// </summary>
        public static NVAPII2CInfoDto FromNative(NV_I2C_INFO_V3 native)
        {
            return new NVAPII2CInfoDto(
                native.displayMask,
                native.bIsDDCPort != 0,
                native.i2cDevAddress,
                Array.Empty<byte>(),
                Array.Empty<byte>(),
                native.i2cSpeed,
                native.i2cSpeedKhz,
                native.portId,
                native.bIsPortIdSet != 0);
        }

        public NV_I2C_INFO_V3 ToNative()
        {
            return new NV_I2C_INFO_V3
            {
                version = NVAPI.NV_I2C_INFO_VER,
                displayMask = DisplayMask,
                bIsDDCPort = IsDDCPort ? (byte)1 : (byte)0,
                i2cDevAddress = I2cDevAddress,
                pbI2cRegAddress = null,
                regAddrSize = (uint)(RegisterAddress?.Length ?? 0),
                pbData = null,
                cbSize = (uint)(Data?.Length ?? 0),
                i2cSpeed = I2cSpeed == 0 ? (uint)NVAPI.NVAPI_I2C_SPEED_DEPRECATED : I2cSpeed,
                i2cSpeedKhz = I2cSpeedKhz,
                portId = PortId,
                bIsPortIdSet = IsPortIdSet ? 1u : 0u
            };
        }

        public bool Equals(NVAPII2CInfoDto other)
        {
            return DisplayMask == other.DisplayMask
                && IsDDCPort == other.IsDDCPort
                && I2cDevAddress == other.I2cDevAddress
                && I2cSpeed == other.I2cSpeed
                && I2cSpeedKhz == other.I2cSpeedKhz
                && PortId == other.PortId
                && IsPortIdSet == other.IsPortIdSet
                && DtoHelpers.SequenceEquals(RegisterAddress, other.RegisterAddress)
                && DtoHelpers.SequenceEquals(Data, other.Data);
        }

        public override bool Equals(object? obj) => obj is NVAPII2CInfoDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = DisplayMask.GetHashCode();
                hash = (hash * 31) + IsDDCPort.GetHashCode();
                hash = (hash * 31) + I2cDevAddress.GetHashCode();
                hash = (hash * 31) + I2cSpeed.GetHashCode();
                hash = (hash * 31) + I2cSpeedKhz.GetHashCode();
                hash = (hash * 31) + PortId.GetHashCode();
                hash = (hash * 31) + IsPortIdSet.GetHashCode();
                hash = (hash * 31) + DtoHelpers.SequenceHashCode(RegisterAddress ?? Array.Empty<byte>());
                hash = (hash * 31) + DtoHelpers.SequenceHashCode(Data ?? Array.Empty<byte>());
                return hash;
            }
        }

        public static bool operator ==(NVAPII2CInfoDto left, NVAPII2CInfoDto right) => left.Equals(right);
        public static bool operator !=(NVAPII2CInfoDto left, NVAPII2CInfoDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Legacy display driver memory info DTO.
    /// </summary>
    public readonly struct NVAPIDisplayDriverMemoryInfoDto : IEquatable<NVAPIDisplayDriverMemoryInfoDto>
    {
        public uint DedicatedVideoMemoryKb { get; }
        public uint AvailableDedicatedVideoMemoryKb { get; }
        public uint SystemVideoMemoryKb { get; }
        public uint SharedSystemMemoryKb { get; }
        public uint CurrentAvailableDedicatedVideoMemoryKb { get; }
        public uint DedicatedVideoMemoryEvictionsSizeKb { get; }
        public uint DedicatedVideoMemoryEvictionCount { get; }

        public NVAPIDisplayDriverMemoryInfoDto(
            uint dedicatedVideoMemoryKb,
            uint availableDedicatedVideoMemoryKb,
            uint systemVideoMemoryKb,
            uint sharedSystemMemoryKb,
            uint currentAvailableDedicatedVideoMemoryKb,
            uint dedicatedVideoMemoryEvictionsSizeKb,
            uint dedicatedVideoMemoryEvictionCount)
        {
            DedicatedVideoMemoryKb = dedicatedVideoMemoryKb;
            AvailableDedicatedVideoMemoryKb = availableDedicatedVideoMemoryKb;
            SystemVideoMemoryKb = systemVideoMemoryKb;
            SharedSystemMemoryKb = sharedSystemMemoryKb;
            CurrentAvailableDedicatedVideoMemoryKb = currentAvailableDedicatedVideoMemoryKb;
            DedicatedVideoMemoryEvictionsSizeKb = dedicatedVideoMemoryEvictionsSizeKb;
            DedicatedVideoMemoryEvictionCount = dedicatedVideoMemoryEvictionCount;
        }

        public static NVAPIDisplayDriverMemoryInfoDto FromNative(NV_DISPLAY_DRIVER_MEMORY_INFO_V3 native)
        {
            return new NVAPIDisplayDriverMemoryInfoDto(
                native.dedicatedVideoMemory,
                native.availableDedicatedVideoMemory,
                native.systemVideoMemory,
                native.sharedSystemMemory,
                native.curAvailableDedicatedVideoMemory,
                native.dedicatedVideoMemoryEvictionsSize,
                native.dedicatedVideoMemoryEvictionCount);
        }

        public NV_DISPLAY_DRIVER_MEMORY_INFO_V3 ToNative()
        {
            return new NV_DISPLAY_DRIVER_MEMORY_INFO_V3
            {
                version = NVAPI.NV_DISPLAY_DRIVER_MEMORY_INFO_VER,
                dedicatedVideoMemory = DedicatedVideoMemoryKb,
                availableDedicatedVideoMemory = AvailableDedicatedVideoMemoryKb,
                systemVideoMemory = SystemVideoMemoryKb,
                sharedSystemMemory = SharedSystemMemoryKb,
                curAvailableDedicatedVideoMemory = CurrentAvailableDedicatedVideoMemoryKb,
                dedicatedVideoMemoryEvictionsSize = DedicatedVideoMemoryEvictionsSizeKb,
                dedicatedVideoMemoryEvictionCount = DedicatedVideoMemoryEvictionCount
            };
        }

        public bool Equals(NVAPIDisplayDriverMemoryInfoDto other)
        {
            return DedicatedVideoMemoryKb == other.DedicatedVideoMemoryKb
                && AvailableDedicatedVideoMemoryKb == other.AvailableDedicatedVideoMemoryKb
                && SystemVideoMemoryKb == other.SystemVideoMemoryKb
                && SharedSystemMemoryKb == other.SharedSystemMemoryKb
                && CurrentAvailableDedicatedVideoMemoryKb == other.CurrentAvailableDedicatedVideoMemoryKb
                && DedicatedVideoMemoryEvictionsSizeKb == other.DedicatedVideoMemoryEvictionsSizeKb
                && DedicatedVideoMemoryEvictionCount == other.DedicatedVideoMemoryEvictionCount;
        }

        public override bool Equals(object? obj) => obj is NVAPIDisplayDriverMemoryInfoDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = DedicatedVideoMemoryKb.GetHashCode();
                hash = (hash * 31) + AvailableDedicatedVideoMemoryKb.GetHashCode();
                hash = (hash * 31) + SystemVideoMemoryKb.GetHashCode();
                hash = (hash * 31) + SharedSystemMemoryKb.GetHashCode();
                hash = (hash * 31) + CurrentAvailableDedicatedVideoMemoryKb.GetHashCode();
                hash = (hash * 31) + DedicatedVideoMemoryEvictionsSizeKb.GetHashCode();
                hash = (hash * 31) + DedicatedVideoMemoryEvictionCount.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIDisplayDriverMemoryInfoDto left, NVAPIDisplayDriverMemoryInfoDto right) => left.Equals(right);
        public static bool operator !=(NVAPIDisplayDriverMemoryInfoDto left, NVAPIDisplayDriverMemoryInfoDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Extended GPU memory info DTO.
    /// </summary>
    public readonly struct NVAPIGpuMemoryInfoExDto : IEquatable<NVAPIGpuMemoryInfoExDto>
    {
        public ulong DedicatedVideoMemoryBytes { get; }
        public ulong AvailableDedicatedVideoMemoryBytes { get; }
        public ulong SystemVideoMemoryBytes { get; }
        public ulong SharedSystemMemoryBytes { get; }
        public ulong CurrentAvailableDedicatedVideoMemoryBytes { get; }
        public ulong DedicatedVideoMemoryEvictionsSizeBytes { get; }
        public ulong DedicatedVideoMemoryEvictionCount { get; }
        public ulong DedicatedVideoMemoryPromotionsSizeBytes { get; }
        public ulong DedicatedVideoMemoryPromotionCount { get; }

        public NVAPIGpuMemoryInfoExDto(
            ulong dedicatedVideoMemoryBytes,
            ulong availableDedicatedVideoMemoryBytes,
            ulong systemVideoMemoryBytes,
            ulong sharedSystemMemoryBytes,
            ulong currentAvailableDedicatedVideoMemoryBytes,
            ulong dedicatedVideoMemoryEvictionsSizeBytes,
            ulong dedicatedVideoMemoryEvictionCount,
            ulong dedicatedVideoMemoryPromotionsSizeBytes,
            ulong dedicatedVideoMemoryPromotionCount)
        {
            DedicatedVideoMemoryBytes = dedicatedVideoMemoryBytes;
            AvailableDedicatedVideoMemoryBytes = availableDedicatedVideoMemoryBytes;
            SystemVideoMemoryBytes = systemVideoMemoryBytes;
            SharedSystemMemoryBytes = sharedSystemMemoryBytes;
            CurrentAvailableDedicatedVideoMemoryBytes = currentAvailableDedicatedVideoMemoryBytes;
            DedicatedVideoMemoryEvictionsSizeBytes = dedicatedVideoMemoryEvictionsSizeBytes;
            DedicatedVideoMemoryEvictionCount = dedicatedVideoMemoryEvictionCount;
            DedicatedVideoMemoryPromotionsSizeBytes = dedicatedVideoMemoryPromotionsSizeBytes;
            DedicatedVideoMemoryPromotionCount = dedicatedVideoMemoryPromotionCount;
        }

        public static NVAPIGpuMemoryInfoExDto FromNative(NV_GPU_MEMORY_INFO_EX_V1 native)
        {
            return new NVAPIGpuMemoryInfoExDto(
                native.dedicatedVideoMemory,
                native.availableDedicatedVideoMemory,
                native.systemVideoMemory,
                native.sharedSystemMemory,
                native.curAvailableDedicatedVideoMemory,
                native.dedicatedVideoMemoryEvictionsSize,
                native.dedicatedVideoMemoryEvictionCount,
                native.dedicatedVideoMemoryPromotionsSize,
                native.dedicatedVideoMemoryPromotionCount);
        }

        public NV_GPU_MEMORY_INFO_EX_V1 ToNative()
        {
            return new NV_GPU_MEMORY_INFO_EX_V1
            {
                version = NVAPI.NV_GPU_MEMORY_INFO_EX_VER,
                dedicatedVideoMemory = DedicatedVideoMemoryBytes,
                availableDedicatedVideoMemory = AvailableDedicatedVideoMemoryBytes,
                systemVideoMemory = SystemVideoMemoryBytes,
                sharedSystemMemory = SharedSystemMemoryBytes,
                curAvailableDedicatedVideoMemory = CurrentAvailableDedicatedVideoMemoryBytes,
                dedicatedVideoMemoryEvictionsSize = DedicatedVideoMemoryEvictionsSizeBytes,
                dedicatedVideoMemoryEvictionCount = DedicatedVideoMemoryEvictionCount,
                dedicatedVideoMemoryPromotionsSize = DedicatedVideoMemoryPromotionsSizeBytes,
                dedicatedVideoMemoryPromotionCount = DedicatedVideoMemoryPromotionCount
            };
        }

        public bool Equals(NVAPIGpuMemoryInfoExDto other)
        {
            return DedicatedVideoMemoryBytes == other.DedicatedVideoMemoryBytes
                && AvailableDedicatedVideoMemoryBytes == other.AvailableDedicatedVideoMemoryBytes
                && SystemVideoMemoryBytes == other.SystemVideoMemoryBytes
                && SharedSystemMemoryBytes == other.SharedSystemMemoryBytes
                && CurrentAvailableDedicatedVideoMemoryBytes == other.CurrentAvailableDedicatedVideoMemoryBytes
                && DedicatedVideoMemoryEvictionsSizeBytes == other.DedicatedVideoMemoryEvictionsSizeBytes
                && DedicatedVideoMemoryEvictionCount == other.DedicatedVideoMemoryEvictionCount
                && DedicatedVideoMemoryPromotionsSizeBytes == other.DedicatedVideoMemoryPromotionsSizeBytes
                && DedicatedVideoMemoryPromotionCount == other.DedicatedVideoMemoryPromotionCount;
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuMemoryInfoExDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = DedicatedVideoMemoryBytes.GetHashCode();
                hash = (hash * 31) + AvailableDedicatedVideoMemoryBytes.GetHashCode();
                hash = (hash * 31) + SystemVideoMemoryBytes.GetHashCode();
                hash = (hash * 31) + SharedSystemMemoryBytes.GetHashCode();
                hash = (hash * 31) + CurrentAvailableDedicatedVideoMemoryBytes.GetHashCode();
                hash = (hash * 31) + DedicatedVideoMemoryEvictionsSizeBytes.GetHashCode();
                hash = (hash * 31) + DedicatedVideoMemoryEvictionCount.GetHashCode();
                hash = (hash * 31) + DedicatedVideoMemoryPromotionsSizeBytes.GetHashCode();
                hash = (hash * 31) + DedicatedVideoMemoryPromotionCount.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIGpuMemoryInfoExDto left, NVAPIGpuMemoryInfoExDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuMemoryInfoExDto left, NVAPIGpuMemoryInfoExDto right) => !left.Equals(right);
    }

    /// <summary>
    /// GPU display ID DTO.
    /// </summary>
    public readonly struct NVAPIGpuDisplayIdDto : IEquatable<NVAPIGpuDisplayIdDto>
    {
        public NV_MONITOR_CONN_TYPE ConnectorType { get; }
        public uint DisplayId { get; }
        public bool IsDynamic { get; }
        public bool IsMultiStreamRootNode { get; }
        public bool IsActive { get; }
        public bool IsCluster { get; }
        public bool IsOSVisible { get; }
        public bool IsWfd { get; }
        public bool IsConnected { get; }

        public NVAPIGpuDisplayIdDto(
            NV_MONITOR_CONN_TYPE connectorType,
            uint displayId,
            bool isDynamic,
            bool isMultiStreamRootNode,
            bool isActive,
            bool isCluster,
            bool isOsVisible,
            bool isWfd,
            bool isConnected)
        {
            ConnectorType = connectorType;
            DisplayId = displayId;
            IsDynamic = isDynamic;
            IsMultiStreamRootNode = isMultiStreamRootNode;
            IsActive = isActive;
            IsCluster = isCluster;
            IsOSVisible = isOsVisible;
            IsWfd = isWfd;
            IsConnected = isConnected;
        }

        public static NVAPIGpuDisplayIdDto FromNative(_NV_GPU_DISPLAYIDS native)
        {
            return new NVAPIGpuDisplayIdDto(
                native.connectorType,
                native.displayId,
                native.isDynamic != 0,
                native.isMultiStreamRootNode != 0,
                native.isActive != 0,
                native.isCluster != 0,
                native.isOSVisible != 0,
                native.isWFD != 0,
                native.isConnected != 0);
        }

        public static NVAPIGpuDisplayIdDto[] FromNative(_NV_GPU_DISPLAYIDS[] native, uint count)
        {
            if (native.Length == 0 || count == 0)
                return Array.Empty<NVAPIGpuDisplayIdDto>();

            var max = (int)Math.Min(count, native.Length);
            var result = new NVAPIGpuDisplayIdDto[max];
            for (var i = 0; i < max; i++)
                result[i] = FromNative(native[i]);
            return result;
        }

        public _NV_GPU_DISPLAYIDS ToNative()
        {
            return new _NV_GPU_DISPLAYIDS
            {
                version = NVAPI.NV_GPU_DISPLAYIDS_VER,
                connectorType = ConnectorType,
                displayId = DisplayId,
                isDynamic = IsDynamic ? 1u : 0u,
                isMultiStreamRootNode = IsMultiStreamRootNode ? 1u : 0u,
                isActive = IsActive ? 1u : 0u,
                isCluster = IsCluster ? 1u : 0u,
                isOSVisible = IsOSVisible ? 1u : 0u,
                isWFD = IsWfd ? 1u : 0u,
                isConnected = IsConnected ? 1u : 0u
            };
        }

        public bool Equals(NVAPIGpuDisplayIdDto other)
        {
            return ConnectorType == other.ConnectorType
                && DisplayId == other.DisplayId
                && IsDynamic == other.IsDynamic
                && IsMultiStreamRootNode == other.IsMultiStreamRootNode
                && IsActive == other.IsActive
                && IsCluster == other.IsCluster
                && IsOSVisible == other.IsOSVisible
                && IsWfd == other.IsWfd
                && IsConnected == other.IsConnected;
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuDisplayIdDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = ConnectorType.GetHashCode();
                hash = (hash * 31) + DisplayId.GetHashCode();
                hash = (hash * 31) + IsDynamic.GetHashCode();
                hash = (hash * 31) + IsMultiStreamRootNode.GetHashCode();
                hash = (hash * 31) + IsActive.GetHashCode();
                hash = (hash * 31) + IsCluster.GetHashCode();
                hash = (hash * 31) + IsOSVisible.GetHashCode();
                hash = (hash * 31) + IsWfd.GetHashCode();
                hash = (hash * 31) + IsConnected.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIGpuDisplayIdDto left, NVAPIGpuDisplayIdDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuDisplayIdDto left, NVAPIGpuDisplayIdDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Dynamic P-state utilization entry DTO.
    /// </summary>
    public readonly struct NVAPIGpuDynamicPstateUtilizationDto : IEquatable<NVAPIGpuDynamicPstateUtilizationDto>
    {
        public bool IsPresent { get; }
        public uint Percentage { get; }

        public NVAPIGpuDynamicPstateUtilizationDto(bool isPresent, uint percentage)
        {
            IsPresent = isPresent;
            Percentage = percentage;
        }

        internal static NVAPIGpuDynamicPstateUtilizationDto FromNative(NV_GPU_DYNAMIC_PSTATES_INFO_EX._utilization_e__Struct native)
        {
            return new NVAPIGpuDynamicPstateUtilizationDto(native.bIsPresent != 0, native.percentage);
        }

        internal NV_GPU_DYNAMIC_PSTATES_INFO_EX._utilization_e__Struct ToNative()
        {
            return new NV_GPU_DYNAMIC_PSTATES_INFO_EX._utilization_e__Struct
            {
                bIsPresent = IsPresent ? 1u : 0u,
                percentage = Percentage
            };
        }

        public bool Equals(NVAPIGpuDynamicPstateUtilizationDto other)
        {
            return IsPresent == other.IsPresent && Percentage == other.Percentage;
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuDynamicPstateUtilizationDto other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(IsPresent, Percentage);
        public static bool operator ==(NVAPIGpuDynamicPstateUtilizationDto left, NVAPIGpuDynamicPstateUtilizationDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuDynamicPstateUtilizationDto left, NVAPIGpuDynamicPstateUtilizationDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Dynamic P-state info DTO.
    /// </summary>
    public readonly struct NVAPIGpuDynamicPstatesInfoExDto : IEquatable<NVAPIGpuDynamicPstatesInfoExDto>
    {
        public uint Flags { get; }
        public NVAPIGpuDynamicPstateUtilizationDto[] Utilization { get; }

        public NVAPIGpuDynamicPstatesInfoExDto(uint flags, NVAPIGpuDynamicPstateUtilizationDto[] utilization)
        {
            Flags = flags;
            Utilization = utilization ?? Array.Empty<NVAPIGpuDynamicPstateUtilizationDto>();
        }

        public static NVAPIGpuDynamicPstatesInfoExDto FromNative(NV_GPU_DYNAMIC_PSTATES_INFO_EX native)
        {
            var utilization = new NVAPIGpuDynamicPstateUtilizationDto[8];
            for (var i = 0; i < utilization.Length; i++)
                utilization[i] = NVAPIGpuDynamicPstateUtilizationDto.FromNative(native.utilization[i]);

            return new NVAPIGpuDynamicPstatesInfoExDto(native.flags, utilization);
        }

        public NV_GPU_DYNAMIC_PSTATES_INFO_EX ToNative()
        {
            var native = new NV_GPU_DYNAMIC_PSTATES_INFO_EX
            {
                version = NVAPI.NV_GPU_DYNAMIC_PSTATES_INFO_EX_VER,
                flags = Flags
            };

            var utilization = Utilization ?? Array.Empty<NVAPIGpuDynamicPstateUtilizationDto>();
            var count = Math.Min(utilization.Length, 8);
            for (var i = 0; i < count; i++)
                native.utilization[i] = utilization[i].ToNative();

            return native;
        }

        public bool Equals(NVAPIGpuDynamicPstatesInfoExDto other)
        {
            return Flags == other.Flags
                && NVAPIGpuDtoHelpers.SequenceEquals(
                    Utilization ?? Array.Empty<NVAPIGpuDynamicPstateUtilizationDto>(),
                    other.Utilization ?? Array.Empty<NVAPIGpuDynamicPstateUtilizationDto>());
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuDynamicPstatesInfoExDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = Flags.GetHashCode();
                hash = (hash * 31) + NVAPIGpuDtoHelpers.SequenceHashCode(Utilization ?? Array.Empty<NVAPIGpuDynamicPstateUtilizationDto>());
                return hash;
            }
        }

        public static bool operator ==(NVAPIGpuDynamicPstatesInfoExDto left, NVAPIGpuDynamicPstatesInfoExDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuDynamicPstatesInfoExDto left, NVAPIGpuDynamicPstatesInfoExDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Thermal sensor DTO.
    /// </summary>
    public readonly struct NVAPIGpuThermalSensorDto : IEquatable<NVAPIGpuThermalSensorDto>
    {
        public NV_THERMAL_CONTROLLER Controller { get; }
        public int DefaultMinTemp { get; }
        public int DefaultMaxTemp { get; }
        public int CurrentTemp { get; }
        public NV_THERMAL_TARGET Target { get; }

        public NVAPIGpuThermalSensorDto(NV_THERMAL_CONTROLLER controller, int defaultMinTemp, int defaultMaxTemp, int currentTemp, NV_THERMAL_TARGET target)
        {
            Controller = controller;
            DefaultMinTemp = defaultMinTemp;
            DefaultMaxTemp = defaultMaxTemp;
            CurrentTemp = currentTemp;
            Target = target;
        }

        internal static NVAPIGpuThermalSensorDto FromNative(NV_GPU_THERMAL_SETTINGS_V2._sensor_e__Struct native)
        {
            return new NVAPIGpuThermalSensorDto(
                native.controller,
                native.defaultMinTemp,
                native.defaultMaxTemp,
                native.currentTemp,
                native.target);
        }

        internal NV_GPU_THERMAL_SETTINGS_V2._sensor_e__Struct ToNative()
        {
            return new NV_GPU_THERMAL_SETTINGS_V2._sensor_e__Struct
            {
                controller = Controller,
                defaultMinTemp = DefaultMinTemp,
                defaultMaxTemp = DefaultMaxTemp,
                currentTemp = CurrentTemp,
                target = Target
            };
        }

        public bool Equals(NVAPIGpuThermalSensorDto other)
        {
            return Controller == other.Controller
                && DefaultMinTemp == other.DefaultMinTemp
                && DefaultMaxTemp == other.DefaultMaxTemp
                && CurrentTemp == other.CurrentTemp
                && Target == other.Target;
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuThermalSensorDto other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(Controller, DefaultMinTemp, DefaultMaxTemp, CurrentTemp, Target);
        public static bool operator ==(NVAPIGpuThermalSensorDto left, NVAPIGpuThermalSensorDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuThermalSensorDto left, NVAPIGpuThermalSensorDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Thermal settings DTO.
    /// </summary>
    public readonly struct NVAPIGpuThermalSettingsDto : IEquatable<NVAPIGpuThermalSettingsDto>
    {
        public uint Count { get; }
        public NVAPIGpuThermalSensorDto[] Sensors { get; }

        public NVAPIGpuThermalSettingsDto(uint count, NVAPIGpuThermalSensorDto[] sensors)
        {
            Count = count;
            Sensors = sensors ?? Array.Empty<NVAPIGpuThermalSensorDto>();
        }

        public static NVAPIGpuThermalSettingsDto FromNative(NV_GPU_THERMAL_SETTINGS_V2 native)
        {
            var sensors = new NVAPIGpuThermalSensorDto[3];
            for (var i = 0; i < sensors.Length; i++)
                sensors[i] = NVAPIGpuThermalSensorDto.FromNative(native.sensor[i]);

            return new NVAPIGpuThermalSettingsDto(native.count, sensors);
        }

        public NV_GPU_THERMAL_SETTINGS_V2 ToNative()
        {
            var native = new NV_GPU_THERMAL_SETTINGS_V2
            {
                version = NVAPI.NV_GPU_THERMAL_SETTINGS_VER,
                count = Count
            };

            var sensors = Sensors ?? Array.Empty<NVAPIGpuThermalSensorDto>();
            var count = Math.Min(sensors.Length, 3);
            for (var i = 0; i < count; i++)
                native.sensor[i] = sensors[i].ToNative();

            return native;
        }

        public bool Equals(NVAPIGpuThermalSettingsDto other)
        {
            return Count == other.Count
                && NVAPIGpuDtoHelpers.SequenceEquals(
                    Sensors ?? Array.Empty<NVAPIGpuThermalSensorDto>(),
                    other.Sensors ?? Array.Empty<NVAPIGpuThermalSensorDto>());
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuThermalSettingsDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = Count.GetHashCode();
                hash = (hash * 31) + NVAPIGpuDtoHelpers.SequenceHashCode(Sensors ?? Array.Empty<NVAPIGpuThermalSensorDto>());
                return hash;
            }
        }

        public static bool operator ==(NVAPIGpuThermalSettingsDto left, NVAPIGpuThermalSettingsDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuThermalSettingsDto left, NVAPIGpuThermalSettingsDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Clock domain DTO.
    /// </summary>
    public readonly struct NVAPIGpuClockDomainDto : IEquatable<NVAPIGpuClockDomainDto>
    {
        public bool IsPresent { get; }
        public uint FrequencyKHz { get; }

        public NVAPIGpuClockDomainDto(bool isPresent, uint frequencyKHz)
        {
            IsPresent = isPresent;
            FrequencyKHz = frequencyKHz;
        }

        internal static NVAPIGpuClockDomainDto FromNative(NV_GPU_CLOCK_FREQUENCIES_V2._domain_e__Struct native)
        {
            return new NVAPIGpuClockDomainDto(native.bIsPresent != 0, native.frequency);
        }

        internal NV_GPU_CLOCK_FREQUENCIES_V2._domain_e__Struct ToNative()
        {
            return new NV_GPU_CLOCK_FREQUENCIES_V2._domain_e__Struct
            {
                bIsPresent = IsPresent ? 1u : 0u,
                frequency = FrequencyKHz
            };
        }

        public bool Equals(NVAPIGpuClockDomainDto other)
        {
            return IsPresent == other.IsPresent && FrequencyKHz == other.FrequencyKHz;
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuClockDomainDto other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(IsPresent, FrequencyKHz);
        public static bool operator ==(NVAPIGpuClockDomainDto left, NVAPIGpuClockDomainDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuClockDomainDto left, NVAPIGpuClockDomainDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Clock frequencies DTO.
    /// </summary>
    public readonly struct NVAPIGpuClockFrequenciesDto : IEquatable<NVAPIGpuClockFrequenciesDto>
    {
        public NV_GPU_CLOCK_FREQUENCIES_CLOCK_TYPE ClockType { get; }
        public NVAPIGpuClockDomainDto[] Domains { get; }

        public NVAPIGpuClockFrequenciesDto(NV_GPU_CLOCK_FREQUENCIES_CLOCK_TYPE clockType, NVAPIGpuClockDomainDto[] domains)
        {
            ClockType = clockType;
            Domains = domains ?? Array.Empty<NVAPIGpuClockDomainDto>();
        }

        public static NVAPIGpuClockFrequenciesDto FromNative(NV_GPU_CLOCK_FREQUENCIES_V2 native)
        {
            var domains = new NVAPIGpuClockDomainDto[32];
            for (var i = 0; i < domains.Length; i++)
                domains[i] = NVAPIGpuClockDomainDto.FromNative(native.domain[i]);

            return new NVAPIGpuClockFrequenciesDto((NV_GPU_CLOCK_FREQUENCIES_CLOCK_TYPE)native.ClockType, domains);
        }

        public NV_GPU_CLOCK_FREQUENCIES_V2 ToNative()
        {
            var native = new NV_GPU_CLOCK_FREQUENCIES_V2
            {
                version = NVAPI.NV_GPU_CLOCK_FREQUENCIES_VER,
                ClockType = (uint)ClockType
            };

            var domains = Domains ?? Array.Empty<NVAPIGpuClockDomainDto>();
            var count = Math.Min(domains.Length, 32);
            for (var i = 0; i < count; i++)
                native.domain[i] = domains[i].ToNative();

            return native;
        }

        public bool Equals(NVAPIGpuClockFrequenciesDto other)
        {
            return ClockType == other.ClockType
                && NVAPIGpuDtoHelpers.SequenceEquals(
                    Domains ?? Array.Empty<NVAPIGpuClockDomainDto>(),
                    other.Domains ?? Array.Empty<NVAPIGpuClockDomainDto>());
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuClockFrequenciesDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = ClockType.GetHashCode();
                hash = (hash * 31) + NVAPIGpuDtoHelpers.SequenceHashCode(Domains ?? Array.Empty<NVAPIGpuClockDomainDto>());
                return hash;
            }
        }

        public static bool operator ==(NVAPIGpuClockFrequenciesDto left, NVAPIGpuClockFrequenciesDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuClockFrequenciesDto left, NVAPIGpuClockFrequenciesDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Illumination support DTO.
    /// </summary>
    public readonly struct NVAPIGpuIlluminationSupportDto : IEquatable<NVAPIGpuIlluminationSupportDto>
    {
        public _NV_GPU_ILLUMINATION_ATTRIB Attribute { get; }
        public bool IsSupported { get; }

        public NVAPIGpuIlluminationSupportDto(_NV_GPU_ILLUMINATION_ATTRIB attribute, bool isSupported)
        {
            Attribute = attribute;
            IsSupported = isSupported;
        }

        public static NVAPIGpuIlluminationSupportDto FromNative(_NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_V1 native)
        {
            return new NVAPIGpuIlluminationSupportDto(native.Attribute, native.bSupported != 0);
        }

        public _NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_V1 ToNative()
        {
            return new _NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_V1
            {
                version = NVAPI.NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_VER,
                hPhysicalGpu = null,
                Attribute = Attribute,
                bSupported = IsSupported ? 1u : 0u
            };
        }

        public bool Equals(NVAPIGpuIlluminationSupportDto other)
        {
            return Attribute == other.Attribute && IsSupported == other.IsSupported;
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuIlluminationSupportDto other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(Attribute, IsSupported);
        public static bool operator ==(NVAPIGpuIlluminationSupportDto left, NVAPIGpuIlluminationSupportDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuIlluminationSupportDto left, NVAPIGpuIlluminationSupportDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Illumination value DTO.
    /// </summary>
    public readonly struct NVAPIGpuIlluminationDto : IEquatable<NVAPIGpuIlluminationDto>
    {
        public _NV_GPU_ILLUMINATION_ATTRIB Attribute { get; }
        public uint Value { get; }

        public NVAPIGpuIlluminationDto(_NV_GPU_ILLUMINATION_ATTRIB attribute, uint value)
        {
            Attribute = attribute;
            Value = value;
        }

        public static NVAPIGpuIlluminationDto FromNative(_NV_GPU_GET_ILLUMINATION_PARM_V1 native)
        {
            return new NVAPIGpuIlluminationDto(native.Attribute, native.Value);
        }

        public _NV_GPU_SET_ILLUMINATION_PARM_V1 ToNative()
        {
            return new _NV_GPU_SET_ILLUMINATION_PARM_V1
            {
                version = NVAPI.NV_GPU_SET_ILLUMINATION_PARM_VER,
                hPhysicalGpu = null,
                Attribute = Attribute,
                Value = Value
            };
        }

        public bool Equals(NVAPIGpuIlluminationDto other)
        {
            return Attribute == other.Attribute && Value == other.Value;
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuIlluminationDto other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(Attribute, Value);
        public static bool operator ==(NVAPIGpuIlluminationDto left, NVAPIGpuIlluminationDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuIlluminationDto left, NVAPIGpuIlluminationDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Illumination device info params DTO.
    /// </summary>
    public readonly struct NVAPIGpuIllumDeviceInfoParamsDto : IEquatable<NVAPIGpuIllumDeviceInfoParamsDto>
    {
        public byte[] RawData { get; }

        private NVAPIGpuIllumDeviceInfoParamsDto(byte[] rawData)
        {
            RawData = rawData ?? Array.Empty<byte>();
        }

        public static NVAPIGpuIllumDeviceInfoParamsDto FromNative(_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_V1 native)
        {
            return new NVAPIGpuIllumDeviceInfoParamsDto(NVAPIGpuDtoHelpers.ToByteArray(native));
        }

        public static NVAPIGpuIllumDeviceInfoParamsDto CreateDefault()
        {
            return FromNative(new _NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_V1 { version = NVAPI.NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_VER });
        }

        public _NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_V1 ToNative()
        {
            return NVAPIGpuDtoHelpers.FromByteArray<_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_V1>(RawData);
        }

        public bool Equals(NVAPIGpuIllumDeviceInfoParamsDto other)
        {
            return NVAPIGpuDtoHelpers.SequenceEquals(RawData, other.RawData);
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuIllumDeviceInfoParamsDto other && Equals(other);
        public override int GetHashCode() => NVAPIGpuDtoHelpers.SequenceHashCode(RawData);
        public static bool operator ==(NVAPIGpuIllumDeviceInfoParamsDto left, NVAPIGpuIllumDeviceInfoParamsDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuIllumDeviceInfoParamsDto left, NVAPIGpuIllumDeviceInfoParamsDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Illumination device control params DTO.
    /// </summary>
    public readonly struct NVAPIGpuIllumDeviceControlParamsDto : IEquatable<NVAPIGpuIllumDeviceControlParamsDto>
    {
        public byte[] RawData { get; }

        private NVAPIGpuIllumDeviceControlParamsDto(byte[] rawData)
        {
            RawData = rawData ?? Array.Empty<byte>();
        }

        public static NVAPIGpuIllumDeviceControlParamsDto FromNative(NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_V1 native)
        {
            return new NVAPIGpuIllumDeviceControlParamsDto(NVAPIGpuDtoHelpers.ToByteArray(native));
        }

        public static NVAPIGpuIllumDeviceControlParamsDto CreateDefault()
        {
            return FromNative(new NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_V1 { version = NVAPI.NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_VER });
        }

        public NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_V1 ToNative()
        {
            return NVAPIGpuDtoHelpers.FromByteArray<NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_V1>(RawData);
        }

        public bool Equals(NVAPIGpuIllumDeviceControlParamsDto other)
        {
            return NVAPIGpuDtoHelpers.SequenceEquals(RawData, other.RawData);
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuIllumDeviceControlParamsDto other && Equals(other);
        public override int GetHashCode() => NVAPIGpuDtoHelpers.SequenceHashCode(RawData);
        public static bool operator ==(NVAPIGpuIllumDeviceControlParamsDto left, NVAPIGpuIllumDeviceControlParamsDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuIllumDeviceControlParamsDto left, NVAPIGpuIllumDeviceControlParamsDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Illumination zone info params DTO.
    /// </summary>
    public readonly struct NVAPIGpuIllumZoneInfoParamsDto : IEquatable<NVAPIGpuIllumZoneInfoParamsDto>
    {
        public byte[] RawData { get; }

        private NVAPIGpuIllumZoneInfoParamsDto(byte[] rawData)
        {
            RawData = rawData ?? Array.Empty<byte>();
        }

        public static NVAPIGpuIllumZoneInfoParamsDto FromNative(_NV_GPU_CLIENT_ILLUM_ZONE_INFO_PARAMS_V1 native)
        {
            return new NVAPIGpuIllumZoneInfoParamsDto(NVAPIGpuDtoHelpers.ToByteArray(native));
        }

        public static NVAPIGpuIllumZoneInfoParamsDto CreateDefault()
        {
            return FromNative(new _NV_GPU_CLIENT_ILLUM_ZONE_INFO_PARAMS_V1 { version = NVAPI.NV_GPU_CLIENT_ILLUM_ZONE_INFO_PARAMS_VER });
        }

        public _NV_GPU_CLIENT_ILLUM_ZONE_INFO_PARAMS_V1 ToNative()
        {
            return NVAPIGpuDtoHelpers.FromByteArray<_NV_GPU_CLIENT_ILLUM_ZONE_INFO_PARAMS_V1>(RawData);
        }

        public bool Equals(NVAPIGpuIllumZoneInfoParamsDto other)
        {
            return NVAPIGpuDtoHelpers.SequenceEquals(RawData, other.RawData);
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuIllumZoneInfoParamsDto other && Equals(other);
        public override int GetHashCode() => NVAPIGpuDtoHelpers.SequenceHashCode(RawData);
        public static bool operator ==(NVAPIGpuIllumZoneInfoParamsDto left, NVAPIGpuIllumZoneInfoParamsDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuIllumZoneInfoParamsDto left, NVAPIGpuIllumZoneInfoParamsDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Illumination zone control params DTO.
    /// </summary>
    public readonly struct NVAPIGpuIllumZoneControlParamsDto : IEquatable<NVAPIGpuIllumZoneControlParamsDto>
    {
        public byte[] RawData { get; }

        private NVAPIGpuIllumZoneControlParamsDto(byte[] rawData)
        {
            RawData = rawData ?? Array.Empty<byte>();
        }

        public static NVAPIGpuIllumZoneControlParamsDto FromNative(_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1 native)
        {
            return new NVAPIGpuIllumZoneControlParamsDto(NVAPIGpuDtoHelpers.ToByteArray(native));
        }

        public static NVAPIGpuIllumZoneControlParamsDto CreateDefault()
        {
            return FromNative(new _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1 { version = NVAPI.NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_VER });
        }

        public _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1 ToNative()
        {
            return NVAPIGpuDtoHelpers.FromByteArray<_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1>(RawData);
        }

        public bool Equals(NVAPIGpuIllumZoneControlParamsDto other)
        {
            return NVAPIGpuDtoHelpers.SequenceEquals(RawData, other.RawData);
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuIllumZoneControlParamsDto other && Equals(other);
        public override int GetHashCode() => NVAPIGpuDtoHelpers.SequenceHashCode(RawData);
        public static bool operator ==(NVAPIGpuIllumZoneControlParamsDto left, NVAPIGpuIllumZoneControlParamsDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuIllumZoneControlParamsDto left, NVAPIGpuIllumZoneControlParamsDto right) => !left.Equals(right);
    }

    /// <summary>
    /// P-states (Pstates20) DTO.
    /// </summary>
    public readonly struct NVAPIGpuPerfPstates20InfoDto : IEquatable<NVAPIGpuPerfPstates20InfoDto>
    {
        public byte[] RawData { get; }

        private NVAPIGpuPerfPstates20InfoDto(byte[] rawData)
        {
            RawData = rawData ?? Array.Empty<byte>();
        }

        public static NVAPIGpuPerfPstates20InfoDto FromNative(_NV_GPU_PERF_PSTATES20_INFO_V2 native)
        {
            return new NVAPIGpuPerfPstates20InfoDto(NVAPIGpuDtoHelpers.ToByteArray(native));
        }

        public static NVAPIGpuPerfPstates20InfoDto CreateDefault()
        {
            return FromNative(new _NV_GPU_PERF_PSTATES20_INFO_V2 { version = NVAPI.NV_GPU_PERF_PSTATES20_INFO_VER });
        }

        public _NV_GPU_PERF_PSTATES20_INFO_V2 ToNative()
        {
            return NVAPIGpuDtoHelpers.FromByteArray<_NV_GPU_PERF_PSTATES20_INFO_V2>(RawData);
        }

        public bool Equals(NVAPIGpuPerfPstates20InfoDto other)
        {
            return NVAPIGpuDtoHelpers.SequenceEquals(RawData, other.RawData);
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuPerfPstates20InfoDto other && Equals(other);
        public override int GetHashCode() => NVAPIGpuDtoHelpers.SequenceHashCode(RawData);
        public static bool operator ==(NVAPIGpuPerfPstates20InfoDto left, NVAPIGpuPerfPstates20InfoDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuPerfPstates20InfoDto left, NVAPIGpuPerfPstates20InfoDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Virtualization info DTO.
    /// </summary>
    public readonly struct NVAPIGpuVirtualizationInfoDto : IEquatable<NVAPIGpuVirtualizationInfoDto>
    {
        public byte[] RawData { get; }

        private NVAPIGpuVirtualizationInfoDto(byte[] rawData)
        {
            RawData = rawData ?? Array.Empty<byte>();
        }

        public static NVAPIGpuVirtualizationInfoDto FromNative(_NV_GPU_VIRTUALIZATION_INFO native)
        {
            return new NVAPIGpuVirtualizationInfoDto(NVAPIGpuDtoHelpers.ToByteArray(native));
        }

        public static NVAPIGpuVirtualizationInfoDto CreateDefault()
        {
            return FromNative(new _NV_GPU_VIRTUALIZATION_INFO { version = NVAPI.NV_GPU_VIRTUALIZATION_INFO_VER });
        }

        public _NV_GPU_VIRTUALIZATION_INFO ToNative()
        {
            return NVAPIGpuDtoHelpers.FromByteArray<_NV_GPU_VIRTUALIZATION_INFO>(RawData);
        }

        public bool Equals(NVAPIGpuVirtualizationInfoDto other)
        {
            return NVAPIGpuDtoHelpers.SequenceEquals(RawData, other.RawData);
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuVirtualizationInfoDto other && Equals(other);
        public override int GetHashCode() => NVAPIGpuDtoHelpers.SequenceHashCode(RawData);
        public static bool operator ==(NVAPIGpuVirtualizationInfoDto left, NVAPIGpuVirtualizationInfoDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuVirtualizationInfoDto left, NVAPIGpuVirtualizationInfoDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Licensable features DTO.
    /// </summary>
    public readonly struct NVAPILicensableFeaturesDto : IEquatable<NVAPILicensableFeaturesDto>
    {
        public byte[] RawData { get; }

        private NVAPILicensableFeaturesDto(byte[] rawData)
        {
            RawData = rawData ?? Array.Empty<byte>();
        }

        public static NVAPILicensableFeaturesDto FromNative(_NV_LICENSABLE_FEATURES_V4 native)
        {
            return new NVAPILicensableFeaturesDto(NVAPIGpuDtoHelpers.ToByteArray(native));
        }

        public static NVAPILicensableFeaturesDto CreateDefault()
        {
            return FromNative(new _NV_LICENSABLE_FEATURES_V4 { version = NVAPI.NV_LICENSABLE_FEATURES_VER });
        }

        public _NV_LICENSABLE_FEATURES_V4 ToNative()
        {
            return NVAPIGpuDtoHelpers.FromByteArray<_NV_LICENSABLE_FEATURES_V4>(RawData);
        }

        public bool Equals(NVAPILicensableFeaturesDto other)
        {
            return NVAPIGpuDtoHelpers.SequenceEquals(RawData, other.RawData);
        }

        public override bool Equals(object? obj) => obj is NVAPILicensableFeaturesDto other && Equals(other);
        public override int GetHashCode() => NVAPIGpuDtoHelpers.SequenceHashCode(RawData);
        public static bool operator ==(NVAPILicensableFeaturesDto left, NVAPILicensableFeaturesDto right) => left.Equals(right);
        public static bool operator !=(NVAPILicensableFeaturesDto left, NVAPILicensableFeaturesDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Encoder statistics DTO.
    /// </summary>
    public readonly struct NVAPIEncoderStatisticsDto : IEquatable<NVAPIEncoderStatisticsDto>
    {
        public byte[] RawData { get; }

        private NVAPIEncoderStatisticsDto(byte[] rawData)
        {
            RawData = rawData ?? Array.Empty<byte>();
        }

        public static NVAPIEncoderStatisticsDto FromNative(_NV_ENCODER_STATISTICS_V1 native)
        {
            return new NVAPIEncoderStatisticsDto(NVAPIGpuDtoHelpers.ToByteArray(native));
        }

        public static NVAPIEncoderStatisticsDto CreateDefault()
        {
            return FromNative(new _NV_ENCODER_STATISTICS_V1 { version = NVAPI.NNV_ENCODER_STATISTICS_VER });
        }

        public _NV_ENCODER_STATISTICS_V1 ToNative()
        {
            return NVAPIGpuDtoHelpers.FromByteArray<_NV_ENCODER_STATISTICS_V1>(RawData);
        }

        public bool Equals(NVAPIEncoderStatisticsDto other)
        {
            return NVAPIGpuDtoHelpers.SequenceEquals(RawData, other.RawData);
        }

        public override bool Equals(object? obj) => obj is NVAPIEncoderStatisticsDto other && Equals(other);
        public override int GetHashCode() => NVAPIGpuDtoHelpers.SequenceHashCode(RawData);
        public static bool operator ==(NVAPIEncoderStatisticsDto left, NVAPIEncoderStatisticsDto right) => left.Equals(right);
        public static bool operator !=(NVAPIEncoderStatisticsDto left, NVAPIEncoderStatisticsDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Encoder sessions info DTO.
    /// </summary>
    public readonly struct NVAPIEncoderSessionsInfoDto : IEquatable<NVAPIEncoderSessionsInfoDto>
    {
        public byte[] RawData { get; }

        private NVAPIEncoderSessionsInfoDto(byte[] rawData)
        {
            RawData = rawData ?? Array.Empty<byte>();
        }

        public static NVAPIEncoderSessionsInfoDto FromNative(_NV_ENCODER_SESSIONS_INFO_V1 native)
        {
            return new NVAPIEncoderSessionsInfoDto(NVAPIGpuDtoHelpers.ToByteArray(native));
        }

        public static NVAPIEncoderSessionsInfoDto CreateDefault()
        {
            return FromNative(new _NV_ENCODER_SESSIONS_INFO_V1 { version = NVAPI.NV_ENCODER_SESSIONS_INFO_VER });
        }

        public _NV_ENCODER_SESSIONS_INFO_V1 ToNative()
        {
            return NVAPIGpuDtoHelpers.FromByteArray<_NV_ENCODER_SESSIONS_INFO_V1>(RawData);
        }

        public bool Equals(NVAPIEncoderSessionsInfoDto other)
        {
            return NVAPIGpuDtoHelpers.SequenceEquals(RawData, other.RawData);
        }

        public override bool Equals(object? obj) => obj is NVAPIEncoderSessionsInfoDto other && Equals(other);
        public override int GetHashCode() => NVAPIGpuDtoHelpers.SequenceHashCode(RawData);
        public static bool operator ==(NVAPIEncoderSessionsInfoDto left, NVAPIEncoderSessionsInfoDto right) => left.Equals(right);
        public static bool operator !=(NVAPIEncoderSessionsInfoDto left, NVAPIEncoderSessionsInfoDto right) => !left.Equals(right);
    }

    /// <summary>
    /// VR Ready DTO.
    /// </summary>
    public readonly struct NVAPIGpuVrReadyDto : IEquatable<NVAPIGpuVrReadyDto>
    {
        public byte[] RawData { get; }

        private NVAPIGpuVrReadyDto(byte[] rawData)
        {
            RawData = rawData ?? Array.Empty<byte>();
        }

        public static NVAPIGpuVrReadyDto FromNative(_NV_GPU_VR_READY_V1 native)
        {
            return new NVAPIGpuVrReadyDto(NVAPIGpuDtoHelpers.ToByteArray(native));
        }

        public static NVAPIGpuVrReadyDto CreateDefault()
        {
            return FromNative(new _NV_GPU_VR_READY_V1 { version = NVAPI.NV_GPU_VR_READY_VER });
        }

        public _NV_GPU_VR_READY_V1 ToNative()
        {
            return NVAPIGpuDtoHelpers.FromByteArray<_NV_GPU_VR_READY_V1>(RawData);
        }

        public bool Equals(NVAPIGpuVrReadyDto other)
        {
            return NVAPIGpuDtoHelpers.SequenceEquals(RawData, other.RawData);
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuVrReadyDto other && Equals(other);
        public override int GetHashCode() => NVAPIGpuDtoHelpers.SequenceHashCode(RawData);
        public static bool operator ==(NVAPIGpuVrReadyDto left, NVAPIGpuVrReadyDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuVrReadyDto left, NVAPIGpuVrReadyDto right) => !left.Equals(right);
    }

    /// <summary>
    /// GSP info DTO.
    /// </summary>
    public readonly struct NVAPIGpuGspInfoDto : IEquatable<NVAPIGpuGspInfoDto>
    {
        public byte[] RawData { get; }

        private NVAPIGpuGspInfoDto(byte[] rawData)
        {
            RawData = rawData ?? Array.Empty<byte>();
        }

        public static NVAPIGpuGspInfoDto FromNative(_NV_GPU_GSP_INFO_V1 native)
        {
            return new NVAPIGpuGspInfoDto(NVAPIGpuDtoHelpers.ToByteArray(native));
        }

        public static NVAPIGpuGspInfoDto CreateDefault()
        {
            return FromNative(new _NV_GPU_GSP_INFO_V1 { version = NVAPI.NV_GPU_GSP_INFO_VER });
        }

        public _NV_GPU_GSP_INFO_V1 ToNative()
        {
            return NVAPIGpuDtoHelpers.FromByteArray<_NV_GPU_GSP_INFO_V1>(RawData);
        }

        public bool Equals(NVAPIGpuGspInfoDto other)
        {
            return NVAPIGpuDtoHelpers.SequenceEquals(RawData, other.RawData);
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuGspInfoDto other && Equals(other);
        public override int GetHashCode() => NVAPIGpuDtoHelpers.SequenceHashCode(RawData);
        public static bool operator ==(NVAPIGpuGspInfoDto left, NVAPIGpuGspInfoDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuGspInfoDto left, NVAPIGpuGspInfoDto right) => !left.Equals(right);
    }

    /// <summary>
    /// NVLINK caps DTO.
    /// </summary>
    public readonly struct NVAPINvLinkCapsDto : IEquatable<NVAPINvLinkCapsDto>
    {
        public byte[] RawData { get; }

        private NVAPINvLinkCapsDto(byte[] rawData)
        {
            RawData = rawData ?? Array.Empty<byte>();
        }

        public static NVAPINvLinkCapsDto FromNative(NVLINK_GET_CAPS_V1 native)
        {
            return new NVAPINvLinkCapsDto(NVAPIGpuDtoHelpers.ToByteArray(native));
        }

        public static NVAPINvLinkCapsDto CreateDefault()
        {
            return FromNative(new NVLINK_GET_CAPS_V1 { version = NVAPI.NVLINK_GET_CAPS_VER });
        }

        public NVLINK_GET_CAPS_V1 ToNative()
        {
            return NVAPIGpuDtoHelpers.FromByteArray<NVLINK_GET_CAPS_V1>(RawData);
        }

        public bool Equals(NVAPINvLinkCapsDto other)
        {
            return NVAPIGpuDtoHelpers.SequenceEquals(RawData, other.RawData);
        }

        public override bool Equals(object? obj) => obj is NVAPINvLinkCapsDto other && Equals(other);
        public override int GetHashCode() => NVAPIGpuDtoHelpers.SequenceHashCode(RawData);
        public static bool operator ==(NVAPINvLinkCapsDto left, NVAPINvLinkCapsDto right) => left.Equals(right);
        public static bool operator !=(NVAPINvLinkCapsDto left, NVAPINvLinkCapsDto right) => !left.Equals(right);
    }

    /// <summary>
    /// NVLINK status DTO.
    /// </summary>
    public readonly struct NVAPINvLinkStatusDto : IEquatable<NVAPINvLinkStatusDto>
    {
        public byte[] RawData { get; }

        private NVAPINvLinkStatusDto(byte[] rawData)
        {
            RawData = rawData ?? Array.Empty<byte>();
        }

        public static NVAPINvLinkStatusDto FromNative(NVLINK_GET_STATUS_V2 native)
        {
            return new NVAPINvLinkStatusDto(NVAPIGpuDtoHelpers.ToByteArray(native));
        }

        public static NVAPINvLinkStatusDto CreateDefault()
        {
            return FromNative(new NVLINK_GET_STATUS_V2 { version = NVAPI.NVLINK_GET_STATUS_VER });
        }

        public NVLINK_GET_STATUS_V2 ToNative()
        {
            return NVAPIGpuDtoHelpers.FromByteArray<NVLINK_GET_STATUS_V2>(RawData);
        }

        public bool Equals(NVAPINvLinkStatusDto other)
        {
            return NVAPIGpuDtoHelpers.SequenceEquals(RawData, other.RawData);
        }

        public override bool Equals(object? obj) => obj is NVAPINvLinkStatusDto other && Equals(other);
        public override int GetHashCode() => NVAPIGpuDtoHelpers.SequenceHashCode(RawData);
        public static bool operator ==(NVAPINvLinkStatusDto left, NVAPINvLinkStatusDto right) => left.Equals(right);
        public static bool operator !=(NVAPINvLinkStatusDto left, NVAPINvLinkStatusDto right) => !left.Equals(right);
    }

    /// <summary>
    /// GPU info DTO.
    /// </summary>
    public readonly struct NVAPIGpuInfoDto : IEquatable<NVAPIGpuInfoDto>
    {
        public byte[] RawData { get; }

        private NVAPIGpuInfoDto(byte[] rawData)
        {
            RawData = rawData ?? Array.Empty<byte>();
        }

        public static NVAPIGpuInfoDto FromNative(_NV_GPU_INFO_V2 native)
        {
            return new NVAPIGpuInfoDto(NVAPIGpuDtoHelpers.ToByteArray(native));
        }

        public static NVAPIGpuInfoDto CreateDefault()
        {
            return FromNative(new _NV_GPU_INFO_V2 { version = NVAPI.NV_GPU_INFO_VER });
        }

        public _NV_GPU_INFO_V2 ToNative()
        {
            return NVAPIGpuDtoHelpers.FromByteArray<_NV_GPU_INFO_V2>(RawData);
        }

        public bool Equals(NVAPIGpuInfoDto other)
        {
            return NVAPIGpuDtoHelpers.SequenceEquals(RawData, other.RawData);
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuInfoDto other && Equals(other);
        public override int GetHashCode() => NVAPIGpuDtoHelpers.SequenceHashCode(RawData);
        public static bool operator ==(NVAPIGpuInfoDto left, NVAPIGpuInfoDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuInfoDto left, NVAPIGpuInfoDto right) => !left.Equals(right);
    }

    internal static class NVAPIGpuDtoHelpers
    {
        public static bool SequenceEquals<T>(T[]? left, T[]? right)
        {
            if (ReferenceEquals(left, right))
                return true;

            if (left is null || right is null)
                return false;

            if (left.Length != right.Length)
                return false;

            for (var i = 0; i < left.Length; i++)
            {
                if (!Equals(left[i], right[i]))
                    return false;
            }

            return true;
        }

        public static int SequenceHashCode<T>(T[]? values)
        {
            if (values is null || values.Length == 0)
                return 0;

            unchecked
            {
                var hash = 17;
                for (var i = 0; i < values.Length; i++)
                    hash = (hash * 31) + (values[i]?.GetHashCode() ?? 0);
                return hash;
            }
        }

        public static unsafe byte[] ToByteArray<T>(T value) where T : unmanaged
        {
            var size = sizeof(T);
            var data = new byte[size];
            fixed (byte* pData = data)
            {
                *(T*)pData = value;
            }
            return data;
        }

        public static unsafe T FromByteArray<T>(byte[] data) where T : unmanaged
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            if (data.Length != sizeof(T))
                throw new ArgumentException($"Expected {sizeof(T)} bytes but received {data.Length}.", nameof(data));

            fixed (byte* pData = data)
            {
                return *(T*)pData;
            }
        }
    }
}
