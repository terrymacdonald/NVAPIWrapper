namespace NVAPIWrapper
{
    /// <include file='NV_SCANOUT_WARPING_DATA.xml' path='doc/member[@name="NV_SCANOUT_WARPING_DATA"]/*' />
    public unsafe partial struct NV_SCANOUT_WARPING_DATA
    {
        /// <include file='NV_SCANOUT_WARPING_DATA.xml' path='doc/member[@name="NV_SCANOUT_WARPING_DATA.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_SCANOUT_WARPING_DATA.xml' path='doc/member[@name="NV_SCANOUT_WARPING_DATA.vertices"]/*' />
        public float* vertices;

        /// <include file='NV_SCANOUT_WARPING_DATA.xml' path='doc/member[@name="NV_SCANOUT_WARPING_DATA.vertexFormat"]/*' />
        public NV_GPU_WARPING_VERTICE_FORMAT vertexFormat;

        /// <include file='NV_SCANOUT_WARPING_DATA.xml' path='doc/member[@name="NV_SCANOUT_WARPING_DATA.numVertices"]/*' />
        public int numVertices;

        /// <include file='NV_SCANOUT_WARPING_DATA.xml' path='doc/member[@name="NV_SCANOUT_WARPING_DATA.textureRect"]/*' />
        public NvSBox* textureRect;
    }
}
