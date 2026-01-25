using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_GSYNC_STATUS_PARAMS_V1.xml' path='doc/member[@name="_NV_GSYNC_STATUS_PARAMS_V1"]/*' />
    public partial struct _NV_GSYNC_STATUS_PARAMS_V1
    {
        /// <include file='_NV_GSYNC_STATUS_PARAMS_V1.xml' path='doc/member[@name="_NV_GSYNC_STATUS_PARAMS_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_GSYNC_STATUS_PARAMS_V1.xml' path='doc/member[@name="_NV_GSYNC_STATUS_PARAMS_V1.refreshRate"]/*' />
        [NativeTypeName("NvU32")]
        public uint refreshRate;

        /// <include file='_NV_GSYNC_STATUS_PARAMS_V1.xml' path='doc/member[@name="_NV_GSYNC_STATUS_PARAMS_V1.RJ45_IO"]/*' />
        [NativeTypeName("NVAPI_GSYNC_RJ45_IO[2]")]
        public _RJ45_IO_e__FixedBuffer RJ45_IO;

        /// <include file='_NV_GSYNC_STATUS_PARAMS_V1.xml' path='doc/member[@name="_NV_GSYNC_STATUS_PARAMS_V1.RJ45_Ethernet"]/*' />
        [NativeTypeName("NvU32[2]")]
        public _RJ45_Ethernet_e__FixedBuffer RJ45_Ethernet;

        /// <include file='_NV_GSYNC_STATUS_PARAMS_V1.xml' path='doc/member[@name="_NV_GSYNC_STATUS_PARAMS_V1.houseSyncIncoming"]/*' />
        [NativeTypeName("NvU32")]
        public uint houseSyncIncoming;

        /// <include file='_NV_GSYNC_STATUS_PARAMS_V1.xml' path='doc/member[@name="_NV_GSYNC_STATUS_PARAMS_V1.bHouseSync"]/*' />
        [NativeTypeName("NvU32")]
        public uint bHouseSync;

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
