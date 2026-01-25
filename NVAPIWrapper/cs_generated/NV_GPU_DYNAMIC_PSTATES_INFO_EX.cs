using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NV_GPU_DYNAMIC_PSTATES_INFO_EX.xml' path='doc/member[@name="NV_GPU_DYNAMIC_PSTATES_INFO_EX"]/*' />
    public partial struct NV_GPU_DYNAMIC_PSTATES_INFO_EX
    {
        /// <include file='NV_GPU_DYNAMIC_PSTATES_INFO_EX.xml' path='doc/member[@name="NV_GPU_DYNAMIC_PSTATES_INFO_EX.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_GPU_DYNAMIC_PSTATES_INFO_EX.xml' path='doc/member[@name="NV_GPU_DYNAMIC_PSTATES_INFO_EX.flags"]/*' />
        [NativeTypeName("NvU32")]
        public uint flags;

        /// <include file='NV_GPU_DYNAMIC_PSTATES_INFO_EX.xml' path='doc/member[@name="NV_GPU_DYNAMIC_PSTATES_INFO_EX.utilization"]/*' />
        [NativeTypeName("struct (anonymous struct at ./../nvapi/nvapi.h:5161:5)[8]")]
        public _utilization_e__FixedBuffer utilization;

        /// <include file='_utilization_e__Struct.xml' path='doc/member[@name="_utilization_e__Struct"]/*' />
        public partial struct _utilization_e__Struct
        {
            public uint _bitfield;

            /// <include file='_utilization_e__Struct.xml' path='doc/member[@name="_utilization_e__Struct.bIsPresent"]/*' />
            [NativeTypeName("NvU32 : 1")]
            public uint bIsPresent
            {
                readonly get
                {
                    return _bitfield & 0x1u;
                }

                set
                {
                    _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
                }
            }

            /// <include file='_utilization_e__Struct.xml' path='doc/member[@name="_utilization_e__Struct.percentage"]/*' />
            [NativeTypeName("NvU32")]
            public uint percentage;
        }

        /// <include file='_utilization_e__FixedBuffer.xml' path='doc/member[@name="_utilization_e__FixedBuffer"]/*' />
        [InlineArray(8)]
        public partial struct _utilization_e__FixedBuffer
        {
            public _utilization_e__Struct e0;
        }
    }
}
