using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_TARGET_INFO_DATA_V1.xml' path='doc/member[@name="_NV_TARGET_INFO_DATA_V1"]/*' />
    public partial struct _NV_TARGET_INFO_DATA_V1
    {
        /// <include file='_NV_TARGET_INFO_DATA_V1.xml' path='doc/member[@name="_NV_TARGET_INFO_DATA_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_TARGET_INFO_DATA_V1.xml' path='doc/member[@name="_NV_TARGET_INFO_DATA_V1.adapterId"]/*' />
        [NativeTypeName("LUID")]
        public _LUID adapterId;

        /// <include file='_NV_TARGET_INFO_DATA_V1.xml' path='doc/member[@name="_NV_TARGET_INFO_DATA_V1.targetId"]/*' />
        [NativeTypeName("NvU32")]
        public uint targetId;

        /// <include file='_NV_TARGET_INFO_DATA_V1.xml' path='doc/member[@name="_NV_TARGET_INFO_DATA_V1.displayId"]/*' />
        [NativeTypeName("NvU32[128]")]
        public _displayId_e__FixedBuffer displayId;

        /// <include file='_NV_TARGET_INFO_DATA_V1.xml' path='doc/member[@name="_NV_TARGET_INFO_DATA_V1.displayIdCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint displayIdCount;

        /// <include file='_NV_TARGET_INFO_DATA_V1.xml' path='doc/member[@name="_NV_TARGET_INFO_DATA_V1.reserved"]/*' />
        [NativeTypeName("NvU32[4]")]
        public _reserved_e__FixedBuffer reserved;

        /// <include file='_displayId_e__FixedBuffer.xml' path='doc/member[@name="_displayId_e__FixedBuffer"]/*' />
        [InlineArray(128)]
        public partial struct _displayId_e__FixedBuffer
        {
            public uint e0;
        }

        /// <include file='_reserved_e__FixedBuffer.xml' path='doc/member[@name="_reserved_e__FixedBuffer"]/*' />
        [InlineArray(4)]
        public partial struct _reserved_e__FixedBuffer
        {
            public uint e0;
        }
    }
}
