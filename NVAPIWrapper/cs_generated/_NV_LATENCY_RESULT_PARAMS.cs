using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_LATENCY_RESULT_PARAMS.xml' path='doc/member[@name="_NV_LATENCY_RESULT_PARAMS"]/*' />
    public partial struct _NV_LATENCY_RESULT_PARAMS
    {
        /// <include file='_NV_LATENCY_RESULT_PARAMS.xml' path='doc/member[@name="_NV_LATENCY_RESULT_PARAMS.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_LATENCY_RESULT_PARAMS.xml' path='doc/member[@name="_NV_LATENCY_RESULT_PARAMS.frameReport"]/*' />
        [NativeTypeName("struct FrameReport[64]")]
        public _frameReport_e__FixedBuffer frameReport;

        /// <include file='_NV_LATENCY_RESULT_PARAMS.xml' path='doc/member[@name="_NV_LATENCY_RESULT_PARAMS.rsvd"]/*' />
        [NativeTypeName("NvU8[32]")]
        public _rsvd_e__FixedBuffer rsvd;

        /// <include file='FrameReport.xml' path='doc/member[@name="FrameReport"]/*' />
        public partial struct FrameReport
        {
            /// <include file='FrameReport.xml' path='doc/member[@name="FrameReport.frameID"]/*' />
            [NativeTypeName("NvU64")]
            public ulong frameID;

            /// <include file='FrameReport.xml' path='doc/member[@name="FrameReport.inputSampleTime"]/*' />
            [NativeTypeName("NvU64")]
            public ulong inputSampleTime;

            /// <include file='FrameReport.xml' path='doc/member[@name="FrameReport.simStartTime"]/*' />
            [NativeTypeName("NvU64")]
            public ulong simStartTime;

            /// <include file='FrameReport.xml' path='doc/member[@name="FrameReport.simEndTime"]/*' />
            [NativeTypeName("NvU64")]
            public ulong simEndTime;

            /// <include file='FrameReport.xml' path='doc/member[@name="FrameReport.renderSubmitStartTime"]/*' />
            [NativeTypeName("NvU64")]
            public ulong renderSubmitStartTime;

            /// <include file='FrameReport.xml' path='doc/member[@name="FrameReport.renderSubmitEndTime"]/*' />
            [NativeTypeName("NvU64")]
            public ulong renderSubmitEndTime;

            /// <include file='FrameReport.xml' path='doc/member[@name="FrameReport.presentStartTime"]/*' />
            [NativeTypeName("NvU64")]
            public ulong presentStartTime;

            /// <include file='FrameReport.xml' path='doc/member[@name="FrameReport.presentEndTime"]/*' />
            [NativeTypeName("NvU64")]
            public ulong presentEndTime;

            /// <include file='FrameReport.xml' path='doc/member[@name="FrameReport.driverStartTime"]/*' />
            [NativeTypeName("NvU64")]
            public ulong driverStartTime;

            /// <include file='FrameReport.xml' path='doc/member[@name="FrameReport.driverEndTime"]/*' />
            [NativeTypeName("NvU64")]
            public ulong driverEndTime;

            /// <include file='FrameReport.xml' path='doc/member[@name="FrameReport.osRenderQueueStartTime"]/*' />
            [NativeTypeName("NvU64")]
            public ulong osRenderQueueStartTime;

            /// <include file='FrameReport.xml' path='doc/member[@name="FrameReport.osRenderQueueEndTime"]/*' />
            [NativeTypeName("NvU64")]
            public ulong osRenderQueueEndTime;

            /// <include file='FrameReport.xml' path='doc/member[@name="FrameReport.gpuRenderStartTime"]/*' />
            [NativeTypeName("NvU64")]
            public ulong gpuRenderStartTime;

            /// <include file='FrameReport.xml' path='doc/member[@name="FrameReport.gpuRenderEndTime"]/*' />
            [NativeTypeName("NvU64")]
            public ulong gpuRenderEndTime;

            /// <include file='FrameReport.xml' path='doc/member[@name="FrameReport.gpuActiveRenderTimeUs"]/*' />
            [NativeTypeName("NvU32")]
            public uint gpuActiveRenderTimeUs;

            /// <include file='FrameReport.xml' path='doc/member[@name="FrameReport.gpuFrameTimeUs"]/*' />
            [NativeTypeName("NvU32")]
            public uint gpuFrameTimeUs;

            /// <include file='FrameReport.xml' path='doc/member[@name="FrameReport.rsvd"]/*' />
            [NativeTypeName("NvU8[120]")]
            public _rsvd_e__FixedBuffer rsvd;

            /// <include file='_rsvd_e__FixedBuffer.xml' path='doc/member[@name="_rsvd_e__FixedBuffer"]/*' />
            [InlineArray(120)]
            public partial struct _rsvd_e__FixedBuffer
            {
                public byte e0;
            }
        }

        /// <include file='_frameReport_e__FixedBuffer.xml' path='doc/member[@name="_frameReport_e__FixedBuffer"]/*' />
        [InlineArray(64)]
        public partial struct _frameReport_e__FixedBuffer
        {
            public FrameReport e0;
        }

        /// <include file='_rsvd_e__FixedBuffer.xml' path='doc/member[@name="_rsvd_e__FixedBuffer"]/*' />
        [InlineArray(32)]
        public partial struct _rsvd_e__FixedBuffer
        {
            public byte e0;
        }
    }
}
