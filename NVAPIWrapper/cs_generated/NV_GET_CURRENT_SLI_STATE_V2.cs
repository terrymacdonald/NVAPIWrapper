namespace NVAPIWrapper
{
    /// <include file='NV_GET_CURRENT_SLI_STATE_V2.xml' path='doc/member[@name="NV_GET_CURRENT_SLI_STATE_V2"]/*' />
    public partial struct NV_GET_CURRENT_SLI_STATE_V2
    {
        /// <include file='NV_GET_CURRENT_SLI_STATE_V2.xml' path='doc/member[@name="NV_GET_CURRENT_SLI_STATE_V2.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_GET_CURRENT_SLI_STATE_V2.xml' path='doc/member[@name="NV_GET_CURRENT_SLI_STATE_V2.maxNumAFRGroups"]/*' />
        [NativeTypeName("NvU32")]
        public uint maxNumAFRGroups;

        /// <include file='NV_GET_CURRENT_SLI_STATE_V2.xml' path='doc/member[@name="NV_GET_CURRENT_SLI_STATE_V2.numAFRGroups"]/*' />
        [NativeTypeName("NvU32")]
        public uint numAFRGroups;

        /// <include file='NV_GET_CURRENT_SLI_STATE_V2.xml' path='doc/member[@name="NV_GET_CURRENT_SLI_STATE_V2.currentAFRIndex"]/*' />
        [NativeTypeName("NvU32")]
        public uint currentAFRIndex;

        /// <include file='NV_GET_CURRENT_SLI_STATE_V2.xml' path='doc/member[@name="NV_GET_CURRENT_SLI_STATE_V2.nextFrameAFRIndex"]/*' />
        [NativeTypeName("NvU32")]
        public uint nextFrameAFRIndex;

        /// <include file='NV_GET_CURRENT_SLI_STATE_V2.xml' path='doc/member[@name="NV_GET_CURRENT_SLI_STATE_V2.previousFrameAFRIndex"]/*' />
        [NativeTypeName("NvU32")]
        public uint previousFrameAFRIndex;

        /// <include file='NV_GET_CURRENT_SLI_STATE_V2.xml' path='doc/member[@name="NV_GET_CURRENT_SLI_STATE_V2.bIsCurAFRGroupNew"]/*' />
        [NativeTypeName("NvU32")]
        public uint bIsCurAFRGroupNew;

        /// <include file='NV_GET_CURRENT_SLI_STATE_V2.xml' path='doc/member[@name="NV_GET_CURRENT_SLI_STATE_V2.numVRSLIGpus"]/*' />
        [NativeTypeName("NvU32")]
        public uint numVRSLIGpus;
    }
}
