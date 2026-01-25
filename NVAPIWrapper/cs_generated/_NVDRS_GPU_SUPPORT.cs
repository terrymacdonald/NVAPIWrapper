namespace NVAPIWrapper
{
    /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT"]/*' />
    public partial struct _NVDRS_GPU_SUPPORT
    {
        public uint _bitfield;

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.geforce"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint geforce
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

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.quadro"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint quadro
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

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.nvs"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint nvs
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

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved4"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved4
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

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved5"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved5
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

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved6"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved6
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

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved7"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved7
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

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved8"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved8
        {
            readonly get
            {
                return (_bitfield >> 7) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 7)) | ((value & 0x1u) << 7);
            }
        }

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved9"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved9
        {
            readonly get
            {
                return (_bitfield >> 8) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 8)) | ((value & 0x1u) << 8);
            }
        }

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved10"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved10
        {
            readonly get
            {
                return (_bitfield >> 9) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 9)) | ((value & 0x1u) << 9);
            }
        }

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved11"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved11
        {
            readonly get
            {
                return (_bitfield >> 10) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 10)) | ((value & 0x1u) << 10);
            }
        }

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved12"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved12
        {
            readonly get
            {
                return (_bitfield >> 11) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 11)) | ((value & 0x1u) << 11);
            }
        }

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved13"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved13
        {
            readonly get
            {
                return (_bitfield >> 12) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 12)) | ((value & 0x1u) << 12);
            }
        }

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved14"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved14
        {
            readonly get
            {
                return (_bitfield >> 13) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 13)) | ((value & 0x1u) << 13);
            }
        }

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved15"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved15
        {
            readonly get
            {
                return (_bitfield >> 14) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 14)) | ((value & 0x1u) << 14);
            }
        }

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved16"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved16
        {
            readonly get
            {
                return (_bitfield >> 15) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 15)) | ((value & 0x1u) << 15);
            }
        }

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved17"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved17
        {
            readonly get
            {
                return (_bitfield >> 16) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 16)) | ((value & 0x1u) << 16);
            }
        }

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved18"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved18
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

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved19"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved19
        {
            readonly get
            {
                return (_bitfield >> 18) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 18)) | ((value & 0x1u) << 18);
            }
        }

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved20"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved20
        {
            readonly get
            {
                return (_bitfield >> 19) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 19)) | ((value & 0x1u) << 19);
            }
        }

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved21"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved21
        {
            readonly get
            {
                return (_bitfield >> 20) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 20)) | ((value & 0x1u) << 20);
            }
        }

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved22"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved22
        {
            readonly get
            {
                return (_bitfield >> 21) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 21)) | ((value & 0x1u) << 21);
            }
        }

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved23"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved23
        {
            readonly get
            {
                return (_bitfield >> 22) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 22)) | ((value & 0x1u) << 22);
            }
        }

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved24"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved24
        {
            readonly get
            {
                return (_bitfield >> 23) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 23)) | ((value & 0x1u) << 23);
            }
        }

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved25"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved25
        {
            readonly get
            {
                return (_bitfield >> 24) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 24)) | ((value & 0x1u) << 24);
            }
        }

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved26"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved26
        {
            readonly get
            {
                return (_bitfield >> 25) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 25)) | ((value & 0x1u) << 25);
            }
        }

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved27"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved27
        {
            readonly get
            {
                return (_bitfield >> 26) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 26)) | ((value & 0x1u) << 26);
            }
        }

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved28"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved28
        {
            readonly get
            {
                return (_bitfield >> 27) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 27)) | ((value & 0x1u) << 27);
            }
        }

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved29"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved29
        {
            readonly get
            {
                return (_bitfield >> 28) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 28)) | ((value & 0x1u) << 28);
            }
        }

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved30"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved30
        {
            readonly get
            {
                return (_bitfield >> 29) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 29)) | ((value & 0x1u) << 29);
            }
        }

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved31"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved31
        {
            readonly get
            {
                return (_bitfield >> 30) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 30)) | ((value & 0x1u) << 30);
            }
        }

        /// <include file='_NVDRS_GPU_SUPPORT.xml' path='doc/member[@name="_NVDRS_GPU_SUPPORT.reserved32"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint reserved32
        {
            readonly get
            {
                return (_bitfield >> 31) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 31)) | ((value & 0x1u) << 31);
            }
        }
    }
}
