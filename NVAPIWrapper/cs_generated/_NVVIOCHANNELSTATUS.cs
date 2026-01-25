namespace NVAPIWrapper
{
    /// <include file='_NVVIOCHANNELSTATUS.xml' path='doc/member[@name="_NVVIOCHANNELSTATUS"]/*' />
    public partial struct _NVVIOCHANNELSTATUS
    {
        /// <include file='_NVVIOCHANNELSTATUS.xml' path='doc/member[@name="_NVVIOCHANNELSTATUS.smpte352"]/*' />
        [NativeTypeName("NvU32")]
        public uint smpte352;

        /// <include file='_NVVIOCHANNELSTATUS.xml' path='doc/member[@name="_NVVIOCHANNELSTATUS.signalFormat"]/*' />
        [NativeTypeName("NVVIOSIGNALFORMAT")]
        public _NVVIOSIGNALFORMAT signalFormat;

        /// <include file='_NVVIOCHANNELSTATUS.xml' path='doc/member[@name="_NVVIOCHANNELSTATUS.bitsPerComponent"]/*' />
        [NativeTypeName("NVVIOBITSPERCOMPONENT")]
        public _NVVIOBITSPERCOMPONENT bitsPerComponent;

        /// <include file='_NVVIOCHANNELSTATUS.xml' path='doc/member[@name="_NVVIOCHANNELSTATUS.samplingFormat"]/*' />
        [NativeTypeName("NVVIOCOMPONENTSAMPLING")]
        public _NVVIOCOMPONENTSAMPLING samplingFormat;

        /// <include file='_NVVIOCHANNELSTATUS.xml' path='doc/member[@name="_NVVIOCHANNELSTATUS.colorSpace"]/*' />
        [NativeTypeName("NVVIOCOLORSPACE")]
        public _NVVIOCOLORSPACE colorSpace;

        /// <include file='_NVVIOCHANNELSTATUS.xml' path='doc/member[@name="_NVVIOCHANNELSTATUS.linkID"]/*' />
        [NativeTypeName("NVVIOLINKID")]
        public _NVVIOLINKID linkID;
    }
}
