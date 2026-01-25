namespace NVAPIWrapper
{
    /// <include file='EValues_SLI_RENDERING_MODE.xml' path='doc/member[@name="EValues_SLI_RENDERING_MODE"]/*' />
    public enum EValues_SLI_RENDERING_MODE
    {
        /// <include file='EValues_SLI_RENDERING_MODE.xml' path='doc/member[@name="EValues_SLI_RENDERING_MODE.SLI_RENDERING_MODE_AUTOSELECT"]/*' />
        SLI_RENDERING_MODE_AUTOSELECT = 0x00000000,

        /// <include file='EValues_SLI_RENDERING_MODE.xml' path='doc/member[@name="EValues_SLI_RENDERING_MODE.SLI_RENDERING_MODE_FORCE_SINGLE"]/*' />
        SLI_RENDERING_MODE_FORCE_SINGLE = 0x00000001,

        /// <include file='EValues_SLI_RENDERING_MODE.xml' path='doc/member[@name="EValues_SLI_RENDERING_MODE.SLI_RENDERING_MODE_FORCE_AFR"]/*' />
        SLI_RENDERING_MODE_FORCE_AFR = 0x00000002,

        /// <include file='EValues_SLI_RENDERING_MODE.xml' path='doc/member[@name="EValues_SLI_RENDERING_MODE.SLI_RENDERING_MODE_FORCE_AFR2"]/*' />
        SLI_RENDERING_MODE_FORCE_AFR2 = 0x00000003,

        /// <include file='EValues_SLI_RENDERING_MODE.xml' path='doc/member[@name="EValues_SLI_RENDERING_MODE.SLI_RENDERING_MODE_FORCE_SFR"]/*' />
        SLI_RENDERING_MODE_FORCE_SFR = 0x00000004,

        /// <include file='EValues_SLI_RENDERING_MODE.xml' path='doc/member[@name="EValues_SLI_RENDERING_MODE.SLI_RENDERING_MODE_FORCE_AFR_OF_SFR__FALLBACK_3AFR"]/*' />
        SLI_RENDERING_MODE_FORCE_AFR_OF_SFR__FALLBACK_3AFR = 0x00000005,

        /// <include file='EValues_SLI_RENDERING_MODE.xml' path='doc/member[@name="EValues_SLI_RENDERING_MODE.SLI_RENDERING_MODE_NUM_VALUES"]/*' />
        SLI_RENDERING_MODE_NUM_VALUES = 6,

        /// <include file='EValues_SLI_RENDERING_MODE.xml' path='doc/member[@name="EValues_SLI_RENDERING_MODE.SLI_RENDERING_MODE_DEFAULT"]/*' />
        SLI_RENDERING_MODE_DEFAULT = SLI_RENDERING_MODE_AUTOSELECT,
    }
}
