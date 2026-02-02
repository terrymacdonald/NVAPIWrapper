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
        private const uint NvApiIdGpuGetVbiosRevision = 0xACC3DA0A;
        private const uint NvApiIdGpuGetVbiosOemRevision = 0x2D43FB31;
        private const uint NvApiIdGpuGetArchInfo = 0xD8265D24;
        private const uint NvApiIdGpuGetBoardInfo = 0x22D54523;
        private const uint NvApiIdGpuGetCurrentPCIEDownstreamWidth = 0xD048C3B1;
        private const uint NvApiIdGpuGetEccConfigurationInfo = 0x77A796F3;
        private const uint NvApiIdGpuGetEccErrorInfo = 0xC71F85A6;
        private const uint NvApiIdGpuResetEccErrorInfo = 0xC02EEC20;
        private const uint NvApiIdGpuSetEccConfiguration = 0x1CF639D9;
        private const uint NvApiIdGpuGetEdid = 0x37D32E69;
        private const uint NvApiIdGpuSetEdid = 0xE83D6456;
        private const uint NvApiIdGpuGetHdcpSupportStatus = 0xF089EEF5;
        private const uint NvApiIdGpuGetIrq = 0xE4715417;
        private const uint NvApiIdGpuGetLogicalGpuInfo = 0x842B066E;
        private const uint NvApiIdGpuGetOutputType = 0x40A505E4;
        private const uint NvApiIdGpuGetRamBusWidth = 0x7975C581;
        private const uint NvApiIdGpuGetScanoutCompositionParameter = 0x58FE51E6;
        private const uint NvApiIdGpuSetScanoutCompositionParameter = 0xF898247D;
        private const uint NvApiIdGpuGetScanoutConfiguration = 0x6A9F5B63;
        private const uint NvApiIdGpuGetScanoutConfigurationEx = 0xE2E1E6F0;
        private const uint NvApiIdGpuGetScanoutIntensityState = 0xE81CE836;
        private const uint NvApiIdGpuSetScanoutIntensity = 0xA57457A4;
        private const uint NvApiIdGpuGetScanoutWarpingState = 0x6F5435AF;
        private const uint NvApiIdGpuSetScanoutWarping = 0xB34BAB4F;
        private const uint NvApiIdGpuValidateOutputCombination = 0x34C9C2D4;
        private const uint NvApiIdGpuQueryWorkstationFeatureSupport = 0x80B1ABB9;
        private const uint NvApiIdGpuWorkstationFeatureQuery = 0x004537DF;
        private const uint NvApiIdGpuWorkstationFeatureSetup = 0x6C1F3FE4;
        private const uint NvApiIdGpuClientRegisterForUtilizationSampleUpdates = 0xADEEAF67;
        private const uint NvApiIdGetLogicalGpuFromPhysicalGpu = 0xADD604D1;
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

        /// <summary>
        /// Get GPU architecture info.
        /// </summary>
        /// <returns>Architecture info DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuArchInfoDto? GetArchInfo()
        {
            ThrowIfDisposed();

            var getInfo = GetDelegate<NvApiGpuGetArchInfoDelegate>(NvApiIdGpuGetArchInfo, "NvAPI_GPU_GetArchInfo");
            var info = CreateGpuArchInfo();
            var status = getInfo(GetHandle(), &info);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGpuArchInfoDto.FromNative(info);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get GPU board info.
        /// </summary>
        /// <returns>Board info DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuBoardInfoDto? GetBoardInfo()
        {
            ThrowIfDisposed();

            var getInfo = GetDelegate<NvApiGpuGetBoardInfoDelegate>(NvApiIdGpuGetBoardInfo, "NvAPI_GPU_GetBoardInfo");
            var info = CreateBoardInfo();
            var status = getInfo(GetHandle(), &info);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGpuBoardInfoDto.FromNative(info);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the VBIOS revision.
        /// </summary>
        /// <returns>VBIOS revision, or null if unavailable.</returns>
        public unsafe uint? GetVbiosRevision()
        {
            ThrowIfDisposed();

            var getRevision = GetDelegate<NvApiGpuGetVbiosRevisionDelegate>(NvApiIdGpuGetVbiosRevision, "NvAPI_GPU_GetVbiosRevision");
            uint revision = 0;
            var status = getRevision(GetHandle(), &revision);
            if (status == _NvAPI_Status.NVAPI_OK)
                return revision;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the VBIOS OEM revision.
        /// </summary>
        /// <returns>VBIOS OEM revision, or null if unavailable.</returns>
        public unsafe uint? GetVbiosOemRevision()
        {
            ThrowIfDisposed();

            var getRevision = GetDelegate<NvApiGpuGetVbiosOemRevisionDelegate>(NvApiIdGpuGetVbiosOemRevision, "NvAPI_GPU_GetVbiosOEMRevision");
            uint revision = 0;
            var status = getRevision(GetHandle(), &revision);
            if (status == _NvAPI_Status.NVAPI_OK)
                return revision;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get current PCIe downstream width.
        /// </summary>
        /// <returns>PCIe downstream width, or null if unavailable.</returns>
        public unsafe uint? GetCurrentPcieDownstreamWidth()
        {
            ThrowIfDisposed();

            var getWidth = GetDelegate<NvApiGpuGetCurrentPcieDownstreamWidthDelegate>(
                NvApiIdGpuGetCurrentPCIEDownstreamWidth,
                "NvAPI_GPU_GetCurrentPCIEDownstreamWidth");
            uint width = 0;
            var status = getWidth(GetHandle(), &width);
            if (status == _NvAPI_Status.NVAPI_OK)
                return width;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the GPU RAM bus width.
        /// </summary>
        /// <returns>RAM bus width, or null if unavailable.</returns>
        public unsafe uint? GetRamBusWidth()
        {
            ThrowIfDisposed();

            var getWidth = GetDelegate<NvApiGpuGetRamBusWidthDelegate>(NvApiIdGpuGetRamBusWidth, "NvAPI_GPU_GetRamBusWidth");
            uint width = 0;
            var status = getWidth(GetHandle(), &width);
            if (status == _NvAPI_Status.NVAPI_OK)
                return width;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the GPU IRQ.
        /// </summary>
        /// <returns>IRQ value, or null if unavailable.</returns>
        public unsafe uint? GetIrq()
        {
            ThrowIfDisposed();

            var getIrq = GetDelegate<NvApiGpuGetIrqDelegate>(NvApiIdGpuGetIrq, "NvAPI_GPU_GetIRQ");
            uint irq = 0;
            var status = getIrq(GetHandle(), &irq);
            if (status == _NvAPI_Status.NVAPI_OK)
                return irq;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get GPU output type for the specified output ID.
        /// </summary>
        /// <param name="outputId">Output ID (single bit set).</param>
        /// <returns>Output type, or null if unavailable.</returns>
        public unsafe _NV_GPU_OUTPUT_TYPE? GetOutputType(uint outputId)
        {
            ThrowIfDisposed();

            var getType = GetDelegate<NvApiGpuGetOutputTypeDelegate>(NvApiIdGpuGetOutputType, "NvAPI_GPU_GetOutputType");
            _NV_GPU_OUTPUT_TYPE outputType = default;
            var status = getType(GetHandle(), outputId, &outputType);
            if (status == _NvAPI_Status.NVAPI_OK)
                return outputType;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Validate an output combination mask.
        /// </summary>
        /// <param name="outputsMask">Outputs mask to validate.</param>
        /// <returns>True if valid, false if invalid, or null if unavailable.</returns>
        public unsafe bool? ValidateOutputCombination(uint outputsMask)
        {
            ThrowIfDisposed();

            var validate = GetDelegate<NvApiGpuValidateOutputCombinationDelegate>(
                NvApiIdGpuValidateOutputCombination,
                "NvAPI_GPU_ValidateOutputCombination");
            var status = validate(GetHandle(), outputsMask);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_INVALID_COMBINATION)
                return false;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get ECC configuration info.
        /// </summary>
        /// <returns>ECC configuration DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuEccConfigurationInfoDto? GetEccConfigurationInfo()
        {
            ThrowIfDisposed();

            var getInfo = GetDelegate<NvApiGpuGetEccConfigurationInfoDelegate>(
                NvApiIdGpuGetEccConfigurationInfo,
                "NvAPI_GPU_GetECCConfigurationInfo");
            var info = CreateEccConfigurationInfo();
            var status = getInfo(GetHandle(), &info);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGpuEccConfigurationInfoDto.FromNative(info);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Set ECC configuration.
        /// </summary>
        /// <param name="enable">True to enable ECC.</param>
        /// <param name="enableImmediately">True to enable immediately.</param>
        /// <returns>True if applied or unchanged, false if unavailable.</returns>
        public unsafe bool SetEccConfiguration(bool enable, bool enableImmediately = true)
        {
            ThrowIfDisposed();

            var current = GetEccConfigurationInfo();
            if (current == null)
                return false;

            if (current.Value.IsEnabled == enable)
                return true;

            var setInfo = GetDelegate<NvApiGpuSetEccConfigurationDelegate>(
                NvApiIdGpuSetEccConfiguration,
                "NvAPI_GPU_SetECCConfiguration");

            var status = setInfo(GetHandle(), enable ? (byte)1 : (byte)0, enableImmediately ? (byte)1 : (byte)0);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get ECC error info.
        /// </summary>
        /// <returns>ECC error info DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuEccErrorInfoDto? GetEccErrorInfo()
        {
            ThrowIfDisposed();

            var getInfo = GetDelegate<NvApiGpuGetEccErrorInfoDelegate>(
                NvApiIdGpuGetEccErrorInfo,
                "NvAPI_GPU_GetECCErrorInfo");
            var info = CreateEccErrorInfo();
            var status = getInfo(GetHandle(), &info);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGpuEccErrorInfoDto.FromNative(info);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Reset ECC error counts.
        /// </summary>
        /// <param name="resetCurrent">Reset current error counts.</param>
        /// <param name="resetAggregate">Reset aggregate error counts.</param>
        /// <returns>True if reset, false if unavailable.</returns>
        public unsafe bool ResetEccErrorInfo(bool resetCurrent = true, bool resetAggregate = true)
        {
            ThrowIfDisposed();

            var resetInfo = GetDelegate<NvApiGpuResetEccErrorInfoDelegate>(
                NvApiIdGpuResetEccErrorInfo,
                "NvAPI_GPU_ResetECCErrorInfo");
            var status = resetInfo(GetHandle(), resetCurrent ? (byte)1 : (byte)0, resetAggregate ? (byte)1 : (byte)0);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get HDCP support status.
        /// </summary>
        /// <returns>HDCP support status DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuHdcpSupportStatusDto? GetHdcpSupportStatus()
        {
            ThrowIfDisposed();

            var getStatus = GetDelegate<NvApiGpuGetHdcpSupportStatusDelegate>(
                NvApiIdGpuGetHdcpSupportStatus,
                "NvAPI_GPU_GetHDCPSupportStatus");
            var statusInfo = CreateHdcpSupportStatus();
            var status = getStatus(GetHandle(), &statusInfo);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGpuHdcpSupportStatusDto.FromNative(statusInfo);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get EDID data for a GPU output.
        /// </summary>
        /// <param name="displayOutputId">Display output ID.</param>
        /// <returns>EDID DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuEdidDto? GetEdid(uint displayOutputId)
        {
            ThrowIfDisposed();

            var getEdid = GetDelegate<NvApiGpuGetEdidDelegate>(NvApiIdGpuGetEdid, "NvAPI_GPU_GetEDID");
            var edid = CreateGpuEdid();
            var status = getEdid(GetHandle(), displayOutputId, &edid);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGpuEdidDto.FromNative(edid);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Set EDID data for a GPU output.
        /// </summary>
        /// <param name="displayOutputId">Display output ID.</param>
        /// <param name="edid">EDID data DTO.</param>
        /// <returns>True if applied or unchanged, false if unavailable.</returns>
        public unsafe bool SetEdid(uint displayOutputId, NVAPIGpuEdidDto edid)
        {
            ThrowIfDisposed();

            var current = GetEdid(displayOutputId);
            if (current == null)
                return false;

            if (current.Value.Equals(edid))
                return true;

            var setEdid = GetDelegate<NvApiGpuSetEdidDelegate>(NvApiIdGpuSetEdid, "NvAPI_GPU_SetEDID");
            var native = edid.ToNative();
            var status = setEdid(GetHandle(), displayOutputId, &native);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get logical GPU info associated with this physical GPU.
        /// </summary>
        /// <returns>Logical GPU info DTO, or null if unavailable.</returns>
        public unsafe NVAPILogicalGpuInfoDto? GetLogicalGpuInfo()
        {
            ThrowIfDisposed();

            var getLogical = GetDelegate<NvApiGetLogicalGpuFromPhysicalGpuDelegate>(
                NvApiIdGetLogicalGpuFromPhysicalGpu,
                "NvAPI_GetLogicalGPUFromPhysicalGPU");
            NvLogicalGpuHandle__* logical = null;
            var status = getLogical(GetHandle(), &logical);
            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            var getInfo = GetDelegate<NvApiGpuGetLogicalGpuInfoDelegate>(
                NvApiIdGpuGetLogicalGpuInfo,
                "NvAPI_GPU_GetLogicalGpuInfo");
            var info = CreateLogicalGpuInfo();
            status = getInfo(logical, &info);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPILogicalGpuInfoDto.FromNative(_apiHelper, info);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Register or unregister for GPU utilization sample updates.
        /// </summary>
        /// <param name="settings">Callback settings DTO (set Callback to IntPtr.Zero to unregister).</param>
        /// <returns>True if registered, false if unavailable.</returns>
        public unsafe bool RegisterForUtilizationSampleUpdates(NVAPIGpuUtilizationSampleCallbackSettingsDto settings)
        {
            ThrowIfDisposed();

            var register = GetDelegate<NvApiGpuClientRegisterForUtilizationSampleUpdatesDelegate>(
                NvApiIdGpuClientRegisterForUtilizationSampleUpdates,
                "NvAPI_GPU_ClientRegisterForUtilizationSampleUpdates");
            var native = settings.ToNative();
            var status = register(GetHandle(), &native);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get scanout composition parameter.
        /// </summary>
        /// <param name="displayId">Display ID.</param>
        /// <param name="parameter">Parameter to query.</param>
        /// <returns>Scanout composition parameter DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuScanoutCompositionParameterDto? GetScanoutCompositionParameter(
            uint displayId,
            NV_GPU_SCANOUT_COMPOSITION_PARAMETER parameter)
        {
            ThrowIfDisposed();

            var getParam = GetDelegate<NvApiGpuGetScanoutCompositionParameterDelegate>(
                NvApiIdGpuGetScanoutCompositionParameter,
                "NvAPI_GPU_GetScanoutCompositionParameter");
            NV_GPU_SCANOUT_COMPOSITION_PARAMETER_VALUE value = default;
            float container = 0;
            var status = getParam(displayId, parameter, &value, &container);
            if (status == _NvAPI_Status.NVAPI_OK)
                return new NVAPIGpuScanoutCompositionParameterDto(parameter, value, container);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Set scanout composition parameter.
        /// </summary>
        /// <param name="displayId">Display ID.</param>
        /// <param name="parameter">Parameter settings.</param>
        /// <returns>True if applied or unchanged, false if unavailable.</returns>
        public unsafe bool SetScanoutCompositionParameter(uint displayId, NVAPIGpuScanoutCompositionParameterDto parameter)
        {
            ThrowIfDisposed();

            var current = GetScanoutCompositionParameter(displayId, parameter.Parameter);
            if (current == null)
                return false;

            if (current.Value.Equals(parameter))
                return true;

            var setParam = GetDelegate<NvApiGpuSetScanoutCompositionParameterDelegate>(
                NvApiIdGpuSetScanoutCompositionParameter,
                "NvAPI_GPU_SetScanoutCompositionParameter");

            var container = parameter.Container;
            var status = setParam(displayId, parameter.Parameter, parameter.Value, &container);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get scanout configuration.
        /// </summary>
        /// <param name="displayId">Display ID.</param>
        /// <returns>Scanout configuration DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuScanoutConfigurationDto? GetScanoutConfiguration(uint displayId)
        {
            ThrowIfDisposed();

            var getConfig = GetDelegate<NvApiGpuGetScanoutConfigurationDelegate>(
                NvApiIdGpuGetScanoutConfiguration,
                "NvAPI_GPU_GetScanoutConfiguration");
            NvSBox desktopRect = default;
            NvSBox scanoutRect = default;
            var status = getConfig(displayId, &desktopRect, &scanoutRect);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGpuScanoutConfigurationDto.FromNative(desktopRect, scanoutRect);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get extended scanout configuration.
        /// </summary>
        /// <param name="displayId">Display ID.</param>
        /// <returns>Scanout configuration DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuScanoutConfigurationExDto? GetScanoutConfigurationEx(uint displayId)
        {
            ThrowIfDisposed();

            var getConfig = GetDelegate<NvApiGpuGetScanoutConfigurationExDelegate>(
                NvApiIdGpuGetScanoutConfigurationEx,
                "NvAPI_GPU_GetScanoutConfigurationEx");
            var info = CreateScanoutInformation();
            var status = getConfig(displayId, &info);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGpuScanoutConfigurationExDto.FromNative(info);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get scanout intensity state.
        /// </summary>
        /// <param name="displayId">Display ID.</param>
        /// <returns>Scanout intensity state DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuScanoutIntensityStateDto? GetScanoutIntensityState(uint displayId)
        {
            ThrowIfDisposed();

            var getState = GetDelegate<NvApiGpuGetScanoutIntensityStateDelegate>(
                NvApiIdGpuGetScanoutIntensityState,
                "NvAPI_GPU_GetScanoutIntensityState");
            var state = CreateScanoutIntensityState();
            var status = getState(displayId, &state);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGpuScanoutIntensityStateDto.FromNative(state);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Set scanout intensity.
        /// </summary>
        /// <param name="displayId">Display ID.</param>
        /// <param name="data">Scanout intensity data.</param>
        /// <returns>Result DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuScanoutIntensityResultDto? SetScanoutIntensity(uint displayId, NVAPIGpuScanoutIntensityDataDto data)
        {
            ThrowIfDisposed();

            var setIntensity = GetDelegate<NvApiGpuSetScanoutIntensityDelegate>(
                NvApiIdGpuSetScanoutIntensity,
                "NvAPI_GPU_SetScanoutIntensity");
            var native = data.ToNative();

            var blending = data.BlendingTexture ?? Array.Empty<float>();
            var offset = data.OffsetTexture ?? Array.Empty<float>();

            fixed (float* pBlend = blending)
            fixed (float* pOffset = offset)
            {
                native.blendingTexture = blending.Length > 0 ? pBlend : null;
                native.offsetTexture = offset.Length > 0 ? pOffset : null;
                int sticky = 0;
                var status = setIntensity(displayId, &native, &sticky);
                if (status == _NvAPI_Status.NVAPI_OK)
                    return new NVAPIGpuScanoutIntensityResultDto(sticky != 0);

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return null;

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Get scanout warping state.
        /// </summary>
        /// <param name="displayId">Display ID.</param>
        /// <returns>Scanout warping state DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuScanoutWarpingStateDto? GetScanoutWarpingState(uint displayId)
        {
            ThrowIfDisposed();

            var getState = GetDelegate<NvApiGpuGetScanoutWarpingStateDelegate>(
                NvApiIdGpuGetScanoutWarpingState,
                "NvAPI_GPU_GetScanoutWarpingState");
            var state = CreateScanoutWarpingState();
            var status = getState(displayId, &state);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGpuScanoutWarpingStateDto.FromNative(state);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Set scanout warping.
        /// </summary>
        /// <param name="displayId">Display ID.</param>
        /// <param name="data">Scanout warping data.</param>
        /// <returns>Result DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuScanoutWarpingResultDto? SetScanoutWarping(uint displayId, NVAPIGpuScanoutWarpingDataDto data)
        {
            ThrowIfDisposed();

            var setWarping = GetDelegate<NvApiGpuSetScanoutWarpingDelegate>(
                NvApiIdGpuSetScanoutWarping,
                "NvAPI_GPU_SetScanoutWarping");
            var native = data.ToNative();
            var vertices = data.Vertices ?? Array.Empty<float>();
            int maxNumVertices = 0;
            int sticky = 0;

            fixed (float* pVertices = vertices)
            {
                native.vertices = vertices.Length > 0 ? pVertices : null;
                native.numVertices = data.NumVertices;

                if (data.TextureRect.HasValue)
                {
                    var rect = data.TextureRect.Value.ToNative();
                    native.textureRect = &rect;
                    var status = setWarping(displayId, &native, &maxNumVertices, &sticky);
                    if (status == _NvAPI_Status.NVAPI_OK)
                        return new NVAPIGpuScanoutWarpingResultDto(maxNumVertices, sticky != 0);

                    if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                        return null;

                    throw new NVAPIException(status);
                }
                else
                {
                    native.textureRect = null;
                    var status = setWarping(displayId, &native, &maxNumVertices, &sticky);
                    if (status == _NvAPI_Status.NVAPI_OK)
                        return new NVAPIGpuScanoutWarpingResultDto(maxNumVertices, sticky != 0);

                    if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                        return null;

                    throw new NVAPIException(status);
                }
            }
        }

        /// <summary>
        /// Query workstation feature support for this GPU.
        /// </summary>
        /// <param name="feature">Workstation feature type.</param>
        /// <returns>True if supported, false if not supported, or null if unavailable.</returns>
        public unsafe bool? QueryWorkstationFeatureSupport(_NV_GPU_WORKSTATION_FEATURE_TYPE feature)
        {
            ThrowIfDisposed();

            var query = GetDelegate<NvApiGpuQueryWorkstationFeatureSupportDelegate>(
                NvApiIdGpuQueryWorkstationFeatureSupport,
                "NvAPI_GPU_QueryWorkstationFeatureSupport");
            var status = query(GetHandle(), feature);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED)
                return false;

            if (status == _NvAPI_Status.NVAPI_SETTING_NOT_FOUND
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Query workstation feature masks.
        /// </summary>
        /// <returns>Workstation feature query DTO, or null if unavailable.</returns>
        public unsafe NVAPIGpuWorkstationFeatureQueryDto? WorkstationFeatureQuery()
        {
            ThrowIfDisposed();

            var query = GetDelegate<NvApiGpuWorkstationFeatureQueryDelegate>(
                NvApiIdGpuWorkstationFeatureQuery,
                "NvAPI_GPU_WorkstationFeatureQuery");
            uint configured = 0;
            uint consistent = 0;
            var status = query(GetHandle(), &configured, &consistent);
            if (status == _NvAPI_Status.NVAPI_OK)
                return new NVAPIGpuWorkstationFeatureQueryDto(configured, consistent);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Configure workstation feature masks.
        /// </summary>
        /// <param name="featureEnableMask">Features to enable.</param>
        /// <param name="featureDisableMask">Features to disable.</param>
        /// <returns>True if applied, false if unavailable.</returns>
        public unsafe bool WorkstationFeatureSetup(uint featureEnableMask, uint featureDisableMask)
        {
            ThrowIfDisposed();

            var setup = GetDelegate<NvApiGpuWorkstationFeatureSetupDelegate>(
                NvApiIdGpuWorkstationFeatureSetup,
                "NvAPI_GPU_WorkstationFeatureSetup");
            var status = setup(GetHandle(), featureEnableMask, featureDisableMask);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
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

        private static NV_GPU_ARCH_INFO_V2 CreateGpuArchInfo()
        {
            return new NV_GPU_ARCH_INFO_V2 { version = NVAPI.NV_GPU_ARCH_INFO_VER };
        }

        private static _NV_BOARD_INFO CreateBoardInfo()
        {
            return new _NV_BOARD_INFO { version = NVAPI.NV_BOARD_INFO_VER };
        }

        private static NV_GPU_ECC_CONFIGURATION_INFO CreateEccConfigurationInfo()
        {
            return new NV_GPU_ECC_CONFIGURATION_INFO { version = NVAPI.NV_GPU_ECC_CONFIGURATION_INFO_VER };
        }

        private static NV_GPU_ECC_ERROR_INFO CreateEccErrorInfo()
        {
            return new NV_GPU_ECC_ERROR_INFO { version = NVAPI.NV_GPU_ECC_ERROR_INFO_VER };
        }

        private static NV_GPU_GET_HDCP_SUPPORT_STATUS CreateHdcpSupportStatus()
        {
            return new NV_GPU_GET_HDCP_SUPPORT_STATUS { version = NVAPI.NV_GPU_GET_HDCP_SUPPORT_STATUS_VER };
        }

        private static NV_EDID_V3 CreateGpuEdid()
        {
            return new NV_EDID_V3 { version = NVAPI.NV_EDID_VER };
        }

        private static _NV_LOGICAL_GPU_DATA_V1 CreateLogicalGpuInfo()
        {
            return new _NV_LOGICAL_GPU_DATA_V1 { version = NVAPI.NV_LOGICAL_GPU_DATA_VER };
        }

        private static _NV_SCANOUT_INFORMATION CreateScanoutInformation()
        {
            return new _NV_SCANOUT_INFORMATION { version = NVAPI.NV_SCANOUT_INFORMATION_VER };
        }

        private static _NV_SCANOUT_INTENSITY_STATE_DATA CreateScanoutIntensityState()
        {
            return new _NV_SCANOUT_INTENSITY_STATE_DATA { version = NVAPI.NV_SCANOUT_INTENSITY_STATE_VER };
        }

        private static _NV_SCANOUT_WARPING_STATE_DATA CreateScanoutWarpingState()
        {
            return new _NV_SCANOUT_WARPING_STATE_DATA { version = NVAPI.NV_SCANOUT_WARPING_STATE_VER };
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

        internal unsafe NvPhysicalGpuHandle__* GetHandle()
        {
            return (NvPhysicalGpuHandle__*)_handle;
        }

        internal IntPtr GetHandleOrThrow()
        {
            ThrowIfDisposed();
            return _handle;
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

        internal void ThrowIfDisposed()
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

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetVbiosRevisionDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, uint* pBiosRevision);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetVbiosOemRevisionDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, uint* pBiosRevision);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetArchInfoDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, NV_GPU_ARCH_INFO_V2* pGpuArchInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetBoardInfoDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, _NV_BOARD_INFO* pBoardInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetCurrentPcieDownstreamWidthDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, uint* pWidth);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetRamBusWidthDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, uint* pWidth);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetIrqDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, uint* pIrq);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetOutputTypeDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, uint outputId, _NV_GPU_OUTPUT_TYPE* pOutputType);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuValidateOutputCombinationDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, uint outputsMask);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetEccConfigurationInfoDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, NV_GPU_ECC_CONFIGURATION_INFO* pEccConfigurationInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuSetEccConfigurationDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, byte bEnable, byte bEnableImmediately);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetEccErrorInfoDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, NV_GPU_ECC_ERROR_INFO* pEccErrorInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuResetEccErrorInfoDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, byte bResetCurrent, byte bResetAggregate);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetHdcpSupportStatusDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, NV_GPU_GET_HDCP_SUPPORT_STATUS* pGetHdcpSupportStatus);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetEdidDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, uint displayOutputId, NV_EDID_V3* pEdid);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuSetEdidDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, uint displayOutputId, NV_EDID_V3* pEdid);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGetLogicalGpuFromPhysicalGpuDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, NvLogicalGpuHandle__** pLogicalGpu);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetLogicalGpuInfoDelegate(NvLogicalGpuHandle__* hLogicalGpu, _NV_LOGICAL_GPU_DATA_V1* pLogicalGpuData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuClientRegisterForUtilizationSampleUpdatesDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, _NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS_V1* pCallbackSettings);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetScanoutCompositionParameterDelegate(
            uint displayId,
            NV_GPU_SCANOUT_COMPOSITION_PARAMETER parameter,
            NV_GPU_SCANOUT_COMPOSITION_PARAMETER_VALUE* parameterData,
            float* pContainer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuSetScanoutCompositionParameterDelegate(
            uint displayId,
            NV_GPU_SCANOUT_COMPOSITION_PARAMETER parameter,
            NV_GPU_SCANOUT_COMPOSITION_PARAMETER_VALUE parameterValue,
            float* pContainer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetScanoutConfigurationDelegate(uint displayId, NvSBox* desktopRect, NvSBox* scanoutRect);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetScanoutConfigurationExDelegate(uint displayId, _NV_SCANOUT_INFORMATION* pScanoutInformation);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetScanoutIntensityStateDelegate(uint displayId, _NV_SCANOUT_INTENSITY_STATE_DATA* scanoutIntensityStateData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuSetScanoutIntensityDelegate(uint displayId, NV_SCANOUT_INTENSITY_DATA_V2* scanoutIntensityData, int* pbSticky);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuGetScanoutWarpingStateDelegate(uint displayId, _NV_SCANOUT_WARPING_STATE_DATA* scanoutWarpingStateData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuSetScanoutWarpingDelegate(uint displayId, NV_SCANOUT_WARPING_DATA* scanoutWarpingData, int* piMaxNumVertices, int* pbSticky);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuQueryWorkstationFeatureSupportDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, _NV_GPU_WORKSTATION_FEATURE_TYPE gpuWorkstationFeature);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuWorkstationFeatureQueryDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, uint* pConfiguredFeatureMask, uint* pConsistentFeatureMask);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGpuWorkstationFeatureSetupDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, uint featureEnableMask, uint featureDisableMask);
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

    /// <summary>
    /// GPU architecture info DTO.
    /// </summary>
    public readonly struct NVAPIGpuArchInfoDto : IEquatable<NVAPIGpuArchInfoDto>
    {
        public _NV_GPU_ARCHITECTURE_ID ArchitectureId { get; }
        public _NV_GPU_ARCH_IMPLEMENTATION_ID ImplementationId { get; }
        public _NV_GPU_CHIP_REVISION RevisionId { get; }

        public NVAPIGpuArchInfoDto(
            _NV_GPU_ARCHITECTURE_ID architectureId,
            _NV_GPU_ARCH_IMPLEMENTATION_ID implementationId,
            _NV_GPU_CHIP_REVISION revisionId)
        {
            ArchitectureId = architectureId;
            ImplementationId = implementationId;
            RevisionId = revisionId;
        }

        public static NVAPIGpuArchInfoDto FromNative(NV_GPU_ARCH_INFO_V2 native)
        {
            return new NVAPIGpuArchInfoDto(native.architecture_id, native.implementation_id, native.revision_id);
        }

        public NV_GPU_ARCH_INFO_V2 ToNative()
        {
            var native = new NV_GPU_ARCH_INFO_V2 { version = NVAPI.NV_GPU_ARCH_INFO_VER };
            native.architecture_id = ArchitectureId;
            native.implementation_id = ImplementationId;
            native.revision_id = RevisionId;
            return native;
        }

        public bool Equals(NVAPIGpuArchInfoDto other)
        {
            return ArchitectureId == other.ArchitectureId
                && ImplementationId == other.ImplementationId
                && RevisionId == other.RevisionId;
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuArchInfoDto other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(ArchitectureId, ImplementationId, RevisionId);
        public static bool operator ==(NVAPIGpuArchInfoDto left, NVAPIGpuArchInfoDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuArchInfoDto left, NVAPIGpuArchInfoDto right) => !left.Equals(right);
    }

    /// <summary>
    /// GPU board info DTO.
    /// </summary>
    public readonly struct NVAPIGpuBoardInfoDto : IEquatable<NVAPIGpuBoardInfoDto>
    {
        public string BoardNumber { get; }
        public byte[] BoardNumberRaw { get; }

        public NVAPIGpuBoardInfoDto(byte[] boardNumberRaw, string boardNumber)
        {
            BoardNumberRaw = boardNumberRaw ?? Array.Empty<byte>();
            BoardNumber = boardNumber ?? string.Empty;
        }

        public static NVAPIGpuBoardInfoDto FromNative(_NV_BOARD_INFO native)
        {
            var data = new byte[16];
            var span = MemoryMarshal.CreateSpan(ref native.BoardNum.e0, data.Length);
            span.CopyTo(data);

            var end = Array.IndexOf(data, (byte)0);
            var length = end >= 0 ? end : data.Length;
            var text = System.Text.Encoding.ASCII.GetString(data, 0, length);
            return new NVAPIGpuBoardInfoDto(data, text);
        }

        public _NV_BOARD_INFO ToNative()
        {
            var native = new _NV_BOARD_INFO { version = NVAPI.NV_BOARD_INFO_VER };
            var span = MemoryMarshal.CreateSpan(ref native.BoardNum.e0, 16);
            span.Clear();

            var data = BoardNumberRaw ?? Array.Empty<byte>();
            data.AsSpan(0, Math.Min(data.Length, span.Length)).CopyTo(span);
            return native;
        }

        public bool Equals(NVAPIGpuBoardInfoDto other)
        {
            return string.Equals(BoardNumber, other.BoardNumber, StringComparison.Ordinal)
                && NVAPIGpuDtoHelpers.SequenceEquals(BoardNumberRaw, other.BoardNumberRaw);
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuBoardInfoDto other && Equals(other);
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = StringComparer.Ordinal.GetHashCode(BoardNumber);
                hash = (hash * 31) + NVAPIGpuDtoHelpers.SequenceHashCode(BoardNumberRaw);
                return hash;
            }
        }

        public static bool operator ==(NVAPIGpuBoardInfoDto left, NVAPIGpuBoardInfoDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuBoardInfoDto left, NVAPIGpuBoardInfoDto right) => !left.Equals(right);
    }

    /// <summary>
    /// ECC configuration info DTO.
    /// </summary>
    public readonly struct NVAPIGpuEccConfigurationInfoDto : IEquatable<NVAPIGpuEccConfigurationInfoDto>
    {
        public bool IsEnabled { get; }
        public bool IsEnabledByDefault { get; }

        public NVAPIGpuEccConfigurationInfoDto(bool isEnabled, bool isEnabledByDefault)
        {
            IsEnabled = isEnabled;
            IsEnabledByDefault = isEnabledByDefault;
        }

        public static NVAPIGpuEccConfigurationInfoDto FromNative(NV_GPU_ECC_CONFIGURATION_INFO native)
        {
            return new NVAPIGpuEccConfigurationInfoDto(native.isEnabled != 0, native.isEnabledByDefault != 0);
        }

        public NV_GPU_ECC_CONFIGURATION_INFO ToNative()
        {
            return new NV_GPU_ECC_CONFIGURATION_INFO
            {
                version = NVAPI.NV_GPU_ECC_CONFIGURATION_INFO_VER,
                isEnabled = IsEnabled ? 1u : 0u,
                isEnabledByDefault = IsEnabledByDefault ? 1u : 0u
            };
        }

        public bool Equals(NVAPIGpuEccConfigurationInfoDto other)
        {
            return IsEnabled == other.IsEnabled && IsEnabledByDefault == other.IsEnabledByDefault;
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuEccConfigurationInfoDto other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(IsEnabled, IsEnabledByDefault);
        public static bool operator ==(NVAPIGpuEccConfigurationInfoDto left, NVAPIGpuEccConfigurationInfoDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuEccConfigurationInfoDto left, NVAPIGpuEccConfigurationInfoDto right) => !left.Equals(right);
    }

    /// <summary>
    /// ECC error info DTO.
    /// </summary>
    public readonly struct NVAPIGpuEccErrorInfoDto : IEquatable<NVAPIGpuEccErrorInfoDto>
    {
        public ulong CurrentSingleBitErrors { get; }
        public ulong CurrentDoubleBitErrors { get; }
        public ulong AggregateSingleBitErrors { get; }
        public ulong AggregateDoubleBitErrors { get; }

        public NVAPIGpuEccErrorInfoDto(
            ulong currentSingleBitErrors,
            ulong currentDoubleBitErrors,
            ulong aggregateSingleBitErrors,
            ulong aggregateDoubleBitErrors)
        {
            CurrentSingleBitErrors = currentSingleBitErrors;
            CurrentDoubleBitErrors = currentDoubleBitErrors;
            AggregateSingleBitErrors = aggregateSingleBitErrors;
            AggregateDoubleBitErrors = aggregateDoubleBitErrors;
        }

        public static NVAPIGpuEccErrorInfoDto FromNative(NV_GPU_ECC_ERROR_INFO native)
        {
            return new NVAPIGpuEccErrorInfoDto(
                native.current.singleBitErrors,
                native.current.doubleBitErrors,
                native.aggregate.singleBitErrors,
                native.aggregate.doubleBitErrors);
        }

        public NV_GPU_ECC_ERROR_INFO ToNative()
        {
            return new NV_GPU_ECC_ERROR_INFO
            {
                version = NVAPI.NV_GPU_ECC_ERROR_INFO_VER,
                current = new NV_GPU_ECC_ERROR_INFO._current_e__Struct
                {
                    singleBitErrors = CurrentSingleBitErrors,
                    doubleBitErrors = CurrentDoubleBitErrors
                },
                aggregate = new NV_GPU_ECC_ERROR_INFO._aggregate_e__Struct
                {
                    singleBitErrors = AggregateSingleBitErrors,
                    doubleBitErrors = AggregateDoubleBitErrors
                }
            };
        }

        public bool Equals(NVAPIGpuEccErrorInfoDto other)
        {
            return CurrentSingleBitErrors == other.CurrentSingleBitErrors
                && CurrentDoubleBitErrors == other.CurrentDoubleBitErrors
                && AggregateSingleBitErrors == other.AggregateSingleBitErrors
                && AggregateDoubleBitErrors == other.AggregateDoubleBitErrors;
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuEccErrorInfoDto other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(CurrentSingleBitErrors, CurrentDoubleBitErrors, AggregateSingleBitErrors, AggregateDoubleBitErrors);
        public static bool operator ==(NVAPIGpuEccErrorInfoDto left, NVAPIGpuEccErrorInfoDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuEccErrorInfoDto left, NVAPIGpuEccErrorInfoDto right) => !left.Equals(right);
    }

    /// <summary>
    /// HDCP support status DTO.
    /// </summary>
    public readonly struct NVAPIGpuHdcpSupportStatusDto : IEquatable<NVAPIGpuHdcpSupportStatusDto>
    {
        public _NV_GPU_HDCP_FUSE_STATE HdcpFuseState { get; }
        public _NV_GPU_HDCP_KEY_SOURCE HdcpKeySource { get; }
        public _NV_GPU_HDCP_KEY_SOURCE_STATE HdcpKeySourceState { get; }

        public NVAPIGpuHdcpSupportStatusDto(
            _NV_GPU_HDCP_FUSE_STATE hdcpFuseState,
            _NV_GPU_HDCP_KEY_SOURCE hdcpKeySource,
            _NV_GPU_HDCP_KEY_SOURCE_STATE hdcpKeySourceState)
        {
            HdcpFuseState = hdcpFuseState;
            HdcpKeySource = hdcpKeySource;
            HdcpKeySourceState = hdcpKeySourceState;
        }

        public static NVAPIGpuHdcpSupportStatusDto FromNative(NV_GPU_GET_HDCP_SUPPORT_STATUS native)
        {
            return new NVAPIGpuHdcpSupportStatusDto(native.hdcpFuseState, native.hdcpKeySource, native.hdcpKeySourceState);
        }

        public NV_GPU_GET_HDCP_SUPPORT_STATUS ToNative()
        {
            return new NV_GPU_GET_HDCP_SUPPORT_STATUS
            {
                version = NVAPI.NV_GPU_GET_HDCP_SUPPORT_STATUS_VER,
                hdcpFuseState = HdcpFuseState,
                hdcpKeySource = HdcpKeySource,
                hdcpKeySourceState = HdcpKeySourceState
            };
        }

        public bool Equals(NVAPIGpuHdcpSupportStatusDto other)
        {
            return HdcpFuseState == other.HdcpFuseState
                && HdcpKeySource == other.HdcpKeySource
                && HdcpKeySourceState == other.HdcpKeySourceState;
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuHdcpSupportStatusDto other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(HdcpFuseState, HdcpKeySource, HdcpKeySourceState);
        public static bool operator ==(NVAPIGpuHdcpSupportStatusDto left, NVAPIGpuHdcpSupportStatusDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuHdcpSupportStatusDto left, NVAPIGpuHdcpSupportStatusDto right) => !left.Equals(right);
    }

    /// <summary>
    /// GPU EDID data DTO.
    /// </summary>
    public readonly struct NVAPIGpuEdidDto : IEquatable<NVAPIGpuEdidDto>
    {
        public byte[] Data { get; }
        public uint SizeOfEdid { get; }
        public uint EdidId { get; }
        public uint Offset { get; }

        public NVAPIGpuEdidDto(byte[] data, uint sizeOfEdid, uint edidId, uint offset)
        {
            Data = data ?? Array.Empty<byte>();
            SizeOfEdid = sizeOfEdid;
            EdidId = edidId;
            Offset = offset;
        }

        public static NVAPIGpuEdidDto FromNative(NV_EDID_V3 native)
        {
            var max = Math.Min((int)native.sizeofEDID, NVAPI.NV_EDID_DATA_SIZE);
            var data = new byte[max];
            if (max > 0)
            {
                var span = MemoryMarshal.CreateSpan(ref native.EDID_Data.e0, NVAPI.NV_EDID_DATA_SIZE);
                span.Slice(0, max).CopyTo(data);
            }

            return new NVAPIGpuEdidDto(data, native.sizeofEDID, native.edidId, native.offset);
        }

        public NV_EDID_V3 ToNative()
        {
            var native = new NV_EDID_V3
            {
                version = NVAPI.NV_EDID_VER,
                sizeofEDID = SizeOfEdid == 0 ? (uint)(Data?.Length ?? 0) : SizeOfEdid,
                edidId = EdidId,
                offset = Offset
            };

            var span = MemoryMarshal.CreateSpan(ref native.EDID_Data.e0, NVAPI.NV_EDID_DATA_SIZE);
            span.Clear();

            var data = Data ?? Array.Empty<byte>();
            data.AsSpan(0, Math.Min(data.Length, span.Length)).CopyTo(span);
            return native;
        }

        public bool Equals(NVAPIGpuEdidDto other)
        {
            return SizeOfEdid == other.SizeOfEdid
                && EdidId == other.EdidId
                && Offset == other.Offset
                && NVAPIGpuDtoHelpers.SequenceEquals(Data, other.Data);
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuEdidDto other && Equals(other);
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = SizeOfEdid.GetHashCode();
                hash = (hash * 31) + EdidId.GetHashCode();
                hash = (hash * 31) + Offset.GetHashCode();
                hash = (hash * 31) + NVAPIGpuDtoHelpers.SequenceHashCode(Data);
                return hash;
            }
        }

        public static bool operator ==(NVAPIGpuEdidDto left, NVAPIGpuEdidDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuEdidDto left, NVAPIGpuEdidDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Logical GPU info DTO.
    /// </summary>
    public readonly struct NVAPILogicalGpuInfoDto : IEquatable<NVAPILogicalGpuInfoDto>
    {
        internal IntPtr[] PhysicalGpuHandles { get; }
        public NVAPIPhysicalGpuHelper[] PhysicalGpus { get; }
        public uint PhysicalGpuCount { get; }
        public _LUID? OsAdapterId { get; }
        public uint[] Reserved { get; }

        private NVAPILogicalGpuInfoDto(_LUID? osAdapterId, IntPtr[] handles, NVAPIPhysicalGpuHelper[] gpus, uint[] reserved)
        {
            OsAdapterId = osAdapterId;
            PhysicalGpuHandles = handles ?? Array.Empty<IntPtr>();
            PhysicalGpus = gpus ?? Array.Empty<NVAPIPhysicalGpuHelper>();
            PhysicalGpuCount = (uint)PhysicalGpuHandles.Length;
            Reserved = reserved ?? Array.Empty<uint>();
        }

        public static unsafe NVAPILogicalGpuInfoDto FromNative(NVAPIApiHelper apiHelper, _NV_LOGICAL_GPU_DATA_V1 native)
        {
            _LUID? luid = null;
            if (native.pOSAdapterId != null)
            {
                luid = *(_LUID*)native.pOSAdapterId;
            }

            var count = (int)Math.Min(native.physicalGpuCount, NVAPI.NVAPI_MAX_PHYSICAL_GPUS);
            var handles = new IntPtr[count];
            var gpus = new NVAPIPhysicalGpuHelper[count];
            for (var i = 0; i < count; i++)
            {
                var handle = native.physicalGpuHandles[i];
                handles[i] = (IntPtr)handle;
                gpus[i] = new NVAPIPhysicalGpuHelper(apiHelper, handles[i]);
            }

            var reserved = new uint[8];
            var reservedSpan = MemoryMarshal.CreateSpan(ref native.reserved.e0, reserved.Length);
            reservedSpan.CopyTo(reserved);

            return new NVAPILogicalGpuInfoDto(luid, handles, gpus, reserved);
        }

        public bool Equals(NVAPILogicalGpuInfoDto other)
        {
            var luidEquals = OsAdapterId.HasValue == other.OsAdapterId.HasValue;
            if (luidEquals && OsAdapterId.HasValue && other.OsAdapterId.HasValue)
            {
                var left = OsAdapterId.Value;
                var right = other.OsAdapterId.Value;
                luidEquals = left.LowPart == right.LowPart && left.HighPart == right.HighPart;
            }

            return luidEquals
                && NVAPIGpuDtoHelpers.SequenceEquals(PhysicalGpuHandles, other.PhysicalGpuHandles)
                && NVAPIGpuDtoHelpers.SequenceEquals(Reserved, other.Reserved);
        }

        public override bool Equals(object? obj) => obj is NVAPILogicalGpuInfoDto other && Equals(other);
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = OsAdapterId?.GetHashCode() ?? 0;
                hash = (hash * 31) + NVAPIGpuDtoHelpers.SequenceHashCode(PhysicalGpuHandles);
                hash = (hash * 31) + NVAPIGpuDtoHelpers.SequenceHashCode(Reserved);
                return hash;
            }
        }

        public static bool operator ==(NVAPILogicalGpuInfoDto left, NVAPILogicalGpuInfoDto right) => left.Equals(right);
        public static bool operator !=(NVAPILogicalGpuInfoDto left, NVAPILogicalGpuInfoDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for NvSBox values.
    /// </summary>
    public readonly struct NVAPISBoxDto : IEquatable<NVAPISBoxDto>
    {
        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }

        public NVAPISBoxDto(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public static NVAPISBoxDto FromNative(NvSBox native)
        {
            return new NVAPISBoxDto(native.sX, native.sY, native.sWidth, native.sHeight);
        }

        public NvSBox ToNative()
        {
            return new NvSBox
            {
                sX = X,
                sY = Y,
                sWidth = Width,
                sHeight = Height
            };
        }

        public bool Equals(NVAPISBoxDto other)
        {
            return X == other.X && Y == other.Y && Width == other.Width && Height == other.Height;
        }

        public override bool Equals(object? obj) => obj is NVAPISBoxDto other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(X, Y, Width, Height);
        public static bool operator ==(NVAPISBoxDto left, NVAPISBoxDto right) => left.Equals(right);
        public static bool operator !=(NVAPISBoxDto left, NVAPISBoxDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Scanout configuration DTO.
    /// </summary>
    public readonly struct NVAPIGpuScanoutConfigurationDto : IEquatable<NVAPIGpuScanoutConfigurationDto>
    {
        public NVAPISBoxDto DesktopRect { get; }
        public NVAPISBoxDto ScanoutRect { get; }

        public NVAPIGpuScanoutConfigurationDto(NVAPISBoxDto desktopRect, NVAPISBoxDto scanoutRect)
        {
            DesktopRect = desktopRect;
            ScanoutRect = scanoutRect;
        }

        public static NVAPIGpuScanoutConfigurationDto FromNative(NvSBox desktopRect, NvSBox scanoutRect)
        {
            return new NVAPIGpuScanoutConfigurationDto(
                NVAPISBoxDto.FromNative(desktopRect),
                NVAPISBoxDto.FromNative(scanoutRect));
        }

        public bool Equals(NVAPIGpuScanoutConfigurationDto other)
        {
            return DesktopRect.Equals(other.DesktopRect) && ScanoutRect.Equals(other.ScanoutRect);
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuScanoutConfigurationDto other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(DesktopRect, ScanoutRect);
        public static bool operator ==(NVAPIGpuScanoutConfigurationDto left, NVAPIGpuScanoutConfigurationDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuScanoutConfigurationDto left, NVAPIGpuScanoutConfigurationDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Extended scanout configuration DTO.
    /// </summary>
    public readonly struct NVAPIGpuScanoutConfigurationExDto : IEquatable<NVAPIGpuScanoutConfigurationExDto>
    {
        public NVAPISBoxDto SourceDesktopRect { get; }
        public NVAPISBoxDto SourceViewportRect { get; }
        public NVAPISBoxDto TargetViewportRect { get; }
        public uint TargetDisplayWidth { get; }
        public uint TargetDisplayHeight { get; }
        public uint CloneImportance { get; }
        public _NV_ROTATE SourceToTargetRotation { get; }

        public NVAPIGpuScanoutConfigurationExDto(
            NVAPISBoxDto sourceDesktopRect,
            NVAPISBoxDto sourceViewportRect,
            NVAPISBoxDto targetViewportRect,
            uint targetDisplayWidth,
            uint targetDisplayHeight,
            uint cloneImportance,
            _NV_ROTATE sourceToTargetRotation)
        {
            SourceDesktopRect = sourceDesktopRect;
            SourceViewportRect = sourceViewportRect;
            TargetViewportRect = targetViewportRect;
            TargetDisplayWidth = targetDisplayWidth;
            TargetDisplayHeight = targetDisplayHeight;
            CloneImportance = cloneImportance;
            SourceToTargetRotation = sourceToTargetRotation;
        }

        public static NVAPIGpuScanoutConfigurationExDto FromNative(_NV_SCANOUT_INFORMATION native)
        {
            return new NVAPIGpuScanoutConfigurationExDto(
                NVAPISBoxDto.FromNative(native.sourceDesktopRect),
                NVAPISBoxDto.FromNative(native.sourceViewportRect),
                NVAPISBoxDto.FromNative(native.targetViewportRect),
                native.targetDisplayWidth,
                native.targetDisplayHeight,
                native.cloneImportance,
                native.sourceToTargetRotation);
        }

        public _NV_SCANOUT_INFORMATION ToNative()
        {
            return new _NV_SCANOUT_INFORMATION
            {
                version = NVAPI.NV_SCANOUT_INFORMATION_VER,
                sourceDesktopRect = SourceDesktopRect.ToNative(),
                sourceViewportRect = SourceViewportRect.ToNative(),
                targetViewportRect = TargetViewportRect.ToNative(),
                targetDisplayWidth = TargetDisplayWidth,
                targetDisplayHeight = TargetDisplayHeight,
                cloneImportance = CloneImportance,
                sourceToTargetRotation = SourceToTargetRotation
            };
        }

        public bool Equals(NVAPIGpuScanoutConfigurationExDto other)
        {
            return SourceDesktopRect.Equals(other.SourceDesktopRect)
                && SourceViewportRect.Equals(other.SourceViewportRect)
                && TargetViewportRect.Equals(other.TargetViewportRect)
                && TargetDisplayWidth == other.TargetDisplayWidth
                && TargetDisplayHeight == other.TargetDisplayHeight
                && CloneImportance == other.CloneImportance
                && SourceToTargetRotation == other.SourceToTargetRotation;
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuScanoutConfigurationExDto other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(SourceDesktopRect, SourceViewportRect, TargetViewportRect, TargetDisplayWidth, TargetDisplayHeight, CloneImportance, SourceToTargetRotation);
        public static bool operator ==(NVAPIGpuScanoutConfigurationExDto left, NVAPIGpuScanoutConfigurationExDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuScanoutConfigurationExDto left, NVAPIGpuScanoutConfigurationExDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Scanout composition parameter DTO.
    /// </summary>
    public readonly struct NVAPIGpuScanoutCompositionParameterDto : IEquatable<NVAPIGpuScanoutCompositionParameterDto>
    {
        public NV_GPU_SCANOUT_COMPOSITION_PARAMETER Parameter { get; }
        public NV_GPU_SCANOUT_COMPOSITION_PARAMETER_VALUE Value { get; }
        public float Container { get; }

        public NVAPIGpuScanoutCompositionParameterDto(
            NV_GPU_SCANOUT_COMPOSITION_PARAMETER parameter,
            NV_GPU_SCANOUT_COMPOSITION_PARAMETER_VALUE value,
            float container)
        {
            Parameter = parameter;
            Value = value;
            Container = container;
        }

        public bool Equals(NVAPIGpuScanoutCompositionParameterDto other)
        {
            return Parameter == other.Parameter && Value == other.Value && Container.Equals(other.Container);
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuScanoutCompositionParameterDto other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(Parameter, Value, Container);
        public static bool operator ==(NVAPIGpuScanoutCompositionParameterDto left, NVAPIGpuScanoutCompositionParameterDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuScanoutCompositionParameterDto left, NVAPIGpuScanoutCompositionParameterDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Scanout intensity state DTO.
    /// </summary>
    public readonly struct NVAPIGpuScanoutIntensityStateDto : IEquatable<NVAPIGpuScanoutIntensityStateDto>
    {
        public bool IsEnabled { get; }

        public NVAPIGpuScanoutIntensityStateDto(bool isEnabled)
        {
            IsEnabled = isEnabled;
        }

        public static NVAPIGpuScanoutIntensityStateDto FromNative(_NV_SCANOUT_INTENSITY_STATE_DATA native)
        {
            return new NVAPIGpuScanoutIntensityStateDto(native.bEnabled != 0);
        }

        public _NV_SCANOUT_INTENSITY_STATE_DATA ToNative()
        {
            return new _NV_SCANOUT_INTENSITY_STATE_DATA
            {
                version = NVAPI.NV_SCANOUT_INTENSITY_STATE_VER,
                bEnabled = IsEnabled ? 1u : 0u
            };
        }

        public bool Equals(NVAPIGpuScanoutIntensityStateDto other)
        {
            return IsEnabled == other.IsEnabled;
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuScanoutIntensityStateDto other && Equals(other);
        public override int GetHashCode() => IsEnabled.GetHashCode();
        public static bool operator ==(NVAPIGpuScanoutIntensityStateDto left, NVAPIGpuScanoutIntensityStateDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuScanoutIntensityStateDto left, NVAPIGpuScanoutIntensityStateDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Scanout intensity data DTO.
    /// </summary>
    public readonly struct NVAPIGpuScanoutIntensityDataDto : IEquatable<NVAPIGpuScanoutIntensityDataDto>
    {
        public uint Width { get; }
        public uint Height { get; }
        public float[] BlendingTexture { get; }
        public float[] OffsetTexture { get; }
        public uint OffsetTexChannels { get; }

        public NVAPIGpuScanoutIntensityDataDto(
            uint width,
            uint height,
            float[] blendingTexture,
            float[] offsetTexture,
            uint offsetTexChannels)
        {
            Width = width;
            Height = height;
            BlendingTexture = blendingTexture ?? Array.Empty<float>();
            OffsetTexture = offsetTexture ?? Array.Empty<float>();
            OffsetTexChannels = offsetTexChannels;
        }

        public NV_SCANOUT_INTENSITY_DATA_V2 ToNative()
        {
            return new NV_SCANOUT_INTENSITY_DATA_V2
            {
                version = NVAPI.NV_SCANOUT_INTENSITY_DATA_VER,
                width = Width,
                height = Height,
                blendingTexture = null,
                offsetTexture = null,
                offsetTexChannels = OffsetTexChannels
            };
        }

        public bool Equals(NVAPIGpuScanoutIntensityDataDto other)
        {
            return Width == other.Width
                && Height == other.Height
                && OffsetTexChannels == other.OffsetTexChannels
                && NVAPIGpuDtoHelpers.SequenceEquals(BlendingTexture, other.BlendingTexture)
                && NVAPIGpuDtoHelpers.SequenceEquals(OffsetTexture, other.OffsetTexture);
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuScanoutIntensityDataDto other && Equals(other);
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = Width.GetHashCode();
                hash = (hash * 31) + Height.GetHashCode();
                hash = (hash * 31) + OffsetTexChannels.GetHashCode();
                hash = (hash * 31) + NVAPIGpuDtoHelpers.SequenceHashCode(BlendingTexture);
                hash = (hash * 31) + NVAPIGpuDtoHelpers.SequenceHashCode(OffsetTexture);
                return hash;
            }
        }

        public static bool operator ==(NVAPIGpuScanoutIntensityDataDto left, NVAPIGpuScanoutIntensityDataDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuScanoutIntensityDataDto left, NVAPIGpuScanoutIntensityDataDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Scanout intensity result DTO.
    /// </summary>
    public readonly struct NVAPIGpuScanoutIntensityResultDto : IEquatable<NVAPIGpuScanoutIntensityResultDto>
    {
        public bool IsSticky { get; }

        public NVAPIGpuScanoutIntensityResultDto(bool isSticky)
        {
            IsSticky = isSticky;
        }

        public bool Equals(NVAPIGpuScanoutIntensityResultDto other)
        {
            return IsSticky == other.IsSticky;
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuScanoutIntensityResultDto other && Equals(other);
        public override int GetHashCode() => IsSticky.GetHashCode();
        public static bool operator ==(NVAPIGpuScanoutIntensityResultDto left, NVAPIGpuScanoutIntensityResultDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuScanoutIntensityResultDto left, NVAPIGpuScanoutIntensityResultDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Scanout warping state DTO.
    /// </summary>
    public readonly struct NVAPIGpuScanoutWarpingStateDto : IEquatable<NVAPIGpuScanoutWarpingStateDto>
    {
        public bool IsEnabled { get; }

        public NVAPIGpuScanoutWarpingStateDto(bool isEnabled)
        {
            IsEnabled = isEnabled;
        }

        public static NVAPIGpuScanoutWarpingStateDto FromNative(_NV_SCANOUT_WARPING_STATE_DATA native)
        {
            return new NVAPIGpuScanoutWarpingStateDto(native.bEnabled != 0);
        }

        public _NV_SCANOUT_WARPING_STATE_DATA ToNative()
        {
            return new _NV_SCANOUT_WARPING_STATE_DATA
            {
                version = NVAPI.NV_SCANOUT_WARPING_STATE_VER,
                bEnabled = IsEnabled ? 1u : 0u
            };
        }

        public bool Equals(NVAPIGpuScanoutWarpingStateDto other)
        {
            return IsEnabled == other.IsEnabled;
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuScanoutWarpingStateDto other && Equals(other);
        public override int GetHashCode() => IsEnabled.GetHashCode();
        public static bool operator ==(NVAPIGpuScanoutWarpingStateDto left, NVAPIGpuScanoutWarpingStateDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuScanoutWarpingStateDto left, NVAPIGpuScanoutWarpingStateDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Scanout warping data DTO.
    /// </summary>
    public readonly struct NVAPIGpuScanoutWarpingDataDto : IEquatable<NVAPIGpuScanoutWarpingDataDto>
    {
        public float[] Vertices { get; }
        public NV_GPU_WARPING_VERTICE_FORMAT VertexFormat { get; }
        public int NumVertices { get; }
        public NVAPISBoxDto? TextureRect { get; }

        public NVAPIGpuScanoutWarpingDataDto(
            float[] vertices,
            NV_GPU_WARPING_VERTICE_FORMAT vertexFormat,
            int numVertices,
            NVAPISBoxDto? textureRect)
        {
            Vertices = vertices ?? Array.Empty<float>();
            VertexFormat = vertexFormat;
            NumVertices = numVertices;
            TextureRect = textureRect;
        }

        public NV_SCANOUT_WARPING_DATA ToNative()
        {
            return new NV_SCANOUT_WARPING_DATA
            {
                version = NVAPI.NV_SCANOUT_WARPING_VER,
                vertices = null,
                vertexFormat = VertexFormat,
                numVertices = NumVertices,
                textureRect = null
            };
        }

        public bool Equals(NVAPIGpuScanoutWarpingDataDto other)
        {
            return VertexFormat == other.VertexFormat
                && NumVertices == other.NumVertices
                && Nullable.Equals(TextureRect, other.TextureRect)
                && NVAPIGpuDtoHelpers.SequenceEquals(Vertices, other.Vertices);
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuScanoutWarpingDataDto other && Equals(other);
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = VertexFormat.GetHashCode();
                hash = (hash * 31) + NumVertices.GetHashCode();
                hash = (hash * 31) + (TextureRect?.GetHashCode() ?? 0);
                hash = (hash * 31) + NVAPIGpuDtoHelpers.SequenceHashCode(Vertices);
                return hash;
            }
        }

        public static bool operator ==(NVAPIGpuScanoutWarpingDataDto left, NVAPIGpuScanoutWarpingDataDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuScanoutWarpingDataDto left, NVAPIGpuScanoutWarpingDataDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Scanout warping result DTO.
    /// </summary>
    public readonly struct NVAPIGpuScanoutWarpingResultDto : IEquatable<NVAPIGpuScanoutWarpingResultDto>
    {
        public int MaxNumVertices { get; }
        public bool IsSticky { get; }

        public NVAPIGpuScanoutWarpingResultDto(int maxNumVertices, bool isSticky)
        {
            MaxNumVertices = maxNumVertices;
            IsSticky = isSticky;
        }

        public bool Equals(NVAPIGpuScanoutWarpingResultDto other)
        {
            return MaxNumVertices == other.MaxNumVertices && IsSticky == other.IsSticky;
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuScanoutWarpingResultDto other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(MaxNumVertices, IsSticky);
        public static bool operator ==(NVAPIGpuScanoutWarpingResultDto left, NVAPIGpuScanoutWarpingResultDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuScanoutWarpingResultDto left, NVAPIGpuScanoutWarpingResultDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Workstation feature query DTO.
    /// </summary>
    public readonly struct NVAPIGpuWorkstationFeatureQueryDto : IEquatable<NVAPIGpuWorkstationFeatureQueryDto>
    {
        public uint ConfiguredFeatureMask { get; }
        public uint ConsistentFeatureMask { get; }

        public NVAPIGpuWorkstationFeatureQueryDto(uint configuredFeatureMask, uint consistentFeatureMask)
        {
            ConfiguredFeatureMask = configuredFeatureMask;
            ConsistentFeatureMask = consistentFeatureMask;
        }

        public bool Equals(NVAPIGpuWorkstationFeatureQueryDto other)
        {
            return ConfiguredFeatureMask == other.ConfiguredFeatureMask
                && ConsistentFeatureMask == other.ConsistentFeatureMask;
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuWorkstationFeatureQueryDto other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(ConfiguredFeatureMask, ConsistentFeatureMask);
        public static bool operator ==(NVAPIGpuWorkstationFeatureQueryDto left, NVAPIGpuWorkstationFeatureQueryDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuWorkstationFeatureQueryDto left, NVAPIGpuWorkstationFeatureQueryDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Utilization sample callback settings DTO.
    /// </summary>
    public readonly struct NVAPIGpuUtilizationSampleCallbackSettingsDto : IEquatable<NVAPIGpuUtilizationSampleCallbackSettingsDto>
    {
        public IntPtr CallbackParam { get; }
        public uint CallbackPeriodMs { get; }
        public IntPtr Callback { get; }
        public byte[] SuperReserved { get; }
        public byte[] PeriodicReserved { get; }
        public byte[] Reserved { get; }

        public NVAPIGpuUtilizationSampleCallbackSettingsDto(
            IntPtr callbackParam,
            uint callbackPeriodMs,
            IntPtr callback,
            byte[] superReserved,
            byte[] periodicReserved,
            byte[] reserved)
        {
            CallbackParam = callbackParam;
            CallbackPeriodMs = callbackPeriodMs;
            Callback = callback;
            SuperReserved = superReserved ?? Array.Empty<byte>();
            PeriodicReserved = periodicReserved ?? Array.Empty<byte>();
            Reserved = reserved ?? Array.Empty<byte>();
        }

        public unsafe _NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS_V1 ToNative()
        {
            var native = new _NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS_V1
            {
                version = NVAPI.NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS_VER,
                super = new _NV_GPU_CLIENT_PERIODIC_CALLBACK_SETTINGS_SUPER_V1
                {
                    super = new _NV_CLIENT_CALLBACK_SETTINGS_SUPER_V1
                    {
                        pCallbackParam = (void*)CallbackParam
                    },
                    callbackPeriodms = CallbackPeriodMs
                },
                callback = (delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, _NV_GPU_CLIENT_CALLBACK_UTILIZATION_DATA_V1*, void>)Callback
            };

            var superReserved = SuperReserved ?? Array.Empty<byte>();
            var superSpan = MemoryMarshal.CreateSpan(ref native.super.super.rsvd.e0, 64);
            superSpan.Clear();
            superReserved.AsSpan(0, Math.Min(superReserved.Length, superSpan.Length)).CopyTo(superSpan);

            var periodicReserved = PeriodicReserved ?? Array.Empty<byte>();
            var periodicSpan = MemoryMarshal.CreateSpan(ref native.super.rsvd.e0, 64);
            periodicSpan.Clear();
            periodicReserved.AsSpan(0, Math.Min(periodicReserved.Length, periodicSpan.Length)).CopyTo(periodicSpan);

            var reserved = Reserved ?? Array.Empty<byte>();
            var reservedSpan = MemoryMarshal.CreateSpan(ref native.rsvd.e0, 64);
            reservedSpan.Clear();
            reserved.AsSpan(0, Math.Min(reserved.Length, reservedSpan.Length)).CopyTo(reservedSpan);

            return native;
        }

        public bool Equals(NVAPIGpuUtilizationSampleCallbackSettingsDto other)
        {
            return CallbackParam == other.CallbackParam
                && CallbackPeriodMs == other.CallbackPeriodMs
                && Callback == other.Callback
                && NVAPIGpuDtoHelpers.SequenceEquals(SuperReserved, other.SuperReserved)
                && NVAPIGpuDtoHelpers.SequenceEquals(PeriodicReserved, other.PeriodicReserved)
                && NVAPIGpuDtoHelpers.SequenceEquals(Reserved, other.Reserved);
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuUtilizationSampleCallbackSettingsDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = CallbackParam.GetHashCode();
                hash = (hash * 31) + CallbackPeriodMs.GetHashCode();
                hash = (hash * 31) + Callback.GetHashCode();
                hash = (hash * 31) + NVAPIGpuDtoHelpers.SequenceHashCode(SuperReserved);
                hash = (hash * 31) + NVAPIGpuDtoHelpers.SequenceHashCode(PeriodicReserved);
                hash = (hash * 31) + NVAPIGpuDtoHelpers.SequenceHashCode(Reserved);
                return hash;
            }
        }

        public static bool operator ==(NVAPIGpuUtilizationSampleCallbackSettingsDto left, NVAPIGpuUtilizationSampleCallbackSettingsDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuUtilizationSampleCallbackSettingsDto left, NVAPIGpuUtilizationSampleCallbackSettingsDto right) => !left.Equals(right);
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
