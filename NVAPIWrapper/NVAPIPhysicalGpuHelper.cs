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

        private static NV_DISPLAY_DRIVER_MEMORY_INFO_V3 CreateDisplayDriverMemoryInfo()
        {
            return new NV_DISPLAY_DRIVER_MEMORY_INFO_V3 { version = NVAPI.NV_DISPLAY_DRIVER_MEMORY_INFO_VER };
        }

        private static NV_GPU_MEMORY_INFO_EX_V1 CreateGpuMemoryInfoEx()
        {
            return new NV_GPU_MEMORY_INFO_EX_V1 { version = NVAPI.NV_GPU_MEMORY_INFO_EX_VER };
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
}
