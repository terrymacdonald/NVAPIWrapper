using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_NGX_GET_DRIVER_FEATURE_SUPPORT_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_GET_DRIVER_FEATURE_SUPPORT_PARAMS_V1"]/*' />
    public partial struct _NV_NGX_GET_DRIVER_FEATURE_SUPPORT_PARAMS_V1
    {
        /// <include file='_NV_NGX_GET_DRIVER_FEATURE_SUPPORT_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_GET_DRIVER_FEATURE_SUPPORT_PARAMS_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_NGX_GET_DRIVER_FEATURE_SUPPORT_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_GET_DRIVER_FEATURE_SUPPORT_PARAMS_V1.featureCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint featureCount;

        /// <include file='_NV_NGX_GET_DRIVER_FEATURE_SUPPORT_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_GET_DRIVER_FEATURE_SUPPORT_PARAMS_V1.featureSupportInfo"]/*' />
        [NativeTypeName("NV_NGX_DRIVER_FEATURE_SUPPORT_INFO[16]")]
        public _featureSupportInfo_e__FixedBuffer featureSupportInfo;

        /// <include file='_NV_NGX_GET_DRIVER_FEATURE_SUPPORT_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_GET_DRIVER_FEATURE_SUPPORT_PARAMS_V1.reserved"]/*' />
        [NativeTypeName("NvU32[6]")]
        public _reserved_e__FixedBuffer reserved;

        /// <include file='_featureSupportInfo_e__FixedBuffer.xml' path='doc/member[@name="_featureSupportInfo_e__FixedBuffer"]/*' />
        [InlineArray(16)]
        public partial struct _featureSupportInfo_e__FixedBuffer
        {
            public _NV_NGX_DRIVER_FEATURE_SUPPORT_INFO e0;
        }

        /// <include file='_reserved_e__FixedBuffer.xml' path='doc/member[@name="_reserved_e__FixedBuffer"]/*' />
        [InlineArray(6)]
        public partial struct _reserved_e__FixedBuffer
        {
            public uint e0;
        }
    }
}
