using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_GPU_CLIENT_UTILIZATION_DATA_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_UTILIZATION_DATA_V1"]/*' />
    public partial struct _NV_GPU_CLIENT_UTILIZATION_DATA_V1
    {
        /// <include file='_NV_GPU_CLIENT_UTILIZATION_DATA_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_UTILIZATION_DATA_V1.utilId"]/*' />
        [NativeTypeName("NV_GPU_CLIENT_UTIL_DOMAIN_ID")]
        public _NV_GPU_CLIENT_UTIL_DOMAIN_ID utilId;

        /// <include file='_NV_GPU_CLIENT_UTILIZATION_DATA_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_UTILIZATION_DATA_V1.utilizationPercent"]/*' />
        [NativeTypeName("NvU32")]
        public uint utilizationPercent;

        /// <include file='_NV_GPU_CLIENT_UTILIZATION_DATA_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_UTILIZATION_DATA_V1.rsvd"]/*' />
        [NativeTypeName("NvU8[61]")]
        public _rsvd_e__FixedBuffer rsvd;

        /// <include file='_rsvd_e__FixedBuffer.xml' path='doc/member[@name="_rsvd_e__FixedBuffer"]/*' />
        [InlineArray(61)]
        public partial struct _rsvd_e__FixedBuffer
        {
            public byte e0;
        }
    }
}
