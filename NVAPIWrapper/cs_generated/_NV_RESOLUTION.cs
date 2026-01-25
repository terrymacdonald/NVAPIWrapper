namespace NVAPIWrapper
{
    /// <include file='_NV_RESOLUTION.xml' path='doc/member[@name="_NV_RESOLUTION"]/*' />
    public partial struct _NV_RESOLUTION
    {
        /// <include file='_NV_RESOLUTION.xml' path='doc/member[@name="_NV_RESOLUTION.width"]/*' />
        [NativeTypeName("NvU32")]
        public uint width;

        /// <include file='_NV_RESOLUTION.xml' path='doc/member[@name="_NV_RESOLUTION.height"]/*' />
        [NativeTypeName("NvU32")]
        public uint height;

        /// <include file='_NV_RESOLUTION.xml' path='doc/member[@name="_NV_RESOLUTION.colorDepth"]/*' />
        [NativeTypeName("NvU32")]
        public uint colorDepth;
    }
}
