namespace NVAPIWrapper
{
    /// <include file='EValues_VRR_MODE.xml' path='doc/member[@name="EValues_VRR_MODE"]/*' />
    public enum EValues_VRR_MODE
    {
        /// <include file='EValues_VRR_MODE.xml' path='doc/member[@name="EValues_VRR_MODE.VRR_MODE_DISABLED"]/*' />
        VRR_MODE_DISABLED = 0x0,

        /// <include file='EValues_VRR_MODE.xml' path='doc/member[@name="EValues_VRR_MODE.VRR_MODE_FULLSCREEN_ONLY"]/*' />
        VRR_MODE_FULLSCREEN_ONLY = 0x1,

        /// <include file='EValues_VRR_MODE.xml' path='doc/member[@name="EValues_VRR_MODE.VRR_MODE_FULLSCREEN_AND_WINDOWED"]/*' />
        VRR_MODE_FULLSCREEN_AND_WINDOWED = 0x2,

        /// <include file='EValues_VRR_MODE.xml' path='doc/member[@name="EValues_VRR_MODE.VRR_MODE_NUM_VALUES"]/*' />
        VRR_MODE_NUM_VALUES = 3,

        /// <include file='EValues_VRR_MODE.xml' path='doc/member[@name="EValues_VRR_MODE.VRR_MODE_DEFAULT"]/*' />
        VRR_MODE_DEFAULT = VRR_MODE_FULLSCREEN_ONLY,
    }
}
