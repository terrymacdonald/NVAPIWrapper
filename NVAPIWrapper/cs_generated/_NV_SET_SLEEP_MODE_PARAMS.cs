using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_SET_SLEEP_MODE_PARAMS.xml' path='doc/member[@name="_NV_SET_SLEEP_MODE_PARAMS"]/*' />
    public partial struct _NV_SET_SLEEP_MODE_PARAMS
    {
        /// <include file='_NV_SET_SLEEP_MODE_PARAMS.xml' path='doc/member[@name="_NV_SET_SLEEP_MODE_PARAMS.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_SET_SLEEP_MODE_PARAMS.xml' path='doc/member[@name="_NV_SET_SLEEP_MODE_PARAMS.bLowLatencyMode"]/*' />
        [NativeTypeName("NvBool")]
        public byte bLowLatencyMode;

        /// <include file='_NV_SET_SLEEP_MODE_PARAMS.xml' path='doc/member[@name="_NV_SET_SLEEP_MODE_PARAMS.bLowLatencyBoost"]/*' />
        [NativeTypeName("NvBool")]
        public byte bLowLatencyBoost;

        /// <include file='_NV_SET_SLEEP_MODE_PARAMS.xml' path='doc/member[@name="_NV_SET_SLEEP_MODE_PARAMS.minimumIntervalUs"]/*' />
        [NativeTypeName("NvU32")]
        public uint minimumIntervalUs;

        /// <include file='_NV_SET_SLEEP_MODE_PARAMS.xml' path='doc/member[@name="_NV_SET_SLEEP_MODE_PARAMS.bUseMarkersToOptimize"]/*' />
        [NativeTypeName("NvBool")]
        public byte bUseMarkersToOptimize;

        /// <include file='_NV_SET_SLEEP_MODE_PARAMS.xml' path='doc/member[@name="_NV_SET_SLEEP_MODE_PARAMS.bUseMinQueueTime"]/*' />
        [NativeTypeName("NvBool")]
        public byte bUseMinQueueTime;

        /// <include file='_NV_SET_SLEEP_MODE_PARAMS.xml' path='doc/member[@name="_NV_SET_SLEEP_MODE_PARAMS.rsvd"]/*' />
        [NativeTypeName("NvU8[30]")]
        public _rsvd_e__FixedBuffer rsvd;

        /// <include file='_rsvd_e__FixedBuffer.xml' path='doc/member[@name="_rsvd_e__FixedBuffer"]/*' />
        [InlineArray(30)]
        public partial struct _rsvd_e__FixedBuffer
        {
            public byte e0;
        }
    }
}
