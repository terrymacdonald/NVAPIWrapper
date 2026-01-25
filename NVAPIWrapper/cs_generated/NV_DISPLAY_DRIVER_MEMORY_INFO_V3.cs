namespace NVAPIWrapper
{
    /// <include file='NV_DISPLAY_DRIVER_MEMORY_INFO_V3.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_MEMORY_INFO_V3"]/*' />
    public partial struct NV_DISPLAY_DRIVER_MEMORY_INFO_V3
    {
        /// <include file='NV_DISPLAY_DRIVER_MEMORY_INFO_V3.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_MEMORY_INFO_V3.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_DISPLAY_DRIVER_MEMORY_INFO_V3.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_MEMORY_INFO_V3.dedicatedVideoMemory"]/*' />
        [NativeTypeName("NvU32")]
        public uint dedicatedVideoMemory;

        /// <include file='NV_DISPLAY_DRIVER_MEMORY_INFO_V3.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_MEMORY_INFO_V3.availableDedicatedVideoMemory"]/*' />
        [NativeTypeName("NvU32")]
        public uint availableDedicatedVideoMemory;

        /// <include file='NV_DISPLAY_DRIVER_MEMORY_INFO_V3.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_MEMORY_INFO_V3.systemVideoMemory"]/*' />
        [NativeTypeName("NvU32")]
        public uint systemVideoMemory;

        /// <include file='NV_DISPLAY_DRIVER_MEMORY_INFO_V3.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_MEMORY_INFO_V3.sharedSystemMemory"]/*' />
        [NativeTypeName("NvU32")]
        public uint sharedSystemMemory;

        /// <include file='NV_DISPLAY_DRIVER_MEMORY_INFO_V3.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_MEMORY_INFO_V3.curAvailableDedicatedVideoMemory"]/*' />
        [NativeTypeName("NvU32")]
        public uint curAvailableDedicatedVideoMemory;

        /// <include file='NV_DISPLAY_DRIVER_MEMORY_INFO_V3.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_MEMORY_INFO_V3.dedicatedVideoMemoryEvictionsSize"]/*' />
        [NativeTypeName("NvU32")]
        public uint dedicatedVideoMemoryEvictionsSize;

        /// <include file='NV_DISPLAY_DRIVER_MEMORY_INFO_V3.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_MEMORY_INFO_V3.dedicatedVideoMemoryEvictionCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint dedicatedVideoMemoryEvictionCount;
    }
}
