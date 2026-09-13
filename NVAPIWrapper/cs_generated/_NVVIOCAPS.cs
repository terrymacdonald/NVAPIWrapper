using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NVVIOCAPS.xml' path='doc/member[@name="_NVVIOCAPS"]/*' />
    public partial struct _NVVIOCAPS
    {
        /// <include file='_NVVIOCAPS.xml' path='doc/member[@name="_NVVIOCAPS.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NVVIOCAPS.xml' path='doc/member[@name="_NVVIOCAPS.adapterName"]/*' />
        [NativeTypeName("NvAPI_String")]
        public _adapterName_e__FixedBuffer adapterName;

        /// <include file='_NVVIOCAPS.xml' path='doc/member[@name="_NVVIOCAPS.adapterClass"]/*' />
        [NativeTypeName("NvU32")]
        public uint adapterClass;

        /// <include file='_NVVIOCAPS.xml' path='doc/member[@name="_NVVIOCAPS.adapterCaps"]/*' />
        [NativeTypeName("NvU32")]
        public uint adapterCaps;

        /// <include file='_NVVIOCAPS.xml' path='doc/member[@name="_NVVIOCAPS.dipSwitch"]/*' />
        [NativeTypeName("NvU32")]
        public uint dipSwitch;

        /// <include file='_NVVIOCAPS.xml' path='doc/member[@name="_NVVIOCAPS.dipSwitchReserved"]/*' />
        [NativeTypeName("NvU32")]
        public uint dipSwitchReserved;

        /// <include file='_NVVIOCAPS.xml' path='doc/member[@name="_NVVIOCAPS.boardID"]/*' />
        [NativeTypeName("NvU32")]
        public uint boardID;

        /// <include file='_NVVIOCAPS.xml' path='doc/member[@name="_NVVIOCAPS.driver"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L21701_C5")]
        public _driver_e__Struct driver;

        /// <include file='_NVVIOCAPS.xml' path='doc/member[@name="_NVVIOCAPS.firmWare"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L21707_C5")]
        public _firmWare_e__Struct firmWare;

        /// <include file='_NVVIOCAPS.xml' path='doc/member[@name="_NVVIOCAPS.ownerId"]/*' />
        [NativeTypeName("NVVIOOWNERID")]
        public uint ownerId;

        /// <include file='_NVVIOCAPS.xml' path='doc/member[@name="_NVVIOCAPS.ownerType"]/*' />
        [NativeTypeName("NVVIOOWNERTYPE")]
        public _NVVIOOWNERTYPE ownerType;

        /// <include file='_driver_e__Struct.xml' path='doc/member[@name="_driver_e__Struct"]/*' />
        public partial struct _driver_e__Struct
        {
            /// <include file='_driver_e__Struct.xml' path='doc/member[@name="_driver_e__Struct.majorVersion"]/*' />
            [NativeTypeName("NvU32")]
            public uint majorVersion;

            /// <include file='_driver_e__Struct.xml' path='doc/member[@name="_driver_e__Struct.minorVersion"]/*' />
            [NativeTypeName("NvU32")]
            public uint minorVersion;
        }

        /// <include file='_firmWare_e__Struct.xml' path='doc/member[@name="_firmWare_e__Struct"]/*' />
        public partial struct _firmWare_e__Struct
        {
            /// <include file='_firmWare_e__Struct.xml' path='doc/member[@name="_firmWare_e__Struct.majorVersion"]/*' />
            [NativeTypeName("NvU32")]
            public uint majorVersion;

            /// <include file='_firmWare_e__Struct.xml' path='doc/member[@name="_firmWare_e__Struct.minorVersion"]/*' />
            [NativeTypeName("NvU32")]
            public uint minorVersion;
        }

        /// <include file='_adapterName_e__FixedBuffer.xml' path='doc/member[@name="_adapterName_e__FixedBuffer"]/*' />
        [InlineArray(4096)]
        public partial struct _adapterName_e__FixedBuffer
        {
            public sbyte e0;
        }
    }
}
