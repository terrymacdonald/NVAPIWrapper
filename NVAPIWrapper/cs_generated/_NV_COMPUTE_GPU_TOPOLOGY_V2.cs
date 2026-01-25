namespace NVAPIWrapper
{
    /// <include file='_NV_COMPUTE_GPU_TOPOLOGY_V2.xml' path='doc/member[@name="_NV_COMPUTE_GPU_TOPOLOGY_V2"]/*' />
    public unsafe partial struct _NV_COMPUTE_GPU_TOPOLOGY_V2
    {
        /// <include file='_NV_COMPUTE_GPU_TOPOLOGY_V2.xml' path='doc/member[@name="_NV_COMPUTE_GPU_TOPOLOGY_V2.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_COMPUTE_GPU_TOPOLOGY_V2.xml' path='doc/member[@name="_NV_COMPUTE_GPU_TOPOLOGY_V2.gpuCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint gpuCount;

        /// <include file='_NV_COMPUTE_GPU_TOPOLOGY_V2.xml' path='doc/member[@name="_NV_COMPUTE_GPU_TOPOLOGY_V2.computeGpus"]/*' />
        [NativeTypeName("NV_COMPUTE_GPU *")]
        public _NV_COMPUTE_GPU* computeGpus;
    }
}
