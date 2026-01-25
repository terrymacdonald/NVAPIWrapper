namespace NVAPIWrapper
{
    /// <include file='EValues_SHIM_RENDERING_MODE.xml' path='doc/member[@name="EValues_SHIM_RENDERING_MODE"]/*' />
    public enum EValues_SHIM_RENDERING_MODE
    {
        /// <include file='EValues_SHIM_RENDERING_MODE.xml' path='doc/member[@name="EValues_SHIM_RENDERING_MODE.SHIM_RENDERING_MODE_INTEGRATED"]/*' />
        SHIM_RENDERING_MODE_INTEGRATED = 0x00000000U,

        /// <include file='EValues_SHIM_RENDERING_MODE.xml' path='doc/member[@name="EValues_SHIM_RENDERING_MODE.SHIM_RENDERING_MODE_ENABLE"]/*' />
        SHIM_RENDERING_MODE_ENABLE = 0x00000001U,

        /// <include file='EValues_SHIM_RENDERING_MODE.xml' path='doc/member[@name="EValues_SHIM_RENDERING_MODE.SHIM_RENDERING_MODE_USER_EDITABLE"]/*' />
        SHIM_RENDERING_MODE_USER_EDITABLE = 0x00000002U,

        /// <include file='EValues_SHIM_RENDERING_MODE.xml' path='doc/member[@name="EValues_SHIM_RENDERING_MODE.SHIM_RENDERING_MODE_MASK"]/*' />
        SHIM_RENDERING_MODE_MASK = 0x00000003U,

        /// <include file='EValues_SHIM_RENDERING_MODE.xml' path='doc/member[@name="EValues_SHIM_RENDERING_MODE.SHIM_RENDERING_MODE_VIDEO_MASK"]/*' />
        SHIM_RENDERING_MODE_VIDEO_MASK = 0x00000004U,

        /// <include file='EValues_SHIM_RENDERING_MODE.xml' path='doc/member[@name="EValues_SHIM_RENDERING_MODE.SHIM_RENDERING_MODE_VARYING_BIT"]/*' />
        SHIM_RENDERING_MODE_VARYING_BIT = 0x00000008U,

        /// <include file='EValues_SHIM_RENDERING_MODE.xml' path='doc/member[@name="EValues_SHIM_RENDERING_MODE.SHIM_RENDERING_MODE_AUTO_SELECT"]/*' />
        SHIM_RENDERING_MODE_AUTO_SELECT = 0x00000010U,

        /// <include file='EValues_SHIM_RENDERING_MODE.xml' path='doc/member[@name="EValues_SHIM_RENDERING_MODE.SHIM_RENDERING_MODE_OVERRIDE_BIT"]/*' />
        SHIM_RENDERING_MODE_OVERRIDE_BIT = unchecked((int)(0x80000000U)),

        /// <include file='EValues_SHIM_RENDERING_MODE.xml' path='doc/member[@name="EValues_SHIM_RENDERING_MODE.SHIM_RENDERING_MODE_NUM_VALUES"]/*' />
        SHIM_RENDERING_MODE_NUM_VALUES = 8,

        /// <include file='EValues_SHIM_RENDERING_MODE.xml' path='doc/member[@name="EValues_SHIM_RENDERING_MODE.SHIM_RENDERING_MODE_DEFAULT"]/*' />
        SHIM_RENDERING_MODE_DEFAULT = SHIM_RENDERING_MODE_AUTO_SELECT,
    }
}
