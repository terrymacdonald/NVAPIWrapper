using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_D3D12_WORKSTATION_FEATURE_PROPERTIES.xml' path='doc/member[@name="_NV_D3D12_WORKSTATION_FEATURE_PROPERTIES"]/*' />
    public partial struct _NV_D3D12_WORKSTATION_FEATURE_PROPERTIES
    {
        /// <include file='_NV_D3D12_WORKSTATION_FEATURE_PROPERTIES.xml' path='doc/member[@name="_NV_D3D12_WORKSTATION_FEATURE_PROPERTIES.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_D3D12_WORKSTATION_FEATURE_PROPERTIES.xml' path='doc/member[@name="_NV_D3D12_WORKSTATION_FEATURE_PROPERTIES.workstationFeatureType"]/*' />
        [NativeTypeName("NV_D3D12_WORKSTATION_FEATURE_TYPE")]
        public _NV_D3D12_WORKSTATION_FEATURE_TYPE workstationFeatureType;

        /// <include file='_NV_D3D12_WORKSTATION_FEATURE_PROPERTIES.xml' path='doc/member[@name="_NV_D3D12_WORKSTATION_FEATURE_PROPERTIES.supported"]/*' />
        [NativeTypeName("NvBool")]
        public byte supported;

        /// <include file='_NV_D3D12_WORKSTATION_FEATURE_PROPERTIES.xml' path='doc/member[@name="_NV_D3D12_WORKSTATION_FEATURE_PROPERTIES.Anonymous"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L20285_C5")]
        public _Anonymous_e__Union Anonymous;

        /// <include file='_Anonymous_e__Union.xml' path='doc/member[@name="_Anonymous_e__Union.rdmaInfo"]/*' />
        [UnscopedRef]
        public ref _NV_D3D12_WORKSTATION_FEATURE_RDMA_PROPERTIES rdmaInfo
        {
            get
            {
                return ref Anonymous.rdmaInfo;
            }
        }

        /// <include file='_Anonymous_e__Union.xml' path='doc/member[@name="_Anonymous_e__Union"]/*' />
        [StructLayout(LayoutKind.Explicit)]
        public partial struct _Anonymous_e__Union
        {
            /// <include file='_Anonymous_e__Union.xml' path='doc/member[@name="_Anonymous_e__Union.rdmaInfo"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NV_D3D12_WORKSTATION_FEATURE_RDMA_PROPERTIES")]
            public _NV_D3D12_WORKSTATION_FEATURE_RDMA_PROPERTIES rdmaInfo;
        }
    }
}
