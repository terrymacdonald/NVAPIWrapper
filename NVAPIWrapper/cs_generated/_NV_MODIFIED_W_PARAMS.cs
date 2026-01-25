using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_MODIFIED_W_PARAMS.xml' path='doc/member[@name="_NV_MODIFIED_W_PARAMS"]/*' />
    public partial struct _NV_MODIFIED_W_PARAMS
    {
        /// <include file='_NV_MODIFIED_W_PARAMS.xml' path='doc/member[@name="_NV_MODIFIED_W_PARAMS.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_MODIFIED_W_PARAMS.xml' path='doc/member[@name="_NV_MODIFIED_W_PARAMS.numEntries"]/*' />
        [NativeTypeName("NvU32")]
        public uint numEntries;

        /// <include file='_NV_MODIFIED_W_PARAMS.xml' path='doc/member[@name="_NV_MODIFIED_W_PARAMS.modifiedWCoefficients"]/*' />
        [NativeTypeName("NV_MODIFIED_W_COEFFICIENTS[16]")]
        public _modifiedWCoefficients_e__FixedBuffer modifiedWCoefficients;

        /// <include file='_NV_MODIFIED_W_PARAMS.xml' path='doc/member[@name="_NV_MODIFIED_W_PARAMS.id"]/*' />
        [NativeTypeName("NvU32")]
        public uint id;

        /// <include file='_NV_MODIFIED_W_PARAMS.xml' path='doc/member[@name="_NV_MODIFIED_W_PARAMS.reserved"]/*' />
        [NativeTypeName("NvU32[16]")]
        public _reserved_e__FixedBuffer reserved;

        /// <include file='_modifiedWCoefficients_e__FixedBuffer.xml' path='doc/member[@name="_modifiedWCoefficients_e__FixedBuffer"]/*' />
        [InlineArray(16)]
        public partial struct _modifiedWCoefficients_e__FixedBuffer
        {
            public _NV_MODIFIED_W_COEFFICIENTS e0;
        }

        /// <include file='_reserved_e__FixedBuffer.xml' path='doc/member[@name="_reserved_e__FixedBuffer"]/*' />
        [InlineArray(16)]
        public partial struct _reserved_e__FixedBuffer
        {
            public uint e0;
        }
    }
}
