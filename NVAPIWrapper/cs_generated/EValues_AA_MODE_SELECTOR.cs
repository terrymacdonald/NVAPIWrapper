namespace NVAPIWrapper
{
    /// <include file='EValues_AA_MODE_SELECTOR.xml' path='doc/member[@name="EValues_AA_MODE_SELECTOR"]/*' />
    public enum EValues_AA_MODE_SELECTOR
    {
        /// <include file='EValues_AA_MODE_SELECTOR.xml' path='doc/member[@name="EValues_AA_MODE_SELECTOR.AA_MODE_SELECTOR_MASK"]/*' />
        AA_MODE_SELECTOR_MASK = 0x00000003,

        /// <include file='EValues_AA_MODE_SELECTOR.xml' path='doc/member[@name="EValues_AA_MODE_SELECTOR.AA_MODE_SELECTOR_APP_CONTROL"]/*' />
        AA_MODE_SELECTOR_APP_CONTROL = 0x00000000,

        /// <include file='EValues_AA_MODE_SELECTOR.xml' path='doc/member[@name="EValues_AA_MODE_SELECTOR.AA_MODE_SELECTOR_OVERRIDE"]/*' />
        AA_MODE_SELECTOR_OVERRIDE = 0x00000001,

        /// <include file='EValues_AA_MODE_SELECTOR.xml' path='doc/member[@name="EValues_AA_MODE_SELECTOR.AA_MODE_SELECTOR_ENHANCE"]/*' />
        AA_MODE_SELECTOR_ENHANCE = 0x00000002,

        /// <include file='EValues_AA_MODE_SELECTOR.xml' path='doc/member[@name="EValues_AA_MODE_SELECTOR.AA_MODE_SELECTOR_MAX"]/*' />
        AA_MODE_SELECTOR_MAX = 0x00000002,

        /// <include file='EValues_AA_MODE_SELECTOR.xml' path='doc/member[@name="EValues_AA_MODE_SELECTOR.AA_MODE_SELECTOR_NUM_VALUES"]/*' />
        AA_MODE_SELECTOR_NUM_VALUES = 5,

        /// <include file='EValues_AA_MODE_SELECTOR.xml' path='doc/member[@name="EValues_AA_MODE_SELECTOR.AA_MODE_SELECTOR_DEFAULT"]/*' />
        AA_MODE_SELECTOR_DEFAULT = AA_MODE_SELECTOR_APP_CONTROL,
    }
}
