using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NV_GPU_CLOCK_FREQUENCIES_V2.xml' path='doc/member[@name="NV_GPU_CLOCK_FREQUENCIES_V2"]/*' />
    public partial struct NV_GPU_CLOCK_FREQUENCIES_V2
    {
        /// <include file='NV_GPU_CLOCK_FREQUENCIES_V2.xml' path='doc/member[@name="NV_GPU_CLOCK_FREQUENCIES_V2.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        public uint _bitfield;

        /// <include file='NV_GPU_CLOCK_FREQUENCIES_V2.xml' path='doc/member[@name="NV_GPU_CLOCK_FREQUENCIES_V2.ClockType"]/*' />
        [NativeTypeName("NvU32 : 4")]
        public uint ClockType
        {
            readonly get
            {
                return _bitfield & 0xFu;
            }

            set
            {
                _bitfield = (_bitfield & ~0xFu) | (value & 0xFu);
            }
        }

        /// <include file='NV_GPU_CLOCK_FREQUENCIES_V2.xml' path='doc/member[@name="NV_GPU_CLOCK_FREQUENCIES_V2.reserved"]/*' />
        [NativeTypeName("NvU32 : 20")]
        public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 4) & 0xFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0xFFFFFu << 4)) | ((value & 0xFFFFFu) << 4);
            }
        }

        /// <include file='NV_GPU_CLOCK_FREQUENCIES_V2.xml' path='doc/member[@name="NV_GPU_CLOCK_FREQUENCIES_V2.reserved1"]/*' />
        [NativeTypeName("NvU32 : 8")]
        public uint reserved1
        {
            readonly get
            {
                return (_bitfield >> 24) & 0xFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0xFFu << 24)) | ((value & 0xFFu) << 24);
            }
        }

        /// <include file='NV_GPU_CLOCK_FREQUENCIES_V2.xml' path='doc/member[@name="NV_GPU_CLOCK_FREQUENCIES_V2.domain"]/*' />
        [NativeTypeName("struct (anonymous struct at ./../nvapi/nvapi.h:5365:5)[32]")]
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
