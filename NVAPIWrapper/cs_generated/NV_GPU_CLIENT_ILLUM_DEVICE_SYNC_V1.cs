using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NV_GPU_CLIENT_ILLUM_DEVICE_SYNC_V1.xml' path='doc/member[@name="NV_GPU_CLIENT_ILLUM_DEVICE_SYNC_V1"]/*' />
    public partial struct NV_GPU_CLIENT_ILLUM_DEVICE_SYNC_V1
    {
        /// <include file='NV_GPU_CLIENT_ILLUM_DEVICE_SYNC_V1.xml' path='doc/member[@name="NV_GPU_CLIENT_ILLUM_DEVICE_SYNC_V1.bSync"]/*' />
        [NativeTypeName("NvBool")]
        public byte bSync;

        /// <include file='NV_GPU_CLIENT_ILLUM_DEVICE_SYNC_V1.xml' path='doc/member[@name="NV_GPU_CLIENT_ILLUM_DEVICE_SYNC_V1.timeStampms"]/*' />
        [NativeTypeName("NvU64")]
        public ulong timeStampms;

        /// <include file='NV_GPU_CLIENT_ILLUM_DEVICE_SYNC_V1.xml' path='doc/member[@name="NV_GPU_CLIENT_ILLUM_DEVICE_SYNC_V1.rsvd"]/*' />
        [NativeTypeName("NvU8[64]")]
        public _rsvd_e__FixedBuffer rsvd;

        /// <include file='_rsvd_e__FixedBuffer.xml' path='doc/member[@name="_rsvd_e__FixedBuffer"]/*' />
        [InlineArray(64)]
        public partial struct _rsvd_e__FixedBuffer
        {
            public byte e0;
        }
    }
}
