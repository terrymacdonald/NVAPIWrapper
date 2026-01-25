namespace NVAPIWrapper
{
    /// <include file='EValues_PREFERRED_PSTATE.xml' path='doc/member[@name="EValues_PREFERRED_PSTATE"]/*' />
    public enum EValues_PREFERRED_PSTATE
    {
        /// <include file='EValues_PREFERRED_PSTATE.xml' path='doc/member[@name="EValues_PREFERRED_PSTATE.PREFERRED_PSTATE_ADAPTIVE"]/*' />
        PREFERRED_PSTATE_ADAPTIVE = 0x00000000,

        /// <include file='EValues_PREFERRED_PSTATE.xml' path='doc/member[@name="EValues_PREFERRED_PSTATE.PREFERRED_PSTATE_PREFER_MAX"]/*' />
        PREFERRED_PSTATE_PREFER_MAX = 0x00000001,

        /// <include file='EValues_PREFERRED_PSTATE.xml' path='doc/member[@name="EValues_PREFERRED_PSTATE.PREFERRED_PSTATE_DRIVER_CONTROLLED"]/*' />
        PREFERRED_PSTATE_DRIVER_CONTROLLED = 0x00000002,

        /// <include file='EValues_PREFERRED_PSTATE.xml' path='doc/member[@name="EValues_PREFERRED_PSTATE.PREFERRED_PSTATE_PREFER_CONSISTENT_PERFORMANCE"]/*' />
        PREFERRED_PSTATE_PREFER_CONSISTENT_PERFORMANCE = 0x00000003,

        /// <include file='EValues_PREFERRED_PSTATE.xml' path='doc/member[@name="EValues_PREFERRED_PSTATE.PREFERRED_PSTATE_PREFER_MIN"]/*' />
        PREFERRED_PSTATE_PREFER_MIN = 0x00000004,

        /// <include file='EValues_PREFERRED_PSTATE.xml' path='doc/member[@name="EValues_PREFERRED_PSTATE.PREFERRED_PSTATE_OPTIMAL_POWER"]/*' />
        PREFERRED_PSTATE_OPTIMAL_POWER = 0x00000005,

        /// <include file='EValues_PREFERRED_PSTATE.xml' path='doc/member[@name="EValues_PREFERRED_PSTATE.PREFERRED_PSTATE_MIN"]/*' />
        PREFERRED_PSTATE_MIN = 0x00000000,

        /// <include file='EValues_PREFERRED_PSTATE.xml' path='doc/member[@name="EValues_PREFERRED_PSTATE.PREFERRED_PSTATE_MAX"]/*' />
        PREFERRED_PSTATE_MAX = 0x00000005,

        /// <include file='EValues_PREFERRED_PSTATE.xml' path='doc/member[@name="EValues_PREFERRED_PSTATE.PREFERRED_PSTATE_NUM_VALUES"]/*' />
        PREFERRED_PSTATE_NUM_VALUES = 8,

        /// <include file='EValues_PREFERRED_PSTATE.xml' path='doc/member[@name="EValues_PREFERRED_PSTATE.PREFERRED_PSTATE_DEFAULT"]/*' />
        PREFERRED_PSTATE_DEFAULT = PREFERRED_PSTATE_OPTIMAL_POWER,
    }
}
