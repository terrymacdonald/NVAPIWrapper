using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NVVIOINPUTCONFIG.xml' path='doc/member[@name="_NVVIOINPUTCONFIG"]/*' />
    public partial struct _NVVIOINPUTCONFIG
    {
        /// <include file='_NVVIOINPUTCONFIG.xml' path='doc/member[@name="_NVVIOINPUTCONFIG.numRawCaptureImages"]/*' />
        [NativeTypeName("NvU32")]
        public uint numRawCaptureImages;

        /// <include file='_NVVIOINPUTCONFIG.xml' path='doc/member[@name="_NVVIOINPUTCONFIG.signalFormat"]/*' />
        [NativeTypeName("NVVIOSIGNALFORMAT")]
        public _NVVIOSIGNALFORMAT signalFormat;

        /// <include file='_NVVIOINPUTCONFIG.xml' path='doc/member[@name="_NVVIOINPUTCONFIG.numStreams"]/*' />
        [NativeTypeName("NvU32")]
        public uint numStreams;

        /// <include file='_NVVIOINPUTCONFIG.xml' path='doc/member[@name="_NVVIOINPUTCONFIG.streams"]/*' />
        [NativeTypeName("NVVIOSTREAM[4]")]
        public _streams_e__FixedBuffer streams;

        /// <include file='_NVVIOINPUTCONFIG.xml' path='doc/member[@name="_NVVIOINPUTCONFIG.bTestMode"]/*' />
        [NativeTypeName("NvU32")]
        public uint bTestMode;

        /// <include file='_streams_e__FixedBuffer.xml' path='doc/member[@name="_streams_e__FixedBuffer"]/*' />
        [InlineArray(4)]
        public partial struct _streams_e__FixedBuffer
        {
            public _NVVIOSTREAM e0;
        }
    }
}
