namespace NVAPIWrapper
{
    /// <include file='NV_INFOFRAME_PROPERTY.xml' path='doc/member[@name="NV_INFOFRAME_PROPERTY"]/*' />
    public partial struct NV_INFOFRAME_PROPERTY
    {
        public uint _bitfield;

        /// <include file='NV_INFOFRAME_PROPERTY.xml' path='doc/member[@name="NV_INFOFRAME_PROPERTY.mode"]/*' />
        [NativeTypeName("NvU32 : 4")]
        public uint mode
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

        /// <include file='NV_INFOFRAME_PROPERTY.xml' path='doc/member[@name="NV_INFOFRAME_PROPERTY.blackList"]/*' />
        [NativeTypeName("NvU32 : 2")]
        public uint blackList
        {
            readonly get
            {
                return (_bitfield >> 4) & 0x3u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x3u << 4)) | ((value & 0x3u) << 4);
            }
        }

        /// <include file='NV_INFOFRAME_PROPERTY.xml' path='doc/member[@name="NV_INFOFRAME_PROPERTY.reserved"]/*' />
        [NativeTypeName("NvU32 : 10")]
        public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 6) & 0x3FFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x3FFu << 6)) | ((value & 0x3FFu) << 6);
            }
        }

        /// <include file='NV_INFOFRAME_PROPERTY.xml' path='doc/member[@name="NV_INFOFRAME_PROPERTY.version"]/*' />
        [NativeTypeName("NvU32 : 8")]
        public uint version
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

        /// <include file='NV_INFOFRAME_PROPERTY.xml' path='doc/member[@name="NV_INFOFRAME_PROPERTY.length"]/*' />
        [NativeTypeName("NvU32 : 8")]
        public uint length
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
    }
}
