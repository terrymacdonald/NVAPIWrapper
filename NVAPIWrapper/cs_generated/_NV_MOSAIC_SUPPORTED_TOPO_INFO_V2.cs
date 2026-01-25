using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_MOSAIC_SUPPORTED_TOPO_INFO_V2.xml' path='doc/member[@name="_NV_MOSAIC_SUPPORTED_TOPO_INFO_V2"]/*' />
    public partial struct _NV_MOSAIC_SUPPORTED_TOPO_INFO_V2
    {
        /// <include file='_NV_MOSAIC_SUPPORTED_TOPO_INFO_V2.xml' path='doc/member[@name="_NV_MOSAIC_SUPPORTED_TOPO_INFO_V2.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_MOSAIC_SUPPORTED_TOPO_INFO_V2.xml' path='doc/member[@name="_NV_MOSAIC_SUPPORTED_TOPO_INFO_V2.topoBriefsCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint topoBriefsCount;

        /// <include file='_NV_MOSAIC_SUPPORTED_TOPO_INFO_V2.xml' path='doc/member[@name="_NV_MOSAIC_SUPPORTED_TOPO_INFO_V2.topoBriefs"]/*' />
        [NativeTypeName("NV_MOSAIC_TOPO_BRIEF[35]")]
        public _topoBriefs_e__FixedBuffer topoBriefs;

        /// <include file='_NV_MOSAIC_SUPPORTED_TOPO_INFO_V2.xml' path='doc/member[@name="_NV_MOSAIC_SUPPORTED_TOPO_INFO_V2.displaySettingsCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint displaySettingsCount;

        /// <include file='_NV_MOSAIC_SUPPORTED_TOPO_INFO_V2.xml' path='doc/member[@name="_NV_MOSAIC_SUPPORTED_TOPO_INFO_V2.displaySettings"]/*' />
        [NativeTypeName("NV_MOSAIC_DISPLAY_SETTING_V2[40]")]
        public _displaySettings_e__FixedBuffer displaySettings;

        /// <include file='_topoBriefs_e__FixedBuffer.xml' path='doc/member[@name="_topoBriefs_e__FixedBuffer"]/*' />
        [InlineArray(35)]
        public partial struct _topoBriefs_e__FixedBuffer
        {
            public NV_MOSAIC_TOPO_BRIEF e0;
        }

        /// <include file='_displaySettings_e__FixedBuffer.xml' path='doc/member[@name="_displaySettings_e__FixedBuffer"]/*' />
        [InlineArray(40)]
        public partial struct _displaySettings_e__FixedBuffer
        {
            public NV_MOSAIC_DISPLAY_SETTING_V2 e0;
        }
    }
}
