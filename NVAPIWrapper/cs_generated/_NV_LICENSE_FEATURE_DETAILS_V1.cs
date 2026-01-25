using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_LICENSE_FEATURE_DETAILS_V1.xml' path='doc/member[@name="_NV_LICENSE_FEATURE_DETAILS_V1"]/*' />
    public partial struct _NV_LICENSE_FEATURE_DETAILS_V1
    {
        /// <include file='_NV_LICENSE_FEATURE_DETAILS_V1.xml' path='doc/member[@name="_NV_LICENSE_FEATURE_DETAILS_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        public uint _bitfield;

        /// <include file='_NV_LICENSE_FEATURE_DETAILS_V1.xml' path='doc/member[@name="_NV_LICENSE_FEATURE_DETAILS_V1.isEnabled"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isEnabled
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

        /// <include file='_NV_LICENSE_FEATURE_DETAILS_V1.xml' path='doc/member[@name="_NV_LICENSE_FEATURE_DETAILS_V1.reserved"]/*' />
        [NativeTypeName("NvU32 : 31")]
        public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x7FFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x7FFFFFFFu << 1)) | ((value & 0x7FFFFFFFu) << 1);
            }
        }

        /// <include file='_NV_LICENSE_FEATURE_DETAILS_V1.xml' path='doc/member[@name="_NV_LICENSE_FEATURE_DETAILS_V1.featureCode"]/*' />
        [NativeTypeName("NV_LICENSE_FEATURE_TYPE")]
        public _NV_LICENSE_FEATURE_TYPE featureCode;

        /// <include file='_NV_LICENSE_FEATURE_DETAILS_V1.xml' path='doc/member[@name="_NV_LICENSE_FEATURE_DETAILS_V1.licenseInfo"]/*' />
        [NativeTypeName("NvAPI_LicenseString")]
        public _licenseInfo_e__FixedBuffer licenseInfo;

        /// <include file='_licenseInfo_e__FixedBuffer.xml' path='doc/member[@name="_licenseInfo_e__FixedBuffer"]/*' />
        [InlineArray(128)]
        public partial struct _licenseInfo_e__FixedBuffer
        {
            public sbyte e0;
        }
    }
}
