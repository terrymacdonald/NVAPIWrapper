namespace NVAPIWrapper
{
    /// <include file='NV_LID_DOCK_PARAMS.xml' path='doc/member[@name="NV_LID_DOCK_PARAMS"]/*' />
    public partial struct NV_LID_DOCK_PARAMS
    {
        /// <include file='NV_LID_DOCK_PARAMS.xml' path='doc/member[@name="NV_LID_DOCK_PARAMS.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_LID_DOCK_PARAMS.xml' path='doc/member[@name="NV_LID_DOCK_PARAMS.currentLidState"]/*' />
        [NativeTypeName("NvU32")]
        public uint currentLidState;

        /// <include file='NV_LID_DOCK_PARAMS.xml' path='doc/member[@name="NV_LID_DOCK_PARAMS.currentDockState"]/*' />
        [NativeTypeName("NvU32")]
        public uint currentDockState;

        /// <include file='NV_LID_DOCK_PARAMS.xml' path='doc/member[@name="NV_LID_DOCK_PARAMS.currentLidPolicy"]/*' />
        [NativeTypeName("NvU32")]
        public uint currentLidPolicy;

        /// <include file='NV_LID_DOCK_PARAMS.xml' path='doc/member[@name="NV_LID_DOCK_PARAMS.currentDockPolicy"]/*' />
        [NativeTypeName("NvU32")]
        public uint currentDockPolicy;

        /// <include file='NV_LID_DOCK_PARAMS.xml' path='doc/member[@name="NV_LID_DOCK_PARAMS.forcedLidMechanismPresent"]/*' />
        [NativeTypeName("NvU32")]
        public uint forcedLidMechanismPresent;

        /// <include file='NV_LID_DOCK_PARAMS.xml' path='doc/member[@name="NV_LID_DOCK_PARAMS.forcedDockMechanismPresent"]/*' />
        [NativeTypeName("NvU32")]
        public uint forcedDockMechanismPresent;
    }
}
