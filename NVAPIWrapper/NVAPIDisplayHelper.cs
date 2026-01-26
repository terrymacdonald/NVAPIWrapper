using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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
