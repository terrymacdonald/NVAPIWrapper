using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NV_EDID_V3.xml' path='doc/member[@name="NV_EDID_V3"]/*' />
    public partial struct NV_EDID_V3
    {
        /// <include file='NV_EDID_V3.xml' path='doc/member[@name="NV_EDID_V3.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_EDID_V3.xml' path='doc/member[@name="NV_EDID_V3.EDID_Data"]/*' />
        [NativeTypeName("NvU8[256]")]
        public _EDID_Data_e__FixedBuffer EDID_Data;

        /// <include file='NV_EDID_V3.xml' path='doc/member[@name="NV_EDID_V3.sizeofEDID"]/*' />
        [NativeTypeName("NvU32")]
        public uint sizeofEDID;

        /// <include file='NV_EDID_V3.xml' path='doc/member[@name="NV_EDID_V3.edidId"]/*' />
        [NativeTypeName("NvU32")]
        public uint edidId;

        /// <include file='NV_EDID_V3.xml' path='doc/member[@name="NV_EDID_V3.offset"]/*' />
        [NativeTypeName("NvU32")]
        public uint offset;

        /// <include file='_EDID_Data_e__FixedBuffer.xml' path='doc/member[@name="_EDID_Data_e__FixedBuffer"]/*' />
        [InlineArray(256)]
        public partial struct _EDID_Data_e__FixedBuffer
        {
            public byte e0;
        }
    }
}
