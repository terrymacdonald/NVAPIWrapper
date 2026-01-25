using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_MANAGED_DEDICATED_DISPLAY_METADATA.xml' path='doc/member[@name="_NV_MANAGED_DEDICATED_DISPLAY_METADATA"]/*' />
    public partial struct _NV_MANAGED_DEDICATED_DISPLAY_METADATA
    {
        /// <include file='_NV_MANAGED_DEDICATED_DISPLAY_METADATA.xml' path='doc/member[@name="_NV_MANAGED_DEDICATED_DISPLAY_METADATA.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_MANAGED_DEDICATED_DISPLAY_METADATA.xml' path='doc/member[@name="_NV_MANAGED_DEDICATED_DISPLAY_METADATA.displayId"]/*' />
        [NativeTypeName("NvU32")]
        public uint displayId;

        public uint _bitfield;

        /// <include file='_NV_MANAGED_DEDICATED_DISPLAY_METADATA.xml' path='doc/member[@name="_NV_MANAGED_DEDICATED_DISPLAY_METADATA.bSetPosition"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bSetPosition
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

        /// <include file='_NV_MANAGED_DEDICATED_DISPLAY_METADATA.xml' path='doc/member[@name="_NV_MANAGED_DEDICATED_DISPLAY_METADATA.bRemovePosition"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bRemovePosition
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

        /// <include file='_NV_MANAGED_DEDICATED_DISPLAY_METADATA.xml' path='doc/member[@name="_NV_MANAGED_DEDICATED_DISPLAY_METADATA.bPositionIsAvailable"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bPositionIsAvailable
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

        /// <include file='_NV_MANAGED_DEDICATED_DISPLAY_METADATA.xml' path='doc/member[@name="_NV_MANAGED_DEDICATED_DISPLAY_METADATA.bSetName"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bSetName
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

        /// <include file='_NV_MANAGED_DEDICATED_DISPLAY_METADATA.xml' path='doc/member[@name="_NV_MANAGED_DEDICATED_DISPLAY_METADATA.bRemoveName"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bRemoveName
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

        /// <include file='_NV_MANAGED_DEDICATED_DISPLAY_METADATA.xml' path='doc/member[@name="_NV_MANAGED_DEDICATED_DISPLAY_METADATA.bNameIsAvailable"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bNameIsAvailable
        {
            readonly get
            {
                return (_bitfield >> 5) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 5)) | ((value & 0x1u) << 5);
            }
        }

        /// <include file='_NV_MANAGED_DEDICATED_DISPLAY_METADATA.xml' path='doc/member[@name="_NV_MANAGED_DEDICATED_DISPLAY_METADATA.reserved"]/*' />
        [NativeTypeName("NvU32 : 26")]
        public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 6) & 0x3FFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x3FFFFFFu << 6)) | ((value & 0x3FFFFFFu) << 6);
            }
        }

        /// <include file='_NV_MANAGED_DEDICATED_DISPLAY_METADATA.xml' path='doc/member[@name="_NV_MANAGED_DEDICATED_DISPLAY_METADATA.positionX"]/*' />
        [NativeTypeName("NvS32")]
        public int positionX;

        /// <include file='_NV_MANAGED_DEDICATED_DISPLAY_METADATA.xml' path='doc/member[@name="_NV_MANAGED_DEDICATED_DISPLAY_METADATA.positionY"]/*' />
        [NativeTypeName("NvS32")]
        public int positionY;

        /// <include file='_NV_MANAGED_DEDICATED_DISPLAY_METADATA.xml' path='doc/member[@name="_NV_MANAGED_DEDICATED_DISPLAY_METADATA.name"]/*' />
        [NativeTypeName("NvAPI_ShortString")]
        public _name_e__FixedBuffer name;

        /// <include file='_name_e__FixedBuffer.xml' path='doc/member[@name="_name_e__FixedBuffer"]/*' />
        [InlineArray(64)]
        public partial struct _name_e__FixedBuffer
        {
            public sbyte e0;
        }
    }
}
