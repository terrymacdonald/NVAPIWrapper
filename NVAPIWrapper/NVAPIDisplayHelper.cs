using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NVAPIWrapper
{
    /// <summary>
    /// Facade helper for an NVIDIA display handle.
    /// </summary>
    public sealed class NVAPIDisplayHelper : IDisposable
    {
        private const uint NvApiIdGetPhysicalGpusFromDisplay = 0x34EF9506;
        private const uint NvApiIdGetLogicalGpuFromDisplay = 0xEE1370CF;
        private const uint NvApiIdGetAssociatedNvidiaDisplayName = 0x22A78B05;
        private const uint NvApiIdGetAssociatedNvidiaDisplayHandle = 0x35C29134;
        private const uint NvApiIdGetAssociatedDisplayOutputId = 0xD995937E;
        private const uint NvApiIdGetVBlankCounter = 0x67B5DB55;
        private const uint NvApiIdDispGetDisplayConfig = 0x11ABCCF8;
        private const uint NvApiIdDispSetDisplayConfig = 0x5D8CF8DE;
        private const uint NvApiIdDispGetDisplayIdByDisplayName = 0xAE457190;
        private const uint NvApiIdDispGetGdiPrimaryDisplayId = 0x1E9D8A31;
        private const uint NvApiIdGetSupportedViews = 0x66FB7FC0;
        private const uint NvApiIdDispGetEdidData = 0x436CED76;
        private const uint NvApiIdDispGetTiming = 0x175167E9;
        private const uint NvApiIdDispGetMonitorCapabilities = 0x3B05C7E1;
        private const uint NvApiIdDispGetMonitorColorCapabilities = 0x6AE4CFB5;
        private const uint NvApiIdGetDisplayPortInfo = 0xC64FF367;
        private const uint NvApiIdSetDisplayPort = 0xFA13E65A;
        private const uint NvApiIdGetHdmiSupportInfo = 0x6AE16EC3;
        private const uint NvApiIdDispGetVrrInfo = 0xDF8FDA57;
        private const uint NvApiIdDispGetAdaptiveSyncData = 0xB73D1EE9;
        private const uint NvApiIdDispSetAdaptiveSyncData = 0x3EEBBA1D;
        private const uint NvApiIdDispGetVirtualRefreshRateData = 0x8C00429A;
        private const uint NvApiIdDispSetVirtualRefreshRateData = 0x5ABBE6A3;
        private const uint NvApiIdDispSetPreferredStereoDisplay = 0xC9D0E25F;
        private const uint NvApiIdDispGetPreferredStereoDisplay = 0x1F6B4666;
        private const uint NvApiIdSysGetGpuAndOutputIdFromDisplayId = 0x112BA1A5;
        private const uint NvApiIdSysGetPhysicalGpuFromDisplayId = 0x9EA74659;
        private const uint NvApiIdEnableHwCursor = 0x2863148D;
        private const uint NvApiIdDisableHwCursor = 0xAB163097;
        private const uint NvApiIdSetRefreshRateOverride = 0x3092AC32;
        private const uint NvApiIdDispInfoFrameControl = 0x6067AF3F;
        private const uint NvApiIdDispColorControl = 0x92F9D80D;
        private const uint NvApiIdDispGetHdrCapabilities = 0x84F2A8DF;
        private const uint NvApiIdDispHdrColorControl = 0x351DA224;
        private const uint NvApiIdDispSetSourceColorSpace = 0x473B6CAF;
        private const uint NvApiIdDispGetSourceColorSpace = 0xCEEDC85B;
        private const uint NvApiIdDispSetSourceHdrMetadata = 0x905EB63B;
        private const uint NvApiIdDispGetSourceHdrMetadata = 0x0D3F52DA;
        private const uint NvApiIdDispSetOutputMode = 0x98E7661A;
        private const uint NvApiIdDispGetOutputMode = 0x81FED88D;
        private const uint NvApiIdDispSetHdrToneMapping = 0xDD6DA362;
        private const uint NvApiIdDispGetHdrToneMapping = 0xFBD36E71;
        private const uint NvApiIdDispGetColorimetry = 0x00B421AD;
        private const uint NvApiIdDispEnumCustomDisplay = 0xA2072D59;
        private const uint NvApiIdDispTryCustomDisplay = 0x1F7DB630;
        private const uint NvApiIdDispDeleteCustomDisplay = 0x552E5B9B;
        private const uint NvApiIdDispSaveCustomDisplay = 0x49882876;
        private const uint NvApiIdDispRevertCustomDisplayTrial = 0xCBBD40F0;
        private const uint NvApiIdDispGetNvManagedDedicatedDisplays = 0xDBDF0CB2;
        private const uint NvApiIdDispAcquireDedicatedDisplay = 0x47C917BA;
        private const uint NvApiIdDispReleaseDedicatedDisplay = 0x1247825F;
        private const uint NvApiIdDispGetNvManagedDedicatedDisplayMetadata = 0xD645D80C;
        private const uint NvApiIdDispSetNvManagedDedicatedDisplayMetadata = 0x3D8B129A;
        private const uint NvApiIdDispGetDisplayIdInfo = 0xBAE8AA5E;
        private const uint NvApiIdDispGetDisplayIdsFromTarget = 0xE7E5F89E;

        private readonly NVAPIApiHelper _apiHelper;
        private readonly IntPtr _handle;
        private readonly NVAPIGpuDisplayIdDto? _displayIdInfo;
        private readonly uint _displayId;
        private bool _disposed;

        internal NVAPIDisplayHelper(NVAPIApiHelper apiHelper, IntPtr handle, NVAPIGpuDisplayIdDto? displayIdInfo = null)
        {
            _apiHelper = apiHelper;
            _handle = handle;
            _displayIdInfo = displayIdInfo;
            _displayId = displayIdInfo?.DisplayId ?? TryGetDisplayIdNoThrow();
        }

        /// <summary>
        /// Get the display ID for this handle when available.
        /// </summary>
        public uint DisplayId => _displayIdInfo?.DisplayId ?? _displayId;

        /// <summary>
        /// Get the connector type for this display when available.
        /// </summary>
        public NV_MONITOR_CONN_TYPE ConnectorType => _displayIdInfo?.ConnectorType ?? default;

        /// <summary>
        /// Get whether this display is part of an MST topology and is dynamic.
        /// </summary>
        public bool IsDynamic => _displayIdInfo?.IsDynamic ?? false;

        /// <summary>
        /// Get whether this display is the multi-stream root node.
        /// </summary>
        public bool IsMultiStreamRootNode => _displayIdInfo?.IsMultiStreamRootNode ?? false;

        /// <summary>
        /// Get whether this display is actively driven.
        /// </summary>
        public bool IsActive => _displayIdInfo?.IsActive ?? false;

        /// <summary>
        /// Get whether this display is the representative display.
        /// </summary>
        public bool IsCluster => _displayIdInfo?.IsCluster ?? false;

        /// <summary>
        /// Get whether this display is reported to the OS.
        /// </summary>
        public bool IsOSVisible => _displayIdInfo?.IsOSVisible ?? false;

        /// <summary>
        /// Get whether this display is a WFD display (deprecated in NVAPI).
        /// </summary>
        public bool IsWfd => _displayIdInfo?.IsWfd ?? false;

        /// <summary>
        /// Get whether this display is connected.
        /// </summary>
        public bool IsConnected => _displayIdInfo?.IsConnected ?? false;

        /// <summary>
        /// Get whether this display is physically connected.
        /// </summary>
        public bool IsPhysicallyConnected => _displayIdInfo?.IsPhysicallyConnected ?? false;

        /// <summary>
        /// Create an EDID data struct with the version initialized.
        /// </summary>
        public static _NV_EDID_DATA_V2 CreateEdidData()
        {
            return new _NV_EDID_DATA_V2
            {
                version = NVAPI.NV_EDID_DATA_VER,
                pEDID = null,
                sizeOfEDID = 0,
            };
        }

        /// <summary>
        /// Create a timing input struct with the version initialized.
        /// </summary>
        public static _NV_TIMING_INPUT CreateTimingInput()
        {
            return new _NV_TIMING_INPUT
            {
                version = NVAPI.NV_TIMING_INPUT_VER,
            };
        }

        /// <summary>
        /// Create a monitor capabilities struct with the version initialized.
        /// </summary>
        public static _NV_MONITOR_CAPABILITIES_V1 CreateMonitorCapabilities()
        {
            return new _NV_MONITOR_CAPABILITIES_V1
            {
                version = NVAPI.NV_MONITOR_CAPABILITIES_VER,
            };
        }

        /// <summary>
        /// Create a display port info struct with the version initialized.
        /// </summary>
        public static _NV_DISPLAY_PORT_INFO_V1 CreateDisplayPortInfo()
        {
            return new _NV_DISPLAY_PORT_INFO_V1
            {
                version = NVAPI.NV_DISPLAY_PORT_INFO_VER,
            };
        }

        /// <summary>
        /// Create a display port config struct with the version initialized.
        /// </summary>
        public static NV_DISPLAY_PORT_CONFIG CreateDisplayPortConfig()
        {
            return new NV_DISPLAY_PORT_CONFIG
            {
                version = NVAPI.NV_DISPLAY_PORT_CONFIG_VER,
            };
        }

        /// <summary>
        /// Create an HDMI support info struct with the version initialized.
        /// </summary>
        public static _NV_HDMI_SUPPORT_INFO_V2 CreateHdmiSupportInfo()
        {
            return new _NV_HDMI_SUPPORT_INFO_V2
            {
                version = NVAPI.NV_HDMI_SUPPORT_INFO_VER2,
            };
        }

        /// <summary>
        /// Create a VRR info struct with the version initialized.
        /// </summary>
        public static _NV_GET_VRR_INFO_V1 CreateVrrInfo()
        {
            return new _NV_GET_VRR_INFO_V1
            {
                version = NVAPI.NV_GET_VRR_INFO_VER,
            };
        }

        /// <summary>
        /// Create adaptive sync GET data with the version initialized.
        /// </summary>
        public static _NV_GET_ADAPTIVE_SYNC_DATA_V1 CreateAdaptiveSyncGetData()
        {
            return new _NV_GET_ADAPTIVE_SYNC_DATA_V1
            {
                version = NVAPI.NV_GET_ADAPTIVE_SYNC_DATA_VER,
            };
        }

        /// <summary>
        /// Create adaptive sync SET data with the version initialized.
        /// </summary>
        public static _NV_SET_ADAPTIVE_SYNC_DATA_V1 CreateAdaptiveSyncSetData()
        {
            return new _NV_SET_ADAPTIVE_SYNC_DATA_V1
            {
                version = NVAPI.NV_SET_ADAPTIVE_SYNC_DATA_VER,
            };
        }

        /// <summary>
        /// Create virtual refresh rate GET data with the version initialized.
        /// </summary>
        public static _NV_GET_VIRTUAL_REFRESH_RATE_DATA_V2 CreateVirtualRefreshRateGetData()
        {
            return new _NV_GET_VIRTUAL_REFRESH_RATE_DATA_V2
            {
                version = NVAPI.NV_GET_VIRTUAL_REFRESH_RATE_DATA_VER,
            };
        }

        /// <summary>
        /// Create virtual refresh rate SET data with the version initialized.
        /// </summary>
        public static _NV_SET_VIRTUAL_REFRESH_RATE_DATA_V2 CreateVirtualRefreshRateSetData()
        {
            return new _NV_SET_VIRTUAL_REFRESH_RATE_DATA_V2
            {
                version = NVAPI.NV_SET_VIRTUAL_REFRESH_RATE_DATA_VER,
            };
        }

        /// <summary>
        /// Create preferred stereo display GET struct with the version initialized.
        /// </summary>
        public static NV_GET_PREFERRED_STEREO_DISPLAY_V1 CreatePreferredStereoDisplayGet()
        {
            return new NV_GET_PREFERRED_STEREO_DISPLAY_V1
            {
                version = NVAPI.NV_GET_PREFERRED_STEREO_DISPLAY_VER,
            };
        }

        /// <summary>
        /// Create preferred stereo display SET struct with the version initialized.
        /// </summary>
        public static NV_SET_PREFERRED_STEREO_DISPLAY_V1 CreatePreferredStereoDisplaySet()
        {
            return new NV_SET_PREFERRED_STEREO_DISPLAY_V1
            {
                version = NVAPI.NV_SET_PREFERRED_STEREO_DISPLAY_VER,
            };
        }

        /// <summary>
        /// Create an infoframe data struct with the version initialized.
        /// </summary>
        public static NV_INFOFRAME_DATA CreateInfoFrameData()
        {
            return new NV_INFOFRAME_DATA
            {
                version = NVAPI.NV_INFOFRAME_DATA_VER,
                size = (ushort)Marshal.SizeOf<NV_INFOFRAME_DATA>(),
            };
        }

        /// <summary>
        /// Create a color data struct with the version initialized.
        /// </summary>
        public static _NV_COLOR_DATA_V5 CreateColorData()
        {
            return new _NV_COLOR_DATA_V5
            {
                version = NVAPI.NV_COLOR_DATA_VER,
                size = (ushort)Marshal.SizeOf<_NV_COLOR_DATA_V5>(),
            };
        }

        /// <summary>
        /// Create an HDR capabilities struct with the version initialized.
        /// </summary>
        public static _NV_HDR_CAPABILITIES_V3 CreateHdrCapabilities()
        {
            return new _NV_HDR_CAPABILITIES_V3
            {
                version = NVAPI.NV_HDR_CAPABILITIES_VER,
            };
        }

        /// <summary>
        /// Create an HDR color data struct with the version initialized.
        /// </summary>
        public static _NV_HDR_COLOR_DATA_V2 CreateHdrColorData()
        {
            return new _NV_HDR_COLOR_DATA_V2
            {
                version = NVAPI.NV_HDR_COLOR_DATA_VER,
            };
        }

        /// <summary>
        /// Create an HDR metadata struct with the version initialized.
        /// </summary>
        public static _NV_HDR_METADATA_V1 CreateHdrMetadata()
        {
            return new _NV_HDR_METADATA_V1
            {
                version = NVAPI.NV_HDR_METADATA_VER,
            };
        }

        /// <summary>
        /// Create a display colorimetry struct with the version initialized.
        /// </summary>
        public static _NV_DISPLAY_COLORIMETRY_V1 CreateDisplayColorimetry()
        {
            return new _NV_DISPLAY_COLORIMETRY_V1
            {
                version = NVAPI.NV_DISPLAY_COLORIMETRY_VER,
            };
        }

        /// <summary>
        /// Create a custom display struct with the version initialized.
        /// </summary>
        public static NV_CUSTOM_DISPLAY CreateCustomDisplay()
        {
            return new NV_CUSTOM_DISPLAY
            {
                version = NVAPI.NV_CUSTOM_DISPLAY_VER,
            };
        }

        /// <summary>
        /// Create a managed dedicated display info struct with the version initialized.
        /// </summary>
        public static _NV_MANAGED_DEDICATED_DISPLAY_INFO CreateManagedDedicatedDisplayInfo()
        {
            return new _NV_MANAGED_DEDICATED_DISPLAY_INFO
            {
                version = NVAPI.NV_MANAGED_DEDICATED_DISPLAY_INFO_VER,
            };
        }

        /// <summary>
        /// Create a managed dedicated display metadata struct with the version initialized.
        /// </summary>
        public static _NV_MANAGED_DEDICATED_DISPLAY_METADATA CreateManagedDedicatedDisplayMetadata()
        {
            return new _NV_MANAGED_DEDICATED_DISPLAY_METADATA
            {
                version = NVAPI.NV_MANAGED_DEDICATED_DISPLAY_METADATA_VER,
            };
        }

        /// <summary>
        /// Create a display ID info data struct with the version initialized.
        /// </summary>
        public static _NV_DISPLAY_ID_INFO_DATA_V1 CreateDisplayIdInfoData()
        {
            return new _NV_DISPLAY_ID_INFO_DATA_V1
            {
                version = NVAPI.NV_DISPLAY_ID_INFO_DATA_VER,
            };
        }

        /// <summary>
        /// Create a target info data struct with the version initialized.
        /// </summary>
        public static _NV_TARGET_INFO_DATA_V1 CreateTargetInfoData()
        {
            return new _NV_TARGET_INFO_DATA_V1
            {
                version = NVAPI.NV_TARGET_INFO_DATA_VER,
            };
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

        /// <summary>
        /// Get the associated NVIDIA display name.
        /// </summary>
        /// <returns>Display name, or null if unavailable.</returns>
        public unsafe string? GetAssociatedNvidiaDisplayName()
        {
            ThrowIfDisposed();

            var getName = GetDelegate<NvApiGetAssociatedNvidiaDisplayNameDelegate>(
                NvApiIdGetAssociatedNvidiaDisplayName,
                "NvAPI_GetAssociatedNvidiaDisplayName");
            Span<sbyte> buffer = stackalloc sbyte[NVAPI.NVAPI_SHORT_STRING_MAX];
            buffer[0] = 0;

            fixed (sbyte* pBuffer = buffer)
            {
                var status = getName(GetHandle(), pBuffer);
                if (status == _NvAPI_Status.NVAPI_OK)
                    return Marshal.PtrToStringAnsi((IntPtr)pBuffer);

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return null;

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Get the output ID associated with this display.
        /// </summary>
        /// <returns>Output ID, or null if unavailable.</returns>
        public unsafe uint? GetAssociatedDisplayOutputId()
        {
            ThrowIfDisposed();

            var getOutputId = GetDelegate<NvApiGetAssociatedDisplayOutputIdDelegate>(
                NvApiIdGetAssociatedDisplayOutputId,
                "NvAPI_GetAssociatedDisplayOutputId");
            uint outputId = 0;
            var status = getOutputId(GetHandle(), &outputId);
            if (status == _NvAPI_Status.NVAPI_OK)
                return outputId;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the physical GPU and output ID for this display.
        /// </summary>
        /// <returns>GPU and output ID info, or null if unavailable.</returns>
        public unsafe NVAPIGpuAndOutputIdDto? GetGpuAndOutputIdFromDisplayId()
        {
            ThrowIfDisposed();

            if (!TryGetDisplayId(out var displayId))
                return null;

            var getInfo = GetDelegate<NvApiSysGetGpuAndOutputIdFromDisplayIdDelegate>(
                NvApiIdSysGetGpuAndOutputIdFromDisplayId,
                "NvAPI_SYS_GetGpuAndOutputIdFromDisplayId");

            NvPhysicalGpuHandle__* physicalGpu = null;
            uint outputId = 0;
            var status = getInfo(displayId, &physicalGpu, &outputId);

            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIGpuAndOutputIdDto.FromNative(_apiHelper, physicalGpu, outputId);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the physical GPU that drives this display.
        /// </summary>
        /// <returns>Physical GPU helper, or null if unavailable.</returns>
        public unsafe NVAPIPhysicalGpuHelper? GetPhysicalGpuFromDisplayId()
        {
            ThrowIfDisposed();

            if (!TryGetDisplayId(out var displayId))
                return null;

            var getGpu = GetDelegate<NvApiSysGetPhysicalGpuFromDisplayIdDelegate>(
                NvApiIdSysGetPhysicalGpuFromDisplayId,
                "NvAPI_SYS_GetPhysicalGpuFromDisplayId");

            NvPhysicalGpuHandle__* physicalGpu = null;
            var status = getGpu(displayId, &physicalGpu);

            if (status == _NvAPI_Status.NVAPI_OK)
                return new NVAPIPhysicalGpuHelper(_apiHelper, (IntPtr)physicalGpu);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the current VBlank counter for this display.
        /// </summary>
        /// <returns>VBlank counter value, or null if unavailable.</returns>
        public unsafe uint? GetVBlankCounter()
        {
            ThrowIfDisposed();

            var getCounter = GetDelegate<NvApiGetVBlankCounterDelegate>(
                NvApiIdGetVBlankCounter,
                "NvAPI_GetVBlankCounter");
            uint counter = 0;
            var status = getCounter(GetHandle(), &counter);
            if (status == _NvAPI_Status.NVAPI_OK)
                return counter;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the current display configuration snapshot.
        /// </summary>
        /// <returns>Display configuration info, or null if unavailable.</returns>
        public unsafe NVAPIDisplayConfigDto? GetDisplayConfig()
        {
            ThrowIfDisposed();

            var getConfig = GetDelegate<NvApiDispGetDisplayConfigDelegate>(
                NvApiIdDispGetDisplayConfig,
                "NvAPI_DISP_GetDisplayConfig");
            uint pathCount = 0;
            var status = getConfig(&pathCount, null);
            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            if (pathCount == 0)
                return new NVAPIDisplayConfigDto(Array.Empty<NVAPIDisplayConfigPathDto>());

            using var buffer = new DisplayConfigBuffer(pathCount);
            buffer.InitializePathInfoVersions();

            status = getConfig(&pathCount, buffer.PathInfo);
            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            buffer.AllocateNestedBuffers();

            status = getConfig(&pathCount, buffer.PathInfo);
            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            return NVAPIDisplayConfigDto.FromNative(pathCount, buffer.PathInfo);
        }

        /// <summary>
        /// Apply a display configuration snapshot using NvAPI_DISP_SetDisplayConfig.
        /// </summary>
        /// <param name="config">Desired display configuration snapshot.</param>
        /// <param name="flags">Optional NVAPI display config flags.</param>
        /// <returns>True if applied, false if unavailable or unchanged.</returns>
        public unsafe bool SetDisplayConfig(NVAPIDisplayConfigDto config, uint flags = 0)
        {
            ThrowIfDisposed();

            var paths = config.Paths ?? Array.Empty<NVAPIDisplayConfigPathDto>();
            if (paths.Length == 0)
                return false;

            var current = GetDisplayConfig();
            if (current == null)
                return false;

            if (current.Value.Equals(config))
                return true;

            var setConfig = GetDelegate<NvApiDispSetDisplayConfigDelegate>(
                NvApiIdDispSetDisplayConfig,
                "NvAPI_DISP_SetDisplayConfig");

            using var buffer = config.ToNativeBuffer();
            var status = setConfig((uint)paths.Length, buffer.PathInfo, flags);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the display ID associated with a display name.
        /// </summary>
        /// <param name="displayName">Display name (e.g., "\\.\DISPLAY1"). If null, uses this display handle's name.</param>
        /// <returns>Display ID, or null if unavailable.</returns>
        public unsafe uint? GetDisplayIdByDisplayName(string? displayName = null)
        {
            ThrowIfDisposed();

            var name = displayName;
            if (string.IsNullOrWhiteSpace(name))
            {
                name = GetAssociatedNvidiaDisplayName();
                if (string.IsNullOrWhiteSpace(name))
                    return null;
            }

            if (!TryGetDisplayIdByName(name, out var displayId))
                return null;

            return displayId;
        }

        /// <summary>
        /// Get the display ID for the GDI primary display.
        /// </summary>
        /// <returns>Display ID, or null if unavailable.</returns>
        public unsafe uint? GetGdiPrimaryDisplayId()
        {
            ThrowIfDisposed();

            var getPrimary = GetDelegate<NvApiDispGetGdiPrimaryDisplayIdDelegate>(
                NvApiIdDispGetGdiPrimaryDisplayId,
                "NvAPI_DISP_GetGDIPrimaryDisplayId");
            uint displayId = 0;
            var status = getPrimary(&displayId);
            if (status == _NvAPI_Status.NVAPI_OK)
                return displayId;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the supported view modes for this display handle.
        /// </summary>
        /// <returns>Supported view modes, or null if unavailable.</returns>
        public unsafe NVAPISupportedViewsDto? GetSupportedViews()
        {
            ThrowIfDisposed();

            var getViews = GetDelegate<NvApiGetSupportedViewsDelegate>(
                NvApiIdGetSupportedViews,
                "NvAPI_GetSupportedViews");
            uint viewCount = 0;
            var status = getViews(GetHandle(), null, &viewCount);
            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            if (viewCount == 0)
                return NVAPISupportedViewsDto.FromNative(Array.Empty<_NV_TARGET_VIEW_MODE>());

            var views = new _NV_TARGET_VIEW_MODE[viewCount];
            fixed (_NV_TARGET_VIEW_MODE* pViews = views)
            {
                status = getViews(GetHandle(), pViews, &viewCount);
            }

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            if (viewCount != views.Length)
            {
                var trimmed = new _NV_TARGET_VIEW_MODE[viewCount];
                Array.Copy(views, trimmed, (int)viewCount);
                views = trimmed;
            }

            return NVAPISupportedViewsDto.FromNative(views);
        }

        /// <summary>
        /// Get EDID data for the display.
        /// </summary>
        /// <param name="flag">EDID flag selection.</param>
        /// <returns>EDID data DTO, or null if unavailable.</returns>
        public unsafe NVAPIDisplayEdidDataDto? GetEdidData(NV_EDID_FLAG flag = NV_EDID_FLAG.NV_EDID_FLAG_DEFAULT)
        {
            ThrowIfDisposed();

            if (!TryGetDisplayId(out var displayId))
                return null;

            var getEdid = GetDelegate<NvApiDispGetEdidDataDelegate>(
                NvApiIdDispGetEdidData,
                "NvAPI_DISP_GetEdidData");

            var edid = CreateEdidData();

            var status = getEdid(displayId, &edid, &flag);
            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            if (status != _NvAPI_Status.NVAPI_OK && status != _NvAPI_Status.NVAPI_INSUFFICIENT_BUFFER)
                throw new NVAPIException(status);

            if (edid.sizeOfEDID == 0)
                return NVAPIDisplayEdidDataDto.FromNative(edid, flag);

            var data = new byte[edid.sizeOfEDID];
            fixed (byte* pData = data)
            {
                edid.pEDID = pData;
                status = getEdid(displayId, &edid, &flag);
                if (status == _NvAPI_Status.NVAPI_OK)
                    return NVAPIDisplayEdidDataDto.FromNative(edid, flag);
            }

            if (status == _NvAPI_Status.NVAPI_INSUFFICIENT_BUFFER && edid.sizeOfEDID > data.Length)
            {
                data = new byte[edid.sizeOfEDID];
                fixed (byte* pData = data)
                {
                    edid.pEDID = pData;
                    status = getEdid(displayId, &edid, &flag);
                    if (status == _NvAPI_Status.NVAPI_OK)
                        return NVAPIDisplayEdidDataDto.FromNative(edid, flag);
                }
            }

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get timing data based on timing input parameters.
        /// </summary>
        /// <param name="input">Timing input parameters.</param>
        /// <returns>Timing DTO, or null if unavailable.</returns>
        public unsafe NVAPITimingDto? GetTiming(NVAPITimingInputDto input)
        {
            ThrowIfDisposed();

            if (!TryGetDisplayId(out var displayId))
                return null;

            var getTiming = GetDelegate<NvApiDispGetTimingDelegate>(
                NvApiIdDispGetTiming,
                "NvAPI_DISP_GetTiming");

            var nativeInput = input.ToNative();

            var timing = new _NV_TIMING();
            var status = getTiming(displayId, &nativeInput, &timing);
            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            return NVAPITimingDto.FromNative(timing);
        }

        /// <summary>
        /// Get monitor capabilities for the display.
        /// </summary>
        /// <returns>Monitor capabilities DTO, or null if unavailable.</returns>
        public unsafe NVAPIMonitorCapabilitiesDto? GetMonitorCapabilities()
        {
            ThrowIfDisposed();

            if (!TryGetDisplayId(out var displayId))
                return null;

            var getCaps = GetDelegate<NvApiDispGetMonitorCapabilitiesDelegate>(
                NvApiIdDispGetMonitorCapabilities,
                "NvAPI_DISP_GetMonitorCapabilities");

            var caps = CreateMonitorCapabilities();

            var status = getCaps(displayId, &caps);
            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            return NVAPIMonitorCapabilitiesDto.FromNative(caps);
        }

        /// <summary>
        /// Get monitor color capabilities for the display.
        /// </summary>
        /// <returns>Monitor color capabilities DTO, or null if unavailable.</returns>
        public unsafe NVAPIMonitorColorCapabilitiesDto? GetMonitorColorCapabilities()
        {
            ThrowIfDisposed();

            if (!TryGetDisplayId(out var displayId))
                return null;

            var getCaps = GetDelegate<NvApiDispGetMonitorColorCapabilitiesDelegate>(
                NvApiIdDispGetMonitorColorCapabilities,
                "NvAPI_DISP_GetMonitorColorCapabilities");

            uint count = 0;
            var status = getCaps(displayId, null, &count);
            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            if (status != _NvAPI_Status.NVAPI_OK && status != _NvAPI_Status.NVAPI_INSUFFICIENT_BUFFER)
                throw new NVAPIException(status);

            if (count == 0)
                return NVAPIMonitorColorCapabilitiesDto.FromNative(Array.Empty<_NV_MONITOR_COLOR_DATA>());

            var caps = new _NV_MONITOR_COLOR_DATA[count];
            for (var i = 0; i < caps.Length; i++)
            {
                caps[i].version = NVAPI.NV_MONITOR_COLOR_CAPS_VER;
            }

            fixed (_NV_MONITOR_COLOR_DATA* pCaps = caps)
            {
                status = getCaps(displayId, pCaps, &count);
            }

            if (status == _NvAPI_Status.NVAPI_INSUFFICIENT_BUFFER && count > caps.Length)
            {
                caps = new _NV_MONITOR_COLOR_DATA[count];
                for (var i = 0; i < caps.Length; i++)
                {
                    caps[i].version = NVAPI.NV_MONITOR_COLOR_CAPS_VER;
                }

                fixed (_NV_MONITOR_COLOR_DATA* pCaps = caps)
                {
                    status = getCaps(displayId, pCaps, &count);
                }
            }

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            if (count != caps.Length)
            {
                var trimmed = new _NV_MONITOR_COLOR_DATA[count];
                Array.Copy(caps, trimmed, (int)count);
                caps = trimmed;
            }

            return NVAPIMonitorColorCapabilitiesDto.FromNative(caps);
        }

        /// <summary>
        /// Get display port information.
        /// </summary>
        /// <param name="outputId">Optional output ID override.</param>
        /// <returns>Display port info DTO, or null if unavailable.</returns>
        public unsafe NVAPIDisplayPortInfoDto? GetDisplayPortInfo(uint? outputId = null)
        {
            ThrowIfDisposed();

            if (!TryGetOutputId(outputId, out var resolvedOutputId))
                return null;

            var getInfo = GetDelegate<NvApiGetDisplayPortInfoDelegate>(
                NvApiIdGetDisplayPortInfo,
                "NvAPI_GetDisplayPortInfo");

            var info = CreateDisplayPortInfo();

            var status = getInfo(GetHandle(), resolvedOutputId, &info);
            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            return NVAPIDisplayPortInfoDto.FromNative(info);
        }

        /// <summary>
        /// Set display port configuration.
        /// </summary>
        /// <param name="config">Display port configuration DTO.</param>
        /// <param name="outputId">Optional output ID override.</param>
        /// <returns>True if applied, false if unavailable.</returns>
        public unsafe bool SetDisplayPort(NVAPIDisplayPortConfigDto config, uint? outputId = null)
        {
            ThrowIfDisposed();

            if (!TryGetOutputId(outputId, out var resolvedOutputId))
                return false;

            var setConfig = GetDelegate<NvApiSetDisplayPortDelegate>(
                NvApiIdSetDisplayPort,
                "NvAPI_SetDisplayPort");

            var nativeConfig = config.ToNative();
            var status = setConfig(GetHandle(), resolvedOutputId, &nativeConfig);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get HDMI support information.
        /// </summary>
        /// <param name="outputId">Optional output ID override.</param>
        /// <returns>HDMI support info DTO, or null if unavailable.</returns>
        public unsafe NVAPIDisplayHdmiSupportInfoDto? GetHdmiSupportInfo(uint? outputId = null)
        {
            ThrowIfDisposed();

            if (!TryGetOutputId(outputId, out var resolvedOutputId))
                return null;

            var getInfo = GetDelegate<NvApiGetHdmiSupportInfoDelegate>(
                NvApiIdGetHdmiSupportInfo,
                "NvAPI_GetHDMISupportInfo");

            var info = CreateHdmiSupportInfo();

            var status = getInfo(GetHandle(), resolvedOutputId, &info);
            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            return NVAPIDisplayHdmiSupportInfoDto.FromNative(info);
        }

        /// <summary>
        /// Get VRR information for this display.
        /// </summary>
        /// <returns>VRR info DTO, or null if unavailable.</returns>
        public unsafe NVAPIVrrInfoDto? GetVrrInfo()
        {
            ThrowIfDisposed();

            if (!TryGetDisplayId(out var displayId))
                return null;

            var getVrr = GetDelegate<NvApiDispGetVrrInfoDelegate>(
                NvApiIdDispGetVrrInfo,
                "NvAPI_Disp_GetVRRInfo");

            var info = CreateVrrInfo();

            var status = getVrr(displayId, &info);
            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            return NVAPIVrrInfoDto.FromNative(info);
        }

        /// <summary>
        /// Get adaptive sync data for this display.
        /// </summary>
        /// <returns>Adaptive sync data DTO, or null if unavailable.</returns>
        public unsafe NVAPIAdaptiveSyncGetDataDto? GetAdaptiveSyncData()
        {
            ThrowIfDisposed();

            if (!TryGetDisplayId(out var displayId))
                return null;

            var getData = GetDelegate<NvApiDispGetAdaptiveSyncDataDelegate>(
                NvApiIdDispGetAdaptiveSyncData,
                "NvAPI_DISP_GetAdaptiveSyncData");

            var data = CreateAdaptiveSyncGetData();

            var status = getData(displayId, &data);
            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            return NVAPIAdaptiveSyncGetDataDto.FromNative(data);
        }

        /// <summary>
        /// Set adaptive sync data for this display.
        /// </summary>
        /// <param name="data">Adaptive sync data DTO.</param>
        /// <returns>True if applied, false if unavailable.</returns>
        public unsafe bool SetAdaptiveSyncData(NVAPIAdaptiveSyncSetDataDto data)
        {
            ThrowIfDisposed();

            if (!TryGetDisplayId(out var displayId))
                return false;

            var setData = GetDelegate<NvApiDispSetAdaptiveSyncDataDelegate>(
                NvApiIdDispSetAdaptiveSyncData,
                "NvAPI_DISP_SetAdaptiveSyncData");

            var nativeData = data.ToNative();
            var status = setData(displayId, &nativeData);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get virtual refresh rate data for this display.
        /// </summary>
        /// <returns>Virtual refresh rate data DTO, or null if unavailable.</returns>
        public unsafe NVAPIVirtualRefreshRateDataDto? GetVirtualRefreshRateData()
        {
            ThrowIfDisposed();

            if (!TryGetDisplayId(out var displayId))
                return null;

            var getData = GetDelegate<NvApiDispGetVirtualRefreshRateDataDelegate>(
                NvApiIdDispGetVirtualRefreshRateData,
                "NvAPI_DISP_GetVirtualRefreshRateData");

            var data = CreateVirtualRefreshRateGetData();

            var status = getData(displayId, &data);
            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            return NVAPIVirtualRefreshRateDataDto.FromNative(data);
        }

        /// <summary>
        /// Set virtual refresh rate data for this display.
        /// </summary>
        /// <param name="data">Virtual refresh rate data DTO.</param>
        /// <returns>True if applied, false if unavailable.</returns>
        public unsafe bool SetVirtualRefreshRateData(NVAPIVirtualRefreshRateDataDto data)
        {
            ThrowIfDisposed();

            if (!TryGetDisplayId(out var displayId))
                return false;

            var setData = GetDelegate<NvApiDispSetVirtualRefreshRateDataDelegate>(
                NvApiIdDispSetVirtualRefreshRateData,
                "NvAPI_DISP_SetVirtualRefreshRateData");

            var nativeData = data.ToNative();

            var status = setData(displayId, &nativeData);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the preferred stereo display.
        /// </summary>
        /// <returns>Preferred stereo display DTO, or null if unavailable.</returns>
        public unsafe NVAPIPreferredStereoDisplayDto? GetPreferredStereoDisplay()
        {
            ThrowIfDisposed();

            var getDisplay = GetDelegate<NvApiDispGetPreferredStereoDisplayDelegate>(
                NvApiIdDispGetPreferredStereoDisplay,
                "NvAPI_DISP_GetPreferredStereoDisplay");

            var display = CreatePreferredStereoDisplayGet();

            var status = getDisplay(&display);
            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            return NVAPIPreferredStereoDisplayDto.FromNative(display);
        }

        /// <summary>
        /// Set the preferred stereo display.
        /// </summary>
        /// <param name="display">Preferred stereo display DTO.</param>
        /// <returns>True if applied, false if unavailable.</returns>
        public unsafe bool SetPreferredStereoDisplay(NVAPIPreferredStereoDisplayDto display)
        {
            ThrowIfDisposed();

            var setDisplay = GetDelegate<NvApiDispSetPreferredStereoDisplayDelegate>(
                NvApiIdDispSetPreferredStereoDisplay,
                "NvAPI_DISP_SetPreferredStereoDisplay");

            var nativeDisplay = display.ToNative();

            var status = setDisplay(&nativeDisplay);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Enable the hardware cursor for this display.
        /// </summary>
        /// <returns>True if enabled, false if unavailable.</returns>
        public unsafe bool EnableHWCursor()
        {
            ThrowIfDisposed();

            var enable = GetDelegate<NvApiEnableHwCursorDelegate>(
                NvApiIdEnableHwCursor,
                "NvAPI_EnableHWCursor");

            var status = enable(GetHandle());
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Disable the hardware cursor for this display.
        /// </summary>
        /// <returns>True if disabled, false if unavailable.</returns>
        public unsafe bool DisableHWCursor()
        {
            ThrowIfDisposed();

            var disable = GetDelegate<NvApiDisableHwCursorDelegate>(
                NvApiIdDisableHwCursor,
                "NvAPI_DisableHWCursor");

            var status = disable(GetHandle());
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Override the refresh rate for the specified output mask.
        /// </summary>
        /// <param name="outputsMask">Output mask to apply the override.</param>
        /// <param name="refreshRate">Refresh rate override (0.0 cancels).</param>
        /// <param name="setDeferred">True to defer to the next modeset.</param>
        /// <returns>True if applied, false if unavailable.</returns>
        public unsafe bool SetRefreshRateOverride(uint outputsMask, float refreshRate, bool setDeferred)
        {
            ThrowIfDisposed();

            var setOverride = GetDelegate<NvApiSetRefreshRateOverrideDelegate>(
                NvApiIdSetRefreshRateOverride,
                "NvAPI_SetRefreshRateOverride");

            var status = setOverride(GetHandle(), outputsMask, refreshRate, setDeferred ? 1u : 0u);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Control infoframe data for this display.
        /// </summary>
        /// <param name="data">Infoframe data DTO.</param>
        /// <returns>Updated infoframe data DTO, or null if unavailable.</returns>
        public unsafe NVAPIInfoFrameDataDto? InfoFrameControl(NVAPIInfoFrameDataDto data)
        {
            ThrowIfDisposed();

            if (!TryGetDisplayId(out var displayId))
                return null;

            var control = GetDelegate<NvApiDispInfoFrameControlDelegate>(
                NvApiIdDispInfoFrameControl,
                "NvAPI_Disp_InfoFrameControl");

            var native = data.ToNative();
            var status = control(displayId, &native);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIInfoFrameDataDto.FromNative(native);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Control display color data for this display.
        /// </summary>
        /// <param name="colorData">Color data DTO.</param>
        /// <returns>Updated color data DTO, or null if unavailable.</returns>
        public unsafe NVAPIDisplayColorDataDto? ColorControl(NVAPIDisplayColorDataDto colorData)
        {
            ThrowIfDisposed();

            if (!TryGetDisplayId(out var displayId))
                return null;

            var control = GetDelegate<NvApiDispColorControlDelegate>(
                NvApiIdDispColorControl,
                "NvAPI_Disp_ColorControl");

            var native = colorData.ToNative();
            var status = control(displayId, &native);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIDisplayColorDataDto.FromNative(native);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get HDR capabilities for this display.
        /// </summary>
        /// <returns>HDR capabilities DTO, or null if unavailable.</returns>
        public unsafe NVAPIHdrCapabilitiesDto? GetHdrCapabilities()
        {
            ThrowIfDisposed();

            if (!TryGetDisplayId(out var displayId))
                return null;

            var getCaps = GetDelegate<NvApiDispGetHdrCapabilitiesDelegate>(
                NvApiIdDispGetHdrCapabilities,
                "NvAPI_Disp_GetHdrCapabilities");

            var caps = CreateHdrCapabilities();
            var status = getCaps(displayId, &caps);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIHdrCapabilitiesDto.FromNative(caps);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Control HDR color settings for this display.
        /// </summary>
        /// <param name="hdrData">HDR color data DTO.</param>
        /// <returns>Updated HDR color data DTO, or null if unavailable.</returns>
        public unsafe NVAPIHdrColorDataDto? HdrColorControl(NVAPIHdrColorDataDto hdrData)
        {
            ThrowIfDisposed();

            if (!TryGetDisplayId(out var displayId))
                return null;

            var control = GetDelegate<NvApiDispHdrColorControlDelegate>(
                NvApiIdDispHdrColorControl,
                "NvAPI_Disp_HdrColorControl");

            var native = hdrData.ToNative();
            var status = control(displayId, &native);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIHdrColorDataDto.FromNative(native);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Set the source color space for this display.
        /// </summary>
        /// <param name="colorSpaceType">Source color space type.</param>
        /// <returns>True if applied, false if unavailable.</returns>
        public unsafe bool SetSourceColorSpace(_NV_COLORSPACE_TYPE colorSpaceType)
        {
            ThrowIfDisposed();

            if (!TryGetDisplayId(out var displayId))
                return false;

            var setColorSpace = GetDelegate<NvApiDispSetSourceColorSpaceDelegate>(
                NvApiIdDispSetSourceColorSpace,
                "NvAPI_Disp_SetSourceColorSpace");

            var status = setColorSpace(displayId, colorSpaceType);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the source color space for this display.
        /// </summary>
        /// <param name="sourcePid">Source process ID (NV_SOURCE_PID_CURRENT for current).</param>
        /// <returns>Source color space type, or null if unavailable.</returns>
        public unsafe _NV_COLORSPACE_TYPE? GetSourceColorSpace(ulong sourcePid = (ulong)NVAPI.NV_SOURCE_PID_CURRENT)
        {
            ThrowIfDisposed();

            if (!TryGetDisplayId(out var displayId))
                return null;

            var getColorSpace = GetDelegate<NvApiDispGetSourceColorSpaceDelegate>(
                NvApiIdDispGetSourceColorSpace,
                "NvAPI_Disp_GetSourceColorSpace");

            _NV_COLORSPACE_TYPE colorSpace = default;
            var status = getColorSpace(displayId, &colorSpace, sourcePid);
            if (status == _NvAPI_Status.NVAPI_OK)
                return colorSpace;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Set the source HDR metadata for this display.
        /// </summary>
        /// <param name="metadata">HDR metadata DTO.</param>
        /// <returns>True if applied, false if unavailable.</returns>
        public unsafe bool SetSourceHdrMetadata(NVAPIHdrMetadataDto metadata)
        {
            ThrowIfDisposed();

            if (!TryGetDisplayId(out var displayId))
                return false;

            var setMetadata = GetDelegate<NvApiDispSetSourceHdrMetadataDelegate>(
                NvApiIdDispSetSourceHdrMetadata,
                "NvAPI_Disp_SetSourceHdrMetadata");

            var native = metadata.ToNative();
            var status = setMetadata(displayId, &native);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the source HDR metadata for this display.
        /// </summary>
        /// <param name="sourcePid">Source process ID (NV_SOURCE_PID_CURRENT for current).</param>
        /// <returns>HDR metadata DTO, or null if unavailable.</returns>
        public unsafe NVAPIHdrMetadataDto? GetSourceHdrMetadata(ulong sourcePid = (ulong)NVAPI.NV_SOURCE_PID_CURRENT)
        {
            ThrowIfDisposed();

            if (!TryGetDisplayId(out var displayId))
                return null;

            var getMetadata = GetDelegate<NvApiDispGetSourceHdrMetadataDelegate>(
                NvApiIdDispGetSourceHdrMetadata,
                "NvAPI_Disp_GetSourceHdrMetadata");

            var metadata = CreateHdrMetadata();
            var status = getMetadata(displayId, &metadata, sourcePid);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIHdrMetadataDto.FromNative(metadata);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Set the display output mode for this display.
        /// </summary>
        /// <param name="displayMode">Desired output mode.</param>
        /// <returns>True if applied, false if unavailable.</returns>
        public unsafe bool SetOutputMode(_NV_DISPLAY_OUTPUT_MODE displayMode)
        {
            ThrowIfDisposed();

            if (!TryGetDisplayId(out var displayId))
                return false;

            var setMode = GetDelegate<NvApiDispSetOutputModeDelegate>(
                NvApiIdDispSetOutputMode,
                "NvAPI_Disp_SetOutputMode");

            var mode = displayMode;
            var status = setMode(displayId, &mode);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the display output mode for this display.
        /// </summary>
        /// <returns>Display output mode, or null if unavailable.</returns>
        public unsafe _NV_DISPLAY_OUTPUT_MODE? GetOutputMode()
        {
            ThrowIfDisposed();

            if (!TryGetDisplayId(out var displayId))
                return null;

            var getMode = GetDelegate<NvApiDispGetOutputModeDelegate>(
                NvApiIdDispGetOutputMode,
                "NvAPI_Disp_GetOutputMode");

            _NV_DISPLAY_OUTPUT_MODE mode = default;
            var status = getMode(displayId, &mode);
            if (status == _NvAPI_Status.NVAPI_OK)
                return mode;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Set the HDR tone mapping method for this display.
        /// </summary>
        /// <param name="hdrTonemapping">HDR tone mapping method.</param>
        /// <returns>True if applied, false if unavailable.</returns>
        public unsafe bool SetHdrToneMapping(_NV_HDR_TONEMAPPING_METHOD hdrTonemapping)
        {
            ThrowIfDisposed();

            if (!TryGetDisplayId(out var displayId))
                return false;

            var setToneMapping = GetDelegate<NvApiDispSetHdrToneMappingDelegate>(
                NvApiIdDispSetHdrToneMapping,
                "NvAPI_Disp_SetHdrToneMapping");

            var status = setToneMapping(displayId, hdrTonemapping);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the HDR tone mapping method for this display.
        /// </summary>
        /// <returns>HDR tone mapping method, or null if unavailable.</returns>
        public unsafe _NV_HDR_TONEMAPPING_METHOD? GetHdrToneMapping()
        {
            ThrowIfDisposed();

            if (!TryGetDisplayId(out var displayId))
                return null;

            var getToneMapping = GetDelegate<NvApiDispGetHdrToneMappingDelegate>(
                NvApiIdDispGetHdrToneMapping,
                "NvAPI_Disp_GetHdrToneMapping");

            _NV_HDR_TONEMAPPING_METHOD toneMapping = default;
            var status = getToneMapping(displayId, &toneMapping);
            if (status == _NvAPI_Status.NVAPI_OK)
                return toneMapping;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get display colorimetry information for this display.
        /// </summary>
        /// <returns>Display colorimetry DTO, or null if unavailable.</returns>
        public unsafe NVAPIDisplayColorimetryDto? GetColorimetry()
        {
            ThrowIfDisposed();

            if (!TryGetDisplayId(out var displayId))
                return null;

            var getColorimetry = GetDelegate<NvApiDispGetColorimetryDelegate>(
                NvApiIdDispGetColorimetry,
                "NvAPI_Disp_GetColorimetry");

            var colorimetry = CreateDisplayColorimetry();
            var status = getColorimetry(displayId, &colorimetry);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIDisplayColorimetryDto.FromNative(colorimetry);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get display ID info for this display.
        /// </summary>
        /// <param name="displayId">Optional display ID override.</param>
        /// <returns>Display ID info DTO, or null if unavailable.</returns>
        public unsafe NVAPIDisplayIdInfoDto? GetDisplayIdInfo(uint? displayId = null)
        {
            ThrowIfDisposed();

            if (!TryResolveDisplayId(displayId, out var resolvedDisplayId))
                return null;

            var getInfo = GetDelegate<NvApiDispGetDisplayIdInfoDelegate>(
                NvApiIdDispGetDisplayIdInfo,
                "NvAPI_Disp_GetDisplayIdInfo");

            var info = CreateDisplayIdInfoData();
            var status = getInfo(resolvedDisplayId, &info);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIDisplayIdInfoDto.FromNative(info);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED ||
                status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND ||
                status == _NvAPI_Status.NVAPI_INVALID_DISPLAY_ID)
            {
                return null;
            }

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get display IDs for the target associated with this display.
        /// </summary>
        /// <returns>Target info DTO, or null if unavailable.</returns>
        public unsafe NVAPITargetInfoDto? GetDisplayIdsFromTarget()
        {
            var info = GetDisplayIdInfo();
            if (info == null)
                return null;

            return GetDisplayIdsFromTarget(info.Value.AdapterLuid, info.Value.TargetId);
        }

        /// <summary>
        /// Get display IDs for the specified target.
        /// </summary>
        /// <param name="adapterLuid">Adapter LUID.</param>
        /// <param name="targetId">Target ID (AdapterRelativeId).</param>
        /// <returns>Target info DTO, or null if unavailable.</returns>
        public unsafe NVAPITargetInfoDto? GetDisplayIdsFromTarget(long adapterLuid, uint targetId)
        {
            ThrowIfDisposed();

            var getInfo = GetDelegate<NvApiDispGetDisplayIdsFromTargetDelegate>(
                NvApiIdDispGetDisplayIdsFromTarget,
                "NvAPI_Disp_GetDisplayIdsFromTarget");

            var info = CreateTargetInfoData();
            info.adapterId = CreateLuid(adapterLuid);
            info.targetId = targetId;

            var status = getInfo(&info);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPITargetInfoDto.FromNative(info);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED ||
                status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND ||
                status == _NvAPI_Status.NVAPI_INVALID_DISPLAY_ID)
            {
                return null;
            }

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Enumerate a custom display for the specified index.
        /// </summary>
        /// <param name="index">Custom display index.</param>
        /// <param name="displayId">Optional display ID override.</param>
        /// <returns>Custom display DTO, or null if unavailable.</returns>
        public unsafe NVAPICustomDisplayDto? EnumCustomDisplay(uint index, uint? displayId = null)
        {
            ThrowIfDisposed();

            if (!TryResolveDisplayId(displayId, out var resolvedDisplayId))
                return null;

            var enumCustom = GetDelegate<NvApiDispEnumCustomDisplayDelegate>(
                NvApiIdDispEnumCustomDisplay,
                "NvAPI_DISP_EnumCustomDisplay");

            var custom = CreateCustomDisplay();
            var status = enumCustom(resolvedDisplayId, index, &custom);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPICustomDisplayDto.FromNative(custom);

            if (status == _NvAPI_Status.NVAPI_END_ENUMERATION ||
                status == _NvAPI_Status.NVAPI_NOT_SUPPORTED ||
                status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
            {
                return null;
            }

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Try applying a custom display.
        /// </summary>
        /// <param name="displayIds">Display IDs to apply the custom display to.</param>
        /// <param name="customDisplays">Custom display DTO array.</param>
        /// <returns>True if applied, false if unavailable.</returns>
        public unsafe bool TryCustomDisplay(uint[] displayIds, NVAPICustomDisplayDto[] customDisplays)
        {
            ThrowIfDisposed();

            if (displayIds == null || customDisplays == null || displayIds.Length == 0)
                return false;

            if (displayIds.Length != customDisplays.Length)
                return false;

            var tryCustom = GetDelegate<NvApiDispTryCustomDisplayDelegate>(
                NvApiIdDispTryCustomDisplay,
                "NvAPI_DISP_TryCustomDisplay");

            fixed (uint* pDisplayIds = displayIds)
            {
                var natives = new NV_CUSTOM_DISPLAY[customDisplays.Length];
                for (var i = 0; i < customDisplays.Length; i++)
                {
                    natives[i] = customDisplays[i].ToNative();
                }

                fixed (NV_CUSTOM_DISPLAY* pCustom = natives)
                {
                    var status = tryCustom(pDisplayIds, (uint)displayIds.Length, pCustom);
                    if (status == _NvAPI_Status.NVAPI_OK)
                        return true;

                    if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                        return false;

                    throw new NVAPIException(status);
                }
            }
        }

        /// <summary>
        /// Get the display helper associated with a display name (e.g., "\\.\DISPLAY1").
        /// </summary>
        /// <param name="displayName">Display name to resolve. If null, uses this display handle's name.</param>
        /// <returns>Display helper, or null if unavailable.</returns>
        public unsafe NVAPIDisplayHelper? GetAssociatedNvidiaDisplayHandle(string? displayName = null)
        {
            ThrowIfDisposed();

            if (string.IsNullOrWhiteSpace(displayName))
            {
                displayName = GetAssociatedNvidiaDisplayName();
                if (string.IsNullOrWhiteSpace(displayName))
                    return null;
            }

            var getHandle = GetDelegate<NvApiGetAssociatedNvidiaDisplayHandleDelegate>(
                NvApiIdGetAssociatedNvidiaDisplayHandle,
                "NvAPI_GetAssociatedNvidiaDisplayHandle");

            var bytes = Encoding.ASCII.GetBytes(displayName + "\0");
            fixed (byte* pBytes = bytes)
            {
                NvDisplayHandle__* handle = null;
                var status = getHandle((sbyte*)pBytes, &handle);
                if (status == _NvAPI_Status.NVAPI_OK)
                    return new NVAPIDisplayHelper(_apiHelper, (IntPtr)handle);

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED ||
                    status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND ||
                    status == _NvAPI_Status.NVAPI_INVALID_ARGUMENT)
                {
                    return null;
                }

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Delete a custom display.
        /// </summary>
        /// <param name="displayIds">Display IDs to delete the custom display from.</param>
        /// <param name="customDisplays">Custom display DTO array.</param>
        /// <returns>True if applied, false if unavailable.</returns>
        public unsafe bool DeleteCustomDisplay(uint[] displayIds, NVAPICustomDisplayDto[] customDisplays)
        {
            ThrowIfDisposed();

            if (displayIds == null || customDisplays == null || displayIds.Length == 0)
                return false;

            if (displayIds.Length != customDisplays.Length)
                return false;

            var deleteCustom = GetDelegate<NvApiDispDeleteCustomDisplayDelegate>(
                NvApiIdDispDeleteCustomDisplay,
                "NvAPI_DISP_DeleteCustomDisplay");

            fixed (uint* pDisplayIds = displayIds)
            {
                var natives = new NV_CUSTOM_DISPLAY[customDisplays.Length];
                for (var i = 0; i < customDisplays.Length; i++)
                {
                    natives[i] = customDisplays[i].ToNative();
                }

                fixed (NV_CUSTOM_DISPLAY* pCustom = natives)
                {
                    var status = deleteCustom(pDisplayIds, (uint)displayIds.Length, pCustom);
                    if (status == _NvAPI_Status.NVAPI_OK)
                        return true;

                    if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                        return false;

                    throw new NVAPIException(status);
                }
            }
        }

        /// <summary>
        /// Save custom display settings for the specified displays.
        /// </summary>
        /// <param name="displayIds">Display IDs to save.</param>
        /// <param name="isThisOutputIdOnly">True to apply only to the output ID.</param>
        /// <param name="isThisMonitorIdOnly">True to apply only to the monitor ID.</param>
        /// <returns>True if applied, false if unavailable.</returns>
        public unsafe bool SaveCustomDisplay(uint[] displayIds, bool isThisOutputIdOnly, bool isThisMonitorIdOnly)
        {
            ThrowIfDisposed();

            if (displayIds == null || displayIds.Length == 0)
                return false;

            var saveCustom = GetDelegate<NvApiDispSaveCustomDisplayDelegate>(
                NvApiIdDispSaveCustomDisplay,
                "NvAPI_DISP_SaveCustomDisplay");

            fixed (uint* pDisplayIds = displayIds)
            {
                var status = saveCustom(
                    pDisplayIds,
                    (uint)displayIds.Length,
                    isThisOutputIdOnly ? 1u : 0u,
                    isThisMonitorIdOnly ? 1u : 0u);

                if (status == _NvAPI_Status.NVAPI_OK)
                    return true;

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return false;

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Revert custom display trial for the specified displays.
        /// </summary>
        /// <param name="displayIds">Display IDs to revert.</param>
        /// <returns>True if applied, false if unavailable.</returns>
        public unsafe bool RevertCustomDisplayTrial(uint[] displayIds)
        {
            ThrowIfDisposed();

            if (displayIds == null || displayIds.Length == 0)
                return false;

            var revert = GetDelegate<NvApiDispRevertCustomDisplayTrialDelegate>(
                NvApiIdDispRevertCustomDisplayTrial,
                "NvAPI_DISP_RevertCustomDisplayTrial");

            fixed (uint* pDisplayIds = displayIds)
            {
                var status = revert(pDisplayIds, (uint)displayIds.Length);
                if (status == _NvAPI_Status.NVAPI_OK)
                    return true;

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return false;

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Get NVIDIA managed dedicated display info entries.
        /// </summary>
        /// <returns>Array of managed dedicated display info DTOs, or empty if unavailable.</returns>
        public unsafe NVAPINvManagedDedicatedDisplayInfoDto[] GetNvManagedDedicatedDisplays()
        {
            ThrowIfDisposed();

            var getDisplays = GetDelegate<NvApiDispGetNvManagedDedicatedDisplaysDelegate>(
                NvApiIdDispGetNvManagedDedicatedDisplays,
                "NvAPI_DISP_GetNvManagedDedicatedDisplays");

            uint count = 0;
            var status = getDisplays(&count, null);
            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return Array.Empty<NVAPINvManagedDedicatedDisplayInfoDto>();

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            if (count == 0)
                return Array.Empty<NVAPINvManagedDedicatedDisplayInfoDto>();

            var infos = new _NV_MANAGED_DEDICATED_DISPLAY_INFO[count];
            for (var i = 0; i < infos.Length; i++)
            {
                infos[i].version = NVAPI.NV_MANAGED_DEDICATED_DISPLAY_INFO_VER;
            }

            fixed (_NV_MANAGED_DEDICATED_DISPLAY_INFO* pInfos = infos)
            {
                status = getDisplays(&count, pInfos);
                if (status == _NvAPI_Status.NVAPI_OK)
                {
                    if (count != infos.Length)
                    {
                        var trimmed = new _NV_MANAGED_DEDICATED_DISPLAY_INFO[count];
                        Array.Copy(infos, trimmed, (int)count);
                        infos = trimmed;
                    }

                    return NVAPINvManagedDedicatedDisplayInfoDto.FromNative(infos);
                }

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return Array.Empty<NVAPINvManagedDedicatedDisplayInfoDto>();

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Acquire a managed dedicated display.
        /// </summary>
        /// <param name="displayId">Optional display ID override.</param>
        /// <returns>Display source handle, or null if unavailable.</returns>
        public unsafe ulong? AcquireDedicatedDisplay(uint? displayId = null)
        {
            ThrowIfDisposed();

            if (!TryResolveDisplayId(displayId, out var resolvedDisplayId))
                return null;

            var acquire = GetDelegate<NvApiDispAcquireDedicatedDisplayDelegate>(
                NvApiIdDispAcquireDedicatedDisplay,
                "NvAPI_DISP_AcquireDedicatedDisplay");

            ulong handle = 0;
            var status = acquire(resolvedDisplayId, &handle);
            if (status == _NvAPI_Status.NVAPI_OK)
                return handle;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED ||
                status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND ||
                status == _NvAPI_Status.NVAPI_UNREGISTERED_RESOURCE ||
                status == _NvAPI_Status.NVAPI_RESOURCE_IN_USE ||
                status == _NvAPI_Status.NVAPI_INVALID_DISPLAY_ID)
            {
                return null;
            }

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Release a managed dedicated display.
        /// </summary>
        /// <param name="displayId">Optional display ID override.</param>
        /// <returns>True if released, false if unavailable.</returns>
        public unsafe bool ReleaseDedicatedDisplay(uint? displayId = null)
        {
            ThrowIfDisposed();

            if (!TryResolveDisplayId(displayId, out var resolvedDisplayId))
                return false;

            var release = GetDelegate<NvApiDispReleaseDedicatedDisplayDelegate>(
                NvApiIdDispReleaseDedicatedDisplay,
                "NvAPI_DISP_ReleaseDedicatedDisplay");

            var status = release(resolvedDisplayId);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED ||
                status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND ||
                status == _NvAPI_Status.NVAPI_UNREGISTERED_RESOURCE ||
                status == _NvAPI_Status.NVAPI_RESOURCE_NOT_ACQUIRED ||
                status == _NvAPI_Status.NVAPI_INVALID_DISPLAY_ID)
            {
                return false;
            }

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get metadata for a managed dedicated display.
        /// </summary>
        /// <param name="displayId">Display ID to query.</param>
        /// <returns>Managed dedicated display metadata DTO, or null if unavailable.</returns>
        public unsafe NVAPINvManagedDedicatedDisplayMetadataDto? GetNvManagedDedicatedDisplayMetadata(uint displayId)
        {
            ThrowIfDisposed();

            var getMetadata = GetDelegate<NvApiDispGetNvManagedDedicatedDisplayMetadataDelegate>(
                NvApiIdDispGetNvManagedDedicatedDisplayMetadata,
                "NvAPI_DISP_GetNvManagedDedicatedDisplayMetadata");

            var metadata = CreateManagedDedicatedDisplayMetadata();
            metadata.displayId = displayId;

            var status = getMetadata(&metadata);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPINvManagedDedicatedDisplayMetadataDto.FromNative(metadata);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Set metadata for a managed dedicated display.
        /// </summary>
        /// <param name="metadata">Managed dedicated display metadata DTO.</param>
        /// <returns>True if applied, false if unavailable.</returns>
        public unsafe bool SetNvManagedDedicatedDisplayMetadata(NVAPINvManagedDedicatedDisplayMetadataDto metadata)
        {
            ThrowIfDisposed();

            var setMetadata = GetDelegate<NvApiDispSetNvManagedDedicatedDisplayMetadataDelegate>(
                NvApiIdDispSetNvManagedDedicatedDisplayMetadata,
                "NvAPI_DISP_SetNvManagedDedicatedDisplayMetadata");

            var native = metadata.ToNative();
            var status = setMetadata(&native);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        private unsafe bool TryGetDisplayId(out uint displayId)
        {
            if (DisplayId != 0)
            {
                displayId = DisplayId;
                return true;
            }

            displayId = 0;
            var name = GetAssociatedNvidiaDisplayName();
            if (string.IsNullOrWhiteSpace(name))
                return false;

            return TryGetDisplayIdByName(name, out displayId);
        }

        private unsafe bool TryGetDisplayIdByName(string displayName, out uint displayId)
        {
            displayId = 0;

            var getDisplayId = GetDelegate<NvApiDispGetDisplayIdByDisplayNameDelegate>(
                NvApiIdDispGetDisplayIdByDisplayName,
                "NvAPI_DISP_GetDisplayIdByDisplayName");

            var bytes = Encoding.ASCII.GetBytes(displayName + "\0");
            fixed (byte* pBytes = bytes)
            {
                uint id = 0;
                var status = getDisplayId((sbyte*)pBytes, &id);
                if (status == _NvAPI_Status.NVAPI_OK)
                {
                    displayId = id;
                    return true;
                }

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED ||
                    status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND ||
                    status == _NvAPI_Status.NVAPI_INVALID_ARGUMENT)
                {
                    return false;
                }

                throw new NVAPIException(status);
            }
        }

        private bool TryResolveDisplayId(uint? displayId, out uint resolvedDisplayId)
        {
            if (displayId.HasValue)
            {
                resolvedDisplayId = displayId.Value;
                return true;
            }

            return TryGetDisplayId(out resolvedDisplayId);
        }

        private uint TryGetDisplayIdNoThrow()
        {
            try
            {
                var name = GetAssociatedNvidiaDisplayName();
                if (string.IsNullOrWhiteSpace(name))
                    return 0;

                if (TryGetDisplayIdByName(name, out var displayId))
                    return displayId;
            }
            catch (NVAPIException)
            {
                return 0;
            }

            return 0;
        }

        internal static _LUID CreateLuid(long adapterLuid)
        {
            return new _LUID
            {
                LowPart = unchecked((uint)adapterLuid),
                HighPart = unchecked((int)(adapterLuid >> 32))
            };
        }

        internal static long ReadLuid(_LUID luid)
        {
            return ((long)luid.HighPart << 32) | (uint)luid.LowPart;
        }

        private bool TryGetOutputId(uint? outputId, out uint resolvedOutputId)
        {
            resolvedOutputId = 0;
            if (outputId.HasValue)
            {
                resolvedOutputId = outputId.Value;
                return true;
            }

            var associated = GetAssociatedDisplayOutputId();
            if (associated == null)
                return false;

            resolvedOutputId = associated.Value;
            return true;
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

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGetAssociatedNvidiaDisplayNameDelegate(NvDisplayHandle__* hNvDisp, sbyte* szDisplayName);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGetAssociatedNvidiaDisplayHandleDelegate(sbyte* displayName, NvDisplayHandle__** displayHandle);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGetAssociatedDisplayOutputIdDelegate(NvDisplayHandle__* hNvDisp, uint* pOutputId);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiSysGetGpuAndOutputIdFromDisplayIdDelegate(uint displayId, NvPhysicalGpuHandle__** hPhysicalGpu, uint* outputId);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiSysGetPhysicalGpuFromDisplayIdDelegate(uint displayId, NvPhysicalGpuHandle__** hPhysicalGpu);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGetVBlankCounterDelegate(NvDisplayHandle__* hNvDisp, uint* pCounter);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispGetDisplayConfigDelegate(uint* pathInfoCount, _NV_DISPLAYCONFIG_PATH_INFO* pathInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispSetDisplayConfigDelegate(uint pathInfoCount, _NV_DISPLAYCONFIG_PATH_INFO* pathInfo, uint flags);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispGetDisplayIdByDisplayNameDelegate(sbyte* displayName, uint* displayId);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispGetGdiPrimaryDisplayIdDelegate(uint* displayId);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGetSupportedViewsDelegate(NvDisplayHandle__* hNvDisplay, _NV_TARGET_VIEW_MODE* pTargetViews, uint* pViewCount);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispGetEdidDataDelegate(uint displayId, _NV_EDID_DATA_V2* pEdidParams, NV_EDID_FLAG* pFlag);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispGetTimingDelegate(uint displayId, _NV_TIMING_INPUT* timingInput, _NV_TIMING* pTiming);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispGetMonitorCapabilitiesDelegate(uint displayId, _NV_MONITOR_CAPABILITIES_V1* pMonitorCapabilities);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispGetMonitorColorCapabilitiesDelegate(uint displayId, _NV_MONITOR_COLOR_DATA* pMonitorColorCapabilities, uint* pColorCapsCount);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGetDisplayPortInfoDelegate(NvDisplayHandle__* hNvDisplay, uint outputId, _NV_DISPLAY_PORT_INFO_V1* pInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiSetDisplayPortDelegate(NvDisplayHandle__* hNvDisplay, uint outputId, NV_DISPLAY_PORT_CONFIG* pCfg);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGetHdmiSupportInfoDelegate(NvDisplayHandle__* hNvDisplay, uint outputId, _NV_HDMI_SUPPORT_INFO_V2* pInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispGetVrrInfoDelegate(uint displayId, _NV_GET_VRR_INFO_V1* pVrrInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispGetAdaptiveSyncDataDelegate(uint displayId, _NV_GET_ADAPTIVE_SYNC_DATA_V1* pAdaptiveSyncData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispSetAdaptiveSyncDataDelegate(uint displayId, _NV_SET_ADAPTIVE_SYNC_DATA_V1* pAdaptiveSyncData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispGetVirtualRefreshRateDataDelegate(uint displayId, _NV_GET_VIRTUAL_REFRESH_RATE_DATA_V2* pVirtualRefreshRateData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispSetVirtualRefreshRateDataDelegate(uint displayId, _NV_SET_VIRTUAL_REFRESH_RATE_DATA_V2* pVirtualRefreshRateData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispSetPreferredStereoDisplayDelegate(NV_SET_PREFERRED_STEREO_DISPLAY_V1* pPreferredStereoDisplay);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispGetPreferredStereoDisplayDelegate(NV_GET_PREFERRED_STEREO_DISPLAY_V1* pPreferredStereoDisplay);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiEnableHwCursorDelegate(NvDisplayHandle__* hNvDisplay);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDisableHwCursorDelegate(NvDisplayHandle__* hNvDisplay);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiSetRefreshRateOverrideDelegate(NvDisplayHandle__* hNvDisplay, uint outputsMask, float refreshRate, uint bSetDeferred);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispInfoFrameControlDelegate(uint displayId, NV_INFOFRAME_DATA* pInfoframeData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispColorControlDelegate(uint displayId, _NV_COLOR_DATA_V5* pColorData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispGetHdrCapabilitiesDelegate(uint displayId, _NV_HDR_CAPABILITIES_V3* pHdrCapabilities);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispHdrColorControlDelegate(uint displayId, _NV_HDR_COLOR_DATA_V2* pHdrColorData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispSetSourceColorSpaceDelegate(uint displayId, _NV_COLORSPACE_TYPE colorSpaceType);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispGetSourceColorSpaceDelegate(uint displayId, _NV_COLORSPACE_TYPE* pColorSpaceType, ulong sourcePid);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispSetSourceHdrMetadataDelegate(uint displayId, _NV_HDR_METADATA_V1* pMetadata);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispGetSourceHdrMetadataDelegate(uint displayId, _NV_HDR_METADATA_V1* pMetadata, ulong sourcePid);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispSetOutputModeDelegate(uint displayId, _NV_DISPLAY_OUTPUT_MODE* pDisplayMode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispGetOutputModeDelegate(uint displayId, _NV_DISPLAY_OUTPUT_MODE* pDisplayMode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispSetHdrToneMappingDelegate(uint displayId, _NV_HDR_TONEMAPPING_METHOD hdrTonemapping);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispGetHdrToneMappingDelegate(uint displayId, _NV_HDR_TONEMAPPING_METHOD* pHdrTonemapping);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispGetColorimetryDelegate(uint displayId, _NV_DISPLAY_COLORIMETRY_V1* pColorimetry);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispEnumCustomDisplayDelegate(uint displayId, uint index, NV_CUSTOM_DISPLAY* pCustDisp);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispTryCustomDisplayDelegate(uint* pDisplayIds, uint count, NV_CUSTOM_DISPLAY* pCustDisp);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispDeleteCustomDisplayDelegate(uint* pDisplayIds, uint count, NV_CUSTOM_DISPLAY* pCustDisp);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispSaveCustomDisplayDelegate(uint* pDisplayIds, uint count, uint isThisOutputIdOnly, uint isThisMonitorIdOnly);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispRevertCustomDisplayTrialDelegate(uint* pDisplayIds, uint count);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispGetNvManagedDedicatedDisplaysDelegate(uint* pDedicatedDisplayCount, _NV_MANAGED_DEDICATED_DISPLAY_INFO* pDedicatedDisplays);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispAcquireDedicatedDisplayDelegate(uint displayId, ulong* pDisplaySourceHandle);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispReleaseDedicatedDisplayDelegate(uint displayId);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispGetNvManagedDedicatedDisplayMetadataDelegate(_NV_MANAGED_DEDICATED_DISPLAY_METADATA* pDedicatedDisplayMetadata);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispSetNvManagedDedicatedDisplayMetadataDelegate(_NV_MANAGED_DEDICATED_DISPLAY_METADATA* pDedicatedDisplayMetadata);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispGetDisplayIdInfoDelegate(uint displayId, _NV_DISPLAY_ID_INFO_DATA_V1* pDisplayIdInfoData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispGetDisplayIdsFromTargetDelegate(_NV_TARGET_INFO_DATA_V1* pTargetInfoData);

        [StructLayout(LayoutKind.Sequential)]
        private struct Luid
        {
            public uint LowPart;
            public int HighPart;
        }

        internal sealed class DisplayConfigBuffer : IDisposable
        {
            private readonly List<IntPtr> _allocations = new List<IntPtr>();
            private bool _disposed;

            /// <summary>
            /// Gets the native path info pointer.
            /// </summary>
            public unsafe _NV_DISPLAYCONFIG_PATH_INFO* PathInfo { get; }

            /// <summary>
            /// Gets the number of paths allocated in the buffer.
            /// </summary>
            public uint PathCount { get; }

            /// <summary>
            /// Initialize a new display configuration buffer for a given number of paths.
            /// </summary>
            /// <param name="pathCount">Number of display config paths to allocate.</param>
            public unsafe DisplayConfigBuffer(uint pathCount)
            {
                PathCount = pathCount;
                var size = checked((int)pathCount) * sizeof(_NV_DISPLAYCONFIG_PATH_INFO);
                var pathPtr = Marshal.AllocHGlobal(size);
                _allocations.Add(pathPtr);
                PathInfo = (_NV_DISPLAYCONFIG_PATH_INFO*)pathPtr;
                new Span<byte>((void*)pathPtr, size).Clear();
            }

            ~DisplayConfigBuffer()
            {
                Dispose(false);
            }

            /// <summary>
            /// Initialize version fields for the path info entries.
            /// </summary>
            public unsafe void InitializePathInfoVersions()
            {
                for (var i = 0; i < PathCount; i++)
                {
                    PathInfo[i].version = NVAPI.NV_DISPLAYCONFIG_PATH_INFO_VER;
                }
            }

            /// <summary>
            /// Allocate nested buffers for source and target info entries.
            /// </summary>
            public unsafe void AllocateNestedBuffers()
            {
                for (var i = 0; i < PathCount; i++)
                {
                    var path = &PathInfo[i];
                    if (path->version == NVAPI.NV_DISPLAYCONFIG_PATH_INFO_VER1 ||
                        path->version == NVAPI.NV_DISPLAYCONFIG_PATH_INFO_VER2 ||
                        path->version == NVAPI.NV_DISPLAYCONFIG_PATH_INFO_VER)
                    {
                        var sourcePtr = Marshal.AllocHGlobal(sizeof(_NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1));
                        _allocations.Add(sourcePtr);
                        new Span<byte>((void*)sourcePtr, sizeof(_NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1)).Clear();
                        path->sourceModeInfo = (_NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1*)sourcePtr;
                    }

                    if (path->targetInfoCount == 0)
                        continue;

                    var targetSize = checked((int)path->targetInfoCount) * sizeof(_NV_DISPLAYCONFIG_PATH_TARGET_INFO_V2);
                    var targetPtr = Marshal.AllocHGlobal(targetSize);
                    _allocations.Add(targetPtr);
                    new Span<byte>((void*)targetPtr, targetSize).Clear();
                    path->targetInfo = (_NV_DISPLAYCONFIG_PATH_TARGET_INFO_V2*)targetPtr;

                    for (var j = 0; j < path->targetInfoCount; j++)
                    {
                        var detailsPtr = Marshal.AllocHGlobal(sizeof(_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1));
                        _allocations.Add(detailsPtr);
                        new Span<byte>((void*)detailsPtr, sizeof(_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1)).Clear();
                        var details = (_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1*)detailsPtr;
                        details->version = NVAPI.NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_VER;
                        path->targetInfo[j].details = details;
                    }
                }
            }

            /// <summary>
            /// Track an additional allocation for cleanup.
            /// </summary>
            /// <param name="ptr">Pointer to track.</param>
            public void TrackAllocation(IntPtr ptr)
            {
                _allocations.Add(ptr);
            }

            /// <summary>
            /// Dispose the buffer and free all tracked allocations.
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

                for (var i = _allocations.Count - 1; i >= 0; i--)
                {
                    Marshal.FreeHGlobal(_allocations[i]);
                }

                _disposed = true;
            }
        }

        internal static unsafe NVAPIDisplayConfigDto CreateDisplayConfigInfo(uint pathCount, _NV_DISPLAYCONFIG_PATH_INFO* pathInfo)
        {
            var paths = new NVAPIDisplayConfigPathDto[pathCount];
            for (var i = 0; i < pathCount; i++)
            {
                var path = &pathInfo[i];
                var source = CreateSourceModeInfo(path->sourceModeInfo);
                var targets = CreateTargets(path->targetInfoCount, path->targetInfo);
                var osAdapterLuid = ReadOsAdapterLuid(path->pOSAdapterID);

                paths[i] = new NVAPIDisplayConfigPathDto(
                    path->version,
                    path->sourceId,
                    path->IsNonNVIDIAAdapter != 0,
                    osAdapterLuid,
                    source,
                    targets);
            }

            return new NVAPIDisplayConfigDto(paths);
        }

        internal static unsafe NVAPIDisplayConfigSourceModeDto? CreateSourceModeInfo(_NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1* sourcePtr)
        {
            if (sourcePtr == null)
                return null;

            var source = *sourcePtr;
            return new NVAPIDisplayConfigSourceModeDto(
                source.resolution,
                source.colorFormat,
                source.position,
                source.spanningOrientation,
                source.bGDIPrimary != 0,
                source.bSLIFocus != 0);
        }

        internal static unsafe NVAPIDisplayConfigTargetDto[] CreateTargets(uint targetCount, _NV_DISPLAYCONFIG_PATH_TARGET_INFO_V2* targetPtr)
        {
            if (targetCount == 0 || targetPtr == null)
                return Array.Empty<NVAPIDisplayConfigTargetDto>();

            var targets = new NVAPIDisplayConfigTargetDto[targetCount];
            for (var i = 0; i < targetCount; i++)
            {
                var target = targetPtr[i];
                var details = CreateAdvancedTargetInfo(target.details);
                targets[i] = new NVAPIDisplayConfigTargetDto(target.displayId, target.targetId, details);
            }

            return targets;
        }

        internal static unsafe NVAPIDisplayConfigAdvancedTargetDto? CreateAdvancedTargetInfo(_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1* detailsPtr)
        {
            if (detailsPtr == null)
                return null;

            var details = *detailsPtr;
            return new NVAPIDisplayConfigAdvancedTargetDto(
                details.rotation,
                details.scaling,
                details.refreshRate1K,
                details.interlaced != 0,
                details.primary != 0,
                details.disableVirtualModeSupport != 0,
                details.isPreferredUnscaledTarget != 0,
                details.connector,
                details.tvFormat,
                details.timingOverride,
                details.timing);
        }

        internal static unsafe long? ReadOsAdapterLuid(void* osAdapterId)
        {
            if (osAdapterId == null)
                return null;

            var luid = (Luid*)osAdapterId;
            var value = ((long)luid->HighPart << 32) | luid->LowPart;
            return value;
        }

        internal static unsafe DisplayConfigBuffer CreateDisplayConfigBuffer(NVAPIDisplayConfigPathDto[] paths)
        {
            var buffer = new DisplayConfigBuffer((uint)paths.Length);
            var pathInfo = buffer.PathInfo;

            for (var i = 0; i < paths.Length; i++)
            {
                var path = paths[i];
                var nativePath = &pathInfo[i];
                nativePath->version = NVAPI.NV_DISPLAYCONFIG_PATH_INFO_VER;
                nativePath->sourceId = path.SourceId;
                nativePath->IsNonNVIDIAAdapter = path.IsNonNvidiaAdapter ? 1u : 0u;
                nativePath->reserved = 0;

                if (path.OsAdapterLuid.HasValue)
                {
                    var luidPtr = Marshal.AllocHGlobal(sizeof(Luid));
                    buffer.TrackAllocation(luidPtr);
                    var luid = (Luid*)luidPtr;
                    var value = path.OsAdapterLuid.Value;
                    luid->LowPart = unchecked((uint)value);
                    luid->HighPart = unchecked((int)(value >> 32));
                    nativePath->pOSAdapterID = luid;
                }

                if (path.SourceModeInfo.HasValue)
                {
                    var sourcePtr = Marshal.AllocHGlobal(sizeof(_NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1));
                    buffer.TrackAllocation(sourcePtr);
                    var source = (_NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1*)sourcePtr;
                    new Span<byte>((void*)sourcePtr, sizeof(_NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1)).Clear();
                    FillSourceModeInfo(source, path.SourceModeInfo.Value);
                    nativePath->sourceModeInfo = source;
                }

                var targets = path.Targets ?? Array.Empty<NVAPIDisplayConfigTargetDto>();
                nativePath->targetInfoCount = (uint)targets.Length;

                if (targets.Length > 0)
                {
                    var targetSize = checked(targets.Length) * sizeof(_NV_DISPLAYCONFIG_PATH_TARGET_INFO_V2);
                    var targetPtr = Marshal.AllocHGlobal(targetSize);
                    buffer.TrackAllocation(targetPtr);
                    new Span<byte>((void*)targetPtr, targetSize).Clear();
                    nativePath->targetInfo = (_NV_DISPLAYCONFIG_PATH_TARGET_INFO_V2*)targetPtr;

                    for (var t = 0; t < targets.Length; t++)
                    {
                        var target = &nativePath->targetInfo[t];
                        target->displayId = targets[t].DisplayId;
                        target->targetId = targets[t].TargetId;

                        if (targets[t].Details.HasValue)
                        {
                            var detailsPtr = Marshal.AllocHGlobal(sizeof(_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1));
                            buffer.TrackAllocation(detailsPtr);
                            var details = (_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1*)detailsPtr;
                            new Span<byte>((void*)detailsPtr, sizeof(_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1)).Clear();
                            FillAdvancedTargetInfo(details, targets[t].Details.GetValueOrDefault());
                            target->details = details;
                        }
                    }
                }
            }

            return buffer;
        }

        private static unsafe void FillSourceModeInfo(_NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1* source, NVAPIDisplayConfigSourceModeDto info)
        {
            source->resolution = info.Resolution;
            source->colorFormat = info.ColorFormat;
            source->position = info.Position;
            source->spanningOrientation = info.SpanningOrientation;
            source->bGDIPrimary = info.IsGdiPrimary ? 1u : 0u;
            source->bSLIFocus = info.IsSliFocus ? 1u : 0u;
            source->reserved = 0;
        }

        private static unsafe void FillAdvancedTargetInfo(_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1* details, NVAPIDisplayConfigAdvancedTargetDto info)
        {
            details->version = NVAPI.NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_VER;
            details->rotation = info.Rotation;
            details->scaling = info.Scaling;
            details->refreshRate1K = info.RefreshRate1K;
            details->interlaced = info.Interlaced ? 1u : 0u;
            details->primary = info.Primary ? 1u : 0u;
            details->disableVirtualModeSupport = info.DisableVirtualModeSupport ? 1u : 0u;
            details->isPreferredUnscaledTarget = info.IsPreferredUnscaledTarget ? 1u : 0u;
            details->connector = info.Connector;
            details->tvFormat = info.TvFormat;
            details->timingOverride = info.TimingOverride;
            details->timing = info.Timing;
            details->reserved = 0;
        }
    }

    /// <summary>
    /// TV-related enum values surfaced alongside the display helper.
    /// </summary>
    public static class NVAPIDisplayTvEnums
    {
        /// <summary>
        /// TV format values (native enum names preserved).
        /// </summary>
        public static class Format
        {
            public const _NV_DISPLAY_TV_FORMAT None = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_NONE;
            public const _NV_DISPLAY_TV_FORMAT SdNtscM = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_SD_NTSCM;
            public const _NV_DISPLAY_TV_FORMAT SdNtscJ = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_SD_NTSCJ;
            public const _NV_DISPLAY_TV_FORMAT SdPalM = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_SD_PALM;
            public const _NV_DISPLAY_TV_FORMAT SdPalBdgh = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_SD_PALBDGH;
            public const _NV_DISPLAY_TV_FORMAT SdPalN = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_SD_PALN;
            public const _NV_DISPLAY_TV_FORMAT SdPalNc = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_SD_PALNC;
            public const _NV_DISPLAY_TV_FORMAT Sd576i = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_SD_576i;
            public const _NV_DISPLAY_TV_FORMAT Sd480i = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_SD_480i;
            public const _NV_DISPLAY_TV_FORMAT Ed480p = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_ED_480p;
            public const _NV_DISPLAY_TV_FORMAT Ed576p = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_ED_576p;
            public const _NV_DISPLAY_TV_FORMAT Hd720p = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_HD_720p;
            public const _NV_DISPLAY_TV_FORMAT Hd1080i = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_HD_1080i;
            public const _NV_DISPLAY_TV_FORMAT Hd1080p = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_HD_1080p;
            public const _NV_DISPLAY_TV_FORMAT Hd720p50 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_HD_720p50;
            public const _NV_DISPLAY_TV_FORMAT Hd1080p24 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_HD_1080p24;
            public const _NV_DISPLAY_TV_FORMAT Hd1080i50 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_HD_1080i50;
            public const _NV_DISPLAY_TV_FORMAT Hd1080p50 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_HD_1080p50;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp30 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp30;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp30_3840 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp30_3840;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp25 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp25;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp25_3840 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp25_3840;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp24 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp24;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp24_3840 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp24_3840;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp24Smpte = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp24_SMPTE;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp50_3840 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp50_3840;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp60_3840 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp60_3840;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp30_4096 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp30_4096;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp25_4096 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp25_4096;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp24_4096 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp24_4096;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp50_4096 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp50_4096;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp60_4096 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp60_4096;
            public const _NV_DISPLAY_TV_FORMAT Uhd8Kp24_7680 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_8Kp24_7680;
            public const _NV_DISPLAY_TV_FORMAT Uhd8Kp25_7680 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_8Kp25_7680;
            public const _NV_DISPLAY_TV_FORMAT Uhd8Kp30_7680 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_8Kp30_7680;
            public const _NV_DISPLAY_TV_FORMAT Uhd8Kp48_7680 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_8Kp48_7680;
            public const _NV_DISPLAY_TV_FORMAT Uhd8Kp50_7680 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_8Kp50_7680;
            public const _NV_DISPLAY_TV_FORMAT Uhd8Kp60_7680 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_8Kp60_7680;
            public const _NV_DISPLAY_TV_FORMAT Uhd8Kp100_7680 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_8Kp100_7680;
            public const _NV_DISPLAY_TV_FORMAT Uhd8Kp120_7680 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_8Kp120_7680;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp48_3840 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp48_3840;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp48_4096 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp48_4096;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp100_4096 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp100_4096;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp100_3840 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp100_3840;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp120_4096 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp120_4096;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp120_3840 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp120_3840;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp100_5120 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp100_5120;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp120_5120 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp120_5120;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp24_5120 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp24_5120;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp25_5120 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp25_5120;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp30_5120 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp30_5120;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp48_5120 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp48_5120;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp50_5120 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp50_5120;
            public const _NV_DISPLAY_TV_FORMAT Uhd4Kp60_5120 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_4Kp60_5120;
            public const _NV_DISPLAY_TV_FORMAT Uhd10Kp24_10240 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_10Kp24_10240;
            public const _NV_DISPLAY_TV_FORMAT Uhd10Kp25_10240 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_10Kp25_10240;
            public const _NV_DISPLAY_TV_FORMAT Uhd10Kp30_10240 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_10Kp30_10240;
            public const _NV_DISPLAY_TV_FORMAT Uhd10Kp48_10240 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_10Kp48_10240;
            public const _NV_DISPLAY_TV_FORMAT Uhd10Kp50_10240 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_10Kp50_10240;
            public const _NV_DISPLAY_TV_FORMAT Uhd10Kp60_10240 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_10Kp60_10240;
            public const _NV_DISPLAY_TV_FORMAT Uhd10Kp100_10240 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_10Kp100_10240;
            public const _NV_DISPLAY_TV_FORMAT Uhd10Kp120_10240 = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_UHD_10Kp120_10240;
            public const _NV_DISPLAY_TV_FORMAT SdOther = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_SD_OTHER;
            public const _NV_DISPLAY_TV_FORMAT EdOther = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_ED_OTHER;
            public const _NV_DISPLAY_TV_FORMAT HdOther = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_HD_OTHER;
            public const _NV_DISPLAY_TV_FORMAT Any = _NV_DISPLAY_TV_FORMAT.NV_DISPLAY_TV_FORMAT_ANY;
        }

        /// <summary>
        /// GPU connector values (native enum names preserved).
        /// </summary>
        public static class Connector
        {
            public const _NV_GPU_CONNECTOR_TYPE Vga15Pin = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_VGA_15_PIN;
            public const _NV_GPU_CONNECTOR_TYPE TvComposite = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_TV_COMPOSITE;
            public const _NV_GPU_CONNECTOR_TYPE TvSVideo = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_TV_SVIDEO;
            public const _NV_GPU_CONNECTOR_TYPE TvHdtvComponent = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_TV_HDTV_COMPONENT;
            public const _NV_GPU_CONNECTOR_TYPE TvScart = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_TV_SCART;
            public const _NV_GPU_CONNECTOR_TYPE TvCompositeScartOnEiaj4120 = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_TV_COMPOSITE_SCART_ON_EIAJ4120;
            public const _NV_GPU_CONNECTOR_TYPE TvHdtvEiaj4120 = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_TV_HDTV_EIAJ4120;
            public const _NV_GPU_CONNECTOR_TYPE PcPodHdtvYprpb = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_PC_POD_HDTV_YPRPB;
            public const _NV_GPU_CONNECTOR_TYPE PcPodSVideo = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_PC_POD_SVIDEO;
            public const _NV_GPU_CONNECTOR_TYPE PcPodComposite = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_PC_POD_COMPOSITE;
            public const _NV_GPU_CONNECTOR_TYPE DviITvSVideo = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_DVI_I_TV_SVIDEO;
            public const _NV_GPU_CONNECTOR_TYPE DviITvComposite = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_DVI_I_TV_COMPOSITE;
            public const _NV_GPU_CONNECTOR_TYPE DviI = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_DVI_I;
            public const _NV_GPU_CONNECTOR_TYPE DviD = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_DVI_D;
            public const _NV_GPU_CONNECTOR_TYPE Adc = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_ADC;
            public const _NV_GPU_CONNECTOR_TYPE LfhDviI1 = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_LFH_DVI_I_1;
            public const _NV_GPU_CONNECTOR_TYPE LfhDviI2 = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_LFH_DVI_I_2;
            public const _NV_GPU_CONNECTOR_TYPE Spwg = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_SPWG;
            public const _NV_GPU_CONNECTOR_TYPE Oem = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_OEM;
            public const _NV_GPU_CONNECTOR_TYPE DisplayPortExternal = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_DISPLAYPORT_EXTERNAL;
            public const _NV_GPU_CONNECTOR_TYPE DisplayPortInternal = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_DISPLAYPORT_INTERNAL;
            public const _NV_GPU_CONNECTOR_TYPE DisplayPortMiniExt = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_DISPLAYPORT_MINI_EXT;
            public const _NV_GPU_CONNECTOR_TYPE HdmiA = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_HDMI_A;
            public const _NV_GPU_CONNECTOR_TYPE HdmiCMini = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_HDMI_C_MINI;
            public const _NV_GPU_CONNECTOR_TYPE LfhDisplayPort1 = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_LFH_DISPLAYPORT_1;
            public const _NV_GPU_CONNECTOR_TYPE LfhDisplayPort2 = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_LFH_DISPLAYPORT_2;
            public const _NV_GPU_CONNECTOR_TYPE VirtualWfd = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_VIRTUAL_WFD;
            public const _NV_GPU_CONNECTOR_TYPE UsbC = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_USB_C;
            public const _NV_GPU_CONNECTOR_TYPE Unknown = _NV_GPU_CONNECTOR_TYPE.NVAPI_GPU_CONNECTOR_UNKNOWN;
        }
    }

    /// <summary>
    /// Snapshot of the display configuration returned by NVAPI.
    /// </summary>
    public readonly struct NVAPIDisplayConfigDto : IEquatable<NVAPIDisplayConfigDto>
    {
        /// <summary>
        /// Display paths in the configuration.
        /// </summary>
        public NVAPIDisplayConfigPathDto[] Paths { get; }

        /// <summary>
        /// Create a display configuration snapshot.
        /// </summary>
        public NVAPIDisplayConfigDto(NVAPIDisplayConfigPathDto[] paths)
        {
            Paths = paths ?? Array.Empty<NVAPIDisplayConfigPathDto>();
        }

        /// <summary>
        /// Create a DTO from native display configuration data.
        /// </summary>
        /// <param name="pathCount">Number of paths.</param>
        /// <param name="pathInfo">Pointer to native path info.</param>
        /// <returns>Display configuration DTO.</returns>
        public static unsafe NVAPIDisplayConfigDto FromNative(uint pathCount, _NV_DISPLAYCONFIG_PATH_INFO* pathInfo)
        {
            return NVAPIDisplayHelper.CreateDisplayConfigInfo(pathCount, pathInfo);
        }

        /// <summary>
        /// Convert this DTO to a native buffer suitable for NvAPI_DISP_SetDisplayConfig.
        /// </summary>
        /// <returns>Native buffer that must be disposed.</returns>
        internal unsafe NVAPIDisplayHelper.DisplayConfigBuffer ToNativeBuffer()
        {
            var paths = Paths ?? Array.Empty<NVAPIDisplayConfigPathDto>();
            return NVAPIDisplayHelper.CreateDisplayConfigBuffer(paths);
        }

        /// <inheritdoc />
        public bool Equals(NVAPIDisplayConfigDto other)
        {
            return SequenceEquals(Paths, other.Paths);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is NVAPIDisplayConfigDto other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                for (var i = 0; i < Paths.Length; i++)
                {
                    hash = (hash * 31) + Paths[i].GetHashCode();
                }

                return hash;
            }
        }

        /// <summary>
        /// Compare two display configuration snapshots.
        /// </summary>
        public static bool operator ==(NVAPIDisplayConfigDto left, NVAPIDisplayConfigDto right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compare two display configuration snapshots.
        /// </summary>
        public static bool operator !=(NVAPIDisplayConfigDto left, NVAPIDisplayConfigDto right)
        {
            return !left.Equals(right);
        }

        private static bool SequenceEquals(NVAPIDisplayConfigPathDto[] left, NVAPIDisplayConfigPathDto[] right)
        {
            if (ReferenceEquals(left, right))
                return true;

            if (left == null || right == null)
                return false;

            if (left.Length != right.Length)
                return false;

            for (var i = 0; i < left.Length; i++)
            {
                if (!left[i].Equals(right[i]))
                    return false;
            }

            return true;
        }
    }

    /// <summary>
    /// Managed representation of an NVAPI display path configuration.
    /// </summary>
    public readonly struct NVAPIDisplayConfigPathDto : IEquatable<NVAPIDisplayConfigPathDto>
    {
        /// <summary>
        /// NVAPI structure version used for this path.
        /// </summary>
        public uint Version { get; }

        /// <summary>
        /// Windows source ID for the path.
        /// </summary>
        public uint SourceId { get; }

        /// <summary>
        /// True when the path represents a non-NVIDIA adapter.
        /// </summary>
        public bool IsNonNvidiaAdapter { get; }

        /// <summary>
        /// OS adapter LUID value for non-NVIDIA adapters, or null if not present.
        /// </summary>
        public long? OsAdapterLuid { get; }

        /// <summary>
        /// Source mode info, or null if not present.
        /// </summary>
        public NVAPIDisplayConfigSourceModeDto? SourceModeInfo { get; }

        /// <summary>
        /// Target configurations for this path.
        /// </summary>
        public NVAPIDisplayConfigTargetDto[] Targets { get; }

        /// <summary>
        /// Create a display path configuration.
        /// </summary>
        public NVAPIDisplayConfigPathDto(
            uint version,
            uint sourceId,
            bool isNonNvidiaAdapter,
            long? osAdapterLuid,
            NVAPIDisplayConfigSourceModeDto? sourceModeInfo,
            NVAPIDisplayConfigTargetDto[] targets)
        {
            Version = version;
            SourceId = sourceId;
            IsNonNvidiaAdapter = isNonNvidiaAdapter;
            OsAdapterLuid = osAdapterLuid;
            SourceModeInfo = sourceModeInfo;
            Targets = targets ?? Array.Empty<NVAPIDisplayConfigTargetDto>();
        }

        /// <summary>
        /// Create a DTO from a native path info struct.
        /// </summary>
        /// <param name="pathInfo">Native path info.</param>
        /// <returns>Display config path DTO.</returns>
        public static unsafe NVAPIDisplayConfigPathDto FromNative(_NV_DISPLAYCONFIG_PATH_INFO pathInfo)
        {
            var source = NVAPIDisplayHelper.CreateSourceModeInfo(pathInfo.sourceModeInfo);
            var targets = NVAPIDisplayHelper.CreateTargets(pathInfo.targetInfoCount, pathInfo.targetInfo);
            var osAdapterLuid = NVAPIDisplayHelper.ReadOsAdapterLuid(pathInfo.pOSAdapterID);

            return new NVAPIDisplayConfigPathDto(
                pathInfo.version,
                pathInfo.sourceId,
                pathInfo.IsNonNVIDIAAdapter != 0,
                osAdapterLuid,
                source,
                targets);
        }

        /// <summary>
        /// Convert this DTO to a native path info struct.
        /// </summary>
        /// <param name="targetInfo">Pointer to native target info array.</param>
        /// <param name="targetInfoCount">Number of target info entries.</param>
        /// <param name="sourceModeInfo">Pointer to native source mode info.</param>
        /// <param name="osAdapterId">Pointer to OS adapter ID (LUID), or null.</param>
        /// <returns>Native path info struct.</returns>
        public unsafe _NV_DISPLAYCONFIG_PATH_INFO ToNative(
            _NV_DISPLAYCONFIG_PATH_TARGET_INFO_V2* targetInfo,
            uint targetInfoCount,
            _NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1* sourceModeInfo,
            void* osAdapterId)
        {
            var version = Version != 0 ? Version : NVAPI.NV_DISPLAYCONFIG_PATH_INFO_VER;
            return new _NV_DISPLAYCONFIG_PATH_INFO
            {
                version = version,
                sourceId = SourceId,
                targetInfoCount = targetInfoCount,
                targetInfo = targetInfo,
                sourceModeInfo = sourceModeInfo,
                IsNonNVIDIAAdapter = IsNonNvidiaAdapter ? 1u : 0u,
                reserved = 0,
                pOSAdapterID = osAdapterId,
            };
        }

        /// <inheritdoc />
        public bool Equals(NVAPIDisplayConfigPathDto other)
        {
            if (Version != other.Version ||
                SourceId != other.SourceId ||
                IsNonNvidiaAdapter != other.IsNonNvidiaAdapter ||
                !Nullable.Equals(OsAdapterLuid, other.OsAdapterLuid) ||
                !Nullable.Equals(SourceModeInfo, other.SourceModeInfo))
            {
                return false;
            }

            return SequenceEquals(Targets, other.Targets);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is NVAPIDisplayConfigPathDto other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = (hash * 31) + Version.GetHashCode();
                hash = (hash * 31) + SourceId.GetHashCode();
                hash = (hash * 31) + IsNonNvidiaAdapter.GetHashCode();
                hash = (hash * 31) + (OsAdapterLuid?.GetHashCode() ?? 0);
                hash = (hash * 31) + (SourceModeInfo?.GetHashCode() ?? 0);
                for (var i = 0; i < Targets.Length; i++)
                {
                    hash = (hash * 31) + Targets[i].GetHashCode();
                }

                return hash;
            }
        }

        /// <summary>
        /// Compare two path configurations.
        /// </summary>
        public static bool operator ==(NVAPIDisplayConfigPathDto left, NVAPIDisplayConfigPathDto right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compare two path configurations.
        /// </summary>
        public static bool operator !=(NVAPIDisplayConfigPathDto left, NVAPIDisplayConfigPathDto right)
        {
            return !left.Equals(right);
        }

        private static bool SequenceEquals(NVAPIDisplayConfigTargetDto[] left, NVAPIDisplayConfigTargetDto[] right)
        {
            if (ReferenceEquals(left, right))
                return true;

            if (left == null || right == null)
                return false;

            if (left.Length != right.Length)
                return false;

            for (var i = 0; i < left.Length; i++)
            {
                if (!left[i].Equals(right[i]))
                    return false;
            }

            return true;
        }
    }

    /// <summary>
    /// Managed representation of NVAPI display source mode info.
    /// </summary>
    public readonly struct NVAPIDisplayConfigSourceModeDto : IEquatable<NVAPIDisplayConfigSourceModeDto>
    {
        /// <summary>Display resolution.</summary>
        public _NV_RESOLUTION Resolution { get; }

        /// <summary>Color format.</summary>
        public _NV_FORMAT ColorFormat { get; }

        /// <summary>Position for the display.</summary>
        public _NV_POSITION Position { get; }

        /// <summary>Spanning orientation.</summary>
        public _NV_DISPLAYCONFIG_SPANNING_ORIENTATION SpanningOrientation { get; }

        /// <summary>True if this is the GDI primary display.</summary>
        public bool IsGdiPrimary { get; }

        /// <summary>True if this is the SLI focus display.</summary>
        public bool IsSliFocus { get; }

        /// <summary>Create source mode info.</summary>
        public NVAPIDisplayConfigSourceModeDto(
            _NV_RESOLUTION resolution,
            _NV_FORMAT colorFormat,
            _NV_POSITION position,
            _NV_DISPLAYCONFIG_SPANNING_ORIENTATION spanningOrientation,
            bool isGdiPrimary,
            bool isSliFocus)
        {
            Resolution = resolution;
            ColorFormat = colorFormat;
            Position = position;
            SpanningOrientation = spanningOrientation;
            IsGdiPrimary = isGdiPrimary;
            IsSliFocus = isSliFocus;
        }

        /// <summary>
        /// Create a DTO from a native source mode info struct.
        /// </summary>
        /// <param name="native">Native source mode info.</param>
        /// <returns>Source mode DTO.</returns>
        public static NVAPIDisplayConfigSourceModeDto FromNative(_NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1 native)
        {
            return new NVAPIDisplayConfigSourceModeDto(
                native.resolution,
                native.colorFormat,
                native.position,
                native.spanningOrientation,
                native.bGDIPrimary != 0,
                native.bSLIFocus != 0);
        }

        /// <summary>
        /// Convert this DTO to a native source mode info struct.
        /// </summary>
        /// <returns>Native source mode info.</returns>
        public _NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1 ToNative()
        {
            var native = new _NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1
            {
                resolution = Resolution,
                colorFormat = ColorFormat,
                position = Position,
                spanningOrientation = SpanningOrientation,
            };
            native.bGDIPrimary = IsGdiPrimary ? 1u : 0u;
            native.bSLIFocus = IsSliFocus ? 1u : 0u;
            native.reserved = 0;
            return native;
        }

        /// <inheritdoc />
        public bool Equals(NVAPIDisplayConfigSourceModeDto other)
        {
            return Resolution.Equals(other.Resolution)
                && ColorFormat.Equals(other.ColorFormat)
                && Position.Equals(other.Position)
                && SpanningOrientation == other.SpanningOrientation
                && IsGdiPrimary == other.IsGdiPrimary
                && IsSliFocus == other.IsSliFocus;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is NVAPIDisplayConfigSourceModeDto other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = (hash * 31) + Resolution.GetHashCode();
                hash = (hash * 31) + ColorFormat.GetHashCode();
                hash = (hash * 31) + Position.GetHashCode();
                hash = (hash * 31) + SpanningOrientation.GetHashCode();
                hash = (hash * 31) + IsGdiPrimary.GetHashCode();
                hash = (hash * 31) + IsSliFocus.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Compare source mode info values.
        /// </summary>
        public static bool operator ==(NVAPIDisplayConfigSourceModeDto left, NVAPIDisplayConfigSourceModeDto right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compare source mode info values.
        /// </summary>
        public static bool operator !=(NVAPIDisplayConfigSourceModeDto left, NVAPIDisplayConfigSourceModeDto right)
        {
            return !left.Equals(right);
        }
    }

    /// <summary>
    /// Managed representation of a display target configuration.
    /// </summary>
    public readonly struct NVAPIDisplayConfigTargetDto : IEquatable<NVAPIDisplayConfigTargetDto>
    {
        /// <summary>Display ID.</summary>
        public uint DisplayId { get; }

        /// <summary>Windows CCD target ID (for non-NVIDIA adapters).</summary>
        public uint TargetId { get; }

        /// <summary>Advanced target info, or null if not present.</summary>
        public NVAPIDisplayConfigAdvancedTargetDto? Details { get; }

        /// <summary>Create target info.</summary>
        public NVAPIDisplayConfigTargetDto(uint displayId, uint targetId, NVAPIDisplayConfigAdvancedTargetDto? details)
        {
            DisplayId = displayId;
            TargetId = targetId;
            Details = details;
        }

        /// <summary>
        /// Create a DTO from a native target info struct.
        /// </summary>
        /// <param name="native">Native target info.</param>
        /// <returns>Target DTO.</returns>
        public static unsafe NVAPIDisplayConfigTargetDto FromNative(_NV_DISPLAYCONFIG_PATH_TARGET_INFO_V2 native)
        {
            var details = NVAPIDisplayHelper.CreateAdvancedTargetInfo(native.details);
            return new NVAPIDisplayConfigTargetDto(native.displayId, native.targetId, details);
        }

        /// <summary>
        /// Convert this DTO to a native target info struct.
        /// </summary>
        /// <param name="details">Pointer to native advanced target info, or null.</param>
        /// <returns>Native target info.</returns>
        public unsafe _NV_DISPLAYCONFIG_PATH_TARGET_INFO_V2 ToNative(_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1* details)
        {
            return new _NV_DISPLAYCONFIG_PATH_TARGET_INFO_V2
            {
                displayId = DisplayId,
                targetId = TargetId,
                details = details,
            };
        }

        /// <inheritdoc />
        public bool Equals(NVAPIDisplayConfigTargetDto other)
        {
            return DisplayId == other.DisplayId
                && TargetId == other.TargetId
                && Nullable.Equals(Details, other.Details);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is NVAPIDisplayConfigTargetDto other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = (hash * 31) + DisplayId.GetHashCode();
                hash = (hash * 31) + TargetId.GetHashCode();
                hash = (hash * 31) + (Details?.GetHashCode() ?? 0);
                return hash;
            }
        }

        /// <summary>
        /// Compare target info values.
        /// </summary>
        public static bool operator ==(NVAPIDisplayConfigTargetDto left, NVAPIDisplayConfigTargetDto right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compare target info values.
        /// </summary>
        public static bool operator !=(NVAPIDisplayConfigTargetDto left, NVAPIDisplayConfigTargetDto right)
        {
            return !left.Equals(right);
        }
    }

    /// <summary>
    /// Managed representation of advanced target configuration.
    /// </summary>
    public readonly struct NVAPIDisplayConfigAdvancedTargetDto : IEquatable<NVAPIDisplayConfigAdvancedTargetDto>
    {
        /// <summary>Rotation setting.</summary>
        public _NV_ROTATE Rotation { get; }

        /// <summary>Scaling setting.</summary>
        public _NV_SCALING Scaling { get; }

        /// <summary>Refresh rate (in 1/1000 Hz).</summary>
        public uint RefreshRate1K { get; }

        /// <summary>True if the target is interlaced.</summary>
        public bool Interlaced { get; }

        /// <summary>True if this is the primary target.</summary>
        public bool Primary { get; }

        /// <summary>True if virtual mode support is disabled.</summary>
        public bool DisableVirtualModeSupport { get; }

        /// <summary>True if this is the preferred unscaled target.</summary>
        public bool IsPreferredUnscaledTarget { get; }

        /// <summary>Connector type.</summary>
        public _NV_GPU_CONNECTOR_TYPE Connector { get; }

        /// <summary>TV format.</summary>
        public _NV_DISPLAY_TV_FORMAT TvFormat { get; }

        /// <summary>Timing override mode.</summary>
        public _NV_TIMING_OVERRIDE TimingOverride { get; }

        /// <summary>Detailed timing.</summary>
        public _NV_TIMING Timing { get; }

        /// <summary>Create advanced target info.</summary>
        public NVAPIDisplayConfigAdvancedTargetDto(
            _NV_ROTATE rotation,
            _NV_SCALING scaling,
            uint refreshRate1K,
            bool interlaced,
            bool primary,
            bool disableVirtualModeSupport,
            bool isPreferredUnscaledTarget,
            _NV_GPU_CONNECTOR_TYPE connector,
            _NV_DISPLAY_TV_FORMAT tvFormat,
            _NV_TIMING_OVERRIDE timingOverride,
            _NV_TIMING timing)
        {
            Rotation = rotation;
            Scaling = scaling;
            RefreshRate1K = refreshRate1K;
            Interlaced = interlaced;
            Primary = primary;
            DisableVirtualModeSupport = disableVirtualModeSupport;
            IsPreferredUnscaledTarget = isPreferredUnscaledTarget;
            Connector = connector;
            TvFormat = tvFormat;
            TimingOverride = timingOverride;
            Timing = timing;
        }

        /// <summary>
        /// Create a DTO from a native advanced target info struct.
        /// </summary>
        /// <param name="native">Native advanced target info.</param>
        /// <returns>Advanced target DTO.</returns>
        public static NVAPIDisplayConfigAdvancedTargetDto FromNative(_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1 native)
        {
            return new NVAPIDisplayConfigAdvancedTargetDto(
                native.rotation,
                native.scaling,
                native.refreshRate1K,
                native.interlaced != 0,
                native.primary != 0,
                native.disableVirtualModeSupport != 0,
                native.isPreferredUnscaledTarget != 0,
                native.connector,
                native.tvFormat,
                native.timingOverride,
                native.timing);
        }

        /// <summary>
        /// Convert this DTO to a native advanced target info struct.
        /// </summary>
        /// <returns>Native advanced target info.</returns>
        public _NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1 ToNative()
        {
            var native = new _NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1
            {
                version = NVAPI.NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_VER,
                rotation = Rotation,
                scaling = Scaling,
                refreshRate1K = RefreshRate1K,
                connector = Connector,
                tvFormat = TvFormat,
                timingOverride = TimingOverride,
                timing = Timing,
            };
            native.interlaced = Interlaced ? 1u : 0u;
            native.primary = Primary ? 1u : 0u;
            native.disableVirtualModeSupport = DisableVirtualModeSupport ? 1u : 0u;
            native.isPreferredUnscaledTarget = IsPreferredUnscaledTarget ? 1u : 0u;
            native.reservedBit1 = 0;
            native.reserved = 0;
            return native;
        }

        /// <inheritdoc />
        public bool Equals(NVAPIDisplayConfigAdvancedTargetDto other)
        {
            return Rotation == other.Rotation
                && Scaling == other.Scaling
                && RefreshRate1K == other.RefreshRate1K
                && Interlaced == other.Interlaced
                && Primary == other.Primary
                && DisableVirtualModeSupport == other.DisableVirtualModeSupport
                && IsPreferredUnscaledTarget == other.IsPreferredUnscaledTarget
                && Connector == other.Connector
                && TvFormat == other.TvFormat
                && TimingOverride.Equals(other.TimingOverride)
                && Timing.Equals(other.Timing);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is NVAPIDisplayConfigAdvancedTargetDto other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = (hash * 31) + Rotation.GetHashCode();
                hash = (hash * 31) + Scaling.GetHashCode();
                hash = (hash * 31) + RefreshRate1K.GetHashCode();
                hash = (hash * 31) + Interlaced.GetHashCode();
                hash = (hash * 31) + Primary.GetHashCode();
                hash = (hash * 31) + DisableVirtualModeSupport.GetHashCode();
                hash = (hash * 31) + IsPreferredUnscaledTarget.GetHashCode();
                hash = (hash * 31) + Connector.GetHashCode();
                hash = (hash * 31) + TvFormat.GetHashCode();
                hash = (hash * 31) + TimingOverride.GetHashCode();
                hash = (hash * 31) + Timing.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Compare advanced target info values.
        /// </summary>
        public static bool operator ==(NVAPIDisplayConfigAdvancedTargetDto left, NVAPIDisplayConfigAdvancedTargetDto right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compare advanced target info values.
        /// </summary>
        public static bool operator !=(NVAPIDisplayConfigAdvancedTargetDto left, NVAPIDisplayConfigAdvancedTargetDto right)
        {
            return !left.Equals(right);
        }
    }

    /// <summary>
    /// DTO for EDID data and flags.
    /// </summary>
    public readonly struct NVAPIDisplayEdidDataDto : IEquatable<NVAPIDisplayEdidDataDto>
    {
        /// <summary>EDID data bytes.</summary>
        public byte[] Data { get; }

        /// <summary>EDID flags used when retrieving the data.</summary>
        public NV_EDID_FLAG Flags { get; }

        /// <summary>Reported EDID size.</summary>
        public uint SizeOfEdid { get; }

        /// <summary>Create an EDID data DTO.</summary>
        public NVAPIDisplayEdidDataDto(byte[] data, NV_EDID_FLAG flags, uint sizeOfEdid)
        {
            Data = data ?? Array.Empty<byte>();
            Flags = flags;
            SizeOfEdid = sizeOfEdid;
        }

        /// <summary>
        /// Create a DTO from a native EDID struct.
        /// </summary>
        /// <param name="native">Native EDID data.</param>
        /// <param name="flags">EDID flags used.</param>
        /// <returns>EDID data DTO.</returns>
        public static unsafe NVAPIDisplayEdidDataDto FromNative(_NV_EDID_DATA_V2 native, NV_EDID_FLAG flags)
        {
            if (native.pEDID == null || native.sizeOfEDID == 0)
                return new NVAPIDisplayEdidDataDto(Array.Empty<byte>(), flags, native.sizeOfEDID);

            var size = checked((int)native.sizeOfEDID);
            var data = new byte[size];
            Marshal.Copy((IntPtr)native.pEDID, data, 0, size);
            return new NVAPIDisplayEdidDataDto(data, flags, native.sizeOfEDID);
        }

        /// <summary>
        /// Convert this DTO to a native EDID struct.
        /// </summary>
        /// <param name="handle">Pinned handle for the EDID buffer (caller must free).</param>
        /// <returns>Native EDID data.</returns>
        public unsafe _NV_EDID_DATA_V2 ToNative(out GCHandle handle)
        {
            handle = default;
            if (Data == null || Data.Length == 0)
            {
                return new _NV_EDID_DATA_V2
                {
                    version = NVAPI.NV_EDID_DATA_VER,
                    pEDID = null,
                    sizeOfEDID = 0,
                };
            }

            handle = GCHandle.Alloc(Data, GCHandleType.Pinned);
            return new _NV_EDID_DATA_V2
            {
                version = NVAPI.NV_EDID_DATA_VER,
                pEDID = (byte*)handle.AddrOfPinnedObject(),
                sizeOfEDID = (uint)Data.Length,
            };
        }

        /// <inheritdoc />
        public bool Equals(NVAPIDisplayEdidDataDto other)
        {
            return Flags == other.Flags
                && SizeOfEdid == other.SizeOfEdid
                && DtoHelpers.SequenceEquals(Data, other.Data);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is NVAPIDisplayEdidDataDto other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = (hash * 31) + Flags.GetHashCode();
                hash = (hash * 31) + SizeOfEdid.GetHashCode();
                hash = (hash * 31) + DtoHelpers.SequenceHashCode(Data);
                return hash;
            }
        }

        /// <summary>Compare EDID data DTOs.</summary>
        public static bool operator ==(NVAPIDisplayEdidDataDto left, NVAPIDisplayEdidDataDto right) => left.Equals(right);

        /// <summary>Compare EDID data DTOs.</summary>
        public static bool operator !=(NVAPIDisplayEdidDataDto left, NVAPIDisplayEdidDataDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for timing input data.
    /// </summary>
    public readonly struct NVAPITimingInputDto : IEquatable<NVAPITimingInputDto>
    {
        /// <summary>Visible width.</summary>
        public uint Width { get; }

        /// <summary>Visible height.</summary>
        public uint Height { get; }

        /// <summary>Refresh rate.</summary>
        public float RefreshRate { get; }

        /// <summary>Timing flags.</summary>
        public NV_TIMING_FLAG Flag { get; }

        /// <summary>Timing override type.</summary>
        public _NV_TIMING_OVERRIDE OverrideType { get; }

        /// <summary>Create a timing input DTO.</summary>
        public NVAPITimingInputDto(uint width, uint height, float refreshRate, NV_TIMING_FLAG flag, _NV_TIMING_OVERRIDE overrideType)
        {
            Width = width;
            Height = height;
            RefreshRate = refreshRate;
            Flag = flag;
            OverrideType = overrideType;
        }

        /// <summary>
        /// Create a DTO from a native timing input struct.
        /// </summary>
        /// <param name="native">Native timing input.</param>
        /// <returns>Timing input DTO.</returns>
        public static NVAPITimingInputDto FromNative(_NV_TIMING_INPUT native)
        {
            return new NVAPITimingInputDto(native.width, native.height, native.rr, native.flag, native.type);
        }

        /// <summary>
        /// Convert this DTO to a native timing input struct.
        /// </summary>
        /// <returns>Native timing input.</returns>
        public _NV_TIMING_INPUT ToNative()
        {
            return new _NV_TIMING_INPUT
            {
                version = NVAPI.NV_TIMING_INPUT_VER,
                width = Width,
                height = Height,
                rr = RefreshRate,
                flag = Flag,
                type = OverrideType,
            };
        }

        /// <inheritdoc />
        public bool Equals(NVAPITimingInputDto other)
        {
            return Width == other.Width
                && Height == other.Height
                && RefreshRate.Equals(other.RefreshRate)
                && Flag.Equals(other.Flag)
                && OverrideType == other.OverrideType;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is NVAPITimingInputDto other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = (hash * 31) + Width.GetHashCode();
                hash = (hash * 31) + Height.GetHashCode();
                hash = (hash * 31) + RefreshRate.GetHashCode();
                hash = (hash * 31) + Flag.GetHashCode();
                hash = (hash * 31) + OverrideType.GetHashCode();
                return hash;
            }
        }

        /// <summary>Compare timing input DTOs.</summary>
        public static bool operator ==(NVAPITimingInputDto left, NVAPITimingInputDto right) => left.Equals(right);

        /// <summary>Compare timing input DTOs.</summary>
        public static bool operator !=(NVAPITimingInputDto left, NVAPITimingInputDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for timing output data.
    /// </summary>
    public readonly struct NVAPITimingDto : IEquatable<NVAPITimingDto>
    {
        /// <summary>Timing data.</summary>
        public _NV_TIMING Timing { get; }

        /// <summary>Create a timing DTO.</summary>
        public NVAPITimingDto(_NV_TIMING timing)
        {
            Timing = timing;
        }

        /// <summary>
        /// Create a DTO from a native timing struct.
        /// </summary>
        /// <param name="native">Native timing.</param>
        /// <returns>Timing DTO.</returns>
        public static NVAPITimingDto FromNative(_NV_TIMING native)
        {
            return new NVAPITimingDto(native);
        }

        /// <summary>
        /// Convert this DTO to a native timing struct.
        /// </summary>
        /// <returns>Native timing.</returns>
        public _NV_TIMING ToNative()
        {
            return Timing;
        }

        /// <inheritdoc />
        public bool Equals(NVAPITimingDto other) => Timing.Equals(other.Timing);

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is NVAPITimingDto other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => Timing.GetHashCode();

        /// <summary>Compare timing DTOs.</summary>
        public static bool operator ==(NVAPITimingDto left, NVAPITimingDto right) => left.Equals(right);

        /// <summary>Compare timing DTOs.</summary>
        public static bool operator !=(NVAPITimingDto left, NVAPITimingDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for monitor capabilities.
    /// </summary>
    public readonly struct NVAPIMonitorCapabilitiesDto : IEquatable<NVAPIMonitorCapabilitiesDto>
    {
        /// <summary>Native monitor capabilities.</summary>
        public _NV_MONITOR_CAPABILITIES_V1 Capabilities { get; }

        /// <summary>Create a monitor capabilities DTO.</summary>
        public NVAPIMonitorCapabilitiesDto(_NV_MONITOR_CAPABILITIES_V1 capabilities)
        {
            Capabilities = capabilities;
        }

        /// <summary>
        /// Create a DTO from a native monitor capabilities struct.
        /// </summary>
        /// <param name="native">Native monitor capabilities.</param>
        /// <returns>Monitor capabilities DTO.</returns>
        public static NVAPIMonitorCapabilitiesDto FromNative(_NV_MONITOR_CAPABILITIES_V1 native)
        {
            return new NVAPIMonitorCapabilitiesDto(native);
        }

        /// <summary>
        /// Convert this DTO to a native monitor capabilities struct.
        /// </summary>
        /// <returns>Native monitor capabilities.</returns>
        public _NV_MONITOR_CAPABILITIES_V1 ToNative()
        {
            var native = Capabilities;
            if (native.version == 0)
            {
                native.version = NVAPI.NV_MONITOR_CAPABILITIES_VER;
            }

            return native;
        }

        /// <inheritdoc />
        public bool Equals(NVAPIMonitorCapabilitiesDto other) => Capabilities.Equals(other.Capabilities);

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is NVAPIMonitorCapabilitiesDto other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => Capabilities.GetHashCode();

        /// <summary>Compare monitor capabilities DTOs.</summary>
        public static bool operator ==(NVAPIMonitorCapabilitiesDto left, NVAPIMonitorCapabilitiesDto right) => left.Equals(right);

        /// <summary>Compare monitor capabilities DTOs.</summary>
        public static bool operator !=(NVAPIMonitorCapabilitiesDto left, NVAPIMonitorCapabilitiesDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for monitor color capabilities collection.
    /// </summary>
    public readonly struct NVAPIMonitorColorCapabilitiesDto : IEquatable<NVAPIMonitorColorCapabilitiesDto>
    {
        /// <summary>Color capability entries.</summary>
        public _NV_MONITOR_COLOR_DATA[] Capabilities { get; }

        /// <summary>Create a monitor color capabilities DTO.</summary>
        public NVAPIMonitorColorCapabilitiesDto(_NV_MONITOR_COLOR_DATA[] capabilities)
        {
            Capabilities = capabilities ?? Array.Empty<_NV_MONITOR_COLOR_DATA>();
        }

        /// <summary>
        /// Create a DTO from native monitor color capabilities.
        /// </summary>
        /// <param name="native">Native color capabilities array.</param>
        /// <returns>Monitor color capabilities DTO.</returns>
        public static NVAPIMonitorColorCapabilitiesDto FromNative(_NV_MONITOR_COLOR_DATA[] native)
        {
            return new NVAPIMonitorColorCapabilitiesDto(native);
        }

        /// <summary>
        /// Convert this DTO to a native color capabilities array.
        /// </summary>
        /// <returns>Native color capabilities array.</returns>
        public _NV_MONITOR_COLOR_DATA[] ToNative()
        {
            return Capabilities ?? Array.Empty<_NV_MONITOR_COLOR_DATA>();
        }

        /// <inheritdoc />
        public bool Equals(NVAPIMonitorColorCapabilitiesDto other)
        {
            return DtoHelpers.SequenceEquals(Capabilities, other.Capabilities);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is NVAPIMonitorColorCapabilitiesDto other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return DtoHelpers.SequenceHashCode(Capabilities);
        }

        /// <summary>Compare monitor color capabilities DTOs.</summary>
        public static bool operator ==(NVAPIMonitorColorCapabilitiesDto left, NVAPIMonitorColorCapabilitiesDto right) => left.Equals(right);

        /// <summary>Compare monitor color capabilities DTOs.</summary>
        public static bool operator !=(NVAPIMonitorColorCapabilitiesDto left, NVAPIMonitorColorCapabilitiesDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for display port info.
    /// </summary>
    public readonly struct NVAPIDisplayPortInfoDto : IEquatable<NVAPIDisplayPortInfoDto>
    {
        /// <summary>Native display port info.</summary>
        public _NV_DISPLAY_PORT_INFO_V1 Info { get; }

        /// <summary>Create a display port info DTO.</summary>
        public NVAPIDisplayPortInfoDto(_NV_DISPLAY_PORT_INFO_V1 info)
        {
            Info = info;
        }

        /// <summary>
        /// Create a DTO from a native display port info struct.
        /// </summary>
        /// <param name="native">Native display port info.</param>
        /// <returns>Display port info DTO.</returns>
        public static NVAPIDisplayPortInfoDto FromNative(_NV_DISPLAY_PORT_INFO_V1 native)
        {
            return new NVAPIDisplayPortInfoDto(native);
        }

        /// <summary>
        /// Convert this DTO to a native display port info struct.
        /// </summary>
        /// <returns>Native display port info.</returns>
        public _NV_DISPLAY_PORT_INFO_V1 ToNative()
        {
            var native = Info;
            if (native.version == 0)
            {
                native.version = NVAPI.NV_DISPLAY_PORT_INFO_VER;
            }

            return native;
        }

        /// <inheritdoc />
        public bool Equals(NVAPIDisplayPortInfoDto other) => Info.Equals(other.Info);

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is NVAPIDisplayPortInfoDto other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => Info.GetHashCode();

        /// <summary>Compare display port info DTOs.</summary>
        public static bool operator ==(NVAPIDisplayPortInfoDto left, NVAPIDisplayPortInfoDto right) => left.Equals(right);

        /// <summary>Compare display port info DTOs.</summary>
        public static bool operator !=(NVAPIDisplayPortInfoDto left, NVAPIDisplayPortInfoDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for display port configuration.
    /// </summary>
    public readonly struct NVAPIDisplayPortConfigDto : IEquatable<NVAPIDisplayPortConfigDto>
    {
        /// <summary>Native display port config.</summary>
        public NV_DISPLAY_PORT_CONFIG Config { get; }

        /// <summary>Create a display port config DTO.</summary>
        public NVAPIDisplayPortConfigDto(NV_DISPLAY_PORT_CONFIG config)
        {
            Config = config;
        }

        /// <summary>
        /// Create a DTO from a native display port config struct.
        /// </summary>
        /// <param name="native">Native display port config.</param>
        /// <returns>Display port config DTO.</returns>
        public static NVAPIDisplayPortConfigDto FromNative(NV_DISPLAY_PORT_CONFIG native)
        {
            return new NVAPIDisplayPortConfigDto(native);
        }

        /// <summary>
        /// Convert this DTO to a native display port config struct.
        /// </summary>
        /// <returns>Native display port config.</returns>
        public NV_DISPLAY_PORT_CONFIG ToNative()
        {
            var native = Config;
            if (native.version == 0)
            {
                native.version = NVAPI.NV_DISPLAY_PORT_CONFIG_VER;
            }

            return native;
        }

        /// <inheritdoc />
        public bool Equals(NVAPIDisplayPortConfigDto other) => Config.Equals(other.Config);

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is NVAPIDisplayPortConfigDto other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => Config.GetHashCode();

        /// <summary>Compare display port config DTOs.</summary>
        public static bool operator ==(NVAPIDisplayPortConfigDto left, NVAPIDisplayPortConfigDto right) => left.Equals(right);

        /// <summary>Compare display port config DTOs.</summary>
        public static bool operator !=(NVAPIDisplayPortConfigDto left, NVAPIDisplayPortConfigDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for HDMI support info.
    /// </summary>
    public readonly struct NVAPIDisplayHdmiSupportInfoDto : IEquatable<NVAPIDisplayHdmiSupportInfoDto>
    {
        /// <summary>Native HDMI support info.</summary>
        public _NV_HDMI_SUPPORT_INFO_V2 Info { get; }

        /// <summary>Create an HDMI support info DTO.</summary>
        public NVAPIDisplayHdmiSupportInfoDto(_NV_HDMI_SUPPORT_INFO_V2 info)
        {
            Info = info;
        }

        /// <summary>
        /// Create a DTO from a native HDMI support info struct.
        /// </summary>
        /// <param name="native">Native HDMI support info.</param>
        /// <returns>HDMI support info DTO.</returns>
        public static NVAPIDisplayHdmiSupportInfoDto FromNative(_NV_HDMI_SUPPORT_INFO_V2 native)
        {
            return new NVAPIDisplayHdmiSupportInfoDto(native);
        }

        /// <summary>
        /// Convert this DTO to a native HDMI support info struct.
        /// </summary>
        /// <returns>Native HDMI support info.</returns>
        public _NV_HDMI_SUPPORT_INFO_V2 ToNative()
        {
            var native = Info;
            if (native.version == 0)
            {
                native.version = NVAPI.NV_HDMI_SUPPORT_INFO_VER2;
            }

            return native;
        }

        /// <inheritdoc />
        public bool Equals(NVAPIDisplayHdmiSupportInfoDto other) => Info.Equals(other.Info);

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is NVAPIDisplayHdmiSupportInfoDto other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => Info.GetHashCode();

        /// <summary>Compare HDMI support info DTOs.</summary>
        public static bool operator ==(NVAPIDisplayHdmiSupportInfoDto left, NVAPIDisplayHdmiSupportInfoDto right) => left.Equals(right);

        /// <summary>Compare HDMI support info DTOs.</summary>
        public static bool operator !=(NVAPIDisplayHdmiSupportInfoDto left, NVAPIDisplayHdmiSupportInfoDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for supported display view modes.
    /// </summary>
    public readonly struct NVAPISupportedViewsDto : IEquatable<NVAPISupportedViewsDto>
    {
        /// <summary>Supported view modes.</summary>
        public _NV_TARGET_VIEW_MODE[] Views { get; }

        /// <summary>Create a supported views DTO.</summary>
        public NVAPISupportedViewsDto(_NV_TARGET_VIEW_MODE[] views)
        {
            Views = views ?? Array.Empty<_NV_TARGET_VIEW_MODE>();
        }

        /// <summary>
        /// Create a DTO from native supported views.
        /// </summary>
        /// <param name="native">Native view modes.</param>
        /// <returns>Supported views DTO.</returns>
        public static NVAPISupportedViewsDto FromNative(_NV_TARGET_VIEW_MODE[] native)
        {
            return new NVAPISupportedViewsDto(native);
        }

        /// <summary>
        /// Convert this DTO to a native view mode array.
        /// </summary>
        /// <returns>Native view modes.</returns>
        public _NV_TARGET_VIEW_MODE[] ToNative()
        {
            return Views ?? Array.Empty<_NV_TARGET_VIEW_MODE>();
        }

        /// <inheritdoc />
        public bool Equals(NVAPISupportedViewsDto other)
        {
            return DtoHelpers.SequenceEquals(Views, other.Views);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is NVAPISupportedViewsDto other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return DtoHelpers.SequenceHashCode(Views);
        }

        /// <summary>Compare supported views DTOs.</summary>
        public static bool operator ==(NVAPISupportedViewsDto left, NVAPISupportedViewsDto right) => left.Equals(right);

        /// <summary>Compare supported views DTOs.</summary>
        public static bool operator !=(NVAPISupportedViewsDto left, NVAPISupportedViewsDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for VRR info.
    /// </summary>
    public readonly struct NVAPIVrrInfoDto : IEquatable<NVAPIVrrInfoDto>
    {
        /// <summary>Native VRR info.</summary>
        public _NV_GET_VRR_INFO_V1 Info { get; }

        /// <summary>Create a VRR info DTO.</summary>
        public NVAPIVrrInfoDto(_NV_GET_VRR_INFO_V1 info)
        {
            Info = info;
        }

        /// <summary>
        /// Create a DTO from a native VRR info struct.
        /// </summary>
        /// <param name="native">Native VRR info.</param>
        /// <returns>VRR info DTO.</returns>
        public static NVAPIVrrInfoDto FromNative(_NV_GET_VRR_INFO_V1 native)
        {
            return new NVAPIVrrInfoDto(native);
        }

        /// <summary>
        /// Convert this DTO to a native VRR info struct.
        /// </summary>
        /// <returns>Native VRR info.</returns>
        public _NV_GET_VRR_INFO_V1 ToNative()
        {
            var native = Info;
            if (native.version == 0)
            {
                native.version = NVAPI.NV_GET_VRR_INFO_VER;
            }

            return native;
        }

        /// <inheritdoc />
        public bool Equals(NVAPIVrrInfoDto other) => Info.Equals(other.Info);

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is NVAPIVrrInfoDto other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => Info.GetHashCode();

        /// <summary>Compare VRR info DTOs.</summary>
        public static bool operator ==(NVAPIVrrInfoDto left, NVAPIVrrInfoDto right) => left.Equals(right);

        /// <summary>Compare VRR info DTOs.</summary>
        public static bool operator !=(NVAPIVrrInfoDto left, NVAPIVrrInfoDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for adaptive sync GET data.
    /// </summary>
    public readonly struct NVAPIAdaptiveSyncGetDataDto : IEquatable<NVAPIAdaptiveSyncGetDataDto>
    {
        /// <summary>Native adaptive sync GET data.</summary>
        public _NV_GET_ADAPTIVE_SYNC_DATA_V1 Data { get; }

        /// <summary>Create an adaptive sync GET DTO.</summary>
        public NVAPIAdaptiveSyncGetDataDto(_NV_GET_ADAPTIVE_SYNC_DATA_V1 data)
        {
            Data = data;
        }

        /// <summary>
        /// Create a DTO from native adaptive sync GET data.
        /// </summary>
        /// <param name="native">Native adaptive sync GET data.</param>
        /// <returns>Adaptive sync GET DTO.</returns>
        public static NVAPIAdaptiveSyncGetDataDto FromNative(_NV_GET_ADAPTIVE_SYNC_DATA_V1 native)
        {
            return new NVAPIAdaptiveSyncGetDataDto(native);
        }

        /// <summary>
        /// Convert this DTO to native adaptive sync GET data.
        /// </summary>
        /// <returns>Native adaptive sync GET data.</returns>
        public _NV_GET_ADAPTIVE_SYNC_DATA_V1 ToNative()
        {
            var native = Data;
            if (native.version == 0)
            {
                native.version = NVAPI.NV_GET_ADAPTIVE_SYNC_DATA_VER;
            }

            return native;
        }

        /// <inheritdoc />
        public bool Equals(NVAPIAdaptiveSyncGetDataDto other) => Data.Equals(other.Data);

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is NVAPIAdaptiveSyncGetDataDto other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => Data.GetHashCode();

        /// <summary>Compare adaptive sync GET DTOs.</summary>
        public static bool operator ==(NVAPIAdaptiveSyncGetDataDto left, NVAPIAdaptiveSyncGetDataDto right) => left.Equals(right);

        /// <summary>Compare adaptive sync GET DTOs.</summary>
        public static bool operator !=(NVAPIAdaptiveSyncGetDataDto left, NVAPIAdaptiveSyncGetDataDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for adaptive sync SET data.
    /// </summary>
    public readonly struct NVAPIAdaptiveSyncSetDataDto : IEquatable<NVAPIAdaptiveSyncSetDataDto>
    {
        /// <summary>Native adaptive sync SET data.</summary>
        public _NV_SET_ADAPTIVE_SYNC_DATA_V1 Data { get; }

        /// <summary>Create an adaptive sync SET DTO.</summary>
        public NVAPIAdaptiveSyncSetDataDto(_NV_SET_ADAPTIVE_SYNC_DATA_V1 data)
        {
            Data = data;
        }

        /// <summary>
        /// Create a DTO from native adaptive sync SET data.
        /// </summary>
        /// <param name="native">Native adaptive sync SET data.</param>
        /// <returns>Adaptive sync SET DTO.</returns>
        public static NVAPIAdaptiveSyncSetDataDto FromNative(_NV_SET_ADAPTIVE_SYNC_DATA_V1 native)
        {
            return new NVAPIAdaptiveSyncSetDataDto(native);
        }

        /// <summary>
        /// Convert this DTO to native adaptive sync SET data.
        /// </summary>
        /// <returns>Native adaptive sync SET data.</returns>
        public _NV_SET_ADAPTIVE_SYNC_DATA_V1 ToNative()
        {
            var native = Data;
            if (native.version == 0)
            {
                native.version = NVAPI.NV_SET_ADAPTIVE_SYNC_DATA_VER;
            }

            return native;
        }

        /// <inheritdoc />
        public bool Equals(NVAPIAdaptiveSyncSetDataDto other) => Data.Equals(other.Data);

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is NVAPIAdaptiveSyncSetDataDto other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => Data.GetHashCode();

        /// <summary>Compare adaptive sync SET DTOs.</summary>
        public static bool operator ==(NVAPIAdaptiveSyncSetDataDto left, NVAPIAdaptiveSyncSetDataDto right) => left.Equals(right);

        /// <summary>Compare adaptive sync SET DTOs.</summary>
        public static bool operator !=(NVAPIAdaptiveSyncSetDataDto left, NVAPIAdaptiveSyncSetDataDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for virtual refresh rate data.
    /// </summary>
    public readonly struct NVAPIVirtualRefreshRateDataDto : IEquatable<NVAPIVirtualRefreshRateDataDto>
    {
        /// <summary>Frame interval (microseconds).</summary>
        public uint FrameIntervalUs { get; }

        /// <summary>Refresh rate in 1/1000 Hz.</summary>
        public uint RefreshRate1K { get; }

        /// <summary>Gaming VRR flag.</summary>
        public bool IsGamingVrr { get; }

        /// <summary>Frame interval (nanoseconds).</summary>
        public ulong FrameIntervalNs { get; }

        /// <summary>Create a virtual refresh rate DTO.</summary>
        public NVAPIVirtualRefreshRateDataDto(uint frameIntervalUs, uint refreshRate1K, bool isGamingVrr, ulong frameIntervalNs)
        {
            FrameIntervalUs = frameIntervalUs;
            RefreshRate1K = refreshRate1K;
            IsGamingVrr = isGamingVrr;
            FrameIntervalNs = frameIntervalNs;
        }

        /// <summary>
        /// Create a DTO from native virtual refresh rate GET data.
        /// </summary>
        /// <param name="native">Native virtual refresh rate GET data.</param>
        /// <returns>Virtual refresh rate DTO.</returns>
        public static NVAPIVirtualRefreshRateDataDto FromNative(_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V2 native)
        {
            return new NVAPIVirtualRefreshRateDataDto(
                native.frameIntervalUs,
                native.rrx1k,
                native.bIsGamingVrr != 0,
                native.frameIntervalNs);
        }

        /// <summary>
        /// Convert this DTO to native virtual refresh rate SET data.
        /// </summary>
        /// <returns>Native virtual refresh rate SET data.</returns>
        public _NV_SET_VIRTUAL_REFRESH_RATE_DATA_V2 ToNative()
        {
            return new _NV_SET_VIRTUAL_REFRESH_RATE_DATA_V2
            {
                version = NVAPI.NV_SET_VIRTUAL_REFRESH_RATE_DATA_VER,
                frameIntervalUs = FrameIntervalUs,
                rrx1k = RefreshRate1K,
                bIsGamingVrr = IsGamingVrr ? 1u : 0u,
                frameIntervalNs = FrameIntervalNs,
            };
        }

        /// <inheritdoc />
        public bool Equals(NVAPIVirtualRefreshRateDataDto other)
        {
            return FrameIntervalUs == other.FrameIntervalUs
                && RefreshRate1K == other.RefreshRate1K
                && IsGamingVrr == other.IsGamingVrr
                && FrameIntervalNs == other.FrameIntervalNs;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is NVAPIVirtualRefreshRateDataDto other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = (hash * 31) + FrameIntervalUs.GetHashCode();
                hash = (hash * 31) + RefreshRate1K.GetHashCode();
                hash = (hash * 31) + IsGamingVrr.GetHashCode();
                hash = (hash * 31) + FrameIntervalNs.GetHashCode();
                return hash;
            }
        }

        /// <summary>Compare virtual refresh rate DTOs.</summary>
        public static bool operator ==(NVAPIVirtualRefreshRateDataDto left, NVAPIVirtualRefreshRateDataDto right) => left.Equals(right);

        /// <summary>Compare virtual refresh rate DTOs.</summary>
        public static bool operator !=(NVAPIVirtualRefreshRateDataDto left, NVAPIVirtualRefreshRateDataDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for infoframe data.
    /// </summary>
    public readonly struct NVAPIInfoFrameDataDto : IEquatable<NVAPIInfoFrameDataDto>
    {
        /// <summary>Native infoframe data.</summary>
        public NV_INFOFRAME_DATA Data { get; }

        /// <summary>Create an infoframe data DTO.</summary>
        public NVAPIInfoFrameDataDto(NV_INFOFRAME_DATA data)
        {
            Data = data;
        }

        /// <summary>
        /// Create a DTO from native infoframe data.
        /// </summary>
        /// <param name="native">Native infoframe data.</param>
        /// <returns>Infoframe data DTO.</returns>
        public static NVAPIInfoFrameDataDto FromNative(NV_INFOFRAME_DATA native)
        {
            return new NVAPIInfoFrameDataDto(native);
        }

        /// <summary>
        /// Convert this DTO to native infoframe data.
        /// </summary>
        /// <returns>Native infoframe data.</returns>
        public NV_INFOFRAME_DATA ToNative()
        {
            var native = Data;
            if (native.version == 0)
            {
                native.version = NVAPI.NV_INFOFRAME_DATA_VER;
            }

            if (native.size == 0)
            {
                native.size = (ushort)Marshal.SizeOf<NV_INFOFRAME_DATA>();
            }

            return native;
        }

        /// <inheritdoc />
        public bool Equals(NVAPIInfoFrameDataDto other) => Data.Equals(other.Data);

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is NVAPIInfoFrameDataDto other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => Data.GetHashCode();

        /// <summary>Compare infoframe data DTOs.</summary>
        public static bool operator ==(NVAPIInfoFrameDataDto left, NVAPIInfoFrameDataDto right) => left.Equals(right);

        /// <summary>Compare infoframe data DTOs.</summary>
        public static bool operator !=(NVAPIInfoFrameDataDto left, NVAPIInfoFrameDataDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for display color data.
    /// </summary>
    public readonly struct NVAPIDisplayColorDataDto : IEquatable<NVAPIDisplayColorDataDto>
    {
        /// <summary>Native color data.</summary>
        public _NV_COLOR_DATA_V5 Data { get; }

        /// <summary>Create a display color data DTO.</summary>
        public NVAPIDisplayColorDataDto(_NV_COLOR_DATA_V5 data)
        {
            Data = data;
        }

        /// <summary>
        /// Create a DTO from native color data.
        /// </summary>
        /// <param name="native">Native color data.</param>
        /// <returns>Display color data DTO.</returns>
        public static NVAPIDisplayColorDataDto FromNative(_NV_COLOR_DATA_V5 native)
        {
            return new NVAPIDisplayColorDataDto(native);
        }

        /// <summary>
        /// Convert this DTO to native color data.
        /// </summary>
        /// <returns>Native color data.</returns>
        public _NV_COLOR_DATA_V5 ToNative()
        {
            var native = Data;
            if (native.version == 0)
            {
                native.version = NVAPI.NV_COLOR_DATA_VER;
            }

            if (native.size == 0)
            {
                native.size = (ushort)Marshal.SizeOf<_NV_COLOR_DATA_V5>();
            }

            return native;
        }

        /// <inheritdoc />
        public bool Equals(NVAPIDisplayColorDataDto other) => Data.Equals(other.Data);

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is NVAPIDisplayColorDataDto other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => Data.GetHashCode();

        /// <summary>Compare display color data DTOs.</summary>
        public static bool operator ==(NVAPIDisplayColorDataDto left, NVAPIDisplayColorDataDto right) => left.Equals(right);

        /// <summary>Compare display color data DTOs.</summary>
        public static bool operator !=(NVAPIDisplayColorDataDto left, NVAPIDisplayColorDataDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for HDR capabilities.
    /// </summary>
    public readonly struct NVAPIHdrCapabilitiesDto : IEquatable<NVAPIHdrCapabilitiesDto>
    {
        /// <summary>Native HDR capabilities.</summary>
        public _NV_HDR_CAPABILITIES_V3 Capabilities { get; }

        /// <summary>Create an HDR capabilities DTO.</summary>
        public NVAPIHdrCapabilitiesDto(_NV_HDR_CAPABILITIES_V3 capabilities)
        {
            Capabilities = capabilities;
        }

        /// <summary>
        /// Create a DTO from native HDR capabilities.
        /// </summary>
        /// <param name="native">Native HDR capabilities.</param>
        /// <returns>HDR capabilities DTO.</returns>
        public static NVAPIHdrCapabilitiesDto FromNative(_NV_HDR_CAPABILITIES_V3 native)
        {
            return new NVAPIHdrCapabilitiesDto(native);
        }

        /// <summary>
        /// Convert this DTO to native HDR capabilities.
        /// </summary>
        /// <returns>Native HDR capabilities.</returns>
        public _NV_HDR_CAPABILITIES_V3 ToNative()
        {
            var native = Capabilities;
            if (native.version == 0)
            {
                native.version = NVAPI.NV_HDR_CAPABILITIES_VER;
            }

            return native;
        }

        /// <summary>
        /// True if any HDR capability flag is set.
        /// </summary>
        public bool IsHdrSupported =>
            Capabilities.isST2084EotfSupported != 0 ||
            Capabilities.isTraditionalHdrGammaSupported != 0 ||
            Capabilities.isEdrSupported != 0 ||
            Capabilities.isDolbyVisionSupported != 0 ||
            Capabilities.isHdr10PlusSupported != 0 ||
            Capabilities.isHdr10PlusGamingSupported != 0;

        /// <inheritdoc />
        public bool Equals(NVAPIHdrCapabilitiesDto other) => Capabilities.Equals(other.Capabilities);

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is NVAPIHdrCapabilitiesDto other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => Capabilities.GetHashCode();

        /// <summary>Compare HDR capabilities DTOs.</summary>
        public static bool operator ==(NVAPIHdrCapabilitiesDto left, NVAPIHdrCapabilitiesDto right) => left.Equals(right);

        /// <summary>Compare HDR capabilities DTOs.</summary>
        public static bool operator !=(NVAPIHdrCapabilitiesDto left, NVAPIHdrCapabilitiesDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for HDR color data.
    /// </summary>
    public readonly struct NVAPIHdrColorDataDto : IEquatable<NVAPIHdrColorDataDto>
    {
        /// <summary>Native HDR color data.</summary>
        public _NV_HDR_COLOR_DATA_V2 Data { get; }

        /// <summary>Create an HDR color data DTO.</summary>
        public NVAPIHdrColorDataDto(_NV_HDR_COLOR_DATA_V2 data)
        {
            Data = data;
        }

        /// <summary>
        /// Create a DTO from native HDR color data.
        /// </summary>
        /// <param name="native">Native HDR color data.</param>
        /// <returns>HDR color data DTO.</returns>
        public static NVAPIHdrColorDataDto FromNative(_NV_HDR_COLOR_DATA_V2 native)
        {
            return new NVAPIHdrColorDataDto(native);
        }

        /// <summary>
        /// Convert this DTO to native HDR color data.
        /// </summary>
        /// <returns>Native HDR color data.</returns>
        public _NV_HDR_COLOR_DATA_V2 ToNative()
        {
            var native = Data;
            if (native.version == 0)
            {
                native.version = NVAPI.NV_HDR_COLOR_DATA_VER;
            }

            return native;
        }

        /// <inheritdoc />
        public bool Equals(NVAPIHdrColorDataDto other) => Data.Equals(other.Data);

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is NVAPIHdrColorDataDto other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => Data.GetHashCode();

        /// <summary>Compare HDR color data DTOs.</summary>
        public static bool operator ==(NVAPIHdrColorDataDto left, NVAPIHdrColorDataDto right) => left.Equals(right);

        /// <summary>Compare HDR color data DTOs.</summary>
        public static bool operator !=(NVAPIHdrColorDataDto left, NVAPIHdrColorDataDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for HDR metadata.
    /// </summary>
    public readonly struct NVAPIHdrMetadataDto : IEquatable<NVAPIHdrMetadataDto>
    {
        /// <summary>Native HDR metadata.</summary>
        public _NV_HDR_METADATA_V1 Metadata { get; }

        /// <summary>Create an HDR metadata DTO.</summary>
        public NVAPIHdrMetadataDto(_NV_HDR_METADATA_V1 metadata)
        {
            Metadata = metadata;
        }

        /// <summary>
        /// Create a DTO from native HDR metadata.
        /// </summary>
        /// <param name="native">Native HDR metadata.</param>
        /// <returns>HDR metadata DTO.</returns>
        public static NVAPIHdrMetadataDto FromNative(_NV_HDR_METADATA_V1 native)
        {
            return new NVAPIHdrMetadataDto(native);
        }

        /// <summary>
        /// Convert this DTO to native HDR metadata.
        /// </summary>
        /// <returns>Native HDR metadata.</returns>
        public _NV_HDR_METADATA_V1 ToNative()
        {
            var native = Metadata;
            if (native.version == 0)
            {
                native.version = NVAPI.NV_HDR_METADATA_VER;
            }

            return native;
        }

        /// <inheritdoc />
        public bool Equals(NVAPIHdrMetadataDto other) => Metadata.Equals(other.Metadata);

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is NVAPIHdrMetadataDto other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => Metadata.GetHashCode();

        /// <summary>Compare HDR metadata DTOs.</summary>
        public static bool operator ==(NVAPIHdrMetadataDto left, NVAPIHdrMetadataDto right) => left.Equals(right);

        /// <summary>Compare HDR metadata DTOs.</summary>
        public static bool operator !=(NVAPIHdrMetadataDto left, NVAPIHdrMetadataDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for display colorimetry.
    /// </summary>
    public readonly struct NVAPIDisplayColorimetryDto : IEquatable<NVAPIDisplayColorimetryDto>
    {
        /// <summary>Native display colorimetry.</summary>
        public _NV_DISPLAY_COLORIMETRY_V1 Colorimetry { get; }

        /// <summary>Create a display colorimetry DTO.</summary>
        public NVAPIDisplayColorimetryDto(_NV_DISPLAY_COLORIMETRY_V1 colorimetry)
        {
            Colorimetry = colorimetry;
        }

        /// <summary>
        /// Create a DTO from native display colorimetry.
        /// </summary>
        /// <param name="native">Native display colorimetry.</param>
        /// <returns>Display colorimetry DTO.</returns>
        public static NVAPIDisplayColorimetryDto FromNative(_NV_DISPLAY_COLORIMETRY_V1 native)
        {
            return new NVAPIDisplayColorimetryDto(native);
        }

        /// <summary>
        /// Convert this DTO to native display colorimetry.
        /// </summary>
        /// <returns>Native display colorimetry.</returns>
        public _NV_DISPLAY_COLORIMETRY_V1 ToNative()
        {
            var native = Colorimetry;
            if (native.version == 0)
            {
                native.version = NVAPI.NV_DISPLAY_COLORIMETRY_VER;
            }

            return native;
        }

        /// <inheritdoc />
        public bool Equals(NVAPIDisplayColorimetryDto other) => Colorimetry.Equals(other.Colorimetry);

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is NVAPIDisplayColorimetryDto other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => Colorimetry.GetHashCode();

        /// <summary>Compare display colorimetry DTOs.</summary>
        public static bool operator ==(NVAPIDisplayColorimetryDto left, NVAPIDisplayColorimetryDto right) => left.Equals(right);

        /// <summary>Compare display colorimetry DTOs.</summary>
        public static bool operator !=(NVAPIDisplayColorimetryDto left, NVAPIDisplayColorimetryDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for custom display.
    /// </summary>
    public readonly struct NVAPICustomDisplayDto : IEquatable<NVAPICustomDisplayDto>
    {
        /// <summary>Native custom display.</summary>
        public NV_CUSTOM_DISPLAY CustomDisplay { get; }

        /// <summary>Create a custom display DTO.</summary>
        public NVAPICustomDisplayDto(NV_CUSTOM_DISPLAY customDisplay)
        {
            CustomDisplay = customDisplay;
        }

        /// <summary>
        /// Create a DTO from native custom display.
        /// </summary>
        /// <param name="native">Native custom display.</param>
        /// <returns>Custom display DTO.</returns>
        public static NVAPICustomDisplayDto FromNative(NV_CUSTOM_DISPLAY native)
        {
            return new NVAPICustomDisplayDto(native);
        }

        /// <summary>
        /// Convert this DTO to native custom display.
        /// </summary>
        /// <returns>Native custom display.</returns>
        public NV_CUSTOM_DISPLAY ToNative()
        {
            var native = CustomDisplay;
            if (native.version == 0)
            {
                native.version = NVAPI.NV_CUSTOM_DISPLAY_VER;
            }

            return native;
        }

        /// <inheritdoc />
        public bool Equals(NVAPICustomDisplayDto other) => CustomDisplay.Equals(other.CustomDisplay);

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is NVAPICustomDisplayDto other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => CustomDisplay.GetHashCode();

        /// <summary>Compare custom display DTOs.</summary>
        public static bool operator ==(NVAPICustomDisplayDto left, NVAPICustomDisplayDto right) => left.Equals(right);

        /// <summary>Compare custom display DTOs.</summary>
        public static bool operator !=(NVAPICustomDisplayDto left, NVAPICustomDisplayDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for NVIDIA managed dedicated display info.
    /// </summary>
    public readonly struct NVAPINvManagedDedicatedDisplayInfoDto : IEquatable<NVAPINvManagedDedicatedDisplayInfoDto>
    {
        /// <summary>Display ID.</summary>
        public uint DisplayId { get; }

        /// <summary>True if acquired by another process.</summary>
        public bool IsAcquired { get; }

        /// <summary>True if part of a Mosaic grid.</summary>
        public bool IsMosaic { get; }

        /// <summary>Create a managed dedicated display info DTO.</summary>
        public NVAPINvManagedDedicatedDisplayInfoDto(uint displayId, bool isAcquired, bool isMosaic)
        {
            DisplayId = displayId;
            IsAcquired = isAcquired;
            IsMosaic = isMosaic;
        }

        /// <summary>
        /// Create a DTO from native managed dedicated display info.
        /// </summary>
        /// <param name="native">Native managed dedicated display info.</param>
        /// <returns>Managed dedicated display info DTO.</returns>
        public static NVAPINvManagedDedicatedDisplayInfoDto FromNative(_NV_MANAGED_DEDICATED_DISPLAY_INFO native)
        {
            return new NVAPINvManagedDedicatedDisplayInfoDto(
                native.displayId,
                native.isAcquired != 0,
                native.isMosaic != 0);
        }

        /// <summary>
        /// Create DTOs from a native managed dedicated display info array.
        /// </summary>
        /// <param name="native">Native managed dedicated display info array.</param>
        /// <returns>Managed dedicated display info DTO array.</returns>
        public static NVAPINvManagedDedicatedDisplayInfoDto[] FromNative(_NV_MANAGED_DEDICATED_DISPLAY_INFO[] native)
        {
            if (native == null || native.Length == 0)
                return Array.Empty<NVAPINvManagedDedicatedDisplayInfoDto>();

            var result = new NVAPINvManagedDedicatedDisplayInfoDto[native.Length];
            for (var i = 0; i < native.Length; i++)
            {
                result[i] = FromNative(native[i]);
            }

            return result;
        }

        /// <inheritdoc />
        public bool Equals(NVAPINvManagedDedicatedDisplayInfoDto other)
        {
            return DisplayId == other.DisplayId &&
                   IsAcquired == other.IsAcquired &&
                   IsMosaic == other.IsMosaic;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is NVAPINvManagedDedicatedDisplayInfoDto other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = DisplayId.GetHashCode();
                hash = (hash * 31) + IsAcquired.GetHashCode();
                hash = (hash * 31) + IsMosaic.GetHashCode();
                return hash;
            }
        }

        /// <summary>Compare managed dedicated display info DTOs.</summary>
        public static bool operator ==(NVAPINvManagedDedicatedDisplayInfoDto left, NVAPINvManagedDedicatedDisplayInfoDto right) => left.Equals(right);

        /// <summary>Compare managed dedicated display info DTOs.</summary>
        public static bool operator !=(NVAPINvManagedDedicatedDisplayInfoDto left, NVAPINvManagedDedicatedDisplayInfoDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for NVIDIA managed dedicated display metadata.
    /// </summary>
    public readonly struct NVAPINvManagedDedicatedDisplayMetadataDto : IEquatable<NVAPINvManagedDedicatedDisplayMetadataDto>
    {
        public uint DisplayId { get; }
        public bool SetPosition { get; }
        public bool RemovePosition { get; }
        public bool PositionIsAvailable { get; }
        public bool SetName { get; }
        public bool RemoveName { get; }
        public bool NameIsAvailable { get; }
        public uint Reserved { get; }
        public int PositionX { get; }
        public int PositionY { get; }
        public string Name { get; }

        /// <summary>
        /// Create a managed dedicated display metadata DTO.
        /// </summary>
        /// <param name="displayId">Display identifier.</param>
        /// <param name="setPosition">Whether to set the display position.</param>
        /// <param name="removePosition">Whether to remove the stored display position.</param>
        /// <param name="positionIsAvailable">Whether a stored display position is available.</param>
        /// <param name="setName">Whether to set the display name.</param>
        /// <param name="removeName">Whether to remove the stored display name.</param>
        /// <param name="nameIsAvailable">Whether a stored display name is available.</param>
        /// <param name="reserved">Reserved field value.</param>
        /// <param name="positionX">Display X position.</param>
        /// <param name="positionY">Display Y position.</param>
        /// <param name="name">Display name.</param>
        public NVAPINvManagedDedicatedDisplayMetadataDto(
            uint displayId,
            bool setPosition,
            bool removePosition,
            bool positionIsAvailable,
            bool setName,
            bool removeName,
            bool nameIsAvailable,
            uint reserved,
            int positionX,
            int positionY,
            string name)
        {
            DisplayId = displayId;
            SetPosition = setPosition;
            RemovePosition = removePosition;
            PositionIsAvailable = positionIsAvailable;
            SetName = setName;
            RemoveName = removeName;
            NameIsAvailable = nameIsAvailable;
            Reserved = reserved;
            PositionX = positionX;
            PositionY = positionY;
            Name = name ?? string.Empty;
        }

        /// <summary>
        /// Create a DTO from native managed dedicated display metadata.
        /// </summary>
        /// <param name="native">Native managed dedicated display metadata.</param>
        /// <returns>Managed dedicated display metadata DTO.</returns>
        public static NVAPINvManagedDedicatedDisplayMetadataDto FromNative(_NV_MANAGED_DEDICATED_DISPLAY_METADATA native)
        {
            var name = NVAPIDisplayHelperString.ReadShortString(ref native.name.e0);
            return new NVAPINvManagedDedicatedDisplayMetadataDto(
                native.displayId,
                native.bSetPosition != 0,
                native.bRemovePosition != 0,
                native.bPositionIsAvailable != 0,
                native.bSetName != 0,
                native.bRemoveName != 0,
                native.bNameIsAvailable != 0,
                native.reserved,
                native.positionX,
                native.positionY,
                name);
        }

        /// <summary>
        /// Convert this DTO to native managed dedicated display metadata.
        /// </summary>
        /// <returns>Native managed dedicated display metadata.</returns>
        public _NV_MANAGED_DEDICATED_DISPLAY_METADATA ToNative()
        {
            var native = new _NV_MANAGED_DEDICATED_DISPLAY_METADATA
            {
                version = NVAPI.NV_MANAGED_DEDICATED_DISPLAY_METADATA_VER,
                displayId = DisplayId,
                bSetPosition = SetPosition ? 1u : 0u,
                bRemovePosition = RemovePosition ? 1u : 0u,
                bPositionIsAvailable = PositionIsAvailable ? 1u : 0u,
                bSetName = SetName ? 1u : 0u,
                bRemoveName = RemoveName ? 1u : 0u,
                bNameIsAvailable = NameIsAvailable ? 1u : 0u,
                reserved = Reserved,
                positionX = PositionX,
                positionY = PositionY
            };

            var span = MemoryMarshal.CreateSpan(ref native.name.e0, NVAPI.NVAPI_SHORT_STRING_MAX);
            NVAPIDisplayHelperString.WriteShortString(span, Name);
            return native;
        }

        /// <summary>
        /// Determine whether this instance equals another managed dedicated display metadata DTO.
        /// </summary>
        /// <param name="other">The other DTO to compare.</param>
        /// <returns>True if the DTOs are equal; otherwise false.</returns>
        public bool Equals(NVAPINvManagedDedicatedDisplayMetadataDto other)
        {
            return DisplayId == other.DisplayId
                && SetPosition == other.SetPosition
                && RemovePosition == other.RemovePosition
                && PositionIsAvailable == other.PositionIsAvailable
                && SetName == other.SetName
                && RemoveName == other.RemoveName
                && NameIsAvailable == other.NameIsAvailable
                && Reserved == other.Reserved
                && PositionX == other.PositionX
                && PositionY == other.PositionY
                && string.Equals(Name, other.Name, StringComparison.Ordinal);
        }

        /// <summary>
        /// Determine whether this instance equals another object.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>True if the object is an equivalent DTO; otherwise false.</returns>
        public override bool Equals(object? obj) => obj is NVAPINvManagedDedicatedDisplayMetadataDto other && Equals(other);

        /// <summary>
        /// Get a hash code for this instance.
        /// </summary>
        /// <returns>Hash code for this instance.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = DisplayId.GetHashCode();
                hash = (hash * 31) + SetPosition.GetHashCode();
                hash = (hash * 31) + RemovePosition.GetHashCode();
                hash = (hash * 31) + PositionIsAvailable.GetHashCode();
                hash = (hash * 31) + SetName.GetHashCode();
                hash = (hash * 31) + RemoveName.GetHashCode();
                hash = (hash * 31) + NameIsAvailable.GetHashCode();
                hash = (hash * 31) + Reserved.GetHashCode();
                hash = (hash * 31) + PositionX.GetHashCode();
                hash = (hash * 31) + PositionY.GetHashCode();
                hash = (hash * 31) + StringComparer.Ordinal.GetHashCode(Name);
                return hash;
            }
        }

        /// <summary>
        /// Determine whether two managed dedicated display metadata DTOs are equal.
        /// </summary>
        /// <param name="left">Left DTO.</param>
        /// <param name="right">Right DTO.</param>
        /// <returns>True if the DTOs are equal; otherwise false.</returns>
        public static bool operator ==(NVAPINvManagedDedicatedDisplayMetadataDto left, NVAPINvManagedDedicatedDisplayMetadataDto right) => left.Equals(right);

        /// <summary>
        /// Determine whether two managed dedicated display metadata DTOs are not equal.
        /// </summary>
        /// <param name="left">Left DTO.</param>
        /// <param name="right">Right DTO.</param>
        /// <returns>True if the DTOs are not equal; otherwise false.</returns>
        public static bool operator !=(NVAPINvManagedDedicatedDisplayMetadataDto left, NVAPINvManagedDedicatedDisplayMetadataDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for display ID info data.
    /// </summary>
    public readonly struct NVAPIDisplayIdInfoDto : IEquatable<NVAPIDisplayIdInfoDto>
    {
        public long AdapterLuid { get; }
        public uint TargetId { get; }
        public uint[] Reserved { get; }

        /// <summary>
        /// Create a display ID info DTO.
        /// </summary>
        /// <param name="adapterLuid">Adapter LUID.</param>
        /// <param name="targetId">Target identifier.</param>
        /// <param name="reserved">Reserved values.</param>
        public NVAPIDisplayIdInfoDto(long adapterLuid, uint targetId, uint[] reserved)
        {
            AdapterLuid = adapterLuid;
            TargetId = targetId;
            Reserved = reserved ?? Array.Empty<uint>();
        }

        /// <summary>
        /// Create a DTO from native display ID info data.
        /// </summary>
        /// <param name="native">Native display ID info data.</param>
        /// <returns>Display ID info DTO.</returns>
        public static NVAPIDisplayIdInfoDto FromNative(_NV_DISPLAY_ID_INFO_DATA_V1 native)
        {
            var reserved = new uint[4];
            var span = MemoryMarshal.CreateSpan(ref native.reserved.e0, 4);
            span.CopyTo(reserved);

            return new NVAPIDisplayIdInfoDto(
                NVAPIDisplayHelper.ReadLuid(native.adapterId),
                native.targetId,
                reserved);
        }

        /// <summary>
        /// Convert this DTO to native display ID info data.
        /// </summary>
        /// <returns>Native display ID info data.</returns>
        public _NV_DISPLAY_ID_INFO_DATA_V1 ToNative()
        {
            var native = new _NV_DISPLAY_ID_INFO_DATA_V1
            {
                version = NVAPI.NV_DISPLAY_ID_INFO_DATA_VER,
                adapterId = NVAPIDisplayHelper.CreateLuid(AdapterLuid),
                targetId = TargetId
            };

            var span = MemoryMarshal.CreateSpan(ref native.reserved.e0, 4);
            var source = Reserved ?? Array.Empty<uint>();
            var count = Math.Min(source.Length, 4);
            for (var i = 0; i < count; i++)
            {
                span[i] = source[i];
            }

            return native;
        }

        /// <summary>
        /// Determine whether this instance equals another display ID info DTO.
        /// </summary>
        /// <param name="other">The other DTO to compare.</param>
        /// <returns>True if the DTOs are equal; otherwise false.</returns>
        public bool Equals(NVAPIDisplayIdInfoDto other)
        {
            return AdapterLuid == other.AdapterLuid
                && TargetId == other.TargetId
                && DtoHelpers.SequenceEquals(Reserved, other.Reserved);
        }

        /// <summary>
        /// Determine whether this instance equals another object.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>True if the object is an equivalent DTO; otherwise false.</returns>
        public override bool Equals(object? obj) => obj is NVAPIDisplayIdInfoDto other && Equals(other);

        /// <summary>
        /// Get a hash code for this instance.
        /// </summary>
        /// <returns>Hash code for this instance.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = AdapterLuid.GetHashCode();
                hash = (hash * 31) + TargetId.GetHashCode();
                hash = (hash * 31) + DtoHelpers.SequenceHashCode(Reserved);
                return hash;
            }
        }

        /// <summary>
        /// Determine whether two display ID info DTOs are equal.
        /// </summary>
        /// <param name="left">Left DTO.</param>
        /// <param name="right">Right DTO.</param>
        /// <returns>True if the DTOs are equal; otherwise false.</returns>
        public static bool operator ==(NVAPIDisplayIdInfoDto left, NVAPIDisplayIdInfoDto right) => left.Equals(right);

        /// <summary>
        /// Determine whether two display ID info DTOs are not equal.
        /// </summary>
        /// <param name="left">Left DTO.</param>
        /// <param name="right">Right DTO.</param>
        /// <returns>True if the DTOs are not equal; otherwise false.</returns>
        public static bool operator !=(NVAPIDisplayIdInfoDto left, NVAPIDisplayIdInfoDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for target info data.
    /// </summary>
    public readonly struct NVAPITargetInfoDto : IEquatable<NVAPITargetInfoDto>
    {
        public long AdapterLuid { get; }
        public uint TargetId { get; }
        public uint[] DisplayIds { get; }
        public uint DisplayIdCount { get; }
        public uint[] Reserved { get; }

        /// <summary>
        /// Create a target info DTO.
        /// </summary>
        /// <param name="adapterLuid">Adapter LUID.</param>
        /// <param name="targetId">Target identifier.</param>
        /// <param name="displayIds">Display identifiers.</param>
        /// <param name="displayIdCount">Display ID count reported by the API.</param>
        /// <param name="reserved">Reserved values.</param>
        public NVAPITargetInfoDto(long adapterLuid, uint targetId, uint[] displayIds, uint displayIdCount, uint[] reserved)
        {
            AdapterLuid = adapterLuid;
            TargetId = targetId;
            DisplayIds = displayIds ?? Array.Empty<uint>();
            DisplayIdCount = displayIdCount;
            Reserved = reserved ?? Array.Empty<uint>();
        }

        /// <summary>
        /// Create a DTO from native target info data.
        /// </summary>
        /// <param name="native">Native target info data.</param>
        /// <returns>Target info DTO.</returns>
        public static NVAPITargetInfoDto FromNative(_NV_TARGET_INFO_DATA_V1 native)
        {
            var count = (int)Math.Min(native.displayIdCount, NVAPI.NVAPI_MAX_DISPLAYS);
            var displayIds = new uint[count];
            var displaySpan = MemoryMarshal.CreateSpan(ref native.displayId.e0, NVAPI.NVAPI_MAX_DISPLAYS);
            displaySpan.Slice(0, count).CopyTo(displayIds);

            var reserved = new uint[4];
            var reservedSpan = MemoryMarshal.CreateSpan(ref native.reserved.e0, 4);
            reservedSpan.CopyTo(reserved);

            return new NVAPITargetInfoDto(
                NVAPIDisplayHelper.ReadLuid(native.adapterId),
                native.targetId,
                displayIds,
                native.displayIdCount,
                reserved);
        }

        /// <summary>
        /// Convert this DTO to native target info data.
        /// </summary>
        /// <returns>Native target info data.</returns>
        public _NV_TARGET_INFO_DATA_V1 ToNative()
        {
            var native = new _NV_TARGET_INFO_DATA_V1
            {
                version = NVAPI.NV_TARGET_INFO_DATA_VER,
                adapterId = NVAPIDisplayHelper.CreateLuid(AdapterLuid),
                targetId = TargetId
            };

            var displaySpan = MemoryMarshal.CreateSpan(ref native.displayId.e0, NVAPI.NVAPI_MAX_DISPLAYS);
            displaySpan.Clear();
            var source = DisplayIds ?? Array.Empty<uint>();
            var count = Math.Min(source.Length, NVAPI.NVAPI_MAX_DISPLAYS);
            for (var i = 0; i < count; i++)
            {
                displaySpan[i] = source[i];
            }

            native.displayIdCount = (uint)count;

            var reservedSpan = MemoryMarshal.CreateSpan(ref native.reserved.e0, 4);
            var reservedSource = Reserved ?? Array.Empty<uint>();
            var reservedCount = Math.Min(reservedSource.Length, 4);
            for (var i = 0; i < reservedCount; i++)
            {
                reservedSpan[i] = reservedSource[i];
            }

            return native;
        }

        /// <summary>
        /// Determine whether this instance equals another target info DTO.
        /// </summary>
        /// <param name="other">The other DTO to compare.</param>
        /// <returns>True if the DTOs are equal; otherwise false.</returns>
        public bool Equals(NVAPITargetInfoDto other)
        {
            return AdapterLuid == other.AdapterLuid
                && TargetId == other.TargetId
                && DisplayIdCount == other.DisplayIdCount
                && DtoHelpers.SequenceEquals(DisplayIds, other.DisplayIds)
                && DtoHelpers.SequenceEquals(Reserved, other.Reserved);
        }

        /// <summary>
        /// Determine whether this instance equals another object.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>True if the object is an equivalent DTO; otherwise false.</returns>
        public override bool Equals(object? obj) => obj is NVAPITargetInfoDto other && Equals(other);

        /// <summary>
        /// Get a hash code for this instance.
        /// </summary>
        /// <returns>Hash code for this instance.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = AdapterLuid.GetHashCode();
                hash = (hash * 31) + TargetId.GetHashCode();
                hash = (hash * 31) + DisplayIdCount.GetHashCode();
                hash = (hash * 31) + DtoHelpers.SequenceHashCode(DisplayIds);
                hash = (hash * 31) + DtoHelpers.SequenceHashCode(Reserved);
                return hash;
            }
        }

        /// <summary>
        /// Determine whether two target info DTOs are equal.
        /// </summary>
        /// <param name="left">Left DTO.</param>
        /// <param name="right">Right DTO.</param>
        /// <returns>True if the DTOs are equal; otherwise false.</returns>
        public static bool operator ==(NVAPITargetInfoDto left, NVAPITargetInfoDto right) => left.Equals(right);

        /// <summary>
        /// Determine whether two target info DTOs are not equal.
        /// </summary>
        /// <param name="left">Left DTO.</param>
        /// <param name="right">Right DTO.</param>
        /// <returns>True if the DTOs are not equal; otherwise false.</returns>
        public static bool operator !=(NVAPITargetInfoDto left, NVAPITargetInfoDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for preferred stereo display.
    /// </summary>
    public readonly struct NVAPIPreferredStereoDisplayDto : IEquatable<NVAPIPreferredStereoDisplayDto>
    {
        /// <summary>Display ID.</summary>
        public uint DisplayId { get; }

        /// <summary>Create a preferred stereo display DTO.</summary>
        public NVAPIPreferredStereoDisplayDto(uint displayId)
        {
            DisplayId = displayId;
        }

        /// <summary>
        /// Create a DTO from native preferred stereo display GET data.
        /// </summary>
        /// <param name="native">Native preferred stereo display GET data.</param>
        /// <returns>Preferred stereo display DTO.</returns>
        public static NVAPIPreferredStereoDisplayDto FromNative(NV_GET_PREFERRED_STEREO_DISPLAY_V1 native)
        {
            return new NVAPIPreferredStereoDisplayDto(native.displayId);
        }

        /// <summary>
        /// Convert this DTO to native preferred stereo display SET data.
        /// </summary>
        /// <returns>Native preferred stereo display SET data.</returns>
        public NV_SET_PREFERRED_STEREO_DISPLAY_V1 ToNative()
        {
            return new NV_SET_PREFERRED_STEREO_DISPLAY_V1
            {
                version = NVAPI.NV_SET_PREFERRED_STEREO_DISPLAY_VER,
                displayId = DisplayId,
            };
        }

        /// <inheritdoc />
        public bool Equals(NVAPIPreferredStereoDisplayDto other) => DisplayId == other.DisplayId;

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is NVAPIPreferredStereoDisplayDto other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => DisplayId.GetHashCode();

        /// <summary>Compare preferred stereo display DTOs.</summary>
        public static bool operator ==(NVAPIPreferredStereoDisplayDto left, NVAPIPreferredStereoDisplayDto right) => left.Equals(right);

        /// <summary>Compare preferred stereo display DTOs.</summary>
        public static bool operator !=(NVAPIPreferredStereoDisplayDto left, NVAPIPreferredStereoDisplayDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DTO for GPU and output ID from a display ID.
    /// </summary>
    public readonly struct NVAPIGpuAndOutputIdDto : IEquatable<NVAPIGpuAndOutputIdDto>
    {
        internal IntPtr Handle { get; }
        public NVAPIPhysicalGpuHelper PhysicalGpu { get; }
        public uint OutputId { get; }

        internal NVAPIGpuAndOutputIdDto(IntPtr handle, NVAPIPhysicalGpuHelper physicalGpu, uint outputId)
        {
            Handle = handle;
            PhysicalGpu = physicalGpu;
            OutputId = outputId;
        }

        /// <summary>
        /// Create a DTO from native GPU and output data.
        /// </summary>
        /// <param name="apiHelper">API helper owning the GPU helper.</param>
        /// <param name="handle">Native physical GPU handle.</param>
        /// <param name="outputId">Output identifier.</param>
        /// <returns>GPU and output ID DTO.</returns>
        public static unsafe NVAPIGpuAndOutputIdDto FromNative(NVAPIApiHelper apiHelper, NvPhysicalGpuHandle__* handle, uint outputId)
        {
            var ptr = (IntPtr)handle;
            return new NVAPIGpuAndOutputIdDto(ptr, new NVAPIPhysicalGpuHelper(apiHelper, ptr), outputId);
        }

        /// <summary>
        /// Determine whether this instance equals another GPU and output ID DTO.
        /// </summary>
        /// <param name="other">The other DTO to compare.</param>
        /// <returns>True if the DTOs are equal; otherwise false.</returns>
        public bool Equals(NVAPIGpuAndOutputIdDto other)
        {
            return Handle == other.Handle && OutputId == other.OutputId;
        }

        /// <summary>
        /// Determine whether this instance equals another object.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>True if the object is an equivalent DTO; otherwise false.</returns>
        public override bool Equals(object? obj) => obj is NVAPIGpuAndOutputIdDto other && Equals(other);

        /// <summary>
        /// Get a hash code for this instance.
        /// </summary>
        /// <returns>Hash code for this instance.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = Handle.GetHashCode();
                hash = (hash * 31) + OutputId.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Determine whether two GPU and output ID DTOs are equal.
        /// </summary>
        /// <param name="left">Left DTO.</param>
        /// <param name="right">Right DTO.</param>
        /// <returns>True if the DTOs are equal; otherwise false.</returns>
        public static bool operator ==(NVAPIGpuAndOutputIdDto left, NVAPIGpuAndOutputIdDto right) => left.Equals(right);

        /// <summary>
        /// Determine whether two GPU and output ID DTOs are not equal.
        /// </summary>
        /// <param name="left">Left DTO.</param>
        /// <param name="right">Right DTO.</param>
        /// <returns>True if the DTOs are not equal; otherwise false.</returns>
        public static bool operator !=(NVAPIGpuAndOutputIdDto left, NVAPIGpuAndOutputIdDto right) => !left.Equals(right);
    }

    /// <summary>
    /// InfoFrame property type values. No official constants are available, so this is a safe placeholder.
    /// </summary>
    public enum NV_INFOFRAME_PROPERTY_TYPE : byte
    {
        /// <summary>
        /// No documentation exists that specifies the values for this field, so defaulting to zero.
        /// </summary>
        NV_INFOFRAME_PROPERTY_TYPE_UNKNOWN = 0
    }

    internal static class NVAPIDisplayHelperString
    {
        /// <summary>
        /// Read a null-terminated ANSI short string from a fixed buffer.
        /// </summary>
        /// <param name="first">First character of the buffer.</param>
        /// <returns>Decoded string value.</returns>
        public static unsafe string ReadShortString(ref sbyte first)
        {
            fixed (sbyte* p = &first)
            {
                return Marshal.PtrToStringAnsi((IntPtr)p) ?? string.Empty;
            }
        }

        /// <summary>
        /// Write a null-terminated ANSI short string to a fixed buffer.
        /// </summary>
        /// <param name="destination">Destination buffer.</param>
        /// <param name="value">String value to write.</param>
        public static void WriteShortString(Span<sbyte> destination, string value)
        {
            destination.Clear();
            if (string.IsNullOrEmpty(value) || destination.Length == 0)
                return;

            var max = destination.Length - 1;
            var bytes = Encoding.ASCII.GetBytes(value);
            var length = Math.Min(bytes.Length, max);
            for (var i = 0; i < length; i++)
            {
                destination[i] = (sbyte)bytes[i];
            }

            destination[length] = 0;
        }
    }

    internal static class DtoHelpers
    {
        /// <summary>
        /// Compare two arrays for equality using the default comparer.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="left">Left array.</param>
        /// <param name="right">Right array.</param>
        /// <returns>True if both arrays are equal; otherwise false.</returns>
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

        /// <summary>
        /// Compute a hash code for an array using the default comparer.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="values">Array values.</param>
        /// <returns>Hash code for the array contents.</returns>
        public static int SequenceHashCode<T>(T[] values)
        {
            if (values == null || values.Length == 0)
                return 0;

            unchecked
            {
                var hash = 17;
                var comparer = EqualityComparer<T>.Default;
                for (var i = 0; i < values.Length; i++)
                {
                    var value = values[i];
                    hash = (hash * 31) + (value == null ? 0 : comparer.GetHashCode(value));
                }

                return hash;
            }
        }
    }
}
