namespace NVAPIWrapper
{
    /// <include file='_NV_TIMING_INPUT.xml' path='doc/member[@name="_NV_TIMING_INPUT"]/*' />
    public partial struct _NV_TIMING_INPUT
    {
        /// <include file='_NV_TIMING_INPUT.xml' path='doc/member[@name="_NV_TIMING_INPUT.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_TIMING_INPUT.xml' path='doc/member[@name="_NV_TIMING_INPUT.width"]/*' />
        [NativeTypeName("NvU32")]
        public uint width;

        /// <include file='_NV_TIMING_INPUT.xml' path='doc/member[@name="_NV_TIMING_INPUT.height"]/*' />
        [NativeTypeName("NvU32")]
        public uint height;

        /// <include file='_NV_TIMING_INPUT.xml' path='doc/member[@name="_NV_TIMING_INPUT.rr"]/*' />
        public float rr;

        /// <include file='_NV_TIMING_INPUT.xml' path='doc/member[@name="_NV_TIMING_INPUT.flag"]/*' />
        public NV_TIMING_FLAG flag;

        /// <include file='_NV_TIMING_INPUT.xml' path='doc/member[@name="_NV_TIMING_INPUT.type"]/*' />
        [NativeTypeName("NV_TIMING_OVERRIDE")]
        public _NV_TIMING_OVERRIDE type;
    }
}
