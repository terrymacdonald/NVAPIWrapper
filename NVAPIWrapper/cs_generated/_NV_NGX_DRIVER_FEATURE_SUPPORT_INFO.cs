using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_NGX_DRIVER_FEATURE_SUPPORT_INFO.xml' path='doc/member[@name="_NV_NGX_DRIVER_FEATURE_SUPPORT_INFO"]/*' />
    public partial struct _NV_NGX_DRIVER_FEATURE_SUPPORT_INFO
    {
        /// <include file='_NV_NGX_DRIVER_FEATURE_SUPPORT_INFO.xml' path='doc/member[@name="_NV_NGX_DRIVER_FEATURE_SUPPORT_INFO.featureId"]/*' />
        [NativeTypeName("NV_NGX_DRIVER_FEATURE_ID")]
        public _NV_NGX_DRIVER_FEATURE_ID featureId;

        public uint _bitfield;

        /// <include file='_NV_NGX_DRIVER_FEATURE_SUPPORT_INFO.xml' path='doc/member[@name="_NV_NGX_DRIVER_FEATURE_SUPPORT_INFO.bSupported"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bSupported
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

        /// <include file='_NV_NGX_DRIVER_FEATURE_SUPPORT_INFO.xml' path='doc/member[@name="_NV_NGX_DRIVER_FEATURE_SUPPORT_INFO.reserved1"]/*' />
        [NativeTypeName("NvU32 : 31")]
        public uint reserved1
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x7FFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x7FFFFFFFu << 1)) | ((value & 0x7FFFFFFFu) << 1);
            }
        }

        /// <include file='_NV_NGX_DRIVER_FEATURE_SUPPORT_INFO.xml' path='doc/member[@name="_NV_NGX_DRIVER_FEATURE_SUPPORT_INFO.reserved2"]/*' />
        [NativeTypeName("NvU32[2]")]
        public _reserved2_e__FixedBuffer reserved2;

        /// <include file='_reserved2_e__FixedBuffer.xml' path='doc/member[@name="_reserved2_e__FixedBuffer"]/*' />
        [InlineArray(2)]
        public partial struct _reserved2_e__FixedBuffer
        {
            public uint e0;
        }
    }
}
