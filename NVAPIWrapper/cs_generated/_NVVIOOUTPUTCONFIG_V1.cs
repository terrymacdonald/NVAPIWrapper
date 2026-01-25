using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    /// <include file='_NVVIOOUTPUTCONFIG_V1.xml' path='doc/member[@name="_NVVIOOUTPUTCONFIG_V1"]/*' />
    public partial struct _NVVIOOUTPUTCONFIG_V1
    {
        /// <include file='_NVVIOOUTPUTCONFIG_V1.xml' path='doc/member[@name="_NVVIOOUTPUTCONFIG_V1.signalFormat"]/*' />
        [NativeTypeName("NVVIOSIGNALFORMAT")]
        public _NVVIOSIGNALFORMAT signalFormat;

        /// <include file='_NVVIOOUTPUTCONFIG_V1.xml' path='doc/member[@name="_NVVIOOUTPUTCONFIG_V1.dataFormat"]/*' />
        [NativeTypeName("NVVIODATAFORMAT")]
        public _NVVIODATAFORMAT dataFormat;

        /// <include file='_NVVIOOUTPUTCONFIG_V1.xml' path='doc/member[@name="_NVVIOOUTPUTCONFIG_V1.outputRegion"]/*' />
        [NativeTypeName("NVVIOOUTPUTREGION")]
        public _NVVIOOUTPUTREGION outputRegion;

        /// <include file='_NVVIOOUTPUTCONFIG_V1.xml' path='doc/member[@name="_NVVIOOUTPUTCONFIG_V1.outputArea"]/*' />
        [NativeTypeName("NVVIOOUTPUTAREA")]
        public _NVVIOOUTPUTAREA outputArea;

        /// <include file='_NVVIOOUTPUTCONFIG_V1.xml' path='doc/member[@name="_NVVIOOUTPUTCONFIG_V1.colorConversion"]/*' />
        [NativeTypeName("NVVIOCOLORCONVERSION")]
        public _NVVIOCOLORCONVERSION colorConversion;

        /// <include file='_NVVIOOUTPUTCONFIG_V1.xml' path='doc/member[@name="_NVVIOOUTPUTCONFIG_V1.gammaCorrection"]/*' />
        [NativeTypeName("NVVIOGAMMACORRECTION")]
        public _NVVIOGAMMACORRECTION gammaCorrection;

        /// <include file='_NVVIOOUTPUTCONFIG_V1.xml' path='doc/member[@name="_NVVIOOUTPUTCONFIG_V1.syncEnable"]/*' />
        [NativeTypeName("NvU32")]
        public uint syncEnable;

        /// <include file='_NVVIOOUTPUTCONFIG_V1.xml' path='doc/member[@name="_NVVIOOUTPUTCONFIG_V1.syncSource"]/*' />
        [NativeTypeName("NVVIOSYNCSOURCE")]
        public _NVVIOSYNCSOURCE syncSource;

        /// <include file='_NVVIOOUTPUTCONFIG_V1.xml' path='doc/member[@name="_NVVIOOUTPUTCONFIG_V1.syncDelay"]/*' />
        [NativeTypeName("NVVIOSYNCDELAY")]
        public _NVVIOSYNCDELAY syncDelay;

        /// <include file='_NVVIOOUTPUTCONFIG_V1.xml' path='doc/member[@name="_NVVIOOUTPUTCONFIG_V1.compositeSyncType"]/*' />
        [NativeTypeName("NVVIOCOMPSYNCTYPE")]
        public _NVVIOCOMPSYNCTYPE compositeSyncType;

        /// <include file='_NVVIOOUTPUTCONFIG_V1.xml' path='doc/member[@name="_NVVIOOUTPUTCONFIG_V1.frameLockEnable"]/*' />
        [NativeTypeName("NvU32")]
        public uint frameLockEnable;

        /// <include file='_NVVIOOUTPUTCONFIG_V1.xml' path='doc/member[@name="_NVVIOOUTPUTCONFIG_V1.psfSignalFormat"]/*' />
        [NativeTypeName("NvU32")]
        public uint psfSignalFormat;

        /// <include file='_NVVIOOUTPUTCONFIG_V1.xml' path='doc/member[@name="_NVVIOOUTPUTCONFIG_V1.enable422Filter"]/*' />
        [NativeTypeName("NvU32")]
        public uint enable422Filter;

        /// <include file='_NVVIOOUTPUTCONFIG_V1.xml' path='doc/member[@name="_NVVIOOUTPUTCONFIG_V1.compositeTerminate"]/*' />
        [NativeTypeName("NvU32")]
        public uint compositeTerminate;

        /// <include file='_NVVIOOUTPUTCONFIG_V1.xml' path='doc/member[@name="_NVVIOOUTPUTCONFIG_V1.enableDataIntegrityCheck"]/*' />
        [NativeTypeName("NvU32")]
        public uint enableDataIntegrityCheck;

        /// <include file='_NVVIOOUTPUTCONFIG_V1.xml' path='doc/member[@name="_NVVIOOUTPUTCONFIG_V1.cscOverride"]/*' />
        [NativeTypeName("NvU32")]
        public uint cscOverride;

        /// <include file='_NVVIOOUTPUTCONFIG_V1.xml' path='doc/member[@name="_NVVIOOUTPUTCONFIG_V1.flipQueueLength"]/*' />
        [NativeTypeName("NvU32")]
        public uint flipQueueLength;

        /// <include file='_NVVIOOUTPUTCONFIG_V1.xml' path='doc/member[@name="_NVVIOOUTPUTCONFIG_V1.enableANCTimeCodeGeneration"]/*' />
        [NativeTypeName("NvU32")]
        public uint enableANCTimeCodeGeneration;

        /// <include file='_NVVIOOUTPUTCONFIG_V1.xml' path='doc/member[@name="_NVVIOOUTPUTCONFIG_V1.enableComposite"]/*' />
        [NativeTypeName("NvU32")]
        public uint enableComposite;

        /// <include file='_NVVIOOUTPUTCONFIG_V1.xml' path='doc/member[@name="_NVVIOOUTPUTCONFIG_V1.enableAlphaKeyComposite"]/*' />
        [NativeTypeName("NvU32")]
        public uint enableAlphaKeyComposite;

        /// <include file='_NVVIOOUTPUTCONFIG_V1.xml' path='doc/member[@name="_NVVIOOUTPUTCONFIG_V1.compRange"]/*' />
        [NativeTypeName("NVVIOCOMPOSITERANGE")]
        public _NVVIOCOMPOSITERANGE compRange;

        /// <include file='_NVVIOOUTPUTCONFIG_V1.xml' path='doc/member[@name="_NVVIOOUTPUTCONFIG_V1.reservedData"]/*' />
        [NativeTypeName("NvU8[256]")]
        public _reservedData_e__FixedBuffer reservedData;

        /// <include file='_NVVIOOUTPUTCONFIG_V1.xml' path='doc/member[@name="_NVVIOOUTPUTCONFIG_V1.enableFullColorRange"]/*' />
        [NativeTypeName("NvU32")]
        public uint enableFullColorRange;

        /// <include file='_NVVIOOUTPUTCONFIG_V1.xml' path='doc/member[@name="_NVVIOOUTPUTCONFIG_V1.enableRGBData"]/*' />
        [NativeTypeName("NvU32")]
        public uint enableRGBData;

        /// <include file='_reservedData_e__FixedBuffer.xml' path='doc/member[@name="_reservedData_e__FixedBuffer"]/*' />
        [InlineArray(256)]
        public partial struct _reservedData_e__FixedBuffer
        {
            public byte e0;
        }
    }
}
