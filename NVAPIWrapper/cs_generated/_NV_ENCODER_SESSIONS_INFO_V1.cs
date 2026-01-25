namespace NVAPIWrapper
{
    /// <include file='_NV_ENCODER_SESSIONS_INFO_V1.xml' path='doc/member[@name="_NV_ENCODER_SESSIONS_INFO_V1"]/*' />
    public unsafe partial struct _NV_ENCODER_SESSIONS_INFO_V1
    {
        /// <include file='_NV_ENCODER_SESSIONS_INFO_V1.xml' path='doc/member[@name="_NV_ENCODER_SESSIONS_INFO_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_ENCODER_SESSIONS_INFO_V1.xml' path='doc/member[@name="_NV_ENCODER_SESSIONS_INFO_V1.sessionsCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint sessionsCount;

        /// <include file='_NV_ENCODER_SESSIONS_INFO_V1.xml' path='doc/member[@name="_NV_ENCODER_SESSIONS_INFO_V1.pSessionInfo"]/*' />
        [NativeTypeName("NV_ENCODER_PER_SESSION_INFO_V1 *")]
        public _NV_ENCODER_PER_SESSION_INFO_V1* pSessionInfo;
    }
}
