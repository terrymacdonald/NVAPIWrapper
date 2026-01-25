namespace NVAPIWrapper
{
    /// <include file='_NVVIOSYNCDELAY.xml' path='doc/member[@name="_NVVIOSYNCDELAY"]/*' />
    public partial struct _NVVIOSYNCDELAY
    {
        /// <include file='_NVVIOSYNCDELAY.xml' path='doc/member[@name="_NVVIOSYNCDELAY.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NVVIOSYNCDELAY.xml' path='doc/member[@name="_NVVIOSYNCDELAY.horizontalDelay"]/*' />
        [NativeTypeName("NvU32")]
        public uint horizontalDelay;

        /// <include file='_NVVIOSYNCDELAY.xml' path='doc/member[@name="_NVVIOSYNCDELAY.verticalDelay"]/*' />
        [NativeTypeName("NvU32")]
        public uint verticalDelay;
    }
}
