using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_SINGLE_COLOR.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_SINGLE_COLOR"]/*' />
    public partial struct _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_SINGLE_COLOR
    {
        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_SINGLE_COLOR.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_SINGLE_COLOR.singleColorParams"]/*' />
        [NativeTypeName("NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_MANUAL_SINGLE_COLOR_PARAMS[2]")]
        public _singleColorParams_e__FixedBuffer singleColorParams;

        /// <include file='_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_SINGLE_COLOR.xml' path='doc/member[@name="_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR_SINGLE_COLOR.piecewiseLinearData"]/*' />
        [NativeTypeName("NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR")]
        public _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_PIECEWISE_LINEAR piecewiseLinearData;

        /// <include file='_singleColorParams_e__FixedBuffer.xml' path='doc/member[@name="_singleColorParams_e__FixedBuffer"]/*' />
        [InlineArray(2)]
        public partial struct _singleColorParams_e__FixedBuffer
        {
            public _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_DATA_MANUAL_SINGLE_COLOR_PARAMS e0;
        }
    }
}
