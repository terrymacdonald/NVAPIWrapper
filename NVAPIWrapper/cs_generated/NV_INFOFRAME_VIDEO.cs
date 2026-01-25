namespace NVAPIWrapper
{
    /// <include file='NV_INFOFRAME_VIDEO.xml' path='doc/member[@name="NV_INFOFRAME_VIDEO"]/*' />
    public partial struct NV_INFOFRAME_VIDEO
    {
        public uint _bitfield1;

        /// <include file='NV_INFOFRAME_VIDEO.xml' path='doc/member[@name="NV_INFOFRAME_VIDEO.vic"]/*' />
        [NativeTypeName("NvU32 : 8")]
        public uint vic
        {
            readonly get
            {
                return _bitfield1 & 0xFFu;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~0xFFu) | (value & 0xFFu);
            }
        }

        /// <include file='NV_INFOFRAME_VIDEO.xml' path='doc/member[@name="NV_INFOFRAME_VIDEO.pixelRepeat"]/*' />
        [NativeTypeName("NvU32 : 5")]
        public uint pixelRepeat
        {
            readonly get
            {
                return (_bitfield1 >> 8) & 0x1Fu;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~(0x1Fu << 8)) | ((value & 0x1Fu) << 8);
            }
        }

        /// <include file='NV_INFOFRAME_VIDEO.xml' path='doc/member[@name="NV_INFOFRAME_VIDEO.colorSpace"]/*' />
        [NativeTypeName("NvU32 : 3")]
        public uint colorSpace
        {
            readonly get
            {
                return (_bitfield1 >> 13) & 0x7u;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~(0x7u << 13)) | ((value & 0x7u) << 13);
            }
        }

        /// <include file='NV_INFOFRAME_VIDEO.xml' path='doc/member[@name="NV_INFOFRAME_VIDEO.colorimetry"]/*' />
        [NativeTypeName("NvU32 : 3")]
        public uint colorimetry
        {
            readonly get
            {
                return (_bitfield1 >> 16) & 0x7u;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~(0x7u << 16)) | ((value & 0x7u) << 16);
            }
        }

        /// <include file='NV_INFOFRAME_VIDEO.xml' path='doc/member[@name="NV_INFOFRAME_VIDEO.extendedColorimetry"]/*' />
        [NativeTypeName("NvU32 : 4")]
        public uint extendedColorimetry
        {
            readonly get
            {
                return (_bitfield1 >> 19) & 0xFu;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~(0xFu << 19)) | ((value & 0xFu) << 19);
            }
        }

        /// <include file='NV_INFOFRAME_VIDEO.xml' path='doc/member[@name="NV_INFOFRAME_VIDEO.rgbQuantizationRange"]/*' />
        [NativeTypeName("NvU32 : 3")]
        public uint rgbQuantizationRange
        {
            readonly get
            {
                return (_bitfield1 >> 23) & 0x7u;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~(0x7u << 23)) | ((value & 0x7u) << 23);
            }
        }

        /// <include file='NV_INFOFRAME_VIDEO.xml' path='doc/member[@name="NV_INFOFRAME_VIDEO.yccQuantizationRange"]/*' />
        [NativeTypeName("NvU32 : 3")]
        public uint yccQuantizationRange
        {
            readonly get
            {
                return (_bitfield1 >> 26) & 0x7u;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~(0x7u << 26)) | ((value & 0x7u) << 26);
            }
        }

        /// <include file='NV_INFOFRAME_VIDEO.xml' path='doc/member[@name="NV_INFOFRAME_VIDEO.itContent"]/*' />
        [NativeTypeName("NvU32 : 2")]
        public uint itContent
        {
            readonly get
            {
                return (_bitfield1 >> 29) & 0x3u;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~(0x3u << 29)) | ((value & 0x3u) << 29);
            }
        }

        public uint _bitfield2;

        /// <include file='NV_INFOFRAME_VIDEO.xml' path='doc/member[@name="NV_INFOFRAME_VIDEO.contentTypes"]/*' />
        [NativeTypeName("NvU32 : 3")]
        public uint contentTypes
        {
            readonly get
            {
                return _bitfield2 & 0x7u;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~0x7u) | (value & 0x7u);
            }
        }

        /// <include file='NV_INFOFRAME_VIDEO.xml' path='doc/member[@name="NV_INFOFRAME_VIDEO.scanInfo"]/*' />
        [NativeTypeName("NvU32 : 3")]
        public uint scanInfo
        {
            readonly get
            {
                return (_bitfield2 >> 3) & 0x7u;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~(0x7u << 3)) | ((value & 0x7u) << 3);
            }
        }

        /// <include file='NV_INFOFRAME_VIDEO.xml' path='doc/member[@name="NV_INFOFRAME_VIDEO.activeFormatInfoPresent"]/*' />
        [NativeTypeName("NvU32 : 2")]
        public uint activeFormatInfoPresent
        {
            readonly get
            {
                return (_bitfield2 >> 6) & 0x3u;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~(0x3u << 6)) | ((value & 0x3u) << 6);
            }
        }

        /// <include file='NV_INFOFRAME_VIDEO.xml' path='doc/member[@name="NV_INFOFRAME_VIDEO.activeFormatAspectRatio"]/*' />
        [NativeTypeName("NvU32 : 5")]
        public uint activeFormatAspectRatio
        {
            readonly get
            {
                return (_bitfield2 >> 8) & 0x1Fu;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~(0x1Fu << 8)) | ((value & 0x1Fu) << 8);
            }
        }

        /// <include file='NV_INFOFRAME_VIDEO.xml' path='doc/member[@name="NV_INFOFRAME_VIDEO.picAspectRatio"]/*' />
        [NativeTypeName("NvU32 : 3")]
        public uint picAspectRatio
        {
            readonly get
            {
                return (_bitfield2 >> 13) & 0x7u;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~(0x7u << 13)) | ((value & 0x7u) << 13);
            }
        }

        /// <include file='NV_INFOFRAME_VIDEO.xml' path='doc/member[@name="NV_INFOFRAME_VIDEO.nonuniformScaling"]/*' />
        [NativeTypeName("NvU32 : 3")]
        public uint nonuniformScaling
        {
            readonly get
            {
                return (_bitfield2 >> 16) & 0x7u;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~(0x7u << 16)) | ((value & 0x7u) << 16);
            }
        }

        /// <include file='NV_INFOFRAME_VIDEO.xml' path='doc/member[@name="NV_INFOFRAME_VIDEO.barInfo"]/*' />
        [NativeTypeName("NvU32 : 3")]
        public uint barInfo
        {
            readonly get
            {
                return (_bitfield2 >> 19) & 0x7u;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~(0x7u << 19)) | ((value & 0x7u) << 19);
            }
        }

        public uint _bitfield3;

        /// <include file='NV_INFOFRAME_VIDEO.xml' path='doc/member[@name="NV_INFOFRAME_VIDEO.top_bar"]/*' />
        [NativeTypeName("NvU32 : 17")]
        public uint top_bar
        {
            readonly get
            {
                return _bitfield3 & 0x1FFFFu;
            }

            set
            {
                _bitfield3 = (_bitfield3 & ~0x1FFFFu) | (value & 0x1FFFFu);
            }
        }

        public uint _bitfield4;

        /// <include file='NV_INFOFRAME_VIDEO.xml' path='doc/member[@name="NV_INFOFRAME_VIDEO.bottom_bar"]/*' />
        [NativeTypeName("NvU32 : 17")]
        public uint bottom_bar
        {
            readonly get
            {
                return _bitfield4 & 0x1FFFFu;
            }

            set
            {
                _bitfield4 = (_bitfield4 & ~0x1FFFFu) | (value & 0x1FFFFu);
            }
        }

        public uint _bitfield5;

        /// <include file='NV_INFOFRAME_VIDEO.xml' path='doc/member[@name="NV_INFOFRAME_VIDEO.left_bar"]/*' />
        [NativeTypeName("NvU32 : 17")]
        public uint left_bar
        {
            readonly get
            {
                return _bitfield5 & 0x1FFFFu;
            }

            set
            {
                _bitfield5 = (_bitfield5 & ~0x1FFFFu) | (value & 0x1FFFFu);
            }
        }

        public uint _bitfield6;

        /// <include file='NV_INFOFRAME_VIDEO.xml' path='doc/member[@name="NV_INFOFRAME_VIDEO.right_bar"]/*' />
        [NativeTypeName("NvU32 : 17")]
        public uint right_bar
        {
            readonly get
            {
                return _bitfield6 & 0x1FFFFu;
            }

            set
            {
                _bitfield6 = (_bitfield6 & ~0x1FFFFu) | (value & 0x1FFFFu);
            }
        }

        /// <include file='NV_INFOFRAME_VIDEO.xml' path='doc/member[@name="NV_INFOFRAME_VIDEO.Future17"]/*' />
        [NativeTypeName("NvU32 : 2")]
        public uint Future17
        {
            readonly get
            {
                return (_bitfield6 >> 17) & 0x3u;
            }

            set
            {
                _bitfield6 = (_bitfield6 & ~(0x3u << 17)) | ((value & 0x3u) << 17);
            }
        }

        /// <include file='NV_INFOFRAME_VIDEO.xml' path='doc/member[@name="NV_INFOFRAME_VIDEO.Future47"]/*' />
        [NativeTypeName("NvU32 : 2")]
        public uint Future47
        {
            readonly get
            {
                return (_bitfield6 >> 19) & 0x3u;
            }

            set
            {
                _bitfield6 = (_bitfield6 & ~(0x3u << 19)) | ((value & 0x3u) << 19);
            }
        }
    }
}
