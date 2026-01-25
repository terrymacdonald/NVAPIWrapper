namespace NVAPIWrapper
{
    /// <include file='NV_GPU_GET_HDCP_SUPPORT_STATUS.xml' path='doc/member[@name="NV_GPU_GET_HDCP_SUPPORT_STATUS"]/*' />
    public partial struct NV_GPU_GET_HDCP_SUPPORT_STATUS
    {
        /// <include file='NV_GPU_GET_HDCP_SUPPORT_STATUS.xml' path='doc/member[@name="NV_GPU_GET_HDCP_SUPPORT_STATUS.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_GPU_GET_HDCP_SUPPORT_STATUS.xml' path='doc/member[@name="NV_GPU_GET_HDCP_SUPPORT_STATUS.hdcpFuseState"]/*' />
        [NativeTypeName("NV_GPU_HDCP_FUSE_STATE")]
        public _NV_GPU_HDCP_FUSE_STATE hdcpFuseState;

        /// <include file='NV_GPU_GET_HDCP_SUPPORT_STATUS.xml' path='doc/member[@name="NV_GPU_GET_HDCP_SUPPORT_STATUS.hdcpKeySource"]/*' />
        [NativeTypeName("NV_GPU_HDCP_KEY_SOURCE")]
        public _NV_GPU_HDCP_KEY_SOURCE hdcpKeySource;

        /// <include file='NV_GPU_GET_HDCP_SUPPORT_STATUS.xml' path='doc/member[@name="NV_GPU_GET_HDCP_SUPPORT_STATUS.hdcpKeySourceState"]/*' />
        [NativeTypeName("NV_GPU_HDCP_KEY_SOURCE_STATE")]
        public _NV_GPU_HDCP_KEY_SOURCE_STATE hdcpKeySourceState;
    }
}
