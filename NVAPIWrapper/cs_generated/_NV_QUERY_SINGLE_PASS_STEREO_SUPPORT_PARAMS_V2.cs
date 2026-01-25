namespace NVAPIWrapper
{
    /// <include file='_NV_QUERY_SINGLE_PASS_STEREO_SUPPORT_PARAMS_V2.xml' path='doc/member[@name="_NV_QUERY_SINGLE_PASS_STEREO_SUPPORT_PARAMS_V2"]/*' />
    public partial struct _NV_QUERY_SINGLE_PASS_STEREO_SUPPORT_PARAMS_V2
    {
        /// <include file='_NV_QUERY_SINGLE_PASS_STEREO_SUPPORT_PARAMS_V2.xml' path='doc/member[@name="_NV_QUERY_SINGLE_PASS_STEREO_SUPPORT_PARAMS_V2.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        public uint _bitfield;

        /// <include file='_NV_QUERY_SINGLE_PASS_STEREO_SUPPORT_PARAMS_V2.xml' path='doc/member[@name="_NV_QUERY_SINGLE_PASS_STEREO_SUPPORT_PARAMS_V2.bSinglePassStereoSupported"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bSinglePassStereoSupported
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

        /// <include file='_NV_QUERY_SINGLE_PASS_STEREO_SUPPORT_PARAMS_V2.xml' path='doc/member[@name="_NV_QUERY_SINGLE_PASS_STEREO_SUPPORT_PARAMS_V2.bSinglePassStereoXYZWSupported"]/*' />
        [NativeTypeName("NvU32 : 1")]
        public uint bSinglePassStereoXYZWSupported
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

        /// <include file='_NV_QUERY_SINGLE_PASS_STEREO_SUPPORT_PARAMS_V2.xml' path='doc/member[@name="_NV_QUERY_SINGLE_PASS_STEREO_SUPPORT_PARAMS_V2.reserved"]/*' />
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
    }
}
