using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NV_VIEW_TARGET_INFO.xml' path='doc/member[@name="NV_VIEW_TARGET_INFO"]/*' />
    public partial struct NV_VIEW_TARGET_INFO
    {
        /// <include file='NV_VIEW_TARGET_INFO.xml' path='doc/member[@name="NV_VIEW_TARGET_INFO.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_VIEW_TARGET_INFO.xml' path='doc/member[@name="NV_VIEW_TARGET_INFO.count"]/*' />
        [NativeTypeName("NvU32")]
        public uint count;

        /// <include file='NV_VIEW_TARGET_INFO.xml' path='doc/member[@name="NV_VIEW_TARGET_INFO.target"]/*' />
        [NativeTypeName("struct (anonymous struct at ./../nvapi/nvapi.h:728:5)[2]")]
        public _target_e__FixedBuffer target;

        /// <include file='_target_e__Struct.xml' path='doc/member[@name="_target_e__Struct"]/*' />
        public partial struct _target_e__Struct
        {
            /// <include file='_target_e__Struct.xml' path='doc/member[@name="_target_e__Struct.deviceMask"]/*' />
            [NativeTypeName("NvU32")]
            public uint deviceMask;

            /// <include file='_target_e__Struct.xml' path='doc/member[@name="_target_e__Struct.sourceId"]/*' />
            [NativeTypeName("NvU32")]
            public uint sourceId;

            public uint _bitfield;

            /// <include file='_target_e__Struct.xml' path='doc/member[@name="_target_e__Struct.bPrimary"]/*' />
            [NativeTypeName("NvU32 : 1")]
            public uint bPrimary
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

            /// <include file='_target_e__Struct.xml' path='doc/member[@name="_target_e__Struct.bInterlaced"]/*' />
            [NativeTypeName("NvU32 : 1")]
            public uint bInterlaced
            {
                readonly get
                {
                    return (_bitfield >> 1) & 0x1u;
                }

                set
                {
                    _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
                }
            }

            /// <include file='_target_e__Struct.xml' path='doc/member[@name="_target_e__Struct.bGDIPrimary"]/*' />
            [NativeTypeName("NvU32 : 1")]
            public uint bGDIPrimary
            {
                readonly get
                {
                    return (_bitfield >> 2) & 0x1u;
                }

                set
                {
                    _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
                }
            }

            /// <include file='_target_e__Struct.xml' path='doc/member[@name="_target_e__Struct.bForceModeSet"]/*' />
            [NativeTypeName("NvU32 : 1")]
            public uint bForceModeSet
            {
                readonly get
                {
                    return (_bitfield >> 3) & 0x1u;
                }

                set
                {
                    _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
                }
            }
        }

        /// <include file='_target_e__FixedBuffer.xml' path='doc/member[@name="_target_e__FixedBuffer"]/*' />
        [InlineArray(2)]
        public partial struct _target_e__FixedBuffer
        {
            public _target_e__Struct e0;
        }
    }
}
