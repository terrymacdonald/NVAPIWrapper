namespace NVAPIWrapper
{
    /// <include file='_NV_DISPLAY_OUTPUT_MODE_CHANGE_EVENT_DATA.xml' path='doc/member[@name="_NV_DISPLAY_OUTPUT_MODE_CHANGE_EVENT_DATA"]/*' />
    public partial struct _NV_DISPLAY_OUTPUT_MODE_CHANGE_EVENT_DATA
    {
        /// <include file='_NV_DISPLAY_OUTPUT_MODE_CHANGE_EVENT_DATA.xml' path='doc/member[@name="_NV_DISPLAY_OUTPUT_MODE_CHANGE_EVENT_DATA.displayId"]/*' />
        [NativeTypeName("NvU32")]
        public uint displayId;

        /// <include file='_NV_DISPLAY_OUTPUT_MODE_CHANGE_EVENT_DATA.xml' path='doc/member[@name="_NV_DISPLAY_OUTPUT_MODE_CHANGE_EVENT_DATA.outputMode"]/*' />
        [NativeTypeName("NvU32")]
        public uint outputMode;
    }
}
