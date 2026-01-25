using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_MULTIVIEW_PARAMS_V1.xml' path='doc/member[@name="_NV_MULTIVIEW_PARAMS_V1"]/*' />
    public partial struct _NV_MULTIVIEW_PARAMS_V1
    {
        /// <include file='_NV_MULTIVIEW_PARAMS_V1.xml' path='doc/member[@name="_NV_MULTIVIEW_PARAMS_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_MULTIVIEW_PARAMS_V1.xml' path='doc/member[@name="_NV_MULTIVIEW_PARAMS_V1.numViews"]/*' />
        [NativeTypeName("NvU32")]
        public uint numViews;

        /// <include file='_NV_MULTIVIEW_PARAMS_V1.xml' path='doc/member[@name="_NV_MULTIVIEW_PARAMS_V1.renderTargetIndexOffset"]/*' />
        [NativeTypeName("NvU32[4]")]
        public _renderTargetIndexOffset_e__FixedBuffer renderTargetIndexOffset;

        /// <include file='_NV_MULTIVIEW_PARAMS_V1.xml' path='doc/member[@name="_NV_MULTIVIEW_PARAMS_V1.independentViewportMaskEnable"]/*' />
        [NativeTypeName("NvU8")]
        public byte independentViewportMaskEnable;

        /// <include file='_renderTargetIndexOffset_e__FixedBuffer.xml' path='doc/member[@name="_renderTargetIndexOffset_e__FixedBuffer"]/*' />
        [InlineArray(4)]
        public partial struct _renderTargetIndexOffset_e__FixedBuffer
        {
            public uint e0;
        }
    }
}
