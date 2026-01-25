namespace NVAPIWrapper
{
    /// <include file='_NV_COLOR_DATA_V2.xml' path='doc/member[@name="_NV_COLOR_DATA_V2"]/*' />
    public partial struct _NV_COLOR_DATA_V2
    {
        /// <include file='_NV_COLOR_DATA_V2.xml' path='doc/member[@name="_NV_COLOR_DATA_V2.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_COLOR_DATA_V2.xml' path='doc/member[@name="_NV_COLOR_DATA_V2.size"]/*' />
        [NativeTypeName("NvU16")]
        public ushort size;

        /// <include file='_NV_COLOR_DATA_V2.xml' path='doc/member[@name="_NV_COLOR_DATA_V2.cmd"]/*' />
        [NativeTypeName("NvU8")]
        public byte cmd;

        /// <include file='_NV_COLOR_DATA_V2.xml' path='doc/member[@name="_NV_COLOR_DATA_V2.data"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L7674_C5")]
        public _data_e__Struct data;

        /// <include file='_data_e__Struct.xml' path='doc/member[@name="_data_e__Struct"]/*' />
        public partial struct _data_e__Struct
        {
            /// <include file='_data_e__Struct.xml' path='doc/member[@name="_data_e__Struct.colorFormat"]/*' />
            [NativeTypeName("NvU8")]
            public byte colorFormat;

            /// <include file='_data_e__Struct.xml' path='doc/member[@name="_data_e__Struct.colorimetry"]/*' />
            [NativeTypeName("NvU8")]
            public byte colorimetry;

            /// <include file='_data_e__Struct.xml' path='doc/member[@name="_data_e__Struct.dynamicRange"]/*' />
            [NativeTypeName("NvU8")]
            public byte dynamicRange;
        }
    }
}
