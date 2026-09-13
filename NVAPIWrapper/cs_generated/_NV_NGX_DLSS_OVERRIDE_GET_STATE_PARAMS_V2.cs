using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2"]/*' />
    public partial struct _NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2
    {
        /// <include file='_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.processIdentifier"]/*' />
        [NativeTypeName("NvU32")]
        public uint processIdentifier;

        /// <include file='_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.feedbackMaskSR"]/*' />
        [NativeTypeName("NvU64")]
        public ulong feedbackMaskSR;

        /// <include file='_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.feedbackMaskRR"]/*' />
        [NativeTypeName("NvU64")]
        public ulong feedbackMaskRR;

        /// <include file='_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.feedbackMaskFG"]/*' />
        [NativeTypeName("NvU64")]
        public ulong feedbackMaskFG;

        /// <include file='_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.scalingRatio"]/*' />
        [NativeTypeName("NvF32")]
        public float scalingRatio;

        /// <include file='_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.performanceMode"]/*' />
        [NativeTypeName("NvU32")]
        public uint performanceMode;

        /// <include file='_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.renderPreset"]/*' />
        [NativeTypeName("NvU32")]
        public uint renderPreset;

        /// <include file='_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.frameGenerationCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint frameGenerationCount;

        /// <include file='_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.frameGenerationPreset"]/*' />
        [NativeTypeName("NvU32")]
        public uint frameGenerationPreset;

        /// <include file='_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.frameGenerationMode"]/*' />
        [NativeTypeName("NvU32")]
        public uint frameGenerationMode;

        /// <include file='_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.reserved0"]/*' />
        [NativeTypeName("NvU64")]
        public ulong reserved0;

        /// <include file='_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.reserved1"]/*' />
        [NativeTypeName("NvU32")]
        public uint reserved1;

        /// <include file='_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.xml' path='doc/member[@name="_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V2.reserved"]/*' />
        [NativeTypeName("NvU32[7]")]
        public _reserved_e__FixedBuffer reserved;

        /// <include file='_reserved_e__FixedBuffer.xml' path='doc/member[@name="_reserved_e__FixedBuffer"]/*' />
        [InlineArray(7)]
        public partial struct _reserved_e__FixedBuffer
        {
            public uint e0;
        }
    }
}
