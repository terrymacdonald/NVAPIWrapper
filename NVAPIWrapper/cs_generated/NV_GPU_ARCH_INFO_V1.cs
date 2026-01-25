namespace NVAPIWrapper
{
    /// <include file='NV_GPU_ARCH_INFO_V1.xml' path='doc/member[@name="NV_GPU_ARCH_INFO_V1"]/*' />
    public partial struct NV_GPU_ARCH_INFO_V1
    {
        /// <include file='NV_GPU_ARCH_INFO_V1.xml' path='doc/member[@name="NV_GPU_ARCH_INFO_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_GPU_ARCH_INFO_V1.xml' path='doc/member[@name="NV_GPU_ARCH_INFO_V1.architecture"]/*' />
        [NativeTypeName("NvU32")]
        public uint architecture;

        /// <include file='NV_GPU_ARCH_INFO_V1.xml' path='doc/member[@name="NV_GPU_ARCH_INFO_V1.implementation"]/*' />
        [NativeTypeName("NvU32")]
        public uint implementation;

        /// <include file='NV_GPU_ARCH_INFO_V1.xml' path='doc/member[@name="NV_GPU_ARCH_INFO_V1.revision"]/*' />
        [NativeTypeName("NvU32")]
        public uint revision;
    }
}
