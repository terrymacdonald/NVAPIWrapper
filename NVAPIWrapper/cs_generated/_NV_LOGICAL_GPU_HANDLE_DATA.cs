using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_LOGICAL_GPU_HANDLE_DATA.xml' path='doc/member[@name="_NV_LOGICAL_GPU_HANDLE_DATA"]/*' />
    public unsafe partial struct _NV_LOGICAL_GPU_HANDLE_DATA
    {
        /// <include file='_NV_LOGICAL_GPU_HANDLE_DATA.xml' path='doc/member[@name="_NV_LOGICAL_GPU_HANDLE_DATA.hLogicalGpu"]/*' />
        [NativeTypeName("NvLogicalGpuHandle")]
        public NvLogicalGpuHandle__* hLogicalGpu;

        /// <include file='_NV_LOGICAL_GPU_HANDLE_DATA.xml' path='doc/member[@name="_NV_LOGICAL_GPU_HANDLE_DATA.adapterType"]/*' />
        [NativeTypeName("NV_ADAPTER_TYPE")]
        public _NV_ADAPTER_TYPE adapterType;

        /// <include file='_NV_LOGICAL_GPU_HANDLE_DATA.xml' path='doc/member[@name="_NV_LOGICAL_GPU_HANDLE_DATA.reserved"]/*' />
        [NativeTypeName("NvU32[4]")]
        public _reserved_e__FixedBuffer reserved;

        /// <include file='_reserved_e__FixedBuffer.xml' path='doc/member[@name="_reserved_e__FixedBuffer"]/*' />
        [InlineArray(4)]
        public partial struct _reserved_e__FixedBuffer
        {
            public uint e0;
        }
    }
}
