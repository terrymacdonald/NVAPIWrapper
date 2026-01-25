namespace NVAPIWrapper
{
    /// <include file='_NV_MOSAIC_GRID_TOPO_DISPLAY_V1.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_DISPLAY_V1"]/*' />
    public partial struct _NV_MOSAIC_GRID_TOPO_DISPLAY_V1
    {
        /// <include file='_NV_MOSAIC_GRID_TOPO_DISPLAY_V1.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_DISPLAY_V1.displayId"]/*' />
        [NativeTypeName("NvU32")]
        public uint displayId;

        /// <include file='_NV_MOSAIC_GRID_TOPO_DISPLAY_V1.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_DISPLAY_V1.overlapX"]/*' />
        [NativeTypeName("NvS32")]
        public int overlapX;

        /// <include file='_NV_MOSAIC_GRID_TOPO_DISPLAY_V1.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_DISPLAY_V1.overlapY"]/*' />
        [NativeTypeName("NvS32")]
        public int overlapY;

        /// <include file='_NV_MOSAIC_GRID_TOPO_DISPLAY_V1.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_DISPLAY_V1.rotation"]/*' />
        [NativeTypeName("NV_ROTATE")]
        public _NV_ROTATE rotation;

        /// <include file='_NV_MOSAIC_GRID_TOPO_DISPLAY_V1.xml' path='doc/member[@name="_NV_MOSAIC_GRID_TOPO_DISPLAY_V1.cloneGroup"]/*' />
        [NativeTypeName("NvU32")]
        public uint cloneGroup;
    }
}
