using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='NV_GPU_THERMAL_SETTINGS_V1.xml' path='doc/member[@name="NV_GPU_THERMAL_SETTINGS_V1"]/*' />
    public partial struct NV_GPU_THERMAL_SETTINGS_V1
    {
        /// <include file='NV_GPU_THERMAL_SETTINGS_V1.xml' path='doc/member[@name="NV_GPU_THERMAL_SETTINGS_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_GPU_THERMAL_SETTINGS_V1.xml' path='doc/member[@name="NV_GPU_THERMAL_SETTINGS_V1.count"]/*' />
        [NativeTypeName("NvU32")]
        public uint count;

        /// <include file='NV_GPU_THERMAL_SETTINGS_V1.xml' path='doc/member[@name="NV_GPU_THERMAL_SETTINGS_V1.sensor"]/*' />
        [NativeTypeName("struct (anonymous struct at ./../nvapi/nvapi.h:5250:5)[3]")]
        public _sensor_e__FixedBuffer sensor;

        /// <include file='_sensor_e__Struct.xml' path='doc/member[@name="_sensor_e__Struct"]/*' />
        public partial struct _sensor_e__Struct
        {
            /// <include file='_sensor_e__Struct.xml' path='doc/member[@name="_sensor_e__Struct.controller"]/*' />
            public NV_THERMAL_CONTROLLER controller;

            /// <include file='_sensor_e__Struct.xml' path='doc/member[@name="_sensor_e__Struct.defaultMinTemp"]/*' />
            [NativeTypeName("NvU32")]
            public uint defaultMinTemp;

            /// <include file='_sensor_e__Struct.xml' path='doc/member[@name="_sensor_e__Struct.defaultMaxTemp"]/*' />
            [NativeTypeName("NvU32")]
            public uint defaultMaxTemp;

            /// <include file='_sensor_e__Struct.xml' path='doc/member[@name="_sensor_e__Struct.currentTemp"]/*' />
            [NativeTypeName("NvU32")]
            public uint currentTemp;

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
