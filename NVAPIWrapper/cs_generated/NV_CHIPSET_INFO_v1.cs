using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NV_CHIPSET_INFO_v1.xml' path='doc/member[@name="NV_CHIPSET_INFO_v1"]/*' />
    public partial struct NV_CHIPSET_INFO_v1
    {
        /// <include file='NV_CHIPSET_INFO_v1.xml' path='doc/member[@name="NV_CHIPSET_INFO_v1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_CHIPSET_INFO_v1.xml' path='doc/member[@name="NV_CHIPSET_INFO_v1.vendorId"]/*' />
        [NativeTypeName("NvU32")]
        public uint vendorId;

        /// <include file='NV_CHIPSET_INFO_v1.xml' path='doc/member[@name="NV_CHIPSET_INFO_v1.deviceId"]/*' />
        [NativeTypeName("NvU32")]
        public uint deviceId;

        /// <include file='NV_CHIPSET_INFO_v1.xml' path='doc/member[@name="NV_CHIPSET_INFO_v1.szVendorName"]/*' />
        [NativeTypeName("NvAPI_ShortString")]
        public _szVendorName_e__FixedBuffer szVendorName;

        /// <include file='NV_CHIPSET_INFO_v1.xml' path='doc/member[@name="NV_CHIPSET_INFO_v1.szChipsetName"]/*' />
        [NativeTypeName("NvAPI_ShortString")]
        public _szChipsetName_e__FixedBuffer szChipsetName;

        /// <include file='_szVendorName_e__FixedBuffer.xml' path='doc/member[@name="_szVendorName_e__FixedBuffer"]/*' />
        [InlineArray(64)]
        public partial struct _szVendorName_e__FixedBuffer
        {
            public sbyte e0;
        }

        /// <include file='_szChipsetName_e__FixedBuffer.xml' path='doc/member[@name="_szChipsetName_e__FixedBuffer"]/*' />
        [InlineArray(64)]
        public partial struct _szChipsetName_e__FixedBuffer
        {
            public sbyte e0;
        }
    }
}
