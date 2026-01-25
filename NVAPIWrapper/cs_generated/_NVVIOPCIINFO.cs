namespace NVAPIWrapper
{
    /// <include file='_NVVIOPCIINFO.xml' path='doc/member[@name="_NVVIOPCIINFO"]/*' />
    public partial struct _NVVIOPCIINFO
    {
        /// <include file='_NVVIOPCIINFO.xml' path='doc/member[@name="_NVVIOPCIINFO.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NVVIOPCIINFO.xml' path='doc/member[@name="_NVVIOPCIINFO.pciDeviceId"]/*' />
        [NativeTypeName("NvU32")]
        public uint pciDeviceId;

        /// <include file='_NVVIOPCIINFO.xml' path='doc/member[@name="_NVVIOPCIINFO.pciSubSystemId"]/*' />
        [NativeTypeName("NvU32")]
        public uint pciSubSystemId;

        /// <include file='_NVVIOPCIINFO.xml' path='doc/member[@name="_NVVIOPCIINFO.pciRevisionId"]/*' />
        [NativeTypeName("NvU32")]
        public uint pciRevisionId;

        /// <include file='_NVVIOPCIINFO.xml' path='doc/member[@name="_NVVIOPCIINFO.pciDomain"]/*' />
        [NativeTypeName("NvU32")]
        public uint pciDomain;

        /// <include file='_NVVIOPCIINFO.xml' path='doc/member[@name="_NVVIOPCIINFO.pciBus"]/*' />
        [NativeTypeName("NvU32")]
        public uint pciBus;

        /// <include file='_NVVIOPCIINFO.xml' path='doc/member[@name="_NVVIOPCIINFO.pciSlot"]/*' />
        [NativeTypeName("NvU32")]
        public uint pciSlot;

        /// <include file='_NVVIOPCIINFO.xml' path='doc/member[@name="_NVVIOPCIINFO.pciLinkWidth"]/*' />
        [NativeTypeName("NVVIOPCILINKWIDTH")]
        public _NVVIOPCILINKWIDTH pciLinkWidth;

        /// <include file='_NVVIOPCIINFO.xml' path='doc/member[@name="_NVVIOPCIINFO.pciLinkRate"]/*' />
        [NativeTypeName("NVVIOPCILINKRATE")]
        public _NVVIOPCILINKRATE pciLinkRate;
    }
}
