using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NVVIOGAMMARAMP10.xml' path='doc/member[@name="_NVVIOGAMMARAMP10"]/*' />
    public partial struct _NVVIOGAMMARAMP10
    {
        /// <include file='_NVVIOGAMMARAMP10.xml' path='doc/member[@name="_NVVIOGAMMARAMP10.uRed"]/*' />
        [NativeTypeName("NvU16[1024]")]
        public _uRed_e__FixedBuffer uRed;

        /// <include file='_NVVIOGAMMARAMP10.xml' path='doc/member[@name="_NVVIOGAMMARAMP10.uGreen"]/*' />
        [NativeTypeName("NvU16[1024]")]
        public _uGreen_e__FixedBuffer uGreen;

        /// <include file='_NVVIOGAMMARAMP10.xml' path='doc/member[@name="_NVVIOGAMMARAMP10.uBlue"]/*' />
        [NativeTypeName("NvU16[1024]")]
        public _uBlue_e__FixedBuffer uBlue;

        /// <include file='_uRed_e__FixedBuffer.xml' path='doc/member[@name="_uRed_e__FixedBuffer"]/*' />
        [InlineArray(1024)]
        public partial struct _uRed_e__FixedBuffer
        {
            public ushort e0;
        }

        /// <include file='_uGreen_e__FixedBuffer.xml' path='doc/member[@name="_uGreen_e__FixedBuffer"]/*' />
        [InlineArray(1024)]
        public partial struct _uGreen_e__FixedBuffer
        {
            public ushort e0;
        }

        /// <include file='_uBlue_e__FixedBuffer.xml' path='doc/member[@name="_uBlue_e__FixedBuffer"]/*' />
        [InlineArray(1024)]
        public partial struct _uBlue_e__FixedBuffer
        {
            public ushort e0;
        }
    }
}
