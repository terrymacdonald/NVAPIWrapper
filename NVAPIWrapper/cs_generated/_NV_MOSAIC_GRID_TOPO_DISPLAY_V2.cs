namespace NVAPIWrapper
{
    /// <include file='_NV_MOSAIC_GRID_TOPO_DISPLAY_V2.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_DISPLAY_V2"]/*' />
    public partial struct _NV_MOSAIC_GRID_TOPO_DISPLAY_V2
    {
        /// <include file='_NV_MOSAIC_GRID_TOPO_DISPLAY_V2.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_DISPLAY_V2.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_MOSAIC_GRID_TOPO_DISPLAY_V2.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_DISPLAY_V2.displayId"]/*' />
        [NativeTypeName("NvU32")]
        public uint displayId;

        /// <include file='_NV_MOSAIC_GRID_TOPO_DISPLAY_V2.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_DISPLAY_V2.overlapX"]/*' />
        [NativeTypeName("NvS32")]
        public int overlapX;

        /// <include file='_NV_MOSAIC_GRID_TOPO_DISPLAY_V2.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_DISPLAY_V2.overlapY"]/*' />
        [NativeTypeName("NvS32")]
        public int overlapY;

        /// <include file='_NV_MOSAIC_GRID_TOPO_DISPLAY_V2.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_DISPLAY_V2.rotation"]/*' />
        [NativeTypeName("NV_ROTATE")]
        public _NV_ROTATE rotation;

        /// <include file='_NV_MOSAIC_GRID_TOPO_DISPLAY_V2.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_DISPLAY_V2.cloneGroup"]/*' />
        [NativeTypeName("NvU32")]
        public uint cloneGroup;

        /// <include file='_NV_MOSAIC_GRID_TOPO_DISPLAY_V2.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_DISPLAY_V2.pixelShiftType"]/*' />
        [NativeTypeName("NV_PIXEL_SHIFT_TYPE")]
        public _NV_PIXEL_SHIFT_TYPE pixelShiftType;
    }
}
