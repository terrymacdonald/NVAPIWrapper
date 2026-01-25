namespace NVAPIWrapper
{
    /// <include file='NV_DISPLAY_PORT_CONFIG.xml' path='doc/member[@name="NV_DISPLAY_PORT_CONFIG"]/*' />
    public partial struct NV_DISPLAY_PORT_CONFIG
    {
        /// <include file='NV_DISPLAY_PORT_CONFIG.xml' path='doc/member[@name="NV_DISPLAY_PORT_CONFIG.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_DISPLAY_PORT_CONFIG.xml' path='doc/member[@name="NV_DISPLAY_PORT_CONFIG.linkRate"]/*' />
        [NativeTypeName("NV_DP_LINK_RATE")]
        public _NV_DP_LINK_RATE linkRate;

        /// <include file='NV_DISPLAY_PORT_CONFIG.xml' path='doc/member[@name="NV_DISPLAY_PORT_CONFIG.laneCount"]/*' />
        [NativeTypeName("NV_DP_LANE_COUNT")]
        public _NV_DP_LANE_COUNT laneCount;

        /// <include file='NV_DISPLAY_PORT_CONFIG.xml' path='doc/member[@name="NV_DISPLAY_PORT_CONFIG.colorFormat"]/*' />
        [NativeTypeName("NV_DP_COLOR_FORMAT")]
        public _NV_DP_COLOR_FORMAT colorFormat;

        /// <include file='NV_DISPLAY_PORT_CONFIG.xml' path='doc/member[@name="NV_DISPLAY_PORT_CONFIG.dynamicRange"]/*' />
        [NativeTypeName("NV_DP_DYNAMIC_RANGE")]
        public _NV_DP_DYNAMIC_RANGE dynamicRange;

        /// <include file='NV_DISPLAY_PORT_CONFIG.xml' path='doc/member[@name="NV_DISPLAY_PORT_CONFIG.colorimetry"]/*' />
        [NativeTypeName("NV_DP_COLORIMETRY")]
        public _NV_DP_COLORIMETRY colorimetry;

        /// <include file='NV_DISPLAY_PORT_CONFIG.xml' path='doc/member[@name="NV_DISPLAY_PORT_CONFIG.bpc"]/*' />
        [NativeTypeName("NV_DP_BPC")]
        public _NV_DP_BPC bpc;

        public uint _bitfield;

        /// <include file='NV_DISPLAY_PORT_CONFIG.xml' path='doc/member[@name="NV_DISPLAY_PORT_CONFIG.isHPD"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isHPD
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

        /// <include file='NV_DISPLAY_PORT_CONFIG.xml' path='doc/member[@name="NV_DISPLAY_PORT_CONFIG.isSetDeferred"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isSetDeferred
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

        /// <include file='NV_DISPLAY_PORT_CONFIG.xml' path='doc/member[@name="NV_DISPLAY_PORT_CONFIG.isChromaLpfOff"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isChromaLpfOff
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

        /// <include file='NV_DISPLAY_PORT_CONFIG.xml' path='doc/member[@name="NV_DISPLAY_PORT_CONFIG.isDitherOff"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isDitherOff
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
            }
        }

        /// <include file='NV_DISPLAY_PORT_CONFIG.xml' path='doc/member[@name="NV_DISPLAY_PORT_CONFIG.testLinkTrain"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint testLinkTrain
        {
            readonly get
            {
                return (_bitfield >> 4) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 4)) | ((value & 0x1u) << 4);
            }
        }

        /// <include file='NV_DISPLAY_PORT_CONFIG.xml' path='doc/member[@name="NV_DISPLAY_PORT_CONFIG.testColorChange"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint testColorChange
        {
            readonly get
            {
                return (_bitfield >> 5) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 5)) | ((value & 0x1u) << 5);
            }
        }
    }
}
