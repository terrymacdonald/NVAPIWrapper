using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_GPU_GSP_INFO_V1.xml' path='doc/member[@name="_NV_GPU_GSP_INFO_V1"]/*' />
    public partial struct _NV_GPU_GSP_INFO_V1
    {
        /// <include file='_NV_GPU_GSP_INFO_V1.xml' path='doc/member[@name="_NV_GPU_GSP_INFO_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_GPU_GSP_INFO_V1.xml' path='doc/member[@name="_NV_GPU_GSP_INFO_V1.firmwareVersion"]/*' />
        [NativeTypeName("NvU8[64]")]
        public _firmwareVersion_e__FixedBuffer firmwareVersion;

        /// <include file='_NV_GPU_GSP_INFO_V1.xml' path='doc/member[@name="_NV_GPU_GSP_INFO_V1.reserved"]/*' />
        [NativeTypeName("NvU32")]
        public uint reserved;

        /// <include file='_firmwareVersion_e__FixedBuffer.xml' path='doc/member[@name="_firmwareVersion_e__FixedBuffer"]/*' />
        [InlineArray(64)]
        public partial struct _firmwareVersion_e__FixedBuffer
        {
            public byte e0;
        }
    }
}
