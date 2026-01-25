namespace NVAPIWrapper
{
    /// <include file='_NV_TIMING.xml' path='doc/member[@name="_NV_TIMING"]/*' />
    public partial struct _NV_TIMING
    {
        /// <include file='_NV_TIMING.xml' path='doc/member[@name="_NV_TIMING.HVisible"]/*' />
        [NativeTypeName("NvU16")]
        public ushort HVisible;

        /// <include file='_NV_TIMING.xml' path='doc/member[@name="_NV_TIMING.HBorder"]/*' />
        [NativeTypeName("NvU16")]
        public ushort HBorder;

        /// <include file='_NV_TIMING.xml' path='doc/member[@name="_NV_TIMING.HFrontPorch"]/*' />
        [NativeTypeName("NvU16")]
        public ushort HFrontPorch;

        /// <include file='_NV_TIMING.xml' path='doc/member[@name="_NV_TIMING.HSyncWidth"]/*' />
        [NativeTypeName("NvU16")]
        public ushort HSyncWidth;

        /// <include file='_NV_TIMING.xml' path='doc/member[@name="_NV_TIMING.HTotal"]/*' />
        [NativeTypeName("NvU16")]
        public ushort HTotal;

        /// <include file='_NV_TIMING.xml' path='doc/member[@name="_NV_TIMING.HSyncPol"]/*' />
        [NativeTypeName("NvU8")]
        public byte HSyncPol;

        /// <include file='_NV_TIMING.xml' path='doc/member[@name="_NV_TIMING.VVisible"]/*' />
        [NativeTypeName("NvU16")]
        public ushort VVisible;

        /// <include file='_NV_TIMING.xml' path='doc/member[@name="_NV_TIMING.VBorder"]/*' />
        [NativeTypeName("NvU16")]
        public ushort VBorder;

        /// <include file='_NV_TIMING.xml' path='doc/member[@name="_NV_TIMING.VFrontPorch"]/*' />
        [NativeTypeName("NvU16")]
        public ushort VFrontPorch;

        /// <include file='_NV_TIMING.xml' path='doc/member[@name="_NV_TIMING.VSyncWidth"]/*' />
        [NativeTypeName("NvU16")]
        public ushort VSyncWidth;

        /// <include file='_NV_TIMING.xml' path='doc/member[@name="_NV_TIMING.VTotal"]/*' />
        [NativeTypeName("NvU16")]
        public ushort VTotal;

        /// <include file='_NV_TIMING.xml' path='doc/member[@name="_NV_TIMING.VSyncPol"]/*' />
        [NativeTypeName("NvU8")]
        public byte VSyncPol;

        /// <include file='_NV_TIMING.xml' path='doc/member[@name="_NV_TIMING.interlaced"]/*' />
        [NativeTypeName("NvU16")]
        public ushort interlaced;

        /// <include file='_NV_TIMING.xml' path='doc/member[@name="_NV_TIMING.pclk"]/*' />
        [NativeTypeName("NvU32")]
        public uint pclk;

        /// <include file='_NV_TIMING.xml' path='doc/member[@name="_NV_TIMING.etc"]/*' />
        [NativeTypeName("NV_TIMINGEXT")]
        public tagNV_TIMINGEXT etc;
    }
}
