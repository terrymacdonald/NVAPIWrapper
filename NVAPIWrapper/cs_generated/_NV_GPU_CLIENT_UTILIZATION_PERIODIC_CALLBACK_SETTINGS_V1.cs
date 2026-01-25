using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS_V1"]/*' />
    public unsafe partial struct _NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS_V1
    {
        /// <include file='_NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS_V1.super"]/*' />
        [NativeTypeName("NV_GPU_CLIENT_PERIODIC_CALLBACK_SETTINGS_SUPER_V1")]
        public _NV_GPU_CLIENT_PERIODIC_CALLBACK_SETTINGS_SUPER_V1 super;

        /// <include file='_NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS_V1.callback"]/*' />
        [NativeTypeName("NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_V1")]
        public delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, _NV_GPU_CLIENT_CALLBACK_UTILIZATION_DATA_V1*, void> callback;

        /// <include file='_NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS_V1.rsvd"]/*' />
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
