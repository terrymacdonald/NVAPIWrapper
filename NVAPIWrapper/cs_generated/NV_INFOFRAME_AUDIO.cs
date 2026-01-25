namespace NVAPIWrapper
{
    /// <include file='NV_INFOFRAME_AUDIO.xml' path='doc/member[@name="NV_INFOFRAME_AUDIO"]/*' />
    public partial struct NV_INFOFRAME_AUDIO
    {
        public uint _bitfield1;

        /// <include file='NV_INFOFRAME_AUDIO.xml' path='doc/member[@name="NV_INFOFRAME_AUDIO.codingType"]/*' />
        [NativeTypeName("NvU32 : 5")]
        public uint codingType
        {
            readonly get
            {
                return _bitfield1 & 0x1Fu;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~0x1Fu) | (value & 0x1Fu);
            }
        }

        /// <include file='NV_INFOFRAME_AUDIO.xml' path='doc/member[@name="NV_INFOFRAME_AUDIO.codingExtensionType"]/*' />
        [NativeTypeName("NvU32 : 6")]
        public uint codingExtensionType
        {
            readonly get
            {
                return (_bitfield1 >> 5) & 0x3Fu;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~(0x3Fu << 5)) | ((value & 0x3Fu) << 5);
            }
        }

        /// <include file='NV_INFOFRAME_AUDIO.xml' path='doc/member[@name="NV_INFOFRAME_AUDIO.sampleSize"]/*' />
        [NativeTypeName("NvU32 : 3")]
        public uint sampleSize
        {
            readonly get
            {
                return (_bitfield1 >> 11) & 0x7u;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~(0x7u << 11)) | ((value & 0x7u) << 11);
            }
        }

        /// <include file='NV_INFOFRAME_AUDIO.xml' path='doc/member[@name="NV_INFOFRAME_AUDIO.sampleRate"]/*' />
        [NativeTypeName("NvU32 : 4")]
        public uint sampleRate
        {
            readonly get
            {
                return (_bitfield1 >> 14) & 0xFu;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~(0xFu << 14)) | ((value & 0xFu) << 14);
            }
        }

        /// <include file='NV_INFOFRAME_AUDIO.xml' path='doc/member[@name="NV_INFOFRAME_AUDIO.channelCount"]/*' />
        [NativeTypeName("NvU32 : 4")]
        public uint channelCount
        {
            readonly get
            {
                return (_bitfield1 >> 18) & 0xFu;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~(0xFu << 18)) | ((value & 0xFu) << 18);
            }
        }

        /// <include file='NV_INFOFRAME_AUDIO.xml' path='doc/member[@name="NV_INFOFRAME_AUDIO.speakerPlacement"]/*' />
        [NativeTypeName("NvU32 : 9")]
        public uint speakerPlacement
        {
            readonly get
            {
                return (_bitfield1 >> 22) & 0x1FFu;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~(0x1FFu << 22)) | ((value & 0x1FFu) << 22);
            }
        }

        public uint _bitfield2;

        /// <include file='NV_INFOFRAME_AUDIO.xml' path='doc/member[@name="NV_INFOFRAME_AUDIO.downmixInhibit"]/*' />
        [NativeTypeName("NvU32 : 2")]
        public uint downmixInhibit
        {
            readonly get
            {
                return _bitfield2 & 0x3u;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~0x3u) | (value & 0x3u);
            }
        }

        /// <include file='NV_INFOFRAME_AUDIO.xml' path='doc/member[@name="NV_INFOFRAME_AUDIO.lfePlaybackLevel"]/*' />
        [NativeTypeName("NvU32 : 3")]
        public uint lfePlaybackLevel
        {
            readonly get
            {
                return (_bitfield2 >> 2) & 0x7u;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~(0x7u << 2)) | ((value & 0x7u) << 2);
            }
        }

        /// <include file='NV_INFOFRAME_AUDIO.xml' path='doc/member[@name="NV_INFOFRAME_AUDIO.levelShift"]/*' />
        [NativeTypeName("NvU32 : 5")]
        public uint levelShift
        {
            readonly get
            {
                return (_bitfield2 >> 5) & 0x1Fu;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~(0x1Fu << 5)) | ((value & 0x1Fu) << 5);
            }
        }

        /// <include file='NV_INFOFRAME_AUDIO.xml' path='doc/member[@name="NV_INFOFRAME_AUDIO.Future12"]/*' />
        [NativeTypeName("NvU32 : 2")]
        public uint Future12
        {
            readonly get
            {
                return (_bitfield2 >> 10) & 0x3u;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~(0x3u << 10)) | ((value & 0x3u) << 10);
            }
        }

        /// <include file='NV_INFOFRAME_AUDIO.xml' path='doc/member[@name="NV_INFOFRAME_AUDIO.Future2x"]/*' />
        [NativeTypeName("NvU32 : 4")]
        public uint Future2x
        {
            readonly get
            {
                return (_bitfield2 >> 12) & 0xFu;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~(0xFu << 12)) | ((value & 0xFu) << 12);
            }
        }

        /// <include file='NV_INFOFRAME_AUDIO.xml' path='doc/member[@name="NV_INFOFRAME_AUDIO.Future3x"]/*' />
        [NativeTypeName("NvU32 : 4")]
        public uint Future3x
        {
            readonly get
            {
                return (_bitfield2 >> 16) & 0xFu;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~(0xFu << 16)) | ((value & 0xFu) << 16);
            }
        }

        /// <include file='NV_INFOFRAME_AUDIO.xml' path='doc/member[@name="NV_INFOFRAME_AUDIO.Future52"]/*' />
        [NativeTypeName("NvU32 : 2")]
        public uint Future52
        {
            readonly get
            {
                return (_bitfield2 >> 20) & 0x3u;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~(0x3u << 20)) | ((value & 0x3u) << 20);
            }
        }

        /// <include file='NV_INFOFRAME_AUDIO.xml' path='doc/member[@name="NV_INFOFRAME_AUDIO.Future6"]/*' />
        [NativeTypeName("NvU32 : 9")]
        public uint Future6
        {
            readonly get
            {
                return (_bitfield2 >> 22) & 0x1FFu;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~(0x1FFu << 22)) | ((value & 0x1FFu) << 22);
            }
        }

        public uint _bitfield3;

        /// <include file='NV_INFOFRAME_AUDIO.xml' path='doc/member[@name="NV_INFOFRAME_AUDIO.Future7"]/*' />
        [NativeTypeName("NvU32 : 9")]
        public uint Future7
        {
            readonly get
            {
                return _bitfield3 & 0x1FFu;
            }

            set
            {
                _bitfield3 = (_bitfield3 & ~0x1FFu) | (value & 0x1FFu);
            }
        }

        /// <include file='NV_INFOFRAME_AUDIO.xml' path='doc/member[@name="NV_INFOFRAME_AUDIO.Future8"]/*' />
        [NativeTypeName("NvU32 : 9")]
        public uint Future8
        {
            readonly get
            {
                return (_bitfield3 >> 9) & 0x1FFu;
            }

            set
            {
                _bitfield3 = (_bitfield3 & ~(0x1FFu << 9)) | ((value & 0x1FFu) << 9);
            }
        }

        /// <include file='NV_INFOFRAME_AUDIO.xml' path='doc/member[@name="NV_INFOFRAME_AUDIO.Future9"]/*' />
        [NativeTypeName("NvU32 : 9")]
        public uint Future9
        {
            readonly get
            {
                return (_bitfield3 >> 18) & 0x1FFu;
            }

            set
            {
                _bitfield3 = (_bitfield3 & ~(0x1FFu << 18)) | ((value & 0x1FFu) << 18);
            }
        }

        public uint _bitfield4;

        /// <include file='NV_INFOFRAME_AUDIO.xml' path='doc/member[@name="NV_INFOFRAME_AUDIO.Future10"]/*' />
        [NativeTypeName("NvU32 : 9")]
        public uint Future10
        {
            readonly get
            {
                return _bitfield4 & 0x1FFu;
            }

            set
            {
                _bitfield4 = (_bitfield4 & ~0x1FFu) | (value & 0x1FFu);
            }
        }
    }
}
