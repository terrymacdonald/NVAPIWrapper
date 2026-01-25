namespace NVAPIWrapper
{
    /// <include file='_NV_GPU_DISPLAYIDS.xml' path='doc/member[@name="_NV_GPU_DISPLAYIDS"]/*' />
    public partial struct _NV_GPU_DISPLAYIDS
    {
        /// <include file='_NV_GPU_DISPLAYIDS.xml' path='doc/member[@name="_NV_GPU_DISPLAYIDS.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_GPU_DISPLAYIDS.xml' path='doc/member[@name="_NV_GPU_DISPLAYIDS.connectorType"]/*' />
        public NV_MONITOR_CONN_TYPE connectorType;

        /// <include file='_NV_GPU_DISPLAYIDS.xml' path='doc/member[@name="_NV_GPU_DISPLAYIDS.displayId"]/*' />
        [NativeTypeName("NvU32")]
        public uint displayId;

        public uint _bitfield;

        /// <include file='_NV_GPU_DISPLAYIDS.xml' path='doc/member[@name="_NV_GPU_DISPLAYIDS.isDynamic"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isDynamic
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

        /// <include file='_NV_GPU_DISPLAYIDS.xml' path='doc/member[@name="_NV_GPU_DISPLAYIDS.isMultiStreamRootNode"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isMultiStreamRootNode
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

        /// <include file='_NV_GPU_DISPLAYIDS.xml' path='doc/member[@name="_NV_GPU_DISPLAYIDS.isActive"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isActive
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

        /// <include file='_NV_GPU_DISPLAYIDS.xml' path='doc/member[@name="_NV_GPU_DISPLAYIDS.isCluster"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isCluster
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

        /// <include file='_NV_GPU_DISPLAYIDS.xml' path='doc/member[@name="_NV_GPU_DISPLAYIDS.isOSVisible"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isOSVisible
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

        /// <include file='_NV_GPU_DISPLAYIDS.xml' path='doc/member[@name="_NV_GPU_DISPLAYIDS.isWFD"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isWFD
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

        /// <include file='_NV_GPU_DISPLAYIDS.xml' path='doc/member[@name="_NV_GPU_DISPLAYIDS.isConnected"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isConnected
        {
            readonly get
            {
                return (_bitfield >> 6) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 6)) | ((value & 0x1u) << 6);
            }
        }

        /// <include file='_NV_GPU_DISPLAYIDS.xml' path='doc/member[@name="_NV_GPU_DISPLAYIDS.reservedInternal"]/*' />
        [NativeTypeName("NvU32 : 10")]
        public uint reservedInternal
        {
            readonly get
            {
                return (_bitfield >> 7) & 0x3FFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x3FFu << 7)) | ((value & 0x3FFu) << 7);
            }
        }

        /// <include file='_NV_GPU_DISPLAYIDS.xml' path='doc/member[@name="_NV_GPU_DISPLAYIDS.isPhysicallyConnected"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint isPhysicallyConnected
        {
            readonly get
            {
                return (_bitfield >> 17) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 17)) | ((value & 0x1u) << 17);
            }
        }

        /// <include file='_NV_GPU_DISPLAYIDS.xml' path='doc/member[@name="_NV_GPU_DISPLAYIDS.reserved"]/*' />
        [NativeTypeName("NvU32 : 14")]
        public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 18) & 0x3FFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x3FFFu << 18)) | ((value & 0x3FFFu) << 18);
            }
        }
    }
}
