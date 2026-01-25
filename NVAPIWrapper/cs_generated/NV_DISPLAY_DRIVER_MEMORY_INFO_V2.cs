namespace NVAPIWrapper
{
    /// <include file='NV_DISPLAY_DRIVER_MEMORY_INFO_V2.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_MEMORY_INFO_V2"]/*' />
    public partial struct NV_DISPLAY_DRIVER_MEMORY_INFO_V2
    {
        /// <include file='NV_DISPLAY_DRIVER_MEMORY_INFO_V2.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_MEMORY_INFO_V2.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_DISPLAY_DRIVER_MEMORY_INFO_V2.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_MEMORY_INFO_V2.dedicatedVideoMemory"]/*' />
        [NativeTypeName("NvU32")]
        public uint dedicatedVideoMemory;

        /// <include file='NV_DISPLAY_DRIVER_MEMORY_INFO_V2.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_MEMORY_INFO_V2.availableDedicatedVideoMemory"]/*' />
        [NativeTypeName("NvU32")]
        public uint availableDedicatedVideoMemory;

        /// <include file='NV_DISPLAY_DRIVER_MEMORY_INFO_V2.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_MEMORY_INFO_V2.systemVideoMemory"]/*' />
        [NativeTypeName("NvU32")]
        public uint systemVideoMemory;

        /// <include file='NV_DISPLAY_DRIVER_MEMORY_INFO_V2.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_MEMORY_INFO_V2.sharedSystemMemory"]/*' />
        [NativeTypeName("NvU32")]
        public uint sharedSystemMemory;

        /// <include file='NV_DISPLAY_DRIVER_MEMORY_INFO_V2.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_MEMORY_INFO_V2.curAvailableDedicatedVideoMemory"]/*' />
        [NativeTypeName("NvU32")]
        public uint curAvailableDedicatedVideoMemory;
    }
}
