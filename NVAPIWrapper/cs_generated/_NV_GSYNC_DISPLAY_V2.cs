using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_GSYNC_DISPLAY_V2.xml' path='doc/member[@name="_NV_GSYNC_DISPLAY_V2"]/*' />
    public partial struct _NV_GSYNC_DISPLAY_V2
    {
        /// <include file='_NV_GSYNC_DISPLAY_V2.xml' path='doc/member[@name="_NV_GSYNC_DISPLAY_V2.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_GSYNC_DISPLAY_V2.xml' path='doc/member[@name="_NV_GSYNC_DISPLAY_V2.displayId"]/*' />
        [NativeTypeName("NvU32")]
        public uint displayId;

        public uint _bitfield;

        /// <include file='_NV_GSYNC_DISPLAY_V2.xml' path='doc/member[@name="_NV_GSYNC_DISPLAY_V2.isMasterable"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isMasterable
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

        /// <include file='_NV_GSYNC_DISPLAY_V2.xml' path='doc/member[@name="_NV_GSYNC_DISPLAY_V2.useExactTiming"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint useExactTiming
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

        /// <include file='_NV_GSYNC_DISPLAY_V2.xml' path='doc/member[@name="_NV_GSYNC_DISPLAY_V2.reserved"]/*' />
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

        /// <include file='_NV_GSYNC_DISPLAY_V2.xml' path='doc/member[@name="_NV_GSYNC_DISPLAY_V2.syncState"]/*' />
        [NativeTypeName("NVAPI_GSYNC_DISPLAY_SYNC_STATE")]
        public _NVAPI_GSYNC_DISPLAY_SYNC_STATE syncState;

        /// <include file='_NV_GSYNC_DISPLAY_V2.xml' path='doc/member[@name="_NV_GSYNC_DISPLAY_V2.reserved2"]/*' />
        [NativeTypeName("NvU32[20]")]
        public _reserved2_e__FixedBuffer reserved2;

        /// <include file='_reserved2_e__FixedBuffer.xml' path='doc/member[@name="_reserved2_e__FixedBuffer"]/*' />
        [InlineArray(20)]
        public partial struct _reserved2_e__FixedBuffer
        {
            public uint e0;
        }
    }
}
