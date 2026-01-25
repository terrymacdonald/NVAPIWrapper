using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_PHYSICAL_GPU_HANDLE_DATA.xml' path='doc/member[@name="_NV_PHYSICAL_GPU_HANDLE_DATA"]/*' />
    public unsafe partial struct _NV_PHYSICAL_GPU_HANDLE_DATA
    {
        /// <include file='_NV_PHYSICAL_GPU_HANDLE_DATA.xml' path='doc/member[@name="_NV_PHYSICAL_GPU_HANDLE_DATA.hPhysicalGpu"]/*' />
        [NativeTypeName("NvPhysicalGpuHandle")]
        public NvPhysicalGpuHandle__* hPhysicalGpu;

        /// <include file='_NV_PHYSICAL_GPU_HANDLE_DATA.xml' path='doc/member[@name="_NV_PHYSICAL_GPU_HANDLE_DATA.adapterType"]/*' />
        [NativeTypeName("NV_ADAPTER_TYPE")]
        public _NV_ADAPTER_TYPE adapterType;

        /// <include file='_NV_PHYSICAL_GPU_HANDLE_DATA.xml' path='doc/member[@name="_NV_PHYSICAL_GPU_HANDLE_DATA.reserved2"]/*' />
        [NativeTypeName("NvU32[4]")]
        public _reserved2_e__FixedBuffer reserved2;

        /// <include file='_reserved2_e__FixedBuffer.xml' path='doc/member[@name="_reserved2_e__FixedBuffer"]/*' />
        [InlineArray(4)]
        public partial struct _reserved2_e__FixedBuffer
        {
            public uint e0;
        }
    }
}
