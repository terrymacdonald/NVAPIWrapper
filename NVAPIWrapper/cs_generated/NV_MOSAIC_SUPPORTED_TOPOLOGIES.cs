using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NV_MOSAIC_SUPPORTED_TOPOLOGIES.xml' path='doc/member[@name="NV_MOSAIC_SUPPORTED_TOPOLOGIES"]/*' />
    public partial struct NV_MOSAIC_SUPPORTED_TOPOLOGIES
    {
        /// <include file='NV_MOSAIC_SUPPORTED_TOPOLOGIES.xml' path='doc/member[@name="NV_MOSAIC_SUPPORTED_TOPOLOGIES.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_MOSAIC_SUPPORTED_TOPOLOGIES.xml' path='doc/member[@name="NV_MOSAIC_SUPPORTED_TOPOLOGIES.totalCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint totalCount;

        /// <include file='NV_MOSAIC_SUPPORTED_TOPOLOGIES.xml' path='doc/member[@name="NV_MOSAIC_SUPPORTED_TOPOLOGIES.topos"]/*' />
        [NativeTypeName("NV_MOSAIC_TOPOLOGY[16]")]
        public _topos_e__FixedBuffer topos;

        /// <include file='_topos_e__FixedBuffer.xml' path='doc/member[@name="_topos_e__FixedBuffer"]/*' />
        [InlineArray(16)]
        public partial struct _topos_e__FixedBuffer
        {
            public NV_MOSAIC_TOPOLOGY e0;
        }
    }
}
