using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_GPU_CLIENT_PERIODIC_CALLBACK_SETTINGS_SUPER_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_PERIODIC_CALLBACK_SETTINGS_SUPER_V1"]/*' />
    public partial struct _NV_GPU_CLIENT_PERIODIC_CALLBACK_SETTINGS_SUPER_V1
    {
        /// <include file='_NV_GPU_CLIENT_PERIODIC_CALLBACK_SETTINGS_SUPER_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_PERIODIC_CALLBACK_SETTINGS_SUPER_V1.super"]/*' />
        [NativeTypeName("NV_GPU_CLIENT_CALLBACK_SETTINGS_SUPER_V1")]
        public _NV_CLIENT_CALLBACK_SETTINGS_SUPER_V1 super;

        /// <include file='_NV_GPU_CLIENT_PERIODIC_CALLBACK_SETTINGS_SUPER_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_PERIODIC_CALLBACK_SETTINGS_SUPER_V1.callbackPeriodms"]/*' />
        [NativeTypeName("NvU32")]
        public uint callbackPeriodms;

        /// <include file='_NV_GPU_CLIENT_PERIODIC_CALLBACK_SETTINGS_SUPER_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_PERIODIC_CALLBACK_SETTINGS_SUPER_V1.rsvd"]/*' />
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
