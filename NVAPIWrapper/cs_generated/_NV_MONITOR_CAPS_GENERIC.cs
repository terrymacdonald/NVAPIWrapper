namespace NVAPIWrapper
{
    /// <include file='_NV_MONITOR_CAPS_GENERIC.xml' path='doc/member[@name="_NV_MONITOR_CAPS_GENERIC"]/*' />
    public partial struct _NV_MONITOR_CAPS_GENERIC
    {
        public byte _bitfield;

        /// <include file='_NV_MONITOR_CAPS_GENERIC.xml' path='doc/member[@name="_NV_MONITOR_CAPS_GENERIC.supportVRR"]/*' />
        [NativeTypeName("NvU8 : 1")]
        public byte supportVRR
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

        /// <include file='_NV_MONITOR_CAPS_GENERIC.xml' path='doc/member[@name="_NV_MONITOR_CAPS_GENERIC.supportULMB"]/*' />
        [NativeTypeName("NvU8 : 1")]
        public byte supportULMB
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

        /// <include file='_NV_MONITOR_CAPS_GENERIC.xml' path='doc/member[@name="_NV_MONITOR_CAPS_GENERIC.isTrueGsync"]/*' />
        [NativeTypeName("NvU8 : 1")]
        public byte isTrueGsync
        {
            readonly get
            {
                return (byte)((_bitfield >> 2) & 0x1u);
            }

            set
            {
                _bitfield = (byte)((_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_GENERIC.xml' path='doc/member[@name="_NV_MONITOR_CAPS_GENERIC.isRLACapable"]/*' />
        [NativeTypeName("NvU8 : 1")]
        public byte isRLACapable
        {
            readonly get
            {
                return (byte)((_bitfield >> 3) & 0x1u);
            }

            set
            {
                _bitfield = (byte)((_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_GENERIC.xml' path='doc/member[@name="_NV_MONITOR_CAPS_GENERIC.currentlyCapableOfVRR"]/*' />
        [NativeTypeName("NvU8 : 1")]
        public byte currentlyCapableOfVRR
        {
            readonly get
            {
                return (byte)((_bitfield >> 4) & 0x1u);
            }

            set
            {
                _bitfield = (byte)((_bitfield & ~(0x1u << 4)) | ((value & 0x1u) << 4));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_GENERIC.xml' path='doc/member[@name="_NV_MONITOR_CAPS_GENERIC.isBasicVRR"]/*' />
        [NativeTypeName("NvU8 : 1")]
        public byte isBasicVRR
        {
            readonly get
            {
                return (byte)((_bitfield >> 5) & 0x1u);
            }

            set
            {
                _bitfield = (byte)((_bitfield & ~(0x1u << 5)) | ((value & 0x1u) << 5));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_GENERIC.xml' path='doc/member[@name="_NV_MONITOR_CAPS_GENERIC.reserved"]/*' />
        [NativeTypeName("NvU8 : 2")]
        public byte reserved
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
