namespace NVAPIWrapper
{
    /// <include file='_NV_NGX_RUNTIME_KEY_VALUE.xml' path='doc/member[@name="_NV_NGX_RUNTIME_KEY_VALUE"]/*' />
    public partial struct _NV_NGX_RUNTIME_KEY_VALUE
    {
        /// <include file='_NV_NGX_RUNTIME_KEY_VALUE.xml' path='doc/member[@name="_NV_NGX_RUNTIME_KEY_VALUE.key"]/*' />
        [NativeTypeName("NV_NGX_RUNTIME_KEY")]
        public _NV_NGX_RUNTIME_KEY key;

        public uint _bitfield;

        /// <include file='_NV_NGX_RUNTIME_KEY_VALUE.xml' path='doc/member[@name="_NV_NGX_RUNTIME_KEY_VALUE.bIsSet"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bIsSet
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

        /// <include file='_NV_NGX_RUNTIME_KEY_VALUE.xml' path='doc/member[@name="_NV_NGX_RUNTIME_KEY_VALUE.bClear"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bClear
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

        /// <include file='_NV_NGX_RUNTIME_KEY_VALUE.xml' path='doc/member[@name="_NV_NGX_RUNTIME_KEY_VALUE.reserved"]/*' />
        [NativeTypeName("NvU32 : 30")]
        public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x3FFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x3FFFFFFFu << 2)) | ((value & 0x3FFFFFFFu) << 2);
            }
        }

        /// <include file='_NV_NGX_RUNTIME_KEY_VALUE.xml' path='doc/member[@name="_NV_NGX_RUNTIME_KEY_VALUE.value"]/*' />
        [NativeTypeName("NvU64")]
        public ulong value;
    }
}
