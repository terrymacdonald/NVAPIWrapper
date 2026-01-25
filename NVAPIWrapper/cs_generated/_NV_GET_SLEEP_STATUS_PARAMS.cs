using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_GET_SLEEP_STATUS_PARAMS.xml' path='doc/member[@name="_NV_GET_SLEEP_STATUS_PARAMS"]/*' />
    public partial struct _NV_GET_SLEEP_STATUS_PARAMS
    {
        /// <include file='_NV_GET_SLEEP_STATUS_PARAMS.xml' path='doc/member[@name="_NV_GET_SLEEP_STATUS_PARAMS.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_GET_SLEEP_STATUS_PARAMS.xml' path='doc/member[@name="_NV_GET_SLEEP_STATUS_PARAMS.bLowLatencyMode"]/*' />
        [NativeTypeName("NvBool")]
        public byte bLowLatencyMode;

        /// <include file='_NV_GET_SLEEP_STATUS_PARAMS.xml' path='doc/member[@name="_NV_GET_SLEEP_STATUS_PARAMS.bFsVrr"]/*' />
        [NativeTypeName("NvBool")]
        public byte bFsVrr;

        /// <include file='_NV_GET_SLEEP_STATUS_PARAMS.xml' path='doc/member[@name="_NV_GET_SLEEP_STATUS_PARAMS.bCplVsyncOn"]/*' />
        [NativeTypeName("NvBool")]
        public byte bCplVsyncOn;

        /// <include file='_NV_GET_SLEEP_STATUS_PARAMS.xml' path='doc/member[@name="_NV_GET_SLEEP_STATUS_PARAMS.sleepIntervalUs"]/*' />
        [NativeTypeName("NvU32")]
        public uint sleepIntervalUs;

        /// <include file='_NV_GET_SLEEP_STATUS_PARAMS.xml' path='doc/member[@name="_NV_GET_SLEEP_STATUS_PARAMS.bUseGameSleep"]/*' />
        [NativeTypeName("NvBool")]
        public byte bUseGameSleep;

        /// <include file='_NV_GET_SLEEP_STATUS_PARAMS.xml' path='doc/member[@name="_NV_GET_SLEEP_STATUS_PARAMS.rsvd"]/*' />
        [NativeTypeName("NvU8[121]")]
        public _rsvd_e__FixedBuffer rsvd;

        /// <include file='_rsvd_e__FixedBuffer.xml' path='doc/member[@name="_rsvd_e__FixedBuffer"]/*' />
        [InlineArray(121)]
        public partial struct _rsvd_e__FixedBuffer
        {
            public byte e0;
        }
    }
}
