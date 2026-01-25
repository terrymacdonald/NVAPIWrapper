using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_LICENSE_FEATURE_DETAILS_V3.xml' path='doc/member[@name="_NV_LICENSE_FEATURE_DETAILS_V3"]/*' />
    public partial struct _NV_LICENSE_FEATURE_DETAILS_V3
    {
        /// <include file='_NV_LICENSE_FEATURE_DETAILS_V3.xml' path='doc/member[@name="_NV_LICENSE_FEATURE_DETAILS_V3.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        public uint _bitfield;

        /// <include file='_NV_LICENSE_FEATURE_DETAILS_V3.xml' path='doc/member[@name="_NV_LICENSE_FEATURE_DETAILS_V3.isEnabled"]/*' />
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

        /// <include file='_NV_LICENSE_FEATURE_DETAILS_V3.xml' path='doc/member[@name="_NV_LICENSE_FEATURE_DETAILS_V3.isFeatureEnabled"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isFeatureEnabled
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

        /// <include file='_NV_LICENSE_FEATURE_DETAILS_V3.xml' path='doc/member[@name="_NV_LICENSE_FEATURE_DETAILS_V3.reserved"]/*' />
        [NativeTypeName("NvU32 : 30")]
        public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x3FFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x3FFFFFFFu << 2)) | ((value & 0x3FFFFFFFu) << 2);
            }
        }

        /// <include file='_NV_LICENSE_FEATURE_DETAILS_V3.xml' path='doc/member[@name="_NV_LICENSE_FEATURE_DETAILS_V3.featureCode"]/*' />
        [NativeTypeName("NV_LICENSE_FEATURE_TYPE")]
        public _NV_LICENSE_FEATURE_TYPE featureCode;

        /// <include file='_NV_LICENSE_FEATURE_DETAILS_V3.xml' path='doc/member[@name="_NV_LICENSE_FEATURE_DETAILS_V3.licenseInfo"]/*' />
        [NativeTypeName("NvAPI_LicenseString")]
        public _licenseInfo_e__FixedBuffer licenseInfo;

        /// <include file='_NV_LICENSE_FEATURE_DETAILS_V3.xml' path='doc/member[@name="_NV_LICENSE_FEATURE_DETAILS_V3.productName"]/*' />
        [NativeTypeName("NvAPI_LicenseString")]
        public _productName_e__FixedBuffer productName;

        /// <include file='_licenseInfo_e__FixedBuffer.xml' path='doc/member[@name="_licenseInfo_e__FixedBuffer"]/*' />
        [InlineArray(128)]
        public partial struct _licenseInfo_e__FixedBuffer
        {
            public sbyte e0;
        }

        /// <include file='_productName_e__FixedBuffer.xml' path='doc/member[@name="_productName_e__FixedBuffer"]/*' />
        [InlineArray(128)]
        public partial struct _productName_e__FixedBuffer
        {
            public sbyte e0;
        }
    }
}
