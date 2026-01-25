using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_RGBW.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_RGBW"]/*' />
    public partial struct _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_RGBW
    {
        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_RGBW.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_RGBW.rgbwParams"]/*' />
        [NativeTypeName("NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_MANUAL_RGBW_PARAMS[2]")]
        public _rgbwParams_e__FixedBuffer rgbwParams;

        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_RGBW.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_RGBW.piecewiseLinearData"]/*' />
        [NativeTypeName("NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR")]
        public _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR piecewiseLinearData;

        /// <include file='_rgbwParams_e__FixedBuffer.xml' path='doc/member[@name="_rgbwParams_e__FixedBuffer"]/*' />
        [InlineArray(2)]
        public partial struct _rgbwParams_e__FixedBuffer
        {
            public _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_MANUAL_RGBW_PARAMS e0;
        }
    }
}
