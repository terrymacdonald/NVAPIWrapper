using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_RISE_CALLBACK_SETTINGS_V1.xml' path='doc/member[@name="_NV_RISE_CALLBACK_SETTINGS_V1"]/*' />
    public unsafe partial struct _NV_RISE_CALLBACK_SETTINGS_V1
    {
        /// <include file='_NV_RISE_CALLBACK_SETTINGS_V1.xml' path='doc/member[@name="_NV_RISE_CALLBACK_SETTINGS_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_RISE_CALLBACK_SETTINGS_V1.xml' path='doc/member[@name="_NV_RISE_CALLBACK_SETTINGS_V1.super"]/*' />
        [NativeTypeName("NV_CLIENT_CALLBACK_SETTINGS_SUPER_V1")]
        public _NV_CLIENT_CALLBACK_SETTINGS_SUPER_V1 super;

        /// <include file='_NV_RISE_CALLBACK_SETTINGS_V1.xml' path='doc/member[@name="_NV_RISE_CALLBACK_SETTINGS_V1.callback"]/*' />
        [NativeTypeName("NV_RISE_CALLBACK_V1")]
        public delegate* unmanaged[Cdecl]<_NV_RISE_CALLBACK_DATA_V1*, void> callback;

        /// <include file='_NV_RISE_CALLBACK_SETTINGS_V1.xml' path='doc/member[@name="_NV_RISE_CALLBACK_SETTINGS_V1.reserved"]/*' />
        [NativeTypeName("NvU8[32]")]
        public _reserved_e__FixedBuffer reserved;

        /// <include file='_reserved_e__FixedBuffer.xml' path='doc/member[@name="_reserved_e__FixedBuffer"]/*' />
        [InlineArray(32)]
        public partial struct _reserved_e__FixedBuffer
        {
            public byte e0;
        }
    }
}
