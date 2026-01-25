namespace NVAPIWrapper
{
    /// <include file='EValues_AA_BEHAVIOR_FLAGS.xml' path='doc/member[@name="EValues_AA_BEHAVIOR_FLAGS"]/*' />
    public enum EValues_AA_BEHAVIOR_FLAGS
    {
        /// <include file='EValues_AA_BEHAVIOR_FLAGS.xml' path='doc/member[@name="EValues_AA_BEHAVIOR_FLAGS.AA_BEHAVIOR_FLAGS_NONE"]/*' />
        AA_BEHAVIOR_FLAGS_NONE = 0x00000000,

        /// <include file='EValues_AA_BEHAVIOR_FLAGS.xml' path='doc/member[@name="EValues_AA_BEHAVIOR_FLAGS.AA_BEHAVIOR_FLAGS_TREAT_OVERRIDE_AS_APP_CONTROLLED"]/*' />
        AA_BEHAVIOR_FLAGS_TREAT_OVERRIDE_AS_APP_CONTROLLED = 0x00000001,

        /// <include file='EValues_AA_BEHAVIOR_FLAGS.xml' path='doc/member[@name="EValues_AA_BEHAVIOR_FLAGS.AA_BEHAVIOR_FLAGS_TREAT_OVERRIDE_AS_ENHANCE"]/*' />
        AA_BEHAVIOR_FLAGS_TREAT_OVERRIDE_AS_ENHANCE = 0x00000002,

        /// <include file='EValues_AA_BEHAVIOR_FLAGS.xml' path='doc/member[@name="EValues_AA_BEHAVIOR_FLAGS.AA_BEHAVIOR_FLAGS_DISABLE_OVERRIDE"]/*' />
        AA_BEHAVIOR_FLAGS_DISABLE_OVERRIDE = 0x00000003,

        /// <include file='EValues_AA_BEHAVIOR_FLAGS.xml' path='doc/member[@name="EValues_AA_BEHAVIOR_FLAGS.AA_BEHAVIOR_FLAGS_TREAT_ENHANCE_AS_APP_CONTROLLED"]/*' />
        AA_BEHAVIOR_FLAGS_TREAT_ENHANCE_AS_APP_CONTROLLED = 0x00000004,

        /// <include file='EValues_AA_BEHAVIOR_FLAGS.xml' path='doc/member[@name="EValues_AA_BEHAVIOR_FLAGS.AA_BEHAVIOR_FLAGS_TREAT_ENHANCE_AS_OVERRIDE"]/*' />
        AA_BEHAVIOR_FLAGS_TREAT_ENHANCE_AS_OVERRIDE = 0x00000008,

        /// <include file='EValues_AA_BEHAVIOR_FLAGS.xml' path='doc/member[@name="EValues_AA_BEHAVIOR_FLAGS.AA_BEHAVIOR_FLAGS_DISABLE_ENHANCE"]/*' />
        AA_BEHAVIOR_FLAGS_DISABLE_ENHANCE = 0x0000000c,

        /// <include file='EValues_AA_BEHAVIOR_FLAGS.xml' path='doc/member[@name="EValues_AA_BEHAVIOR_FLAGS.AA_BEHAVIOR_FLAGS_MAP_VCAA_TO_MULTISAMPLING"]/*' />
        AA_BEHAVIOR_FLAGS_MAP_VCAA_TO_MULTISAMPLING = 0x00010000,

        /// <include file='EValues_AA_BEHAVIOR_FLAGS.xml' path='doc/member[@name="EValues_AA_BEHAVIOR_FLAGS.AA_BEHAVIOR_FLAGS_SLI_DISABLE_TRANSPARENCY_SUPERSAMPLING"]/*' />
        AA_BEHAVIOR_FLAGS_SLI_DISABLE_TRANSPARENCY_SUPERSAMPLING = 0x00020000,

        /// <include file='EValues_AA_BEHAVIOR_FLAGS.xml' path='doc/member[@name="EValues_AA_BEHAVIOR_FLAGS.AA_BEHAVIOR_FLAGS_DISABLE_CPLAA"]/*' />
        AA_BEHAVIOR_FLAGS_DISABLE_CPLAA = 0x00040000,

        /// <include file='EValues_AA_BEHAVIOR_FLAGS.xml' path='doc/member[@name="EValues_AA_BEHAVIOR_FLAGS.AA_BEHAVIOR_FLAGS_SKIP_RT_DIM_CHECK_FOR_ENHANCE"]/*' />
        AA_BEHAVIOR_FLAGS_SKIP_RT_DIM_CHECK_FOR_ENHANCE = 0x00080000,

        /// <include file='EValues_AA_BEHAVIOR_FLAGS.xml' path='doc/member[@name="EValues_AA_BEHAVIOR_FLAGS.AA_BEHAVIOR_FLAGS_DISABLE_SLIAA"]/*' />
        AA_BEHAVIOR_FLAGS_DISABLE_SLIAA = 0x00100000,

        /// <include file='EValues_AA_BEHAVIOR_FLAGS.xml' path='doc/member[@name="EValues_AA_BEHAVIOR_FLAGS.AA_BEHAVIOR_FLAGS_DEFAULT"]/*' />
        AA_BEHAVIOR_FLAGS_DEFAULT = 0x00000000,

        /// <include file='EValues_AA_BEHAVIOR_FLAGS.xml' path='doc/member[@name="EValues_AA_BEHAVIOR_FLAGS.AA_BEHAVIOR_FLAGS_AA_RT_BPP_DIV_4"]/*' />
        AA_BEHAVIOR_FLAGS_AA_RT_BPP_DIV_4 = unchecked((int)(0xf0000000)),

        /// <include file='EValues_AA_BEHAVIOR_FLAGS.xml' path='doc/member[@name="EValues_AA_BEHAVIOR_FLAGS.AA_BEHAVIOR_FLAGS_AA_RT_BPP_DIV_4_SHIFT"]/*' />
        AA_BEHAVIOR_FLAGS_AA_RT_BPP_DIV_4_SHIFT = 28,

        /// <include file='EValues_AA_BEHAVIOR_FLAGS.xml' path='doc/member[@name="EValues_AA_BEHAVIOR_FLAGS.AA_BEHAVIOR_FLAGS_NON_AA_RT_BPP_DIV_4"]/*' />
        AA_BEHAVIOR_FLAGS_NON_AA_RT_BPP_DIV_4 = 0x0f000000,

        /// <include file='EValues_AA_BEHAVIOR_FLAGS.xml' path='doc/member[@name="EValues_AA_BEHAVIOR_FLAGS.AA_BEHAVIOR_FLAGS_NON_AA_RT_BPP_DIV_4_SHIFT"]/*' />
        AA_BEHAVIOR_FLAGS_NON_AA_RT_BPP_DIV_4_SHIFT = 24,

        /// <include file='EValues_AA_BEHAVIOR_FLAGS.xml' path='doc/member[@name="EValues_AA_BEHAVIOR_FLAGS.AA_BEHAVIOR_FLAGS_MASK"]/*' />
        AA_BEHAVIOR_FLAGS_MASK = unchecked((int)(0xff1f000f)),

        /// <include file='EValues_AA_BEHAVIOR_FLAGS.xml' path='doc/member[@name="EValues_AA_BEHAVIOR_FLAGS.AA_BEHAVIOR_FLAGS_NUM_VALUES"]/*' />
        AA_BEHAVIOR_FLAGS_NUM_VALUES = 18,
    }
}
