using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_SINGLE_COLOR.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_SINGLE_COLOR"]/*' />
    public partial struct _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_SINGLE_COLOR
    {
        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_SINGLE_COLOR.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_SINGLE_COLOR.data"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L6432_C5")]
        public _data_e__Union data;

        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_SINGLE_COLOR.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_SINGLE_COLOR.rsvd"]/*' />
        [NativeTypeName("NvU8[64]")]
        public _rsvd_e__FixedBuffer rsvd;

        /// <include file='_data_e__Union.xml' path='doc/member[@name="_data_e__Union"]/*' />
        [StructLayout(LayoutKind.Explicit)]
        public partial struct _data_e__Union
        {
            /// <include file='_data_e__Union.xml' path='doc/member[@name="_data_e__Union.manualSingleColor"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_MANUAL_SINGLE_COLOR")]
            public _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_MANUAL_SINGLE_COLOR manualSingleColor;

            /// <include file='_data_e__Union.xml' path='doc/member[@name="_data_e__Union.piecewiseLinearSingleColor"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_SINGLE_COLOR")]
            public _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_SINGLE_COLOR piecewiseLinearSingleColor;

            /// <include file='_data_e__Union.xml' path='doc/member[@name="_data_e__Union.rsvd"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NvU8[64]")]
            public _rsvd_e__FixedBuffer rsvd;

            /// <include file='_rsvd_e__FixedBuffer.xml' path='doc/member[@name="_rsvd_e__FixedBuffer"]/*' />
            [InlineArray(64)]
            public partial struct _rsvd_e__FixedBuffer
            {
                public byte e0;
            }
        }

        /// <include file='_rsvd_e__FixedBuffer.xml' path='doc/member[@name="_rsvd_e__FixedBuffer"]/*' />
        [InlineArray(64)]
        public partial struct _rsvd_e__FixedBuffer
        {
            public byte e0;
        }
    }
}
