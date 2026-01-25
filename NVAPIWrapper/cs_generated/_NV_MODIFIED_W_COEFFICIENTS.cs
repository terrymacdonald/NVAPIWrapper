using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_MODIFIED_W_COEFFICIENTS.xml' path='doc/member[@name="_NV_MODIFIED_W_COEFFICIENTS"]/*' />
    public partial struct _NV_MODIFIED_W_COEFFICIENTS
    {
        /// <include file='_NV_MODIFIED_W_COEFFICIENTS.xml' path='doc/member[@name="_NV_MODIFIED_W_COEFFICIENTS.fA"]/*' />
        public float fA;

        /// <include file='_NV_MODIFIED_W_COEFFICIENTS.xml' path='doc/member[@name="_NV_MODIFIED_W_COEFFICIENTS.fB"]/*' />
        public float fB;

        /// <include file='_NV_MODIFIED_W_COEFFICIENTS.xml' path='doc/member[@name="_NV_MODIFIED_W_COEFFICIENTS.fAReserved"]/*' />
        public float fAReserved;

        /// <include file='_NV_MODIFIED_W_COEFFICIENTS.xml' path='doc/member[@name="_NV_MODIFIED_W_COEFFICIENTS.fBReserved"]/*' />
        public float fBReserved;

        /// <include file='_NV_MODIFIED_W_COEFFICIENTS.xml' path='doc/member[@name="_NV_MODIFIED_W_COEFFICIENTS.fReserved"]/*' />
        [NativeTypeName("float[2]")]
        public _fReserved_e__FixedBuffer fReserved;

        /// <include file='_fReserved_e__FixedBuffer.xml' path='doc/member[@name="_fReserved_e__FixedBuffer"]/*' />
        [InlineArray(2)]
        public partial struct _fReserved_e__FixedBuffer
        {
            public float e0;
        }
    }
}
