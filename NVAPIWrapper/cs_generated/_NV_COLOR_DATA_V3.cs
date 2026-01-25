namespace NVAPIWrapper
{
    /// <include file='_NV_COLOR_DATA_V3.xml' path='doc/member[@name="_NV_COLOR_DATA_V3"]/*' />
    public partial struct _NV_COLOR_DATA_V3
    {
        /// <include file='_NV_COLOR_DATA_V3.xml' path='doc/member[@name="_NV_COLOR_DATA_V3.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_COLOR_DATA_V3.xml' path='doc/member[@name="_NV_COLOR_DATA_V3.size"]/*' />
        [NativeTypeName("NvU16")]
        public ushort size;

        /// <include file='_NV_COLOR_DATA_V3.xml' path='doc/member[@name="_NV_COLOR_DATA_V3.cmd"]/*' />
        [NativeTypeName("NvU8")]
        public byte cmd;

        /// <include file='_NV_COLOR_DATA_V3.xml' path='doc/member[@name="_NV_COLOR_DATA_V3.data"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L7687_C5")]
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

            /// <include file='_data_e__Struct.xml' path='doc/member[@name="_data_e__Struct.bpc"]/*' />
            [NativeTypeName("NV_BPC")]
            public _NV_BPC bpc;
        }
    }
}
