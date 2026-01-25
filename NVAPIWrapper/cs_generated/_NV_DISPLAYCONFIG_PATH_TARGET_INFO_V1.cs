namespace NVAPIWrapper
{
    /// <include file='_NV_DISPLAYCONFIG_PATH_TARGET_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_TARGET_INFO_V1"]/*' />
    public unsafe partial struct _NV_DISPLAYCONFIG_PATH_TARGET_INFO_V1
    {
        /// <include file='_NV_DISPLAYCONFIG_PATH_TARGET_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_TARGET_INFO_V1.displayId"]/*' />
        [NativeTypeName("NvU32")]
        public uint displayId;

        /// <include file='_NV_DISPLAYCONFIG_PATH_TARGET_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_TARGET_INFO_V1.details"]/*' />
        [NativeTypeName("NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO *")]
        public _NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1* details;
    }
}
