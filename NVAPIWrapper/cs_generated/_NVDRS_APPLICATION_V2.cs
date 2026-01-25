using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NVDRS_APPLICATION_V2.xml' path='doc/member[@name="_NVDRS_APPLICATION_V2"]/*' />
    public partial struct _NVDRS_APPLICATION_V2
    {
        /// <include file='_NVDRS_APPLICATION_V2.xml' path='doc/member[@name="_NVDRS_APPLICATION_V2.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NVDRS_APPLICATION_V2.xml' path='doc/member[@name="_NVDRS_APPLICATION_V2.isPredefined"]/*' />
        [NativeTypeName("NvU32")]
        public uint isPredefined;

        /// <include file='_NVDRS_APPLICATION_V2.xml' path='doc/member[@name="_NVDRS_APPLICATION_V2.appName"]/*' />
        [NativeTypeName("NvAPI_UnicodeString")]
        public _appName_e__FixedBuffer appName;

        /// <include file='_NVDRS_APPLICATION_V2.xml' path='doc/member[@name="_NVDRS_APPLICATION_V2.userFriendlyName"]/*' />
        [NativeTypeName("NvAPI_UnicodeString")]
        public _userFriendlyName_e__FixedBuffer userFriendlyName;

        /// <include file='_NVDRS_APPLICATION_V2.xml' path='doc/member[@name="_NVDRS_APPLICATION_V2.launcher"]/*' />
        [NativeTypeName("NvAPI_UnicodeString")]
        public _launcher_e__FixedBuffer launcher;

        /// <include file='_NVDRS_APPLICATION_V2.xml' path='doc/member[@name="_NVDRS_APPLICATION_V2.fileInFolder"]/*' />
        [NativeTypeName("NvAPI_UnicodeString")]
        public _fileInFolder_e__FixedBuffer fileInFolder;

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

        /// <include file='_fileInFolder_e__FixedBuffer.xml' path='doc/member[@name="_fileInFolder_e__FixedBuffer"]/*' />
        [InlineArray(2048)]
        public partial struct _fileInFolder_e__FixedBuffer
        {
            public ushort e0;
        }
    }
}
