using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <include file='NV_GPU_PSTATE20_CLOCK_ENTRY_V1.xml' path='doc/member[@name="NV_GPU_PSTATE20_CLOCK_ENTRY_V1"]/*' />
    public partial struct NV_GPU_PSTATE20_CLOCK_ENTRY_V1
    {
        /// <include file='NV_GPU_PSTATE20_CLOCK_ENTRY_V1.xml' path='doc/member[@name="NV_GPU_PSTATE20_CLOCK_ENTRY_V1.domainId"]/*' />
        [NativeTypeName("NV_GPU_PUBLIC_CLOCK_ID")]
        public _NV_GPU_PUBLIC_CLOCK_ID domainId;

        /// <include file='NV_GPU_PSTATE20_CLOCK_ENTRY_V1.xml' path='doc/member[@name="NV_GPU_PSTATE20_CLOCK_ENTRY_V1.typeId"]/*' />
        public NV_GPU_PERF_PSTATE20_CLOCK_TYPE_ID typeId;

        public uint _bitfield;

        /// <include file='NV_GPU_PSTATE20_CLOCK_ENTRY_V1.xml' path='doc/member[@name="NV_GPU_PSTATE20_CLOCK_ENTRY_V1.bIsEditable"]/*' />
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

        /// <include file='NV_GPU_PSTATE20_CLOCK_ENTRY_V1.xml' path='doc/member[@name="NV_GPU_PSTATE20_CLOCK_ENTRY_V1.reserved"]/*' />
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

        /// <include file='NV_GPU_PSTATE20_CLOCK_ENTRY_V1.xml' path='doc/member[@name="NV_GPU_PSTATE20_CLOCK_ENTRY_V1.freqDelta_kHz"]/*' />
        public NV_GPU_PERF_PSTATES20_PARAM_DELTA freqDelta_kHz;

        /// <include file='NV_GPU_PSTATE20_CLOCK_ENTRY_V1.xml' path='doc/member[@name="NV_GPU_PSTATE20_CLOCK_ENTRY_V1.data"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L1181_C5")]
        public _data_e__Union data;

        /// <include file='_data_e__Union.xml' path='doc/member[@name="_data_e__Union"]/*' />
        [StructLayout(LayoutKind.Explicit)]
        public partial struct _data_e__Union
        {
            /// <include file='_data_e__Union.xml' path='doc/member[@name="_data_e__Union.single"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("__AnonymousRecord_nvapi_L1183_C9")]
            public _single_e__Struct single;

            /// <include file='_data_e__Union.xml' path='doc/member[@name="_data_e__Union.range"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("__AnonymousRecord_nvapi_L1189_C9")]
            public _range_e__Struct range;

            /// <include file='_single_e__Struct.xml' path='doc/member[@name="_single_e__Struct"]/*' />
            public partial struct _single_e__Struct
            {
                /// <include file='_single_e__Struct.xml' path='doc/member[@name="_single_e__Struct.freq_kHz"]/*' />
                [NativeTypeName("NvU32")]
                public uint freq_kHz;
            }

            /// <include file='_range_e__Struct.xml' path='doc/member[@name="_range_e__Struct"]/*' />
            public partial struct _range_e__Struct
            {
                /// <include file='_range_e__Struct.xml' path='doc/member[@name="_range_e__Struct.minFreq_kHz"]/*' />
                [NativeTypeName("NvU32")]
                public uint minFreq_kHz;

                /// <include file='_range_e__Struct.xml' path='doc/member[@name="_range_e__Struct.maxFreq_kHz"]/*' />
                [NativeTypeName("NvU32")]
                public uint maxFreq_kHz;

                /// <include file='_range_e__Struct.xml' path='doc/member[@name="_range_e__Struct.domainId"]/*' />
                [NativeTypeName("NV_GPU_PERF_VOLTAGE_INFO_DOMAIN_ID")]
                public _NV_GPU_PERF_VOLTAGE_INFO_DOMAIN_ID domainId;

                /// <include file='_range_e__Struct.xml' path='doc/member[@name="_range_e__Struct.minVoltage_uV"]/*' />
                [NativeTypeName("NvU32")]
                public uint minVoltage_uV;

                /// <include file='_range_e__Struct.xml' path='doc/member[@name="_range_e__Struct.maxVoltage_uV"]/*' />
                [NativeTypeName("NvU32")]
                public uint maxVoltage_uV;
            }
        }
    }
}
