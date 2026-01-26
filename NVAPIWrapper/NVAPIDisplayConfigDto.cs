using System;

namespace NVAPIWrapper
{
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
}
