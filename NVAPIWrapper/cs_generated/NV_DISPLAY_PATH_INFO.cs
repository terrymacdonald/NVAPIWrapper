using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NV_DISPLAY_PATH_INFO.xml' path='doc/member[@name="NV_DISPLAY_PATH_INFO"]/*' />
    public partial struct NV_DISPLAY_PATH_INFO
    {
        /// <include file='NV_DISPLAY_PATH_INFO.xml' path='doc/member[@name="NV_DISPLAY_PATH_INFO.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_DISPLAY_PATH_INFO.xml' path='doc/member[@name="NV_DISPLAY_PATH_INFO.count"]/*' />
        [NativeTypeName("NvU32")]
        public uint count;

        /// <include file='NV_DISPLAY_PATH_INFO.xml' path='doc/member[@name="NV_DISPLAY_PATH_INFO.path"]/*' />
        [NativeTypeName("NV_DISPLAY_PATH[4]")]
        public _path_e__FixedBuffer path;

        /// <include file='_path_e__FixedBuffer.xml' path='doc/member[@name="_path_e__FixedBuffer"]/*' />
        [InlineArray(4)]
        public partial struct _path_e__FixedBuffer
        {
            public NV_DISPLAY_PATH e0;
        }
    }
}
