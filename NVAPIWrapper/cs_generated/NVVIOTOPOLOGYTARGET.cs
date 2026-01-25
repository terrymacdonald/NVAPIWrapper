namespace NVAPIWrapper
{
    /// <include file='NVVIOTOPOLOGYTARGET.xml' path='doc/member[@name="NVVIOTOPOLOGYTARGET"]/*' />
    public unsafe partial struct NVVIOTOPOLOGYTARGET
    {
        /// <include file='NVVIOTOPOLOGYTARGET.xml' path='doc/member[@name="NVVIOTOPOLOGYTARGET.hPhysicalGpu"]/*' />
        [NativeTypeName("NvPhysicalGpuHandle")]
        public NvPhysicalGpuHandle__* hPhysicalGpu;

        /// <include file='NVVIOTOPOLOGYTARGET.xml' path='doc/member[@name="NVVIOTOPOLOGYTARGET.hVioHandle"]/*' />
        [NativeTypeName("NvVioHandle")]
        public NvVioHandle__* hVioHandle;

        /// <include file='NVVIOTOPOLOGYTARGET.xml' path='doc/member[@name="NVVIOTOPOLOGYTARGET.vioId"]/*' />
        [NativeTypeName("NvU32")]
        public uint vioId;

        /// <include file='NVVIOTOPOLOGYTARGET.xml' path='doc/member[@name="NVVIOTOPOLOGYTARGET.outputId"]/*' />
        [NativeTypeName("NvU32")]
        public uint outputId;
    }
}
