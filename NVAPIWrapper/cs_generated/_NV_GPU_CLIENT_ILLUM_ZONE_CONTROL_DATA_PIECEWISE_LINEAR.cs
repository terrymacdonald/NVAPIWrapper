namespace NVAPIWrapper
{
    /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR"]/*' />
    public partial struct _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR
    {
        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR.cycleType"]/*' />
        public NV_GPU_CLIENT_ILLUM_PIECEWISE_LINEAR_CYCLE_TYPE cycleType;

        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR.grpCount"]/*' />
        [NativeTypeName("NvU8")]
        public byte grpCount;

        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR.riseTimems"]/*' />
        [NativeTypeName("NvU16")]
        public ushort riseTimems;

        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR.fallTimems"]/*' />
        [NativeTypeName("NvU16")]
        public ushort fallTimems;

        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR.ATimems"]/*' />
        [NativeTypeName("NvU16")]
        public ushort ATimems;

        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR.BTimems"]/*' />
        [NativeTypeName("NvU16")]
        public ushort BTimems;

        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR.grpIdleTimems"]/*' />
        [NativeTypeName("NvU16")]
        public ushort grpIdleTimems;

        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR.phaseOffsetms"]/*' />
        [NativeTypeName("NvU16")]
        public ushort phaseOffsetms;
    }
}
