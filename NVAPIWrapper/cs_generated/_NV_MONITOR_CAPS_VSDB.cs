using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB"]/*' />
    public partial struct _NV_MONITOR_CAPS_VSDB
    {
        public byte _bitfield1;

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.sourcePhysicalAddressB"]/*' />
        [NativeTypeName("NvU8 : 4")]
        public byte sourcePhysicalAddressB
        {
            readonly get
            {
                return (byte)(_bitfield1 & 0xFu);
            }

            set
            {
                _bitfield1 = (byte)((_bitfield1 & ~0xFu) | (value & 0xFu));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.sourcePhysicalAddressA"]/*' />
        [NativeTypeName("NvU8 : 4")]
        public byte sourcePhysicalAddressA
        {
            readonly get
            {
                return (byte)((_bitfield1 >> 4) & 0xFu);
            }

            set
            {
                _bitfield1 = (byte)((_bitfield1 & ~(0xFu << 4)) | ((value & 0xFu) << 4));
            }
        }

        public byte _bitfield2;

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.sourcePhysicalAddressD"]/*' />
        [NativeTypeName("NvU8 : 4")]
        public byte sourcePhysicalAddressD
        {
            readonly get
            {
                return (byte)(_bitfield2 & 0xFu);
            }

            set
            {
                _bitfield2 = (byte)((_bitfield2 & ~0xFu) | (value & 0xFu));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.sourcePhysicalAddressC"]/*' />
        [NativeTypeName("NvU8 : 4")]
        public byte sourcePhysicalAddressC
        {
            readonly get
            {
                return (byte)((_bitfield2 >> 4) & 0xFu);
            }

            set
            {
                _bitfield2 = (byte)((_bitfield2 & ~(0xFu << 4)) | ((value & 0xFu) << 4));
            }
        }

        public byte _bitfield3;

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.supportDualDviOperation"]/*' />
        [NativeTypeName("NvU8 : 1")]
        public byte supportDualDviOperation
        {
            readonly get
            {
                return (byte)(_bitfield3 & 0x1u);
            }

            set
            {
                _bitfield3 = (byte)((_bitfield3 & ~0x1u) | (value & 0x1u));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.reserved6"]/*' />
        [NativeTypeName("NvU8 : 2")]
        public byte reserved6
        {
            readonly get
            {
                return (byte)((_bitfield3 >> 1) & 0x3u);
            }

            set
            {
                _bitfield3 = (byte)((_bitfield3 & ~(0x3u << 1)) | ((value & 0x3u) << 1));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.supportDeepColorYCbCr444"]/*' />
        [NativeTypeName("NvU8 : 1")]
        public byte supportDeepColorYCbCr444
        {
            readonly get
            {
                return (byte)((_bitfield3 >> 3) & 0x1u);
            }

            set
            {
                _bitfield3 = (byte)((_bitfield3 & ~(0x1u << 3)) | ((value & 0x1u) << 3));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.supportDeepColor30bits"]/*' />
        [NativeTypeName("NvU8 : 1")]
        public byte supportDeepColor30bits
        {
            readonly get
            {
                return (byte)((_bitfield3 >> 4) & 0x1u);
            }

            set
            {
                _bitfield3 = (byte)((_bitfield3 & ~(0x1u << 4)) | ((value & 0x1u) << 4));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.supportDeepColor36bits"]/*' />
        [NativeTypeName("NvU8 : 1")]
        public byte supportDeepColor36bits
        {
            readonly get
            {
                return (byte)((_bitfield3 >> 5) & 0x1u);
            }

            set
            {
                _bitfield3 = (byte)((_bitfield3 & ~(0x1u << 5)) | ((value & 0x1u) << 5));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.supportDeepColor48bits"]/*' />
        [NativeTypeName("NvU8 : 1")]
        public byte supportDeepColor48bits
        {
            readonly get
            {
                return (byte)((_bitfield3 >> 6) & 0x1u);
            }

            set
            {
                _bitfield3 = (byte)((_bitfield3 & ~(0x1u << 6)) | ((value & 0x1u) << 6));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.supportAI"]/*' />
        [NativeTypeName("NvU8 : 1")]
        public byte supportAI
        {
            readonly get
            {
                return (byte)((_bitfield3 >> 7) & 0x1u);
            }

            set
            {
                _bitfield3 = (byte)((_bitfield3 & ~(0x1u << 7)) | ((value & 0x1u) << 7));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.maxTmdsClock"]/*' />
        [NativeTypeName("NvU8")]
        public byte maxTmdsClock;

        public byte _bitfield4;

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.cnc0SupportGraphicsTextContent"]/*' />
        [NativeTypeName("NvU8 : 1")]
        public byte cnc0SupportGraphicsTextContent
        {
            readonly get
            {
                return (byte)(_bitfield4 & 0x1u);
            }

            set
            {
                _bitfield4 = (byte)((_bitfield4 & ~0x1u) | (value & 0x1u));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.cnc1SupportPhotoContent"]/*' />
        [NativeTypeName("NvU8 : 1")]
        public byte cnc1SupportPhotoContent
        {
            readonly get
            {
                return (byte)((_bitfield4 >> 1) & 0x1u);
            }

            set
            {
                _bitfield4 = (byte)((_bitfield4 & ~(0x1u << 1)) | ((value & 0x1u) << 1));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.cnc2SupportCinemaContent"]/*' />
        [NativeTypeName("NvU8 : 1")]
        public byte cnc2SupportCinemaContent
        {
            readonly get
            {
                return (byte)((_bitfield4 >> 2) & 0x1u);
            }

            set
            {
                _bitfield4 = (byte)((_bitfield4 & ~(0x1u << 2)) | ((value & 0x1u) << 2));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.cnc3SupportGameContent"]/*' />
        [NativeTypeName("NvU8 : 1")]
        public byte cnc3SupportGameContent
        {
            readonly get
            {
                return (byte)((_bitfield4 >> 3) & 0x1u);
            }

            set
            {
                _bitfield4 = (byte)((_bitfield4 & ~(0x1u << 3)) | ((value & 0x1u) << 3));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.reserved8"]/*' />
        [NativeTypeName("NvU8 : 1")]
        public byte reserved8
        {
            readonly get
            {
                return (byte)((_bitfield4 >> 4) & 0x1u);
            }

            set
            {
                _bitfield4 = (byte)((_bitfield4 & ~(0x1u << 4)) | ((value & 0x1u) << 4));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.hasVicEntries"]/*' />
        [NativeTypeName("NvU8 : 1")]
        public byte hasVicEntries
        {
            readonly get
            {
                return (byte)((_bitfield4 >> 5) & 0x1u);
            }

            set
            {
                _bitfield4 = (byte)((_bitfield4 & ~(0x1u << 5)) | ((value & 0x1u) << 5));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.hasInterlacedLatencyField"]/*' />
        [NativeTypeName("NvU8 : 1")]
        public byte hasInterlacedLatencyField
        {
            readonly get
            {
                return (byte)((_bitfield4 >> 6) & 0x1u);
            }

            set
            {
                _bitfield4 = (byte)((_bitfield4 & ~(0x1u << 6)) | ((value & 0x1u) << 6));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.hasLatencyField"]/*' />
        [NativeTypeName("NvU8 : 1")]
        public byte hasLatencyField
        {
            readonly get
            {
                return (byte)((_bitfield4 >> 7) & 0x1u);
            }

            set
            {
                _bitfield4 = (byte)((_bitfield4 & ~(0x1u << 7)) | ((value & 0x1u) << 7));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.videoLatency"]/*' />
        [NativeTypeName("NvU8")]
        public byte videoLatency;

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.audioLatency"]/*' />
        [NativeTypeName("NvU8")]
        public byte audioLatency;

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.interlacedVideoLatency"]/*' />
        [NativeTypeName("NvU8")]
        public byte interlacedVideoLatency;

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.interlacedAudioLatency"]/*' />
        [NativeTypeName("NvU8")]
        public byte interlacedAudioLatency;

        public byte _bitfield5;

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.reserved13"]/*' />
        [NativeTypeName("NvU8 : 7")]
        public byte reserved13
        {
            readonly get
            {
                return (byte)(_bitfield5 & 0x7Fu);
            }

            set
            {
                _bitfield5 = (byte)((_bitfield5 & ~0x7Fu) | (value & 0x7Fu));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.has3dEntries"]/*' />
        [NativeTypeName("NvU8 : 1")]
        public byte has3dEntries
        {
            readonly get
            {
                return (byte)((_bitfield5 >> 7) & 0x1u);
            }

            set
            {
                _bitfield5 = (byte)((_bitfield5 & ~(0x1u << 7)) | ((value & 0x1u) << 7));
            }
        }

        public byte _bitfield6;

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.hdmi3dLength"]/*' />
        [NativeTypeName("NvU8 : 5")]
        public byte hdmi3dLength
        {
            readonly get
            {
                return (byte)(_bitfield6 & 0x1Fu);
            }

            set
            {
                _bitfield6 = (byte)((_bitfield6 & ~0x1Fu) | (value & 0x1Fu));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.hdmiVicLength"]/*' />
        [NativeTypeName("NvU8 : 3")]
        public byte hdmiVicLength
        {
            readonly get
            {
                return (byte)((_bitfield6 >> 5) & 0x7u);
            }

            set
            {
                _bitfield6 = (byte)((_bitfield6 & ~(0x7u << 5)) | ((value & 0x7u) << 5));
            }
        }

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.hdmi_vic"]/*' />
        [NativeTypeName("NvU8[7]")]
        public _hdmi_vic_e__FixedBuffer hdmi_vic;

        /// <include file='_NV_MONITOR_CAPS_VSDB.xml' path='doc/member[@name="_NV_MONITOR_CAPS_VSDB.hdmi_3d"]/*' />
        [NativeTypeName("NvU8[31]")]
        public _hdmi_3d_e__FixedBuffer hdmi_3d;

        /// <include file='_hdmi_vic_e__FixedBuffer.xml' path='doc/member[@name="_hdmi_vic_e__FixedBuffer"]/*' />
        [InlineArray(7)]
        public partial struct _hdmi_vic_e__FixedBuffer
        {
            public byte e0;
        }

        /// <include file='_hdmi_3d_e__FixedBuffer.xml' path='doc/member[@name="_hdmi_3d_e__FixedBuffer"]/*' />
        [InlineArray(31)]
        public partial struct _hdmi_3d_e__FixedBuffer
        {
            public byte e0;
        }
    }
}
