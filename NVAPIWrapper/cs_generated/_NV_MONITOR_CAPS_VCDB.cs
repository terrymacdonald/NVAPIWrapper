namespace NVAPIWrapper
{
    /// <include file='_NV_MONITOR_CAPS_VCDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VCDB"]/*' />
    public partial struct _NV_MONITOR_CAPS_VCDB
    {
        public byte _bitfield;

        /// <include file='_NV_MONITOR_CAPS_VCDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VCDB.quantizationRangeYcc"]/*' />
        [NativeTypeName("NvU8 : 1")]
        public byte quantizationRangeYcc
        {
            readonly get
            {
                return (byte)(_bitfield & 0x1u);
            }

            set
            {
                _bitfield = (byte)((_bitfield & ~0x1u) | (value & 0x1u));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_VCDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VCDB.quantizationRangeRgb"]/*' />
        [NativeTypeName("NvU8 : 1")]
        public byte quantizationRangeRgb
        {
            readonly get
            {
                return (byte)((_bitfield >> 1) & 0x1u);
            }

            set
            {
                _bitfield = (byte)((_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_VCDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VCDB.scanInfoPreferredVideoFormat"]/*' />
        [NativeTypeName("NvU8 : 2")]
        public byte scanInfoPreferredVideoFormat
        {
            readonly get
            {
                return (byte)((_bitfield >> 2) & 0x3u);
            }

            set
            {
                _bitfield = (byte)((_bitfield & ~(0x3u << 2)) | ((value & 0x3u) << 2));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_VCDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VCDB.scanInfoITVideoFormats"]/*' />
        [NativeTypeName("NvU8 : 2")]
        public byte scanInfoITVideoFormats
        {
            readonly get
            {
                return (byte)((_bitfield >> 4) & 0x3u);
            }

            set
            {
                _bitfield = (byte)((_bitfield & ~(0x3u << 4)) | ((value & 0x3u) << 4));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_VCDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VCDB.scanInfoCEVideoFormats"]/*' />
        [NativeTypeName("NvU8 : 2")]
        public byte scanInfoCEVideoFormats
        {
            readonly get
            {
                return (byte)((_bitfield >> 6) & 0x3u);
            }

            set
            {
                _bitfield = (byte)((_bitfield & ~(0x3u << 6)) | ((value & 0x3u) << 6));
            }
        }
    }
}
