namespace NVAPIWrapper
{
    /// <include file='_NV_GSYNC_STATUS.xml' path='doc/member[@name="_NV_GSYNC_STATUS"]/*' />
    public partial struct _NV_GSYNC_STATUS
    {
        /// <include file='_NV_GSYNC_STATUS.xml' path='doc/member[@name="_NV_GSYNC_STATUS.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_GSYNC_STATUS.xml' path='doc/member[@name="_NV_GSYNC_STATUS.bIsSynced"]/*' />
        [NativeTypeName("NvU32")]
        public uint bIsSynced;

        /// <include file='_NV_GSYNC_STATUS.xml' path='doc/member[@name="_NV_GSYNC_STATUS.bIsStereoSynced"]/*' />
        [NativeTypeName("NvU32")]
        public uint bIsStereoSynced;

        /// <include file='_NV_GSYNC_STATUS.xml' path='doc/member[@name="_NV_GSYNC_STATUS.bIsSyncSignalAvailable"]/*' />
        [NativeTypeName("NvU32")]
        public uint bIsSyncSignalAvailable;
    }
}
