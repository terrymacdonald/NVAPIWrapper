using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_MOSAIC_GRID_TOPO_V2.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_V2"]/*' />
    public partial struct _NV_MOSAIC_GRID_TOPO_V2
    {
        /// <include file='_NV_MOSAIC_GRID_TOPO_V2.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_V2.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_MOSAIC_GRID_TOPO_V2.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_V2.rows"]/*' />
        [NativeTypeName("NvU32")]
        public uint rows;

        /// <include file='_NV_MOSAIC_GRID_TOPO_V2.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_V2.columns"]/*' />
        [NativeTypeName("NvU32")]
        public uint columns;

        /// <include file='_NV_MOSAIC_GRID_TOPO_V2.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_V2.displayCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint displayCount;

        public uint _bitfield;

        /// <include file='_NV_MOSAIC_GRID_TOPO_V2.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_V2.applyWithBezelCorrect"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint applyWithBezelCorrect
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

        /// <include file='_NV_MOSAIC_GRID_TOPO_V2.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_V2.immersiveGaming"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint immersiveGaming
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

        /// <include file='_NV_MOSAIC_GRID_TOPO_V2.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_V2.baseMosaic"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint baseMosaic
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

        /// <include file='_NV_MOSAIC_GRID_TOPO_V2.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_V2.driverReloadAllowed"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint driverReloadAllowed
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

        /// <include file='_NV_MOSAIC_GRID_TOPO_V2.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_V2.acceleratePrimaryDisplay"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint acceleratePrimaryDisplay
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

        /// <include file='_NV_MOSAIC_GRID_TOPO_V2.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_V2.pixelShift"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint pixelShift
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

        /// <include file='_NV_MOSAIC_GRID_TOPO_V2.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_V2.reserved"]/*' />
        [NativeTypeName("NvU32 : 26")]
        public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 6) & 0x3FFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x3FFFFFFu << 6)) | ((value & 0x3FFFFFFu) << 6);
            }
        }

        /// <include file='_NV_MOSAIC_GRID_TOPO_V2.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_V2.displays"]/*' />
        [NativeTypeName("NV_MOSAIC_GRID_TOPO_DISPLAY_V2[64]")]
        public _displays_e__FixedBuffer displays;

        /// <include file='_NV_MOSAIC_GRID_TOPO_V2.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_V2.displaySettings"]/*' />
        [NativeTypeName("NV_MOSAIC_DISPLAY_SETTING_V1")]
        public _NV_MOSAIC_DISPLAY_SETTING_V1 displaySettings;

        /// <include file='_displays_e__FixedBuffer.xml' path='doc/member[@name="_displays_e__FixedBuffer"]/*' />
        [InlineArray(64)]
        public partial struct _displays_e__FixedBuffer
        {
            public _NV_MOSAIC_GRID_TOPO_DISPLAY_V2 e0;
        }
    }
}
