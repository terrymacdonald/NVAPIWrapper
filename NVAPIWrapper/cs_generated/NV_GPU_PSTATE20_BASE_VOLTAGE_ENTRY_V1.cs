namespace NVAPIWrapper
{
    /// <include file='NV_GPU_PSTATE20_BASE_VOLTAGE_ENTRY_V1.xml' path='doc/member[@name="NV_GPU_PSTATE20_BASE_VOLTAGE_ENTRY_V1"]/*' />
    public partial struct NV_GPU_PSTATE20_BASE_VOLTAGE_ENTRY_V1
    {
        /// <include file='NV_GPU_PSTATE20_BASE_VOLTAGE_ENTRY_V1.xml' path='doc/member[@name="NV_GPU_PSTATE20_BASE_VOLTAGE_ENTRY_V1.domainId"]/*' />
        [NativeTypeName("NV_GPU_PERF_VOLTAGE_INFO_DOMAIN_ID")]
        public _NV_GPU_PERF_VOLTAGE_INFO_DOMAIN_ID domainId;

        public uint _bitfield;

        /// <include file='NV_GPU_PSTATE20_BASE_VOLTAGE_ENTRY_V1.xml' path='doc/member[@name="NV_GPU_PSTATE20_BASE_VOLTAGE_ENTRY_V1.bIsEditable"]/*' />
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

        /// <include file='NV_GPU_PSTATE20_BASE_VOLTAGE_ENTRY_V1.xml' path='doc/member[@name="NV_GPU_PSTATE20_BASE_VOLTAGE_ENTRY_V1.reserved"]/*' />
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

        /// <include file='NV_GPU_PSTATE20_BASE_VOLTAGE_ENTRY_V1.xml' path='doc/member[@name="NV_GPU_PSTATE20_BASE_VOLTAGE_ENTRY_V1.volt_uV"]/*' />
        [NativeTypeName("NvU32")]
        public uint volt_uV;

        /// <include file='NV_GPU_PSTATE20_BASE_VOLTAGE_ENTRY_V1.xml' path='doc/member[@name="NV_GPU_PSTATE20_BASE_VOLTAGE_ENTRY_V1.voltDelta_uV"]/*' />
        public NV_GPU_PERF_PSTATES20_PARAM_DELTA voltDelta_uV;
    }
}
