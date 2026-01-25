namespace NVAPIWrapper
{
    /// <include file='NV_CUSTOM_DISPLAY.xml' path='doc/member[@name="NV_CUSTOM_DISPLAY"]/*' />
    public partial struct NV_CUSTOM_DISPLAY
    {
        /// <include file='NV_CUSTOM_DISPLAY.xml' path='doc/member[@name="NV_CUSTOM_DISPLAY.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_CUSTOM_DISPLAY.xml' path='doc/member[@name="NV_CUSTOM_DISPLAY.width"]/*' />
        [NativeTypeName("NvU32")]
        public uint width;

        /// <include file='NV_CUSTOM_DISPLAY.xml' path='doc/member[@name="NV_CUSTOM_DISPLAY.height"]/*' />
        [NativeTypeName("NvU32")]
        public uint height;

        /// <include file='NV_CUSTOM_DISPLAY.xml' path='doc/member[@name="NV_CUSTOM_DISPLAY.depth"]/*' />
        [NativeTypeName("NvU32")]
        public uint depth;

        /// <include file='NV_CUSTOM_DISPLAY.xml' path='doc/member[@name="NV_CUSTOM_DISPLAY.colorFormat"]/*' />
        [NativeTypeName("NV_FORMAT")]
        public _NV_FORMAT colorFormat;

        /// <include file='NV_CUSTOM_DISPLAY.xml' path='doc/member[@name="NV_CUSTOM_DISPLAY.srcPartition"]/*' />
        public NV_VIEWPORTF srcPartition;

        /// <include file='NV_CUSTOM_DISPLAY.xml' path='doc/member[@name="NV_CUSTOM_DISPLAY.xRatio"]/*' />
        public float xRatio;

        /// <include file='NV_CUSTOM_DISPLAY.xml' path='doc/member[@name="NV_CUSTOM_DISPLAY.yRatio"]/*' />
        public float yRatio;

        /// <include file='NV_CUSTOM_DISPLAY.xml' path='doc/member[@name="NV_CUSTOM_DISPLAY.timing"]/*' />
        [NativeTypeName("NV_TIMING")]
        public _NV_TIMING timing;

        public uint _bitfield;

        /// <include file='NV_CUSTOM_DISPLAY.xml' path='doc/member[@name="NV_CUSTOM_DISPLAY.hwModeSetOnly"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint hwModeSetOnly
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }
    }
}
