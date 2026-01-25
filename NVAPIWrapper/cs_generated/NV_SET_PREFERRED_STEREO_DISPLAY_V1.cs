namespace NVAPIWrapper
{
    /// <include file='NV_SET_PREFERRED_STEREO_DISPLAY_V1.xml' path='doc/member[@name="NV_SET_PREFERRED_STEREO_DISPLAY_V1"]/*' />
    public partial struct NV_SET_PREFERRED_STEREO_DISPLAY_V1
    {
        /// <include file='NV_SET_PREFERRED_STEREO_DISPLAY_V1.xml' path='doc/member[@name="NV_SET_PREFERRED_STEREO_DISPLAY_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_SET_PREFERRED_STEREO_DISPLAY_V1.xml' path='doc/member[@name="NV_SET_PREFERRED_STEREO_DISPLAY_V1.displayId"]/*' />
        [NativeTypeName("NvU32")]
        public uint displayId;

        /// <include file='NV_SET_PREFERRED_STEREO_DISPLAY_V1.xml' path='doc/member[@name="NV_SET_PREFERRED_STEREO_DISPLAY_V1.reserved"]/*' />
        [NativeTypeName("NvU32")]
        public uint reserved;
    }
}
