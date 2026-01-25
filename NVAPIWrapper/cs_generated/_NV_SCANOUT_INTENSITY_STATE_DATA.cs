namespace NVAPIWrapper
{
    /// <include file='_NV_SCANOUT_INTENSITY_STATE_DATA.xml' path='doc/member[@name="_NV_SCANOUT_INTENSITY_STATE_DATA"]/*' />
    public partial struct _NV_SCANOUT_INTENSITY_STATE_DATA
    {
        /// <include file='_NV_SCANOUT_INTENSITY_STATE_DATA.xml' path='doc/member[@name="_NV_SCANOUT_INTENSITY_STATE_DATA.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_SCANOUT_INTENSITY_STATE_DATA.xml' path='doc/member[@name="_NV_SCANOUT_INTENSITY_STATE_DATA.bEnabled"]/*' />
        [NativeTypeName("NvU32")]
        public uint bEnabled;
    }
}
