namespace NVAPIWrapper
{
    /// <include file='_SettingWSTRINGNameString.xml' path='doc/member[@name="_SettingWSTRINGNameString"]/*' />
    public unsafe partial struct _SettingWSTRINGNameString
    {
        /// <include file='_SettingWSTRINGNameString.xml' path='doc/member[@name="_SettingWSTRINGNameString.settingId"]/*' />
        [NativeTypeName("NvU32")]
        public uint settingId;

        /// <include file='_SettingWSTRINGNameString.xml' path='doc/member[@name="_SettingWSTRINGNameString.settingNameString"]/*' />
        [NativeTypeName("const wchar_t *")]
        public ushort* settingNameString;

        /// <include file='_SettingWSTRINGNameString.xml' path='doc/member[@name="_SettingWSTRINGNameString.numSettingValues"]/*' />
        [NativeTypeName("NvU32")]
        public uint numSettingValues;

        /// <include file='_SettingWSTRINGNameString.xml' path='doc/member[@name="_SettingWSTRINGNameString.settingValues"]/*' />
        [NativeTypeName("const wchar_t **")]
        public ushort** settingValues;

        /// <include file='_SettingWSTRINGNameString.xml' path='doc/member[@name="_SettingWSTRINGNameString.defaultValue"]/*' />
        [NativeTypeName("const wchar_t *")]
        public ushort* defaultValue;
    }
}
