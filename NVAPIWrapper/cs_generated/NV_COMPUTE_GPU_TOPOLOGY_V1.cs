using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NV_COMPUTE_GPU_TOPOLOGY_V1.xml' path='doc/member[@name="NV_COMPUTE_GPU_TOPOLOGY_V1"]/*' />
    public partial struct NV_COMPUTE_GPU_TOPOLOGY_V1
    {
        /// <include file='NV_COMPUTE_GPU_TOPOLOGY_V1.xml' path='doc/member[@name="NV_COMPUTE_GPU_TOPOLOGY_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_COMPUTE_GPU_TOPOLOGY_V1.xml' path='doc/member[@name="NV_COMPUTE_GPU_TOPOLOGY_V1.gpuCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint gpuCount;

        /// <include file='NV_COMPUTE_GPU_TOPOLOGY_V1.xml' path='doc/member[@name="NV_COMPUTE_GPU_TOPOLOGY_V1.computeGpus"]/*' />
        [NativeTypeName("struct (anonymous struct at ./../nvapi/nvapi.h:3291:5)[8]")]
        public _computeGpus_e__FixedBuffer computeGpus;

        /// <include file='_computeGpus_e__Struct.xml' path='doc/member[@name="_computeGpus_e__Struct"]/*' />
        public unsafe partial struct _computeGpus_e__Struct
        {
            /// <include file='_computeGpus_e__Struct.xml' path='doc/member[@name="_computeGpus_e__Struct.hPhysicalGpu"]/*' />
            [NativeTypeName("NvPhysicalGpuHandle")]
            public NvPhysicalGpuHandle__* hPhysicalGpu;

            /// <include file='_computeGpus_e__Struct.xml' path='doc/member[@name="_computeGpus_e__Struct.flags"]/*' />
            [NativeTypeName("NvU32")]
            public uint flags;
        }

        /// <include file='_computeGpus_e__FixedBuffer.xml' path='doc/member[@name="_computeGpus_e__FixedBuffer"]/*' />
        [InlineArray(8)]
        public partial struct _computeGpus_e__FixedBuffer
        {
            public _computeGpus_e__Struct e0;
        }
    }
}
