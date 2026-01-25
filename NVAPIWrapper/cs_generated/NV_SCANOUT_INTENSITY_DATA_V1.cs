namespace NVAPIWrapper
{
    /// <include file='NV_SCANOUT_INTENSITY_DATA_V1.xml' path='doc/member[@name="NV_SCANOUT_INTENSITY_DATA_V1"]/*' />
    public unsafe partial struct NV_SCANOUT_INTENSITY_DATA_V1
    {
        /// <include file='NV_SCANOUT_INTENSITY_DATA_V1.xml' path='doc/member[@name="NV_SCANOUT_INTENSITY_DATA_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_SCANOUT_INTENSITY_DATA_V1.xml' path='doc/member[@name="NV_SCANOUT_INTENSITY_DATA_V1.width"]/*' />
        [NativeTypeName("NvU32")]
        public uint width;

        /// <include file='NV_SCANOUT_INTENSITY_DATA_V1.xml' path='doc/member[@name="NV_SCANOUT_INTENSITY_DATA_V1.height"]/*' />
        [NativeTypeName("NvU32")]
        public uint height;

        /// <include file='NV_SCANOUT_INTENSITY_DATA_V1.xml' path='doc/member[@name="NV_SCANOUT_INTENSITY_DATA_V1.blendingTexture"]/*' />
        public float* blendingTexture;
    }
}
