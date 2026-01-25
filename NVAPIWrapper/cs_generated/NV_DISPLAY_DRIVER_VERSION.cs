using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NV_DISPLAY_DRIVER_VERSION.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_VERSION"]/*' />
    public partial struct NV_DISPLAY_DRIVER_VERSION
    {
        /// <include file='NV_DISPLAY_DRIVER_VERSION.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_VERSION.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_DISPLAY_DRIVER_VERSION.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_VERSION.drvVersion"]/*' />
        [NativeTypeName("NvU32")]
        public uint drvVersion;

        /// <include file='NV_DISPLAY_DRIVER_VERSION.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_VERSION.bldChangeListNum"]/*' />
        [NativeTypeName("NvU32")]
        public uint bldChangeListNum;

        /// <include file='NV_DISPLAY_DRIVER_VERSION.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_VERSION.szBuildBranchString"]/*' />
        [NativeTypeName("NvAPI_ShortString")]
        public _szBuildBranchString_e__FixedBuffer szBuildBranchString;

        /// <include file='NV_DISPLAY_DRIVER_VERSION.xml' path='doc/member[@name="NV_DISPLAY_DRIVER_VERSION.szAdapterString"]/*' />
        [NativeTypeName("NvAPI_ShortString")]
        public _szAdapterString_e__FixedBuffer szAdapterString;

        /// <include file='_szBuildBranchString_e__FixedBuffer.xml' path='doc/member[@name="_szBuildBranchString_e__FixedBuffer"]/*' />
        [InlineArray(64)]
        public partial struct _szBuildBranchString_e__FixedBuffer
        {
            public sbyte e0;
        }

        /// <include file='_szAdapterString_e__FixedBuffer.xml' path='doc/member[@name="_szAdapterString_e__FixedBuffer"]/*' />
        [InlineArray(64)]
        public partial struct _szAdapterString_e__FixedBuffer
        {
            public sbyte e0;
        }
    }
}
