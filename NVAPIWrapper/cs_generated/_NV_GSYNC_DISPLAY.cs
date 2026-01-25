namespace NVAPIWrapper
{
    /// <include file='_NV_GSYNC_DISPLAY.xml' path='doc/member[@name="_NV_GSYNC_DISPLAY"]/*' />
    public partial struct _NV_GSYNC_DISPLAY
    {
        /// <include file='_NV_GSYNC_DISPLAY.xml' path='doc/member[@name="_NV_GSYNC_DISPLAY.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_GSYNC_DISPLAY.xml' path='doc/member[@name="_NV_GSYNC_DISPLAY.displayId"]/*' />
        [NativeTypeName("NvU32")]
        public uint displayId;

        public uint _bitfield;

        /// <include file='_NV_GSYNC_DISPLAY.xml' path='doc/member[@name="_NV_GSYNC_DISPLAY.isMasterable"]/*' />
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

        /// <include file='_NV_GSYNC_DISPLAY.xml' path='doc/member[@name="_NV_GSYNC_DISPLAY.reserved"]/*' />
        [NativeTypeName("NvU32 : 31")]
        public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x7FFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x7FFFFFFFu << 1)) | ((value & 0x7FFFFFFFu) << 1);
            }
        }

        /// <include file='_NV_GSYNC_DISPLAY.xml' path='doc/member[@name="_NV_GSYNC_DISPLAY.syncState"]/*' />
        [NativeTypeName("NVAPI_GSYNC_DISPLAY_SYNC_STATE")]
        public _NVAPI_GSYNC_DISPLAY_SYNC_STATE syncState;
    }
}
