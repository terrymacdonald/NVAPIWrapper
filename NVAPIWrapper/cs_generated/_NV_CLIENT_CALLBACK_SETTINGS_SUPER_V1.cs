using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_CLIENT_CALLBACK_SETTINGS_SUPER_V1.xml' path='doc/member[@name="_NV_CLIENT_CALLBACK_SETTINGS_SUPER_V1"]/*' />
    public unsafe partial struct _NV_CLIENT_CALLBACK_SETTINGS_SUPER_V1
    {
        /// <include file='_NV_CLIENT_CALLBACK_SETTINGS_SUPER_V1.xml' path='doc/member[@name="_NV_CLIENT_CALLBACK_SETTINGS_SUPER_V1.pCallbackParam"]/*' />
        public void* pCallbackParam;

        /// <include file='_NV_CLIENT_CALLBACK_SETTINGS_SUPER_V1.xml' path='doc/member[@name="_NV_CLIENT_CALLBACK_SETTINGS_SUPER_V1.rsvd"]/*' />
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
