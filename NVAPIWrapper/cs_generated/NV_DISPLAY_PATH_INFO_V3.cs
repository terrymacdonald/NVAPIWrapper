using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NV_DISPLAY_PATH_INFO_V3.xml' path='doc/member[@name="NV_DISPLAY_PATH_INFO_V3"]/*' />
    public partial struct NV_DISPLAY_PATH_INFO_V3
    {
        /// <include file='NV_DISPLAY_PATH_INFO_V3.xml' path='doc/member[@name="NV_DISPLAY_PATH_INFO_V3.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_DISPLAY_PATH_INFO_V3.xml' path='doc/member[@name="NV_DISPLAY_PATH_INFO_V3.count"]/*' />
        [NativeTypeName("NvU32")]
        public uint count;

        /// <include file='NV_DISPLAY_PATH_INFO_V3.xml' path='doc/member[@name="NV_DISPLAY_PATH_INFO_V3.path"]/*' />
        [NativeTypeName("NV_DISPLAY_PATH[2]")]
        public _path_e__FixedBuffer path;

        /// <include file='_path_e__FixedBuffer.xml' path='doc/member[@name="_path_e__FixedBuffer"]/*' />
        [InlineArray(2)]
        public partial struct _path_e__FixedBuffer
        {
            public NV_DISPLAY_PATH e0;
        }
    }
}
