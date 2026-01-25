using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NV_GPU_THERMAL_SETTINGS_V2.xml' path='doc/member[@name="NV_GPU_THERMAL_SETTINGS_V2"]/*' />
    public partial struct NV_GPU_THERMAL_SETTINGS_V2
    {
        /// <include file='NV_GPU_THERMAL_SETTINGS_V2.xml' path='doc/member[@name="NV_GPU_THERMAL_SETTINGS_V2.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_GPU_THERMAL_SETTINGS_V2.xml' path='doc/member[@name="NV_GPU_THERMAL_SETTINGS_V2.count"]/*' />
        [NativeTypeName("NvU32")]
        public uint count;

        /// <include file='NV_GPU_THERMAL_SETTINGS_V2.xml' path='doc/member[@name="NV_GPU_THERMAL_SETTINGS_V2.sensor"]/*' />
        [NativeTypeName("struct (anonymous struct at ./../nvapi/nvapi.h:5266:5)[3]")]
        public _sensor_e__FixedBuffer sensor;

        /// <include file='_sensor_e__Struct.xml' path='doc/member[@name="_sensor_e__Struct"]/*' />
        public partial struct _sensor_e__Struct
        {
            /// <include file='_sensor_e__Struct.xml' path='doc/member[@name="_sensor_e__Struct.controller"]/*' />
            public NV_THERMAL_CONTROLLER controller;

            /// <include file='_sensor_e__Struct.xml' path='doc/member[@name="_sensor_e__Struct.defaultMinTemp"]/*' />
            [NativeTypeName("NvS32")]
            public int defaultMinTemp;

            /// <include file='_sensor_e__Struct.xml' path='doc/member[@name="_sensor_e__Struct.defaultMaxTemp"]/*' />
            [NativeTypeName("NvS32")]
            public int defaultMaxTemp;

            /// <include file='_sensor_e__Struct.xml' path='doc/member[@name="_sensor_e__Struct.currentTemp"]/*' />
            [NativeTypeName("NvS32")]
            public int currentTemp;

            /// <include file='_sensor_e__Struct.xml' path='doc/member[@name="_sensor_e__Struct.target"]/*' />
            public NV_THERMAL_TARGET target;
        }

        /// <include file='_sensor_e__FixedBuffer.xml' path='doc/member[@name="_sensor_e__FixedBuffer"]/*' />
        [InlineArray(3)]
        public partial struct _sensor_e__FixedBuffer
        {
            public _sensor_e__Struct e0;
        }
    }
}
