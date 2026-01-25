using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_SET_ADAPTIVE_SYNC_DATA_V1.xml' path='doc/member[@name="_NV_SET_ADAPTIVE_SYNC_DATA_V1"]/*' />
    public partial struct _NV_SET_ADAPTIVE_SYNC_DATA_V1
    {
        /// <include file='_NV_SET_ADAPTIVE_SYNC_DATA_V1.xml' path='doc/member[@name="_NV_SET_ADAPTIVE_SYNC_DATA_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_SET_ADAPTIVE_SYNC_DATA_V1.xml' path='doc/member[@name="_NV_SET_ADAPTIVE_SYNC_DATA_V1.maxFrameInterval"]/*' />
        [NativeTypeName("NvU32")]
        public uint maxFrameInterval;

        public uint _bitfield;

        /// <include file='_NV_SET_ADAPTIVE_SYNC_DATA_V1.xml' path='doc/member[@name="_NV_SET_ADAPTIVE_SYNC_DATA_V1.bDisableAdaptiveSync"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bDisableAdaptiveSync
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

        /// <include file='_NV_SET_ADAPTIVE_SYNC_DATA_V1.xml' path='doc/member[@name="_NV_SET_ADAPTIVE_SYNC_DATA_V1.bDisableFrameSplitting"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bDisableFrameSplitting
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

        /// <include file='_NV_SET_ADAPTIVE_SYNC_DATA_V1.xml' path='doc/member[@name="_NV_SET_ADAPTIVE_SYNC_DATA_V1.reserved"]/*' />
        [NativeTypeName("NvU32 : 30")]
        public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x3FFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x3FFFFFFFu << 2)) | ((value & 0x3FFFFFFFu) << 2);
            }
        }

        /// <include file='_NV_SET_ADAPTIVE_SYNC_DATA_V1.xml' path='doc/member[@name="_NV_SET_ADAPTIVE_SYNC_DATA_V1.reserved1"]/*' />
        [NativeTypeName("NvU32")]
        public uint reserved1;

        /// <include file='_NV_SET_ADAPTIVE_SYNC_DATA_V1.xml' path='doc/member[@name="_NV_SET_ADAPTIVE_SYNC_DATA_V1.maxFrameIntervalNs"]/*' />
        [NativeTypeName("NvU64")]
        public ulong maxFrameIntervalNs;

        /// <include file='_NV_SET_ADAPTIVE_SYNC_DATA_V1.xml' path='doc/member[@name="_NV_SET_ADAPTIVE_SYNC_DATA_V1.reservedEx"]/*' />
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
