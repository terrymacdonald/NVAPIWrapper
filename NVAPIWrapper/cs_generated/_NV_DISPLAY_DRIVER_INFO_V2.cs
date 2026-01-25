using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_DISPLAY_DRIVER_INFO_V2.xml' path='doc/member[@name="_NV_DISPLAY_DRIVER_INFO_V2"]/*' />
    public partial struct _NV_DISPLAY_DRIVER_INFO_V2
    {
        /// <include file='_NV_DISPLAY_DRIVER_INFO_V2.xml' path='doc/member[@name="_NV_DISPLAY_DRIVER_INFO_V2.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_DISPLAY_DRIVER_INFO_V2.xml' path='doc/member[@name="_NV_DISPLAY_DRIVER_INFO_V2.driverVersion"]/*' />
        [NativeTypeName("NvU32")]
        public uint driverVersion;

        /// <include file='_NV_DISPLAY_DRIVER_INFO_V2.xml' path='doc/member[@name="_NV_DISPLAY_DRIVER_INFO_V2.szBuildBranch"]/*' />
        [NativeTypeName("NvAPI_ShortString")]
        public _szBuildBranch_e__FixedBuffer szBuildBranch;

        public uint _bitfield;

        /// <include file='_NV_DISPLAY_DRIVER_INFO_V2.xml' path='doc/member[@name="_NV_DISPLAY_DRIVER_INFO_V2.bIsDCHDriver"]/*' />
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

        /// <include file='_NV_DISPLAY_DRIVER_INFO_V2.xml' path='doc/member[@name="_NV_DISPLAY_DRIVER_INFO_V2.bIsNVIDIAStudioPackage"]/*' />
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

        /// <include file='_NV_DISPLAY_DRIVER_INFO_V2.xml' path='doc/member[@name="_NV_DISPLAY_DRIVER_INFO_V2.bIsNVIDIAGameReadyPackage"]/*' />
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

        /// <include file='_NV_DISPLAY_DRIVER_INFO_V2.xml' path='doc/member[@name="_NV_DISPLAY_DRIVER_INFO_V2.bIsNVIDIARTXProductionBranchPackage"]/*' />
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

        /// <include file='_NV_DISPLAY_DRIVER_INFO_V2.xml' path='doc/member[@name="_NV_DISPLAY_DRIVER_INFO_V2.bIsNVIDIARTXNewFeatureBranchPackage"]/*' />
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

        /// <include file='_NV_DISPLAY_DRIVER_INFO_V2.xml' path='doc/member[@name="_NV_DISPLAY_DRIVER_INFO_V2.reserved"]/*' />
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

        /// <include file='_NV_DISPLAY_DRIVER_INFO_V2.xml' path='doc/member[@name="_NV_DISPLAY_DRIVER_INFO_V2.szBuildBaseBranch"]/*' />
        [NativeTypeName("NvAPI_ShortString")]
        public _szBuildBaseBranch_e__FixedBuffer szBuildBaseBranch;

        /// <include file='_NV_DISPLAY_DRIVER_INFO_V2.xml' path='doc/member[@name="_NV_DISPLAY_DRIVER_INFO_V2.reservedEx"]/*' />
        [NativeTypeName("NvU32")]
        public uint reservedEx;

        /// <include file='_szBuildBranch_e__FixedBuffer.xml' path='doc/member[@name="_szBuildBranch_e__FixedBuffer"]/*' />
        [InlineArray(64)]
        public partial struct _szBuildBranch_e__FixedBuffer
        {
            public sbyte e0;
        }

        /// <include file='_szBuildBaseBranch_e__FixedBuffer.xml' path='doc/member[@name="_szBuildBaseBranch_e__FixedBuffer"]/*' />
        [InlineArray(64)]
        public partial struct _szBuildBaseBranch_e__FixedBuffer
        {
            public sbyte e0;
        }
    }
}
