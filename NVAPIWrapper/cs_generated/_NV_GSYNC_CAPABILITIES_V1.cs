namespace NVAPIWrapper
{
    /// <include file='_NV_GSYNC_CAPABILITIES_V1.xml' path='doc/member[@name="_NV_GSYNC_CAPABILITIES_V1"]/*' />
    public partial struct _NV_GSYNC_CAPABILITIES_V1
    {
        /// <include file='_NV_GSYNC_CAPABILITIES_V1.xml' path='doc/member[@name="_NV_GSYNC_CAPABILITIES_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_GSYNC_CAPABILITIES_V1.xml' path='doc/member[@name="_NV_GSYNC_CAPABILITIES_V1.boardId"]/*' />
        [NativeTypeName("NvU32")]
        public uint boardId;

        /// <include file='_NV_GSYNC_CAPABILITIES_V1.xml' path='doc/member[@name="_NV_GSYNC_CAPABILITIES_V1.revision"]/*' />
        [NativeTypeName("NvU32")]
        public uint revision;

        /// <include file='_NV_GSYNC_CAPABILITIES_V1.xml' path='doc/member[@name="_NV_GSYNC_CAPABILITIES_V1.capFlags"]/*' />
        [NativeTypeName("NvU32")]
        public uint capFlags;
    }
}
