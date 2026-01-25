namespace NVAPIWrapper
{
    /// <include file='_NV_SCALING.xml' path='doc/member[@name="_NV_SCALING"]/*' />
    public enum _NV_SCALING
    {
        /// <include file='_NV_SCALING.xml' path='doc/member[@name="_NV_SCALING.NV_SCALING_DEFAULT"]/*' />
        NV_SCALING_DEFAULT = 0,

        /// <include file='_NV_SCALING.xml' path='doc/member[@name="_NV_SCALING.NV_SCALING_GPU_SCALING_TO_CLOSEST"]/*' />
        NV_SCALING_GPU_SCALING_TO_CLOSEST = 1,

        /// <include file='_NV_SCALING.xml' path='doc/member[@name="_NV_SCALING.NV_SCALING_GPU_SCALING_TO_NATIVE"]/*' />
        NV_SCALING_GPU_SCALING_TO_NATIVE = 2,

        /// <include file='_NV_SCALING.xml' path='doc/member[@name="_NV_SCALING.NV_SCALING_GPU_SCANOUT_TO_NATIVE"]/*' />
        NV_SCALING_GPU_SCANOUT_TO_NATIVE = 3,

        /// <include file='_NV_SCALING.xml' path='doc/member[@name="_NV_SCALING.NV_SCALING_GPU_SCALING_TO_ASPECT_SCANOUT_TO_NATIVE"]/*' />
        NV_SCALING_GPU_SCALING_TO_ASPECT_SCANOUT_TO_NATIVE = 5,

        /// <include file='_NV_SCALING.xml' path='doc/member[@name="_NV_SCALING.NV_SCALING_GPU_SCALING_TO_ASPECT_SCANOUT_TO_CLOSEST"]/*' />
        NV_SCALING_GPU_SCALING_TO_ASPECT_SCANOUT_TO_CLOSEST = 6,

        /// <include file='_NV_SCALING.xml' path='doc/member[@name="_NV_SCALING.NV_SCALING_GPU_SCANOUT_TO_CLOSEST"]/*' />
        NV_SCALING_GPU_SCANOUT_TO_CLOSEST = 7,

        /// <include file='_NV_SCALING.xml' path='doc/member[@name="_NV_SCALING.NV_SCALING_GPU_INTEGER_ASPECT_SCALING"]/*' />
        NV_SCALING_GPU_INTEGER_ASPECT_SCALING = 8,

        /// <include file='_NV_SCALING.xml' path='doc/member[@name="_NV_SCALING.NV_SCALING_MONITOR_SCALING"]/*' />
        NV_SCALING_MONITOR_SCALING = NV_SCALING_GPU_SCALING_TO_CLOSEST,

        /// <include file='_NV_SCALING.xml' path='doc/member[@name="_NV_SCALING.NV_SCALING_ADAPTER_SCALING"]/*' />
        NV_SCALING_ADAPTER_SCALING = NV_SCALING_GPU_SCALING_TO_NATIVE,

        /// <include file='_NV_SCALING.xml' path='doc/member[@name="_NV_SCALING.NV_SCALING_CENTERED"]/*' />
        NV_SCALING_CENTERED = NV_SCALING_GPU_SCANOUT_TO_NATIVE,

        /// <include file='_NV_SCALING.xml' path='doc/member[@name="_NV_SCALING.NV_SCALING_ASPECT_SCALING"]/*' />
        NV_SCALING_ASPECT_SCALING = NV_SCALING_GPU_SCALING_TO_ASPECT_SCANOUT_TO_NATIVE,

        /// <include file='_NV_SCALING.xml' path='doc/member[@name="_NV_SCALING.NV_SCALING_CUSTOMIZED"]/*' />
        NV_SCALING_CUSTOMIZED = 255,
    }
}
