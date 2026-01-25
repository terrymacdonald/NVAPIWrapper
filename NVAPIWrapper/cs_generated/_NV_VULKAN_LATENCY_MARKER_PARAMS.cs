using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_VULKAN_LATENCY_MARKER_PARAMS.xml' path='doc/member[@name="_NV_VULKAN_LATENCY_MARKER_PARAMS"]/*' />
    public partial struct _NV_VULKAN_LATENCY_MARKER_PARAMS
    {
        /// <include file='_NV_VULKAN_LATENCY_MARKER_PARAMS.xml' path='doc/member[@name="_NV_VULKAN_LATENCY_MARKER_PARAMS.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_VULKAN_LATENCY_MARKER_PARAMS.xml' path='doc/member[@name="_NV_VULKAN_LATENCY_MARKER_PARAMS.frameID"]/*' />
        [NativeTypeName("NvU64")]
        public ulong frameID;

        /// <include file='_NV_VULKAN_LATENCY_MARKER_PARAMS.xml' path='doc/member[@name="_NV_VULKAN_LATENCY_MARKER_PARAMS.markerType"]/*' />
        public NV_VULKAN_LATENCY_MARKER_TYPE markerType;

        /// <include file='_NV_VULKAN_LATENCY_MARKER_PARAMS.xml' path='doc/member[@name="_NV_VULKAN_LATENCY_MARKER_PARAMS.rsvd"]/*' />
        [NativeTypeName("NvU8[64]")]
        public _rsvd_e__FixedBuffer rsvd;

        /// <include file='_rsvd_e__FixedBuffer.xml' path='doc/member[@name="_rsvd_e__FixedBuffer"]/*' />
        [InlineArray(64)]
        public partial struct _rsvd_e__FixedBuffer
        {
            public byte e0;
        }
    }
}
