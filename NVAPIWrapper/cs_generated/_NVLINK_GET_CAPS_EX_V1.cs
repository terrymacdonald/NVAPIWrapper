using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NVLINK_GET_CAPS_EX_V1.xml' path='doc/member[@name="_NVLINK_GET_CAPS_EX_V1"]/*' />
    public partial struct _NVLINK_GET_CAPS_EX_V1
    {
        /// <include file='_NVLINK_GET_CAPS_EX_V1.xml' path='doc/member[@name="_NVLINK_GET_CAPS_EX_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NVLINK_GET_CAPS_EX_V1.xml' path='doc/member[@name="_NVLINK_GET_CAPS_EX_V1.capsTbl"]/*' />
        [NativeTypeName("NvU32")]
        public uint capsTbl;

        /// <include file='_NVLINK_GET_CAPS_EX_V1.xml' path='doc/member[@name="_NVLINK_GET_CAPS_EX_V1.lowestNvlinkVersion"]/*' />
        [NativeTypeName("NvU8")]
        public byte lowestNvlinkVersion;

        /// <include file='_NVLINK_GET_CAPS_EX_V1.xml' path='doc/member[@name="_NVLINK_GET_CAPS_EX_V1.highestNvlinkVersion"]/*' />
        [NativeTypeName("NvU8")]
        public byte highestNvlinkVersion;

        /// <include file='_NVLINK_GET_CAPS_EX_V1.xml' path='doc/member[@name="_NVLINK_GET_CAPS_EX_V1.lowestNciVersion"]/*' />
        [NativeTypeName("NvU8")]
        public byte lowestNciVersion;

        /// <include file='_NVLINK_GET_CAPS_EX_V1.xml' path='doc/member[@name="_NVLINK_GET_CAPS_EX_V1.highestNciVersion"]/*' />
        [NativeTypeName("NvU8")]
        public byte highestNciVersion;

        /// <include file='_NVLINK_GET_CAPS_EX_V1.xml' path='doc/member[@name="_NVLINK_GET_CAPS_EX_V1.links"]/*' />
        [NativeTypeName("NVAPI_NVLINK_LINK_MASK_V1")]
        public _NVAPI_NVLINK_LINK_MASK_V1 links;

        /// <include file='_NVLINK_GET_CAPS_EX_V1.xml' path='doc/member[@name="_NVLINK_GET_CAPS_EX_V1.reserved"]/*' />
        [NativeTypeName("NvU32[2]")]
        public _reserved_e__FixedBuffer reserved;

        /// <include file='_reserved_e__FixedBuffer.xml' path='doc/member[@name="_reserved_e__FixedBuffer"]/*' />
        [InlineArray(2)]
        public partial struct _reserved_e__FixedBuffer
        {
            public uint e0;
        }
    }
}
