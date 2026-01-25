namespace NVAPIWrapper
{
    /// <include file='_NV_HDMI_SUPPORT_INFO_V2.xml' path='doc/member[@name="_NV_HDMI_SUPPORT_INFO_V2"]/*' />
    public partial struct _NV_HDMI_SUPPORT_INFO_V2
    {
        /// <include file='_NV_HDMI_SUPPORT_INFO_V2.xml' path='doc/member[@name="_NV_HDMI_SUPPORT_INFO_V2.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        public uint _bitfield;

        /// <include file='_NV_HDMI_SUPPORT_INFO_V2.xml' path='doc/member[@name="_NV_HDMI_SUPPORT_INFO_V2.isGpuHDMICapable"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isGpuHDMICapable
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

        /// <include file='_NV_HDMI_SUPPORT_INFO_V2.xml' path='doc/member[@name="_NV_HDMI_SUPPORT_INFO_V2.isMonUnderscanCapable"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isMonUnderscanCapable
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

        /// <include file='_NV_HDMI_SUPPORT_INFO_V2.xml' path='doc/member[@name="_NV_HDMI_SUPPORT_INFO_V2.isMonBasicAudioCapable"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isMonBasicAudioCapable
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

        /// <include file='_NV_HDMI_SUPPORT_INFO_V2.xml' path='doc/member[@name="_NV_HDMI_SUPPORT_INFO_V2.isMonYCbCr444Capable"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isMonYCbCr444Capable
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

        /// <include file='_NV_HDMI_SUPPORT_INFO_V2.xml' path='doc/member[@name="_NV_HDMI_SUPPORT_INFO_V2.isMonYCbCr422Capable"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isMonYCbCr422Capable
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

        /// <include file='_NV_HDMI_SUPPORT_INFO_V2.xml' path='doc/member[@name="_NV_HDMI_SUPPORT_INFO_V2.isMonxvYCC601Capable"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isMonxvYCC601Capable
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

        /// <include file='_NV_HDMI_SUPPORT_INFO_V2.xml' path='doc/member[@name="_NV_HDMI_SUPPORT_INFO_V2.isMonxvYCC709Capable"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isMonxvYCC709Capable
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

        /// <include file='_NV_HDMI_SUPPORT_INFO_V2.xml' path='doc/member[@name="_NV_HDMI_SUPPORT_INFO_V2.isMonHDMI"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isMonHDMI
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

        /// <include file='_NV_HDMI_SUPPORT_INFO_V2.xml' path='doc/member[@name="_NV_HDMI_SUPPORT_INFO_V2.isMonsYCC601Capable"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isMonsYCC601Capable
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

        /// <include file='_NV_HDMI_SUPPORT_INFO_V2.xml' path='doc/member[@name="_NV_HDMI_SUPPORT_INFO_V2.isMonAdobeYCC601Capable"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isMonAdobeYCC601Capable
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

        /// <include file='_NV_HDMI_SUPPORT_INFO_V2.xml' path='doc/member[@name="_NV_HDMI_SUPPORT_INFO_V2.isMonAdobeRGBCapable"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isMonAdobeRGBCapable
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

        /// <include file='_NV_HDMI_SUPPORT_INFO_V2.xml' path='doc/member[@name="_NV_HDMI_SUPPORT_INFO_V2.reserved"]/*' />
        [NativeTypeName("NvU32 : 21")]
        public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 11) & 0x1FFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1FFFFFu << 11)) | ((value & 0x1FFFFFu) << 11);
            }
        }

        /// <include file='_NV_HDMI_SUPPORT_INFO_V2.xml' path='doc/member[@name="_NV_HDMI_SUPPORT_INFO_V2.EDID861ExtRev"]/*' />
        [NativeTypeName("NvU32")]
        public uint EDID861ExtRev;
    }
}
