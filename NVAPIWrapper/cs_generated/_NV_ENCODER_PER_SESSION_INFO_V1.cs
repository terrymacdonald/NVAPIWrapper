namespace NVAPIWrapper
{
    /// <include file='_NV_ENCODER_PER_SESSION_INFO_V1.xml' path='doc/member[@name="_NV_ENCODER_PER_SESSION_INFO_V1"]/*' />
    public partial struct _NV_ENCODER_PER_SESSION_INFO_V1
    {
        /// <include file='_NV_ENCODER_PER_SESSION_INFO_V1.xml' path='doc/member[@name="_NV_ENCODER_PER_SESSION_INFO_V1.sessionId"]/*' />
        [NativeTypeName("NvU32")]
        public uint sessionId;

        /// <include file='_NV_ENCODER_PER_SESSION_INFO_V1.xml' path='doc/member[@name="_NV_ENCODER_PER_SESSION_INFO_V1.processId"]/*' />
        [NativeTypeName("NvU32")]
        public uint processId;

        /// <include file='_NV_ENCODER_PER_SESSION_INFO_V1.xml' path='doc/member[@name="_NV_ENCODER_PER_SESSION_INFO_V1.vgpuInstance"]/*' />
        [NativeTypeName("NvU32")]
        public uint vgpuInstance;

        /// <include file='_NV_ENCODER_PER_SESSION_INFO_V1.xml' path='doc/member[@name="_NV_ENCODER_PER_SESSION_INFO_V1.codecType"]/*' />
        [NativeTypeName("NV_ENCODER_TYPE")]
        public _NV_ENCODER_TYPE codecType;

        /// <include file='_NV_ENCODER_PER_SESSION_INFO_V1.xml' path='doc/member[@name="_NV_ENCODER_PER_SESSION_INFO_V1.hResolution"]/*' />
        [NativeTypeName("NvU32")]
        public uint hResolution;

        /// <include file='_NV_ENCODER_PER_SESSION_INFO_V1.xml' path='doc/member[@name="_NV_ENCODER_PER_SESSION_INFO_V1.vResolution"]/*' />
        [NativeTypeName("NvU32")]
        public uint vResolution;

        /// <include file='_NV_ENCODER_PER_SESSION_INFO_V1.xml' path='doc/member[@name="_NV_ENCODER_PER_SESSION_INFO_V1.averageEncodeFps"]/*' />
        [NativeTypeName("NvU32")]
        public uint averageEncodeFps;

        /// <include file='_NV_ENCODER_PER_SESSION_INFO_V1.xml' path='doc/member[@name="_NV_ENCODER_PER_SESSION_INFO_V1.averageEncodeLatency"]/*' />
        [NativeTypeName("NvU32")]
        public uint averageEncodeLatency;
    }
}
