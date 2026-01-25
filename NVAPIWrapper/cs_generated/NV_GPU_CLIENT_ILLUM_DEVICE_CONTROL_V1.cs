using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_V1.xml' path='doc/member[@name="NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_V1"]/*' />
    public partial struct NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_V1
    {
        /// <include file='NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_V1.xml' path='doc/member[@name="NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_V1.type"]/*' />
        public NV_GPU_CLIENT_ILLUM_DEVICE_TYPE type;

        /// <include file='NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_V1.xml' path='doc/member[@name="NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_V1.syncData"]/*' />
        public NV_GPU_CLIENT_ILLUM_DEVICE_SYNC_V1 syncData;

        /// <include file='NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_V1.xml' path='doc/member[@name="NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_V1.rsvd"]/*' />
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
