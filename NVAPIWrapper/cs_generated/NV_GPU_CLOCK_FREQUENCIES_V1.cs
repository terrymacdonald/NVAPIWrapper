using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NV_GPU_CLOCK_FREQUENCIES_V1.xml' path='doc/member[@name="NV_GPU_CLOCK_FREQUENCIES_V1"]/*' />
    public partial struct NV_GPU_CLOCK_FREQUENCIES_V1
    {
        /// <include file='NV_GPU_CLOCK_FREQUENCIES_V1.xml' path='doc/member[@name="NV_GPU_CLOCK_FREQUENCIES_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_GPU_CLOCK_FREQUENCIES_V1.xml' path='doc/member[@name="NV_GPU_CLOCK_FREQUENCIES_V1.reserved"]/*' />
        [NativeTypeName("NvU32")]
        public uint reserved;

        /// <include file='NV_GPU_CLOCK_FREQUENCIES_V1.xml' path='doc/member[@name="NV_GPU_CLOCK_FREQUENCIES_V1.domain"]/*' />
        [NativeTypeName("struct (anonymous struct at ./../nvapi/nvapi.h:5335:5)[32]")]
        public _domain_e__FixedBuffer domain;

        /// <include file='_domain_e__Struct.xml' path='doc/member[@name="_domain_e__Struct"]/*' />
        public partial struct _domain_e__Struct
        {
            public uint _bitfield;

            /// <include file='_domain_e__Struct.xml' path='doc/member[@name="_domain_e__Struct.bIsPresent"]/*' />
            [NativeTypeName("NvU32 : 1")]
            public uint bIsPresent
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

            /// <include file='_domain_e__Struct.xml' path='doc/member[@name="_domain_e__Struct.reserved"]/*' />
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

            /// <include file='_domain_e__Struct.xml' path='doc/member[@name="_domain_e__Struct.frequency"]/*' />
            [NativeTypeName("NvU32")]
            public uint frequency;
        }

        /// <include file='_domain_e__FixedBuffer.xml' path='doc/member[@name="_domain_e__FixedBuffer"]/*' />
        [InlineArray(32)]
        public partial struct _domain_e__FixedBuffer
        {
            public _domain_e__Struct e0;
        }
    }
}
