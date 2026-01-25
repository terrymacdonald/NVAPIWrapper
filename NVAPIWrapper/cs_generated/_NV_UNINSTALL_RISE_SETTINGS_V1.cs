using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_UNINSTALL_RISE_SETTINGS_V1.xml' path='doc/member[@name="_NV_UNINSTALL_RISE_SETTINGS_V1"]/*' />
    public partial struct _NV_UNINSTALL_RISE_SETTINGS_V1
    {
        /// <include file='_NV_UNINSTALL_RISE_SETTINGS_V1.xml' path='doc/member[@name="_NV_UNINSTALL_RISE_SETTINGS_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_UNINSTALL_RISE_SETTINGS_V1.xml' path='doc/member[@name="_NV_UNINSTALL_RISE_SETTINGS_V1.reserved"]/*' />
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
