using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_RGBW.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_RGBW"]/*' />
    public partial struct _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_RGBW
    {
        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_RGBW.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_RGBW.data"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L6358_C5")]
        public _data_e__Union data;

        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_RGBW.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_RGBW.rsvd"]/*' />
        [NativeTypeName("NvU8[64]")]
        public _rsvd_e__FixedBuffer rsvd;

        /// <include file='_data_e__Union.xml' path='doc/member[@name="_data_e__Union"]/*' />
        [StructLayout(LayoutKind.Explicit)]
        public partial struct _data_e__Union
        {
            /// <include file='_data_e__Union.xml' path='doc/member[@name="_data_e__Union.manualRGBW"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_MANUAL_RGBW")]
            public _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_MANUAL_RGBW manualRGBW;

            /// <include file='_data_e__Union.xml' path='doc/member[@name="_data_e__Union.piecewiseLinearRGBW"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_RGBW")]
            public _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_RGBW piecewiseLinearRGBW;

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
