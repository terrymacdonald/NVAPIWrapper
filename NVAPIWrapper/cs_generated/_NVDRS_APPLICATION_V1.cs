using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NVDRS_APPLICATION_V1.xml' path='doc/member[@name="_NVDRS_APPLICATION_V1"]/*' />
    public partial struct _NVDRS_APPLICATION_V1
    {
        /// <include file='_NVDRS_APPLICATION_V1.xml' path='doc/member[@name="_NVDRS_APPLICATION_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NVDRS_APPLICATION_V1.xml' path='doc/member[@name="_NVDRS_APPLICATION_V1.isPredefined"]/*' />
        [NativeTypeName("NvU32")]
        public uint isPredefined;

        /// <include file='_NVDRS_APPLICATION_V1.xml' path='doc/member[@name="_NVDRS_APPLICATION_V1.appName"]/*' />
        [NativeTypeName("NvAPI_UnicodeString")]
        public _appName_e__FixedBuffer appName;

        /// <include file='_NVDRS_APPLICATION_V1.xml' path='doc/member[@name="_NVDRS_APPLICATION_V1.userFriendlyName"]/*' />
        [NativeTypeName("NvAPI_UnicodeString")]
        public _userFriendlyName_e__FixedBuffer userFriendlyName;

        /// <include file='_NVDRS_APPLICATION_V1.xml' path='doc/member[@name="_NVDRS_APPLICATION_V1.launcher"]/*' />
        [NativeTypeName("NvAPI_UnicodeString")]
        public _launcher_e__FixedBuffer launcher;

        /// <include file='_appName_e__FixedBuffer.xml' path='doc/member[@name="_appName_e__FixedBuffer"]/*' />
        [InlineArray(2048)]
        public partial struct _appName_e__FixedBuffer
        {
            public ushort e0;
        }

        /// <include file='_userFriendlyName_e__FixedBuffer.xml' path='doc/member[@name="_userFriendlyName_e__FixedBuffer"]/*' />
        [InlineArray(2048)]
        public partial struct _userFriendlyName_e__FixedBuffer
        {
            public ushort e0;
        }

        /// <include file='_launcher_e__FixedBuffer.xml' path='doc/member[@name="_launcher_e__FixedBuffer"]/*' />
        [InlineArray(2048)]
        public partial struct _launcher_e__FixedBuffer
        {
            public ushort e0;
        }
    }
}
