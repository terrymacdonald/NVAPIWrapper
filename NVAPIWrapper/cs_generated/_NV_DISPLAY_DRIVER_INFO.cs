using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_DISPLAY_DRIVER_INFO.xml' path='doc/member[@name="_NV_DISPLAY_DRIVER_INFO"]/*' />
    public partial struct _NV_DISPLAY_DRIVER_INFO
    {
        /// <include file='_NV_DISPLAY_DRIVER_INFO.xml' path='doc/member[@name="_NV_DISPLAY_DRIVER_INFO.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_DISPLAY_DRIVER_INFO.xml' path='doc/member[@name="_NV_DISPLAY_DRIVER_INFO.driverVersion"]/*' />
        [NativeTypeName("NvU32")]
        public uint driverVersion;

        /// <include file='_NV_DISPLAY_DRIVER_INFO.xml' path='doc/member[@name="_NV_DISPLAY_DRIVER_INFO.szBuildBranch"]/*' />
        [NativeTypeName("NvAPI_ShortString")]
        public _szBuildBranch_e__FixedBuffer szBuildBranch;

        public uint _bitfield;

        /// <include file='_NV_DISPLAY_DRIVER_INFO.xml' path='doc/member[@name="_NV_DISPLAY_DRIVER_INFO.bIsDCHDriver"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bIsDCHDriver
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

        /// <include file='_NV_DISPLAY_DRIVER_INFO.xml' path='doc/member[@name="_NV_DISPLAY_DRIVER_INFO.bIsNVIDIAStudioPackage"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bIsNVIDIAStudioPackage
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

        /// <include file='_NV_DISPLAY_DRIVER_INFO.xml' path='doc/member[@name="_NV_DISPLAY_DRIVER_INFO.bIsNVIDIAGameReadyPackage"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bIsNVIDIAGameReadyPackage
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

        /// <include file='_NV_DISPLAY_DRIVER_INFO.xml' path='doc/member[@name="_NV_DISPLAY_DRIVER_INFO.bIsNVIDIARTXProductionBranchPackage"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bIsNVIDIARTXProductionBranchPackage
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
            }
        }

        /// <include file='_NV_DISPLAY_DRIVER_INFO.xml' path='doc/member[@name="_NV_DISPLAY_DRIVER_INFO.bIsNVIDIARTXNewFeatureBranchPackage"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bIsNVIDIARTXNewFeatureBranchPackage
        {
            readonly get
            {
                return (_bitfield >> 4) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 4)) | ((value & 0x1u) << 4);
            }
        }

        /// <include file='_NV_DISPLAY_DRIVER_INFO.xml' path='doc/member[@name="_NV_DISPLAY_DRIVER_INFO.reserved"]/*' />
        [NativeTypeName("NvU32 : 27")]
        public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 5) & 0x7FFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x7FFFFFFu << 5)) | ((value & 0x7FFFFFFu) << 5);
            }
        }

        /// <include file='_szBuildBranch_e__FixedBuffer.xml' path='doc/member[@name="_szBuildBranch_e__FixedBuffer"]/*' />
        [InlineArray(64)]
        public partial struct _szBuildBranch_e__FixedBuffer
        {
            public sbyte e0;
        }
    }
}
