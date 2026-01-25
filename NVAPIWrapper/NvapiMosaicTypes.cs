using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <summary>Represents a Mosaic GPU layout cell entry.</summary>
    public unsafe partial struct NV_MOSAIC_GPU_LAYOUT_CELL
    {
        /// <summary>Physical GPU to be used in the topology.</summary>
        [NativeTypeName("NvPhysicalGpuHandle")]
        public NvPhysicalGpuHandle__* hPhysicalGPU;

        /// <summary>Connected display target.</summary>
        [NativeTypeName("NvU32")]
        public uint displayOutputId;

        /// <summary>Pixels of overlap on left of target (+overlap, -gap).</summary>
        [NativeTypeName("NvS32")]
        public int overlapX;

        /// <summary>Pixels of overlap on top of target (+overlap, -gap).</summary>
        [NativeTypeName("NvS32")]
        public int overlapY;
    }

    /// <summary>Used in NvAPI_GetCurrentMosaicTopology and NvAPI_SetCurrentMosaicTopology.</summary>
    public partial struct NV_MOSAIC_TOPOLOGY
    {
        /// <summary>Version number of the mosaic topology.</summary>
        [NativeTypeName("NvU32")]
        public uint version;

        /// <summary>Horizontal display count.</summary>
        [NativeTypeName("NvU32")]
        public uint rowCount;

        /// <summary>Vertical display count.</summary>
        [NativeTypeName("NvU32")]
        public uint colCount;

        /// <summary>GPU layout table for the topology.</summary>
        [NativeTypeName("struct (anonymous struct at ./../nvapi/nvapi.h:10429:5)[8][8]")]
        public _gpuLayout_e__FixedBuffer gpuLayout;

        /// <summary>Fixed buffer for the GPU layout table.</summary>
        [InlineArray(8 * 8)]
        public partial struct _gpuLayout_e__FixedBuffer
        {
            public NV_MOSAIC_GPU_LAYOUT_CELL e0_0;
        }
    }

    /// <summary>Defines the Mosaic topology details.</summary>
    public unsafe partial struct NV_MOSAIC_TOPO_DETAILS
    {
        /// <summary>Version of this structure.</summary>
        [NativeTypeName("NvU32")]
        public uint version;

        /// <summary>Logical GPU for this topology.</summary>
        [NativeTypeName("NvLogicalGpuHandle")]
        public NvLogicalGpuHandle__* hLogicalGPU;

        /// <summary>Validity mask for the topology.</summary>
        [NativeTypeName("NvU32")]
        public uint validityMask;

        /// <summary>Number of displays in a row.</summary>
        [NativeTypeName("NvU32")]
        public uint rowCount;

        /// <summary>Number of displays in a column.</summary>
        [NativeTypeName("NvU32")]
        public uint colCount;

        /// <summary>GPU layout table for the topology.</summary>
        [NativeTypeName("struct (anonymous struct at ./../nvapi/nvapi.h:9584:5)[8][8]")]
        public _gpuLayout_e__FixedBuffer gpuLayout;

        /// <summary>Fixed buffer for the GPU layout table.</summary>
        [InlineArray(8 * 8)]
        public partial struct _gpuLayout_e__FixedBuffer
        {
            public NV_MOSAIC_GPU_LAYOUT_CELL e0_0;
        }
    }
}
