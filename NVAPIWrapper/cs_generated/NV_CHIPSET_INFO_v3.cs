using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NV_CHIPSET_INFO_v3.xml' path='doc/member[@name="NV_CHIPSET_INFO_v3"]/*' />
    public partial struct NV_CHIPSET_INFO_v3
    {
        /// <include file='NV_CHIPSET_INFO_v3.xml' path='doc/member[@name="NV_CHIPSET_INFO_v3.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_CHIPSET_INFO_v3.xml' path='doc/member[@name="NV_CHIPSET_INFO_v3.vendorId"]/*' />
        [NativeTypeName("NvU32")]
        public uint vendorId;

        /// <include file='NV_CHIPSET_INFO_v3.xml' path='doc/member[@name="NV_CHIPSET_INFO_v3.deviceId"]/*' />
        [NativeTypeName("NvU32")]
        public uint deviceId;

        /// <include file='NV_CHIPSET_INFO_v3.xml' path='doc/member[@name="NV_CHIPSET_INFO_v3.szVendorName"]/*' />
        [NativeTypeName("NvAPI_ShortString")]
        public _szVendorName_e__FixedBuffer szVendorName;

        /// <include file='NV_CHIPSET_INFO_v3.xml' path='doc/member[@name="NV_CHIPSET_INFO_v3.szChipsetName"]/*' />
        [NativeTypeName("NvAPI_ShortString")]
        public _szChipsetName_e__FixedBuffer szChipsetName;

        /// <include file='NV_CHIPSET_INFO_v3.xml' path='doc/member[@name="NV_CHIPSET_INFO_v3.flags"]/*' />
        [NativeTypeName("NvU32")]
        public uint flags;

        /// <include file='NV_CHIPSET_INFO_v3.xml' path='doc/member[@name="NV_CHIPSET_INFO_v3.subSysVendorId"]/*' />
        [NativeTypeName("NvU32")]
        public uint subSysVendorId;

        /// <include file='NV_CHIPSET_INFO_v3.xml' path='doc/member[@name="NV_CHIPSET_INFO_v3.subSysDeviceId"]/*' />
        [NativeTypeName("NvU32")]
        public uint subSysDeviceId;

        /// <include file='NV_CHIPSET_INFO_v3.xml' path='doc/member[@name="NV_CHIPSET_INFO_v3.szSubSysVendorName"]/*' />
        [NativeTypeName("NvAPI_ShortString")]
        public _szSubSysVendorName_e__FixedBuffer szSubSysVendorName;

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

        /// <include file='_szSubSysVendorName_e__FixedBuffer.xml' path='doc/member[@name="_szSubSysVendorName_e__FixedBuffer"]/*' />
        [InlineArray(64)]
        public partial struct _szSubSysVendorName_e__FixedBuffer
        {
            public sbyte e0;
        }
    }
}
