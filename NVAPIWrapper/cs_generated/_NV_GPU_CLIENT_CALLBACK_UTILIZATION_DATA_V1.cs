using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_GPU_CLIENT_CALLBACK_UTILIZATION_DATA_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_CALLBACK_UTILIZATION_DATA_V1"]/*' />
    public partial struct _NV_GPU_CLIENT_CALLBACK_UTILIZATION_DATA_V1
    {
        /// <include file='_NV_GPU_CLIENT_CALLBACK_UTILIZATION_DATA_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_CALLBACK_UTILIZATION_DATA_V1.super"]/*' />
        [NativeTypeName("NV_GPU_CLIENT_CALLBACK_DATA_SUPER_V1")]
        public _NV_GPU_CLIENT_CALLBACK_DATA_SUPER_V1 super;

        /// <include file='_NV_GPU_CLIENT_CALLBACK_UTILIZATION_DATA_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_CALLBACK_UTILIZATION_DATA_V1.numUtils"]/*' />
        [NativeTypeName("NvU32")]
        public uint numUtils;

        /// <include file='_NV_GPU_CLIENT_CALLBACK_UTILIZATION_DATA_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_CALLBACK_UTILIZATION_DATA_V1.timestamp"]/*' />
        [NativeTypeName("NvU64")]
        public ulong timestamp;

        /// <include file='_NV_GPU_CLIENT_CALLBACK_UTILIZATION_DATA_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_CALLBACK_UTILIZATION_DATA_V1.rsvd"]/*' />
        [NativeTypeName("NvU8[64]")]
        public _rsvd_e__FixedBuffer rsvd;

        /// <include file='_NV_GPU_CLIENT_CALLBACK_UTILIZATION_DATA_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_CALLBACK_UTILIZATION_DATA_V1.utils"]/*' />
        [NativeTypeName("NV_GPU_CLIENT_UTILIZATION_DATA_V1[4]")]
        public _utils_e__FixedBuffer utils;

        /// <include file='_rsvd_e__FixedBuffer.xml' path='doc/member[@name="_rsvd_e__FixedBuffer"]/*' />
        [InlineArray(64)]
        public partial struct _rsvd_e__FixedBuffer
        {
            public byte e0;
        }

        /// <include file='_utils_e__FixedBuffer.xml' path='doc/member[@name="_utils_e__FixedBuffer"]/*' />
        [InlineArray(4)]
        public partial struct _utils_e__FixedBuffer
        {
            public _NV_GPU_CLIENT_UTILIZATION_DATA_V1 e0;
        }
    }
}
