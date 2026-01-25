using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <include file='_NVVIOGAMMACORRECTION.xml' path='doc/member[@name="_NVVIOGAMMACORRECTION"]/*' />
    public partial struct _NVVIOGAMMACORRECTION
    {
        /// <include file='_NVVIOGAMMACORRECTION.xml' path='doc/member[@name="_NVVIOGAMMACORRECTION.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NVVIOGAMMACORRECTION.xml' path='doc/member[@name="_NVVIOGAMMACORRECTION.vioGammaCorrectionType"]/*' />
        [NativeTypeName("NvU32")]
        public uint vioGammaCorrectionType;

        /// <include file='_NVVIOGAMMACORRECTION.xml' path='doc/member[@name="_NVVIOGAMMACORRECTION.gammaRamp"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L21887_C5")]
        public _gammaRamp_e__Union gammaRamp;

        /// <include file='_NVVIOGAMMACORRECTION.xml' path='doc/member[@name="_NVVIOGAMMACORRECTION.fGammaValueR"]/*' />
        public float fGammaValueR;

        /// <include file='_NVVIOGAMMACORRECTION.xml' path='doc/member[@name="_NVVIOGAMMACORRECTION.fGammaValueG"]/*' />
        public float fGammaValueG;

        /// <include file='_NVVIOGAMMACORRECTION.xml' path='doc/member[@name="_NVVIOGAMMACORRECTION.fGammaValueB"]/*' />
        public float fGammaValueB;

        /// <include file='_gammaRamp_e__Union.xml' path='doc/member[@name="_gammaRamp_e__Union"]/*' />
        [StructLayout(LayoutKind.Explicit)]
        public partial struct _gammaRamp_e__Union
        {
            /// <include file='_gammaRamp_e__Union.xml' path='doc/member[@name="_gammaRamp_e__Union.gammaRamp8"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NVVIOGAMMARAMP8")]
            public _NVVIOGAMMARAMP8 gammaRamp8;

            /// <include file='_gammaRamp_e__Union.xml' path='doc/member[@name="_gammaRamp_e__Union.gammaRamp10"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NVVIOGAMMARAMP10")]
            public _NVVIOGAMMARAMP10 gammaRamp10;
        }
    }
}
