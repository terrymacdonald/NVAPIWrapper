namespace NVAPIWrapper
{
    /// <include file='_NV_HDMI_SUPPORT_INFO_V1.xml' path='doc/member[@name="_NV_HDMI_SUPPORT_INFO_V1"]/*' />
    public partial struct _NV_HDMI_SUPPORT_INFO_V1
    {
        /// <include file='_NV_HDMI_SUPPORT_INFO_V1.xml' path='doc/member[@name="_NV_HDMI_SUPPORT_INFO_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        public uint _bitfield;

        /// <include file='_NV_HDMI_SUPPORT_INFO_V1.xml' path='doc/member[@name="_NV_HDMI_SUPPORT_INFO_V1.isGpuHDMICapable"]/*' />
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

        /// <include file='_NV_HDMI_SUPPORT_INFO_V1.xml' path='doc/member[@name="_NV_HDMI_SUPPORT_INFO_V1.isMonUnderscanCapable"]/*' />
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

        /// <include file='_NV_HDMI_SUPPORT_INFO_V1.xml' path='doc/member[@name="_NV_HDMI_SUPPORT_INFO_V1.isMonBasicAudioCapable"]/*' />
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

        /// <include file='_NV_HDMI_SUPPORT_INFO_V1.xml' path='doc/member[@name="_NV_HDMI_SUPPORT_INFO_V1.isMonYCbCr444Capable"]/*' />
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

        /// <include file='_NV_HDMI_SUPPORT_INFO_V1.xml' path='doc/member[@name="_NV_HDMI_SUPPORT_INFO_V1.isMonYCbCr422Capable"]/*' />
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

        /// <include file='_NV_HDMI_SUPPORT_INFO_V1.xml' path='doc/member[@name="_NV_HDMI_SUPPORT_INFO_V1.isMonxvYCC601Capable"]/*' />
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

        /// <include file='_NV_HDMI_SUPPORT_INFO_V1.xml' path='doc/member[@name="_NV_HDMI_SUPPORT_INFO_V1.isMonxvYCC709Capable"]/*' />
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

        /// <include file='_NV_HDMI_SUPPORT_INFO_V1.xml' path='doc/member[@name="_NV_HDMI_SUPPORT_INFO_V1.isMonHDMI"]/*' />
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

        /// <include file='_NV_HDMI_SUPPORT_INFO_V1.xml' path='doc/member[@name="_NV_HDMI_SUPPORT_INFO_V1.reserved"]/*' />
        [NativeTypeName("NvU32 : 24")]
        public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 8) & 0xFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0xFFFFFFu << 8)) | ((value & 0xFFFFFFu) << 8);
            }
        }

        /// <include file='_NV_HDMI_SUPPORT_INFO_V1.xml' path='doc/member[@name="_NV_HDMI_SUPPORT_INFO_V1.EDID861ExtRev"]/*' />
        [NativeTypeName("NvU32")]
        public uint EDID861ExtRev;
    }
}
