namespace NVAPIWrapper
{
    /// <include file='_NV_MANAGED_DEDICATED_DISPLAY_INFO.xml' path='doc/member[@name="_NV_MANAGED_DEDICATED_DISPLAY_INFO"]/*' />
    public partial struct _NV_MANAGED_DEDICATED_DISPLAY_INFO
    {
        /// <include file='_NV_MANAGED_DEDICATED_DISPLAY_INFO.xml' path='doc/member[@name="_NV_MANAGED_DEDICATED_DISPLAY_INFO.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_MANAGED_DEDICATED_DISPLAY_INFO.xml' path='doc/member[@name="_NV_MANAGED_DEDICATED_DISPLAY_INFO.displayId"]/*' />
        [NativeTypeName("NvU32")]
        public uint displayId;

        public uint _bitfield;

        /// <include file='_NV_MANAGED_DEDICATED_DISPLAY_INFO.xml' path='doc/member[@name="_NV_MANAGED_DEDICATED_DISPLAY_INFO.isAcquired"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isAcquired
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

        /// <include file='_NV_MANAGED_DEDICATED_DISPLAY_INFO.xml' path='doc/member[@name="_NV_MANAGED_DEDICATED_DISPLAY_INFO.isMosaic"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isMosaic
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

        /// <include file='_NV_MANAGED_DEDICATED_DISPLAY_INFO.xml' path='doc/member[@name="_NV_MANAGED_DEDICATED_DISPLAY_INFO.reserved"]/*' />
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
    }
}
