using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <summary>Advanced target settings for display configuration paths.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct _NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1
    {
        /// <summary>Structure version.</summary>
        [NativeTypeName("NvU32")]
        public uint version;

        /// <summary>Rotation setting.</summary>
        [NativeTypeName("NV_ROTATE")]
        public _NV_ROTATE rotation;

        /// <summary>Scaling setting.</summary>
        [NativeTypeName("NV_SCALING")]
        public _NV_SCALING scaling;

        // Padding to match native enum width for layout size.
        [NativeTypeName("NvU32")]
        private uint _padding;

        /// <summary>Non-interlaced refresh rate multiplied by 1000; 0 means ignored.</summary>
        [NativeTypeName("NvU32")]
        public uint refreshRate1K;

        /// <summary>Bitfield storage for flags.</summary>
        public uint _bitfield;

        /// <summary>Interlaced mode flag.</summary>
        [NativeTypeName("NvU32 : 1")]
        public uint interlaced
        {
            readonly get => _bitfield & 0x1u;
            set => _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
        }

        /// <summary>Primary display flag.</summary>
        [NativeTypeName("NvU32 : 1")]
        public uint primary
        {
            readonly get => (_bitfield >> 1) & 0x1u;
            set => _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
        }

        /// <summary>Reserved bit.</summary>
        [NativeTypeName("NvU32 : 1")]
        public uint reservedBit1
        {
            readonly get => (_bitfield >> 2) & 0x1u;
            set => _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
        }

        /// <summary>Disable virtual mode support flag.</summary>
        [NativeTypeName("NvU32 : 1")]
        public uint disableVirtualModeSupport
        {
            readonly get => (_bitfield >> 3) & 0x1u;
            set => _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
        }

        /// <summary>Preferred unscaled target flag.</summary>
        [NativeTypeName("NvU32 : 1")]
        public uint isPreferredUnscaledTarget
        {
            readonly get => (_bitfield >> 4) & 0x1u;
            set => _bitfield = (_bitfield & ~(0x1u << 4)) | ((value & 0x1u) << 4);
        }

        /// <summary>Reserved flags.</summary>
        [NativeTypeName("NvU32 : 27")]
        public uint reserved
        {
            readonly get => (_bitfield >> 5) & 0x7FFFFFFu;
            set => _bitfield = (_bitfield & ~(0x7FFFFFFu << 5)) | ((value & 0x7FFFFFFu) << 5);
        }

        /// <summary>Connector type for TV outputs.</summary>
        [NativeTypeName("NV_GPU_CONNECTOR_TYPE")]
        public _NV_GPU_CONNECTOR_TYPE connector;

        /// <summary>TV format.</summary>
        [NativeTypeName("NV_DISPLAY_TV_FORMAT")]
        public _NV_DISPLAY_TV_FORMAT tvFormat;

        /// <summary>Timing override mode.</summary>
        [NativeTypeName("NV_TIMING_OVERRIDE")]
        public _NV_TIMING_OVERRIDE timingOverride;

        /// <summary>Scan out timing for custom timing overrides.</summary>
        [NativeTypeName("NV_TIMING")]
        public _NV_TIMING timing;
    }
}
