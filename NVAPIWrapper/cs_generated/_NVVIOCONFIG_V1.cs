using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <include file='_NVVIOCONFIG_V1.xml' path='doc/member[@name="_NVVIOCONFIG_V1"]/*' />
    public partial struct _NVVIOCONFIG_V1
    {
        /// <include file='_NVVIOCONFIG_V1.xml' path='doc/member[@name="_NVVIOCONFIG_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NVVIOCONFIG_V1.xml' path='doc/member[@name="_NVVIOCONFIG_V1.fields"]/*' />
        [NativeTypeName("NvU32")]
        public uint fields;

        /// <include file='_NVVIOCONFIG_V1.xml' path='doc/member[@name="_NVVIOCONFIG_V1.nvvioConfigType"]/*' />
        [NativeTypeName("NVVIOCONFIGTYPE")]
        public _NVVIOCONFIGTYPE nvvioConfigType;

        /// <include file='_NVVIOCONFIG_V1.xml' path='doc/member[@name="_NVVIOCONFIG_V1.vioConfig"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L22169_C5")]
        public _vioConfig_e__Union vioConfig;

        /// <include file='_vioConfig_e__Union.xml' path='doc/member[@name="_vioConfig_e__Union"]/*' />
        [StructLayout(LayoutKind.Explicit)]
        public partial struct _vioConfig_e__Union
        {
            /// <include file='_vioConfig_e__Union.xml' path='doc/member[@name="_vioConfig_e__Union.inConfig"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NVVIOINPUTCONFIG")]
            public _NVVIOINPUTCONFIG inConfig;

            /// <include file='_vioConfig_e__Union.xml' path='doc/member[@name="_vioConfig_e__Union.outConfig"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NVVIOOUTPUTCONFIG_V1")]
            public _NVVIOOUTPUTCONFIG_V1 outConfig;
        }
    }
}
