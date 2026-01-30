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

        private readonly NVAPIApiHelper _apiHelper;
        private readonly IntPtr _handle;
        private bool _disposed;

        internal NVAPIDisplayHelper(NVAPIApiHelper apiHelper, IntPtr handle)
        {
            _apiHelper = apiHelper;
            _handle = handle;
        }

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
                return NVAPISupportedViewsDto.FromNative(Array.Empty<NV_TARGET_VIEW_MODE>());

            var views = new NV_TARGET_VIEW_MODE[viewCount];
            fixed (NV_TARGET_VIEW_MODE* pViews = views)
            {
                status = getViews(GetHandle(), pViews, &viewCount);
            }

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            if (viewCount != views.Length)
            {
                var trimmed = new NV_TARGET_VIEW_MODE[viewCount];
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

        private unsafe bool TryGetDisplayId(out uint displayId)
        {
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
                var status = getDisplayId((sbyte*)pBytes, &displayId);
                if (status == _NvAPI_Status.NVAPI_OK)
                    return true;

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED ||
                    status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND ||
                    status == _NvAPI_Status.NVAPI_INVALID_ARGUMENT)
                {
                    return false;
                }

                throw new NVAPIException(status);
            }
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
        private unsafe delegate _NvAPI_Status NvApiGetSupportedViewsDelegate(NvDisplayHandle__* hNvDisplay, NV_TARGET_VIEW_MODE* pTargetViews, uint* pViewCount);

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

        [StructLayout(LayoutKind.Sequential)]
        private struct Luid
        {
            public uint LowPart;
            public int HighPart;
        }

        internal sealed class DisplayConfigBuffer : IDisposable
        {
            private readonly List<IntPtr> _allocations = new List<IntPtr>();

            public unsafe _NV_DISPLAYCONFIG_PATH_INFO* PathInfo { get; }

            public uint PathCount { get; }

            public unsafe DisplayConfigBuffer(uint pathCount)
            {
                PathCount = pathCount;
                var size = checked((int)pathCount) * sizeof(_NV_DISPLAYCONFIG_PATH_INFO);
                var pathPtr = Marshal.AllocHGlobal(size);
                _allocations.Add(pathPtr);
                PathInfo = (_NV_DISPLAYCONFIG_PATH_INFO*)pathPtr;
                new Span<byte>((void*)pathPtr, size).Clear();
            }

            public unsafe void InitializePathInfoVersions()
            {
                for (var i = 0; i < PathCount; i++)
                {
                    PathInfo[i].version = NVAPI.NV_DISPLAYCONFIG_PATH_INFO_VER;
                }
            }

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

            public void TrackAllocation(IntPtr ptr)
            {
                _allocations.Add(ptr);
            }

            public void Dispose()
            {
                for (var i = _allocations.Count - 1; i >= 0; i--)
                {
                    Marshal.FreeHGlobal(_allocations[i]);
                }
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
                            FillAdvancedTargetInfo(details, targets[t].Details.Value);
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
                && Flag == other.Flag
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
        public NV_TARGET_VIEW_MODE[] Views { get; }

        /// <summary>Create a supported views DTO.</summary>
        public NVAPISupportedViewsDto(NV_TARGET_VIEW_MODE[] views)
        {
            Views = views ?? Array.Empty<NV_TARGET_VIEW_MODE>();
        }

        /// <summary>
        /// Create a DTO from native supported views.
        /// </summary>
        /// <param name="native">Native view modes.</param>
        /// <returns>Supported views DTO.</returns>
        public static NVAPISupportedViewsDto FromNative(NV_TARGET_VIEW_MODE[] native)
        {
            return new NVAPISupportedViewsDto(native);
        }

        /// <summary>
        /// Convert this DTO to a native view mode array.
        /// </summary>
        /// <returns>Native view modes.</returns>
        public NV_TARGET_VIEW_MODE[] ToNative()
        {
            return Views ?? Array.Empty<NV_TARGET_VIEW_MODE>();
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

        public static NVAPIGpuAndOutputIdDto FromNative(NVAPIApiHelper apiHelper, NvPhysicalGpuHandle__* handle, uint outputId)
        {
            var ptr = (IntPtr)handle;
            return new NVAPIGpuAndOutputIdDto(ptr, new NVAPIPhysicalGpuHelper(apiHelper, ptr), outputId);
        }

        public bool Equals(NVAPIGpuAndOutputIdDto other)
        {
            return Handle == other.Handle && OutputId == other.OutputId;
        }

        public override bool Equals(object? obj) => obj is NVAPIGpuAndOutputIdDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = Handle.GetHashCode();
                hash = (hash * 31) + OutputId.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIGpuAndOutputIdDto left, NVAPIGpuAndOutputIdDto right) => left.Equals(right);
        public static bool operator !=(NVAPIGpuAndOutputIdDto left, NVAPIGpuAndOutputIdDto right) => !left.Equals(right);
    }

    internal static class DtoHelpers
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
            if (values == null || values.Length == 0)
                return 0;

            unchecked
            {
                var hash = 17;
                var comparer = EqualityComparer<T>.Default;
                for (var i = 0; i < values.Length; i++)
                {
                    hash = (hash * 31) + comparer.GetHashCode(values[i]);
                }

                return hash;
            }
        }
    }
}
