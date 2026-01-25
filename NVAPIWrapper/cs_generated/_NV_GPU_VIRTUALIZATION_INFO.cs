namespace NVAPIWrapper
{
    /// <include file='_NV_GPU_VIRTUALIZATION_INFO.xml' path='doc/member[@name="_NV_GPU_VIRTUALIZATION_INFO"]/*' />
    public partial struct _NV_GPU_VIRTUALIZATION_INFO
    {
        /// <include file='_NV_GPU_VIRTUALIZATION_INFO.xml' path='doc/member[@name="_NV_GPU_VIRTUALIZATION_INFO.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_GPU_VIRTUALIZATION_INFO.xml' path='doc/member[@name="_NV_GPU_VIRTUALIZATION_INFO.virtualizationMode"]/*' />
        [NativeTypeName("NV_VIRTUALIZATION_MODE")]
        public _NV_VIRTUALIZATION_MODE virtualizationMode;

        /// <include file='_NV_GPU_VIRTUALIZATION_INFO.xml' path='doc/member[@name="_NV_GPU_VIRTUALIZATION_INFO.reserved"]/*' />
        [NativeTypeName("NvU32")]
        public uint reserved;
    }
}
