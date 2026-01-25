namespace NVAPIWrapper
{
    /// <include file='_NV_GSYNC_DELAY.xml' path='doc/member[@name="_NV_GSYNC_DELAY"]/*' />
    public partial struct _NV_GSYNC_DELAY
    {
        /// <include file='_NV_GSYNC_DELAY.xml' path='doc/member[@name="_NV_GSYNC_DELAY.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_GSYNC_DELAY.xml' path='doc/member[@name="_NV_GSYNC_DELAY.numLines"]/*' />
        [NativeTypeName("NvU32")]
        public uint numLines;

        /// <include file='_NV_GSYNC_DELAY.xml' path='doc/member[@name="_NV_GSYNC_DELAY.numPixels"]/*' />
        [NativeTypeName("NvU32")]
        public uint numPixels;

        /// <include file='_NV_GSYNC_DELAY.xml' path='doc/member[@name="_NV_GSYNC_DELAY.maxLines"]/*' />
        [NativeTypeName("NvU32")]
        public uint maxLines;

        /// <include file='_NV_GSYNC_DELAY.xml' path='doc/member[@name="_NV_GSYNC_DELAY.minPixels"]/*' />
        [NativeTypeName("NvU32")]
        public uint minPixels;
    }
}
