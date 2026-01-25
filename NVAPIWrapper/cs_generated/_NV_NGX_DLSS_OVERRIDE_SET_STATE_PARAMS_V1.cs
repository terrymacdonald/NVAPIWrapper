using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_NGX_DLSS_OVERRIDE_SET_STATE_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_SET_STATE_PARAMS_V1"]/*' />
    public partial struct _NV_NGX_DLSS_OVERRIDE_SET_STATE_PARAMS_V1
    {
        /// <include file='_NV_NGX_DLSS_OVERRIDE_SET_STATE_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_SET_STATE_PARAMS_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_NGX_DLSS_OVERRIDE_SET_STATE_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_SET_STATE_PARAMS_V1.processIdentifier"]/*' />
        [NativeTypeName("NvU32")]
        public uint processIdentifier;

        /// <include file='_NV_NGX_DLSS_OVERRIDE_SET_STATE_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_SET_STATE_PARAMS_V1.feature"]/*' />
        [NativeTypeName("NvU32")]
        public uint feature;

        /// <include file='_NV_NGX_DLSS_OVERRIDE_SET_STATE_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_SET_STATE_PARAMS_V1.feedbackMask"]/*' />
        [NativeTypeName("NvU64")]
        public ulong feedbackMask;

        /// <include file='_NV_NGX_DLSS_OVERRIDE_SET_STATE_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_SET_STATE_PARAMS_V1.reserved"]/*' />
        [NativeTypeName("NvU64[4]")]
        public _reserved_e__FixedBuffer reserved;

        /// <include file='_reserved_e__FixedBuffer.xml' path='doc/member[@name="_reserved_e__FixedBuffer"]/*' />
        [InlineArray(4)]
        public partial struct _reserved_e__FixedBuffer
        {
            public ulong e0;
        }
    }
}
