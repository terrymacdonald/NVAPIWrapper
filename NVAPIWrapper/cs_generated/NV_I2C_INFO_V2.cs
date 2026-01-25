namespace NVAPIWrapper
{
    /// <include file='NV_I2C_INFO_V2.xml' path='doc/member[@name="NV_I2C_INFO_V2"]/*' />
    public unsafe partial struct NV_I2C_INFO_V2
    {
        /// <include file='NV_I2C_INFO_V2.xml' path='doc/member[@name="NV_I2C_INFO_V2.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_I2C_INFO_V2.xml' path='doc/member[@name="NV_I2C_INFO_V2.displayMask"]/*' />
        [NativeTypeName("NvU32")]
        public uint displayMask;

        /// <include file='NV_I2C_INFO_V2.xml' path='doc/member[@name="NV_I2C_INFO_V2.bIsDDCPort"]/*' />
        [NativeTypeName("NvU8")]
        public byte bIsDDCPort;

        /// <include file='NV_I2C_INFO_V2.xml' path='doc/member[@name="NV_I2C_INFO_V2.i2cDevAddress"]/*' />
        [NativeTypeName("NvU8")]
        public byte i2cDevAddress;

        /// <include file='NV_I2C_INFO_V2.xml' path='doc/member[@name="NV_I2C_INFO_V2.pbI2cRegAddress"]/*' />
        [NativeTypeName("NvU8 *")]
        public byte* pbI2cRegAddress;

        /// <include file='NV_I2C_INFO_V2.xml' path='doc/member[@name="NV_I2C_INFO_V2.regAddrSize"]/*' />
        [NativeTypeName("NvU32")]
        public uint regAddrSize;

        /// <include file='NV_I2C_INFO_V2.xml' path='doc/member[@name="NV_I2C_INFO_V2.pbData"]/*' />
        [NativeTypeName("NvU8 *")]
        public byte* pbData;

        /// <include file='NV_I2C_INFO_V2.xml' path='doc/member[@name="NV_I2C_INFO_V2.cbSize"]/*' />
        [NativeTypeName("NvU32")]
        public uint cbSize;

        /// <include file='NV_I2C_INFO_V2.xml' path='doc/member[@name="NV_I2C_INFO_V2.i2cSpeed"]/*' />
        [NativeTypeName("NvU32")]
        public uint i2cSpeed;

        /// <include file='NV_I2C_INFO_V2.xml' path='doc/member[@name="NV_I2C_INFO_V2.i2cSpeedKhz"]/*' />
        public NV_I2C_SPEED i2cSpeedKhz;
    }
}
