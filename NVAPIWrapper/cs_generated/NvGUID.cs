using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NvGUID.xml' path='doc/member[@name="NvGUID"]/*' />
    public partial struct NvGUID
    {
        /// <include file='NvGUID.xml' path='doc/member[@name="NvGUID.data1"]/*' />
        [NativeTypeName("NvU32")]
        public uint data1;

        /// <include file='NvGUID.xml' path='doc/member[@name="NvGUID.data2"]/*' />
        [NativeTypeName("NvU16")]
        public ushort data2;

        /// <include file='NvGUID.xml' path='doc/member[@name="NvGUID.data3"]/*' />
        [NativeTypeName("NvU16")]
        public ushort data3;

        /// <include file='NvGUID.xml' path='doc/member[@name="NvGUID.data4"]/*' />
        [NativeTypeName("NvU8[8]")]
        public _data4_e__FixedBuffer data4;

        /// <include file='_data4_e__FixedBuffer.xml' path='doc/member[@name="_data4_e__FixedBuffer"]/*' />
        [InlineArray(8)]
        public partial struct _data4_e__FixedBuffer
        {
            public byte e0;
        }
    }
}
