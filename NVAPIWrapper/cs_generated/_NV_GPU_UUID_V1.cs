using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_GPU_UUID_V1.xml' path='doc/member[@name="_NV_GPU_UUID_V1"]/*' />
    public partial struct _NV_GPU_UUID_V1
    {
        /// <include file='_NV_GPU_UUID_V1.xml' path='doc/member[@name="_NV_GPU_UUID_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_GPU_UUID_V1.xml' path='doc/member[@name="_NV_GPU_UUID_V1.uuid"]/*' />
        [NativeTypeName("NvU8[16]")]
        public _uuid_e__FixedBuffer uuid;

        /// <include file='_uuid_e__FixedBuffer.xml' path='doc/member[@name="_uuid_e__FixedBuffer"]/*' />
        [InlineArray(16)]
        public partial struct _uuid_e__FixedBuffer
        {
            public byte e0;
        }
    }
}
