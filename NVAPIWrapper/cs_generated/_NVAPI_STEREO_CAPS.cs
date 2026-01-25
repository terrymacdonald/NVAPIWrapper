using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NVAPI_STEREO_CAPS.xml' path='doc/member[@name="_NVAPI_STEREO_CAPS"]/*' />
    public partial struct _NVAPI_STEREO_CAPS
    {
        /// <include file='_NVAPI_STEREO_CAPS.xml' path='doc/member[@name="_NVAPI_STEREO_CAPS.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        public uint _bitfield;

        /// <include file='_NVAPI_STEREO_CAPS.xml' path='doc/member[@name="_NVAPI_STEREO_CAPS.supportsWindowedModeOff"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint supportsWindowedModeOff
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

        /// <include file='_NVAPI_STEREO_CAPS.xml' path='doc/member[@name="_NVAPI_STEREO_CAPS.supportsWindowedModeAutomatic"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint supportsWindowedModeAutomatic
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

        /// <include file='_NVAPI_STEREO_CAPS.xml' path='doc/member[@name="_NVAPI_STEREO_CAPS.supportsWindowedModePersistent"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint supportsWindowedModePersistent
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

        /// <include file='_NVAPI_STEREO_CAPS.xml' path='doc/member[@name="_NVAPI_STEREO_CAPS.reserved"]/*' />
        [NativeTypeName("NvU32 : 29")]
        public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1FFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1FFFFFFFu << 3)) | ((value & 0x1FFFFFFFu) << 3);
            }
        }

        /// <include file='_NVAPI_STEREO_CAPS.xml' path='doc/member[@name="_NVAPI_STEREO_CAPS.reserved2"]/*' />
        [NativeTypeName("NvU32[3]")]
        public _reserved2_e__FixedBuffer reserved2;

        /// <include file='_reserved2_e__FixedBuffer.xml' path='doc/member[@name="_reserved2_e__FixedBuffer"]/*' />
        [InlineArray(3)]
        public partial struct _reserved2_e__FixedBuffer
        {
            public uint e0;
        }
    }
}
