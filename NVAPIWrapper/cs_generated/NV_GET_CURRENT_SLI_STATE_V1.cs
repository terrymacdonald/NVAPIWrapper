namespace NVAPIWrapper
{
    /// <include file='NV_GET_CURRENT_SLI_STATE_V1.xml' path='doc/member[@name="NV_GET_CURRENT_SLI_STATE_V1"]/*' />
    public partial struct NV_GET_CURRENT_SLI_STATE_V1
    {
        /// <include file='NV_GET_CURRENT_SLI_STATE_V1.xml' path='doc/member[@name="NV_GET_CURRENT_SLI_STATE_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_GET_CURRENT_SLI_STATE_V1.xml' path='doc/member[@name="NV_GET_CURRENT_SLI_STATE_V1.maxNumAFRGroups"]/*' />
        [NativeTypeName("NvU32")]
        public uint maxNumAFRGroups;

        /// <include file='NV_GET_CURRENT_SLI_STATE_V1.xml' path='doc/member[@name="NV_GET_CURRENT_SLI_STATE_V1.numAFRGroups"]/*' />
        [NativeTypeName("NvU32")]
        public uint numAFRGroups;

        /// <include file='NV_GET_CURRENT_SLI_STATE_V1.xml' path='doc/member[@name="NV_GET_CURRENT_SLI_STATE_V1.currentAFRIndex"]/*' />
        [NativeTypeName("NvU32")]
        public uint currentAFRIndex;

        /// <include file='NV_GET_CURRENT_SLI_STATE_V1.xml' path='doc/member[@name="NV_GET_CURRENT_SLI_STATE_V1.nextFrameAFRIndex"]/*' />
        [NativeTypeName("NvU32")]
        public uint nextFrameAFRIndex;

        /// <include file='NV_GET_CURRENT_SLI_STATE_V1.xml' path='doc/member[@name="NV_GET_CURRENT_SLI_STATE_V1.previousFrameAFRIndex"]/*' />
        [NativeTypeName("NvU32")]
        public uint previousFrameAFRIndex;

        /// <include file='NV_GET_CURRENT_SLI_STATE_V1.xml' path='doc/member[@name="NV_GET_CURRENT_SLI_STATE_V1.bIsCurAFRGroupNew"]/*' />
        [NativeTypeName("NvU32")]
        public uint bIsCurAFRGroupNew;
    }
}
