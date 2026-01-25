namespace NVAPIWrapper
{
    /// <include file='NV_MOSAIC_TOPO_BRIEF.xml' path='doc/member[@name="NV_MOSAIC_TOPO_BRIEF"]/*' />
    public partial struct NV_MOSAIC_TOPO_BRIEF
    {
        /// <include file='NV_MOSAIC_TOPO_BRIEF.xml' path='doc/member[@name="NV_MOSAIC_TOPO_BRIEF.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_MOSAIC_TOPO_BRIEF.xml' path='doc/member[@name="NV_MOSAIC_TOPO_BRIEF.topo"]/*' />
        public NV_MOSAIC_TOPO topo;

        /// <include file='NV_MOSAIC_TOPO_BRIEF.xml' path='doc/member[@name="NV_MOSAIC_TOPO_BRIEF.enabled"]/*' />
        [NativeTypeName("NvU32")]
        public uint enabled;

        /// <include file='NV_MOSAIC_TOPO_BRIEF.xml' path='doc/member[@name="NV_MOSAIC_TOPO_BRIEF.isPossible"]/*' />
        [NativeTypeName("NvU32")]
        public uint isPossible;
    }
}
