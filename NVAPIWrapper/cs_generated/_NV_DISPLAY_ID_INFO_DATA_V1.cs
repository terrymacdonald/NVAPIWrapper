using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_DISPLAY_ID_INFO_DATA_V1.xml' path='doc/member[@name="_NV_DISPLAY_ID_INFO_DATA_V1"]/*' />
    public partial struct _NV_DISPLAY_ID_INFO_DATA_V1
    {
        /// <include file='_NV_DISPLAY_ID_INFO_DATA_V1.xml' path='doc/member[@name="_NV_DISPLAY_ID_INFO_DATA_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_DISPLAY_ID_INFO_DATA_V1.xml' path='doc/member[@name="_NV_DISPLAY_ID_INFO_DATA_V1.adapterId"]/*' />
        [NativeTypeName("LUID")]
        public _LUID adapterId;

        /// <include file='_NV_DISPLAY_ID_INFO_DATA_V1.xml' path='doc/member[@name="_NV_DISPLAY_ID_INFO_DATA_V1.targetId"]/*' />
        [NativeTypeName("NvU32")]
        public uint targetId;

        /// <include file='_NV_DISPLAY_ID_INFO_DATA_V1.xml' path='doc/member[@name="_NV_DISPLAY_ID_INFO_DATA_V1.reserved"]/*' />
        [NativeTypeName("NvU32[4]")]
        public _reserved_e__FixedBuffer reserved;

        /// <include file='_reserved_e__FixedBuffer.xml' path='doc/member[@name="_reserved_e__FixedBuffer"]/*' />
        [InlineArray(4)]
        public partial struct _reserved_e__FixedBuffer
        {
            public uint e0;
        }
    }
}
