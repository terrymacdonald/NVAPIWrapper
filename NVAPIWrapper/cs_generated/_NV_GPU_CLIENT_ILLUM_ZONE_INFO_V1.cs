using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_INFO_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_INFO_V1"]/*' />
    public partial struct _NV_GPU_CLIENT_ILLUM_ZONE_INFO_V1
    {
        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_INFO_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_INFO_V1.type"]/*' />
        public NV_GPU_CLIENT_ILLUM_ZONE_TYPE type;

        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_INFO_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_INFO_V1.illumDeviceIdx"]/*' />
        [NativeTypeName("NvU8")]
        public byte illumDeviceIdx;

        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_INFO_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_INFO_V1.provIdx"]/*' />
        [NativeTypeName("NvU8")]
        public byte provIdx;

        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_INFO_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_INFO_V1.zoneLocation"]/*' />
        public NV_GPU_CLIENT_ILLUM_ZONE_LOCATION zoneLocation;

        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_INFO_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_INFO_V1.data"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L6005_C5")]
        public _data_e__Union data;

        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_INFO_V1.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_INFO_V1.rsvd"]/*' />
        [NativeTypeName("NvU8[64]")]
        public _rsvd_e__FixedBuffer rsvd;

        /// <include file='_data_e__Union.xml' path='doc/member[@name="_data_e__Union"]/*' />
        [StructLayout(LayoutKind.Explicit)]
        public partial struct _data_e__Union
        {
            /// <include file='_data_e__Union.xml' path='doc/member[@name="_data_e__Union.rgb"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NV_GPU_CLIENT_ILLUM_ZONE_INFO_DATA_RGB")]
            public _NV_GPU_CLIENT_ILLUM_ZONE_INFO_DATA_RGB rgb;

            /// <include file='_data_e__Union.xml' path='doc/member[@name="_data_e__Union.rgbw"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NV_GPU_CLIENT_ILLUM_ZONE_INFO_DATA_RGBW")]
            public _NV_GPU_CLIENT_ILLUM_ZONE_INFO_DATA_RGBW rgbw;

            /// <include file='_data_e__Union.xml' path='doc/member[@name="_data_e__Union.singleColor"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NV_GPU_CLIENT_ILLUM_ZONE_INFO_DATA_SINGLE_COLOR")]
            public _NV_GPU_CLIENT_ILLUM_ZONE_INFO_DATA_SINGLE_COLOR singleColor;

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
