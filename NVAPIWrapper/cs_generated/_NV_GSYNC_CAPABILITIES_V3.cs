namespace NVAPIWrapper
{
    /// <include file='_NV_GSYNC_CAPABILITIES_V3.xml' path='doc/member[@name="_NV_GSYNC_CAPABILITIES_V3"]/*' />
    public partial struct _NV_GSYNC_CAPABILITIES_V3
    {
        /// <include file='_NV_GSYNC_CAPABILITIES_V3.xml' path='doc/member[@name="_NV_GSYNC_CAPABILITIES_V3.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_GSYNC_CAPABILITIES_V3.xml' path='doc/member[@name="_NV_GSYNC_CAPABILITIES_V3.boardId"]/*' />
        [NativeTypeName("NvU32")]
        public uint boardId;

        /// <include file='_NV_GSYNC_CAPABILITIES_V3.xml' path='doc/member[@name="_NV_GSYNC_CAPABILITIES_V3.revision"]/*' />
        [NativeTypeName("NvU32")]
        public uint revision;

        /// <include file='_NV_GSYNC_CAPABILITIES_V3.xml' path='doc/member[@name="_NV_GSYNC_CAPABILITIES_V3.capFlags"]/*' />
        [NativeTypeName("NvU32")]
        public uint capFlags;

        /// <include file='_NV_GSYNC_CAPABILITIES_V3.xml' path='doc/member[@name="_NV_GSYNC_CAPABILITIES_V3.extendedRevision"]/*' />
        [NativeTypeName("NvU32")]
        public uint extendedRevision;

        public uint _bitfield;

        /// <include file='_NV_GSYNC_CAPABILITIES_V3.xml' path='doc/member[@name="_NV_GSYNC_CAPABILITIES_V3.bIsMulDivSupported"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bIsMulDivSupported
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

        /// <include file='_NV_GSYNC_CAPABILITIES_V3.xml' path='doc/member[@name="_NV_GSYNC_CAPABILITIES_V3.reserved"]/*' />
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

        /// <include file='_NV_GSYNC_CAPABILITIES_V3.xml' path='doc/member[@name="_NV_GSYNC_CAPABILITIES_V3.maxMulDivValue"]/*' />
        [NativeTypeName("NvU32")]
        public uint maxMulDivValue;
    }
}
