using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_RISE_CALLBACK_DATA_V1.xml' path='doc/member[@name="_NV_RISE_CALLBACK_DATA_V1"]/*' />
    public partial struct _NV_RISE_CALLBACK_DATA_V1
    {
        /// <include file='_NV_RISE_CALLBACK_DATA_V1.xml' path='doc/member[@name="_NV_RISE_CALLBACK_DATA_V1.super"]/*' />
        [NativeTypeName("NV_CLIENT_CALLBACK_SETTINGS_SUPER_V1")]
        public _NV_CLIENT_CALLBACK_SETTINGS_SUPER_V1 super;

        /// <include file='_NV_RISE_CALLBACK_DATA_V1.xml' path='doc/member[@name="_NV_RISE_CALLBACK_DATA_V1.contentType"]/*' />
        [NativeTypeName("NV_RISE_CONTENT_TYPE")]
        public _NV_RISE_CONTENT_TYPE contentType;

        /// <include file='_NV_RISE_CALLBACK_DATA_V1.xml' path='doc/member[@name="_NV_RISE_CALLBACK_DATA_V1.content"]/*' />
        [NativeTypeName("NvAPI_String")]
        public _content_e__FixedBuffer content;

        /// <include file='_NV_RISE_CALLBACK_DATA_V1.xml' path='doc/member[@name="_NV_RISE_CALLBACK_DATA_V1.completed"]/*' />
        [NativeTypeName("NvBool")]
        public byte completed;

        /// <include file='_content_e__FixedBuffer.xml' path='doc/member[@name="_content_e__FixedBuffer"]/*' />
        [InlineArray(4096)]
        public partial struct _content_e__FixedBuffer
        {
            public sbyte e0;
        }
    }
}
