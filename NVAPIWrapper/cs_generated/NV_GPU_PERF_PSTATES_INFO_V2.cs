using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NV_GPU_PERF_PSTATES_INFO_V2.xml' path='doc/member[@name="NV_GPU_PERF_PSTATES_INFO_V2"]/*' />
    public partial struct NV_GPU_PERF_PSTATES_INFO_V2
    {
        /// <include file='NV_GPU_PERF_PSTATES_INFO_V2.xml' path='doc/member[@name="NV_GPU_PERF_PSTATES_INFO_V2.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_GPU_PERF_PSTATES_INFO_V2.xml' path='doc/member[@name="NV_GPU_PERF_PSTATES_INFO_V2.flags"]/*' />
        [NativeTypeName("NvU32")]
        public uint flags;

        /// <include file='NV_GPU_PERF_PSTATES_INFO_V2.xml' path='doc/member[@name="NV_GPU_PERF_PSTATES_INFO_V2.numPstates"]/*' />
        [NativeTypeName("NvU32")]
        public uint numPstates;

        /// <include file='NV_GPU_PERF_PSTATES_INFO_V2.xml' path='doc/member[@name="NV_GPU_PERF_PSTATES_INFO_V2.numClocks"]/*' />
        [NativeTypeName("NvU32")]
        public uint numClocks;

        /// <include file='NV_GPU_PERF_PSTATES_INFO_V2.xml' path='doc/member[@name="NV_GPU_PERF_PSTATES_INFO_V2.numVoltages"]/*' />
        [NativeTypeName("NvU32")]
        public uint numVoltages;

        /// <include file='NV_GPU_PERF_PSTATES_INFO_V2.xml' path='doc/member[@name="NV_GPU_PERF_PSTATES_INFO_V2.pstates"]/*' />
        [NativeTypeName("struct (anonymous struct at ./../nvapi/nvapi.h:4968:5)[16]")]
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
            [NativeTypeName("struct (anonymous struct at ./../nvapi/nvapi.h:4975:9)[32]")]
            public _clocks_e__FixedBuffer clocks;

            /// <include file='_pstates_e__Struct.xml' path='doc/member[@name="_pstates_e__Struct.voltages"]/*' />
            [NativeTypeName("struct (anonymous struct at ./../nvapi/nvapi.h:4983:9)[16]")]
            public _voltages_e__FixedBuffer voltages;

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

            /// <include file='_voltages_e__Struct.xml' path='doc/member[@name="_voltages_e__Struct"]/*' />
            public partial struct _voltages_e__Struct
            {
                /// <include file='_voltages_e__Struct.xml' path='doc/member[@name="_voltages_e__Struct.domainId"]/*' />
                [NativeTypeName("NV_GPU_PERF_VOLTAGE_INFO_DOMAIN_ID")]
                public _NV_GPU_PERF_VOLTAGE_INFO_DOMAIN_ID domainId;

                /// <include file='_voltages_e__Struct.xml' path='doc/member[@name="_voltages_e__Struct.flags"]/*' />
                [NativeTypeName("NvU32")]
                public uint flags;

                /// <include file='_voltages_e__Struct.xml' path='doc/member[@name="_voltages_e__Struct.mvolt"]/*' />
                [NativeTypeName("NvU32")]
                public uint mvolt;
            }

            /// <include file='_clocks_e__FixedBuffer.xml' path='doc/member[@name="_clocks_e__FixedBuffer"]/*' />
            [InlineArray(32)]
            public partial struct _clocks_e__FixedBuffer
            {
                public _clocks_e__Struct e0;
            }

            /// <include file='_voltages_e__FixedBuffer.xml' path='doc/member[@name="_voltages_e__FixedBuffer"]/*' />
            [InlineArray(16)]
            public partial struct _voltages_e__FixedBuffer
            {
                public _voltages_e__Struct e0;
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
