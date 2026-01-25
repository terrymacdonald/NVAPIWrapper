namespace NVAPIWrapper
{
    /// <include file='_NVVIOVIDEOMODE.xml' path='doc/member[@name="_NVVIOVIDEOMODE"]/*' />
    public partial struct _NVVIOVIDEOMODE
    {
        /// <include file='_NVVIOVIDEOMODE.xml' path='doc/member[@name="_NVVIOVIDEOMODE.horizontalPixels"]/*' />
        [NativeTypeName("NvU32")]
        public uint horizontalPixels;

        /// <include file='_NVVIOVIDEOMODE.xml' path='doc/member[@name="_NVVIOVIDEOMODE.verticalLines"]/*' />
        [NativeTypeName("NvU32")]
        public uint verticalLines;

        /// <include file='_NVVIOVIDEOMODE.xml' path='doc/member[@name="_NVVIOVIDEOMODE.fFrameRate"]/*' />
        public float fFrameRate;

        /// <include file='_NVVIOVIDEOMODE.xml' path='doc/member[@name="_NVVIOVIDEOMODE.interlaceMode"]/*' />
        [NativeTypeName("NVVIOINTERLACEMODE")]
        public _NVVIOINTERLACEMODE interlaceMode;

        /// <include file='_NVVIOVIDEOMODE.xml' path='doc/member[@name="_NVVIOVIDEOMODE.videoStandard"]/*' />
        [NativeTypeName("NVVIOVIDEOSTANDARD")]
        public _NVVIOVIDEOSTANDARD videoStandard;

        /// <include file='_NVVIOVIDEOMODE.xml' path='doc/member[@name="_NVVIOVIDEOMODE.videoType"]/*' />
        [NativeTypeName("NVVIOVIDEOTYPE")]
        public _NVVIOVIDEOTYPE videoType;
    }
}
