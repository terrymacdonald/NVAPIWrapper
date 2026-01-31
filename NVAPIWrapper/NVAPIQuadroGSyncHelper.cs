using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <summary>
    /// Facade helper for Quadro G-Sync (frame lock) devices.
    /// </summary>
    public sealed class NVAPIQuadroGSyncHelper : IDisposable
    {
        private const uint NvApiIdGSyncQueryCapabilities = 0x44A3F1D1;
        private const uint NvApiIdGSyncGetTopology = 0x4562BC38;
        private const uint NvApiIdGSyncSetSyncStateSettings = 0x60ACDFDD;
        private const uint NvApiIdGSyncGetControlParameters = 0x16DE1C6A;
        private const uint NvApiIdGSyncSetControlParameters = 0x8BBFF88B;
        private const uint NvApiIdGSyncAdjustSyncDelay = 0x2D11FF51;
        private const uint NvApiIdGSyncGetSyncStatus = 0xF1F5B434;
        private const uint NvApiIdGSyncGetStatusParameters = 0x70D404EC;

        private readonly NVAPIApiHelper _apiHelper;
        private readonly IntPtr _handle;
        private bool _disposed;

        internal NVAPIQuadroGSyncHelper(NVAPIApiHelper apiHelper, IntPtr handle)
        {
            _apiHelper = apiHelper;
            _handle = handle;
        }

        internal IntPtr Handle => _handle;

        /// <summary>
        /// Create a G-Sync capabilities struct with the version initialized.
        /// </summary>
        public static _NV_GSYNC_CAPABILITIES_V3 CreateCapabilities()
        {
            return new _NV_GSYNC_CAPABILITIES_V3
            {
                version = NVAPI.NV_GSYNC_CAPABILITIES_VER
            };
        }

        /// <summary>
        /// Create a G-Sync control parameters struct with the version initialized.
        /// </summary>
        public static _NV_GSYNC_CONTROL_PARAMS_V2 CreateControlParameters()
        {
            return new _NV_GSYNC_CONTROL_PARAMS_V2
            {
                version = NVAPI.NV_GSYNC_CONTROL_PARAMS_VER
            };
        }

        /// <summary>
        /// Create a G-Sync delay struct with the version initialized.
        /// </summary>
        public static _NV_GSYNC_DELAY CreateDelay()
        {
            return new _NV_GSYNC_DELAY
            {
                version = NVAPI.NV_GSYNC_DELAY_VER
            };
        }

        /// <summary>
        /// Create a G-Sync status struct with the version initialized.
        /// </summary>
        public static _NV_GSYNC_STATUS CreateSyncStatus()
        {
            return new _NV_GSYNC_STATUS
            {
                version = NVAPI.NV_GSYNC_STATUS_VER
            };
        }

        /// <summary>
        /// Create a G-Sync status parameters struct with the version initialized.
        /// </summary>
        public static _NV_GSYNC_STATUS_PARAMS_V2 CreateStatusParameters()
        {
            return new _NV_GSYNC_STATUS_PARAMS_V2
            {
                version = NVAPI.NV_GSYNC_STATUS_PARAMS_VER
            };
        }

        /// <summary>
        /// Create a G-Sync GPU topology struct with the version initialized.
        /// </summary>
        public static _NV_GSYNC_GPU CreateGSyncGpu()
        {
            return new _NV_GSYNC_GPU
            {
                version = NVAPI.NV_GSYNC_GPU_VER
            };
        }

        /// <summary>
        /// Create a G-Sync display topology struct with the version initialized.
        /// </summary>
        public static _NV_GSYNC_DISPLAY CreateGSyncDisplay()
        {
            return new _NV_GSYNC_DISPLAY
            {
                version = NVAPI.NV_GSYNC_DISPLAY_VER
            };
        }

        /// <summary>
        /// Query capabilities of this G-Sync device.
        /// </summary>
        /// <returns>Capabilities DTO, or null if unavailable.</returns>
        public unsafe NVAPIGSyncCapabilitiesDto? QueryCapabilities()
        {
            ThrowIfDisposed();

            var query = GetDelegate<NvApiGSyncQueryCapabilitiesDelegate>(
                NvApiIdGSyncQueryCapabilities,
                "NvAPI_GSync_QueryCapabilities");

            var caps = CreateCapabilities();
            var status = query((NvGSyncDeviceHandle__*)_handle, &caps);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGSyncCapabilitiesDto.FromNative(caps);

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Query the topology for this G-Sync device.
        /// </summary>
        /// <returns>Topology DTO, or null if unavailable.</returns>
        public unsafe NVAPIGSyncTopologyDto? GetTopology()
        {
            ThrowIfDisposed();

            var getTopology = GetDelegate<NvApiGSyncGetTopologyDelegate>(
                NvApiIdGSyncGetTopology,
                "NvAPI_GSync_GetTopology");

            uint gpuCount = 0;
            uint displayCount = 0;
            var status = getTopology((NvGSyncDeviceHandle__*)_handle, &gpuCount, null, &displayCount, null);
            if (status == _NvAPI_Status.NVAPI_OK)
            {
                var gpus = Array.Empty<NVAPIGSyncGpuDto>();
                var displays = Array.Empty<NVAPIGSyncDisplayDto>();

                if (gpuCount > 0)
                {
                    var nativeGpus = stackalloc _NV_GSYNC_GPU[(int)gpuCount];
                    for (var i = 0; i < gpuCount; i++)
                    {
                        nativeGpus[i] = CreateGSyncGpu();
                    }

                    if (displayCount > 0)
                    {
                        var nativeDisplays = stackalloc _NV_GSYNC_DISPLAY[(int)displayCount];
                        for (var i = 0; i < displayCount; i++)
                        {
                            nativeDisplays[i] = CreateGSyncDisplay();
                        }

                        status = getTopology((NvGSyncDeviceHandle__*)_handle, &gpuCount, nativeGpus, &displayCount, nativeDisplays);
                        if (status == _NvAPI_Status.NVAPI_OK)
                        {
                            gpus = NVAPIGSyncGpuDto.FromNative(_apiHelper, nativeGpus, (int)gpuCount);
                            displays = NVAPIGSyncDisplayDto.FromNative(nativeDisplays, (int)displayCount);
                            return new NVAPIGSyncTopologyDto(gpus, displays);
                        }
                    }
                    else
                    {
                        status = getTopology((NvGSyncDeviceHandle__*)_handle, &gpuCount, nativeGpus, null, null);
                        if (status == _NvAPI_Status.NVAPI_OK)
                        {
                            gpus = NVAPIGSyncGpuDto.FromNative(_apiHelper, nativeGpus, (int)gpuCount);
                            return new NVAPIGSyncTopologyDto(gpus, displays);
                        }
                    }
                }
                else if (displayCount > 0)
                {
                    var nativeDisplays = stackalloc _NV_GSYNC_DISPLAY[(int)displayCount];
                    for (var i = 0; i < displayCount; i++)
                    {
                        nativeDisplays[i] = CreateGSyncDisplay();
                    }

                    status = getTopology((NvGSyncDeviceHandle__*)_handle, null, null, &displayCount, nativeDisplays);
                    if (status == _NvAPI_Status.NVAPI_OK)
                    {
                        displays = NVAPIGSyncDisplayDto.FromNative(nativeDisplays, (int)displayCount);
                        return new NVAPIGSyncTopologyDto(gpus, displays);
                    }
                }
                else
                {
                    return new NVAPIGSyncTopologyDto(gpus, displays);
                }
            }

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get control parameters for this G-Sync device.
        /// </summary>
        /// <returns>Control parameters DTO, or null if unavailable.</returns>
        public unsafe NVAPIGSyncControlParametersDto? GetControlParameters()
        {
            ThrowIfDisposed();

            var getParams = GetDelegate<NvApiGSyncGetControlParametersDelegate>(
                NvApiIdGSyncGetControlParameters,
                "NvAPI_GSync_GetControlParameters");

            var parameters = CreateControlParameters();
            var status = getParams((NvGSyncDeviceHandle__*)_handle, &parameters);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGSyncControlParametersDto.FromNative(parameters);

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Set control parameters for this G-Sync device.
        /// </summary>
        /// <param name="parameters">Control parameters DTO.</param>
        /// <returns>True if applied, null if unsupported.</returns>
        public unsafe bool? SetControlParameters(NVAPIGSyncControlParametersDto parameters)
        {
            ThrowIfDisposed();

            var setParams = GetDelegate<NvApiGSyncSetControlParametersDelegate>(
                NvApiIdGSyncSetControlParameters,
                "NvAPI_GSync_SetControlParameters");

            var native = parameters.ToNative();
            var status = setParams((NvGSyncDeviceHandle__*)_handle, &native);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Adjust sync delay for this G-Sync device.
        /// </summary>
        /// <param name="delayType">Delay type.</param>
        /// <param name="delay">Delay DTO.</param>
        /// <returns>Adjusted delay DTO, or null if unavailable.</returns>
        public unsafe NVAPIGSyncAdjustedDelayDto? AdjustSyncDelay(_NVAPI_GSYNC_DELAY_TYPE delayType, NVAPIGSyncDelayDto delay)
        {
            ThrowIfDisposed();

            var adjust = GetDelegate<NvApiGSyncAdjustSyncDelayDelegate>(
                NvApiIdGSyncAdjustSyncDelay,
                "NvAPI_GSync_AdjustSyncDelay");

            var native = delay.ToNative();
            uint syncSteps = 0;
            var status = adjust((NvGSyncDeviceHandle__*)_handle, delayType, &native, &syncSteps);
            if (status == _NvAPI_Status.NVAPI_OK)
                return new NVAPIGSyncAdjustedDelayDto(NVAPIGSyncDelayDto.FromNative(native), syncSteps);

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get sync status for a physical GPU attached to this G-Sync device.
        /// </summary>
        /// <param name="physicalGpu">Physical GPU helper.</param>
        /// <returns>Sync status DTO, or null if unavailable.</returns>
        public unsafe NVAPIGSyncSyncStatusDto? GetSyncStatus(NVAPIPhysicalGpuHelper physicalGpu)
        {
            ThrowIfDisposed();

            if (physicalGpu == null)
                throw new ArgumentNullException(nameof(physicalGpu));

            var getStatus = GetDelegate<NvApiGSyncGetSyncStatusDelegate>(
                NvApiIdGSyncGetSyncStatus,
                "NvAPI_GSync_GetSyncStatus");

            var statusInfo = CreateSyncStatus();
            var status = getStatus((NvGSyncDeviceHandle__*)_handle, (NvPhysicalGpuHandle__*)physicalGpu.GetHandleOrThrow(), &statusInfo);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGSyncSyncStatusDto.FromNative(statusInfo);

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get status parameters for this G-Sync device.
        /// </summary>
        /// <returns>Status parameters DTO, or null if unavailable.</returns>
        public unsafe NVAPIGSyncStatusParametersDto? GetStatusParameters()
        {
            ThrowIfDisposed();

            var getStatus = GetDelegate<NvApiGSyncGetStatusParametersDelegate>(
                NvApiIdGSyncGetStatusParameters,
                "NvAPI_GSync_GetStatusParameters");

            var parameters = CreateStatusParameters();
            var status = getStatus((NvGSyncDeviceHandle__*)_handle, &parameters);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGSyncStatusParametersDto.FromNative(parameters);

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Set display sync state settings for this G-Sync device.
        /// </summary>
        /// <param name="displays">Display DTO array.</param>
        /// <param name="flags">Flags for the operation.</param>
        /// <returns>True if applied, null if unsupported.</returns>
        public unsafe bool? SetSyncStateSettings(NVAPIGSyncDisplayDto[] displays, uint flags = 0)
        {
            ThrowIfDisposed();

            var setSync = GetDelegate<NvApiGSyncSetSyncStateSettingsDelegate>(
                NvApiIdGSyncSetSyncStateSettings,
                "NvAPI_GSync_SetSyncStateSettings");

            var items = displays ?? Array.Empty<NVAPIGSyncDisplayDto>();
            if (items.Length == 0)
                return false;

            var native = stackalloc _NV_GSYNC_DISPLAY[items.Length];
            for (var i = 0; i < items.Length; i++)
            {
                native[i] = items[i].ToNative();
            }

            var status = setSync((uint)items.Length, native, flags);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        private bool IsUnsupported(_NvAPI_Status status)
        {
            return status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND;
        }

        private T GetDelegate<T>(uint id, string name) where T : Delegate
        {
            var functionPtr = _apiHelper.Api.TryGetFunctionPointer(id);
            if (functionPtr == IntPtr.Zero)
                throw new NVAPIException(_NvAPI_Status.NVAPI_NO_IMPLEMENTATION, $"NVAPI function '{name}' (0x{id:X8}) not available.");

            return Marshal.GetDelegateForFunctionPointer<T>(functionPtr);
        }

        private void ThrowIfDisposed()
        {
            _apiHelper.ThrowIfDisposed();
            if (_disposed)
                throw new ObjectDisposedException(nameof(NVAPIQuadroGSyncHelper));
        }

        /// <summary>
        /// Dispose the helper.
        /// </summary>
        public void Dispose()
        {
            _disposed = true;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGSyncQueryCapabilitiesDelegate(NvGSyncDeviceHandle__* hNvGSyncDevice, _NV_GSYNC_CAPABILITIES_V3* pNvGSyncCapabilities);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGSyncGetTopologyDelegate(NvGSyncDeviceHandle__* hNvGSyncDevice, uint* gsyncGpuCount, _NV_GSYNC_GPU* gsyncGPUs, uint* gsyncDisplayCount, _NV_GSYNC_DISPLAY* gsyncDisplays);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGSyncSetSyncStateSettingsDelegate(uint gsyncDisplayCount, _NV_GSYNC_DISPLAY* pGsyncDisplays, uint flags);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGSyncGetControlParametersDelegate(NvGSyncDeviceHandle__* hNvGSyncDevice, _NV_GSYNC_CONTROL_PARAMS_V2* pGsyncControls);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGSyncSetControlParametersDelegate(NvGSyncDeviceHandle__* hNvGSyncDevice, _NV_GSYNC_CONTROL_PARAMS_V2* pGsyncControls);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGSyncAdjustSyncDelayDelegate(NvGSyncDeviceHandle__* hNvGSyncDevice, _NVAPI_GSYNC_DELAY_TYPE delayType, _NV_GSYNC_DELAY* pGsyncDelay, uint* syncSteps);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGSyncGetSyncStatusDelegate(NvGSyncDeviceHandle__* hNvGSyncDevice, NvPhysicalGpuHandle__* hPhysicalGpu, _NV_GSYNC_STATUS* status);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGSyncGetStatusParametersDelegate(NvGSyncDeviceHandle__* hNvGSyncDevice, _NV_GSYNC_STATUS_PARAMS_V2* pStatusParams);
    }

    /// <summary>
    /// DTO for G-Sync capabilities.
    /// </summary>
    public readonly struct NVAPIGSyncCapabilitiesDto : IEquatable<NVAPIGSyncCapabilitiesDto>
    {
        public uint BoardId { get; }
        public uint Revision { get; }
        public uint CapFlags { get; }
        public uint ExtendedRevision { get; }
        public bool IsMulDivSupported { get; }
        public uint MaxMulDivValue { get; }

        public NVAPIGSyncCapabilitiesDto(
            uint boardId,
            uint revision,
            uint capFlags,
            uint extendedRevision,
            bool isMulDivSupported,
            uint maxMulDivValue)
        {
            BoardId = boardId;
            Revision = revision;
            CapFlags = capFlags;
            ExtendedRevision = extendedRevision;
            IsMulDivSupported = isMulDivSupported;
            MaxMulDivValue = maxMulDivValue;
        }

        public static NVAPIGSyncCapabilitiesDto FromNative(_NV_GSYNC_CAPABILITIES_V3 native)
        {
            return new NVAPIGSyncCapabilitiesDto(
                native.boardId,
                native.revision,
                native.capFlags,
                native.extendedRevision,
                native.bIsMulDivSupported != 0,
                native.maxMulDivValue);
        }

        public _NV_GSYNC_CAPABILITIES_V3 ToNative()
        {
            return new _NV_GSYNC_CAPABILITIES_V3
            {
                version = NVAPI.NV_GSYNC_CAPABILITIES_VER,
                boardId = BoardId,
                revision = Revision,
                capFlags = CapFlags,
                extendedRevision = ExtendedRevision,
                bIsMulDivSupported = IsMulDivSupported ? 1u : 0u,
                reserved = 0,
                maxMulDivValue = MaxMulDivValue,
            };
        }

        public bool Equals(NVAPIGSyncCapabilitiesDto other)
        {
            return BoardId == other.BoardId
                && Revision == other.Revision
                && CapFlags == other.CapFlags
                && ExtendedRevision == other.ExtendedRevision
                && IsMulDivSupported == other.IsMulDivSupported
                && MaxMulDivValue == other.MaxMulDivValue;
        }

        public override bool Equals(object? obj) => obj is NVAPIGSyncCapabilitiesDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = BoardId.GetHashCode();
                hash = (hash * 31) + Revision.GetHashCode();
                hash = (hash * 31) + CapFlags.GetHashCode();
                hash = (hash * 31) + ExtendedRevision.GetHashCode();
                hash = (hash * 31) + IsMulDivSupported.GetHashCode();
                hash = (hash * 31) + MaxMulDivValue.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIGSyncCapabilitiesDto left, NVAPIGSyncCapabilitiesDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGSyncCapabilitiesDto left, NVAPIGSyncCapabilitiesDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for a G-Sync GPU entry in topology.
    /// </summary>
    public readonly struct NVAPIGSyncGpuDto : IEquatable<NVAPIGSyncGpuDto>
    {
        internal IntPtr PhysicalGpuHandle { get; }
        internal IntPtr ProxyPhysicalGpuHandle { get; }
        public NVAPIPhysicalGpuHelper PhysicalGpu { get; }
        public NVAPIPhysicalGpuHelper? ProxyPhysicalGpu { get; }
        public _NVAPI_GSYNC_GPU_TOPOLOGY_CONNECTOR Connector { get; }
        public bool IsSynced { get; }

        public NVAPIGSyncGpuDto(
            NVAPIPhysicalGpuHelper physicalGpu,
            _NVAPI_GSYNC_GPU_TOPOLOGY_CONNECTOR connector,
            NVAPIPhysicalGpuHelper? proxyPhysicalGpu,
            bool isSynced)
        {
            PhysicalGpu = physicalGpu ?? throw new ArgumentNullException(nameof(physicalGpu));
            ProxyPhysicalGpu = proxyPhysicalGpu;
            Connector = connector;
            IsSynced = isSynced;
            PhysicalGpuHandle = physicalGpu.GetHandleOrThrow();
            ProxyPhysicalGpuHandle = proxyPhysicalGpu != null ? proxyPhysicalGpu.GetHandleOrThrow() : IntPtr.Zero;
        }

        private NVAPIGSyncGpuDto(
            IntPtr physicalGpuHandle,
            NVAPIPhysicalGpuHelper physicalGpu,
            IntPtr proxyPhysicalGpuHandle,
            NVAPIPhysicalGpuHelper? proxyPhysicalGpu,
            _NVAPI_GSYNC_GPU_TOPOLOGY_CONNECTOR connector,
            bool isSynced)
        {
            PhysicalGpuHandle = physicalGpuHandle;
            PhysicalGpu = physicalGpu;
            ProxyPhysicalGpuHandle = proxyPhysicalGpuHandle;
            ProxyPhysicalGpu = proxyPhysicalGpu;
            Connector = connector;
            IsSynced = isSynced;
        }

        public static unsafe NVAPIGSyncGpuDto FromNative(NVAPIApiHelper apiHelper, _NV_GSYNC_GPU native)
        {
            var gpuHandle = (IntPtr)native.hPhysicalGpu;
            var proxyHandle = (IntPtr)native.hProxyPhysicalGpu;
            var gpu = new NVAPIPhysicalGpuHelper(apiHelper, gpuHandle);
            NVAPIPhysicalGpuHelper? proxy = null;
            if (proxyHandle != IntPtr.Zero)
                proxy = new NVAPIPhysicalGpuHelper(apiHelper, proxyHandle);

            return new NVAPIGSyncGpuDto(
                gpuHandle,
                gpu,
                proxyHandle,
                proxy,
                native.connector,
                native.isSynced != 0);
        }

        public static unsafe NVAPIGSyncGpuDto[] FromNative(NVAPIApiHelper apiHelper, _NV_GSYNC_GPU* native, int count)
        {
            if (count <= 0 || native == null)
                return Array.Empty<NVAPIGSyncGpuDto>();

            var result = new NVAPIGSyncGpuDto[count];
            for (var i = 0; i < count; i++)
            {
                result[i] = FromNative(apiHelper, native[i]);
            }

            return result;
        }

        public unsafe _NV_GSYNC_GPU ToNative()
        {
            var native = new _NV_GSYNC_GPU
            {
                version = NVAPI.NV_GSYNC_GPU_VER,
                connector = Connector,
                isSynced = IsSynced ? 1u : 0u,
                reserved = 0,
            };

            native.hPhysicalGpu = PhysicalGpuHandle == IntPtr.Zero ? null : (NvPhysicalGpuHandle__*)PhysicalGpuHandle;
            native.hProxyPhysicalGpu = ProxyPhysicalGpuHandle == IntPtr.Zero ? null : (NvPhysicalGpuHandle__*)ProxyPhysicalGpuHandle;
            return native;
        }

        public bool Equals(NVAPIGSyncGpuDto other)
        {
            return PhysicalGpuHandle == other.PhysicalGpuHandle
                && ProxyPhysicalGpuHandle == other.ProxyPhysicalGpuHandle
                && Connector == other.Connector
                && IsSynced == other.IsSynced;
        }

        public override bool Equals(object? obj) => obj is NVAPIGSyncGpuDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = PhysicalGpuHandle.GetHashCode();
                hash = (hash * 31) + ProxyPhysicalGpuHandle.GetHashCode();
                hash = (hash * 31) + Connector.GetHashCode();
                hash = (hash * 31) + IsSynced.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIGSyncGpuDto left, NVAPIGSyncGpuDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGSyncGpuDto left, NVAPIGSyncGpuDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for a G-Sync display entry in topology.
    /// </summary>
    public readonly struct NVAPIGSyncDisplayDto : IEquatable<NVAPIGSyncDisplayDto>
    {
        public uint DisplayId { get; }
        public bool IsMasterable { get; }
        public _NVAPI_GSYNC_DISPLAY_SYNC_STATE SyncState { get; }

        public NVAPIGSyncDisplayDto(uint displayId, bool isMasterable, _NVAPI_GSYNC_DISPLAY_SYNC_STATE syncState)
        {
            DisplayId = displayId;
            IsMasterable = isMasterable;
            SyncState = syncState;
        }

        public static NVAPIGSyncDisplayDto FromNative(_NV_GSYNC_DISPLAY native)
        {
            return new NVAPIGSyncDisplayDto(
                native.displayId,
                native.isMasterable != 0,
                native.syncState);
        }

        public static unsafe NVAPIGSyncDisplayDto[] FromNative(_NV_GSYNC_DISPLAY* native, int count)
        {
            if (count <= 0 || native == null)
                return Array.Empty<NVAPIGSyncDisplayDto>();

            var result = new NVAPIGSyncDisplayDto[count];
            for (var i = 0; i < count; i++)
            {
                result[i] = FromNative(native[i]);
            }

            return result;
        }

        public _NV_GSYNC_DISPLAY ToNative()
        {
            return new _NV_GSYNC_DISPLAY
            {
                version = NVAPI.NV_GSYNC_DISPLAY_VER,
                displayId = DisplayId,
                isMasterable = IsMasterable ? 1u : 0u,
                reserved = 0,
                syncState = SyncState,
            };
        }

        public bool Equals(NVAPIGSyncDisplayDto other)
        {
            return DisplayId == other.DisplayId
                && IsMasterable == other.IsMasterable
                && SyncState == other.SyncState;
        }

        public override bool Equals(object? obj) => obj is NVAPIGSyncDisplayDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = DisplayId.GetHashCode();
                hash = (hash * 31) + IsMasterable.GetHashCode();
                hash = (hash * 31) + SyncState.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIGSyncDisplayDto left, NVAPIGSyncDisplayDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGSyncDisplayDto left, NVAPIGSyncDisplayDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for G-Sync topology results.
    /// </summary>
    public readonly struct NVAPIGSyncTopologyDto : IEquatable<NVAPIGSyncTopologyDto>
    {
        public NVAPIGSyncGpuDto[] Gpus { get; }
        public NVAPIGSyncDisplayDto[] Displays { get; }

        public NVAPIGSyncTopologyDto(NVAPIGSyncGpuDto[] gpus, NVAPIGSyncDisplayDto[] displays)
        {
            Gpus = gpus ?? Array.Empty<NVAPIGSyncGpuDto>();
            Displays = displays ?? Array.Empty<NVAPIGSyncDisplayDto>();
        }

        public bool Equals(NVAPIGSyncTopologyDto other)
        {
            return NVAPIGSyncDtoHelpers.SequenceEquals(Gpus, other.Gpus)
                && NVAPIGSyncDtoHelpers.SequenceEquals(Displays, other.Displays);
        }

        public override bool Equals(object? obj) => obj is NVAPIGSyncTopologyDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = NVAPIGSyncDtoHelpers.SequenceHashCode(Gpus);
                hash = (hash * 31) + NVAPIGSyncDtoHelpers.SequenceHashCode(Displays);
                return hash;
            }
        }

        public static bool operator ==(NVAPIGSyncTopologyDto left, NVAPIGSyncTopologyDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGSyncTopologyDto left, NVAPIGSyncTopologyDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for G-Sync delay.
    /// </summary>
    public readonly struct NVAPIGSyncDelayDto : IEquatable<NVAPIGSyncDelayDto>
    {
        public uint NumLines { get; }
        public uint NumPixels { get; }
        public uint MaxLines { get; }
        public uint MinPixels { get; }

        public NVAPIGSyncDelayDto(uint numLines, uint numPixels, uint maxLines, uint minPixels)
        {
            NumLines = numLines;
            NumPixels = numPixels;
            MaxLines = maxLines;
            MinPixels = minPixels;
        }

        public static NVAPIGSyncDelayDto FromNative(_NV_GSYNC_DELAY native)
        {
            return new NVAPIGSyncDelayDto(native.numLines, native.numPixels, native.maxLines, native.minPixels);
        }

        public _NV_GSYNC_DELAY ToNative()
        {
            return new _NV_GSYNC_DELAY
            {
                version = NVAPI.NV_GSYNC_DELAY_VER,
                numLines = NumLines,
                numPixels = NumPixels,
                maxLines = MaxLines,
                minPixels = MinPixels,
            };
        }

        public bool Equals(NVAPIGSyncDelayDto other)
        {
            return NumLines == other.NumLines
                && NumPixels == other.NumPixels
                && MaxLines == other.MaxLines
                && MinPixels == other.MinPixels;
        }

        public override bool Equals(object? obj) => obj is NVAPIGSyncDelayDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = NumLines.GetHashCode();
                hash = (hash * 31) + NumPixels.GetHashCode();
                hash = (hash * 31) + MaxLines.GetHashCode();
                hash = (hash * 31) + MinPixels.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIGSyncDelayDto left, NVAPIGSyncDelayDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGSyncDelayDto left, NVAPIGSyncDelayDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for adjusted delay results.
    /// </summary>
    public readonly struct NVAPIGSyncAdjustedDelayDto : IEquatable<NVAPIGSyncAdjustedDelayDto>
    {
        public NVAPIGSyncDelayDto Delay { get; }
        public uint SyncSteps { get; }

        public NVAPIGSyncAdjustedDelayDto(NVAPIGSyncDelayDto delay, uint syncSteps)
        {
            Delay = delay;
            SyncSteps = syncSteps;
        }

        public bool Equals(NVAPIGSyncAdjustedDelayDto other)
        {
            return Delay.Equals(other.Delay) && SyncSteps == other.SyncSteps;
        }

        public override bool Equals(object? obj) => obj is NVAPIGSyncAdjustedDelayDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = Delay.GetHashCode();
                hash = (hash * 31) + SyncSteps.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIGSyncAdjustedDelayDto left, NVAPIGSyncAdjustedDelayDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGSyncAdjustedDelayDto left, NVAPIGSyncAdjustedDelayDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for G-Sync control parameters.
    /// </summary>
    public readonly struct NVAPIGSyncControlParametersDto : IEquatable<NVAPIGSyncControlParametersDto>
    {
        public _NVAPI_GSYNC_POLARITY Polarity { get; }
        public _NVAPI_GSYNC_VIDEO_MODE VideoMode { get; }
        public uint Interval { get; }
        public _NVAPI_GSYNC_SYNC_SOURCE Source { get; }
        public bool InterlaceMode { get; }
        public bool SyncSourceIsOutput { get; }
        public NVAPIGSyncDelayDto SyncSkew { get; }
        public NVAPIGSyncDelayDto StartupDelay { get; }
        public _NVAPI_GSYNC_MULTIPLY_DIVIDE_MODE MultiplyDivideMode { get; }
        public byte MultiplyDivideValue { get; }

        public NVAPIGSyncControlParametersDto(
            _NVAPI_GSYNC_POLARITY polarity,
            _NVAPI_GSYNC_VIDEO_MODE videoMode,
            uint interval,
            _NVAPI_GSYNC_SYNC_SOURCE source,
            bool interlaceMode,
            bool syncSourceIsOutput,
            NVAPIGSyncDelayDto syncSkew,
            NVAPIGSyncDelayDto startupDelay,
            _NVAPI_GSYNC_MULTIPLY_DIVIDE_MODE multiplyDivideMode,
            byte multiplyDivideValue)
        {
            Polarity = polarity;
            VideoMode = videoMode;
            Interval = interval;
            Source = source;
            InterlaceMode = interlaceMode;
            SyncSourceIsOutput = syncSourceIsOutput;
            SyncSkew = syncSkew;
            StartupDelay = startupDelay;
            MultiplyDivideMode = multiplyDivideMode;
            MultiplyDivideValue = multiplyDivideValue;
        }

        public static NVAPIGSyncControlParametersDto FromNative(_NV_GSYNC_CONTROL_PARAMS_V2 native)
        {
            return new NVAPIGSyncControlParametersDto(
                native.polarity,
                native.vmode,
                native.interval,
                native.source,
                native.interlaceMode != 0,
                native.syncSourceIsOutput != 0,
                NVAPIGSyncDelayDto.FromNative(native.syncSkew),
                NVAPIGSyncDelayDto.FromNative(native.startupDelay),
                native.multiplyDivideMode,
                native.multiplyDivideValue);
        }

        public _NV_GSYNC_CONTROL_PARAMS_V2 ToNative()
        {
            var native = new _NV_GSYNC_CONTROL_PARAMS_V2
            {
                version = NVAPI.NV_GSYNC_CONTROL_PARAMS_VER,
                polarity = Polarity,
                vmode = VideoMode,
                interval = Interval,
                source = Source,
                interlaceMode = InterlaceMode ? 1u : 0u,
                syncSourceIsOutput = SyncSourceIsOutput ? 1u : 0u,
                reserved = 0,
                syncSkew = SyncSkew.ToNative(),
                startupDelay = StartupDelay.ToNative(),
                multiplyDivideMode = MultiplyDivideMode,
                multiplyDivideValue = MultiplyDivideValue,
            };

            return native;
        }

        public bool Equals(NVAPIGSyncControlParametersDto other)
        {
            return Polarity == other.Polarity
                && VideoMode == other.VideoMode
                && Interval == other.Interval
                && Source == other.Source
                && InterlaceMode == other.InterlaceMode
                && SyncSourceIsOutput == other.SyncSourceIsOutput
                && SyncSkew.Equals(other.SyncSkew)
                && StartupDelay.Equals(other.StartupDelay)
                && MultiplyDivideMode == other.MultiplyDivideMode
                && MultiplyDivideValue == other.MultiplyDivideValue;
        }

        public override bool Equals(object? obj) => obj is NVAPIGSyncControlParametersDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = Polarity.GetHashCode();
                hash = (hash * 31) + VideoMode.GetHashCode();
                hash = (hash * 31) + Interval.GetHashCode();
                hash = (hash * 31) + Source.GetHashCode();
                hash = (hash * 31) + InterlaceMode.GetHashCode();
                hash = (hash * 31) + SyncSourceIsOutput.GetHashCode();
                hash = (hash * 31) + SyncSkew.GetHashCode();
                hash = (hash * 31) + StartupDelay.GetHashCode();
                hash = (hash * 31) + MultiplyDivideMode.GetHashCode();
                hash = (hash * 31) + MultiplyDivideValue.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIGSyncControlParametersDto left, NVAPIGSyncControlParametersDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGSyncControlParametersDto left, NVAPIGSyncControlParametersDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for sync status.
    /// </summary>
    public readonly struct NVAPIGSyncSyncStatusDto : IEquatable<NVAPIGSyncSyncStatusDto>
    {
        public bool IsSynced { get; }
        public bool IsStereoSynced { get; }
        public bool IsSyncSignalAvailable { get; }

        public NVAPIGSyncSyncStatusDto(bool isSynced, bool isStereoSynced, bool isSyncSignalAvailable)
        {
            IsSynced = isSynced;
            IsStereoSynced = isStereoSynced;
            IsSyncSignalAvailable = isSyncSignalAvailable;
        }

        public static NVAPIGSyncSyncStatusDto FromNative(_NV_GSYNC_STATUS native)
        {
            return new NVAPIGSyncSyncStatusDto(
                native.bIsSynced != 0,
                native.bIsStereoSynced != 0,
                native.bIsSyncSignalAvailable != 0);
        }

        public _NV_GSYNC_STATUS ToNative()
        {
            return new _NV_GSYNC_STATUS
            {
                version = NVAPI.NV_GSYNC_STATUS_VER,
                bIsSynced = IsSynced ? 1u : 0u,
                bIsStereoSynced = IsStereoSynced ? 1u : 0u,
                bIsSyncSignalAvailable = IsSyncSignalAvailable ? 1u : 0u,
            };
        }

        public bool Equals(NVAPIGSyncSyncStatusDto other)
        {
            return IsSynced == other.IsSynced
                && IsStereoSynced == other.IsStereoSynced
                && IsSyncSignalAvailable == other.IsSyncSignalAvailable;
        }

        public override bool Equals(object? obj) => obj is NVAPIGSyncSyncStatusDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = IsSynced.GetHashCode();
                hash = (hash * 31) + IsStereoSynced.GetHashCode();
                hash = (hash * 31) + IsSyncSignalAvailable.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIGSyncSyncStatusDto left, NVAPIGSyncSyncStatusDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGSyncSyncStatusDto left, NVAPIGSyncSyncStatusDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for G-Sync status parameters.
    /// </summary>
    public readonly struct NVAPIGSyncStatusParametersDto : IEquatable<NVAPIGSyncStatusParametersDto>
    {
        public uint RefreshRate { get; }
        public _NVAPI_GSYNC_RJ45_IO[] Rj45Io { get; }
        public uint[] Rj45Ethernet { get; }
        public uint HouseSyncIncoming { get; }
        public bool IsHouseSyncConnected { get; }
        public bool IsInternalSlave { get; }

        public NVAPIGSyncStatusParametersDto(
            uint refreshRate,
            _NVAPI_GSYNC_RJ45_IO[] rj45Io,
            uint[] rj45Ethernet,
            uint houseSyncIncoming,
            bool isHouseSyncConnected,
            bool isInternalSlave)
        {
            RefreshRate = refreshRate;
            Rj45Io = rj45Io ?? Array.Empty<_NVAPI_GSYNC_RJ45_IO>();
            Rj45Ethernet = rj45Ethernet ?? Array.Empty<uint>();
            HouseSyncIncoming = houseSyncIncoming;
            IsHouseSyncConnected = isHouseSyncConnected;
            IsInternalSlave = isInternalSlave;
        }

        public static NVAPIGSyncStatusParametersDto FromNative(_NV_GSYNC_STATUS_PARAMS_V2 native)
        {
            var io = new _NVAPI_GSYNC_RJ45_IO[NVAPI.NVAPI_MAX_RJ45_PER_GSYNC];
            var ethernet = new uint[NVAPI.NVAPI_MAX_RJ45_PER_GSYNC];
            for (var i = 0; i < NVAPI.NVAPI_MAX_RJ45_PER_GSYNC; i++)
            {
                io[i] = native.RJ45_IO[i];
                ethernet[i] = native.RJ45_Ethernet[i];
            }

            return new NVAPIGSyncStatusParametersDto(
                native.refreshRate,
                io,
                ethernet,
                native.houseSyncIncoming,
                native.bHouseSync != 0,
                native.bInternalSlave != 0);
        }

        public _NV_GSYNC_STATUS_PARAMS_V2 ToNative()
        {
            var native = new _NV_GSYNC_STATUS_PARAMS_V2
            {
                version = NVAPI.NV_GSYNC_STATUS_PARAMS_VER,
                refreshRate = RefreshRate,
                houseSyncIncoming = HouseSyncIncoming,
                bHouseSync = IsHouseSyncConnected ? 1u : 0u,
                bInternalSlave = IsInternalSlave ? 1u : 0u,
                reserved = 0,
            };

            for (var i = 0; i < NVAPI.NVAPI_MAX_RJ45_PER_GSYNC; i++)
            {
                native.RJ45_IO[i] = (Rj45Io != null && i < Rj45Io.Length) ? Rj45Io[i] : _NVAPI_GSYNC_RJ45_IO.NVAPI_GSYNC_RJ45_UNUSED;
                native.RJ45_Ethernet[i] = (Rj45Ethernet != null && i < Rj45Ethernet.Length) ? Rj45Ethernet[i] : 0u;
            }

            return native;
        }

        public bool Equals(NVAPIGSyncStatusParametersDto other)
        {
            return RefreshRate == other.RefreshRate
                && NVAPIGSyncDtoHelpers.SequenceEquals(Rj45Io, other.Rj45Io)
                && NVAPIGSyncDtoHelpers.SequenceEquals(Rj45Ethernet, other.Rj45Ethernet)
                && HouseSyncIncoming == other.HouseSyncIncoming
                && IsHouseSyncConnected == other.IsHouseSyncConnected
                && IsInternalSlave == other.IsInternalSlave;
        }

        public override bool Equals(object? obj) => obj is NVAPIGSyncStatusParametersDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = RefreshRate.GetHashCode();
                hash = (hash * 31) + NVAPIGSyncDtoHelpers.SequenceHashCode(Rj45Io);
                hash = (hash * 31) + NVAPIGSyncDtoHelpers.SequenceHashCode(Rj45Ethernet);
                hash = (hash * 31) + HouseSyncIncoming.GetHashCode();
                hash = (hash * 31) + IsHouseSyncConnected.GetHashCode();
                hash = (hash * 31) + IsInternalSlave.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIGSyncStatusParametersDto left, NVAPIGSyncStatusParametersDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGSyncStatusParametersDto left, NVAPIGSyncStatusParametersDto right) => !left.Equals(right);
    }

    internal static class NVAPIGSyncDtoHelpers
    {
        public static bool SequenceEquals<T>(T[] left, T[] right)
        {
            if (ReferenceEquals(left, right))
                return true;

            if (left == null || right == null)
                return false;

            if (left.Length != right.Length)
                return false;

            var comparer = EqualityComparer<T>.Default;
            for (var i = 0; i < left.Length; i++)
            {
                if (!comparer.Equals(left[i], right[i]))
                    return false;
            }

            return true;
        }

        public static int SequenceHashCode<T>(T[] values)
        {
            if (values == null)
                return 0;

            unchecked
            {
                var hash = 17;
                var comparer = EqualityComparer<T>.Default;
                for (var i = 0; i < values.Length; i++)
                {
                    var value = values[i];
                    if (value is null)
                    {
                        hash = (hash * 31);
                        continue;
                    }

                    hash = (hash * 31) + comparer.GetHashCode(value);
                }

                return hash;
            }
        }
    }
}
