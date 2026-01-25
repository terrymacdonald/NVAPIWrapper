namespace NVAPIWrapper
{
    /// <include file='_NV_LICENSE_EXPIRY_DETAILS.xml' path='doc/member[@name="_NV_LICENSE_EXPIRY_DETAILS"]/*' />
    public partial struct _NV_LICENSE_EXPIRY_DETAILS
    {
        /// <include file='_NV_LICENSE_EXPIRY_DETAILS.xml' path='doc/member[@name="_NV_LICENSE_EXPIRY_DETAILS.year"]/*' />
        [NativeTypeName("NvU32")]
        public uint year;

        /// <include file='_NV_LICENSE_EXPIRY_DETAILS.xml' path='doc/member[@name="_NV_LICENSE_EXPIRY_DETAILS.month"]/*' />
        [NativeTypeName("NvU16")]
        public ushort month;

        /// <include file='_NV_LICENSE_EXPIRY_DETAILS.xml' path='doc/member[@name="_NV_LICENSE_EXPIRY_DETAILS.day"]/*' />
        [NativeTypeName("NvU16")]
        public ushort day;

        /// <include file='_NV_LICENSE_EXPIRY_DETAILS.xml' path='doc/member[@name="_NV_LICENSE_EXPIRY_DETAILS.hour"]/*' />
        [NativeTypeName("NvU16")]
        public ushort hour;

        /// <include file='_NV_LICENSE_EXPIRY_DETAILS.xml' path='doc/member[@name="_NV_LICENSE_EXPIRY_DETAILS.min"]/*' />
        [NativeTypeName("NvU16")]
        public ushort min;

        /// <include file='_NV_LICENSE_EXPIRY_DETAILS.xml' path='doc/member[@name="_NV_LICENSE_EXPIRY_DETAILS.sec"]/*' />
        [NativeTypeName("NvU16")]
        public ushort sec;

        /// <include file='_NV_LICENSE_EXPIRY_DETAILS.xml' path='doc/member[@name="_NV_LICENSE_EXPIRY_DETAILS.status"]/*' />
        [NativeTypeName("NvU8")]
        public byte status;
    }
}
