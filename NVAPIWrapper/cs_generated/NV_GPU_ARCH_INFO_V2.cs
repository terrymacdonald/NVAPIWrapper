using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <include file='NV_GPU_ARCH_INFO_V2.xml' path='doc/member[@name="NV_GPU_ARCH_INFO_V2"]/*' />
    public partial struct NV_GPU_ARCH_INFO_V2
    {
        /// <include file='NV_GPU_ARCH_INFO_V2.xml' path='doc/member[@name="NV_GPU_ARCH_INFO_V2.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_GPU_ARCH_INFO_V2.xml' path='doc/member[@name="NV_GPU_ARCH_INFO_V2.Anonymous1"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L2894_C5")]
        public _Anonymous1_e__Union Anonymous1;

        /// <include file='NV_GPU_ARCH_INFO_V2.xml' path='doc/member[@name="NV_GPU_ARCH_INFO_V2.Anonymous2"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L2899_C5")]
        public _Anonymous2_e__Union Anonymous2;

        /// <include file='NV_GPU_ARCH_INFO_V2.xml' path='doc/member[@name="NV_GPU_ARCH_INFO_V2.Anonymous3"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L2904_C5")]
        public _Anonymous3_e__Union Anonymous3;

        /// <include file='_Anonymous1_e__Union.xml' path='doc/member[@name="_Anonymous1_e__Union.architecture"]/*' />
        [UnscopedRef]
        public ref uint architecture
        {
            get
            {
                return ref Anonymous1.architecture;
            }
        }

        /// <include file='_Anonymous1_e__Union.xml' path='doc/member[@name="_Anonymous1_e__Union.architecture_id"]/*' />
        [UnscopedRef]
        public ref _NV_GPU_ARCHITECTURE_ID architecture_id
        {
            get
            {
                return ref Anonymous1.architecture_id;
            }
        }

        /// <include file='_Anonymous2_e__Union.xml' path='doc/member[@name="_Anonymous2_e__Union.implementation"]/*' />
        [UnscopedRef]
        public ref uint implementation
        {
            get
            {
                return ref Anonymous2.implementation;
            }
        }

        /// <include file='_Anonymous2_e__Union.xml' path='doc/member[@name="_Anonymous2_e__Union.implementation_id"]/*' />
        [UnscopedRef]
        public ref _NV_GPU_ARCH_IMPLEMENTATION_ID implementation_id
        {
            get
            {
                return ref Anonymous2.implementation_id;
            }
        }

        /// <include file='_Anonymous3_e__Union.xml' path='doc/member[@name="_Anonymous3_e__Union.revision"]/*' />
        [UnscopedRef]
        public ref uint revision
        {
            get
            {
                return ref Anonymous3.revision;
            }
        }

        /// <include file='_Anonymous3_e__Union.xml' path='doc/member[@name="_Anonymous3_e__Union.revision_id"]/*' />
        [UnscopedRef]
        public ref _NV_GPU_CHIP_REVISION revision_id
        {
            get
            {
                return ref Anonymous3.revision_id;
            }
        }

        /// <include file='_Anonymous1_e__Union.xml' path='doc/member[@name="_Anonymous1_e__Union"]/*' />
        [StructLayout(LayoutKind.Explicit)]
        public partial struct _Anonymous1_e__Union
        {
            /// <include file='_Anonymous1_e__Union.xml' path='doc/member[@name="_Anonymous1_e__Union.architecture"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NvU32")]
            public uint architecture;

            /// <include file='_Anonymous1_e__Union.xml' path='doc/member[@name="_Anonymous1_e__Union.architecture_id"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NV_GPU_ARCHITECTURE_ID")]
            public _NV_GPU_ARCHITECTURE_ID architecture_id;
        }

        /// <include file='_Anonymous2_e__Union.xml' path='doc/member[@name="_Anonymous2_e__Union"]/*' />
        [StructLayout(LayoutKind.Explicit)]
        public partial struct _Anonymous2_e__Union
        {
            /// <include file='_Anonymous2_e__Union.xml' path='doc/member[@name="_Anonymous2_e__Union.implementation"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NvU32")]
            public uint implementation;

            /// <include file='_Anonymous2_e__Union.xml' path='doc/member[@name="_Anonymous2_e__Union.implementation_id"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NV_GPU_ARCH_IMPLEMENTATION_ID")]
            public _NV_GPU_ARCH_IMPLEMENTATION_ID implementation_id;
        }

        /// <include file='_Anonymous3_e__Union.xml' path='doc/member[@name="_Anonymous3_e__Union"]/*' />
        [StructLayout(LayoutKind.Explicit)]
        public partial struct _Anonymous3_e__Union
        {
            /// <include file='_Anonymous3_e__Union.xml' path='doc/member[@name="_Anonymous3_e__Union.revision"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NvU32")]
            public uint revision;

            /// <include file='_Anonymous3_e__Union.xml' path='doc/member[@name="_Anonymous3_e__Union.revision_id"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NV_GPU_CHIP_REVISION")]
            public _NV_GPU_CHIP_REVISION revision_id;
        }
    }
}
