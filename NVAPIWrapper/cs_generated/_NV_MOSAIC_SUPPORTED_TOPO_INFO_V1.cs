using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NV_MOSAIC_SUPPORTED_TOPO_INFO_V1.xml' path='doc/member[@name="_NV_MOSAIC_SUPPORTED_TOPO_INFO_V1"]/*' />
    public partial struct _NV_MOSAIC_SUPPORTED_TOPO_INFO_V1
    {
        /// <include file='_NV_MOSAIC_SUPPORTED_TOPO_INFO_V1.xml' path='doc/member[@name="_NV_MOSAIC_SUPPORTED_TOPO_INFO_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NV_MOSAIC_SUPPORTED_TOPO_INFO_V1.xml' path='doc/member[@name="_NV_MOSAIC_SUPPORTED_TOPO_INFO_V1.topoBriefsCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint topoBriefsCount;

        /// <include file='_NV_MOSAIC_SUPPORTED_TOPO_INFO_V1.xml' path='doc/member[@name="_NV_MOSAIC_SUPPORTED_TOPO_INFO_V1.topoBriefs"]/*' />
        [NativeTypeName("NV_MOSAIC_TOPO_BRIEF[35]")]
        public _topoBriefs_e__FixedBuffer topoBriefs;

        /// <include file='_NV_MOSAIC_SUPPORTED_TOPO_INFO_V1.xml' path='doc/member[@name="_NV_MOSAIC_SUPPORTED_TOPO_INFO_V1.displaySettingsCount"]/*' />
        [NativeTypeName("NvU32")]
        public uint displaySettingsCount;

        /// <include file='_NV_MOSAIC_SUPPORTED_TOPO_INFO_V1.xml' path='doc/member[@name="_NV_MOSAIC_SUPPORTED_TOPO_INFO_V1.displaySettings"]/*' />
        [NativeTypeName("NV_MOSAIC_DISPLAY_SETTING_V1[40]")]
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
            public _NV_MOSAIC_DISPLAY_SETTING_V1 e0;
        }
    }
}
