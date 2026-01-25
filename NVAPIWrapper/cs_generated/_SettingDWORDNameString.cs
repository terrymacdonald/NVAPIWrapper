namespace NVAPIWrapper
{
    /// <include file='_SettingDWORDNameString.xml' path='doc/member[@name="_SettingDWORDNameString"]/*' />
    public unsafe partial struct _SettingDWORDNameString
    {
        /// <include file='_SettingDWORDNameString.xml' path='doc/member[@name="_SettingDWORDNameString.settingId"]/*' />
        [NativeTypeName("NvU32")]
        public uint settingId;

        /// <include file='_SettingDWORDNameString.xml' path='doc/member[@name="_SettingDWORDNameString.settingNameString"]/*' />
        [NativeTypeName("const wchar_t *")]
        public ushort* settingNameString;

        /// <include file='_SettingDWORDNameString.xml' path='doc/member[@name="_SettingDWORDNameString.numSettingValues"]/*' />
        [NativeTypeName("NvU32")]
        public uint numSettingValues;

        /// <include file='_SettingDWORDNameString.xml' path='doc/member[@name="_SettingDWORDNameString.settingValues"]/*' />
        [NativeTypeName("NvU32 *")]
        public uint* settingValues;

        /// <include file='_SettingDWORDNameString.xml' path='doc/member[@name="_SettingDWORDNameString.defaultValue"]/*' />
        [NativeTypeName("NvU32")]
        public uint defaultValue;
    }
}
