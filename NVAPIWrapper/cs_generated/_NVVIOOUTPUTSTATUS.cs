namespace NVAPIWrapper
{
    /// <include file='_NVVIOOUTPUTSTATUS.xml' path='doc/member[@name="_NVVIOOUTPUTSTATUS"]/*' />
    public partial struct _NVVIOOUTPUTSTATUS
    {
        /// <include file='_NVVIOOUTPUTSTATUS.xml' path='doc/member[@name="_NVVIOOUTPUTSTATUS.vid1Out"]/*' />
        [NativeTypeName("NVVIOINPUTOUTPUTSTATUS")]
        public _NVVIOINPUTOUTPUTSTATUS vid1Out;

        /// <include file='_NVVIOOUTPUTSTATUS.xml' path='doc/member[@name="_NVVIOOUTPUTSTATUS.vid2Out"]/*' />
        [NativeTypeName("NVVIOINPUTOUTPUTSTATUS")]
        public _NVVIOINPUTOUTPUTSTATUS vid2Out;

        /// <include file='_NVVIOOUTPUTSTATUS.xml' path='doc/member[@name="_NVVIOOUTPUTSTATUS.sdiSyncIn"]/*' />
        [NativeTypeName("NVVIOSYNCSTATUS")]
        public _NVVIOSYNCSTATUS sdiSyncIn;

        /// <include file='_NVVIOOUTPUTSTATUS.xml' path='doc/member[@name="_NVVIOOUTPUTSTATUS.compSyncIn"]/*' />
        [NativeTypeName("NVVIOSYNCSTATUS")]
        public _NVVIOSYNCSTATUS compSyncIn;

        /// <include file='_NVVIOOUTPUTSTATUS.xml' path='doc/member[@name="_NVVIOOUTPUTSTATUS.syncEnable"]/*' />
        [NativeTypeName("NvU32")]
        public uint syncEnable;

        /// <include file='_NVVIOOUTPUTSTATUS.xml' path='doc/member[@name="_NVVIOOUTPUTSTATUS.syncSource"]/*' />
        [NativeTypeName("NVVIOSYNCSOURCE")]
        public _NVVIOSYNCSOURCE syncSource;

        /// <include file='_NVVIOOUTPUTSTATUS.xml' path='doc/member[@name="_NVVIOOUTPUTSTATUS.syncFormat"]/*' />
        [NativeTypeName("NVVIOSIGNALFORMAT")]
        public _NVVIOSIGNALFORMAT syncFormat;

        /// <include file='_NVVIOOUTPUTSTATUS.xml' path='doc/member[@name="_NVVIOOUTPUTSTATUS.frameLockEnable"]/*' />
        [NativeTypeName("NvU32")]
        public uint frameLockEnable;

        /// <include file='_NVVIOOUTPUTSTATUS.xml' path='doc/member[@name="_NVVIOOUTPUTSTATUS.outputVideoLocked"]/*' />
        [NativeTypeName("NvU32")]
        public uint outputVideoLocked;

        /// <include file='_NVVIOOUTPUTSTATUS.xml' path='doc/member[@name="_NVVIOOUTPUTSTATUS.dataIntegrityCheckErrorCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint dataIntegrityCheckErrorCount;

        /// <include file='_NVVIOOUTPUTSTATUS.xml' path='doc/member[@name="_NVVIOOUTPUTSTATUS.dataIntegrityCheckEnabled"]/*' />
        [NativeTypeName("NvU32")]
        public uint dataIntegrityCheckEnabled;

        /// <include file='_NVVIOOUTPUTSTATUS.xml' path='doc/member[@name="_NVVIOOUTPUTSTATUS.dataIntegrityCheckFailed"]/*' />
        [NativeTypeName("NvU32")]
        public uint dataIntegrityCheckFailed;

        /// <include file='_NVVIOOUTPUTSTATUS.xml' path='doc/member[@name="_NVVIOOUTPUTSTATUS.uSyncSourceLocked"]/*' />
        [NativeTypeName("NvU32")]
        public uint uSyncSourceLocked;

        /// <include file='_NVVIOOUTPUTSTATUS.xml' path='doc/member[@name="_NVVIOOUTPUTSTATUS.uPowerOn"]/*' />
        [NativeTypeName("NvU32")]
        public uint uPowerOn;
    }
}
