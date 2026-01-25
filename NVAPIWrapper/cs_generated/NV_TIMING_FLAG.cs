using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <include file='NV_TIMING_FLAG.xml' path='doc/member[@name="NV_TIMING_FLAG"]/*' />
    public partial struct NV_TIMING_FLAG
    {
        public uint _bitfield1;

        /// <include file='NV_TIMING_FLAG.xml' path='doc/member[@name="NV_TIMING_FLAG.isInterlaced"]/*' />
        [NativeTypeName("NvU32 : 4")]
        public uint isInterlaced
        {
            readonly get
            {
                return _bitfield1 & 0xFu;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~0xFu) | (value & 0xFu);
            }
        }

        /// <include file='NV_TIMING_FLAG.xml' path='doc/member[@name="NV_TIMING_FLAG.reserved0"]/*' />
        [NativeTypeName("NvU32 : 12")]
        public uint reserved0
        {
            readonly get
            {
                return (_bitfield1 >> 4) & 0xFFFu;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~(0xFFFu << 4)) | ((value & 0xFFFu) << 4);
            }
        }

        /// <include file='NV_TIMING_FLAG.xml' path='doc/member[@name="NV_TIMING_FLAG.Anonymous"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L8328_C5")]
        public _Anonymous_e__Union Anonymous;

        public uint _bitfield2;

        /// <include file='NV_TIMING_FLAG.xml' path='doc/member[@name="NV_TIMING_FLAG.scaling"]/*' />
        [NativeTypeName("NvU32 : 8")]
        public uint scaling
        {
            readonly get
            {
                return _bitfield2 & 0xFFu;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~0xFFu) | (value & 0xFFu);
            }
        }

        /// <include file='_Anonymous_e__Union.xml' path='doc/member[@name="_Anonymous_e__Union.tvFormat"]/*' />
        public uint tvFormat
        {
            readonly get
            {
                return Anonymous.tvFormat;
            }

            set
            {
                Anonymous.tvFormat = value;
            }
        }

        /// <include file='_Anonymous_e__Union.xml' path='doc/member[@name="_Anonymous_e__Union.ceaId"]/*' />
        public uint ceaId
        {
            readonly get
            {
                return Anonymous.ceaId;
            }

            set
            {
                Anonymous.ceaId = value;
            }
        }

        /// <include file='_Anonymous_e__Union.xml' path='doc/member[@name="_Anonymous_e__Union.nvPsfId"]/*' />
        public uint nvPsfId
        {
            readonly get
            {
                return Anonymous.nvPsfId;
            }

            set
            {
                Anonymous.nvPsfId = value;
            }
        }

        /// <include file='_Anonymous_e__Union.xml' path='doc/member[@name="_Anonymous_e__Union"]/*' />
        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        public partial struct _Anonymous_e__Union
        {
            [FieldOffset(0)]
            public uint _bitfield;

            /// <include file='_Anonymous_e__Union.xml' path='doc/member[@name="_Anonymous_e__Union.tvFormat"]/*' />
            [NativeTypeName("NvU32 : 8")]
            public uint tvFormat
            {
                readonly get
                {
                    return _bitfield & 0xFFu;
                }

                set
                {
                    _bitfield = (_bitfield & ~0xFFu) | (value & 0xFFu);
                }
            }

            /// <include file='_Anonymous_e__Union.xml' path='doc/member[@name="_Anonymous_e__Union.ceaId"]/*' />
            [NativeTypeName("NvU32 : 8")]
            public uint ceaId
            {
                readonly get
                {
                    return (_bitfield >> 8) & 0xFFu;
                }

                set
                {
                    _bitfield = (_bitfield & ~(0xFFu << 8)) | ((value & 0xFFu) << 8);
                }
            }

            /// <include file='_Anonymous_e__Union.xml' path='doc/member[@name="_Anonymous_e__Union.nvPsfId"]/*' />
            [NativeTypeName("NvU32 : 8")]
            public uint nvPsfId
            {
                readonly get
                {
                    return (_bitfield >> 16) & 0xFFu;
                }

                set
                {
                    _bitfield = (_bitfield & ~(0xFFu << 16)) | ((value & 0xFFu) << 16);
                }
            }
        }
    }
}
