namespace NVAPIWrapper
{
    /// <include file='_NV_EDID_DATA_V1.xml' path='doc/member[@name="_NV_EDID_DATA_V1"]/*' />
    public unsafe partial struct _NV_EDID_DATA_V1
    {
        /// <include file='_NV_EDID_DATA_V1.xml' path='doc/member[@name="_NV_EDID_DATA_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_EDID_DATA_V1.xml' path='doc/member[@name="_NV_EDID_DATA_V1.pEDID"]/*' />
        [NativeTypeName("NvU8 *")]
        public byte* pEDID;

        /// <include file='_NV_EDID_DATA_V1.xml' path='doc/member[@name="_NV_EDID_DATA_V1.sizeOfEDID"]/*' />
        [NativeTypeName("NvU32")]
        public uint sizeOfEDID;
    }
}
