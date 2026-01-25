namespace NVAPIWrapper
{
    /// <include file='_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1"]/*' />
    public partial struct _NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1
    {
        /// <include file='_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.rotation"]/*' />
        [NativeTypeName("NV_ROTATE")]
        public _NV_ROTATE rotation;

        /// <include file='_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.scaling"]/*' />
        [NativeTypeName("NV_SCALING")]
        public _NV_SCALING scaling;

        /// <include file='_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.refreshRate1K"]/*' />
        [NativeTypeName("NvU32")]
        public uint refreshRate1K;

        public uint _bitfield;

        /// <include file='_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.interlaced"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint interlaced
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

        /// <include file='_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.primary"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint primary
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

        /// <include file='_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.reservedBit1"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reservedBit1
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

        /// <include file='_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.disableVirtualModeSupport"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint disableVirtualModeSupport
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

        /// <include file='_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.isPreferredUnscaledTarget"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isPreferredUnscaledTarget
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

        /// <include file='_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.reserved"]/*' />
        [NativeTypeName("NvU32 : 27")]
        public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 5) & 0x7FFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x7FFFFFFu << 5)) | ((value & 0x7FFFFFFu) << 5);
            }
        }

        /// <include file='_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.connector"]/*' />
        [NativeTypeName("NV_GPU_CONNECTOR_TYPE")]
        public _NV_GPU_CONNECTOR_TYPE connector;

        /// <include file='_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.tvFormat"]/*' />
        [NativeTypeName("NV_DISPLAY_TV_FORMAT")]
        public _NV_DISPLAY_TV_FORMAT tvFormat;

        /// <include file='_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.timingOverride"]/*' />
        [NativeTypeName("NV_TIMING_OVERRIDE")]
        public _NV_TIMING_OVERRIDE timingOverride;

        /// <include file='_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1.timing"]/*' />
        [NativeTypeName("NV_TIMING")]
        public _NV_TIMING timing;
    }
}
