using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='tagNV_TIMINGEXT.xml' path='doc/member[@name="tagNV_TIMINGEXT"]/*' />
    public partial struct tagNV_TIMINGEXT
    {
        /// <include file='tagNV_TIMINGEXT.xml' path='doc/member[@name="tagNV_TIMINGEXT.flag"]/*' />
        [NativeTypeName("NvU32")]
        public uint flag;

        /// <include file='tagNV_TIMINGEXT.xml' path='doc/member[@name="tagNV_TIMINGEXT.rr"]/*' />
        [NativeTypeName("NvU16")]
        public ushort rr;

        /// <include file='tagNV_TIMINGEXT.xml' path='doc/member[@name="tagNV_TIMINGEXT.rrx1k"]/*' />
        [NativeTypeName("NvU32")]
        public uint rrx1k;

        /// <include file='tagNV_TIMINGEXT.xml' path='doc/member[@name="tagNV_TIMINGEXT.aspect"]/*' />
        [NativeTypeName("NvU32")]
        public uint aspect;

        /// <include file='tagNV_TIMINGEXT.xml' path='doc/member[@name="tagNV_TIMINGEXT.rep"]/*' />
        [NativeTypeName("NvU16")]
        public ushort rep;

        /// <include file='tagNV_TIMINGEXT.xml' path='doc/member[@name="tagNV_TIMINGEXT.status"]/*' />
        [NativeTypeName("NvU32")]
        public uint status;

        /// <include file='tagNV_TIMINGEXT.xml' path='doc/member[@name="tagNV_TIMINGEXT.name"]/*' />
        [NativeTypeName("NvU8[40]")]
        public _name_e__FixedBuffer name;

        /// <include file='_name_e__FixedBuffer.xml' path='doc/member[@name="_name_e__FixedBuffer"]/*' />
        [InlineArray(40)]
        public partial struct _name_e__FixedBuffer
        {
            public byte e0;
        }
    }
}
