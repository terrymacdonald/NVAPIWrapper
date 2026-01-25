using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NV_MOSAIC_TOPO_GROUP.xml' path='doc/member[@name="NV_MOSAIC_TOPO_GROUP"]/*' />
    public partial struct NV_MOSAIC_TOPO_GROUP
    {
        /// <include file='NV_MOSAIC_TOPO_GROUP.xml' path='doc/member[@name="NV_MOSAIC_TOPO_GROUP.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_MOSAIC_TOPO_GROUP.xml' path='doc/member[@name="NV_MOSAIC_TOPO_GROUP.brief"]/*' />
        public NV_MOSAIC_TOPO_BRIEF brief;

        /// <include file='NV_MOSAIC_TOPO_GROUP.xml' path='doc/member[@name="NV_MOSAIC_TOPO_GROUP.count"]/*' />
        [NativeTypeName("NvU32")]
        public uint count;

        /// <include file='NV_MOSAIC_TOPO_GROUP.xml' path='doc/member[@name="NV_MOSAIC_TOPO_GROUP.topos"]/*' />
        [NativeTypeName("NV_MOSAIC_TOPO_DETAILS[2]")]
        public _topos_e__FixedBuffer topos;

        /// <include file='_topos_e__FixedBuffer.xml' path='doc/member[@name="_topos_e__FixedBuffer"]/*' />
        [InlineArray(2)]
        public partial struct _topos_e__FixedBuffer
        {
            public NV_MOSAIC_TOPO_DETAILS e0;
        }
    }
}
