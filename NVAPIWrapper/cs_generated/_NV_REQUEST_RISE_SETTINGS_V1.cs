using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_REQUEST_RISE_SETTINGS_V1.xml' path='doc/member[@name="_NV_REQUEST_RISE_SETTINGS_V1"]/*' />
    public partial struct _NV_REQUEST_RISE_SETTINGS_V1
    {
        /// <include file='_NV_REQUEST_RISE_SETTINGS_V1.xml' path='doc/member[@name="_NV_REQUEST_RISE_SETTINGS_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_REQUEST_RISE_SETTINGS_V1.xml' path='doc/member[@name="_NV_REQUEST_RISE_SETTINGS_V1.contentType"]/*' />
        [NativeTypeName("NV_RISE_CONTENT_TYPE")]
        public _NV_RISE_CONTENT_TYPE contentType;

        /// <include file='_NV_REQUEST_RISE_SETTINGS_V1.xml' path='doc/member[@name="_NV_REQUEST_RISE_SETTINGS_V1.content"]/*' />
        [NativeTypeName("NvAPI_String")]
        public _content_e__FixedBuffer content;

        /// <include file='_NV_REQUEST_RISE_SETTINGS_V1.xml' path='doc/member[@name="_NV_REQUEST_RISE_SETTINGS_V1.completed"]/*' />
        [NativeTypeName("NvBool")]
        public byte completed;

        /// <include file='_NV_REQUEST_RISE_SETTINGS_V1.xml' path='doc/member[@name="_NV_REQUEST_RISE_SETTINGS_V1.reserved"]/*' />
        [NativeTypeName("NvU8[32]")]
        public _reserved_e__FixedBuffer reserved;

        /// <include file='_content_e__FixedBuffer.xml' path='doc/member[@name="_content_e__FixedBuffer"]/*' />
        [InlineArray(4096)]
        public partial struct _content_e__FixedBuffer
        {
            public sbyte e0;
        }

        /// <include file='_reserved_e__FixedBuffer.xml' path='doc/member[@name="_reserved_e__FixedBuffer"]/*' />
        [InlineArray(32)]
        public partial struct _reserved_e__FixedBuffer
        {
            public byte e0;
        }
    }
}
