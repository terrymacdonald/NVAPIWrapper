namespace NVAPIWrapper
{
    /// <include file='NVLINK_LINK_STATUS_INFO_V1.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V1"]/*' />
    public partial struct NVLINK_LINK_STATUS_INFO_V1
    {
        /// <include file='NVLINK_LINK_STATUS_INFO_V1.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V1.capsTbl"]/*' />
        [NativeTypeName("NvU32")]
        public uint capsTbl;

        /// <include file='NVLINK_LINK_STATUS_INFO_V1.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V1.phyType"]/*' />
        [NativeTypeName("NvU8")]
        public byte phyType;

        /// <include file='NVLINK_LINK_STATUS_INFO_V1.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V1.subLinkWidth"]/*' />
        [NativeTypeName("NvU8")]
        public byte subLinkWidth;

        /// <include file='NVLINK_LINK_STATUS_INFO_V1.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V1.linkState"]/*' />
        [NativeTypeName("NvU32")]
        public uint linkState;

        /// <include file='NVLINK_LINK_STATUS_INFO_V1.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V1.rxSublinkStatus"]/*' />
        [NativeTypeName("NvU8")]
        public byte rxSublinkStatus;

        /// <include file='NVLINK_LINK_STATUS_INFO_V1.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V1.txSublinkStatus"]/*' />
        [NativeTypeName("NvU8")]
        public byte txSublinkStatus;

        /// <include file='NVLINK_LINK_STATUS_INFO_V1.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V1.nvlinkVersion"]/*' />
        [NativeTypeName("NvU8")]
        public byte nvlinkVersion;

        /// <include file='NVLINK_LINK_STATUS_INFO_V1.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V1.nciVersion"]/*' />
        [NativeTypeName("NvU8")]
        public byte nciVersion;

        /// <include file='NVLINK_LINK_STATUS_INFO_V1.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V1.phyVersion"]/*' />
        [NativeTypeName("NvU8")]
        public byte phyVersion;

        /// <include file='NVLINK_LINK_STATUS_INFO_V1.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V1.nvlinkCommonClockSpeedMhz"]/*' />
        [NativeTypeName("NvU32")]
        public uint nvlinkCommonClockSpeedMhz;

        /// <include file='NVLINK_LINK_STATUS_INFO_V1.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V1.nvlinkRefClkSpeedMhz"]/*' />
        [NativeTypeName("NvU32")]
        public uint nvlinkRefClkSpeedMhz;

        /// <include file='NVLINK_LINK_STATUS_INFO_V1.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V1.nvlinkRefClkType"]/*' />
        [NativeTypeName("NvU8")]
        public byte nvlinkRefClkType;

        /// <include file='NVLINK_LINK_STATUS_INFO_V1.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V1.nvlinkLinkClockMhz"]/*' />
        [NativeTypeName("NvU32")]
        public uint nvlinkLinkClockMhz;

        public uint _bitfield;

        /// <include file='NVLINK_LINK_STATUS_INFO_V1.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V1.connected"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint connected
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

        /// <include file='NVLINK_LINK_STATUS_INFO_V1.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V1.reserved"]/*' />
        [NativeTypeName("NvU32 : 31")]
        public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x7FFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x7FFFFFFFu << 1)) | ((value & 0x7FFFFFFFu) << 1);
            }
        }

        /// <include file='NVLINK_LINK_STATUS_INFO_V1.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V1.loopProperty"]/*' />
        [NativeTypeName("NvU8")]
        public byte loopProperty;

        /// <include file='NVLINK_LINK_STATUS_INFO_V1.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V1.remoteDeviceLinkNumber"]/*' />
        [NativeTypeName("NvU8")]
        public byte remoteDeviceLinkNumber;

        /// <include file='NVLINK_LINK_STATUS_INFO_V1.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V1.remoteDeviceInfo"]/*' />
        public NVLINK_DEVICE_INFO_V1 remoteDeviceInfo;
    }
}
