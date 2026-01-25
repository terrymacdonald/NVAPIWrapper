namespace NVAPIWrapper
{
    /// <include file='_NV_QUERY_MODIFIED_W_SUPPORT_PARAMS.xml' path='doc/member[@name="_NV_QUERY_MODIFIED_W_SUPPORT_PARAMS"]/*' />
    public partial struct _NV_QUERY_MODIFIED_W_SUPPORT_PARAMS
    {
        /// <include file='_NV_QUERY_MODIFIED_W_SUPPORT_PARAMS.xml' path='doc/member[@name="_NV_QUERY_MODIFIED_W_SUPPORT_PARAMS.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_QUERY_MODIFIED_W_SUPPORT_PARAMS.xml' path='doc/member[@name="_NV_QUERY_MODIFIED_W_SUPPORT_PARAMS.bModifiedWSupported"]/*' />
        [NativeTypeName("NvU32")]
        public uint bModifiedWSupported;
    }
}
