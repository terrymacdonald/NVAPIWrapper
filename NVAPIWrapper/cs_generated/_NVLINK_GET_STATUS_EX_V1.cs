using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NVLINK_GET_STATUS_EX_V1.xml' path='doc/member[@name="_NVLINK_GET_STATUS_EX_V1"]/*' />
    public partial struct _NVLINK_GET_STATUS_EX_V1
    {
        /// <include file='_NVLINK_GET_STATUS_EX_V1.xml' path='doc/member[@name="_NVLINK_GET_STATUS_EX_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NVLINK_GET_STATUS_EX_V1.xml' path='doc/member[@name="_NVLINK_GET_STATUS_EX_V1.links"]/*' />
        [NativeTypeName("NVAPI_NVLINK_LINK_MASK_V1")]
        public _NVAPI_NVLINK_LINK_MASK_V1 links;

        /// <include file='_NVLINK_GET_STATUS_EX_V1.xml' path='doc/member[@name="_NVLINK_GET_STATUS_EX_V1.linkInfo"]/*' />
        [NativeTypeName("NVLINK_LINK_STATUS_INFO_V2[128]")]
        public _linkInfo_e__FixedBuffer linkInfo;

        /// <include file='_linkInfo_e__FixedBuffer.xml' path='doc/member[@name="_linkInfo_e__FixedBuffer"]/*' />
        [InlineArray(128)]
        public partial struct _linkInfo_e__FixedBuffer
        {
            public NVLINK_LINK_STATUS_INFO_V2 e0;
        }
    }
}
