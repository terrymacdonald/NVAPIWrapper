using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_EDID_DATA_V2.xml' path='doc/member[@name="_NV_EDID_DATA_V2"]/*' />
    public unsafe partial struct _NV_EDID_DATA_V2
    {
        /// <include file='_NV_EDID_DATA_V2.xml' path='doc/member[@name="_NV_EDID_DATA_V2.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_EDID_DATA_V2.xml' path='doc/member[@name="_NV_EDID_DATA_V2.pEDID"]/*' />
        [NativeTypeName("NvU8 *")]
        public byte* pEDID;

        /// <include file='_NV_EDID_DATA_V2.xml' path='doc/member[@name="_NV_EDID_DATA_V2.sizeOfEDID"]/*' />
        [NativeTypeName("NvU32")]
        public uint sizeOfEDID;

        /// <include file='_NV_EDID_DATA_V2.xml' path='doc/member[@name="_NV_EDID_DATA_V2.reserved"]/*' />
        [NativeTypeName("NvU32[8]")]
        public _reserved_e__FixedBuffer reserved;

        /// <include file='_reserved_e__FixedBuffer.xml' path='doc/member[@name="_reserved_e__FixedBuffer"]/*' />
        [InlineArray(8)]
        public partial struct _reserved_e__FixedBuffer
        {
            public uint e0;
        }
    }
}
