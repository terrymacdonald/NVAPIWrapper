using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1"]/*' />
    public partial struct _NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1
    {
        /// <include file='_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1.processIdentifier"]/*' />
        [NativeTypeName("NvU32")]
        public uint processIdentifier;

        /// <include file='_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1.feedbackMaskSR"]/*' />
        [NativeTypeName("NvU64")]
        public ulong feedbackMaskSR;

        /// <include file='_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1.feedbackMaskRR"]/*' />
        [NativeTypeName("NvU64")]
        public ulong feedbackMaskRR;

        /// <include file='_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1.feedbackMaskFG"]/*' />
        [NativeTypeName("NvU64")]
        public ulong feedbackMaskFG;

        /// <include file='_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1.scalingRatio"]/*' />
        [NativeTypeName("NvF32")]
        public float scalingRatio;

        /// <include file='_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1.performanceMode"]/*' />
        [NativeTypeName("NvU32")]
        public uint performanceMode;

        /// <include file='_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1.renderPreset"]/*' />
        [NativeTypeName("NvU32")]
        public uint renderPreset;

        /// <include file='_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1.frameGenerationCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint frameGenerationCount;

        /// <include file='_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1.frameGenerationPreset"]/*' />
        [NativeTypeName("NvU32")]
        public uint frameGenerationPreset;

        /// <include file='_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1.reserved"]/*' />
        [NativeTypeName("NvU32[3]")]
        public _reserved_e__FixedBuffer reserved;

        /// <include file='_reserved_e__FixedBuffer.xml' path='doc/member[@name="_reserved_e__FixedBuffer"]/*' />
        [InlineArray(3)]
        public partial struct _reserved_e__FixedBuffer
        {
            public uint e0;
        }
    }
}
