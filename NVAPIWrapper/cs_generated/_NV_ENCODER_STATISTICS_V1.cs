namespace NVAPIWrapper
{
    /// <include file='_NV_ENCODER_STATISTICS_V1.xml' path='doc/member[@name="_NV_ENCODER_STATISTICS_V1"]/*' />
    public partial struct _NV_ENCODER_STATISTICS_V1
    {
        /// <include file='_NV_ENCODER_STATISTICS_V1.xml' path='doc/member[@name="_NV_ENCODER_STATISTICS_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_ENCODER_STATISTICS_V1.xml' path='doc/member[@name="_NV_ENCODER_STATISTICS_V1.sessionsCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint sessionsCount;

        /// <include file='_NV_ENCODER_STATISTICS_V1.xml' path='doc/member[@name="_NV_ENCODER_STATISTICS_V1.averageFps"]/*' />
        [NativeTypeName("NvU32")]
        public uint averageFps;

        /// <include file='_NV_ENCODER_STATISTICS_V1.xml' path='doc/member[@name="_NV_ENCODER_STATISTICS_V1.averageLatency"]/*' />
        [NativeTypeName("NvU32")]
        public uint averageLatency;
    }
}
