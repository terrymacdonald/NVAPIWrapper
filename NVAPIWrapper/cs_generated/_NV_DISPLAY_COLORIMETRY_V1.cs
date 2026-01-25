namespace NVAPIWrapper
{
    /// <include file='_NV_DISPLAY_COLORIMETRY_V1.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_V1"]/*' />
    public partial struct _NV_DISPLAY_COLORIMETRY_V1
    {
        /// <include file='_NV_DISPLAY_COLORIMETRY_V1.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_DISPLAY_COLORIMETRY_V1.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_V1.min_luminance"]/*' />
        public float min_luminance;

        /// <include file='_NV_DISPLAY_COLORIMETRY_V1.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_V1.max_full_frame_luminance"]/*' />
        public float max_full_frame_luminance;

        /// <include file='_NV_DISPLAY_COLORIMETRY_V1.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_V1.max_luminance"]/*' />
        public float max_luminance;

        /// <include file='_NV_DISPLAY_COLORIMETRY_V1.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_V1.hdrBrightnessLuminanceScalingFactor"]/*' />
        public float hdrBrightnessLuminanceScalingFactor;

        /// <include file='_NV_DISPLAY_COLORIMETRY_V1.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_V1.red_primary_x"]/*' />
        public float red_primary_x;

        /// <include file='_NV_DISPLAY_COLORIMETRY_V1.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_V1.red_primary_y"]/*' />
        public float red_primary_y;

        /// <include file='_NV_DISPLAY_COLORIMETRY_V1.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_V1.green_primary_x"]/*' />
        public float green_primary_x;

        /// <include file='_NV_DISPLAY_COLORIMETRY_V1.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_V1.green_primary_y"]/*' />
        public float green_primary_y;

        /// <include file='_NV_DISPLAY_COLORIMETRY_V1.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_V1.blue_primary_x"]/*' />
        public float blue_primary_x;

        /// <include file='_NV_DISPLAY_COLORIMETRY_V1.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_V1.blue_primary_y"]/*' />
        public float blue_primary_y;

        /// <include file='_NV_DISPLAY_COLORIMETRY_V1.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_V1.white_point_x"]/*' />
        public float white_point_x;

        /// <include file='_NV_DISPLAY_COLORIMETRY_V1.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_V1.white_point_y"]/*' />
        public float white_point_y;
    }
}
