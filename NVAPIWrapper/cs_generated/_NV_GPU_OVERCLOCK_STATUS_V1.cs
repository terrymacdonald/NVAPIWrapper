using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_GPU_OVERCLOCK_STATUS_V1.xml' path='doc/member[@name="_NV_GPU_OVERCLOCK_STATUS_V1"]/*' />
    public partial struct _NV_GPU_OVERCLOCK_STATUS_V1
    {
        /// <include file='_NV_GPU_OVERCLOCK_STATUS_V1.xml' path='doc/member[@name="_NV_GPU_OVERCLOCK_STATUS_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        public uint _bitfield;

        /// <include file='_NV_GPU_OVERCLOCK_STATUS_V1.xml' path='doc/member[@name="_NV_GPU_OVERCLOCK_STATUS_V1.bOverclockingDetected"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bOverclockingDetected
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

        /// <include file='_NV_GPU_OVERCLOCK_STATUS_V1.xml' path='doc/member[@name="_NV_GPU_OVERCLOCK_STATUS_V1.reserved"]/*' />
        [NativeTypeName("NvU32 : 31")]
        public uint reserved
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

        /// <include file='_NV_GPU_OVERCLOCK_STATUS_V1.xml' path='doc/member[@name="_NV_GPU_OVERCLOCK_STATUS_V1.rsvd"]/*' />
        [NativeTypeName("NvU32[16]")]
        public _rsvd_e__FixedBuffer rsvd;

        /// <include file='_rsvd_e__FixedBuffer.xml' path='doc/member[@name="_rsvd_e__FixedBuffer"]/*' />
        [InlineArray(16)]
        public partial struct _rsvd_e__FixedBuffer
        {
            public uint e0;
        }
    }
}
