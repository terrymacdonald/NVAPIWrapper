namespace NVAPIWrapper
{
    /// <include file='_NV_LICENSE_FEATURE_TYPE.xml' path='doc/member[@name="_NV_LICENSE_FEATURE_TYPE"]/*' />
    public enum _NV_LICENSE_FEATURE_TYPE
    {
        /// <include file='_NV_LICENSE_FEATURE_TYPE.xml' path='doc/member[@name="_NV_LICENSE_FEATURE_TYPE.NV_LICENSE_FEATURE_UNKNOWN"]/*' />
        NV_LICENSE_FEATURE_UNKNOWN = 0,

        /// <include file='_NV_LICENSE_FEATURE_TYPE.xml' path='doc/member[@name="_NV_LICENSE_FEATURE_TYPE.NV_LICENSE_FEATURE_VGPU"]/*' />
        NV_LICENSE_FEATURE_VGPU = 1,

        /// <include file='_NV_LICENSE_FEATURE_TYPE.xml' path='doc/member[@name="_NV_LICENSE_FEATURE_TYPE.NV_LICENSE_FEATURE_NVIDIA_RTX"]/*' />
        NV_LICENSE_FEATURE_NVIDIA_RTX = 2,

        /// <include file='_NV_LICENSE_FEATURE_TYPE.xml' path='doc/member[@name="_NV_LICENSE_FEATURE_TYPE.NV_LICENSE_FEATURE_QUADRO"]/*' />
        NV_LICENSE_FEATURE_QUADRO = NV_LICENSE_FEATURE_NVIDIA_RTX,

        /// <include file='_NV_LICENSE_FEATURE_TYPE.xml' path='doc/member[@name="_NV_LICENSE_FEATURE_TYPE.NV_LICENSE_FEATURE_GAMING"]/*' />
        NV_LICENSE_FEATURE_GAMING = 3,

        /// <include file='_NV_LICENSE_FEATURE_TYPE.xml' path='doc/member[@name="_NV_LICENSE_FEATURE_TYPE.NV_LICENSE_FEATURE_COMPUTE"]/*' />
        NV_LICENSE_FEATURE_COMPUTE = 4,
    }
}
