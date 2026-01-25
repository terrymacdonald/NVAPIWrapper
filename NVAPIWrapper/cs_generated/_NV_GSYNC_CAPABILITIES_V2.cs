namespace NVAPIWrapper
{
    /// <include file='_NV_GSYNC_CAPABILITIES_V2.xml' path='doc/member[@name="_NV_GSYNC_CAPABILITIES_V2"]/*' />
    public partial struct _NV_GSYNC_CAPABILITIES_V2
    {
        /// <include file='_NV_GSYNC_CAPABILITIES_V2.xml' path='doc/member[@name="_NV_GSYNC_CAPABILITIES_V2.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_GSYNC_CAPABILITIES_V2.xml' path='doc/member[@name="_NV_GSYNC_CAPABILITIES_V2.boardId"]/*' />
        [NativeTypeName("NvU32")]
        public uint boardId;

        /// <include file='_NV_GSYNC_CAPABILITIES_V2.xml' path='doc/member[@name="_NV_GSYNC_CAPABILITIES_V2.revision"]/*' />
        [NativeTypeName("NvU32")]
        public uint revision;

        /// <include file='_NV_GSYNC_CAPABILITIES_V2.xml' path='doc/member[@name="_NV_GSYNC_CAPABILITIES_V2.capFlags"]/*' />
        [NativeTypeName("NvU32")]
        public uint capFlags;

        /// <include file='_NV_GSYNC_CAPABILITIES_V2.xml' path='doc/member[@name="_NV_GSYNC_CAPABILITIES_V2.extendedRevision"]/*' />
        [NativeTypeName("NvU32")]
        public uint extendedRevision;
    }
}
