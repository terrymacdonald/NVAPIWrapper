namespace NVAPIWrapper
{
    /// <include file='_NV_HDR_COLOR_DATA_V1.xml' path='doc/member[@name="_NV_HDR_COLOR_DATA_V1"]/*' />
    public partial struct _NV_HDR_COLOR_DATA_V1
    {
        /// <include file='_NV_HDR_COLOR_DATA_V1.xml' path='doc/member[@name="_NV_HDR_COLOR_DATA_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_HDR_COLOR_DATA_V1.xml' path='doc/member[@name="_NV_HDR_COLOR_DATA_V1.cmd"]/*' />
        public NV_HDR_CMD cmd;

        /// <include file='_NV_HDR_COLOR_DATA_V1.xml' path='doc/member[@name="_NV_HDR_COLOR_DATA_V1.hdrMode"]/*' />
        public NV_HDR_MODE hdrMode;

        /// <include file='_NV_HDR_COLOR_DATA_V1.xml' path='doc/member[@name="_NV_HDR_COLOR_DATA_V1.static_metadata_descriptor_id"]/*' />
        public NV_STATIC_METADATA_DESCRIPTOR_ID static_metadata_descriptor_id;

        /// <include file='_NV_HDR_COLOR_DATA_V1.xml' path='doc/member[@name="_NV_HDR_COLOR_DATA_V1.mastering_display_data"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L7977_C5")]
        public _mastering_display_data_e__Struct mastering_display_data;

        /// <include file='_mastering_display_data_e__Struct.xml' path='doc/member[@name="_mastering_display_data_e__Struct"]/*' />
        public partial struct _mastering_display_data_e__Struct
        {
            /// <include file='_mastering_display_data_e__Struct.xml' path='doc/member[@name="_mastering_display_data_e__Struct.displayPrimary_x0"]/*' />
            [NativeTypeName("NvU16")]
            public ushort displayPrimary_x0;

            /// <include file='_mastering_display_data_e__Struct.xml' path='doc/member[@name="_mastering_display_data_e__Struct.displayPrimary_y0"]/*' />
            [NativeTypeName("NvU16")]
            public ushort displayPrimary_y0;

            /// <include file='_mastering_display_data_e__Struct.xml' path='doc/member[@name="_mastering_display_data_e__Struct.displayPrimary_x1"]/*' />
            [NativeTypeName("NvU16")]
            public ushort displayPrimary_x1;

            /// <include file='_mastering_display_data_e__Struct.xml' path='doc/member[@name="_mastering_display_data_e__Struct.displayPrimary_y1"]/*' />
            [NativeTypeName("NvU16")]
            public ushort displayPrimary_y1;

            /// <include file='_mastering_display_data_e__Struct.xml' path='doc/member[@name="_mastering_display_data_e__Struct.displayPrimary_x2"]/*' />
            [NativeTypeName("NvU16")]
            public ushort displayPrimary_x2;

            /// <include file='_mastering_display_data_e__Struct.xml' path='doc/member[@name="_mastering_display_data_e__Struct.displayPrimary_y2"]/*' />
            [NativeTypeName("NvU16")]
            public ushort displayPrimary_y2;

            /// <include file='_mastering_display_data_e__Struct.xml' path='doc/member[@name="_mastering_display_data_e__Struct.displayWhitePoint_x"]/*' />
            [NativeTypeName("NvU16")]
            public ushort displayWhitePoint_x;

            /// <include file='_mastering_display_data_e__Struct.xml' path='doc/member[@name="_mastering_display_data_e__Struct.displayWhitePoint_y"]/*' />
            [NativeTypeName("NvU16")]
            public ushort displayWhitePoint_y;

            /// <include file='_mastering_display_data_e__Struct.xml' path='doc/member[@name="_mastering_display_data_e__Struct.max_display_mastering_luminance"]/*' />
            [NativeTypeName("NvU16")]
            public ushort max_display_mastering_luminance;

            /// <include file='_mastering_display_data_e__Struct.xml' path='doc/member[@name="_mastering_display_data_e__Struct.min_display_mastering_luminance"]/*' />
            [NativeTypeName("NvU16")]
            public ushort min_display_mastering_luminance;

            /// <include file='_mastering_display_data_e__Struct.xml' path='doc/member[@name="_mastering_display_data_e__Struct.max_content_light_level"]/*' />
            [NativeTypeName("NvU16")]
            public ushort max_content_light_level;

            /// <include file='_mastering_display_data_e__Struct.xml' path='doc/member[@name="_mastering_display_data_e__Struct.max_frame_average_light_level"]/*' />
            [NativeTypeName("NvU16")]
            public ushort max_frame_average_light_level;
        }
    }
}
