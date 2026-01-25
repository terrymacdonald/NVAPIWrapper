using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_COLOR_FIXED.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_COLOR_FIXED"]/*' />
    public partial struct _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_COLOR_FIXED
    {
        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_COLOR_FIXED.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_COLOR_FIXED.colorFixedParams"]/*' />
        [NativeTypeName("NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_MANUAL_COLOR_FIXED_PARAMS[2]")]
        public _colorFixedParams_e__FixedBuffer colorFixedParams;

        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_COLOR_FIXED.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_COLOR_FIXED.piecewiseLinearData"]/*' />
        [NativeTypeName("NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR")]
        public _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR piecewiseLinearData;

        /// <include file='_colorFixedParams_e__FixedBuffer.xml' path='doc/member[@name="_colorFixedParams_e__FixedBuffer"]/*' />
        [InlineArray(2)]
        public partial struct _colorFixedParams_e__FixedBuffer
        {
            public _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_MANUAL_COLOR_FIXED_PARAMS e0;
        }
    }
}
