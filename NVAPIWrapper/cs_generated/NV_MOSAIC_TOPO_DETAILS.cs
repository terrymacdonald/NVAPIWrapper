using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NV_MOSAIC_TOPO_DETAILS.xml' path='doc/member[@name="NV_MOSAIC_TOPO_DETAILS"]/*' />
    public unsafe partial struct NV_MOSAIC_TOPO_DETAILS
    {
        /// <include file='NV_MOSAIC_TOPO_DETAILS.xml' path='doc/member[@name="NV_MOSAIC_TOPO_DETAILS.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_MOSAIC_TOPO_DETAILS.xml' path='doc/member[@name="NV_MOSAIC_TOPO_DETAILS.hLogicalGPU"]/*' />
        [NativeTypeName("NvLogicalGpuHandle")]
        public NvLogicalGpuHandle__* hLogicalGPU;

        /// <include file='NV_MOSAIC_TOPO_DETAILS.xml' path='doc/member[@name="NV_MOSAIC_TOPO_DETAILS.validityMask"]/*' />
        [NativeTypeName("NvU32")]
        public uint validityMask;

        /// <include file='NV_MOSAIC_TOPO_DETAILS.xml' path='doc/member[@name="NV_MOSAIC_TOPO_DETAILS.rowCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint rowCount;

        /// <include file='NV_MOSAIC_TOPO_DETAILS.xml' path='doc/member[@name="NV_MOSAIC_TOPO_DETAILS.colCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint colCount;

        /// <include file='NV_MOSAIC_TOPO_DETAILS.xml' path='doc/member[@name="NV_MOSAIC_TOPO_DETAILS.gpuLayout"]/*' />
        [NativeTypeName("struct (anonymous struct at ./../nvapi/nvapi.h:9584:5)[8][8]")]
        public _gpuLayout_e__FixedBuffer gpuLayout;

        /// <include file='_Anonymous-1_e__Struct.xml' path='doc/member[@name="_Anonymous-1_e__Struct"]/*' />
        public unsafe partial struct _Anonymous-1_e__Struct
        {
            /// <include file='_Anonymous-1_e__Struct.xml' path='doc/member[@name="_Anonymous-1_e__Struct.hPhysicalGPU"]/*' />
            [NativeTypeName("NvPhysicalGpuHandle")]
            public NvPhysicalGpuHandle__* hPhysicalGPU;

            /// <include file='_Anonymous-1_e__Struct.xml' path='doc/member[@name="_Anonymous-1_e__Struct.displayOutputId"]/*' />
            [NativeTypeName("NvU32")]
            public uint displayOutputId;

            /// <include file='_Anonymous-1_e__Struct.xml' path='doc/member[@name="_Anonymous-1_e__Struct.overlapX"]/*' />
            [NativeTypeName("NvS32")]
            public int overlapX;

            /// <include file='_Anonymous-1_e__Struct.xml' path='doc/member[@name="_Anonymous-1_e__Struct.overlapY"]/*' />
            [NativeTypeName("NvS32")]
            public int overlapY;
        }

        /// <include file='_gpuLayout_e__FixedBuffer.xml' path='doc/member[@name="_gpuLayout_e__FixedBuffer"]/*' />
        [InlineArray(8 * 8)]
        public partial struct _gpuLayout_e__FixedBuffer
        {
            public NV_MOSAIC_GPU_LAYOUT_CELL e0_0;
        }
    }
}
