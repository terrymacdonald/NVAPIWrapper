namespace NVAPIWrapper
{
    /// <include file='_NV_DISPLAYCONFIG_PATH_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_INFO_V1"]/*' />
    public unsafe partial struct _NV_DISPLAYCONFIG_PATH_INFO_V1
    {
        /// <include file='_NV_DISPLAYCONFIG_PATH_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_INFO_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_DISPLAYCONFIG_PATH_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_INFO_V1.reserved_sourceId"]/*' />
        [NativeTypeName("NvU32")]
        public uint reserved_sourceId;

        /// <include file='_NV_DISPLAYCONFIG_PATH_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_INFO_V1.targetInfoCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint targetInfoCount;

        /// <include file='_NV_DISPLAYCONFIG_PATH_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_INFO_V1.targetInfo"]/*' />
        [NativeTypeName("NV_DISPLAYCONFIG_PATH_TARGET_INFO_V1 *")]
        public _NV_DISPLAYCONFIG_PATH_TARGET_INFO_V1* targetInfo;

        /// <include file='_NV_DISPLAYCONFIG_PATH_INFO_V1.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_INFO_V1.sourceModeInfo"]/*' />
        [NativeTypeName("NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1 *")]
        public _NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1* sourceModeInfo;
    }
}
