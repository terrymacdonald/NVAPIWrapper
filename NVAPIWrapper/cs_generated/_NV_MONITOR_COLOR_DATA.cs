namespace NVAPIWrapper
{
    /// <include file='_NV_MONITOR_COLOR_DATA.xml' path='doc/member[@name="_NV_MONITOR_COLOR_DATA"]/*' />
    public partial struct _NV_MONITOR_COLOR_DATA
    {
        /// <include file='_NV_MONITOR_COLOR_DATA.xml' path='doc/member[@name="_NV_MONITOR_COLOR_DATA.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_MONITOR_COLOR_DATA.xml' path='doc/member[@name="_NV_MONITOR_COLOR_DATA.colorFormat"]/*' />
        [NativeTypeName("NV_DP_COLOR_FORMAT")]
        public _NV_DP_COLOR_FORMAT colorFormat;

        /// <include file='_NV_MONITOR_COLOR_DATA.xml' path='doc/member[@name="_NV_MONITOR_COLOR_DATA.backendBitDepths"]/*' />
        [NativeTypeName("NV_DP_BPC")]
        public _NV_DP_BPC backendBitDepths;
    }
}
