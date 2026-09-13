using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NVAPI_NVLINK_LINK_MASK_V1.xml' path='doc/member[@name="_NVAPI_NVLINK_LINK_MASK_V1"]/*' />
    public partial struct _NVAPI_NVLINK_LINK_MASK_V1
    {
        /// <include file='_NVAPI_NVLINK_LINK_MASK_V1.xml' path='doc/member[@name="_NVAPI_NVLINK_LINK_MASK_V1.lenMasks"]/*' />
        [NativeTypeName("NvU32")]
        public uint lenMasks;

        /// <include file='_NVAPI_NVLINK_LINK_MASK_V1.xml' path='doc/member[@name="_NVAPI_NVLINK_LINK_MASK_V1.masks"]/*' />
        [NativeTypeName("NvU64[128]")]
        public _masks_e__FixedBuffer masks;

        /// <include file='_masks_e__FixedBuffer.xml' path='doc/member[@name="_masks_e__FixedBuffer"]/*' />
        [InlineArray(128)]
        public partial struct _masks_e__FixedBuffer
        {
            public ulong e0;
        }
    }
}
