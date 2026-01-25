namespace NVAPIWrapper
{
    /// <include file='NV_DISPLAY_PATH.xml' path='doc/member[@name="NV_DISPLAY_PATH"]/*' />
    public partial struct NV_DISPLAY_PATH
    {
        /// <include file='NV_DISPLAY_PATH.xml' path='doc/member[@name="NV_DISPLAY_PATH.deviceMask"]/*' />
        [NativeTypeName("NvU32")]
        public uint deviceMask;

        /// <include file='NV_DISPLAY_PATH.xml' path='doc/member[@name="NV_DISPLAY_PATH.sourceId"]/*' />
        [NativeTypeName("NvU32")]
        public uint sourceId;

        public uint _bitfield1;

        /// <include file='NV_DISPLAY_PATH.xml' path='doc/member[@name="NV_DISPLAY_PATH.bPrimary"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bPrimary
        {
            readonly get
            {
                return _bitfield1 & 0x1u;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~0x1u) | (value & 0x1u);
            }
        }

        /// <include file='NV_DISPLAY_PATH.xml' path='doc/member[@name="NV_DISPLAY_PATH.connector"]/*' />
        [NativeTypeName("NV_GPU_CONNECTOR_TYPE")]
        public _NV_GPU_CONNECTOR_TYPE connector;

        /// <include file='NV_DISPLAY_PATH.xml' path='doc/member[@name="NV_DISPLAY_PATH.width"]/*' />
        [NativeTypeName("NvU32")]
        public uint width;

        /// <include file='NV_DISPLAY_PATH.xml' path='doc/member[@name="NV_DISPLAY_PATH.height"]/*' />
        [NativeTypeName("NvU32")]
        public uint height;

        /// <include file='NV_DISPLAY_PATH.xml' path='doc/member[@name="NV_DISPLAY_PATH.depth"]/*' />
        [NativeTypeName("NvU32")]
        public uint depth;

        /// <include file='NV_DISPLAY_PATH.xml' path='doc/member[@name="NV_DISPLAY_PATH.colorFormat"]/*' />
        [NativeTypeName("NV_FORMAT")]
        public _NV_FORMAT colorFormat;

        /// <include file='NV_DISPLAY_PATH.xml' path='doc/member[@name="NV_DISPLAY_PATH.rotation"]/*' />
        [NativeTypeName("NV_ROTATE")]
        public _NV_ROTATE rotation;

        /// <include file='NV_DISPLAY_PATH.xml' path='doc/member[@name="NV_DISPLAY_PATH.scaling"]/*' />
        [NativeTypeName("NV_SCALING")]
        public _NV_SCALING scaling;

        /// <include file='NV_DISPLAY_PATH.xml' path='doc/member[@name="NV_DISPLAY_PATH.refreshRate"]/*' />
        [NativeTypeName("NvU32")]
        public uint refreshRate;

        public uint _bitfield2;

        /// <include file='NV_DISPLAY_PATH.xml' path='doc/member[@name="NV_DISPLAY_PATH.interlaced"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint interlaced
        {
            readonly get
            {
                return _bitfield2 & 0x1u;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~0x1u) | (value & 0x1u);
            }
        }

        /// <include file='NV_DISPLAY_PATH.xml' path='doc/member[@name="NV_DISPLAY_PATH.tvFormat"]/*' />
        [NativeTypeName("NV_DISPLAY_TV_FORMAT")]
        public _NV_DISPLAY_TV_FORMAT tvFormat;

        /// <include file='NV_DISPLAY_PATH.xml' path='doc/member[@name="NV_DISPLAY_PATH.posx"]/*' />
        [NativeTypeName("NvU32")]
        public uint posx;

        /// <include file='NV_DISPLAY_PATH.xml' path='doc/member[@name="NV_DISPLAY_PATH.posy"]/*' />
        [NativeTypeName("NvU32")]
        public uint posy;

        public uint _bitfield3;

        /// <include file='NV_DISPLAY_PATH.xml' path='doc/member[@name="NV_DISPLAY_PATH.bGDIPrimary"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bGDIPrimary
        {
            readonly get
            {
                return _bitfield3 & 0x1u;
            }

            set
            {
                _bitfield3 = (_bitfield3 & ~0x1u) | (value & 0x1u);
            }
        }

        /// <include file='NV_DISPLAY_PATH.xml' path='doc/member[@name="NV_DISPLAY_PATH.bForceModeSet"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bForceModeSet
        {
            readonly get
            {
                return (_bitfield3 >> 1) & 0x1u;
            }

            set
            {
                _bitfield3 = (_bitfield3 & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

        /// <include file='NV_DISPLAY_PATH.xml' path='doc/member[@name="NV_DISPLAY_PATH.bFocusDisplay"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bFocusDisplay
        {
            readonly get
            {
                return (_bitfield3 >> 2) & 0x1u;
            }

            set
            {
                _bitfield3 = (_bitfield3 & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

        /// <include file='NV_DISPLAY_PATH.xml' path='doc/member[@name="NV_DISPLAY_PATH.gpuId"]/*' />
        [NativeTypeName("NvU32 : 24")]
        public uint gpuId
        {
            readonly get
            {
                return (_bitfield3 >> 3) & 0xFFFFFFu;
            }

            set
            {
                _bitfield3 = (_bitfield3 & ~(0xFFFFFFu << 3)) | ((value & 0xFFFFFFu) << 3);
            }
        }
    }
}
