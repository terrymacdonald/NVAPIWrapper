using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NV_EDID_V1.xml' path='doc/member[@name="NV_EDID_V1"]/*' />
    public partial struct NV_EDID_V1
    {
        /// <include file='NV_EDID_V1.xml' path='doc/member[@name="NV_EDID_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_EDID_V1.xml' path='doc/member[@name="NV_EDID_V1.EDID_Data"]/*' />
        [NativeTypeName("NvU8[256]")]
        public _EDID_Data_e__FixedBuffer EDID_Data;

        /// <include file='_EDID_Data_e__FixedBuffer.xml' path='doc/member[@name="_EDID_Data_e__FixedBuffer"]/*' />
        [InlineArray(256)]
        public partial struct _EDID_Data_e__FixedBuffer
        {
            public byte e0;
        }
    }
}
