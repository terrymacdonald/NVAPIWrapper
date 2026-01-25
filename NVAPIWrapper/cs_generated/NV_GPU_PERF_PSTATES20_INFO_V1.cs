using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NV_GPU_PERF_PSTATES20_INFO_V1.xml' path='doc/member[@name="NV_GPU_PERF_PSTATES20_INFO_V1"]/*' />
    public partial struct NV_GPU_PERF_PSTATES20_INFO_V1
    {
        /// <include file='NV_GPU_PERF_PSTATES20_INFO_V1.xml' path='doc/member[@name="NV_GPU_PERF_PSTATES20_INFO_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        public uint _bitfield;

        /// <include file='NV_GPU_PERF_PSTATES20_INFO_V1.xml' path='doc/member[@name="NV_GPU_PERF_PSTATES20_INFO_V1.bIsEditable"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bIsEditable
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

        /// <include file='NV_GPU_PERF_PSTATES20_INFO_V1.xml' path='doc/member[@name="NV_GPU_PERF_PSTATES20_INFO_V1.reserved"]/*' />
        [NativeTypeName("NvU32 : 31")]
        public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x7FFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x7FFFFFFFu << 1)) | ((value & 0x7FFFFFFFu) << 1);
            }
        }

        /// <include file='NV_GPU_PERF_PSTATES20_INFO_V1.xml' path='doc/member[@name="NV_GPU_PERF_PSTATES20_INFO_V1.numPstates"]/*' />
        [NativeTypeName("NvU32")]
        public uint numPstates;

        /// <include file='NV_GPU_PERF_PSTATES20_INFO_V1.xml' path='doc/member[@name="NV_GPU_PERF_PSTATES20_INFO_V1.numClocks"]/*' />
        [NativeTypeName("NvU32")]
        public uint numClocks;

        /// <include file='NV_GPU_PERF_PSTATES20_INFO_V1.xml' path='doc/member[@name="NV_GPU_PERF_PSTATES20_INFO_V1.numBaseVoltages"]/*' />
        [NativeTypeName("NvU32")]
        public uint numBaseVoltages;

        /// <include file='NV_GPU_PERF_PSTATES20_INFO_V1.xml' path='doc/member[@name="NV_GPU_PERF_PSTATES20_INFO_V1.pstates"]/*' />
        [NativeTypeName("struct (anonymous struct at ./../nvapi/nvapi.h:1244:5)[16]")]
        public _pstates_e__FixedBuffer pstates;

        /// <include file='_pstates_e__Struct.xml' path='doc/member[@name="_pstates_e__Struct"]/*' />
        public partial struct _pstates_e__Struct
        {
            /// <include file='_pstates_e__Struct.xml' path='doc/member[@name="_pstates_e__Struct.pstateId"]/*' />
            [NativeTypeName("NV_GPU_PERF_PSTATE_ID")]
            public _NV_GPU_PERF_PSTATE_ID pstateId;

            public uint _bitfield;

            /// <include file='_pstates_e__Struct.xml' path='doc/member[@name="_pstates_e__Struct.bIsEditable"]/*' />
            [NativeTypeName("NvU32 : 1")]
            public uint bIsEditable
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

            /// <include file='_pstates_e__Struct.xml' path='doc/member[@name="_pstates_e__Struct.reserved"]/*' />
            [NativeTypeName("NvU32 : 31")]
            public uint reserved
            {
                readonly get
                {
                    return (_bitfield >> 1) & 0x7FFFFFFFu;
                }

                set
                {
                    _bitfield = (_bitfield & ~(0x7FFFFFFFu << 1)) | ((value & 0x7FFFFFFFu) << 1);
                }
            }

            /// <include file='_pstates_e__Struct.xml' path='doc/member[@name="_pstates_e__Struct.clocks"]/*' />
            [NativeTypeName("NV_GPU_PSTATE20_CLOCK_ENTRY_V1[8]")]
            public _clocks_e__FixedBuffer clocks;

            /// <include file='_pstates_e__Struct.xml' path='doc/member[@name="_pstates_e__Struct.baseVoltages"]/*' />
            [NativeTypeName("NV_GPU_PSTATE20_BASE_VOLTAGE_ENTRY_V1[4]")]
            public _baseVoltages_e__FixedBuffer baseVoltages;

            /// <include file='_clocks_e__FixedBuffer.xml' path='doc/member[@name="_clocks_e__FixedBuffer"]/*' />
            [InlineArray(8)]
            public partial struct _clocks_e__FixedBuffer
            {
                public NV_GPU_PSTATE20_CLOCK_ENTRY_V1 e0;
            }

            /// <include file='_baseVoltages_e__FixedBuffer.xml' path='doc/member[@name="_baseVoltages_e__FixedBuffer"]/*' />
            [InlineArray(4)]
            public partial struct _baseVoltages_e__FixedBuffer
            {
                public NV_GPU_PSTATE20_BASE_VOLTAGE_ENTRY_V1 e0;
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
