namespace NVAPIWrapper
{
    /// <include file='_NV_MOSAIC_DISPLAY_SETTING_V1.xml' path='doc/member[@name="_NV_MOSAIC_DISPLAY_SETTING_V1"]/*' />
    public partial struct _NV_MOSAIC_DISPLAY_SETTING_V1
    {
        /// <include file='_NV_MOSAIC_DISPLAY_SETTING_V1.xml' path='doc/member[@name="_NV_MOSAIC_DISPLAY_SETTING_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_MOSAIC_DISPLAY_SETTING_V1.xml' path='doc/member[@name="_NV_MOSAIC_DISPLAY_SETTING_V1.width"]/*' />
        [NativeTypeName("NvU32")]
        public uint width;

        /// <include file='_NV_MOSAIC_DISPLAY_SETTING_V1.xml' path='doc/member[@name="_NV_MOSAIC_DISPLAY_SETTING_V1.height"]/*' />
        [NativeTypeName("NvU32")]
        public uint height;

        /// <include file='_NV_MOSAIC_DISPLAY_SETTING_V1.xml' path='doc/member[@name="_NV_MOSAIC_DISPLAY_SETTING_V1.bpp"]/*' />
        [NativeTypeName("NvU32")]
        public uint bpp;

        /// <include file='_NV_MOSAIC_DISPLAY_SETTING_V1.xml' path='doc/member[@name="_NV_MOSAIC_DISPLAY_SETTING_V1.freq"]/*' />
        [NativeTypeName("NvU32")]
        public uint freq;
    }
}
