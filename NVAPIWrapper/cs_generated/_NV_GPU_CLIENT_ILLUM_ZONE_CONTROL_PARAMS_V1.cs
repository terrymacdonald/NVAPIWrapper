using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1"]/*' />
    public partial struct _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1
    {
        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        public uint _bitfield;

        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1.bDefault"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bDefault
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1.rsvdField"]/*' />
        [NativeTypeName("NvU32 : 31")]
        public uint rsvdField
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x7FFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x7FFFFFFFu << 1)) | ((value & 0x7FFFFFFFu) << 1);
            }
        }

        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1.numIllumZonesControl"]/*' />
        [NativeTypeName("NvU32")]
        public uint numIllumZonesControl;

        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1.rsvd"]/*' />
        [NativeTypeName("NvU8[64]")]
        public _rsvd_e__FixedBuffer rsvd;

        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1.zones"]/*' />
        [NativeTypeName("NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_V1[32]")]
        public _zones_e__FixedBuffer zones;

        /// <include file='_rsvd_e__FixedBuffer.xml' path='doc/member[@name="_rsvd_e__FixedBuffer"]/*' />
        [InlineArray(64)]
        public partial struct _rsvd_e__FixedBuffer
        {
            public byte e0;
        }

        /// <include file='_zones_e__FixedBuffer.xml' path='doc/member[@name="_zones_e__FixedBuffer"]/*' />
        [InlineArray(32)]
        public partial struct _zones_e__FixedBuffer
        {
            public _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_V1 e0;
        }
    }
}
