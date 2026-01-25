using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_V1"]/*' />
    public partial struct _NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_V1
    {
        /// <include file='_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_V1.numIllumDevices"]/*' />
        [NativeTypeName("NvU32")]
        public uint numIllumDevices;

        /// <include file='_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_V1.rsvd"]/*' />
        [NativeTypeName("NvU8[64]")]
        public _rsvd_e__FixedBuffer rsvd;

        /// <include file='_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_V1.devices"]/*' />
        [NativeTypeName("NV_GPU_CLIENT_ILLUM_DEVICE_INFO_V1[32]")]
        public _devices_e__FixedBuffer devices;

        /// <include file='_rsvd_e__FixedBuffer.xml' path='doc/member[@name="_rsvd_e__FixedBuffer"]/*' />
        [InlineArray(64)]
        public partial struct _rsvd_e__FixedBuffer
        {
            public byte e0;
        }

        /// <include file='_devices_e__FixedBuffer.xml' path='doc/member[@name="_devices_e__FixedBuffer"]/*' />
        [InlineArray(32)]
        public partial struct _devices_e__FixedBuffer
        {
            public _NV_GPU_CLIENT_ILLUM_DEVICE_INFO_V1 e0;
        }
    }
}
