using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NV_QSYNC_EVENT_DATA.xml' path='doc/member[@name="NV_QSYNC_EVENT_DATA"]/*' />
    public partial struct NV_QSYNC_EVENT_DATA
    {
        /// <include file='NV_QSYNC_EVENT_DATA.xml' path='doc/member[@name="NV_QSYNC_EVENT_DATA.qsyncEvent"]/*' />
        public NV_QSYNC_EVENT qsyncEvent;

        /// <include file='NV_QSYNC_EVENT_DATA.xml' path='doc/member[@name="NV_QSYNC_EVENT_DATA.reserved"]/*' />
        [NativeTypeName("NvU32[7]")]
        public _reserved_e__FixedBuffer reserved;

        /// <include file='_reserved_e__FixedBuffer.xml' path='doc/member[@name="_reserved_e__FixedBuffer"]/*' />
        [InlineArray(7)]
        public partial struct _reserved_e__FixedBuffer
        {
            public uint e0;
        }
    }
}
