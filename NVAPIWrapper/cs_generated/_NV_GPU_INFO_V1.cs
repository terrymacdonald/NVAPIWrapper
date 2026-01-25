namespace NVAPIWrapper
{
    /// <include file='_NV_GPU_INFO_V1.xml' path='doc/member[@name="_NV_GPU_INFO_V1"]/*' />
    public partial struct _NV_GPU_INFO_V1
    {
        /// <include file='_NV_GPU_INFO_V1.xml' path='doc/member[@name="_NV_GPU_INFO_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        public uint _bitfield;

        /// <include file='_NV_GPU_INFO_V1.xml' path='doc/member[@name="_NV_GPU_INFO_V1.bIsExternalGpu"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bIsExternalGpu
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

        /// <include file='_NV_GPU_INFO_V1.xml' path='doc/member[@name="_NV_GPU_INFO_V1.reserved"]/*' />
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
    }
}
