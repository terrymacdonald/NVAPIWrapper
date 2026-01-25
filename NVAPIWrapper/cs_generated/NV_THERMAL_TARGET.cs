namespace NVAPIWrapper
{
    /// <include file='NV_THERMAL_TARGET.xml' path='doc/member[@name="NV_THERMAL_TARGET"]/*' />
    public enum NV_THERMAL_TARGET
    {
        /// <include file='NV_THERMAL_TARGET.xml' path='doc/member[@name="NV_THERMAL_TARGET.NVAPI_THERMAL_TARGET_NONE"]/*' />
        NVAPI_THERMAL_TARGET_NONE = 0,

        /// <include file='NV_THERMAL_TARGET.xml' path='doc/member[@name="NV_THERMAL_TARGET.NVAPI_THERMAL_TARGET_GPU"]/*' />
        NVAPI_THERMAL_TARGET_GPU = 1,

        /// <include file='NV_THERMAL_TARGET.xml' path='doc/member[@name="NV_THERMAL_TARGET.NVAPI_THERMAL_TARGET_MEMORY"]/*' />
        NVAPI_THERMAL_TARGET_MEMORY = 2,

        /// <include file='NV_THERMAL_TARGET.xml' path='doc/member[@name="NV_THERMAL_TARGET.NVAPI_THERMAL_TARGET_POWER_SUPPLY"]/*' />
        NVAPI_THERMAL_TARGET_POWER_SUPPLY = 4,

        /// <include file='NV_THERMAL_TARGET.xml' path='doc/member[@name="NV_THERMAL_TARGET.NVAPI_THERMAL_TARGET_BOARD"]/*' />
        NVAPI_THERMAL_TARGET_BOARD = 8,

        /// <include file='NV_THERMAL_TARGET.xml' path='doc/member[@name="NV_THERMAL_TARGET.NVAPI_THERMAL_TARGET_VCD_BOARD"]/*' />
        NVAPI_THERMAL_TARGET_VCD_BOARD = 9,

        /// <include file='NV_THERMAL_TARGET.xml' path='doc/member[@name="NV_THERMAL_TARGET.NVAPI_THERMAL_TARGET_VCD_INLET"]/*' />
        NVAPI_THERMAL_TARGET_VCD_INLET = 10,

        /// <include file='NV_THERMAL_TARGET.xml' path='doc/member[@name="NV_THERMAL_TARGET.NVAPI_THERMAL_TARGET_VCD_OUTLET"]/*' />
        NVAPI_THERMAL_TARGET_VCD_OUTLET = 11,

        /// <include file='NV_THERMAL_TARGET.xml' path='doc/member[@name="NV_THERMAL_TARGET.NVAPI_THERMAL_TARGET_ALL"]/*' />
        NVAPI_THERMAL_TARGET_ALL = 15,

        /// <include file='NV_THERMAL_TARGET.xml' path='doc/member[@name="NV_THERMAL_TARGET.NVAPI_THERMAL_TARGET_UNKNOWN"]/*' />
        NVAPI_THERMAL_TARGET_UNKNOWN = -1,
    }
}
