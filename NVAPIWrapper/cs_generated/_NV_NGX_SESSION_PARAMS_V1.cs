using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_NGX_SESSION_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_SESSION_PARAMS_V1"]/*' />
    public partial struct _NV_NGX_SESSION_PARAMS_V1
    {
        /// <include file='_NV_NGX_SESSION_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_SESSION_PARAMS_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_NGX_SESSION_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_SESSION_PARAMS_V1.processIdentifier"]/*' />
        [NativeTypeName("NvU32")]
        public uint processIdentifier;

        /// <include file='_NV_NGX_SESSION_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_SESSION_PARAMS_V1.hSession"]/*' />
        [NativeTypeName("NV_NGX_SESSION")]
        public ulong hSession;

        /// <include file='_NV_NGX_SESSION_PARAMS_V1.xml' path='doc/member[@name="_NV_NGX_SESSION_PARAMS_V1.reserved"]/*' />
        [NativeTypeName("NvU32[8]")]
        public _reserved_e__FixedBuffer reserved;

        /// <include file='_reserved_e__FixedBuffer.xml' path='doc/member[@name="_reserved_e__FixedBuffer"]/*' />
        [InlineArray(8)]
        public partial struct _reserved_e__FixedBuffer
        {
            public uint e0;
        }
    }
}
