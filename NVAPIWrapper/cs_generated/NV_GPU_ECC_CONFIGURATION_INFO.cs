namespace NVAPIWrapper
{
    /// <include file='NV_GPU_ECC_CONFIGURATION_INFO.xml' path='doc/member[@name="NV_GPU_ECC_CONFIGURATION_INFO"]/*' />
    public partial struct NV_GPU_ECC_CONFIGURATION_INFO
    {
        /// <include file='NV_GPU_ECC_CONFIGURATION_INFO.xml' path='doc/member[@name="NV_GPU_ECC_CONFIGURATION_INFO.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        public uint _bitfield;

        /// <include file='NV_GPU_ECC_CONFIGURATION_INFO.xml' path='doc/member[@name="NV_GPU_ECC_CONFIGURATION_INFO.isEnabled"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isEnabled
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

        /// <include file='NV_GPU_ECC_CONFIGURATION_INFO.xml' path='doc/member[@name="NV_GPU_ECC_CONFIGURATION_INFO.isEnabledByDefault"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isEnabledByDefault
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }
    }
}
