using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_MONITOR_CAPABILITIES_V1.xml' path='doc/member[@name="_NV_MONITOR_CAPABILITIES_V1"]/*' />
    public partial struct _NV_MONITOR_CAPABILITIES_V1
    {
        /// <include file='_NV_MONITOR_CAPABILITIES_V1.xml' path='doc/member[@name="_NV_MONITOR_CAPABILITIES_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_MONITOR_CAPABILITIES_V1.xml' path='doc/member[@name="_NV_MONITOR_CAPABILITIES_V1.size"]/*' />
        [NativeTypeName("NvU16")]
        public ushort size;

        /// <include file='_NV_MONITOR_CAPABILITIES_V1.xml' path='doc/member[@name="_NV_MONITOR_CAPABILITIES_V1.infoType"]/*' />
        [NativeTypeName("NvU32")]
        public uint infoType;

        /// <include file='_NV_MONITOR_CAPABILITIES_V1.xml' path='doc/member[@name="_NV_MONITOR_CAPABILITIES_V1.connectorType"]/*' />
        [NativeTypeName("NvU32")]
        public uint connectorType;

        public byte _bitfield;

        /// <include file='_NV_MONITOR_CAPABILITIES_V1.xml' path='doc/member[@name="_NV_MONITOR_CAPABILITIES_V1.bIsValidInfo"]/*' />
        [NativeTypeName("NvU8 : 1")]
        public byte bIsValidInfo
        {
            readonly get
            {
                return (byte)(_bitfield & 0x1u);
            }

            set
            {
                _bitfield = (byte)((_bitfield & ~0x1u) | (value & 0x1u));
            }
        }

        /// <include file='_NV_MONITOR_CAPABILITIES_V1.xml' path='doc/member[@name="_NV_MONITOR_CAPABILITIES_V1.data"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L8492_C5")]
        public _data_e__Union data;

        /// <include file='_data_e__Union.xml' path='doc/member[@name="_data_e__Union"]/*' />
        [StructLayout(LayoutKind.Explicit)]
        public partial struct _data_e__Union
        {
            /// <include file='_data_e__Union.xml' path='doc/member[@name="_data_e__Union.vsdb"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NV_MONITOR_CAPS_VSDB")]
            public _NV_MONITOR_CAPS_VSDB vsdb;

            /// <include file='_data_e__Union.xml' path='doc/member[@name="_data_e__Union.vcdb"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NV_MONITOR_CAPS_VCDB")]
            public _NV_MONITOR_CAPS_VCDB vcdb;

            /// <include file='_data_e__Union.xml' path='doc/member[@name="_data_e__Union.caps"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NV_MONITOR_CAPS_GENERIC")]
            public _NV_MONITOR_CAPS_GENERIC caps;
        }
    }
}
