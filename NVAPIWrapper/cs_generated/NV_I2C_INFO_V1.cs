namespace NVAPIWrapper
{
    /// <include file='NV_I2C_INFO_V1.xml' path='doc/member[@name="NV_I2C_INFO_V1"]/*' />
    public unsafe partial struct NV_I2C_INFO_V1
    {
        /// <include file='NV_I2C_INFO_V1.xml' path='doc/member[@name="NV_I2C_INFO_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_I2C_INFO_V1.xml' path='doc/member[@name="NV_I2C_INFO_V1.displayMask"]/*' />
        [NativeTypeName("NvU32")]
        public uint displayMask;

        /// <include file='NV_I2C_INFO_V1.xml' path='doc/member[@name="NV_I2C_INFO_V1.bIsDDCPort"]/*' />
        [NativeTypeName("NvU8")]
        public byte bIsDDCPort;

        /// <include file='NV_I2C_INFO_V1.xml' path='doc/member[@name="NV_I2C_INFO_V1.i2cDevAddress"]/*' />
        [NativeTypeName("NvU8")]
        public byte i2cDevAddress;

        /// <include file='NV_I2C_INFO_V1.xml' path='doc/member[@name="NV_I2C_INFO_V1.pbI2cRegAddress"]/*' />
        [NativeTypeName("NvU8 *")]
        public byte* pbI2cRegAddress;

        /// <include file='NV_I2C_INFO_V1.xml' path='doc/member[@name="NV_I2C_INFO_V1.regAddrSize"]/*' />
        [NativeTypeName("NvU32")]
        public uint regAddrSize;

        /// <include file='NV_I2C_INFO_V1.xml' path='doc/member[@name="NV_I2C_INFO_V1.pbData"]/*' />
        [NativeTypeName("NvU8 *")]
        public byte* pbData;

        /// <include file='NV_I2C_INFO_V1.xml' path='doc/member[@name="NV_I2C_INFO_V1.cbSize"]/*' />
        [NativeTypeName("NvU32")]
        public uint cbSize;

        /// <include file='NV_I2C_INFO_V1.xml' path='doc/member[@name="NV_I2C_INFO_V1.i2cSpeed"]/*' />
        [NativeTypeName("NvU32")]
        public uint i2cSpeed;
    }
}
