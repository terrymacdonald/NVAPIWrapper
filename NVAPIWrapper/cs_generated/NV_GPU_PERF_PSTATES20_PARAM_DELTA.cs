namespace NVAPIWrapper
{
    /// <include file='NV_GPU_PERF_PSTATES20_PARAM_DELTA.xml' path='doc/member[@name="NV_GPU_PERF_PSTATES20_PARAM_DELTA"]/*' />
    public partial struct NV_GPU_PERF_PSTATES20_PARAM_DELTA
    {
        /// <include file='NV_GPU_PERF_PSTATES20_PARAM_DELTA.xml' path='doc/member[@name="NV_GPU_PERF_PSTATES20_PARAM_DELTA.value"]/*' />
        [NativeTypeName("NvS32")]
        public int value;

        /// <include file='NV_GPU_PERF_PSTATES20_PARAM_DELTA.xml' path='doc/member[@name="NV_GPU_PERF_PSTATES20_PARAM_DELTA.valueRange"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L1154_C5")]
        public _valueRange_e__Struct valueRange;

        /// <include file='_valueRange_e__Struct.xml' path='doc/member[@name="_valueRange_e__Struct"]/*' />
        public partial struct _valueRange_e__Struct
        {
            /// <include file='_valueRange_e__Struct.xml' path='doc/member[@name="_valueRange_e__Struct.min"]/*' />
            [NativeTypeName("NvS32")]
            public int min;

            /// <include file='_valueRange_e__Struct.xml' path='doc/member[@name="_valueRange_e__Struct.max"]/*' />
            [NativeTypeName("NvS32")]
            public int max;
        }
    }
}
