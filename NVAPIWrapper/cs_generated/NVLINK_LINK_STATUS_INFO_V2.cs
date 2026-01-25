using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NVLINK_LINK_STATUS_INFO_V2.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V2"]/*' />
    public partial struct NVLINK_LINK_STATUS_INFO_V2
    {
        /// <include file='NVLINK_LINK_STATUS_INFO_V2.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V2.capsTbl"]/*' />
        [NativeTypeName("NvU32")]
        public uint capsTbl;

        /// <include file='NVLINK_LINK_STATUS_INFO_V2.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V2.phyType"]/*' />
        [NativeTypeName("NvU8")]
        public byte phyType;

        /// <include file='NVLINK_LINK_STATUS_INFO_V2.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V2.subLinkWidth"]/*' />
        [NativeTypeName("NvU8")]
        public byte subLinkWidth;

        /// <include file='NVLINK_LINK_STATUS_INFO_V2.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V2.linkState"]/*' />
        [NativeTypeName("NvU32")]
        public uint linkState;

        /// <include file='NVLINK_LINK_STATUS_INFO_V2.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V2.rxSublinkStatus"]/*' />
        [NativeTypeName("NvU8")]
        public byte rxSublinkStatus;

        /// <include file='NVLINK_LINK_STATUS_INFO_V2.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V2.txSublinkStatus"]/*' />
        [NativeTypeName("NvU8")]
        public byte txSublinkStatus;

        /// <include file='NVLINK_LINK_STATUS_INFO_V2.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V2.nvlinkVersion"]/*' />
        [NativeTypeName("NvU8")]
        public byte nvlinkVersion;

        /// <include file='NVLINK_LINK_STATUS_INFO_V2.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V2.nciVersion"]/*' />
        [NativeTypeName("NvU8")]
        public byte nciVersion;

        /// <include file='NVLINK_LINK_STATUS_INFO_V2.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V2.phyVersion"]/*' />
        [NativeTypeName("NvU8")]
        public byte phyVersion;

        /// <include file='NVLINK_LINK_STATUS_INFO_V2.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V2.nvlinkCommonClockSpeedMhz"]/*' />
        [NativeTypeName("NvU32")]
        public uint nvlinkCommonClockSpeedMhz;

        /// <include file='NVLINK_LINK_STATUS_INFO_V2.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V2.nvlinkRefClkSpeedMhz"]/*' />
        [NativeTypeName("NvU32")]
        public uint nvlinkRefClkSpeedMhz;

        /// <include file='NVLINK_LINK_STATUS_INFO_V2.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V2.nvlinkRefClkType"]/*' />
        [NativeTypeName("NvU8")]
        public byte nvlinkRefClkType;

        /// <include file='NVLINK_LINK_STATUS_INFO_V2.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V2.nvlinkLinkClockMhz"]/*' />
        [NativeTypeName("NvU32")]
        public uint nvlinkLinkClockMhz;

        public uint _bitfield;

        /// <include file='NVLINK_LINK_STATUS_INFO_V2.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V2.connected"]/*' />
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

        /// <include file='NVLINK_LINK_STATUS_INFO_V2.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V2.reserved"]/*' />
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

        /// <include file='NVLINK_LINK_STATUS_INFO_V2.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V2.loopProperty"]/*' />
        [NativeTypeName("NvU8")]
        public byte loopProperty;

        /// <include file='NVLINK_LINK_STATUS_INFO_V2.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V2.remoteDeviceLinkNumber"]/*' />
        [NativeTypeName("NvU8")]
        public byte remoteDeviceLinkNumber;

        /// <include file='NVLINK_LINK_STATUS_INFO_V2.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V2.remoteDeviceInfo"]/*' />
        public NVLINK_DEVICE_INFO_V1 remoteDeviceInfo;

        /// <include file='NVLINK_LINK_STATUS_INFO_V2.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V2.localDeviceLinkNumber"]/*' />
        [NativeTypeName("NvU8")]
        public byte localDeviceLinkNumber;

        /// <include file='NVLINK_LINK_STATUS_INFO_V2.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V2.localDeviceInfo"]/*' />
        public NVLINK_DEVICE_INFO_V1 localDeviceInfo;

        /// <include file='NVLINK_LINK_STATUS_INFO_V2.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V2.nvlinkLineRateMbps"]/*' />
        [NativeTypeName("NvU32")]
        public uint nvlinkLineRateMbps;

        /// <include file='NVLINK_LINK_STATUS_INFO_V2.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V2.nvlinkMinL1Threshold"]/*' />
        [NativeTypeName("NvU32")]
        public uint nvlinkMinL1Threshold;

        /// <include file='NVLINK_LINK_STATUS_INFO_V2.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V2.nvlinkMaxL1Threshold"]/*' />
        [NativeTypeName("NvU32")]
        public uint nvlinkMaxL1Threshold;

        /// <include file='NVLINK_LINK_STATUS_INFO_V2.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V2.nvlinkL1ThresholdUnits"]/*' />
        [NativeTypeName("NvU32")]
        public uint nvlinkL1ThresholdUnits;

        /// <include file='NVLINK_LINK_STATUS_INFO_V2.xml' path='doc/member[@name="NVLINK_LINK_STATUS_INFO_V2.reservedEx"]/*' />
        [NativeTypeName("NvU32[5]")]
        public _reservedEx_e__FixedBuffer reservedEx;

        /// <include file='_reservedEx_e__FixedBuffer.xml' path='doc/member[@name="_reservedEx_e__FixedBuffer"]/*' />
        [InlineArray(5)]
        public partial struct _reservedEx_e__FixedBuffer
        {
            public uint e0;
        }
    }
}
