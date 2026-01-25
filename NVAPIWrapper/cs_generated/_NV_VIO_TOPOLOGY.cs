using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_VIO_TOPOLOGY.xml' path='doc/member[@name="_NV_VIO_TOPOLOGY"]/*' />
    public partial struct _NV_VIO_TOPOLOGY
    {
        /// <include file='_NV_VIO_TOPOLOGY.xml' path='doc/member[@name="_NV_VIO_TOPOLOGY.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_VIO_TOPOLOGY.xml' path='doc/member[@name="_NV_VIO_TOPOLOGY.vioTotalDeviceCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint vioTotalDeviceCount;

        /// <include file='_NV_VIO_TOPOLOGY.xml' path='doc/member[@name="_NV_VIO_TOPOLOGY.vioTarget"]/*' />
        [NativeTypeName("NVVIOTOPOLOGYTARGET[8]")]
        public _vioTarget_e__FixedBuffer vioTarget;

        /// <include file='_vioTarget_e__FixedBuffer.xml' path='doc/member[@name="_vioTarget_e__FixedBuffer"]/*' />
        [InlineArray(8)]
        public partial struct _vioTarget_e__FixedBuffer
        {
            public NVVIOTOPOLOGYTARGET e0;
        }
    }
}
