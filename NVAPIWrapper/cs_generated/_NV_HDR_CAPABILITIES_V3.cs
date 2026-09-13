namespace NVAPIWrapper
{
    /// <include file='_NV_HDR_CAPABILITIES_V3.xml' path='doc/member[@name="_NV_HDR_CAPABILITIES_V3"]/*' />
    public partial struct _NV_HDR_CAPABILITIES_V3
    {
        /// <include file='_NV_HDR_CAPABILITIES_V3.xml' path='doc/member[@name="_NV_HDR_CAPABILITIES_V3.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        public uint _bitfield;

        /// <include file='_NV_HDR_CAPABILITIES_V3.xml' path='doc/member[@name="_NV_HDR_CAPABILITIES_V3.isST2084EotfSupported"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isST2084EotfSupported
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

        /// <include file='_NV_HDR_CAPABILITIES_V3.xml' path='doc/member[@name="_NV_HDR_CAPABILITIES_V3.isTraditionalHdrGammaSupported"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isTraditionalHdrGammaSupported
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

        /// <include file='_NV_HDR_CAPABILITIES_V3.xml' path='doc/member[@name="_NV_HDR_CAPABILITIES_V3.isEdrSupported"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isEdrSupported
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

        /// <include file='_NV_HDR_CAPABILITIES_V3.xml' path='doc/member[@name="_NV_HDR_CAPABILITIES_V3.driverExpandDefaultHdrParameters"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint driverExpandDefaultHdrParameters
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

        /// <include file='_NV_HDR_CAPABILITIES_V3.xml' path='doc/member[@name="_NV_HDR_CAPABILITIES_V3.isTraditionalSdrGammaSupported"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isTraditionalSdrGammaSupported
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

        /// <include file='_NV_HDR_CAPABILITIES_V3.xml' path='doc/member[@name="_NV_HDR_CAPABILITIES_V3.isDolbyVisionSupported"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isDolbyVisionSupported
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

        /// <include file='_NV_HDR_CAPABILITIES_V3.xml' path='doc/member[@name="_NV_HDR_CAPABILITIES_V3.isHdr10PlusSupported"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isHdr10PlusSupported
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

        /// <include file='_NV_HDR_CAPABILITIES_V3.xml' path='doc/member[@name="_NV_HDR_CAPABILITIES_V3.isHdr10PlusGamingSupported"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isHdr10PlusGamingSupported
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

        /// <include file='_NV_HDR_CAPABILITIES_V3.xml' path='doc/member[@name="_NV_HDR_CAPABILITIES_V3.isNvidiaCertifiedDisplay"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isNvidiaCertifiedDisplay
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

        /// <include file='_NV_HDR_CAPABILITIES_V3.xml' path='doc/member[@name="_NV_HDR_CAPABILITIES_V3.reserved"]/*' />
        [NativeTypeName("NvU32 : 23")]
        public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 9) & 0x7FFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x7FFFFFu << 9)) | ((value & 0x7FFFFFu) << 9);
            }
        }

        /// <include file='_NV_HDR_CAPABILITIES_V3.xml' path='doc/member[@name="_NV_HDR_CAPABILITIES_V3.static_metadata_descriptor_id"]/*' />
        public NV_STATIC_METADATA_DESCRIPTOR_ID static_metadata_descriptor_id;

        /// <include file='_NV_HDR_CAPABILITIES_V3.xml' path='doc/member[@name="_NV_HDR_CAPABILITIES_V3.display_data"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L7860_C5")]
        public _display_data_e__Struct display_data;

        /// <include file='_NV_HDR_CAPABILITIES_V3.xml' path='doc/member[@name="_NV_HDR_CAPABILITIES_V3.dv_static_metadata"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L7879_C5")]
        public _dv_static_metadata_e__Struct dv_static_metadata;

        /// <include file='_NV_HDR_CAPABILITIES_V3.xml' path='doc/member[@name="_NV_HDR_CAPABILITIES_V3.hdr10plus_vsvdb"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L7907_C5")]
        public _hdr10plus_vsvdb_e__Struct hdr10plus_vsvdb;

        /// <include file='_display_data_e__Struct.xml' path='doc/member[@name="_display_data_e__Struct"]/*' />
        public partial struct _display_data_e__Struct
        {
            /// <include file='_display_data_e__Struct.xml' path='doc/member[@name="_display_data_e__Struct.displayPrimary_x0"]/*' />
            [NativeTypeName("NvU16")]
            public ushort displayPrimary_x0;

            /// <include file='_display_data_e__Struct.xml' path='doc/member[@name="_display_data_e__Struct.displayPrimary_y0"]/*' />
            [NativeTypeName("NvU16")]
            public ushort displayPrimary_y0;

            /// <include file='_display_data_e__Struct.xml' path='doc/member[@name="_display_data_e__Struct.displayPrimary_x1"]/*' />
            [NativeTypeName("NvU16")]
            public ushort displayPrimary_x1;

            /// <include file='_display_data_e__Struct.xml' path='doc/member[@name="_display_data_e__Struct.displayPrimary_y1"]/*' />
            [NativeTypeName("NvU16")]
            public ushort displayPrimary_y1;

            /// <include file='_display_data_e__Struct.xml' path='doc/member[@name="_display_data_e__Struct.displayPrimary_x2"]/*' />
            [NativeTypeName("NvU16")]
            public ushort displayPrimary_x2;

            /// <include file='_display_data_e__Struct.xml' path='doc/member[@name="_display_data_e__Struct.displayPrimary_y2"]/*' />
            [NativeTypeName("NvU16")]
            public ushort displayPrimary_y2;

            /// <include file='_display_data_e__Struct.xml' path='doc/member[@name="_display_data_e__Struct.displayWhitePoint_x"]/*' />
            [NativeTypeName("NvU16")]
            public ushort displayWhitePoint_x;

            /// <include file='_display_data_e__Struct.xml' path='doc/member[@name="_display_data_e__Struct.displayWhitePoint_y"]/*' />
            [NativeTypeName("NvU16")]
            public ushort displayWhitePoint_y;

            /// <include file='_display_data_e__Struct.xml' path='doc/member[@name="_display_data_e__Struct.desired_content_max_luminance"]/*' />
            [NativeTypeName("NvU16")]
            public ushort desired_content_max_luminance;

            /// <include file='_display_data_e__Struct.xml' path='doc/member[@name="_display_data_e__Struct.desired_content_min_luminance"]/*' />
            [NativeTypeName("NvU16")]
            public ushort desired_content_min_luminance;

            /// <include file='_display_data_e__Struct.xml' path='doc/member[@name="_display_data_e__Struct.desired_content_max_frame_average_luminance"]/*' />
            [NativeTypeName("NvU16")]
            public ushort desired_content_max_frame_average_luminance;
        }

        /// <include file='_dv_static_metadata_e__Struct.xml' path='doc/member[@name="_dv_static_metadata_e__Struct"]/*' />
        public partial struct _dv_static_metadata_e__Struct
        {
            public uint _bitfield;

            /// <include file='_dv_static_metadata_e__Struct.xml' path='doc/member[@name="_dv_static_metadata_e__Struct.VSVDB_version"]/*' />
            [NativeTypeName("NvU32 : 3")]
            public uint VSVDB_version
            {
                readonly get
                {
                    return _bitfield & 0x7u;
                }

                set
                {
                    _bitfield = (_bitfield & ~0x7u) | (value & 0x7u);
                }
            }

            /// <include file='_dv_static_metadata_e__Struct.xml' path='doc/member[@name="_dv_static_metadata_e__Struct.dm_version"]/*' />
            [NativeTypeName("NvU32 : 8")]
            public uint dm_version
            {
                readonly get
                {
                    return (_bitfield >> 3) & 0xFFu;
                }

                set
                {
                    _bitfield = (_bitfield & ~(0xFFu << 3)) | ((value & 0xFFu) << 3);
                }
            }

            /// <include file='_dv_static_metadata_e__Struct.xml' path='doc/member[@name="_dv_static_metadata_e__Struct.supports_2160p60hz"]/*' />
            [NativeTypeName("NvU32 : 1")]
            public uint supports_2160p60hz
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

            /// <include file='_dv_static_metadata_e__Struct.xml' path='doc/member[@name="_dv_static_metadata_e__Struct.supports_YUV422_12bit"]/*' />
            [NativeTypeName("NvU32 : 1")]
            public uint supports_YUV422_12bit
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

            /// <include file='_dv_static_metadata_e__Struct.xml' path='doc/member[@name="_dv_static_metadata_e__Struct.supports_global_dimming"]/*' />
            [NativeTypeName("NvU32 : 1")]
            public uint supports_global_dimming
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

            /// <include file='_dv_static_metadata_e__Struct.xml' path='doc/member[@name="_dv_static_metadata_e__Struct.colorimetry"]/*' />
            [NativeTypeName("NvU32 : 1")]
            public uint colorimetry
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

            /// <include file='_dv_static_metadata_e__Struct.xml' path='doc/member[@name="_dv_static_metadata_e__Struct.supports_backlight_control"]/*' />
            [NativeTypeName("NvU32 : 2")]
            public uint supports_backlight_control
            {
                readonly get
                {
                    return (_bitfield >> 15) & 0x3u;
                }

                set
                {
                    _bitfield = (_bitfield & ~(0x3u << 15)) | ((value & 0x3u) << 15);
                }
            }

            /// <include file='_dv_static_metadata_e__Struct.xml' path='doc/member[@name="_dv_static_metadata_e__Struct.backlt_min_luma"]/*' />
            [NativeTypeName("NvU32 : 2")]
            public uint backlt_min_luma
            {
                readonly get
                {
                    return (_bitfield >> 17) & 0x3u;
                }

                set
                {
                    _bitfield = (_bitfield & ~(0x3u << 17)) | ((value & 0x3u) << 17);
                }
            }

            /// <include file='_dv_static_metadata_e__Struct.xml' path='doc/member[@name="_dv_static_metadata_e__Struct.interface_supported_by_sink"]/*' />
            [NativeTypeName("NvU32 : 2")]
            public uint interface_supported_by_sink
            {
                readonly get
                {
                    return (_bitfield >> 19) & 0x3u;
                }

                set
                {
                    _bitfield = (_bitfield & ~(0x3u << 19)) | ((value & 0x3u) << 19);
                }
            }

            /// <include file='_dv_static_metadata_e__Struct.xml' path='doc/member[@name="_dv_static_metadata_e__Struct.supports_10b_12b_444"]/*' />
            [NativeTypeName("NvU32 : 2")]
            public uint supports_10b_12b_444
            {
                readonly get
                {
                    return (_bitfield >> 21) & 0x3u;
                }

                set
                {
                    _bitfield = (_bitfield & ~(0x3u << 21)) | ((value & 0x3u) << 21);
                }
            }

            /// <include file='_dv_static_metadata_e__Struct.xml' path='doc/member[@name="_dv_static_metadata_e__Struct.parity"]/*' />
            [NativeTypeName("NvU32 : 1")]
            public uint parity
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

            /// <include file='_dv_static_metadata_e__Struct.xml' path='doc/member[@name="_dv_static_metadata_e__Struct.reserved"]/*' />
            [NativeTypeName("NvU32 : 8")]
            public uint reserved
            {
                readonly get
                {
                    return (_bitfield >> 24) & 0xFFu;
                }

                set
                {
                    _bitfield = (_bitfield & ~(0xFFu << 24)) | ((value & 0xFFu) << 24);
                }
            }

            /// <include file='_dv_static_metadata_e__Struct.xml' path='doc/member[@name="_dv_static_metadata_e__Struct.target_min_luminance"]/*' />
            [NativeTypeName("NvU16")]
            public ushort target_min_luminance;

            /// <include file='_dv_static_metadata_e__Struct.xml' path='doc/member[@name="_dv_static_metadata_e__Struct.target_max_luminance"]/*' />
            [NativeTypeName("NvU16")]
            public ushort target_max_luminance;

            /// <include file='_dv_static_metadata_e__Struct.xml' path='doc/member[@name="_dv_static_metadata_e__Struct.cc_red_x"]/*' />
            [NativeTypeName("NvU16")]
            public ushort cc_red_x;

            /// <include file='_dv_static_metadata_e__Struct.xml' path='doc/member[@name="_dv_static_metadata_e__Struct.cc_red_y"]/*' />
            [NativeTypeName("NvU16")]
            public ushort cc_red_y;

            /// <include file='_dv_static_metadata_e__Struct.xml' path='doc/member[@name="_dv_static_metadata_e__Struct.cc_green_x"]/*' />
            [NativeTypeName("NvU16")]
            public ushort cc_green_x;

            /// <include file='_dv_static_metadata_e__Struct.xml' path='doc/member[@name="_dv_static_metadata_e__Struct.cc_green_y"]/*' />
            [NativeTypeName("NvU16")]
            public ushort cc_green_y;

            /// <include file='_dv_static_metadata_e__Struct.xml' path='doc/member[@name="_dv_static_metadata_e__Struct.cc_blue_x"]/*' />
            [NativeTypeName("NvU16")]
            public ushort cc_blue_x;

            /// <include file='_dv_static_metadata_e__Struct.xml' path='doc/member[@name="_dv_static_metadata_e__Struct.cc_blue_y"]/*' />
            [NativeTypeName("NvU16")]
            public ushort cc_blue_y;

            /// <include file='_dv_static_metadata_e__Struct.xml' path='doc/member[@name="_dv_static_metadata_e__Struct.cc_white_x"]/*' />
            [NativeTypeName("NvU16")]
            public ushort cc_white_x;

            /// <include file='_dv_static_metadata_e__Struct.xml' path='doc/member[@name="_dv_static_metadata_e__Struct.cc_white_y"]/*' />
            [NativeTypeName("NvU16")]
            public ushort cc_white_y;
        }

        /// <include file='_hdr10plus_vsvdb_e__Struct.xml' path='doc/member[@name="_hdr10plus_vsvdb_e__Struct"]/*' />
        public partial struct _hdr10plus_vsvdb_e__Struct
        {
            public ushort _bitfield;

            /// <include file='_hdr10plus_vsvdb_e__Struct.xml' path='doc/member[@name="_hdr10plus_vsvdb_e__Struct.application_version"]/*' />
            [NativeTypeName("NvU16 : 2")]
            public ushort application_version
            {
                readonly get
                {
                    return (ushort)(_bitfield & 0x3u);
                }

                set
                {
                    _bitfield = (ushort)((_bitfield & ~0x3u) | (value & 0x3u));
                }
            }

            /// <include file='_hdr10plus_vsvdb_e__Struct.xml' path='doc/member[@name="_hdr10plus_vsvdb_e__Struct.full_frame_peak_luminance_index"]/*' />
            [NativeTypeName("NvU16 : 2")]
            public ushort full_frame_peak_luminance_index
            {
                readonly get
                {
                    return (ushort)((_bitfield >> 2) & 0x3u);
                }

                set
                {
                    _bitfield = (ushort)((_bitfield & ~(0x3u << 2)) | ((value & 0x3u) << 2));
                }
            }

            /// <include file='_hdr10plus_vsvdb_e__Struct.xml' path='doc/member[@name="_hdr10plus_vsvdb_e__Struct.peak_luminance_index"]/*' />
            [NativeTypeName("NvU16 : 4")]
            public ushort peak_luminance_index
            {
                readonly get
                {
                    return (ushort)((_bitfield >> 4) & 0xFu);
                }

                set
                {
                    _bitfield = (ushort)((_bitfield & ~(0xFu << 4)) | ((value & 0xFu) << 4));
                }
            }

            /// <include file='_hdr10plus_vsvdb_e__Struct.xml' path='doc/member[@name="_hdr10plus_vsvdb_e__Struct.reserved"]/*' />
            [NativeTypeName("NvU16 : 8")]
            public ushort reserved
            {
                readonly get
                {
                    return (ushort)((_bitfield >> 8) & 0xFFu);
                }

                set
                {
                    _bitfield = (ushort)((_bitfield & ~(0xFFu << 8)) | ((value & 0xFFu) << 8));
                }
            }
        }
    }
}
