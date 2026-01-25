namespace NVAPIWrapper
{
    /// <include file='NVAPI_INTERFACE_TABLE.xml' path='doc/member[@name="NVAPI_INTERFACE_TABLE"]/*' />
    public unsafe partial struct NVAPI_INTERFACE_TABLE
    {
        /// <include file='NVAPI_INTERFACE_TABLE.xml' path='doc/member[@name="NVAPI_INTERFACE_TABLE.func"]/*' />
        [NativeTypeName("const char *")]
        public sbyte* func;

        /// <include file='NVAPI_INTERFACE_TABLE.xml' path='doc/member[@name="NVAPI_INTERFACE_TABLE.id"]/*' />
        [NativeTypeName("unsigned int")]
        public uint id;
    }
}
