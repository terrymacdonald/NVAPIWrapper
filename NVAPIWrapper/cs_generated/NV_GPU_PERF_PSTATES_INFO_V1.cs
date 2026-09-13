using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NV_GPU_PERF_PSTATES_INFO_V1.xml' path='doc/member[@name="NV_GPU_PERF_PSTATES_INFO_V1"]/*' />
    public partial struct NV_GPU_PERF_PSTATES_INFO_V1
    {
        /// <include file='NV_GPU_PERF_PSTATES_INFO_V1.xml' path='doc/member[@name="NV_GPU_PERF_PSTATES_INFO_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_GPU_PERF_PSTATES_INFO_V1.xml' path='doc/member[@name="NV_GPU_PERF_PSTATES_INFO_V1.flags"]/*' />
        [NativeTypeName("NvU32")]
        public uint flags;

        /// <include file='NV_GPU_PERF_PSTATES_INFO_V1.xml' path='doc/member[@name="NV_GPU_PERF_PSTATES_INFO_V1.numPstates"]/*' />
        [NativeTypeName("NvU32")]
        public uint numPstates;

        /// <include file='NV_GPU_PERF_PSTATES_INFO_V1.xml' path='doc/member[@name="NV_GPU_PERF_PSTATES_INFO_V1.numClocks"]/*' />
        [NativeTypeName("NvU32")]
        public uint numClocks;

        /// <include file='NV_GPU_PERF_PSTATES_INFO_V1.xml' path='doc/member[@name="NV_GPU_PERF_PSTATES_INFO_V1.pstates"]/*' />
        [NativeTypeName("struct (anonymous struct at ./../nvapi/nvapi.h:4938:5)[16]")]
        public _pstates_e__FixedBuffer pstates;

        /// <include file='_pstates_e__Struct.xml' path='doc/member[@name="_pstates_e__Struct"]/*' />
        public partial struct _pstates_e__Struct
        {
            /// <include file='_pstates_e__Struct.xml' path='doc/member[@name="_pstates_e__Struct.pstateId"]/*' />
            [NativeTypeName("NV_GPU_PERF_PSTATE_ID")]
            public _NV_GPU_PERF_PSTATE_ID pstateId;

            /// <include file='_pstates_e__Struct.xml' path='doc/member[@name="_pstates_e__Struct.flags"]/*' />
            [NativeTypeName("NvU32")]
            public uint flags;

            /// <include file='_pstates_e__Struct.xml' path='doc/member[@name="_pstates_e__Struct.clocks"]/*' />
            [NativeTypeName("struct (anonymous struct at ./../nvapi/nvapi.h:4945:9)[32]")]
            public _clocks_e__FixedBuffer clocks;

            /// <include file='_clocks_e__Struct.xml' path='doc/member[@name="_clocks_e__Struct"]/*' />
            public partial struct _clocks_e__Struct
            {
                /// <include file='_clocks_e__Struct.xml' path='doc/member[@name="_clocks_e__Struct.domainId"]/*' />
                [NativeTypeName("NV_GPU_PUBLIC_CLOCK_ID")]
                public _NV_GPU_PUBLIC_CLOCK_ID domainId;

                /// <include file='_clocks_e__Struct.xml' path='doc/member[@name="_clocks_e__Struct.flags"]/*' />
                [NativeTypeName("NvU32")]
                public uint flags;

                /// <include file='_clocks_e__Struct.xml' path='doc/member[@name="_clocks_e__Struct.freq"]/*' />
                [NativeTypeName("NvU32")]
                public uint freq;
            }

            /// <include file='_clocks_e__FixedBuffer.xml' path='doc/member[@name="_clocks_e__FixedBuffer"]/*' />
            [InlineArray(32)]
            public partial struct _clocks_e__FixedBuffer
            {
                public _clocks_e__Struct e0;
            }
        }

        /// <include file='_pstates_e__FixedBuffer.xml' path='doc/member[@name="_pstates_e__FixedBuffer"]/*' />
        [InlineArray(16)]
        public partial struct _pstates_e__FixedBuffer
        {
            public _pstates_e__Struct e0;
        }
    }
}
