using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_LOGICAL_GPU_DATA_V1.xml' path='doc/member[@name="_NV_LOGICAL_GPU_DATA_V1"]/*' />
    public unsafe partial struct _NV_LOGICAL_GPU_DATA_V1
    {
        /// <include file='_NV_LOGICAL_GPU_DATA_V1.xml' path='doc/member[@name="_NV_LOGICAL_GPU_DATA_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_LOGICAL_GPU_DATA_V1.xml' path='doc/member[@name="_NV_LOGICAL_GPU_DATA_V1.pOSAdapterId"]/*' />
        public void* pOSAdapterId;

        /// <include file='_NV_LOGICAL_GPU_DATA_V1.xml' path='doc/member[@name="_NV_LOGICAL_GPU_DATA_V1.physicalGpuCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint physicalGpuCount;

        /// <include file='_NV_LOGICAL_GPU_DATA_V1.xml' path='doc/member[@name="_NV_LOGICAL_GPU_DATA_V1.physicalGpuHandles"]/*' />
        [NativeTypeName("NvPhysicalGpuHandle[64]")]
        public _physicalGpuHandles_e__FixedBuffer physicalGpuHandles;

        /// <include file='_NV_LOGICAL_GPU_DATA_V1.xml' path='doc/member[@name="_NV_LOGICAL_GPU_DATA_V1.reserved"]/*' />
        [NativeTypeName("NvU32[8]")]
        public _reserved_e__FixedBuffer reserved;

        /// <include file='_physicalGpuHandles_e__FixedBuffer.xml' path='doc/member[@name="_physicalGpuHandles_e__FixedBuffer"]/*' />
        public unsafe partial struct _physicalGpuHandles_e__FixedBuffer
        {
            public NvPhysicalGpuHandle__* e0;
            public NvPhysicalGpuHandle__* e1;
            public NvPhysicalGpuHandle__* e2;
            public NvPhysicalGpuHandle__* e3;
            public NvPhysicalGpuHandle__* e4;
            public NvPhysicalGpuHandle__* e5;
            public NvPhysicalGpuHandle__* e6;
            public NvPhysicalGpuHandle__* e7;
            public NvPhysicalGpuHandle__* e8;
            public NvPhysicalGpuHandle__* e9;
            public NvPhysicalGpuHandle__* e10;
            public NvPhysicalGpuHandle__* e11;
            public NvPhysicalGpuHandle__* e12;
            public NvPhysicalGpuHandle__* e13;
            public NvPhysicalGpuHandle__* e14;
            public NvPhysicalGpuHandle__* e15;
            public NvPhysicalGpuHandle__* e16;
            public NvPhysicalGpuHandle__* e17;
            public NvPhysicalGpuHandle__* e18;
            public NvPhysicalGpuHandle__* e19;
            public NvPhysicalGpuHandle__* e20;
            public NvPhysicalGpuHandle__* e21;
            public NvPhysicalGpuHandle__* e22;
            public NvPhysicalGpuHandle__* e23;
            public NvPhysicalGpuHandle__* e24;
            public NvPhysicalGpuHandle__* e25;
            public NvPhysicalGpuHandle__* e26;
            public NvPhysicalGpuHandle__* e27;
            public NvPhysicalGpuHandle__* e28;
            public NvPhysicalGpuHandle__* e29;
            public NvPhysicalGpuHandle__* e30;
            public NvPhysicalGpuHandle__* e31;
            public NvPhysicalGpuHandle__* e32;
            public NvPhysicalGpuHandle__* e33;
            public NvPhysicalGpuHandle__* e34;
            public NvPhysicalGpuHandle__* e35;
            public NvPhysicalGpuHandle__* e36;
            public NvPhysicalGpuHandle__* e37;
            public NvPhysicalGpuHandle__* e38;
            public NvPhysicalGpuHandle__* e39;
            public NvPhysicalGpuHandle__* e40;
            public NvPhysicalGpuHandle__* e41;
            public NvPhysicalGpuHandle__* e42;
            public NvPhysicalGpuHandle__* e43;
            public NvPhysicalGpuHandle__* e44;
            public NvPhysicalGpuHandle__* e45;
            public NvPhysicalGpuHandle__* e46;
            public NvPhysicalGpuHandle__* e47;
            public NvPhysicalGpuHandle__* e48;
            public NvPhysicalGpuHandle__* e49;
            public NvPhysicalGpuHandle__* e50;
            public NvPhysicalGpuHandle__* e51;
            public NvPhysicalGpuHandle__* e52;
            public NvPhysicalGpuHandle__* e53;
            public NvPhysicalGpuHandle__* e54;
            public NvPhysicalGpuHandle__* e55;
            public NvPhysicalGpuHandle__* e56;
            public NvPhysicalGpuHandle__* e57;
            public NvPhysicalGpuHandle__* e58;
            public NvPhysicalGpuHandle__* e59;
            public NvPhysicalGpuHandle__* e60;
            public NvPhysicalGpuHandle__* e61;
            public NvPhysicalGpuHandle__* e62;
            public NvPhysicalGpuHandle__* e63;

            public ref NvPhysicalGpuHandle__* this[int index]
            {
                get
                {
                    fixed (NvPhysicalGpuHandle__** pThis = &e0)
                    {
                        return ref pThis[index];
                    }
                }
            }
        }

        /// <include file='_reserved_e__FixedBuffer.xml' path='doc/member[@name="_reserved_e__FixedBuffer"]/*' />
        [InlineArray(8)]
        public partial struct _reserved_e__FixedBuffer
        {
            public uint e0;
        }
    }
}
