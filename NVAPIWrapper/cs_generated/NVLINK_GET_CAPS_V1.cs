namespace NVAPIWrapper
{
    /// <include file='NVLINK_GET_CAPS_V1.xml' path='doc/member[@name="NVLINK_GET_CAPS_V1"]/*' />
    public partial struct NVLINK_GET_CAPS_V1
    {
        /// <include file='NVLINK_GET_CAPS_V1.xml' path='doc/member[@name="NVLINK_GET_CAPS_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NVLINK_GET_CAPS_V1.xml' path='doc/member[@name="NVLINK_GET_CAPS_V1.capsTbl"]/*' />
        [NativeTypeName("NvU32")]
        public uint capsTbl;

        /// <include file='NVLINK_GET_CAPS_V1.xml' path='doc/member[@name="NVLINK_GET_CAPS_V1.lowestNvlinkVersion"]/*' />
        [NativeTypeName("NvU8")]
        public byte lowestNvlinkVersion;

        /// <include file='NVLINK_GET_CAPS_V1.xml' path='doc/member[@name="NVLINK_GET_CAPS_V1.highestNvlinkVersion"]/*' />
        [NativeTypeName("NvU8")]
        public byte highestNvlinkVersion;

        /// <include file='NVLINK_GET_CAPS_V1.xml' path='doc/member[@name="NVLINK_GET_CAPS_V1.lowestNciVersion"]/*' />
        [NativeTypeName("NvU8")]
        public byte lowestNciVersion;

        /// <include file='NVLINK_GET_CAPS_V1.xml' path='doc/member[@name="NVLINK_GET_CAPS_V1.highestNciVersion"]/*' />
        [NativeTypeName("NvU8")]
        public byte highestNciVersion;

        /// <include file='NVLINK_GET_CAPS_V1.xml' path='doc/member[@name="NVLINK_GET_CAPS_V1.linkMask"]/*' />
        [NativeTypeName("NvU32")]
        public uint linkMask;
    }
}
