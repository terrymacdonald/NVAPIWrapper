using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NVDRS_BINARY_SETTING.xml' path='doc/member[@name="_NVDRS_BINARY_SETTING"]/*' />
    public partial struct _NVDRS_BINARY_SETTING
    {
        /// <include file='_NVDRS_BINARY_SETTING.xml' path='doc/member[@name="_NVDRS_BINARY_SETTING.valueLength"]/*' />
        [NativeTypeName("NvU32")]
        public uint valueLength;

        /// <include file='_NVDRS_BINARY_SETTING.xml' path='doc/member[@name="_NVDRS_BINARY_SETTING.valueData"]/*' />
        [NativeTypeName("NvU8[4096]")]
        public _valueData_e__FixedBuffer valueData;

        /// <include file='_valueData_e__FixedBuffer.xml' path='doc/member[@name="_valueData_e__FixedBuffer"]/*' />
        [InlineArray(4096)]
        public partial struct _valueData_e__FixedBuffer
        {
            public byte e0;
        }
    }
}
