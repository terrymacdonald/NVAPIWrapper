namespace NVAPIWrapper
{
    /// <include file='_NV_HDR_CAPABILITIES_V1.xml' path='doc/member[@name="_NV_HDR_CAPABILITIES_V1"]/*' />
    public partial struct _NV_HDR_CAPABILITIES_V1
    {
        /// <include file='_NV_HDR_CAPABILITIES_V1.xml' path='doc/member[@name="_NV_HDR_CAPABILITIES_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        public uint _bitfield;

        /// <include file='_NV_HDR_CAPABILITIES_V1.xml' path='doc/member[@name="_NV_HDR_CAPABILITIES_V1.isST2084EotfSupported"]/*' />
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

        /// <include file='_NV_HDR_CAPABILITIES_V1.xml' path='doc/member[@name="_NV_HDR_CAPABILITIES_V1.isTraditionalHdrGammaSupported"]/*' />
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

        /// <include file='_NV_HDR_CAPABILITIES_V1.xml' path='doc/member[@name="_NV_HDR_CAPABILITIES_V1.isEdrSupported"]/*' />
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

        /// <include file='_NV_HDR_CAPABILITIES_V1.xml' path='doc/member[@name="_NV_HDR_CAPABILITIES_V1.driverExpandDefaultHdrParameters"]/*' />
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

        /// <include file='_NV_HDR_CAPABILITIES_V1.xml' path='doc/member[@name="_NV_HDR_CAPABILITIES_V1.isTraditionalSdrGammaSupported"]/*' />
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

        /// <include file='_NV_HDR_CAPABILITIES_V1.xml' path='doc/member[@name="_NV_HDR_CAPABILITIES_V1.reserved"]/*' />
        [NativeTypeName("NvU32 : 27")]
        public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 5) & 0x7FFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x7FFFFFFu << 5)) | ((value & 0x7FFFFFFu) << 5);
            }
        }

        /// <include file='_NV_HDR_CAPABILITIES_V1.xml' path='doc/member[@name="_NV_HDR_CAPABILITIES_V1.static_metadata_descriptor_id"]/*' />
        public NV_STATIC_METADATA_DESCRIPTOR_ID static_metadata_descriptor_id;

        /// <include file='_NV_HDR_CAPABILITIES_V1.xml' path='doc/member[@name="_NV_HDR_CAPABILITIES_V1.display_data"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L7760_C5")]
        public _display_data_e__Struct display_data;

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
    }
}
