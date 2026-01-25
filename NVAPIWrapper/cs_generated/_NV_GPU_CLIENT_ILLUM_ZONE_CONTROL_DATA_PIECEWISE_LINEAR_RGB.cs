using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_RGB.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_RGB"]/*' />
    public partial struct _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_RGB
    {
        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_RGB.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_RGB.rgbParams"]/*' />
        [NativeTypeName("NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_MANUAL_RGB_PARAMS[2]")]
        public _rgbParams_e__FixedBuffer rgbParams;

        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_RGB.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_RGB.piecewiseLinearData"]/*' />
        [NativeTypeName("NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR")]
        public _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR piecewiseLinearData;

        /// <include file='_rgbParams_e__FixedBuffer.xml' path='doc/member[@name="_rgbParams_e__FixedBuffer"]/*' />
        [InlineArray(2)]
        public partial struct _rgbParams_e__FixedBuffer
        {
            public _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_MANUAL_RGB_PARAMS e0;
        }
    }
}
