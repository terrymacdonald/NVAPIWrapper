using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NVDRS_APPLICATION_V3.xml' path='doc/member[@name="_NVDRS_APPLICATION_V3"]/*' />
    public partial struct _NVDRS_APPLICATION_V3
    {
        /// <include file='_NVDRS_APPLICATION_V3.xml' path='doc/member[@name="_NVDRS_APPLICATION_V3.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NVDRS_APPLICATION_V3.xml' path='doc/member[@name="_NVDRS_APPLICATION_V3.isPredefined"]/*' />
        [NativeTypeName("NvU32")]
        public uint isPredefined;

        /// <include file='_NVDRS_APPLICATION_V3.xml' path='doc/member[@name="_NVDRS_APPLICATION_V3.appName"]/*' />
        [NativeTypeName("NvAPI_UnicodeString")]
        public _appName_e__FixedBuffer appName;

        /// <include file='_NVDRS_APPLICATION_V3.xml' path='doc/member[@name="_NVDRS_APPLICATION_V3.userFriendlyName"]/*' />
        [NativeTypeName("NvAPI_UnicodeString")]
        public _userFriendlyName_e__FixedBuffer userFriendlyName;

        /// <include file='_NVDRS_APPLICATION_V3.xml' path='doc/member[@name="_NVDRS_APPLICATION_V3.launcher"]/*' />
        [NativeTypeName("NvAPI_UnicodeString")]
        public _launcher_e__FixedBuffer launcher;

        /// <include file='_NVDRS_APPLICATION_V3.xml' path='doc/member[@name="_NVDRS_APPLICATION_V3.fileInFolder"]/*' />
        [NativeTypeName("NvAPI_UnicodeString")]
        public _fileInFolder_e__FixedBuffer fileInFolder;

        public uint _bitfield;

        /// <include file='_NVDRS_APPLICATION_V3.xml' path='doc/member[@name="_NVDRS_APPLICATION_V3.isMetro"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isMetro
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

        /// <include file='_NVDRS_APPLICATION_V3.xml' path='doc/member[@name="_NVDRS_APPLICATION_V3.isCommandLine"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isCommandLine
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

        /// <include file='_NVDRS_APPLICATION_V3.xml' path='doc/member[@name="_NVDRS_APPLICATION_V3.reserved"]/*' />
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
