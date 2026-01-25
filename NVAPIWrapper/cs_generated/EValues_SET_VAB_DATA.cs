namespace NVAPIWrapper
{
    /// <include file='EValues_SET_VAB_DATA.xml' path='doc/member[@name="EValues_SET_VAB_DATA"]/*' />
    public enum EValues_SET_VAB_DATA
    {
        /// <include file='EValues_SET_VAB_DATA.xml' path='doc/member[@name="EValues_SET_VAB_DATA.SET_VAB_DATA_ZERO"]/*' />
        SET_VAB_DATA_ZERO = 0x00000000,

        /// <include file='EValues_SET_VAB_DATA.xml' path='doc/member[@name="EValues_SET_VAB_DATA.SET_VAB_DATA_UINT_ONE"]/*' />
        SET_VAB_DATA_UINT_ONE = 0x00000001,

        /// <include file='EValues_SET_VAB_DATA.xml' path='doc/member[@name="EValues_SET_VAB_DATA.SET_VAB_DATA_FLOAT_ONE"]/*' />
        SET_VAB_DATA_FLOAT_ONE = 0x3f800000,

        /// <include file='EValues_SET_VAB_DATA.xml' path='doc/member[@name="EValues_SET_VAB_DATA.SET_VAB_DATA_FLOAT_POS_INF"]/*' />
        SET_VAB_DATA_FLOAT_POS_INF = 0x7f800000,

        /// <include file='EValues_SET_VAB_DATA.xml' path='doc/member[@name="EValues_SET_VAB_DATA.SET_VAB_DATA_FLOAT_NAN"]/*' />
        SET_VAB_DATA_FLOAT_NAN = 0x7fc00000,

        /// <include file='EValues_SET_VAB_DATA.xml' path='doc/member[@name="EValues_SET_VAB_DATA.SET_VAB_DATA_USE_API_DEFAULTS"]/*' />
        SET_VAB_DATA_USE_API_DEFAULTS = unchecked((int)(0xffffffff)),

        /// <include file='EValues_SET_VAB_DATA.xml' path='doc/member[@name="EValues_SET_VAB_DATA.SET_VAB_DATA_NUM_VALUES"]/*' />
        SET_VAB_DATA_NUM_VALUES = 6,

        /// <include file='EValues_SET_VAB_DATA.xml' path='doc/member[@name="EValues_SET_VAB_DATA.SET_VAB_DATA_DEFAULT"]/*' />
        SET_VAB_DATA_DEFAULT = SET_VAB_DATA_USE_API_DEFAULTS,
    }
}
