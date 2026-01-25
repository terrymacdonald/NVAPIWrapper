using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <include file='_NVVIOSTATUS.xml' path='doc/member[@name="_NVVIOSTATUS"]/*' />
    public partial struct _NVVIOSTATUS
    {
        /// <include file='_NVVIOSTATUS.xml' path='doc/member[@name="_NVVIOSTATUS.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NVVIOSTATUS.xml' path='doc/member[@name="_NVVIOSTATUS.nvvioStatusType"]/*' />
        [NativeTypeName("NVVIOSTATUSTYPE")]
        public _NVVIOSTATUSTYPE nvvioStatusType;

        /// <include file='_NVVIOSTATUS.xml' path='doc/member[@name="_NVVIOSTATUS.vioStatus"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L21763_C5")]
        public _vioStatus_e__Union vioStatus;

        /// <include file='_vioStatus_e__Union.xml' path='doc/member[@name="_vioStatus_e__Union"]/*' />
        [StructLayout(LayoutKind.Explicit)]
        public partial struct _vioStatus_e__Union
        {
            /// <include file='_vioStatus_e__Union.xml' path='doc/member[@name="_vioStatus_e__Union.inStatus"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NVVIOINPUTSTATUS")]
            public _NVVIOINPUTSTATUS inStatus;

            /// <include file='_vioStatus_e__Union.xml' path='doc/member[@name="_vioStatus_e__Union.outStatus"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NVVIOOUTPUTSTATUS")]
            public _NVVIOOUTPUTSTATUS outStatus;
        }
    }
}
