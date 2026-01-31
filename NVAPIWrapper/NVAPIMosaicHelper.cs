using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <summary>
    /// Facade helper for Mosaic operations.
    /// </summary>
    public sealed class NVAPIMosaicHelper : IDisposable
    {
        private const uint NvApiIdMosaicGetSupportedTopoInfo = 0xFDB63C81;
        private const uint NvApiIdMosaicGetTopoGroup = 0xCB89381D;
        private const uint NvApiIdMosaicGetOverlapLimits = 0x989685F0;
        private const uint NvApiIdMosaicSetCurrentTopo = 0x9B542831;
        private const uint NvApiIdMosaicGetCurrentTopo = 0xEC32944E;
        private const uint NvApiIdMosaicEnableCurrentTopo = 0x5F1AA66C;
        private const uint NvApiIdMosaicGetDisplayViewportsByResolution = 0xDC6DC8D3;
        private const uint NvApiIdMosaicSetDisplayGrids = 0x4D959A89;
        private const uint NvApiIdMosaicValidateDisplayGrids = 0xCF43903D;
        private const uint NvApiIdMosaicEnumDisplayModes = 0x78DB97D7;
        private const uint NvApiIdMosaicEnumDisplayGrids = 0xDF2887AF;

        private readonly NVAPIApiHelper _apiHelper;
        private bool _disposed;

        internal NVAPIMosaicHelper(NVAPIApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        /// <summary>
        /// Create a supported topology info struct with the version initialized.
        /// </summary>
        public static _NV_MOSAIC_SUPPORTED_TOPO_INFO_V2 CreateSupportedTopoInfo()
        {
            return new _NV_MOSAIC_SUPPORTED_TOPO_INFO_V2
            {
                version = NVAPI.NVAPI_MOSAIC_SUPPORTED_TOPO_INFO_VER2
            };
        }

        /// <summary>
        /// Create a Mosaic topology brief struct with the version initialized.
        /// </summary>
        public static NV_MOSAIC_TOPO_BRIEF CreateTopoBrief()
        {
            return new NV_MOSAIC_TOPO_BRIEF
            {
                version = NVAPI.NVAPI_MOSAIC_TOPO_BRIEF_VER
            };
        }

        /// <summary>
        /// Create a Mosaic display setting struct (v2) with the version initialized.
        /// </summary>
        public static NV_MOSAIC_DISPLAY_SETTING_V2 CreateDisplaySetting()
        {
            return new NV_MOSAIC_DISPLAY_SETTING_V2
            {
                version = NVAPI.NVAPI_MOSAIC_DISPLAY_SETTING_VER2
            };
        }

        /// <summary>
        /// Create a Mosaic topology group struct with the version initialized.
        /// </summary>
        public static NV_MOSAIC_TOPO_GROUP CreateTopoGroup()
        {
            return new NV_MOSAIC_TOPO_GROUP
            {
                version = NVAPI.NVAPI_MOSAIC_TOPO_GROUP_VER
            };
        }

        /// <summary>
        /// Create a Mosaic grid topology (v2) with the version initialized.
        /// </summary>
        public static _NV_MOSAIC_GRID_TOPO_V2 CreateGridTopology()
        {
            return new _NV_MOSAIC_GRID_TOPO_V2
            {
                version = NVAPI.NV_MOSAIC_GRID_TOPO_VER,
                displaySettings = new _NV_MOSAIC_DISPLAY_SETTING_V1
                {
                    version = NVAPI.NVAPI_MOSAIC_DISPLAY_SETTING_VER1
                }
            };
        }

        /// <summary>
        /// Create a Mosaic display topology status struct with the version initialized.
        /// </summary>
        public static NV_MOSAIC_DISPLAY_TOPO_STATUS CreateDisplayTopoStatus()
        {
            return new NV_MOSAIC_DISPLAY_TOPO_STATUS
            {
                version = NVAPI.NV_MOSAIC_DISPLAY_TOPO_STATUS_VER
            };
        }

        /// <summary>
        /// Get supported Mosaic topologies and display settings.
        /// </summary>
        /// <param name="type">Topology type filter.</param>
        /// <returns>Supported topology info, or null if unavailable.</returns>
        public unsafe NVAPIMosaicSupportedTopoInfoDto? GetSupportedTopoInfo(NV_MOSAIC_TOPO_TYPE type = NV_MOSAIC_TOPO_TYPE.NV_MOSAIC_TOPO_TYPE_ALL)
        {
            ThrowIfDisposed();

            var getInfo = GetDelegate<NvApiMosaicGetSupportedTopoInfoDelegate>(
                NvApiIdMosaicGetSupportedTopoInfo,
                "NvAPI_Mosaic_GetSupportedTopoInfo");

            var info = CreateSupportedTopoInfo();
            var status = getInfo(&info, type);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIMosaicSupportedTopoInfoDto.FromNative(info);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get detailed topology group data for a given topology brief.
        /// </summary>
        /// <param name="topoBrief">Topology brief to query.</param>
        /// <returns>Topology group details, or null if unavailable.</returns>
        public unsafe NVAPIMosaicTopoGroupDto? GetTopoGroup(NVAPIMosaicTopoBriefDto topoBrief)
        {
            ThrowIfDisposed();

            var getGroup = GetDelegate<NvApiMosaicGetTopoGroupDelegate>(
                NvApiIdMosaicGetTopoGroup,
                "NvAPI_Mosaic_GetTopoGroup");

            var nativeBrief = topoBrief.ToNative();
            var group = CreateTopoGroup();

            var status = getGroup(&nativeBrief, &group);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIMosaicTopoGroupDto.FromNative(_apiHelper, group);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get overlap limits for a given topology and display setting.
        /// </summary>
        /// <param name="topoBrief">Topology brief.</param>
        /// <param name="displaySetting">Display setting.</param>
        /// <returns>Overlap limits, or null if unavailable.</returns>
        public unsafe NVAPIMosaicOverlapLimitsDto? GetOverlapLimits(NVAPIMosaicTopoBriefDto topoBrief, NVAPIMosaicDisplaySettingDto displaySetting)
        {
            ThrowIfDisposed();

            var getLimits = GetDelegate<NvApiMosaicGetOverlapLimitsDelegate>(
                NvApiIdMosaicGetOverlapLimits,
                "NvAPI_Mosaic_GetOverlapLimits");

            var nativeBrief = topoBrief.ToNative();
            var nativeSetting = displaySetting.ToNativeV2();
            int minX = 0;
            int maxX = 0;
            int minY = 0;
            int maxY = 0;

            var status = getLimits(&nativeBrief, &nativeSetting, &minX, &maxX, &minY, &maxY);
            if (status == _NvAPI_Status.NVAPI_OK)
                return new NVAPIMosaicOverlapLimitsDto(minX, maxX, minY, maxY);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Set the current Mosaic topology.
        /// </summary>
        /// <param name="topoBrief">Topology brief.</param>
        /// <param name="displaySetting">Display setting.</param>
        /// <param name="overlapX">Horizontal overlap.</param>
        /// <param name="overlapY">Vertical overlap.</param>
        /// <param name="enable">Enable after setting.</param>
        /// <returns>True if applied, false if unavailable.</returns>
        public unsafe bool SetCurrentTopo(NVAPIMosaicTopoBriefDto topoBrief, NVAPIMosaicDisplaySettingDto displaySetting, int overlapX, int overlapY, bool enable = true)
        {
            ThrowIfDisposed();

            var current = GetCurrentTopo();
            if (current.HasValue && current.Value.Equals(new NVAPIMosaicCurrentTopoDto(topoBrief, displaySetting, overlapX, overlapY)))
                return true;

            var setTopo = GetDelegate<NvApiMosaicSetCurrentTopoDelegate>(
                NvApiIdMosaicSetCurrentTopo,
                "NvAPI_Mosaic_SetCurrentTopo");

            var nativeBrief = topoBrief.ToNative();
            var nativeSetting = displaySetting.ToNativeV2();

            var status = setTopo(&nativeBrief, &nativeSetting, overlapX, overlapY, enable ? 1u : 0u);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the current Mosaic topology.
        /// </summary>
        /// <returns>Current topology info, or null if unavailable.</returns>
        public unsafe NVAPIMosaicCurrentTopoDto? GetCurrentTopo()
        {
            ThrowIfDisposed();

            var getTopo = GetDelegate<NvApiMosaicGetCurrentTopoDelegate>(
                NvApiIdMosaicGetCurrentTopo,
                "NvAPI_Mosaic_GetCurrentTopo");

            var brief = CreateTopoBrief();
            var display = CreateDisplaySetting();
            int overlapX = 0;
            int overlapY = 0;

            var status = getTopo(&brief, &display, &overlapX, &overlapY);
            if (status == _NvAPI_Status.NVAPI_OK)
                return new NVAPIMosaicCurrentTopoDto(
                    NVAPIMosaicTopoBriefDto.FromNative(brief),
                    NVAPIMosaicDisplaySettingDto.FromNative(display),
                    overlapX,
                    overlapY);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Enable or disable the current Mosaic topology.
        /// </summary>
        /// <param name="enable">Enable or disable.</param>
        /// <returns>True if applied, false if unavailable.</returns>
        public unsafe bool EnableCurrentTopo(bool enable)
        {
            ThrowIfDisposed();

            var enableTopo = GetDelegate<NvApiMosaicEnableCurrentTopoDelegate>(
                NvApiIdMosaicEnableCurrentTopo,
                "NvAPI_Mosaic_EnableCurrentTopo");

            var status = enableTopo(enable ? 1u : 0u);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get viewports for a display at a given resolution.
        /// </summary>
        /// <param name="displayId">Display ID.</param>
        /// <param name="srcWidth">Source width.</param>
        /// <param name="srcHeight">Source height.</param>
        /// <returns>Viewport data, or null if unavailable.</returns>
        public unsafe NVAPIMosaicViewportsDto? GetDisplayViewportsByResolution(uint displayId, uint srcWidth, uint srcHeight)
        {
            ThrowIfDisposed();

            var getViewports = GetDelegate<NvApiMosaicGetDisplayViewportsByResolutionDelegate>(
                NvApiIdMosaicGetDisplayViewportsByResolution,
                "NvAPI_Mosaic_GetDisplayViewportsByResolution");

            Span<_NV_RECT> viewports = stackalloc _NV_RECT[NVAPI.NV_MOSAIC_MAX_DISPLAYS];
            viewports.Clear();
            byte bezelCorrected = 0;

            fixed (_NV_RECT* pViewports = viewports)
            {
                var status = getViewports(displayId, srcWidth, srcHeight, pViewports, &bezelCorrected);
                if (status == _NvAPI_Status.NVAPI_OK)
                {
                    var rects = new NVAPIRectDto[viewports.Length];
                    for (var i = 0; i < rects.Length; i++)
                    {
                        rects[i] = NVAPIRectDto.FromNative(viewports[i]);
                    }

                    return new NVAPIMosaicViewportsDto(rects, bezelCorrected != 0);
                }

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                    || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                    || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return null;

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Set display grid topologies.
        /// </summary>
        /// <param name="grids">Grid topologies.</param>
        /// <param name="setTopoFlags">Set topology flags.</param>
        /// <returns>True if applied, false if unavailable.</returns>
        public unsafe bool SetDisplayGrids(NVAPIMosaicGridTopologiesDto grids, uint setTopoFlags = 0)
        {
            ThrowIfDisposed();

            var gridArray = grids.Grids ?? Array.Empty<NVAPIMosaicGridTopoDto>();
            if (gridArray.Length == 0)
                return false;

            var setGrids = GetDelegate<NvApiMosaicSetDisplayGridsDelegate>(
                NvApiIdMosaicSetDisplayGrids,
                "NvAPI_Mosaic_SetDisplayGrids");

            var nativeGrids = NVAPIMosaicGridTopologiesDto.ToNativeArray(gridArray);
            fixed (_NV_MOSAIC_GRID_TOPO_V2* pGrids = nativeGrids)
            {
                var status = setGrids(pGrids, (uint)nativeGrids.Length, setTopoFlags);
                if (status == _NvAPI_Status.NVAPI_OK)
                    return true;

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                    || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                    || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return false;

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Validate display grid topologies.
        /// </summary>
        /// <param name="setTopoFlags">Set topology flags.</param>
        /// <param name="grids">Grid topologies to validate.</param>
        /// <returns>Status results, or null if unavailable.</returns>
        public unsafe NVAPIMosaicDisplayTopoStatusesDto? ValidateDisplayGrids(uint setTopoFlags, NVAPIMosaicGridTopologiesDto grids)
        {
            ThrowIfDisposed();

            var gridArray = grids.Grids ?? Array.Empty<NVAPIMosaicGridTopoDto>();
            if (gridArray.Length == 0)
                return new NVAPIMosaicDisplayTopoStatusesDto(Array.Empty<NVAPIMosaicDisplayTopoStatusDto>());

            var validate = GetDelegate<NvApiMosaicValidateDisplayGridsDelegate>(
                NvApiIdMosaicValidateDisplayGrids,
                "NvAPI_Mosaic_ValidateDisplayGrids");

            var nativeGrids = NVAPIMosaicGridTopologiesDto.ToNativeArray(gridArray);
            var nativeStatus = new NV_MOSAIC_DISPLAY_TOPO_STATUS[nativeGrids.Length];
            for (var i = 0; i < nativeStatus.Length; i++)
            {
                nativeStatus[i].version = NVAPI.NV_MOSAIC_DISPLAY_TOPO_STATUS_VER;
            }

            fixed (_NV_MOSAIC_GRID_TOPO_V2* pGrids = nativeGrids)
            fixed (NV_MOSAIC_DISPLAY_TOPO_STATUS* pStatus = nativeStatus)
            {
                var status = validate(setTopoFlags, pGrids, pStatus, (uint)nativeGrids.Length);
                if (status == _NvAPI_Status.NVAPI_OK)
                {
                    var results = new NVAPIMosaicDisplayTopoStatusDto[nativeStatus.Length];
                    for (var i = 0; i < results.Length; i++)
                    {
                        results[i] = NVAPIMosaicDisplayTopoStatusDto.FromNative(nativeStatus[i]);
                    }

                    return new NVAPIMosaicDisplayTopoStatusesDto(results);
                }

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                    || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                    || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return null;

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Enumerate available display modes for a grid topology.
        /// </summary>
        /// <param name="gridTopology">Grid topology to query.</param>
        /// <returns>Display settings list, or null if unavailable.</returns>
        public unsafe NVAPIMosaicDisplaySettingsDto? EnumDisplayModes(NVAPIMosaicGridTopoDto gridTopology)
        {
            ThrowIfDisposed();

            var enumModes = GetDelegate<NvApiMosaicEnumDisplayModesDelegate>(
                NvApiIdMosaicEnumDisplayModes,
                "NvAPI_Mosaic_EnumDisplayModes");

            var nativeTopo = gridTopology.ToNative();
            uint count = 0;
            var status = enumModes(&nativeTopo, null, &count);
            if (status == _NvAPI_Status.NVAPI_OK && count == 0)
                return new NVAPIMosaicDisplaySettingsDto(Array.Empty<NVAPIMosaicDisplaySettingDto>());

            if (status != _NvAPI_Status.NVAPI_OK)
            {
                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                    || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                    || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return null;

                throw new NVAPIException(status);
            }

            var settings = new NV_MOSAIC_DISPLAY_SETTING_V2[count];
            for (var i = 0; i < settings.Length; i++)
            {
                settings[i].version = NVAPI.NVAPI_MOSAIC_DISPLAY_SETTING_VER2;
            }

            fixed (NV_MOSAIC_DISPLAY_SETTING_V2* pSettings = settings)
            {
                status = enumModes(&nativeTopo, pSettings, &count);
                if (status == _NvAPI_Status.NVAPI_OK)
                {
                    var result = new NVAPIMosaicDisplaySettingDto[count];
                    for (var i = 0; i < count; i++)
                    {
                        result[i] = NVAPIMosaicDisplaySettingDto.FromNative(settings[i]);
                    }

                    return new NVAPIMosaicDisplaySettingsDto(result);
                }

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                    || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                    || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return null;

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Enumerate current active grid topologies.
        /// </summary>
        /// <returns>Grid topologies, or null if unavailable.</returns>
        public unsafe NVAPIMosaicGridTopologiesDto? EnumDisplayGrids()
        {
            ThrowIfDisposed();

            var enumGrids = GetDelegate<NvApiMosaicEnumDisplayGridsDelegate>(
                NvApiIdMosaicEnumDisplayGrids,
                "NvAPI_Mosaic_EnumDisplayGrids");

            uint count = 0;
            var status = enumGrids(null, &count);
            if (status == _NvAPI_Status.NVAPI_OK && count == 0)
                return new NVAPIMosaicGridTopologiesDto(Array.Empty<NVAPIMosaicGridTopoDto>());

            if (status == _NvAPI_Status.NVAPI_END_ENUMERATION)
                return new NVAPIMosaicGridTopologiesDto(Array.Empty<NVAPIMosaicGridTopoDto>());

            if (status != _NvAPI_Status.NVAPI_OK)
            {
                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                    || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                    || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return null;

                throw new NVAPIException(status);
            }

            var grids = new _NV_MOSAIC_GRID_TOPO_V2[count];
            for (var i = 0; i < grids.Length; i++)
            {
                grids[i].version = NVAPI.NV_MOSAIC_GRID_TOPO_VER;
                grids[i].displaySettings.version = NVAPI.NVAPI_MOSAIC_DISPLAY_SETTING_VER1;
            }

            fixed (_NV_MOSAIC_GRID_TOPO_V2* pGrids = grids)
            {
                status = enumGrids(pGrids, &count);
                if (status == _NvAPI_Status.NVAPI_OK)
                    return NVAPIMosaicGridTopologiesDto.FromNative(count, grids);

                if (status == _NvAPI_Status.NVAPI_END_ENUMERATION)
                    return new NVAPIMosaicGridTopologiesDto(Array.Empty<NVAPIMosaicGridTopoDto>());

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                    || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                    || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return null;

                throw new NVAPIException(status);
            }
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
            if (_disposed)
                throw new ObjectDisposedException(nameof(NVAPIMosaicHelper));

            _apiHelper.ThrowIfDisposed();
        }

        /// <summary>
        /// Dispose the helper.
        /// </summary>
        public void Dispose()
        {
            _disposed = true;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiMosaicGetSupportedTopoInfoDelegate(_NV_MOSAIC_SUPPORTED_TOPO_INFO_V2* pSupportedTopoInfo, NV_MOSAIC_TOPO_TYPE type);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiMosaicGetTopoGroupDelegate(NV_MOSAIC_TOPO_BRIEF* pTopoBrief, NV_MOSAIC_TOPO_GROUP* pTopoGroup);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiMosaicGetOverlapLimitsDelegate(NV_MOSAIC_TOPO_BRIEF* pTopoBrief, NV_MOSAIC_DISPLAY_SETTING_V2* pDisplaySetting, int* pMinOverlapX, int* pMaxOverlapX, int* pMinOverlapY, int* pMaxOverlapY);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiMosaicSetCurrentTopoDelegate(NV_MOSAIC_TOPO_BRIEF* pTopoBrief, NV_MOSAIC_DISPLAY_SETTING_V2* pDisplaySetting, int overlapX, int overlapY, uint enable);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiMosaicGetCurrentTopoDelegate(NV_MOSAIC_TOPO_BRIEF* pTopoBrief, NV_MOSAIC_DISPLAY_SETTING_V2* pDisplaySetting, int* pOverlapX, int* pOverlapY);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiMosaicEnableCurrentTopoDelegate(uint enable);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiMosaicGetDisplayViewportsByResolutionDelegate(uint displayId, uint srcWidth, uint srcHeight, _NV_RECT* viewports, byte* bezelCorrected);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiMosaicSetDisplayGridsDelegate(_NV_MOSAIC_GRID_TOPO_V2* pGridTopologies, uint gridCount, uint setTopoFlags);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiMosaicValidateDisplayGridsDelegate(uint setTopoFlags, _NV_MOSAIC_GRID_TOPO_V2* pGridTopologies, NV_MOSAIC_DISPLAY_TOPO_STATUS* pTopoStatus, uint gridCount);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiMosaicEnumDisplayModesDelegate(_NV_MOSAIC_GRID_TOPO_V2* pGridTopology, NV_MOSAIC_DISPLAY_SETTING_V2* pDisplaySettings, uint* pDisplayCount);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiMosaicEnumDisplayGridsDelegate(_NV_MOSAIC_GRID_TOPO_V2* pGridTopologies, uint* pGridCount);
    }

    /// <summary>
    /// Snapshot of supported Mosaic topology data.
    /// </summary>
    public readonly struct NVAPIMosaicSupportedTopoInfoDto : IEquatable<NVAPIMosaicSupportedTopoInfoDto>
    {
        public NVAPIMosaicTopoBriefDto[] TopoBriefs { get; }
        public NVAPIMosaicDisplaySettingDto[] DisplaySettings { get; }

        public NVAPIMosaicSupportedTopoInfoDto(NVAPIMosaicTopoBriefDto[] topoBriefs, NVAPIMosaicDisplaySettingDto[] displaySettings)
        {
            TopoBriefs = topoBriefs ?? Array.Empty<NVAPIMosaicTopoBriefDto>();
            DisplaySettings = displaySettings ?? Array.Empty<NVAPIMosaicDisplaySettingDto>();
        }

        public static NVAPIMosaicSupportedTopoInfoDto FromNative(_NV_MOSAIC_SUPPORTED_TOPO_INFO_V2 native)
        {
            var topoCount = (int)Math.Min(native.topoBriefsCount, 35u);
            var displayCount = (int)Math.Min(native.displaySettingsCount, 40u);

            var topoSpan = MemoryMarshal.CreateSpan(ref native.topoBriefs.e0, 35);
            var topoBriefs = new NVAPIMosaicTopoBriefDto[topoCount];
            for (var i = 0; i < topoCount; i++)
            {
                topoBriefs[i] = NVAPIMosaicTopoBriefDto.FromNative(topoSpan[i]);
            }

            var displaySpan = MemoryMarshal.CreateSpan(ref native.displaySettings.e0, 40);
            var displaySettings = new NVAPIMosaicDisplaySettingDto[displayCount];
            for (var i = 0; i < displayCount; i++)
            {
                displaySettings[i] = NVAPIMosaicDisplaySettingDto.FromNative(displaySpan[i]);
            }

            return new NVAPIMosaicSupportedTopoInfoDto(topoBriefs, displaySettings);
        }

        public bool Equals(NVAPIMosaicSupportedTopoInfoDto other)
        {
            return DtoHelpers.SequenceEquals(TopoBriefs, other.TopoBriefs)
                && DtoHelpers.SequenceEquals(DisplaySettings, other.DisplaySettings);
        }

        public override bool Equals(object? obj) => obj is NVAPIMosaicSupportedTopoInfoDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = DtoHelpers.SequenceHashCode(TopoBriefs);
                hash = (hash * 31) + DtoHelpers.SequenceHashCode(DisplaySettings);
                return hash;
            }
        }

        public static bool operator ==(NVAPIMosaicSupportedTopoInfoDto left, NVAPIMosaicSupportedTopoInfoDto right) => left.Equals(right);
        public static bool operator !=(NVAPIMosaicSupportedTopoInfoDto left, NVAPIMosaicSupportedTopoInfoDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Mosaic topology brief DTO.
    /// </summary>
    public readonly struct NVAPIMosaicTopoBriefDto : IEquatable<NVAPIMosaicTopoBriefDto>
    {
        public NV_MOSAIC_TOPO Topo { get; }
        public bool Enabled { get; }
        public bool IsPossible { get; }

        public NVAPIMosaicTopoBriefDto(NV_MOSAIC_TOPO topo, bool enabled, bool isPossible)
        {
            Topo = topo;
            Enabled = enabled;
            IsPossible = isPossible;
        }

        public static NVAPIMosaicTopoBriefDto FromNative(NV_MOSAIC_TOPO_BRIEF native)
        {
            return new NVAPIMosaicTopoBriefDto(native.topo, native.enabled != 0, native.isPossible != 0);
        }

        public NV_MOSAIC_TOPO_BRIEF ToNative()
        {
            return new NV_MOSAIC_TOPO_BRIEF
            {
                version = NVAPI.NVAPI_MOSAIC_TOPO_BRIEF_VER,
                topo = Topo,
                enabled = Enabled ? 1u : 0u,
                isPossible = IsPossible ? 1u : 0u
            };
        }

        public bool Equals(NVAPIMosaicTopoBriefDto other)
        {
            return Topo == other.Topo && Enabled == other.Enabled && IsPossible == other.IsPossible;
        }

        public override bool Equals(object? obj) => obj is NVAPIMosaicTopoBriefDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = Topo.GetHashCode();
                hash = (hash * 31) + Enabled.GetHashCode();
                hash = (hash * 31) + IsPossible.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIMosaicTopoBriefDto left, NVAPIMosaicTopoBriefDto right) => left.Equals(right);
        public static bool operator !=(NVAPIMosaicTopoBriefDto left, NVAPIMosaicTopoBriefDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Mosaic display setting DTO (v2).
    /// </summary>
    public readonly struct NVAPIMosaicDisplaySettingDto : IEquatable<NVAPIMosaicDisplaySettingDto>
    {
        public uint Width { get; }
        public uint Height { get; }
        public uint BitsPerPixel { get; }
        public uint Frequency { get; }
        public uint RefreshRate1K { get; }

        public NVAPIMosaicDisplaySettingDto(uint width, uint height, uint bitsPerPixel, uint frequency, uint refreshRate1K)
        {
            Width = width;
            Height = height;
            BitsPerPixel = bitsPerPixel;
            Frequency = frequency;
            RefreshRate1K = refreshRate1K;
        }

        public static NVAPIMosaicDisplaySettingDto FromNative(NV_MOSAIC_DISPLAY_SETTING_V2 native)
        {
            return new NVAPIMosaicDisplaySettingDto(native.width, native.height, native.bpp, native.freq, native.rrx1k);
        }

        public static NVAPIMosaicDisplaySettingDto FromNative(_NV_MOSAIC_DISPLAY_SETTING_V1 native)
        {
            return new NVAPIMosaicDisplaySettingDto(native.width, native.height, native.bpp, native.freq, 0);
        }

        public NV_MOSAIC_DISPLAY_SETTING_V2 ToNativeV2()
        {
            return new NV_MOSAIC_DISPLAY_SETTING_V2
            {
                version = NVAPI.NVAPI_MOSAIC_DISPLAY_SETTING_VER2,
                width = Width,
                height = Height,
                bpp = BitsPerPixel,
                freq = Frequency,
                rrx1k = RefreshRate1K
            };
        }

        public _NV_MOSAIC_DISPLAY_SETTING_V1 ToNativeV1()
        {
            return new _NV_MOSAIC_DISPLAY_SETTING_V1
            {
                version = NVAPI.NVAPI_MOSAIC_DISPLAY_SETTING_VER1,
                width = Width,
                height = Height,
                bpp = BitsPerPixel,
                freq = Frequency
            };
        }

        public bool Equals(NVAPIMosaicDisplaySettingDto other)
        {
            return Width == other.Width
                && Height == other.Height
                && BitsPerPixel == other.BitsPerPixel
                && Frequency == other.Frequency
                && RefreshRate1K == other.RefreshRate1K;
        }

        public override bool Equals(object? obj) => obj is NVAPIMosaicDisplaySettingDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = Width.GetHashCode();
                hash = (hash * 31) + Height.GetHashCode();
                hash = (hash * 31) + BitsPerPixel.GetHashCode();
                hash = (hash * 31) + Frequency.GetHashCode();
                hash = (hash * 31) + RefreshRate1K.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIMosaicDisplaySettingDto left, NVAPIMosaicDisplaySettingDto right) => left.Equals(right);
        public static bool operator !=(NVAPIMosaicDisplaySettingDto left, NVAPIMosaicDisplaySettingDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Mosaic overlap limits DTO.
    /// </summary>
    public readonly struct NVAPIMosaicOverlapLimitsDto : IEquatable<NVAPIMosaicOverlapLimitsDto>
    {
        public int MinOverlapX { get; }
        public int MaxOverlapX { get; }
        public int MinOverlapY { get; }
        public int MaxOverlapY { get; }

        public NVAPIMosaicOverlapLimitsDto(int minOverlapX, int maxOverlapX, int minOverlapY, int maxOverlapY)
        {
            MinOverlapX = minOverlapX;
            MaxOverlapX = maxOverlapX;
            MinOverlapY = minOverlapY;
            MaxOverlapY = maxOverlapY;
        }

        public bool Equals(NVAPIMosaicOverlapLimitsDto other)
        {
            return MinOverlapX == other.MinOverlapX
                && MaxOverlapX == other.MaxOverlapX
                && MinOverlapY == other.MinOverlapY
                && MaxOverlapY == other.MaxOverlapY;
        }

        public override bool Equals(object? obj) => obj is NVAPIMosaicOverlapLimitsDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = MinOverlapX.GetHashCode();
                hash = (hash * 31) + MaxOverlapX.GetHashCode();
                hash = (hash * 31) + MinOverlapY.GetHashCode();
                hash = (hash * 31) + MaxOverlapY.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIMosaicOverlapLimitsDto left, NVAPIMosaicOverlapLimitsDto right) => left.Equals(right);
        public static bool operator !=(NVAPIMosaicOverlapLimitsDto left, NVAPIMosaicOverlapLimitsDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Current Mosaic topology DTO.
    /// </summary>
    public readonly struct NVAPIMosaicCurrentTopoDto : IEquatable<NVAPIMosaicCurrentTopoDto>
    {
        public NVAPIMosaicTopoBriefDto TopoBrief { get; }
        public NVAPIMosaicDisplaySettingDto DisplaySetting { get; }
        public int OverlapX { get; }
        public int OverlapY { get; }

        public NVAPIMosaicCurrentTopoDto(NVAPIMosaicTopoBriefDto topoBrief, NVAPIMosaicDisplaySettingDto displaySetting, int overlapX, int overlapY)
        {
            TopoBrief = topoBrief;
            DisplaySetting = displaySetting;
            OverlapX = overlapX;
            OverlapY = overlapY;
        }

        public bool Equals(NVAPIMosaicCurrentTopoDto other)
        {
            return TopoBrief.Equals(other.TopoBrief)
                && DisplaySetting.Equals(other.DisplaySetting)
                && OverlapX == other.OverlapX
                && OverlapY == other.OverlapY;
        }

        public override bool Equals(object? obj) => obj is NVAPIMosaicCurrentTopoDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = TopoBrief.GetHashCode();
                hash = (hash * 31) + DisplaySetting.GetHashCode();
                hash = (hash * 31) + OverlapX.GetHashCode();
                hash = (hash * 31) + OverlapY.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIMosaicCurrentTopoDto left, NVAPIMosaicCurrentTopoDto right) => left.Equals(right);
        public static bool operator !=(NVAPIMosaicCurrentTopoDto left, NVAPIMosaicCurrentTopoDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Mosaic topology group DTO.
    /// </summary>
    public readonly struct NVAPIMosaicTopoGroupDto : IEquatable<NVAPIMosaicTopoGroupDto>
    {
        public NVAPIMosaicTopoBriefDto Brief { get; }
        public NVAPIMosaicTopoDetailsDto[] Topos { get; }

        public NVAPIMosaicTopoGroupDto(NVAPIMosaicTopoBriefDto brief, NVAPIMosaicTopoDetailsDto[] topos)
        {
            Brief = brief;
            Topos = topos ?? Array.Empty<NVAPIMosaicTopoDetailsDto>();
        }

        public static NVAPIMosaicTopoGroupDto FromNative(NVAPIApiHelper apiHelper, NV_MOSAIC_TOPO_GROUP native)
        {
            var count = (int)Math.Min(native.count, 2u);
            var span = MemoryMarshal.CreateSpan(ref native.topos.e0, 2);
            var details = new NVAPIMosaicTopoDetailsDto[count];
            for (var i = 0; i < count; i++)
            {
                details[i] = NVAPIMosaicTopoDetailsDto.FromNative(apiHelper, span[i]);
            }

            return new NVAPIMosaicTopoGroupDto(NVAPIMosaicTopoBriefDto.FromNative(native.brief), details);
        }

        public bool Equals(NVAPIMosaicTopoGroupDto other)
        {
            return Brief.Equals(other.Brief) && DtoHelpers.SequenceEquals(Topos, other.Topos);
        }

        public override bool Equals(object? obj) => obj is NVAPIMosaicTopoGroupDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = Brief.GetHashCode();
                hash = (hash * 31) + DtoHelpers.SequenceHashCode(Topos);
                return hash;
            }
        }

        public static bool operator ==(NVAPIMosaicTopoGroupDto left, NVAPIMosaicTopoGroupDto right) => left.Equals(right);
        public static bool operator !=(NVAPIMosaicTopoGroupDto left, NVAPIMosaicTopoGroupDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Mosaic topology details DTO.
    /// </summary>
    public readonly struct NVAPIMosaicTopoDetailsDto : IEquatable<NVAPIMosaicTopoDetailsDto>
    {
        internal IntPtr LogicalGpuHandle { get; }
        public NVAPILogicalGpuHelper? LogicalGpu { get; }
        public uint ValidityMask { get; }
        public uint RowCount { get; }
        public uint ColCount { get; }
        public NVAPIMosaicGpuLayoutCellDto[] GpuLayout { get; }

        public NVAPIMosaicTopoDetailsDto(IntPtr logicalGpuHandle, uint validityMask, uint rowCount, uint colCount, NVAPIMosaicGpuLayoutCellDto[] gpuLayout)
        {
            LogicalGpuHandle = logicalGpuHandle;
            LogicalGpu = null;
            ValidityMask = validityMask;
            RowCount = rowCount;
            ColCount = colCount;
            GpuLayout = gpuLayout ?? Array.Empty<NVAPIMosaicGpuLayoutCellDto>();
        }

        internal NVAPIMosaicTopoDetailsDto(IntPtr logicalGpuHandle, NVAPILogicalGpuHelper logicalGpu, uint validityMask, uint rowCount, uint colCount, NVAPIMosaicGpuLayoutCellDto[] gpuLayout)
        {
            LogicalGpuHandle = logicalGpuHandle;
            LogicalGpu = logicalGpu;
            ValidityMask = validityMask;
            RowCount = rowCount;
            ColCount = colCount;
            GpuLayout = gpuLayout ?? Array.Empty<NVAPIMosaicGpuLayoutCellDto>();
        }

        public static unsafe NVAPIMosaicTopoDetailsDto FromNative(NVAPIApiHelper apiHelper, NV_MOSAIC_TOPO_DETAILS native)
        {
            var layoutCount = (int)Math.Min((ulong)native.rowCount * native.colCount, 64ul);
            var span = MemoryMarshal.CreateSpan(ref native.gpuLayout.e0_0, 64);
            var layout = new NVAPIMosaicGpuLayoutCellDto[layoutCount];
            for (var i = 0; i < layoutCount; i++)
            {
                layout[i] = NVAPIMosaicGpuLayoutCellDto.FromNative(apiHelper, span[i]);
            }

            var handle = (IntPtr)native.hLogicalGPU;
            var helper = new NVAPILogicalGpuHelper(apiHelper, handle);
            return new NVAPIMosaicTopoDetailsDto(handle, helper, native.validityMask, native.rowCount, native.colCount, layout);
        }

        public unsafe NV_MOSAIC_TOPO_DETAILS ToNative()
        {
            var native = new NV_MOSAIC_TOPO_DETAILS
            {
                version = NVAPI.NVAPI_MOSAIC_TOPO_DETAILS_VER,
                hLogicalGPU = (NvLogicalGpuHandle__*)LogicalGpuHandle,
                validityMask = ValidityMask,
                rowCount = RowCount,
                colCount = ColCount
            };

            var span = MemoryMarshal.CreateSpan(ref native.gpuLayout.e0_0, 64);
            span.Clear();
            var count = Math.Min(GpuLayout.Length, 64);
            for (var i = 0; i < count; i++)
            {
                span[i] = GpuLayout[i].ToNative();
            }

            return native;
        }

        public bool Equals(NVAPIMosaicTopoDetailsDto other)
        {
            return LogicalGpuHandle == other.LogicalGpuHandle
                && ValidityMask == other.ValidityMask
                && RowCount == other.RowCount
                && ColCount == other.ColCount
                && DtoHelpers.SequenceEquals(GpuLayout, other.GpuLayout);
        }

        public override bool Equals(object? obj) => obj is NVAPIMosaicTopoDetailsDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = LogicalGpuHandle.GetHashCode();
                hash = (hash * 31) + ValidityMask.GetHashCode();
                hash = (hash * 31) + RowCount.GetHashCode();
                hash = (hash * 31) + ColCount.GetHashCode();
                hash = (hash * 31) + DtoHelpers.SequenceHashCode(GpuLayout);
                return hash;
            }
        }

        public static bool operator ==(NVAPIMosaicTopoDetailsDto left, NVAPIMosaicTopoDetailsDto right) => left.Equals(right);
        public static bool operator !=(NVAPIMosaicTopoDetailsDto left, NVAPIMosaicTopoDetailsDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Mosaic GPU layout cell DTO.
    /// </summary>
    public readonly struct NVAPIMosaicGpuLayoutCellDto : IEquatable<NVAPIMosaicGpuLayoutCellDto>
    {
        internal IntPtr PhysicalGpuHandle { get; }
        public NVAPIPhysicalGpuHelper? PhysicalGpu { get; }
        public uint DisplayOutputId { get; }
        public int OverlapX { get; }
        public int OverlapY { get; }

        public NVAPIMosaicGpuLayoutCellDto(IntPtr physicalGpuHandle, uint displayOutputId, int overlapX, int overlapY)
        {
            PhysicalGpuHandle = physicalGpuHandle;
            PhysicalGpu = null;
            DisplayOutputId = displayOutputId;
            OverlapX = overlapX;
            OverlapY = overlapY;
        }

        internal NVAPIMosaicGpuLayoutCellDto(IntPtr physicalGpuHandle, NVAPIPhysicalGpuHelper physicalGpu, uint displayOutputId, int overlapX, int overlapY)
        {
            PhysicalGpuHandle = physicalGpuHandle;
            PhysicalGpu = physicalGpu;
            DisplayOutputId = displayOutputId;
            OverlapX = overlapX;
            OverlapY = overlapY;
        }

        public static unsafe NVAPIMosaicGpuLayoutCellDto FromNative(NVAPIApiHelper apiHelper, NV_MOSAIC_GPU_LAYOUT_CELL native)
        {
            var handle = (IntPtr)native.hPhysicalGPU;
            var helper = new NVAPIPhysicalGpuHelper(apiHelper, handle);
            return new NVAPIMosaicGpuLayoutCellDto(handle, helper, native.displayOutputId, native.overlapX, native.overlapY);
        }

        public unsafe NV_MOSAIC_GPU_LAYOUT_CELL ToNative()
        {
            return new NV_MOSAIC_GPU_LAYOUT_CELL
            {
                hPhysicalGPU = (NvPhysicalGpuHandle__*)PhysicalGpuHandle,
                displayOutputId = DisplayOutputId,
                overlapX = OverlapX,
                overlapY = OverlapY
            };
        }

        public bool Equals(NVAPIMosaicGpuLayoutCellDto other)
        {
            return PhysicalGpuHandle == other.PhysicalGpuHandle
                && DisplayOutputId == other.DisplayOutputId
                && OverlapX == other.OverlapX
                && OverlapY == other.OverlapY;
        }

        public override bool Equals(object? obj) => obj is NVAPIMosaicGpuLayoutCellDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = PhysicalGpuHandle.GetHashCode();
                hash = (hash * 31) + DisplayOutputId.GetHashCode();
                hash = (hash * 31) + OverlapX.GetHashCode();
                hash = (hash * 31) + OverlapY.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIMosaicGpuLayoutCellDto left, NVAPIMosaicGpuLayoutCellDto right) => left.Equals(right);
        public static bool operator !=(NVAPIMosaicGpuLayoutCellDto left, NVAPIMosaicGpuLayoutCellDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Mosaic grid display DTO.
    /// </summary>
    public readonly struct NVAPIMosaicGridTopoDisplayDto : IEquatable<NVAPIMosaicGridTopoDisplayDto>
    {
        public uint DisplayId { get; }
        public int OverlapX { get; }
        public int OverlapY { get; }
        public _NV_ROTATE Rotation { get; }
        public uint CloneGroup { get; }
        public _NV_PIXEL_SHIFT_TYPE PixelShiftType { get; }

        public NVAPIMosaicGridTopoDisplayDto(uint displayId, int overlapX, int overlapY, _NV_ROTATE rotation, uint cloneGroup, _NV_PIXEL_SHIFT_TYPE pixelShiftType)
        {
            DisplayId = displayId;
            OverlapX = overlapX;
            OverlapY = overlapY;
            Rotation = rotation;
            CloneGroup = cloneGroup;
            PixelShiftType = pixelShiftType;
        }

        public static NVAPIMosaicGridTopoDisplayDto FromNative(_NV_MOSAIC_GRID_TOPO_DISPLAY_V2 native)
        {
            return new NVAPIMosaicGridTopoDisplayDto(
                native.displayId,
                native.overlapX,
                native.overlapY,
                native.rotation,
                native.cloneGroup,
                native.pixelShiftType);
        }

        public unsafe _NV_MOSAIC_GRID_TOPO_DISPLAY_V2 ToNative()
        {
            return new _NV_MOSAIC_GRID_TOPO_DISPLAY_V2
            {
                version = GetVersion(),
                displayId = DisplayId,
                overlapX = OverlapX,
                overlapY = OverlapY,
                rotation = Rotation,
                cloneGroup = CloneGroup,
                pixelShiftType = PixelShiftType
            };
        }

        private static unsafe uint GetVersion()
        {
            return (uint)(sizeof(_NV_MOSAIC_GRID_TOPO_DISPLAY_V2) | (2u << 16));
        }

        public bool Equals(NVAPIMosaicGridTopoDisplayDto other)
        {
            return DisplayId == other.DisplayId
                && OverlapX == other.OverlapX
                && OverlapY == other.OverlapY
                && Rotation == other.Rotation
                && CloneGroup == other.CloneGroup
                && PixelShiftType == other.PixelShiftType;
        }

        public override bool Equals(object? obj) => obj is NVAPIMosaicGridTopoDisplayDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = DisplayId.GetHashCode();
                hash = (hash * 31) + OverlapX.GetHashCode();
                hash = (hash * 31) + OverlapY.GetHashCode();
                hash = (hash * 31) + Rotation.GetHashCode();
                hash = (hash * 31) + CloneGroup.GetHashCode();
                hash = (hash * 31) + PixelShiftType.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIMosaicGridTopoDisplayDto left, NVAPIMosaicGridTopoDisplayDto right) => left.Equals(right);
        public static bool operator !=(NVAPIMosaicGridTopoDisplayDto left, NVAPIMosaicGridTopoDisplayDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Mosaic grid topology DTO.
    /// </summary>
    public readonly struct NVAPIMosaicGridTopoDto : IEquatable<NVAPIMosaicGridTopoDto>
    {
        public uint Rows { get; }
        public uint Columns { get; }
        public bool ApplyWithBezelCorrect { get; }
        public bool ImmersiveGaming { get; }
        public bool BaseMosaic { get; }
        public bool DriverReloadAllowed { get; }
        public bool AcceleratePrimaryDisplay { get; }
        public bool PixelShift { get; }
        public NVAPIMosaicGridTopoDisplayDto[] Displays { get; }
        public NVAPIMosaicDisplaySettingDto DisplaySettings { get; }

        public NVAPIMosaicGridTopoDto(
            uint rows,
            uint columns,
            bool applyWithBezelCorrect,
            bool immersiveGaming,
            bool baseMosaic,
            bool driverReloadAllowed,
            bool acceleratePrimaryDisplay,
            bool pixelShift,
            NVAPIMosaicGridTopoDisplayDto[] displays,
            NVAPIMosaicDisplaySettingDto displaySettings)
        {
            Rows = rows;
            Columns = columns;
            ApplyWithBezelCorrect = applyWithBezelCorrect;
            ImmersiveGaming = immersiveGaming;
            BaseMosaic = baseMosaic;
            DriverReloadAllowed = driverReloadAllowed;
            AcceleratePrimaryDisplay = acceleratePrimaryDisplay;
            PixelShift = pixelShift;
            Displays = displays ?? Array.Empty<NVAPIMosaicGridTopoDisplayDto>();
            DisplaySettings = displaySettings;
        }

        public static NVAPIMosaicGridTopoDto FromNative(_NV_MOSAIC_GRID_TOPO_V2 native)
        {
            var count = (int)Math.Min(native.displayCount, NVAPI.NV_MOSAIC_MAX_DISPLAYS);
            var span = MemoryMarshal.CreateSpan(ref native.displays.e0, NVAPI.NV_MOSAIC_MAX_DISPLAYS);
            var displays = new NVAPIMosaicGridTopoDisplayDto[count];
            for (var i = 0; i < count; i++)
            {
                displays[i] = NVAPIMosaicGridTopoDisplayDto.FromNative(span[i]);
            }

            return new NVAPIMosaicGridTopoDto(
                native.rows,
                native.columns,
                native.applyWithBezelCorrect != 0,
                native.immersiveGaming != 0,
                native.baseMosaic != 0,
                native.driverReloadAllowed != 0,
                native.acceleratePrimaryDisplay != 0,
                native.pixelShift != 0,
                displays,
                NVAPIMosaicDisplaySettingDto.FromNative(native.displaySettings));
        }

        public unsafe _NV_MOSAIC_GRID_TOPO_V2 ToNative()
        {
            var native = new _NV_MOSAIC_GRID_TOPO_V2
            {
                version = NVAPI.NV_MOSAIC_GRID_TOPO_VER,
                rows = Rows,
                columns = Columns,
                displayCount = (uint)Math.Min(Displays.Length, NVAPI.NV_MOSAIC_MAX_DISPLAYS),
                displaySettings = DisplaySettings.ToNativeV1()
            };

            native.applyWithBezelCorrect = ApplyWithBezelCorrect ? 1u : 0u;
            native.immersiveGaming = ImmersiveGaming ? 1u : 0u;
            native.baseMosaic = BaseMosaic ? 1u : 0u;
            native.driverReloadAllowed = DriverReloadAllowed ? 1u : 0u;
            native.acceleratePrimaryDisplay = AcceleratePrimaryDisplay ? 1u : 0u;
            native.pixelShift = PixelShift ? 1u : 0u;
            native.reserved = 0;

            var span = MemoryMarshal.CreateSpan(ref native.displays.e0, NVAPI.NV_MOSAIC_MAX_DISPLAYS);
            span.Clear();
            var count = (int)native.displayCount;
            for (var i = 0; i < count; i++)
            {
                span[i] = Displays[i].ToNative();
            }

            return native;
        }

        public bool Equals(NVAPIMosaicGridTopoDto other)
        {
            return Rows == other.Rows
                && Columns == other.Columns
                && ApplyWithBezelCorrect == other.ApplyWithBezelCorrect
                && ImmersiveGaming == other.ImmersiveGaming
                && BaseMosaic == other.BaseMosaic
                && DriverReloadAllowed == other.DriverReloadAllowed
                && AcceleratePrimaryDisplay == other.AcceleratePrimaryDisplay
                && PixelShift == other.PixelShift
                && DisplaySettings.Equals(other.DisplaySettings)
                && DtoHelpers.SequenceEquals(Displays, other.Displays);
        }

        public override bool Equals(object? obj) => obj is NVAPIMosaicGridTopoDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = Rows.GetHashCode();
                hash = (hash * 31) + Columns.GetHashCode();
                hash = (hash * 31) + ApplyWithBezelCorrect.GetHashCode();
                hash = (hash * 31) + ImmersiveGaming.GetHashCode();
                hash = (hash * 31) + BaseMosaic.GetHashCode();
                hash = (hash * 31) + DriverReloadAllowed.GetHashCode();
                hash = (hash * 31) + AcceleratePrimaryDisplay.GetHashCode();
                hash = (hash * 31) + PixelShift.GetHashCode();
                hash = (hash * 31) + DisplaySettings.GetHashCode();
                hash = (hash * 31) + DtoHelpers.SequenceHashCode(Displays);
                return hash;
            }
        }

        public static bool operator ==(NVAPIMosaicGridTopoDto left, NVAPIMosaicGridTopoDto right) => left.Equals(right);
        public static bool operator !=(NVAPIMosaicGridTopoDto left, NVAPIMosaicGridTopoDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Mosaic grid topology collection DTO.
    /// </summary>
    public readonly struct NVAPIMosaicGridTopologiesDto : IEquatable<NVAPIMosaicGridTopologiesDto>
    {
        public NVAPIMosaicGridTopoDto[] Grids { get; }

        public NVAPIMosaicGridTopologiesDto(NVAPIMosaicGridTopoDto[] grids)
        {
            Grids = grids ?? Array.Empty<NVAPIMosaicGridTopoDto>();
        }

        public static NVAPIMosaicGridTopologiesDto FromNative(uint count, _NV_MOSAIC_GRID_TOPO_V2[] native)
        {
            var gridCount = (int)Math.Min(count, (uint)native.Length);
            var grids = new NVAPIMosaicGridTopoDto[gridCount];
            for (var i = 0; i < gridCount; i++)
            {
                grids[i] = NVAPIMosaicGridTopoDto.FromNative(native[i]);
            }

            return new NVAPIMosaicGridTopologiesDto(grids);
        }

        internal static _NV_MOSAIC_GRID_TOPO_V2[] ToNativeArray(NVAPIMosaicGridTopoDto[] grids)
        {
            var native = new _NV_MOSAIC_GRID_TOPO_V2[grids.Length];
            for (var i = 0; i < grids.Length; i++)
            {
                native[i] = grids[i].ToNative();
            }

            return native;
        }

        public bool Equals(NVAPIMosaicGridTopologiesDto other)
        {
            return DtoHelpers.SequenceEquals(Grids, other.Grids);
        }

        public override bool Equals(object? obj) => obj is NVAPIMosaicGridTopologiesDto other && Equals(other);

        public override int GetHashCode() => DtoHelpers.SequenceHashCode(Grids);

        public static bool operator ==(NVAPIMosaicGridTopologiesDto left, NVAPIMosaicGridTopologiesDto right) => left.Equals(right);
        public static bool operator !=(NVAPIMosaicGridTopologiesDto left, NVAPIMosaicGridTopologiesDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Mosaic display modes DTO.
    /// </summary>
    public readonly struct NVAPIMosaicDisplaySettingsDto : IEquatable<NVAPIMosaicDisplaySettingsDto>
    {
        public NVAPIMosaicDisplaySettingDto[] Settings { get; }

        public NVAPIMosaicDisplaySettingsDto(NVAPIMosaicDisplaySettingDto[] settings)
        {
            Settings = settings ?? Array.Empty<NVAPIMosaicDisplaySettingDto>();
        }

        public bool Equals(NVAPIMosaicDisplaySettingsDto other)
        {
            return DtoHelpers.SequenceEquals(Settings, other.Settings);
        }

        public override bool Equals(object? obj) => obj is NVAPIMosaicDisplaySettingsDto other && Equals(other);

        public override int GetHashCode() => DtoHelpers.SequenceHashCode(Settings);

        public static bool operator ==(NVAPIMosaicDisplaySettingsDto left, NVAPIMosaicDisplaySettingsDto right) => left.Equals(right);
        public static bool operator !=(NVAPIMosaicDisplaySettingsDto left, NVAPIMosaicDisplaySettingsDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Mosaic display topology status entry DTO.
    /// </summary>
    public readonly struct NVAPIMosaicDisplayStatusEntryDto : IEquatable<NVAPIMosaicDisplayStatusEntryDto>
    {
        public uint DisplayId { get; }
        public uint ErrorFlags { get; }
        public uint WarningFlags { get; }
        public bool SupportsRotation { get; }

        public NVAPIMosaicDisplayStatusEntryDto(uint displayId, uint errorFlags, uint warningFlags, bool supportsRotation)
        {
            DisplayId = displayId;
            ErrorFlags = errorFlags;
            WarningFlags = warningFlags;
            SupportsRotation = supportsRotation;
        }

        public static NVAPIMosaicDisplayStatusEntryDto FromNative(NV_MOSAIC_DISPLAY_TOPO_STATUS._displays_e__Struct native)
        {
            return new NVAPIMosaicDisplayStatusEntryDto(
                native.displayId,
                native.errorFlags,
                native.warningFlags,
                native.supportsRotation != 0);
        }

        public bool Equals(NVAPIMosaicDisplayStatusEntryDto other)
        {
            return DisplayId == other.DisplayId
                && ErrorFlags == other.ErrorFlags
                && WarningFlags == other.WarningFlags
                && SupportsRotation == other.SupportsRotation;
        }

        public override bool Equals(object? obj) => obj is NVAPIMosaicDisplayStatusEntryDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = DisplayId.GetHashCode();
                hash = (hash * 31) + ErrorFlags.GetHashCode();
                hash = (hash * 31) + WarningFlags.GetHashCode();
                hash = (hash * 31) + SupportsRotation.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIMosaicDisplayStatusEntryDto left, NVAPIMosaicDisplayStatusEntryDto right) => left.Equals(right);
        public static bool operator !=(NVAPIMosaicDisplayStatusEntryDto left, NVAPIMosaicDisplayStatusEntryDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Mosaic display topology status DTO.
    /// </summary>
    public readonly struct NVAPIMosaicDisplayTopoStatusDto : IEquatable<NVAPIMosaicDisplayTopoStatusDto>
    {
        public uint ErrorFlags { get; }
        public uint WarningFlags { get; }
        public NVAPIMosaicDisplayStatusEntryDto[] Displays { get; }

        public NVAPIMosaicDisplayTopoStatusDto(uint errorFlags, uint warningFlags, NVAPIMosaicDisplayStatusEntryDto[] displays)
        {
            ErrorFlags = errorFlags;
            WarningFlags = warningFlags;
            Displays = displays ?? Array.Empty<NVAPIMosaicDisplayStatusEntryDto>();
        }

        public static NVAPIMosaicDisplayTopoStatusDto FromNative(NV_MOSAIC_DISPLAY_TOPO_STATUS native)
        {
            var count = (int)Math.Min(native.displayCount, 128u);
            var span = MemoryMarshal.CreateSpan(ref native.displays.e0, 128);
            var displays = new NVAPIMosaicDisplayStatusEntryDto[count];
            for (var i = 0; i < count; i++)
            {
                displays[i] = NVAPIMosaicDisplayStatusEntryDto.FromNative(span[i]);
            }

            return new NVAPIMosaicDisplayTopoStatusDto(native.errorFlags, native.warningFlags, displays);
        }

        public bool Equals(NVAPIMosaicDisplayTopoStatusDto other)
        {
            return ErrorFlags == other.ErrorFlags
                && WarningFlags == other.WarningFlags
                && DtoHelpers.SequenceEquals(Displays, other.Displays);
        }

        public override bool Equals(object? obj) => obj is NVAPIMosaicDisplayTopoStatusDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = ErrorFlags.GetHashCode();
                hash = (hash * 31) + WarningFlags.GetHashCode();
                hash = (hash * 31) + DtoHelpers.SequenceHashCode(Displays);
                return hash;
            }
        }

        public static bool operator ==(NVAPIMosaicDisplayTopoStatusDto left, NVAPIMosaicDisplayTopoStatusDto right) => left.Equals(right);
        public static bool operator !=(NVAPIMosaicDisplayTopoStatusDto left, NVAPIMosaicDisplayTopoStatusDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Mosaic display topology status collection DTO.
    /// </summary>
    public readonly struct NVAPIMosaicDisplayTopoStatusesDto : IEquatable<NVAPIMosaicDisplayTopoStatusesDto>
    {
        public NVAPIMosaicDisplayTopoStatusDto[] Statuses { get; }

        public NVAPIMosaicDisplayTopoStatusesDto(NVAPIMosaicDisplayTopoStatusDto[] statuses)
        {
            Statuses = statuses ?? Array.Empty<NVAPIMosaicDisplayTopoStatusDto>();
        }

        public bool Equals(NVAPIMosaicDisplayTopoStatusesDto other)
        {
            return DtoHelpers.SequenceEquals(Statuses, other.Statuses);
        }

        public override bool Equals(object? obj) => obj is NVAPIMosaicDisplayTopoStatusesDto other && Equals(other);

        public override int GetHashCode() => DtoHelpers.SequenceHashCode(Statuses);

        public static bool operator ==(NVAPIMosaicDisplayTopoStatusesDto left, NVAPIMosaicDisplayTopoStatusesDto right) => left.Equals(right);
        public static bool operator !=(NVAPIMosaicDisplayTopoStatusesDto left, NVAPIMosaicDisplayTopoStatusesDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Rectangle DTO for Mosaic viewports.
    /// </summary>
    public readonly struct NVAPIRectDto : IEquatable<NVAPIRectDto>
    {
        public uint Left { get; }
        public uint Top { get; }
        public uint Right { get; }
        public uint Bottom { get; }

        public NVAPIRectDto(uint left, uint top, uint right, uint bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public static NVAPIRectDto FromNative(_NV_RECT native)
        {
            return new NVAPIRectDto(native.left, native.top, native.right, native.bottom);
        }

        public _NV_RECT ToNative()
        {
            return new _NV_RECT
            {
                left = Left,
                top = Top,
                right = Right,
                bottom = Bottom
            };
        }

        public bool Equals(NVAPIRectDto other)
        {
            return Left == other.Left && Top == other.Top && Right == other.Right && Bottom == other.Bottom;
        }

        public override bool Equals(object? obj) => obj is NVAPIRectDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = Left.GetHashCode();
                hash = (hash * 31) + Top.GetHashCode();
                hash = (hash * 31) + Right.GetHashCode();
                hash = (hash * 31) + Bottom.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIRectDto left, NVAPIRectDto right) => left.Equals(right);
        public static bool operator !=(NVAPIRectDto left, NVAPIRectDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Mosaic viewport list DTO.
    /// </summary>
    public readonly struct NVAPIMosaicViewportsDto : IEquatable<NVAPIMosaicViewportsDto>
    {
        public NVAPIRectDto[] Viewports { get; }
        public bool BezelCorrected { get; }

        public NVAPIMosaicViewportsDto(NVAPIRectDto[] viewports, bool bezelCorrected)
        {
            Viewports = viewports ?? Array.Empty<NVAPIRectDto>();
            BezelCorrected = bezelCorrected;
        }

        public bool Equals(NVAPIMosaicViewportsDto other)
        {
            return BezelCorrected == other.BezelCorrected
                && DtoHelpers.SequenceEquals(Viewports, other.Viewports);
        }

        public override bool Equals(object? obj) => obj is NVAPIMosaicViewportsDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = BezelCorrected.GetHashCode();
                hash = (hash * 31) + DtoHelpers.SequenceHashCode(Viewports);
                return hash;
            }
        }

        public static bool operator ==(NVAPIMosaicViewportsDto left, NVAPIMosaicViewportsDto right) => left.Equals(right);
        public static bool operator !=(NVAPIMosaicViewportsDto left, NVAPIMosaicViewportsDto right) => !left.Equals(right);
    }

    /// <summary>Represents a Mosaic GPU layout cell entry.</summary>
    public unsafe partial struct NV_MOSAIC_GPU_LAYOUT_CELL
    {
        /// <summary>Physical GPU to be used in the topology.</summary>
        [NativeTypeName("NvPhysicalGpuHandle")]
        public NvPhysicalGpuHandle__* hPhysicalGPU;

        /// <summary>Connected display target.</summary>
        [NativeTypeName("NvU32")]
        public uint displayOutputId;

        /// <summary>Pixels of overlap on left of target (+overlap, -gap).</summary>
        [NativeTypeName("NvS32")]
        public int overlapX;

        /// <summary>Pixels of overlap on top of target (+overlap, -gap).</summary>
        [NativeTypeName("NvS32")]
        public int overlapY;
    }

    /// <summary>Defines the Mosaic topology details.</summary>
    public unsafe partial struct NV_MOSAIC_TOPO_DETAILS
    {
        /// <summary>Version of this structure.</summary>
        [NativeTypeName("NvU32")]
        public uint version;

        /// <summary>Logical GPU for this topology.</summary>
        [NativeTypeName("NvLogicalGpuHandle")]
        public NvLogicalGpuHandle__* hLogicalGPU;

        /// <summary>Validity mask for the topology.</summary>
        [NativeTypeName("NvU32")]
        public uint validityMask;

        /// <summary>Number of displays in a row.</summary>
        [NativeTypeName("NvU32")]
        public uint rowCount;

        /// <summary>Number of displays in a column.</summary>
        [NativeTypeName("NvU32")]
        public uint colCount;

        /// <summary>GPU layout table for the topology.</summary>
        [NativeTypeName("struct (anonymous struct at ./../nvapi/nvapi.h:9584:5)[8][8]")]
        public _gpuLayout_e__FixedBuffer gpuLayout;

        /// <summary>Fixed buffer for the GPU layout table.</summary>
        [InlineArray(8 * 8)]
        public partial struct _gpuLayout_e__FixedBuffer
        {
            public NV_MOSAIC_GPU_LAYOUT_CELL e0_0;
        }
    }

    /// <summary>Used in legacy Mosaic topology APIs.</summary>
    public partial struct NV_MOSAIC_TOPOLOGY
    {
        /// <summary>Version number of the mosaic topology.</summary>
        [NativeTypeName("NvU32")]
        public uint version;

        /// <summary>Horizontal display count.</summary>
        [NativeTypeName("NvU32")]
        public uint rowCount;

        /// <summary>Vertical display count.</summary>
        [NativeTypeName("NvU32")]
        public uint colCount;

        /// <summary>GPU layout table for the topology.</summary>
        [NativeTypeName("struct (anonymous struct at ./../nvapi/nvapi.h:10429:5)[8][8]")]
        public _gpuLayout_e__FixedBuffer gpuLayout;

        /// <summary>Fixed buffer for the GPU layout table.</summary>
        [InlineArray(8 * 8)]
        public partial struct _gpuLayout_e__FixedBuffer
        {
            public NV_MOSAIC_GPU_LAYOUT_CELL e0_0;
        }
    }
}
