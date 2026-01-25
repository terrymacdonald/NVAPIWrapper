using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NVLINK_DEVICE_INFO_V1.xml' path='doc/member[@name="NVLINK_DEVICE_INFO_V1"]/*' />
    public partial struct NVLINK_DEVICE_INFO_V1
    {
        /// <include file='NVLINK_DEVICE_INFO_V1.xml' path='doc/member[@name="NVLINK_DEVICE_INFO_V1.deviceIdFlags"]/*' />
        [NativeTypeName("NvU32")]
        public uint deviceIdFlags;

        /// <include file='NVLINK_DEVICE_INFO_V1.xml' path='doc/member[@name="NVLINK_DEVICE_INFO_V1.domain"]/*' />
        [NativeTypeName("NvU16")]
        public ushort domain;

        /// <include file='NVLINK_DEVICE_INFO_V1.xml' path='doc/member[@name="NVLINK_DEVICE_INFO_V1.bus"]/*' />
        [NativeTypeName("NvU16")]
        public ushort bus;

        /// <include file='NVLINK_DEVICE_INFO_V1.xml' path='doc/member[@name="NVLINK_DEVICE_INFO_V1.device"]/*' />
        [NativeTypeName("NvU16")]
        public ushort device;

        /// <include file='NVLINK_DEVICE_INFO_V1.xml' path='doc/member[@name="NVLINK_DEVICE_INFO_V1.function"]/*' />
        [NativeTypeName("NvU16")]
        public ushort function;

        /// <include file='NVLINK_DEVICE_INFO_V1.xml' path='doc/member[@name="NVLINK_DEVICE_INFO_V1.pciDeviceId"]/*' />
        [NativeTypeName("NvU32")]
        public uint pciDeviceId;

        /// <include file='NVLINK_DEVICE_INFO_V1.xml' path='doc/member[@name="NVLINK_DEVICE_INFO_V1.deviceType"]/*' />
        [NativeTypeName("NvU64")]
        public ulong deviceType;

        /// <include file='NVLINK_DEVICE_INFO_V1.xml' path='doc/member[@name="NVLINK_DEVICE_INFO_V1.deviceUUID"]/*' />
        [NativeTypeName("NvU8[16]")]
        public _deviceUUID_e__FixedBuffer deviceUUID;

        /// <include file='_deviceUUID_e__FixedBuffer.xml' path='doc/member[@name="_deviceUUID_e__FixedBuffer"]/*' />
        [InlineArray(16)]
        public partial struct _deviceUUID_e__FixedBuffer
        {
            public byte e0;
        }
    }
}
