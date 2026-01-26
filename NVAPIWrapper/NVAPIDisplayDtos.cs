using System;
using System.Collections.Generic;

namespace NVAPIWrapper
{
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
