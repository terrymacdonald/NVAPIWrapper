using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_LICENSABLE_FEATURES_V3.xml' path='doc/member[@name="_NV_LICENSABLE_FEATURES_V3"]/*' />
    public partial struct _NV_LICENSABLE_FEATURES_V3
    {
        /// <include file='_NV_LICENSABLE_FEATURES_V3.xml' path='doc/member[@name="_NV_LICENSABLE_FEATURES_V3.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        public uint _bitfield;

        /// <include file='_NV_LICENSABLE_FEATURES_V3.xml' path='doc/member[@name="_NV_LICENSABLE_FEATURES_V3.isLicenseSupported"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isLicenseSupported
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

        /// <include file='_NV_LICENSABLE_FEATURES_V3.xml' path='doc/member[@name="_NV_LICENSABLE_FEATURES_V3.reserved"]/*' />
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

        /// <include file='_NV_LICENSABLE_FEATURES_V3.xml' path='doc/member[@name="_NV_LICENSABLE_FEATURES_V3.licensableFeatureCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint licensableFeatureCount;

        /// <include file='_NV_LICENSABLE_FEATURES_V3.xml' path='doc/member[@name="_NV_LICENSABLE_FEATURES_V3.signature"]/*' />
        [NativeTypeName("NvU8[128]")]
        public _signature_e__FixedBuffer signature;

        /// <include file='_NV_LICENSABLE_FEATURES_V3.xml' path='doc/member[@name="_NV_LICENSABLE_FEATURES_V3.licenseDetails"]/*' />
        [NativeTypeName("NV_LICENSE_FEATURE_DETAILS_V3[3]")]
        public _licenseDetails_e__FixedBuffer licenseDetails;

        /// <include file='_signature_e__FixedBuffer.xml' path='doc/member[@name="_signature_e__FixedBuffer"]/*' />
        [InlineArray(128)]
        public partial struct _signature_e__FixedBuffer
        {
            public byte e0;
        }

        /// <include file='_licenseDetails_e__FixedBuffer.xml' path='doc/member[@name="_licenseDetails_e__FixedBuffer"]/*' />
        [InlineArray(3)]
        public partial struct _licenseDetails_e__FixedBuffer
        {
            public _NV_LICENSE_FEATURE_DETAILS_V3 e0;
        }
    }
}
