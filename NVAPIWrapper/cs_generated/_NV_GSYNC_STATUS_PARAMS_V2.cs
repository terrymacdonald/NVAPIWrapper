using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_GSYNC_STATUS_PARAMS_V2.xml' path='doc/member[@name="_NV_GSYNC_STATUS_PARAMS_V2"]/*' />
    public partial struct _NV_GSYNC_STATUS_PARAMS_V2
    {
        /// <include file='_NV_GSYNC_STATUS_PARAMS_V2.xml' path='doc/member[@name="_NV_GSYNC_STATUS_PARAMS_V2.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_GSYNC_STATUS_PARAMS_V2.xml' path='doc/member[@name="_NV_GSYNC_STATUS_PARAMS_V2.refreshRate"]/*' />
        [NativeTypeName("NvU32")]
        public uint refreshRate;

        /// <include file='_NV_GSYNC_STATUS_PARAMS_V2.xml' path='doc/member[@name="_NV_GSYNC_STATUS_PARAMS_V2.RJ45_IO"]/*' />
        [NativeTypeName("NVAPI_GSYNC_RJ45_IO[2]")]
        public _RJ45_IO_e__FixedBuffer RJ45_IO;

        /// <include file='_NV_GSYNC_STATUS_PARAMS_V2.xml' path='doc/member[@name="_NV_GSYNC_STATUS_PARAMS_V2.RJ45_Ethernet"]/*' />
        [NativeTypeName("NvU32[2]")]
        public _RJ45_Ethernet_e__FixedBuffer RJ45_Ethernet;

        /// <include file='_NV_GSYNC_STATUS_PARAMS_V2.xml' path='doc/member[@name="_NV_GSYNC_STATUS_PARAMS_V2.houseSyncIncoming"]/*' />
        [NativeTypeName("NvU32")]
        public uint houseSyncIncoming;

        /// <include file='_NV_GSYNC_STATUS_PARAMS_V2.xml' path='doc/member[@name="_NV_GSYNC_STATUS_PARAMS_V2.bHouseSync"]/*' />
        [NativeTypeName("NvU32")]
        public uint bHouseSync;

        public uint _bitfield;

        /// <include file='_NV_GSYNC_STATUS_PARAMS_V2.xml' path='doc/member[@name="_NV_GSYNC_STATUS_PARAMS_V2.bInternalSlave"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bInternalSlave
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

        /// <include file='_NV_GSYNC_STATUS_PARAMS_V2.xml' path='doc/member[@name="_NV_GSYNC_STATUS_PARAMS_V2.reserved"]/*' />
        [NativeTypeName("NvU32 : 31")]
        public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x7FFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x7FFFFFFFu << 1)) | ((value & 0x7FFFFFFFu) << 1);
            }
        }

        /// <include file='_RJ45_IO_e__FixedBuffer.xml' path='doc/member[@name="_RJ45_IO_e__FixedBuffer"]/*' />
        [InlineArray(2)]
        public partial struct _RJ45_IO_e__FixedBuffer
        {
            public _NVAPI_GSYNC_RJ45_IO e0;
        }

        /// <include file='_RJ45_Ethernet_e__FixedBuffer.xml' path='doc/member[@name="_RJ45_Ethernet_e__FixedBuffer"]/*' />
        [InlineArray(2)]
        public partial struct _RJ45_Ethernet_e__FixedBuffer
        {
            public uint e0;
        }
    }
}
