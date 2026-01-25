namespace NVAPIWrapper
{
    /// <include file='_NV_COMPUTE_GPU.xml' path='doc/member[@name="_NV_COMPUTE_GPU"]/*' />
    public unsafe partial struct _NV_COMPUTE_GPU
    {
        /// <include file='_NV_COMPUTE_GPU.xml' path='doc/member[@name="_NV_COMPUTE_GPU.hPhysicalGpu"]/*' />
        [NativeTypeName("NvPhysicalGpuHandle")]
        public NvPhysicalGpuHandle__* hPhysicalGpu;

        /// <include file='_NV_COMPUTE_GPU.xml' path='doc/member[@name="_NV_COMPUTE_GPU.flags"]/*' />
        [NativeTypeName("NvU32")]
        public uint flags;
    }
}
