using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_BOARD_INFO.xml' path='doc/member[@name="_NV_BOARD_INFO"]/*' />
    public partial struct _NV_BOARD_INFO
    {
        /// <include file='_NV_BOARD_INFO.xml' path='doc/member[@name="_NV_BOARD_INFO.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_BOARD_INFO.xml' path='doc/member[@name="_NV_BOARD_INFO.BoardNum"]/*' />
        [NativeTypeName("NvU8[16]")]
        public _BoardNum_e__FixedBuffer BoardNum;

        /// <include file='_BoardNum_e__FixedBuffer.xml' path='doc/member[@name="_BoardNum_e__FixedBuffer"]/*' />
        [InlineArray(16)]
        public partial struct _BoardNum_e__FixedBuffer
        {
            public byte e0;
        }
    }
}
