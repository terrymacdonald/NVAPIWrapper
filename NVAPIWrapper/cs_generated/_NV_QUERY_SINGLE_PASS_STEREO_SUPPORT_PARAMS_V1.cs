namespace NVAPIWrapper
{
    /// <include file='_NV_QUERY_SINGLE_PASS_STEREO_SUPPORT_PARAMS_V1.xml' path='doc/member[@name="_NV_QUERY_SINGLE_PASS_STEREO_SUPPORT_PARAMS_V1"]/*' />
    public partial struct _NV_QUERY_SINGLE_PASS_STEREO_SUPPORT_PARAMS_V1
    {
        /// <include file='_NV_QUERY_SINGLE_PASS_STEREO_SUPPORT_PARAMS_V1.xml' path='doc/member[@name="_NV_QUERY_SINGLE_PASS_STEREO_SUPPORT_PARAMS_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_QUERY_SINGLE_PASS_STEREO_SUPPORT_PARAMS_V1.xml' path='doc/member[@name="_NV_QUERY_SINGLE_PASS_STEREO_SUPPORT_PARAMS_V1.bSinglePassStereoSupported"]/*' />
        [NativeTypeName("NvU32")]
        public uint bSinglePassStereoSupported;
    }
}
