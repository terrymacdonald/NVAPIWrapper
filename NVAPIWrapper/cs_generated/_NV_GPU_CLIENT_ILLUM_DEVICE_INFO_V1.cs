using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_V1"]/*' />
    public partial struct _NV_GPU_CLIENT_ILLUM_DEVICE_INFO_V1
    {
        /// <include file='_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_V1.type"]/*' />
        public NV_GPU_CLIENT_ILLUM_DEVICE_TYPE type;

        /// <include file='_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_V1.ctrlModeMask"]/*' />
        [NativeTypeName("NvU32")]
        public uint ctrlModeMask;

        /// <include file='_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_V1.data"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L5764_C5")]
        public _data_e__Union data;

        /// <include file='_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_V1.rsvd"]/*' />
        [NativeTypeName("NvU8[64]")]
        public _rsvd_e__FixedBuffer rsvd;

        /// <include file='_data_e__Union.xml' path='doc/member[@name="_data_e__Union"]/*' />
        [StructLayout(LayoutKind.Explicit)]
        public partial struct _data_e__Union
        {
            /// <include file='_data_e__Union.xml' path='doc/member[@name="_data_e__Union.mcuv10"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NV_GPU_CLIENT_ILLUM_DEVICE_INFO_DATA_MCUV10")]
            public _NV_GPU_CLIENT_ILLUM_DEVICE_INFO_DATA_MCUV10 mcuv10;

            /// <include file='_data_e__Union.xml' path='doc/member[@name="_data_e__Union.gpioPwmRgbwv10"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NV_GPU_CLIENT_ILLUM_DEVICE_INFO_DATA_GPIO_PWM_RGBW")]
            public _NV_GPU_CLIENT_ILLUM_DEVICE_INFO_DATA_GPIO_PWM_RGBW gpioPwmRgbwv10;

            /// <include file='_data_e__Union.xml' path='doc/member[@name="_data_e__Union.gpioPwmSingleColorv10"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NV_GPU_CLIENT_ILLUM_DEVICE_INFO_DATA_GPIO_PWM_SINGLE_COLOR")]
            public _NV_GPU_CLIENT_ILLUM_DEVICE_INFO_DATA_GPIO_PWM_SINGLE_COLOR gpioPwmSingleColorv10;

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
