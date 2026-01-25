namespace NVAPIWrapper
{
    /// <include file='NV_SCANOUT_INTENSITY_DATA_V2.xml' path='doc/member[@name="NV_SCANOUT_INTENSITY_DATA_V2"]/*' />
    public unsafe partial struct NV_SCANOUT_INTENSITY_DATA_V2
    {
        /// <include file='NV_SCANOUT_INTENSITY_DATA_V2.xml' path='doc/member[@name="NV_SCANOUT_INTENSITY_DATA_V2.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_SCANOUT_INTENSITY_DATA_V2.xml' path='doc/member[@name="NV_SCANOUT_INTENSITY_DATA_V2.width"]/*' />
        [NativeTypeName("NvU32")]
        public uint width;

        /// <include file='NV_SCANOUT_INTENSITY_DATA_V2.xml' path='doc/member[@name="NV_SCANOUT_INTENSITY_DATA_V2.height"]/*' />
        [NativeTypeName("NvU32")]
        public uint height;

        /// <include file='NV_SCANOUT_INTENSITY_DATA_V2.xml' path='doc/member[@name="NV_SCANOUT_INTENSITY_DATA_V2.blendingTexture"]/*' />
        public float* blendingTexture;

        /// <include file='NV_SCANOUT_INTENSITY_DATA_V2.xml' path='doc/member[@name="NV_SCANOUT_INTENSITY_DATA_V2.offsetTexture"]/*' />
        public float* offsetTexture;

        /// <include file='NV_SCANOUT_INTENSITY_DATA_V2.xml' path='doc/member[@name="NV_SCANOUT_INTENSITY_DATA_V2.offsetTexChannels"]/*' />
        [NativeTypeName("NvU32")]
        public uint offsetTexChannels;
    }
}
