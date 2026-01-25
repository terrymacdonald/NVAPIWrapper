namespace NVAPIWrapper
{
    /// <include file='NV_DISPLAY_DRIVER_MEMORY_INFO_V1.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_MEMORY_INFO_V1"]/*' />
    public partial struct NV_DISPLAY_DRIVER_MEMORY_INFO_V1
    {
        /// <include file='NV_DISPLAY_DRIVER_MEMORY_INFO_V1.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_MEMORY_INFO_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_DISPLAY_DRIVER_MEMORY_INFO_V1.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_MEMORY_INFO_V1.dedicatedVideoMemory"]/*' />
        [NativeTypeName("NvU32")]
        public uint dedicatedVideoMemory;

        /// <include file='NV_DISPLAY_DRIVER_MEMORY_INFO_V1.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_MEMORY_INFO_V1.availableDedicatedVideoMemory"]/*' />
        [NativeTypeName("NvU32")]
        public uint availableDedicatedVideoMemory;

        /// <include file='NV_DISPLAY_DRIVER_MEMORY_INFO_V1.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_MEMORY_INFO_V1.systemVideoMemory"]/*' />
        [NativeTypeName("NvU32")]
        public uint systemVideoMemory;

        /// <include file='NV_DISPLAY_DRIVER_MEMORY_INFO_V1.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_MEMORY_INFO_V1.sharedSystemMemory"]/*' />
        [NativeTypeName("NvU32")]
        public uint sharedSystemMemory;
    }
}
