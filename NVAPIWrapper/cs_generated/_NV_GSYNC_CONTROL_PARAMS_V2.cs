namespace NVAPIWrapper
{
    /// <include file='_NV_GSYNC_CONTROL_PARAMS_V2.xml' path='doc/member[@name="_NV_GSYNC_CONTROL_PARAMS_V2"]/*' />
    public partial struct _NV_GSYNC_CONTROL_PARAMS_V2
    {
        /// <include file='_NV_GSYNC_CONTROL_PARAMS_V2.xml' path='doc/member[@name="_NV_GSYNC_CONTROL_PARAMS_V2.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_GSYNC_CONTROL_PARAMS_V2.xml' path='doc/member[@name="_NV_GSYNC_CONTROL_PARAMS_V2.polarity"]/*' />
        [NativeTypeName("NVAPI_GSYNC_POLARITY")]
        public _NVAPI_GSYNC_POLARITY polarity;

        /// <include file='_NV_GSYNC_CONTROL_PARAMS_V2.xml' path='doc/member[@name="_NV_GSYNC_CONTROL_PARAMS_V2.vmode"]/*' />
        [NativeTypeName("NVAPI_GSYNC_VIDEO_MODE")]
        public _NVAPI_GSYNC_VIDEO_MODE vmode;

        /// <include file='_NV_GSYNC_CONTROL_PARAMS_V2.xml' path='doc/member[@name="_NV_GSYNC_CONTROL_PARAMS_V2.interval"]/*' />
        [NativeTypeName("NvU32")]
        public uint interval;

        /// <include file='_NV_GSYNC_CONTROL_PARAMS_V2.xml' path='doc/member[@name="_NV_GSYNC_CONTROL_PARAMS_V2.source"]/*' />
        [NativeTypeName("NVAPI_GSYNC_SYNC_SOURCE")]
        public _NVAPI_GSYNC_SYNC_SOURCE source;

        public uint _bitfield;

        /// <include file='_NV_GSYNC_CONTROL_PARAMS_V2.xml' path='doc/member[@name="_NV_GSYNC_CONTROL_PARAMS_V2.interlaceMode"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint interlaceMode
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

        /// <include file='_NV_GSYNC_CONTROL_PARAMS_V2.xml' path='doc/member[@name="_NV_GSYNC_CONTROL_PARAMS_V2.syncSourceIsOutput"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint syncSourceIsOutput
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

        /// <include file='_NV_GSYNC_CONTROL_PARAMS_V2.xml' path='doc/member[@name="_NV_GSYNC_CONTROL_PARAMS_V2.reserved"]/*' />
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

        /// <include file='_NV_GSYNC_CONTROL_PARAMS_V2.xml' path='doc/member[@name="_NV_GSYNC_CONTROL_PARAMS_V2.syncSkew"]/*' />
        [NativeTypeName("NV_GSYNC_DELAY")]
        public _NV_GSYNC_DELAY syncSkew;

        /// <include file='_NV_GSYNC_CONTROL_PARAMS_V2.xml' path='doc/member[@name="_NV_GSYNC_CONTROL_PARAMS_V2.startupDelay"]/*' />
        [NativeTypeName("NV_GSYNC_DELAY")]
        public _NV_GSYNC_DELAY startupDelay;

        /// <include file='_NV_GSYNC_CONTROL_PARAMS_V2.xml' path='doc/member[@name="_NV_GSYNC_CONTROL_PARAMS_V2.multiplyDivideMode"]/*' />
        [NativeTypeName("NVAPI_GSYNC_MULTIPLY_DIVIDE_MODE")]
        public _NVAPI_GSYNC_MULTIPLY_DIVIDE_MODE multiplyDivideMode;

        /// <include file='_NV_GSYNC_CONTROL_PARAMS_V2.xml' path='doc/member[@name="_NV_GSYNC_CONTROL_PARAMS_V2.multiplyDivideValue"]/*' />
        [NativeTypeName("NvU8")]
        public byte multiplyDivideValue;
    }
}
