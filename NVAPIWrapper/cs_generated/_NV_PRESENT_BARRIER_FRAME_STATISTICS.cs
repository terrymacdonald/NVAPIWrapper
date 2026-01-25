namespace NVAPIWrapper
{
    /// <include file='_NV_PRESENT_BARRIER_FRAME_STATISTICS.xml' path='doc/member[@name="_NV_PRESENT_BARRIER_FRAME_STATISTICS"]/*' />
    public partial struct _NV_PRESENT_BARRIER_FRAME_STATISTICS
    {
        /// <include file='_NV_PRESENT_BARRIER_FRAME_STATISTICS.xml' path='doc/member[@name="_NV_PRESENT_BARRIER_FRAME_STATISTICS.dwVersion"]/*' />
        [NativeTypeName("NvU32")]
        public uint dwVersion;

        /// <include file='_NV_PRESENT_BARRIER_FRAME_STATISTICS.xml' path='doc/member[@name="_NV_PRESENT_BARRIER_FRAME_STATISTICS.SyncMode"]/*' />
        [NativeTypeName("NV_PRESENT_BARRIER_SYNC_MODE")]
        public _NV_PRESENT_BARRIER_SYNC_MODE SyncMode;

        /// <include file='_NV_PRESENT_BARRIER_FRAME_STATISTICS.xml' path='doc/member[@name="_NV_PRESENT_BARRIER_FRAME_STATISTICS.PresentCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint PresentCount;

        /// <include file='_NV_PRESENT_BARRIER_FRAME_STATISTICS.xml' path='doc/member[@name="_NV_PRESENT_BARRIER_FRAME_STATISTICS.PresentInSyncCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint PresentInSyncCount;

        /// <include file='_NV_PRESENT_BARRIER_FRAME_STATISTICS.xml' path='doc/member[@name="_NV_PRESENT_BARRIER_FRAME_STATISTICS.FlipInSyncCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint FlipInSyncCount;

        /// <include file='_NV_PRESENT_BARRIER_FRAME_STATISTICS.xml' path='doc/member[@name="_NV_PRESENT_BARRIER_FRAME_STATISTICS.RefreshCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint RefreshCount;
    }
}
