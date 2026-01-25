namespace NVAPIWrapper
{
    /// <include file='_NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_V1.xml' path='doc/member[@name="_NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_V1"]/*' />
    public unsafe partial struct _NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_V1
    {
        /// <include file='_NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_V1.xml' path='doc/member[@name="_NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_V1.xml' path='doc/member[@name="_NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_V1.hPhysicalGpu"]/*' />
        [NativeTypeName("NvPhysicalGpuHandle")]
        public NvPhysicalGpuHandle__* hPhysicalGpu;

        /// <include file='_NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_V1.xml' path='doc/member[@name="_NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_V1.Attribute"]/*' />
        [NativeTypeName("NV_GPU_ILLUMINATION_ATTRIB")]
        public _NV_GPU_ILLUMINATION_ATTRIB Attribute;

        /// <include file='_NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_V1.xml' path='doc/member[@name="_NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_V1.bSupported"]/*' />
        [NativeTypeName("NvU32")]
        public uint bSupported;
    }
}
