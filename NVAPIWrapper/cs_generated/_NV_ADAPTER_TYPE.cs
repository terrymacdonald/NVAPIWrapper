namespace NVAPIWrapper
{
    /// <include file='_NV_ADAPTER_TYPE.xml' path='doc/member[@name="_NV_ADAPTER_TYPE"]/*' />
    public enum _NV_ADAPTER_TYPE
    {
        /// <include file='_NV_ADAPTER_TYPE.xml' path='doc/member[@name="_NV_ADAPTER_TYPE.NV_ADAPTER_TYPE_UNKNOWN"]/*' />
        NV_ADAPTER_TYPE_UNKNOWN = 0x0,

        /// <include file='_NV_ADAPTER_TYPE.xml' path='doc/member[@name="_NV_ADAPTER_TYPE.NV_ADAPTER_TYPE_WDDM"]/*' />
        NV_ADAPTER_TYPE_WDDM = (1 << (0)),

        /// <include file='_NV_ADAPTER_TYPE.xml' path='doc/member[@name="_NV_ADAPTER_TYPE.NV_ADAPTER_TYPE_MCDM"]/*' />
        NV_ADAPTER_TYPE_MCDM = (1 << (1)),

        /// <include file='_NV_ADAPTER_TYPE.xml' path='doc/member[@name="_NV_ADAPTER_TYPE.NV_ADAPTER_TYPE_TCC"]/*' />
        NV_ADAPTER_TYPE_TCC = (1 << (2)),

        /// <include file='_NV_ADAPTER_TYPE.xml' path='doc/member[@name="_NV_ADAPTER_TYPE.NV_ADAPTER_TYPE_LAST"]/*' />
        NV_ADAPTER_TYPE_LAST = unchecked((int)(0xFFFFFFFF)),
    }
}
