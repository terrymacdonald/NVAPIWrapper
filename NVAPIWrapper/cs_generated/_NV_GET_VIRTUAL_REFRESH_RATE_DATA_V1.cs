using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V1.xml' path='doc/member[@name="_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V1"]/*' />
    public partial struct _NV_GET_VIRTUAL_REFRESH_RATE_DATA_V1
    {
        /// <include file='_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V1.xml' path='doc/member[@name="_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V1.xml' path='doc/member[@name="_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V1.frameIntervalUs"]/*' />
        [NativeTypeName("NvU32")]
        public uint frameIntervalUs;

        /// <include file='_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V1.xml' path='doc/member[@name="_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V1.rrx1k"]/*' />
        [NativeTypeName("NvU32")]
        public uint rrx1k;

        /// <include file='_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V1.xml' path='doc/member[@name="_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V1.bIsGamingVrr"]/*' />
        [NativeTypeName("NvU32")]
        public uint bIsGamingVrr;

        /// <include file='_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V1.xml' path='doc/member[@name="_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V1.reservedEx"]/*' />
        [NativeTypeName("NvU32[6]")]
        public _reservedEx_e__FixedBuffer reservedEx;

        /// <include file='_reservedEx_e__FixedBuffer.xml' path='doc/member[@name="_reservedEx_e__FixedBuffer"]/*' />
        [InlineArray(6)]
        public partial struct _reservedEx_e__FixedBuffer
        {
            public uint e0;
        }
    }
}
