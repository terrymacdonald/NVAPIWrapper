namespace NVAPIWrapper
{
    /// <include file='_NV_PRESENT_BARRIER_SYNC_MODE.xml' path='doc/member[@name="_NV_PRESENT_BARRIER_SYNC_MODE"]/*' />
    public enum _NV_PRESENT_BARRIER_SYNC_MODE
    {
        /// <include file='_NV_PRESENT_BARRIER_SYNC_MODE.xml' path='doc/member[@name="_NV_PRESENT_BARRIER_SYNC_MODE.PRESENT_BARRIER_NOT_JOINED"]/*' />
        PRESENT_BARRIER_NOT_JOINED = 0x00000000,

        /// <include file='_NV_PRESENT_BARRIER_SYNC_MODE.xml' path='doc/member[@name="_NV_PRESENT_BARRIER_SYNC_MODE.PRESENT_BARRIER_SYNC_CLIENT"]/*' />
        PRESENT_BARRIER_SYNC_CLIENT = 0x00000001,

        /// <include file='_NV_PRESENT_BARRIER_SYNC_MODE.xml' path='doc/member[@name="_NV_PRESENT_BARRIER_SYNC_MODE.PRESENT_BARRIER_SYNC_SYSTEM"]/*' />
        PRESENT_BARRIER_SYNC_SYSTEM = 0x00000002,

        /// <include file='_NV_PRESENT_BARRIER_SYNC_MODE.xml' path='doc/member[@name="_NV_PRESENT_BARRIER_SYNC_MODE.PRESENT_BARRIER_SYNC_CLUSTER"]/*' />
        PRESENT_BARRIER_SYNC_CLUSTER = 0x00000003,
    }
}
