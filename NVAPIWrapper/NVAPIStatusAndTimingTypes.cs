using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <summary>Used in NvAPI_DISP_GetTiming.</summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NV_TIMING_FLAG
    {
        /// <summary>Interlaced flag and related packed fields.</summary>
        [NativeTypeName("NvU32")]
        public uint flags;

        /// <summary>TV format or related packed fields.</summary>
        [NativeTypeName("NvU32")]
        public uint tvFormat;
    }

    /// <summary>Used in NvAPI_GPU_GetECCStatusInfo.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NV_GPU_ECC_STATUS_INFO
    {
        /// <summary>Structure version.</summary>
        [NativeTypeName("NvU32")]
        public uint version;

        // Packed bitfields for isSupported/isEnabled to match the native layout size.
        [NativeTypeName("NvU32")]
        private uint _flags;

        /// <summary>Supported ECC configuration options.</summary>
        [NativeTypeName("NV_ECC_CONFIGURATION")]
        public _NV_ECC_CONFIGURATION configurationOptions;

        /// <summary>ECC memory feature support.</summary>
        [NativeTypeName("NvU32")]
        public uint isSupported
        {
            get => _flags & 0x1u;
            set => _flags = (_flags & ~0x1u) | (value & 0x1u);
        }

        /// <summary>Active ECC memory setting.</summary>
        [NativeTypeName("NvU32")]
        public uint isEnabled
        {
            get => (_flags >> 1) & 0x1u;
            set => _flags = (_flags & ~(1u << 1)) | ((value & 0x1u) << 1);
        }
    }
}
