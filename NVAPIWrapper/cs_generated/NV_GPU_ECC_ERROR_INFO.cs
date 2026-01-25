namespace NVAPIWrapper
{
    /// <include file='NV_GPU_ECC_ERROR_INFO.xml' path='doc/member[@name="NV_GPU_ECC_ERROR_INFO"]/*' />
    public partial struct NV_GPU_ECC_ERROR_INFO
    {
        /// <include file='NV_GPU_ECC_ERROR_INFO.xml' path='doc/member[@name="NV_GPU_ECC_ERROR_INFO.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_GPU_ECC_ERROR_INFO.xml' path='doc/member[@name="NV_GPU_ECC_ERROR_INFO.current"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L3448_C5")]
        public _current_e__Struct current;

        /// <include file='NV_GPU_ECC_ERROR_INFO.xml' path='doc/member[@name="NV_GPU_ECC_ERROR_INFO.aggregate"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L3453_C5")]
        public _aggregate_e__Struct aggregate;

        /// <include file='_current_e__Struct.xml' path='doc/member[@name="_current_e__Struct"]/*' />
        public partial struct _current_e__Struct
        {
            /// <include file='_current_e__Struct.xml' path='doc/member[@name="_current_e__Struct.singleBitErrors"]/*' />
            [NativeTypeName("NvU64")]
            public ulong singleBitErrors;

            /// <include file='_current_e__Struct.xml' path='doc/member[@name="_current_e__Struct.doubleBitErrors"]/*' />
            [NativeTypeName("NvU64")]
            public ulong doubleBitErrors;
        }

        /// <include file='_aggregate_e__Struct.xml' path='doc/member[@name="_aggregate_e__Struct"]/*' />
        public partial struct _aggregate_e__Struct
        {
            /// <include file='_aggregate_e__Struct.xml' path='doc/member[@name="_aggregate_e__Struct.singleBitErrors"]/*' />
            [NativeTypeName("NvU64")]
            public ulong singleBitErrors;

            /// <include file='_aggregate_e__Struct.xml' path='doc/member[@name="_aggregate_e__Struct.doubleBitErrors"]/*' />
            [NativeTypeName("NvU64")]
            public ulong doubleBitErrors;
        }
    }
}
