using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NVVIOINPUTSTATUS.xml' path='doc/member[@name="_NVVIOINPUTSTATUS"]/*' />
    public partial struct _NVVIOINPUTSTATUS
    {
        /// <include file='_NVVIOINPUTSTATUS.xml' path='doc/member[@name="_NVVIOINPUTSTATUS.vidIn"]/*' />
        [NativeTypeName("NVVIOCHANNELSTATUS[4][2]")]
        public _vidIn_e__FixedBuffer vidIn;

        /// <include file='_NVVIOINPUTSTATUS.xml' path='doc/member[@name="_NVVIOINPUTSTATUS.captureStatus"]/*' />
        [NativeTypeName("NVVIOCAPTURESTATUS")]
        public _NVVIOCAPTURESTATUS captureStatus;

        /// <include file='_vidIn_e__FixedBuffer.xml' path='doc/member[@name="_vidIn_e__FixedBuffer"]/*' />
        [InlineArray(4 * 2)]
        public partial struct _vidIn_e__FixedBuffer
        {
            public _NVVIOCHANNELSTATUS e0_0;
        }
    }
}
