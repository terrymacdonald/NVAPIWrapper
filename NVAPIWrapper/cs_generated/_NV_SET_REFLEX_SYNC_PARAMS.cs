using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_SET_REFLEX_SYNC_PARAMS.xml' path='doc/member[@name="_NV_SET_REFLEX_SYNC_PARAMS"]/*' />
    public partial struct _NV_SET_REFLEX_SYNC_PARAMS
    {
        /// <include file='_NV_SET_REFLEX_SYNC_PARAMS.xml' path='doc/member[@name="_NV_SET_REFLEX_SYNC_PARAMS.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        public uint _bitfield;

        /// <include file='_NV_SET_REFLEX_SYNC_PARAMS.xml' path='doc/member[@name="_NV_SET_REFLEX_SYNC_PARAMS.bEnable"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bEnable
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

        /// <include file='_NV_SET_REFLEX_SYNC_PARAMS.xml' path='doc/member[@name="_NV_SET_REFLEX_SYNC_PARAMS.bDisable"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bDisable
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

        /// <include file='_NV_SET_REFLEX_SYNC_PARAMS.xml' path='doc/member[@name="_NV_SET_REFLEX_SYNC_PARAMS.flagsRsvd"]/*' />
        [NativeTypeName("NvU32 : 30")]
        public uint flagsRsvd
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

        /// <include file='_NV_SET_REFLEX_SYNC_PARAMS.xml' path='doc/member[@name="_NV_SET_REFLEX_SYNC_PARAMS.vblankIntervalUs"]/*' />
        [NativeTypeName("NvU32")]
        public uint vblankIntervalUs;

        /// <include file='_NV_SET_REFLEX_SYNC_PARAMS.xml' path='doc/member[@name="_NV_SET_REFLEX_SYNC_PARAMS.timeInQueueUs"]/*' />
        [NativeTypeName("NvS32")]
        public int timeInQueueUs;

        /// <include file='_NV_SET_REFLEX_SYNC_PARAMS.xml' path='doc/member[@name="_NV_SET_REFLEX_SYNC_PARAMS.timeInQueueUsTarget"]/*' />
        [NativeTypeName("NvU32")]
        public uint timeInQueueUsTarget;

        /// <include file='_NV_SET_REFLEX_SYNC_PARAMS.xml' path='doc/member[@name="_NV_SET_REFLEX_SYNC_PARAMS.rsvd"]/*' />
        [NativeTypeName("NvU8[28]")]
        public _rsvd_e__FixedBuffer rsvd;

        /// <include file='_rsvd_e__FixedBuffer.xml' path='doc/member[@name="_rsvd_e__FixedBuffer"]/*' />
        [InlineArray(28)]
        public partial struct _rsvd_e__FixedBuffer
        {
            public byte e0;
        }
    }
}
