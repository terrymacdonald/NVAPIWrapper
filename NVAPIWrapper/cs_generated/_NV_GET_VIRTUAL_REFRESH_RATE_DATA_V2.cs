using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V2.xml' path='doc/member[@name="_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V2"]/*' />
    public partial struct _NV_GET_VIRTUAL_REFRESH_RATE_DATA_V2
    {
        /// <include file='_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V2.xml' path='doc/member[@name="_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V2.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V2.xml' path='doc/member[@name="_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V2.frameIntervalUs"]/*' />
        [NativeTypeName("NvU32")]
        public uint frameIntervalUs;

        /// <include file='_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V2.xml' path='doc/member[@name="_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V2.rrx1k"]/*' />
        [NativeTypeName("NvU32")]
        public uint rrx1k;

        /// <include file='_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V2.xml' path='doc/member[@name="_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V2.bIsGamingVrr"]/*' />
        [NativeTypeName("NvU32")]
        public uint bIsGamingVrr;

        /// <include file='_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V2.xml' path='doc/member[@name="_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V2.frameIntervalNs"]/*' />
        [NativeTypeName("NvU64")]
        public ulong frameIntervalNs;

        /// <include file='_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V2.xml' path='doc/member[@name="_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V2.reservedEx"]/*' />
        [NativeTypeName("NvU32[4]")]
        public _reservedEx_e__FixedBuffer reservedEx;

        /// <include file='_reservedEx_e__FixedBuffer.xml' path='doc/member[@name="_reservedEx_e__FixedBuffer"]/*' />
        [InlineArray(4)]
        public partial struct _reservedEx_e__FixedBuffer
        {
            public uint e0;
        }
    }
}
