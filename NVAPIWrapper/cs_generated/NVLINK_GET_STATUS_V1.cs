using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NVLINK_GET_STATUS_V1.xml' path='doc/member[@name="NVLINK_GET_STATUS_V1"]/*' />
    public partial struct NVLINK_GET_STATUS_V1
    {
        /// <include file='NVLINK_GET_STATUS_V1.xml' path='doc/member[@name="NVLINK_GET_STATUS_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NVLINK_GET_STATUS_V1.xml' path='doc/member[@name="NVLINK_GET_STATUS_V1.linkMask"]/*' />
        [NativeTypeName("NvU32")]
        public uint linkMask;

        /// <include file='NVLINK_GET_STATUS_V1.xml' path='doc/member[@name="NVLINK_GET_STATUS_V1.linkInfo"]/*' />
        [NativeTypeName("NVLINK_LINK_STATUS_INFO_V1[32]")]
        public _linkInfo_e__FixedBuffer linkInfo;

        /// <include file='_linkInfo_e__FixedBuffer.xml' path='doc/member[@name="_linkInfo_e__FixedBuffer"]/*' />
        [InlineArray(32)]
        public partial struct _linkInfo_e__FixedBuffer
        {
            public NVLINK_LINK_STATUS_INFO_V1 e0;
        }
    }
}
