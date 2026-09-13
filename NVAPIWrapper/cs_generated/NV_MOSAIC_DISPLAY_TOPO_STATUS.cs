using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NV_MOSAIC_DISPLAY_TOPO_STATUS.xml' path='doc/member[@name="NV_MOSAIC_DISPLAY_TOPO_STATUS"]/*' />
    public partial struct NV_MOSAIC_DISPLAY_TOPO_STATUS
    {
        /// <include file='NV_MOSAIC_DISPLAY_TOPO_STATUS.xml' path='doc/member[@name="NV_MOSAIC_DISPLAY_TOPO_STATUS.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_MOSAIC_DISPLAY_TOPO_STATUS.xml' path='doc/member[@name="NV_MOSAIC_DISPLAY_TOPO_STATUS.errorFlags"]/*' />
        [NativeTypeName("NvU32")]
        public uint errorFlags;

        /// <include file='NV_MOSAIC_DISPLAY_TOPO_STATUS.xml' path='doc/member[@name="NV_MOSAIC_DISPLAY_TOPO_STATUS.warningFlags"]/*' />
        [NativeTypeName("NvU32")]
        public uint warningFlags;

        /// <include file='NV_MOSAIC_DISPLAY_TOPO_STATUS.xml' path='doc/member[@name="NV_MOSAIC_DISPLAY_TOPO_STATUS.displayCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint displayCount;

        /// <include file='NV_MOSAIC_DISPLAY_TOPO_STATUS.xml' path='doc/member[@name="NV_MOSAIC_DISPLAY_TOPO_STATUS.displays"]/*' />
        [NativeTypeName("struct (anonymous struct at ./../nvapi/nvapi.h:10251:5)[128]")]
        public _displays_e__FixedBuffer displays;

        /// <include file='_displays_e__Struct.xml' path='doc/member[@name="_displays_e__Struct"]/*' />
        public partial struct _displays_e__Struct
        {
            /// <include file='_displays_e__Struct.xml' path='doc/member[@name="_displays_e__Struct.displayId"]/*' />
            [NativeTypeName("NvU32")]
            public uint displayId;

            /// <include file='_displays_e__Struct.xml' path='doc/member[@name="_displays_e__Struct.errorFlags"]/*' />
            [NativeTypeName("NvU32")]
            public uint errorFlags;

            /// <include file='_displays_e__Struct.xml' path='doc/member[@name="_displays_e__Struct.warningFlags"]/*' />
            [NativeTypeName("NvU32")]
            public uint warningFlags;

            public uint _bitfield;

            /// <include file='_displays_e__Struct.xml' path='doc/member[@name="_displays_e__Struct.supportsRotation"]/*' />
            [NativeTypeName("NvU32 : 1")]
            public uint supportsRotation
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

            /// <include file='_displays_e__Struct.xml' path='doc/member[@name="_displays_e__Struct.reserved"]/*' />
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
        }

        /// <include file='_displays_e__FixedBuffer.xml' path='doc/member[@name="_displays_e__FixedBuffer"]/*' />
        [InlineArray(128)]
        public partial struct _displays_e__FixedBuffer
        {
            public _displays_e__Struct e0;
        }
    }
}
