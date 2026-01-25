namespace NVAPIWrapper
{
    /// <include file='NV_GPU_MEMORY_INFO_EX_V1.xml' path='doc/member[@name="NV_GPU_MEMORY_INFO_EX_V1"]/*' />
    public partial struct NV_GPU_MEMORY_INFO_EX_V1
    {
        /// <include file='NV_GPU_MEMORY_INFO_EX_V1.xml' path='doc/member[@name="NV_GPU_MEMORY_INFO_EX_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_GPU_MEMORY_INFO_EX_V1.xml' path='doc/member[@name="NV_GPU_MEMORY_INFO_EX_V1.dedicatedVideoMemory"]/*' />
        [NativeTypeName("NvU64")]
        public ulong dedicatedVideoMemory;

        /// <include file='NV_GPU_MEMORY_INFO_EX_V1.xml' path='doc/member[@name="NV_GPU_MEMORY_INFO_EX_V1.availableDedicatedVideoMemory"]/*' />
        [NativeTypeName("NvU64")]
        public ulong availableDedicatedVideoMemory;

        /// <include file='NV_GPU_MEMORY_INFO_EX_V1.xml' path='doc/member[@name="NV_GPU_MEMORY_INFO_EX_V1.systemVideoMemory"]/*' />
        [NativeTypeName("NvU64")]
        public ulong systemVideoMemory;

        /// <include file='NV_GPU_MEMORY_INFO_EX_V1.xml' path='doc/member[@name="NV_GPU_MEMORY_INFO_EX_V1.sharedSystemMemory"]/*' />
        [NativeTypeName("NvU64")]
        public ulong sharedSystemMemory;

        /// <include file='NV_GPU_MEMORY_INFO_EX_V1.xml' path='doc/member[@name="NV_GPU_MEMORY_INFO_EX_V1.curAvailableDedicatedVideoMemory"]/*' />
        [NativeTypeName("NvU64")]
        public ulong curAvailableDedicatedVideoMemory;

        /// <include file='NV_GPU_MEMORY_INFO_EX_V1.xml' path='doc/member[@name="NV_GPU_MEMORY_INFO_EX_V1.dedicatedVideoMemoryEvictionsSize"]/*' />
        [NativeTypeName("NvU64")]
        public ulong dedicatedVideoMemoryEvictionsSize;

        /// <include file='NV_GPU_MEMORY_INFO_EX_V1.xml' path='doc/member[@name="NV_GPU_MEMORY_INFO_EX_V1.dedicatedVideoMemoryEvictionCount"]/*' />
        [NativeTypeName("NvU64")]
        public ulong dedicatedVideoMemoryEvictionCount;

        /// <include file='NV_GPU_MEMORY_INFO_EX_V1.xml' path='doc/member[@name="NV_GPU_MEMORY_INFO_EX_V1.dedicatedVideoMemoryPromotionsSize"]/*' />
        [NativeTypeName("NvU64")]
        public ulong dedicatedVideoMemoryPromotionsSize;

        /// <include file='NV_GPU_MEMORY_INFO_EX_V1.xml' path='doc/member[@name="NV_GPU_MEMORY_INFO_EX_V1.dedicatedVideoMemoryPromotionCount"]/*' />
        [NativeTypeName("NvU64")]
        public ulong dedicatedVideoMemoryPromotionCount;
    }
}
