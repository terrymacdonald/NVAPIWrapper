using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <include file='_NVDRS_SETTING_VALUES.xml' path='doc/member[@name="_NVDRS_SETTING_VALUES"]/*' />
    public partial struct _NVDRS_SETTING_VALUES
    {
        /// <include file='_NVDRS_SETTING_VALUES.xml' path='doc/member[@name="_NVDRS_SETTING_VALUES.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NVDRS_SETTING_VALUES.xml' path='doc/member[@name="_NVDRS_SETTING_VALUES.numSettingValues"]/*' />
        [NativeTypeName("NvU32")]
        public uint numSettingValues;

        /// <include file='_NVDRS_SETTING_VALUES.xml' path='doc/member[@name="_NVDRS_SETTING_VALUES.settingType"]/*' />
        [NativeTypeName("NVDRS_SETTING_TYPE")]
        public _NVDRS_SETTING_TYPE settingType;

        /// <include file='_NVDRS_SETTING_VALUES.xml' path='doc/member[@name="_NVDRS_SETTING_VALUES.Anonymous"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L23944_C6")]
        public _Anonymous_e__Union Anonymous;

        /// <include file='_NVDRS_SETTING_VALUES.xml' path='doc/member[@name="_NVDRS_SETTING_VALUES.settingValues"]/*' />
        [NativeTypeName("union (anonymous union at ./../nvapi/nvapi.h:23951:6)[100]")]
        public _settingValues_e__FixedBuffer settingValues;

        /// <include file='_Anonymous_e__Union.xml' path='doc/member[@name="_Anonymous_e__Union.u32DefaultValue"]/*' />
        [UnscopedRef]
        public ref uint u32DefaultValue
        {
            get
            {
                return ref Anonymous.u32DefaultValue;
            }
        }

        /// <include file='_Anonymous_e__Union.xml' path='doc/member[@name="_Anonymous_e__Union.binaryDefaultValue"]/*' />
        [UnscopedRef]
        public ref _NVDRS_BINARY_SETTING binaryDefaultValue
        {
            get
            {
                return ref Anonymous.binaryDefaultValue;
            }
        }

        /// <include file='_Anonymous_e__Union.xml' path='doc/member[@name="_Anonymous_e__Union.wszDefaultValue"]/*' />
        [UnscopedRef]
        public Span<ushort> wszDefaultValue
        {
            get
            {
                return Anonymous.wszDefaultValue;
            }
        }

        /// <include file='_Anonymous_e__Union.xml' path='doc/member[@name="_Anonymous_e__Union"]/*' />
        [StructLayout(LayoutKind.Explicit)]
        public partial struct _Anonymous_e__Union
        {
            /// <include file='_Anonymous_e__Union.xml' path='doc/member[@name="_Anonymous_e__Union.u32DefaultValue"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NvU32")]
            public uint u32DefaultValue;

            /// <include file='_Anonymous_e__Union.xml' path='doc/member[@name="_Anonymous_e__Union.binaryDefaultValue"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NVDRS_BINARY_SETTING")]
            public _NVDRS_BINARY_SETTING binaryDefaultValue;

            /// <include file='_Anonymous_e__Union.xml' path='doc/member[@name="_Anonymous_e__Union.wszDefaultValue"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NvAPI_UnicodeString")]
            public _wszDefaultValue_e__FixedBuffer wszDefaultValue;

            /// <include file='_wszDefaultValue_e__FixedBuffer.xml' path='doc/member[@name="_wszDefaultValue_e__FixedBuffer"]/*' />
            [InlineArray(2048)]
            public partial struct _wszDefaultValue_e__FixedBuffer
            {
                public ushort e0;
            }
        }

        /// <include file='_settingValues_e__Union.xml' path='doc/member[@name="_settingValues_e__Union"]/*' />
        [StructLayout(LayoutKind.Explicit)]
        public partial struct _settingValues_e__Union
        {
            /// <include file='_settingValues_e__Union.xml' path='doc/member[@name="_settingValues_e__Union.u32Value"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NvU32")]
            public uint u32Value;

            /// <include file='_settingValues_e__Union.xml' path='doc/member[@name="_settingValues_e__Union.binaryValue"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NVDRS_BINARY_SETTING")]
            public _NVDRS_BINARY_SETTING binaryValue;

            /// <include file='_settingValues_e__Union.xml' path='doc/member[@name="_settingValues_e__Union.wszValue"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NvAPI_UnicodeString")]
            public _wszValue_e__FixedBuffer wszValue;

            /// <include file='_wszValue_e__FixedBuffer.xml' path='doc/member[@name="_wszValue_e__FixedBuffer"]/*' />
            [InlineArray(2048)]
            public partial struct _wszValue_e__FixedBuffer
            {
                public ushort e0;
            }
        }

        /// <include file='_settingValues_e__FixedBuffer.xml' path='doc/member[@name="_settingValues_e__FixedBuffer"]/*' />
        [InlineArray(100)]
        public partial struct _settingValues_e__FixedBuffer
        {
            public _settingValues_e__Union e0;
        }
    }
}
