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

            return CreateDisplayConfigInfo(pathCount, buffer.PathInfo);
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

            using var buffer = CreateDisplayConfigBuffer(paths);
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
                return new NVAPISupportedViewsDto(Array.Empty<NV_TARGET_VIEW_MODE>());

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

            return new NVAPISupportedViewsDto(views);
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

            var edid = new _NV_EDID_DATA_V2
            {
                version = NVAPI.NV_EDID_DATA_VER,
                pEDID = null,
                sizeOfEDID = 0,
            };

            var status = getEdid(displayId, &edid, &flag);
            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            if (status != _NvAPI_Status.NVAPI_OK && status != _NvAPI_Status.NVAPI_INSUFFICIENT_BUFFER)
                throw new NVAPIException(status);

            if (edid.sizeOfEDID == 0)
                return new NVAPIDisplayEdidDataDto(Array.Empty<byte>(), flag, 0);

            var data = new byte[edid.sizeOfEDID];
            fixed (byte* pData = data)
            {
                edid.pEDID = pData;
                status = getEdid(displayId, &edid, &flag);
            }

            if (status == _NvAPI_Status.NVAPI_OK)
                return new NVAPIDisplayEdidDataDto(data, flag, edid.sizeOfEDID);

            if (status == _NvAPI_Status.NVAPI_INSUFFICIENT_BUFFER && edid.sizeOfEDID > data.Length)
            {
                data = new byte[edid.sizeOfEDID];
                fixed (byte* pData = data)
                {
                    edid.pEDID = pData;
                    status = getEdid(displayId, &edid, &flag);
                }

                if (status == _NvAPI_Status.NVAPI_OK)
                    return new NVAPIDisplayEdidDataDto(data, flag, edid.sizeOfEDID);
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

            var nativeInput = new _NV_TIMING_INPUT
            {
                version = NVAPI.NV_TIMING_INPUT_VER,
                width = input.Width,
                height = input.Height,
                rr = input.RefreshRate,
                flag = input.Flag,
                type = input.OverrideType,
            };

            var timing = new _NV_TIMING();
            var status = getTiming(displayId, &nativeInput, &timing);
            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            return new NVAPITimingDto(timing);
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

            var caps = new _NV_MONITOR_CAPABILITIES_V1
            {
                version = NVAPI.NV_MONITOR_CAPABILITIES_VER,
            };

            var status = getCaps(displayId, &caps);
            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            return new NVAPIMonitorCapabilitiesDto(caps);
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
                return new NVAPIMonitorColorCapabilitiesDto(Array.Empty<_NV_MONITOR_COLOR_DATA>());

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

            return new NVAPIMonitorColorCapabilitiesDto(caps);
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

            var info = new _NV_DISPLAY_PORT_INFO_V1
            {
                version = NVAPI.NV_DISPLAY_PORT_INFO_VER,
            };

            var status = getInfo(GetHandle(), resolvedOutputId, &info);
            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            return new NVAPIDisplayPortInfoDto(info);
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

            var nativeConfig = config.Config;
            nativeConfig.version = NVAPI.NV_DISPLAY_PORT_CONFIG_VER;
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

            var info = new _NV_HDMI_SUPPORT_INFO_V2
            {
                version = NVAPI.NV_HDMI_SUPPORT_INFO_VER,
            };

            var status = getInfo(GetHandle(), resolvedOutputId, &info);
            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            return new NVAPIDisplayHdmiSupportInfoDto(info);
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

            var info = new _NV_GET_VRR_INFO_V1
            {
                version = NVAPI.NV_GET_VRR_INFO_VER,
            };

            var status = getVrr(displayId, &info);
            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            return new NVAPIVrrInfoDto(info);
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

            var data = new _NV_GET_ADAPTIVE_SYNC_DATA_V1
            {
                version = NVAPI.NV_GET_ADAPTIVE_SYNC_DATA_VER,
            };

            var status = getData(displayId, &data);
            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            return new NVAPIAdaptiveSyncGetDataDto(data);
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

            var nativeData = data.Data;
            nativeData.version = NVAPI.NV_SET_ADAPTIVE_SYNC_DATA_VER;
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

            var data = new _NV_GET_VIRTUAL_REFRESH_RATE_DATA_V2
            {
                version = NVAPI.NV_GET_VIRTUAL_REFRESH_RATE_DATA_VER,
            };

            var status = getData(displayId, &data);
            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            return new NVAPIVirtualRefreshRateDataDto(data.frameIntervalUs, data.rrx1k, data.bIsGamingVrr != 0, data.frameIntervalNs);
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

            var nativeData = new _NV_SET_VIRTUAL_REFRESH_RATE_DATA_V2
            {
                version = NVAPI.NV_SET_VIRTUAL_REFRESH_RATE_DATA_VER,
                frameIntervalUs = data.FrameIntervalUs,
                rrx1k = data.RefreshRate1K,
                bIsGamingVrr = data.IsGamingVrr ? 1u : 0u,
                frameIntervalNs = data.FrameIntervalNs,
            };

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

            var display = new NV_GET_PREFERRED_STEREO_DISPLAY_V1
            {
                version = NVAPI.NV_GET_PREFERRED_STEREO_DISPLAY_VER,
            };

            var status = getDisplay(&display);
            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            return new NVAPIPreferredStereoDisplayDto(display.displayId);
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

            var nativeDisplay = new NV_SET_PREFERRED_STEREO_DISPLAY_V1
            {
                version = NVAPI.NV_SET_PREFERRED_STEREO_DISPLAY_VER,
                displayId = display.DisplayId,
            };

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

        private sealed class DisplayConfigBuffer : IDisposable
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

        private static unsafe NVAPIDisplayConfigDto CreateDisplayConfigInfo(uint pathCount, _NV_DISPLAYCONFIG_PATH_INFO* pathInfo)
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

        private static unsafe NVAPIDisplayConfigSourceModeDto? CreateSourceModeInfo(_NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1* sourcePtr)
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

        private static unsafe NVAPIDisplayConfigTargetDto[] CreateTargets(uint targetCount, _NV_DISPLAYCONFIG_PATH_TARGET_INFO_V2* targetPtr)
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

        private static unsafe NVAPIDisplayConfigAdvancedTargetDto? CreateAdvancedTargetInfo(_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1* detailsPtr)
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

        private static unsafe long? ReadOsAdapterLuid(void* osAdapterId)
        {
            if (osAdapterId == null)
                return null;

            var luid = (Luid*)osAdapterId;
            var value = ((long)luid->HighPart << 32) | luid->LowPart;
            return value;
        }

        private static unsafe DisplayConfigBuffer CreateDisplayConfigBuffer(NVAPIDisplayConfigPathDto[] paths)
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
}
