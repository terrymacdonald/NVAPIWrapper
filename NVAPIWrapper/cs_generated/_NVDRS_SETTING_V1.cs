using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <include file='_NVDRS_SETTING_V1.xml' path='doc/member[@name="_NVDRS_SETTING_V1"]/*' />
    public partial struct _NVDRS_SETTING_V1
    {
        /// <include file='_NVDRS_SETTING_V1.xml' path='doc/member[@name="_NVDRS_SETTING_V1.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='_NVDRS_SETTING_V1.xml' path='doc/member[@name="_NVDRS_SETTING_V1.settingName"]/*' />
        [NativeTypeName("NvAPI_UnicodeString")]
        public _settingName_e__FixedBuffer settingName;

        /// <include file='_NVDRS_SETTING_V1.xml' path='doc/member[@name="_NVDRS_SETTING_V1.settingId"]/*' />
        [NativeTypeName("NvU32")]
        public uint settingId;

        /// <include file='_NVDRS_SETTING_V1.xml' path='doc/member[@name="_NVDRS_SETTING_V1.settingType"]/*' />
        [NativeTypeName("NVDRS_SETTING_TYPE")]
        public _NVDRS_SETTING_TYPE settingType;

        /// <include file='_NVDRS_SETTING_V1.xml' path='doc/member[@name="_NVDRS_SETTING_V1.settingLocation"]/*' />
        [NativeTypeName("NVDRS_SETTING_LOCATION")]
        public _NVDRS_SETTING_LOCATION settingLocation;

        /// <include file='_NVDRS_SETTING_V1.xml' path='doc/member[@name="_NVDRS_SETTING_V1.isCurrentPredefined"]/*' />
        [NativeTypeName("NvU32")]
        public uint isCurrentPredefined;

        /// <include file='_NVDRS_SETTING_V1.xml' path='doc/member[@name="_NVDRS_SETTING_V1.isPredefinedValid"]/*' />
        [NativeTypeName("NvU32")]
        public uint isPredefinedValid;

        /// <include file='_NVDRS_SETTING_V1.xml' path='doc/member[@name="_NVDRS_SETTING_V1.Anonymous1"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L23972_C6")]
        public _Anonymous1_e__Union Anonymous1;

        /// <include file='_NVDRS_SETTING_V1.xml' path='doc/member[@name="_NVDRS_SETTING_V1.Anonymous2"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L23980_C6")]
        public _Anonymous2_e__Union Anonymous2;

        /// <include file='_Anonymous1_e__Union.xml' path='doc/member[@name="_Anonymous1_e__Union.u32PredefinedValue"]/*' />
        [UnscopedRef]
        public ref uint u32PredefinedValue
        {
            get
            {
                return ref Anonymous1.u32PredefinedValue;
            }
        }

        /// <include file='_Anonymous1_e__Union.xml' path='doc/member[@name="_Anonymous1_e__Union.binaryPredefinedValue"]/*' />
        [UnscopedRef]
        public ref _NVDRS_BINARY_SETTING binaryPredefinedValue
        {
            get
            {
                return ref Anonymous1.binaryPredefinedValue;
            }
        }

        /// <include file='_Anonymous1_e__Union.xml' path='doc/member[@name="_Anonymous1_e__Union.wszPredefinedValue"]/*' />
        [UnscopedRef]
        public Span<ushort> wszPredefinedValue
        {
            get
            {
                return Anonymous1.wszPredefinedValue;
            }
        }

        /// <include file='_Anonymous2_e__Union.xml' path='doc/member[@name="_Anonymous2_e__Union.u32CurrentValue"]/*' />
        [UnscopedRef]
        public ref uint u32CurrentValue
        {
            get
            {
                return ref Anonymous2.u32CurrentValue;
            }
        }

        /// <include file='_Anonymous2_e__Union.xml' path='doc/member[@name="_Anonymous2_e__Union.binaryCurrentValue"]/*' />
        [UnscopedRef]
        public ref _NVDRS_BINARY_SETTING binaryCurrentValue
        {
            get
            {
                return ref Anonymous2.binaryCurrentValue;
            }
        }

        /// <include file='_Anonymous2_e__Union.xml' path='doc/member[@name="_Anonymous2_e__Union.wszCurrentValue"]/*' />
        [UnscopedRef]
        public Span<ushort> wszCurrentValue
        {
            get
            {
                return Anonymous2.wszCurrentValue;
            }
        }

        /// <include file='_Anonymous1_e__Union.xml' path='doc/member[@name="_Anonymous1_e__Union"]/*' />
        [StructLayout(LayoutKind.Explicit)]
        public partial struct _Anonymous1_e__Union
        {
            /// <include file='_Anonymous1_e__Union.xml' path='doc/member[@name="_Anonymous1_e__Union.u32PredefinedValue"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NvU32")]
            public uint u32PredefinedValue;

            /// <include file='_Anonymous1_e__Union.xml' path='doc/member[@name="_Anonymous1_e__Union.binaryPredefinedValue"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NVDRS_BINARY_SETTING")]
            public _NVDRS_BINARY_SETTING binaryPredefinedValue;

            /// <include file='_Anonymous1_e__Union.xml' path='doc/member[@name="_Anonymous1_e__Union.wszPredefinedValue"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NvAPI_UnicodeString")]
            public _wszPredefinedValue_e__FixedBuffer wszPredefinedValue;

            /// <include file='_wszPredefinedValue_e__FixedBuffer.xml' path='doc/member[@name="_wszPredefinedValue_e__FixedBuffer"]/*' />
            [InlineArray(2048)]
            public partial struct _wszPredefinedValue_e__FixedBuffer
            {
                public ushort e0;
            }
        }

        /// <include file='_Anonymous2_e__Union.xml' path='doc/member[@name="_Anonymous2_e__Union"]/*' />
        [StructLayout(LayoutKind.Explicit)]
        public partial struct _Anonymous2_e__Union
        {
            /// <include file='_Anonymous2_e__Union.xml' path='doc/member[@name="_Anonymous2_e__Union.u32CurrentValue"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NvU32")]
            public uint u32CurrentValue;

            /// <include file='_Anonymous2_e__Union.xml' path='doc/member[@name="_Anonymous2_e__Union.binaryCurrentValue"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NVDRS_BINARY_SETTING")]
            public _NVDRS_BINARY_SETTING binaryCurrentValue;

            /// <include file='_Anonymous2_e__Union.xml' path='doc/member[@name="_Anonymous2_e__Union.wszCurrentValue"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NvAPI_UnicodeString")]
            public _wszCurrentValue_e__FixedBuffer wszCurrentValue;

            /// <include file='_wszCurrentValue_e__FixedBuffer.xml' path='doc/member[@name="_wszCurrentValue_e__FixedBuffer"]/*' />
            [InlineArray(2048)]
            public partial struct _wszCurrentValue_e__FixedBuffer
            {
                public ushort e0;
            }
        }

        /// <include file='_settingName_e__FixedBuffer.xml' path='doc/member[@name="_settingName_e__FixedBuffer"]/*' />
        [InlineArray(2048)]
        public partial struct _settingName_e__FixedBuffer
        {
            public ushort e0;
        }
    }
}
