using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NVVIOCOLORCONVERSION.xml' path='doc/member[@name="_NVVIOCOLORCONVERSION"]/*' />
    public partial struct _NVVIOCOLORCONVERSION
    {
        /// <include file='_NVVIOCOLORCONVERSION.xml' path='doc/member[@name="_NVVIOCOLORCONVERSION.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NVVIOCOLORCONVERSION.xml' path='doc/member[@name="_NVVIOCOLORCONVERSION.colorMatrix"]/*' />
        [NativeTypeName("float[3][3]")]
        public _colorMatrix_e__FixedBuffer colorMatrix;

        /// <include file='_NVVIOCOLORCONVERSION.xml' path='doc/member[@name="_NVVIOCOLORCONVERSION.colorOffset"]/*' />
        [NativeTypeName("float[3]")]
        public _colorOffset_e__FixedBuffer colorOffset;

        /// <include file='_NVVIOCOLORCONVERSION.xml' path='doc/member[@name="_NVVIOCOLORCONVERSION.colorScale"]/*' />
        [NativeTypeName("float[3]")]
        public _colorScale_e__FixedBuffer colorScale;

        /// <include file='_NVVIOCOLORCONVERSION.xml' path='doc/member[@name="_NVVIOCOLORCONVERSION.compositeSafe"]/*' />
        [NativeTypeName("NvU32")]
        public uint compositeSafe;

        /// <include file='_colorMatrix_e__FixedBuffer.xml' path='doc/member[@name="_colorMatrix_e__FixedBuffer"]/*' />
        [InlineArray(3 * 3)]
        public partial struct _colorMatrix_e__FixedBuffer
        {
            public float e0_0;
        }

        /// <include file='_colorOffset_e__FixedBuffer.xml' path='doc/member[@name="_colorOffset_e__FixedBuffer"]/*' />
        [InlineArray(3)]
        public partial struct _colorOffset_e__FixedBuffer
        {
            public float e0;
        }

        /// <include file='_colorScale_e__FixedBuffer.xml' path='doc/member[@name="_colorScale_e__FixedBuffer"]/*' />
        [InlineArray(3)]
        public partial struct _colorScale_e__FixedBuffer
        {
            public float e0;
        }
    }
}
