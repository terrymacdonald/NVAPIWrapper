using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NV_MOSAIC_TOPOLOGY.xml' path='doc/member[@name="NV_MOSAIC_TOPOLOGY"]/*' />
    public partial struct NV_MOSAIC_TOPOLOGY
    {
        /// <include file='NV_MOSAIC_TOPOLOGY.xml' path='doc/member[@name="NV_MOSAIC_TOPOLOGY.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_MOSAIC_TOPOLOGY.xml' path='doc/member[@name="NV_MOSAIC_TOPOLOGY.rowCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint rowCount;

        /// <include file='NV_MOSAIC_TOPOLOGY.xml' path='doc/member[@name="NV_MOSAIC_TOPOLOGY.colCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint colCount;

        /// <include file='NV_MOSAIC_TOPOLOGY.xml' path='doc/member[@name="NV_MOSAIC_TOPOLOGY.gpuLayout"]/*' />
        [NativeTypeName("struct (anonymous struct at ./../nvapi/nvapi.h:10429:5)[8][8]")]
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
            public _Anonymous-1_e__Struct e0_0;
        }
    }
}
