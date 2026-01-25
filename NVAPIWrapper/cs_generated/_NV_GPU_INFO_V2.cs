using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_GPU_INFO_V2.xml' path='doc/member[@name="_NV_GPU_INFO_V2"]/*' />
    public partial struct _NV_GPU_INFO_V2
    {
        /// <include file='_NV_GPU_INFO_V2.xml' path='doc/member[@name="_NV_GPU_INFO_V2.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        public uint _bitfield;

        /// <include file='_NV_GPU_INFO_V2.xml' path='doc/member[@name="_NV_GPU_INFO_V2.bIsExternalGpu"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bIsExternalGpu
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

        /// <include file='_NV_GPU_INFO_V2.xml' path='doc/member[@name="_NV_GPU_INFO_V2.reserved0"]/*' />
        [NativeTypeName("NvU32 : 31")]
        public uint reserved0
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

        /// <include file='_NV_GPU_INFO_V2.xml' path='doc/member[@name="_NV_GPU_INFO_V2.reserved1"]/*' />
        [NativeTypeName("NvU64")]
        public ulong reserved1;

        /// <include file='_NV_GPU_INFO_V2.xml' path='doc/member[@name="_NV_GPU_INFO_V2.rayTracingCores"]/*' />
        [NativeTypeName("NvU32")]
        public uint rayTracingCores;

        /// <include file='_NV_GPU_INFO_V2.xml' path='doc/member[@name="_NV_GPU_INFO_V2.tensorCores"]/*' />
        [NativeTypeName("NvU32")]
        public uint tensorCores;

        /// <include file='_NV_GPU_INFO_V2.xml' path='doc/member[@name="_NV_GPU_INFO_V2.reserved2"]/*' />
        [NativeTypeName("NvU32[14]")]
        public _reserved2_e__FixedBuffer reserved2;

        /// <include file='_reserved2_e__FixedBuffer.xml' path='doc/member[@name="_reserved2_e__FixedBuffer"]/*' />
        [InlineArray(14)]
        public partial struct _reserved2_e__FixedBuffer
        {
            public uint e0;
        }
    }
}
