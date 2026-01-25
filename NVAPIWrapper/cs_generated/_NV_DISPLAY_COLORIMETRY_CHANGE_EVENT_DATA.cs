namespace NVAPIWrapper
{
    /// <include file='_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA"]/*' />
    public partial struct _NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA
    {
        /// <include file='_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA.displayId"]/*' />
        [NativeTypeName("NvU32")]
        public uint displayId;

        /// <include file='_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA.min_luminance"]/*' />
        public float min_luminance;

        /// <include file='_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA.max_full_frame_luminance"]/*' />
        public float max_full_frame_luminance;

        /// <include file='_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA.max_luminance"]/*' />
        public float max_luminance;

        /// <include file='_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA.hdrBrightnessLuminanceScalingFactor"]/*' />
        public float hdrBrightnessLuminanceScalingFactor;

        /// <include file='_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA.red_primary_x"]/*' />
        public float red_primary_x;

        /// <include file='_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA.red_primary_y"]/*' />
        public float red_primary_y;

        /// <include file='_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA.green_primary_x"]/*' />
        public float green_primary_x;

        /// <include file='_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA.green_primary_y"]/*' />
        public float green_primary_y;

        /// <include file='_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA.blue_primary_x"]/*' />
        public float blue_primary_x;

        /// <include file='_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA.blue_primary_y"]/*' />
        public float blue_primary_y;

        /// <include file='_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA.white_point_x"]/*' />
        public float white_point_x;

        /// <include file='_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA.xml' path='doc/member[@name="_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA.white_point_y"]/*' />
        public float white_point_y;
    }
}
