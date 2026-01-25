using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_DISPLAYCONFIG_PATH_INFO.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_INFO"]/*' />
    public unsafe partial struct _NV_DISPLAYCONFIG_PATH_INFO
    {
        /// <include file='_NV_DISPLAYCONFIG_PATH_INFO.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_INFO.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_DISPLAYCONFIG_PATH_INFO.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_INFO.Anonymous"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L1022_C5")]
        public _Anonymous_e__Union Anonymous;

        /// <include file='_NV_DISPLAYCONFIG_PATH_INFO.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_INFO.targetInfoCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint targetInfoCount;

        /// <include file='_NV_DISPLAYCONFIG_PATH_INFO.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_INFO.targetInfo"]/*' />
        [NativeTypeName("NV_DISPLAYCONFIG_PATH_TARGET_INFO_V2 *")]
        public _NV_DISPLAYCONFIG_PATH_TARGET_INFO_V2* targetInfo;

        /// <include file='_NV_DISPLAYCONFIG_PATH_INFO.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_INFO.sourceModeInfo"]/*' />
        [NativeTypeName("NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1 *")]
        public _NV_DISPLAYCONFIG_SOURCE_MODE_INFO_V1* sourceModeInfo;

        public uint _bitfield;

        /// <include file='_NV_DISPLAYCONFIG_PATH_INFO.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_INFO.IsNonNVIDIAAdapter"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint IsNonNVIDIAAdapter
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

        /// <include file='_NV_DISPLAYCONFIG_PATH_INFO.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_INFO.reserved"]/*' />
        [NativeTypeName("NvU32 : 31")]
        public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x7FFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x7FFFFFFFu << 1)) | ((value & 0x7FFFFFFFu) << 1);
            }
        }

        /// <include file='_NV_DISPLAYCONFIG_PATH_INFO.xml' path='doc/member[@name="_NV_DISPLAYCONFIG_PATH_INFO.pOSAdapterID"]/*' />
        public void* pOSAdapterID;

        /// <include file='_Anonymous_e__Union.xml' path='doc/member[@name="_Anonymous_e__Union.sourceId"]/*' />
        [UnscopedRef]
        public ref uint sourceId
        {
            get
            {
                return ref Anonymous.sourceId;
            }
        }

        /// <include file='_Anonymous_e__Union.xml' path='doc/member[@name="_Anonymous_e__Union.reserved_sourceId"]/*' />
        [UnscopedRef]
        public ref uint reserved_sourceId
        {
            get
            {
                return ref Anonymous.reserved_sourceId;
            }
        }

        /// <include file='_Anonymous_e__Union.xml' path='doc/member[@name="_Anonymous_e__Union"]/*' />
        [StructLayout(LayoutKind.Explicit)]
        public partial struct _Anonymous_e__Union
        {
            /// <include file='_Anonymous_e__Union.xml' path='doc/member[@name="_Anonymous_e__Union.sourceId"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NvU32")]
            public uint sourceId;

            /// <include file='_Anonymous_e__Union.xml' path='doc/member[@name="_Anonymous_e__Union.reserved_sourceId"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NvU32")]
            public uint reserved_sourceId;
        }
    }
}
