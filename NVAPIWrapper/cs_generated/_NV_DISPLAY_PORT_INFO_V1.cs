namespace NVAPIWrapper
{
    /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1"]/*' />
    public partial struct _NV_DISPLAY_PORT_INFO_V1
    {
        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.dpcd_ver"]/*' />
        [NativeTypeName("NvU32")]
        public uint dpcd_ver;

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.maxLinkRate"]/*' />
        [NativeTypeName("NV_DP_LINK_RATE")]
        public _NV_DP_LINK_RATE maxLinkRate;

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.maxLaneCount"]/*' />
        [NativeTypeName("NV_DP_LANE_COUNT")]
        public _NV_DP_LANE_COUNT maxLaneCount;

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.curLinkRate"]/*' />
        [NativeTypeName("NV_DP_LINK_RATE")]
        public _NV_DP_LINK_RATE curLinkRate;

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.curLaneCount"]/*' />
        [NativeTypeName("NV_DP_LANE_COUNT")]
        public _NV_DP_LANE_COUNT curLaneCount;

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.colorFormat"]/*' />
        [NativeTypeName("NV_DP_COLOR_FORMAT")]
        public _NV_DP_COLOR_FORMAT colorFormat;

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.dynamicRange"]/*' />
        [NativeTypeName("NV_DP_DYNAMIC_RANGE")]
        public _NV_DP_DYNAMIC_RANGE dynamicRange;

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.colorimetry"]/*' />
        [NativeTypeName("NV_DP_COLORIMETRY")]
        public _NV_DP_COLORIMETRY colorimetry;

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.bpc"]/*' />
        [NativeTypeName("NV_DP_BPC")]
        public _NV_DP_BPC bpc;

        public uint _bitfield;

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.isDp"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isDp
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

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.isInternalDp"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isInternalDp
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.isColorCtrlSupported"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isColorCtrlSupported
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.is6BPCSupported"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint is6BPCSupported
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
            }
        }

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.is8BPCSupported"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint is8BPCSupported
        {
            readonly get
            {
                return (_bitfield >> 4) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 4)) | ((value & 0x1u) << 4);
            }
        }

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.is10BPCSupported"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint is10BPCSupported
        {
            readonly get
            {
                return (_bitfield >> 5) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 5)) | ((value & 0x1u) << 5);
            }
        }

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.is12BPCSupported"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint is12BPCSupported
        {
            readonly get
            {
                return (_bitfield >> 6) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 6)) | ((value & 0x1u) << 6);
            }
        }

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.is16BPCSupported"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint is16BPCSupported
        {
            readonly get
            {
                return (_bitfield >> 7) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 7)) | ((value & 0x1u) << 7);
            }
        }

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.isYCrCb420Supported"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isYCrCb420Supported
        {
            readonly get
            {
                return (_bitfield >> 8) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 8)) | ((value & 0x1u) << 8);
            }
        }

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.isYCrCb422Supported"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isYCrCb422Supported
        {
            readonly get
            {
                return (_bitfield >> 9) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 9)) | ((value & 0x1u) << 9);
            }
        }

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.isYCrCb444Supported"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isYCrCb444Supported
        {
            readonly get
            {
                return (_bitfield >> 10) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 10)) | ((value & 0x1u) << 10);
            }
        }

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.isRgb444SupportedOnCurrentMode"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isRgb444SupportedOnCurrentMode
        {
            readonly get
            {
                return (_bitfield >> 11) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 11)) | ((value & 0x1u) << 11);
            }
        }

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.isYCbCr444SupportedOnCurrentMode"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isYCbCr444SupportedOnCurrentMode
        {
            readonly get
            {
                return (_bitfield >> 12) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 12)) | ((value & 0x1u) << 12);
            }
        }

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.isYCbCr422SupportedOnCurrentMode"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isYCbCr422SupportedOnCurrentMode
        {
            readonly get
            {
                return (_bitfield >> 13) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 13)) | ((value & 0x1u) << 13);
            }
        }

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.isYCbCr420SupportedOnCurrentMode"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isYCbCr420SupportedOnCurrentMode
        {
            readonly get
            {
                return (_bitfield >> 14) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 14)) | ((value & 0x1u) << 14);
            }
        }

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.is6BPCSupportedOnCurrentMode"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint is6BPCSupportedOnCurrentMode
        {
            readonly get
            {
                return (_bitfield >> 15) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 15)) | ((value & 0x1u) << 15);
            }
        }

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.is8BPCSupportedOnCurrentMode"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint is8BPCSupportedOnCurrentMode
        {
            readonly get
            {
                return (_bitfield >> 16) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 16)) | ((value & 0x1u) << 16);
            }
        }

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.is10BPCSupportedOnCurrentMode"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint is10BPCSupportedOnCurrentMode
        {
            readonly get
            {
                return (_bitfield >> 17) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 17)) | ((value & 0x1u) << 17);
            }
        }

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.is12BPCSupportedOnCurrentMode"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint is12BPCSupportedOnCurrentMode
        {
            readonly get
            {
                return (_bitfield >> 18) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 18)) | ((value & 0x1u) << 18);
            }
        }

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.is16BPCSupportedOnCurrentMode"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint is16BPCSupportedOnCurrentMode
        {
            readonly get
            {
                return (_bitfield >> 19) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 19)) | ((value & 0x1u) << 19);
            }
        }

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.isMonxvYCC601Capable"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isMonxvYCC601Capable
        {
            readonly get
            {
                return (_bitfield >> 20) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 20)) | ((value & 0x1u) << 20);
            }
        }

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.isMonxvYCC709Capable"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isMonxvYCC709Capable
        {
            readonly get
            {
                return (_bitfield >> 21) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 21)) | ((value & 0x1u) << 21);
            }
        }

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.isMonsYCC601Capable"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isMonsYCC601Capable
        {
            readonly get
            {
                return (_bitfield >> 22) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 22)) | ((value & 0x1u) << 22);
            }
        }

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.isMonAdobeYCC601Capable"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isMonAdobeYCC601Capable
        {
            readonly get
            {
                return (_bitfield >> 23) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 23)) | ((value & 0x1u) << 23);
            }
        }

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.isMonAdobeRGBCapable"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isMonAdobeRGBCapable
        {
            readonly get
            {
                return (_bitfield >> 24) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 24)) | ((value & 0x1u) << 24);
            }
        }

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.isMonBT2020RGBCapable"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isMonBT2020RGBCapable
        {
            readonly get
            {
                return (_bitfield >> 25) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 25)) | ((value & 0x1u) << 25);
            }
        }

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.isMonBT2020YCCCapable"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isMonBT2020YCCCapable
        {
            readonly get
            {
                return (_bitfield >> 26) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 26)) | ((value & 0x1u) << 26);
            }
        }

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.isMonBT2020cYCCCapable"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isMonBT2020cYCCCapable
        {
            readonly get
            {
                return (_bitfield >> 27) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 27)) | ((value & 0x1u) << 27);
            }
        }

        /// <include file='_NV_DISPLAY_PORT_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAY_PORT_INFO_V1.reserved"]/*' />
        [NativeTypeName("NvU32 : 4")]
        public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 28) & 0xFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0xFu << 28)) | ((value & 0xFu) << 28);
            }
        }
    }
}
