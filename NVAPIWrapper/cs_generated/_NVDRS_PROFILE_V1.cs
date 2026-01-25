using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NVDRS_PROFILE_V1.xml' path='doc/member[@name="_NVDRS_PROFILE_V1"]/*' />
    public partial struct _NVDRS_PROFILE_V1
    {
        /// <include file='_NVDRS_PROFILE_V1.xml' path='doc/member[@name="_NVDRS_PROFILE_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NVDRS_PROFILE_V1.xml' path='doc/member[@name="_NVDRS_PROFILE_V1.profileName"]/*' />
        [NativeTypeName("NvAPI_UnicodeString")]
        public _profileName_e__FixedBuffer profileName;

        /// <include file='_NVDRS_PROFILE_V1.xml' path='doc/member[@name="_NVDRS_PROFILE_V1.gpuSupport"]/*' />
        [NativeTypeName("NVDRS_GPU_SUPPORT")]
        public _NVDRS_GPU_SUPPORT gpuSupport;

        /// <include file='_NVDRS_PROFILE_V1.xml' path='doc/member[@name="_NVDRS_PROFILE_V1.isPredefined"]/*' />
        [NativeTypeName("NvU32")]
        public uint isPredefined;

        /// <include file='_NVDRS_PROFILE_V1.xml' path='doc/member[@name="_NVDRS_PROFILE_V1.numOfApps"]/*' />
        [NativeTypeName("NvU32")]
        public uint numOfApps;

        /// <include file='_NVDRS_PROFILE_V1.xml' path='doc/member[@name="_NVDRS_PROFILE_V1.numOfSettings"]/*' />
        [NativeTypeName("NvU32")]
        public uint numOfSettings;

        /// <include file='_profileName_e__FixedBuffer.xml' path='doc/member[@name="_profileName_e__FixedBuffer"]/*' />
        [InlineArray(2048)]
        public partial struct _profileName_e__FixedBuffer
        {
            public ushort e0;
        }
    }
}
