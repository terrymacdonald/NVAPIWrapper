using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NVVIOSTREAM.xml' path='doc/member[@name="_NVVIOSTREAM"]/*' />
    public partial struct _NVVIOSTREAM
    {
        /// <include file='_NVVIOSTREAM.xml' path='doc/member[@name="_NVVIOSTREAM.bitsPerComponent"]/*' />
        [NativeTypeName("NvU32")]
        public uint bitsPerComponent;

        /// <include file='_NVVIOSTREAM.xml' path='doc/member[@name="_NVVIOSTREAM.sampling"]/*' />
        [NativeTypeName("NVVIOCOMPONENTSAMPLING")]
        public _NVVIOCOMPONENTSAMPLING sampling;

        /// <include file='_NVVIOSTREAM.xml' path='doc/member[@name="_NVVIOSTREAM.expansionEnable"]/*' />
        [NativeTypeName("NvU32")]
        public uint expansionEnable;

        /// <include file='_NVVIOSTREAM.xml' path='doc/member[@name="_NVVIOSTREAM.numLinks"]/*' />
        [NativeTypeName("NvU32")]
        public uint numLinks;

        /// <include file='_NVVIOSTREAM.xml' path='doc/member[@name="_NVVIOSTREAM.links"]/*' />
        [NativeTypeName("struct (anonymous struct at ./../nvapi/nvapi.h:22143:5)[2]")]
        public _links_e__FixedBuffer links;

        /// <include file='_links_e__Struct.xml' path='doc/member[@name="_links_e__Struct"]/*' />
        public partial struct _links_e__Struct
        {
            /// <include file='_links_e__Struct.xml' path='doc/member[@name="_links_e__Struct.jack"]/*' />
            [NativeTypeName("NvU32")]
            public uint jack;

            /// <include file='_links_e__Struct.xml' path='doc/member[@name="_links_e__Struct.channel"]/*' />
            [NativeTypeName("NvU32")]
            public uint channel;
        }

        /// <include file='_links_e__FixedBuffer.xml' path='doc/member[@name="_links_e__FixedBuffer"]/*' />
        [InlineArray(2)]
        public partial struct _links_e__FixedBuffer
        {
            public _links_e__Struct e0;
        }
    }
}
