using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_GET_VRR_INFO_V1.xml' path='doc/member[@name="_NV_GET_VRR_INFO_V1"]/*' />
    public partial struct _NV_GET_VRR_INFO_V1
    {
        /// <include file='_NV_GET_VRR_INFO_V1.xml' path='doc/member[@name="_NV_GET_VRR_INFO_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        public uint _bitfield;

        /// <include file='_NV_GET_VRR_INFO_V1.xml' path='doc/member[@name="_NV_GET_VRR_INFO_V1.bIsVRREnabled"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bIsVRREnabled
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

        /// <include file='_NV_GET_VRR_INFO_V1.xml' path='doc/member[@name="_NV_GET_VRR_INFO_V1.bIsVRRPossible"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bIsVRRPossible
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

        /// <include file='_NV_GET_VRR_INFO_V1.xml' path='doc/member[@name="_NV_GET_VRR_INFO_V1.bIsVRRRequested"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bIsVRRRequested
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

        /// <include file='_NV_GET_VRR_INFO_V1.xml' path='doc/member[@name="_NV_GET_VRR_INFO_V1.bIsVRRIndicatorEnabled"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bIsVRRIndicatorEnabled
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

        /// <include file='_NV_GET_VRR_INFO_V1.xml' path='doc/member[@name="_NV_GET_VRR_INFO_V1.bIsDisplayInVRRMode"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bIsDisplayInVRRMode
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

        /// <include file='_NV_GET_VRR_INFO_V1.xml' path='doc/member[@name="_NV_GET_VRR_INFO_V1.reserved"]/*' />
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

        /// <include file='_NV_GET_VRR_INFO_V1.xml' path='doc/member[@name="_NV_GET_VRR_INFO_V1.reservedEx"]/*' />
        [NativeTypeName("NvU32[4]")]
        public _reservedEx_e__FixedBuffer reservedEx;

        /// <include file='_reservedEx_e__FixedBuffer.xml' path='doc/member[@name="_reservedEx_e__FixedBuffer"]/*' />
        [InlineArray(4)]
        public partial struct _reservedEx_e__FixedBuffer
        {
            public uint e0;
        }
    }
}
