using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_PHYSICAL_GPUS.xml' path='doc/member[@name="_NV_PHYSICAL_GPUS"]/*' />
    public partial struct _NV_PHYSICAL_GPUS
    {
        /// <include file='_NV_PHYSICAL_GPUS.xml' path='doc/member[@name="_NV_PHYSICAL_GPUS.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_PHYSICAL_GPUS.xml' path='doc/member[@name="_NV_PHYSICAL_GPUS.gpuHandleData"]/*' />
        [NativeTypeName("NV_PHYSICAL_GPU_HANDLE_DATA[64]")]
        public _gpuHandleData_e__FixedBuffer gpuHandleData;

        /// <include file='_NV_PHYSICAL_GPUS.xml' path='doc/member[@name="_NV_PHYSICAL_GPUS.gpuHandleCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint gpuHandleCount;

        /// <include file='_NV_PHYSICAL_GPUS.xml' path='doc/member[@name="_NV_PHYSICAL_GPUS.reserved"]/*' />
        [NativeTypeName("NvU32[4]")]
        public _reserved_e__FixedBuffer reserved;

        /// <include file='_gpuHandleData_e__FixedBuffer.xml' path='doc/member[@name="_gpuHandleData_e__FixedBuffer"]/*' />
        [InlineArray(64)]
        public partial struct _gpuHandleData_e__FixedBuffer
        {
            public _NV_PHYSICAL_GPU_HANDLE_DATA e0;
        }

        /// <include file='_reserved_e__FixedBuffer.xml' path='doc/member[@name="_reserved_e__FixedBuffer"]/*' />
        [InlineArray(4)]
        public partial struct _reserved_e__FixedBuffer
        {
            public uint e0;
        }
    }
}
