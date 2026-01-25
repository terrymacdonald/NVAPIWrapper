namespace NVAPIWrapper
{
    /// <include file='_NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1"]/*' />
    public partial struct _NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1
    {
        /// <include file='_NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1.resolution"]/*' />
        [NativeTypeName("NV_RESOLUTION")]
        public _NV_RESOLUTION resolution;

        /// <include file='_NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1.colorFormat"]/*' />
        [NativeTypeName("NV_FORMAT")]
        public _NV_FORMAT colorFormat;

        /// <include file='_NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1.position"]/*' />
        [NativeTypeName("NV_POSITION")]
        public _NV_POSITION position;

        /// <include file='_NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1.spanningOrientation"]/*' />
        [NativeTypeName("NV_DISPLAYCONFIG_SPANNING_ORIENTATION")]
        public _NV_DISPLAYCONFIG_SPANNING_ORIENTATION spanningOrientation;

        public uint _bitfield;

        /// <include file='_NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1.bGDIPrimary"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bGDIPrimary
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

        /// <include file='_NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1.bSLIFocus"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bSLIFocus
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

        /// <include file='_NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1.reserved"]/*' />
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
