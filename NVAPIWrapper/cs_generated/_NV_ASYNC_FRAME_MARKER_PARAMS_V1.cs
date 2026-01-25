using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_ASYNC_FRAME_MARKER_PARAMS_V1.xml' path='doc/member[@name="_NV_ASYNC_FRAME_MARKER_PARAMS_V1"]/*' />
    public partial struct _NV_ASYNC_FRAME_MARKER_PARAMS_V1
    {
        /// <include file='_NV_ASYNC_FRAME_MARKER_PARAMS_V1.xml' path='doc/member[@name="_NV_ASYNC_FRAME_MARKER_PARAMS_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_ASYNC_FRAME_MARKER_PARAMS_V1.xml' path='doc/member[@name="_NV_ASYNC_FRAME_MARKER_PARAMS_V1.frameID"]/*' />
        [NativeTypeName("NvU64")]
        public ulong frameID;

        /// <include file='_NV_ASYNC_FRAME_MARKER_PARAMS_V1.xml' path='doc/member[@name="_NV_ASYNC_FRAME_MARKER_PARAMS_V1.markerType"]/*' />
        public NV_LATENCY_MARKER_TYPE markerType;

        /// <include file='_NV_ASYNC_FRAME_MARKER_PARAMS_V1.xml' path='doc/member[@name="_NV_ASYNC_FRAME_MARKER_PARAMS_V1.presentFrameID"]/*' />
        [NativeTypeName("NvU64")]
        public ulong presentFrameID;

        /// <include file='_NV_ASYNC_FRAME_MARKER_PARAMS_V1.xml' path='doc/member[@name="_NV_ASYNC_FRAME_MARKER_PARAMS_V1.vendorInternal"]/*' />
        [NativeTypeName("NvBool")]
        public byte vendorInternal;

        /// <include file='_NV_ASYNC_FRAME_MARKER_PARAMS_V1.xml' path='doc/member[@name="_NV_ASYNC_FRAME_MARKER_PARAMS_V1.rsvd"]/*' />
        [NativeTypeName("NvU8[55]")]
        public _rsvd_e__FixedBuffer rsvd;

        /// <include file='_rsvd_e__FixedBuffer.xml' path='doc/member[@name="_rsvd_e__FixedBuffer"]/*' />
        [InlineArray(55)]
        public partial struct _rsvd_e__FixedBuffer
        {
            public byte e0;
        }
    }
}
