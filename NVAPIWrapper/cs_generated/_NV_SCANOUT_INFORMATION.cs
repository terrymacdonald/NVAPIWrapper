namespace NVAPIWrapper
{
    /// <include file='_NV_SCANOUT_INFORMATION.xml' path='doc/member[@name="_NV_SCANOUT_INFORMATION"]/*' />
    public partial struct _NV_SCANOUT_INFORMATION
    {
        /// <include file='_NV_SCANOUT_INFORMATION.xml' path='doc/member[@name="_NV_SCANOUT_INFORMATION.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_SCANOUT_INFORMATION.xml' path='doc/member[@name="_NV_SCANOUT_INFORMATION.sourceDesktopRect"]/*' />
        public NvSBox sourceDesktopRect;

        /// <include file='_NV_SCANOUT_INFORMATION.xml' path='doc/member[@name="_NV_SCANOUT_INFORMATION.sourceViewportRect"]/*' />
        public NvSBox sourceViewportRect;

        /// <include file='_NV_SCANOUT_INFORMATION.xml' path='doc/member[@name="_NV_SCANOUT_INFORMATION.targetViewportRect"]/*' />
        public NvSBox targetViewportRect;

        /// <include file='_NV_SCANOUT_INFORMATION.xml' path='doc/member[@name="_NV_SCANOUT_INFORMATION.targetDisplayWidth"]/*' />
        [NativeTypeName("NvU32")]
        public uint targetDisplayWidth;

        /// <include file='_NV_SCANOUT_INFORMATION.xml' path='doc/member[@name="_NV_SCANOUT_INFORMATION.targetDisplayHeight"]/*' />
        [NativeTypeName("NvU32")]
        public uint targetDisplayHeight;

        /// <include file='_NV_SCANOUT_INFORMATION.xml' path='doc/member[@name="_NV_SCANOUT_INFORMATION.cloneImportance"]/*' />
        [NativeTypeName("NvU32")]
        public uint cloneImportance;

        /// <include file='_NV_SCANOUT_INFORMATION.xml' path='doc/member[@name="_NV_SCANOUT_INFORMATION.sourceToTargetRotation"]/*' />
        [NativeTypeName("NV_ROTATE")]
        public _NV_ROTATE sourceToTargetRotation;
    }
}
