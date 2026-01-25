namespace NVAPIWrapper
{
    /// <include file='NV_GPU_ECC_STATUS_INFO.xml' path='doc/member[@name="NV_GPU_ECC_STATUS_INFO"]/*' />
    public partial struct NV_GPU_ECC_STATUS_INFO
    {
        /// <include file='NV_GPU_ECC_STATUS_INFO.xml' path='doc/member[@name="NV_GPU_ECC_STATUS_INFO.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        public uint _bitfield1;

        /// <include file='NV_GPU_ECC_STATUS_INFO.xml' path='doc/member[@name="NV_GPU_ECC_STATUS_INFO.isSupported"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isSupported
        {
            readonly get
            {
                return _bitfield1 & 0x1u;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~0x1u) | (value & 0x1u);
            }
        }

        /// <include file='NV_GPU_ECC_STATUS_INFO.xml' path='doc/member[@name="NV_GPU_ECC_STATUS_INFO.configurationOptions"]/*' />
        [NativeTypeName("NV_ECC_CONFIGURATION")]
        public _NV_ECC_CONFIGURATION configurationOptions;

        public uint _bitfield2;

        /// <include file='NV_GPU_ECC_STATUS_INFO.xml' path='doc/member[@name="NV_GPU_ECC_STATUS_INFO.isEnabled"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isEnabled
        {
            readonly get
            {
                return _bitfield2 & 0x1u;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~0x1u) | (value & 0x1u);
            }
        }
    }
}
