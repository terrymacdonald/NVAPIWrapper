namespace NVAPIWrapper
{
    /// <include file='_NV_GSYNC_GPU.xml' path='doc/member[@name="_NV_GSYNC_GPU"]/*' />
    public unsafe partial struct _NV_GSYNC_GPU
    {
        /// <include file='_NV_GSYNC_GPU.xml' path='doc/member[@name="_NV_GSYNC_GPU.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_GSYNC_GPU.xml' path='doc/member[@name="_NV_GSYNC_GPU.hPhysicalGpu"]/*' />
        [NativeTypeName("NvPhysicalGpuHandle")]
        public NvPhysicalGpuHandle__* hPhysicalGpu;

        /// <include file='_NV_GSYNC_GPU.xml' path='doc/member[@name="_NV_GSYNC_GPU.connector"]/*' />
        [NativeTypeName("NVAPI_GSYNC_GPU_TOPOLOGY_CONNECTOR")]
        public _NVAPI_GSYNC_GPU_TOPOLOGY_CONNECTOR connector;

        /// <include file='_NV_GSYNC_GPU.xml' path='doc/member[@name="_NV_GSYNC_GPU.hProxyPhysicalGpu"]/*' />
        [NativeTypeName("NvPhysicalGpuHandle")]
        public NvPhysicalGpuHandle__* hProxyPhysicalGpu;

        public uint _bitfield;

        /// <include file='_NV_GSYNC_GPU.xml' path='doc/member[@name="_NV_GSYNC_GPU.isSynced"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isSynced
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

        /// <include file='_NV_GSYNC_GPU.xml' path='doc/member[@name="_NV_GSYNC_GPU.reserved"]/*' />
        [NativeTypeName("NvU32 : 31")]
        public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x7FFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x7FFFFFFFu << 1)) | ((value & 0x7FFFFFFFu) << 1);
            }
        }
    }
}
