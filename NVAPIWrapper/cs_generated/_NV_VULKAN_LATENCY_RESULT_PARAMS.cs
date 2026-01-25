using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_VULKAN_LATENCY_RESULT_PARAMS.xml' path='doc/member[@name="_NV_VULKAN_LATENCY_RESULT_PARAMS"]/*' />
    public partial struct _NV_VULKAN_LATENCY_RESULT_PARAMS
    {
        /// <include file='_NV_VULKAN_LATENCY_RESULT_PARAMS.xml' path='doc/member[@name="_NV_VULKAN_LATENCY_RESULT_PARAMS.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_VULKAN_LATENCY_RESULT_PARAMS.xml' path='doc/member[@name="_NV_VULKAN_LATENCY_RESULT_PARAMS.frameReport"]/*' />
        [NativeTypeName("struct vkFrameReport[64]")]
        public _frameReport_e__FixedBuffer frameReport;

        /// <include file='_NV_VULKAN_LATENCY_RESULT_PARAMS.xml' path='doc/member[@name="_NV_VULKAN_LATENCY_RESULT_PARAMS.rsvd"]/*' />
        [NativeTypeName("NvU8[32]")]
        public _rsvd_e__FixedBuffer rsvd;

        /// <include file='vkFrameReport.xml' path='doc/member[@name="vkFrameReport"]/*' />
        public partial struct vkFrameReport
        {
            /// <include file='vkFrameReport.xml' path='doc/member[@name="vkFrameReport.frameID"]/*' />
            [NativeTypeName("NvU64")]
            public ulong frameID;

            /// <include file='vkFrameReport.xml' path='doc/member[@name="vkFrameReport.inputSampleTime"]/*' />
            [NativeTypeName("NvU64")]
            public ulong inputSampleTime;

            /// <include file='vkFrameReport.xml' path='doc/member[@name="vkFrameReport.simStartTime"]/*' />
            [NativeTypeName("NvU64")]
            public ulong simStartTime;

            /// <include file='vkFrameReport.xml' path='doc/member[@name="vkFrameReport.simEndTime"]/*' />
            [NativeTypeName("NvU64")]
            public ulong simEndTime;

            /// <include file='vkFrameReport.xml' path='doc/member[@name="vkFrameReport.renderSubmitStartTime"]/*' />
            [NativeTypeName("NvU64")]
            public ulong renderSubmitStartTime;

            /// <include file='vkFrameReport.xml' path='doc/member[@name="vkFrameReport.renderSubmitEndTime"]/*' />
            [NativeTypeName("NvU64")]
            public ulong renderSubmitEndTime;

            /// <include file='vkFrameReport.xml' path='doc/member[@name="vkFrameReport.presentStartTime"]/*' />
            [NativeTypeName("NvU64")]
            public ulong presentStartTime;

            /// <include file='vkFrameReport.xml' path='doc/member[@name="vkFrameReport.presentEndTime"]/*' />
            [NativeTypeName("NvU64")]
            public ulong presentEndTime;

            /// <include file='vkFrameReport.xml' path='doc/member[@name="vkFrameReport.driverStartTime"]/*' />
            [NativeTypeName("NvU64")]
            public ulong driverStartTime;

            /// <include file='vkFrameReport.xml' path='doc/member[@name="vkFrameReport.driverEndTime"]/*' />
            [NativeTypeName("NvU64")]
            public ulong driverEndTime;

            /// <include file='vkFrameReport.xml' path='doc/member[@name="vkFrameReport.osRenderQueueStartTime"]/*' />
            [NativeTypeName("NvU64")]
            public ulong osRenderQueueStartTime;

            /// <include file='vkFrameReport.xml' path='doc/member[@name="vkFrameReport.osRenderQueueEndTime"]/*' />
            [NativeTypeName("NvU64")]
            public ulong osRenderQueueEndTime;

            /// <include file='vkFrameReport.xml' path='doc/member[@name="vkFrameReport.gpuRenderStartTime"]/*' />
            [NativeTypeName("NvU64")]
            public ulong gpuRenderStartTime;

            /// <include file='vkFrameReport.xml' path='doc/member[@name="vkFrameReport.gpuRenderEndTime"]/*' />
            [NativeTypeName("NvU64")]
            public ulong gpuRenderEndTime;

            /// <include file='vkFrameReport.xml' path='doc/member[@name="vkFrameReport.rsvd"]/*' />
            [NativeTypeName("NvU8[128]")]
            public _rsvd_e__FixedBuffer rsvd;

            /// <include file='_rsvd_e__FixedBuffer.xml' path='doc/member[@name="_rsvd_e__FixedBuffer"]/*' />
            [InlineArray(128)]
            public partial struct _rsvd_e__FixedBuffer
            {
                public byte e0;
            }
        }

        /// <include file='_frameReport_e__FixedBuffer.xml' path='doc/member[@name="_frameReport_e__FixedBuffer"]/*' />
        [InlineArray(64)]
        public partial struct _frameReport_e__FixedBuffer
        {
            public vkFrameReport e0;
        }

        /// <include file='_rsvd_e__FixedBuffer.xml' path='doc/member[@name="_rsvd_e__FixedBuffer"]/*' />
        [InlineArray(32)]
        public partial struct _rsvd_e__FixedBuffer
        {
            public byte e0;
        }
    }
}
