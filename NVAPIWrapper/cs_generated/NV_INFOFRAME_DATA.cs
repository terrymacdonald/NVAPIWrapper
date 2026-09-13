using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <include file='NV_INFOFRAME_DATA.xml' path='doc/member[@name="NV_INFOFRAME_DATA"]/*' />
    public partial struct NV_INFOFRAME_DATA
    {
        /// <include file='NV_INFOFRAME_DATA.xml' path='doc/member[@name="NV_INFOFRAME_DATA.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_INFOFRAME_DATA.xml' path='doc/member[@name="NV_INFOFRAME_DATA.size"]/*' />
        [NativeTypeName("NvU16")]
        public ushort size;

        /// <include file='NV_INFOFRAME_DATA.xml' path='doc/member[@name="NV_INFOFRAME_DATA.cmd"]/*' />
        [NativeTypeName("NvU8")]
        public byte cmd;

        /// <include file='NV_INFOFRAME_DATA.xml' path='doc/member[@name="NV_INFOFRAME_DATA.type"]/*' />
        [NativeTypeName("NvU8")]
        public byte type;

        /// <include file='NV_INFOFRAME_DATA.xml' path='doc/member[@name="NV_INFOFRAME_DATA.infoframe"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L7525_C5")]
        public _infoframe_e__Union infoframe;

        /// <include file='_infoframe_e__Union.xml' path='doc/member[@name="_infoframe_e__Union"]/*' />
        [StructLayout(LayoutKind.Explicit)]
        public partial struct _infoframe_e__Union
        {
            /// <include file='_infoframe_e__Union.xml' path='doc/member[@name="_infoframe_e__Union.property"]/*' />
            [FieldOffset(0)]
            public NV_INFOFRAME_PROPERTY property;

            /// <include file='_infoframe_e__Union.xml' path='doc/member[@name="_infoframe_e__Union.audio"]/*' />
            [FieldOffset(0)]
            public NV_INFOFRAME_AUDIO audio;

            /// <include file='_infoframe_e__Union.xml' path='doc/member[@name="_infoframe_e__Union.video"]/*' />
            [FieldOffset(0)]
            public NV_INFOFRAME_VIDEO video;
        }
    }
}
