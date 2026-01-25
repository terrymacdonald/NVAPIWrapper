using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <include file='NV_EVENT_REGISTER_CALLBACK.xml' path='doc/member[@name="NV_EVENT_REGISTER_CALLBACK"]/*' />
    public unsafe partial struct NV_EVENT_REGISTER_CALLBACK
    {
        /// <include file='NV_EVENT_REGISTER_CALLBACK.xml' path='doc/member[@name="NV_EVENT_REGISTER_CALLBACK.version"]/*' />
        [NativeTypeName("NvU32")]
        public uint version;

        /// <include file='NV_EVENT_REGISTER_CALLBACK.xml' path='doc/member[@name="NV_EVENT_REGISTER_CALLBACK.eventId"]/*' />
        public NV_EVENT_TYPE eventId;

        /// <include file='NV_EVENT_REGISTER_CALLBACK.xml' path='doc/member[@name="NV_EVENT_REGISTER_CALLBACK.callbackParam"]/*' />
        public void* callbackParam;

        /// <include file='NV_EVENT_REGISTER_CALLBACK.xml' path='doc/member[@name="NV_EVENT_REGISTER_CALLBACK.nvCallBackFunc"]/*' />
        [NativeTypeName("__AnonymousRecord_nvapi_L3690_C5")]
        public _nvCallBackFunc_e__Union nvCallBackFunc;

        /// <include file='_nvCallBackFunc_e__Union.xml' path='doc/member[@name="_nvCallBackFunc_e__Union"]/*' />
        [StructLayout(LayoutKind.Explicit)]
        public unsafe partial struct _nvCallBackFunc_e__Union
        {
            /// <include file='_nvCallBackFunc_e__Union.xml' path='doc/member[@name="_nvCallBackFunc_e__Union.nvQSYNCEventCallback"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NVAPI_CALLBACK_QSYNCEVENT")]
            public delegate* unmanaged[Cdecl]<NV_QSYNC_EVENT_DATA, void*, void> nvQSYNCEventCallback;

            /// <include file='_nvCallBackFunc_e__Union.xml' path='doc/member[@name="_nvCallBackFunc_e__Union.nvDisplayOutputModeChangeEventCallback"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NVAPI_CALLBACK_DISPLAY_OUTPUT_MODE_CHANGE_EVENT")]
            public delegate* unmanaged[Cdecl]<_NV_DISPLAY_OUTPUT_MODE_CHANGE_EVENT_DATA*, void*, void> nvDisplayOutputModeChangeEventCallback;

            /// <include file='_nvCallBackFunc_e__Union.xml' path='doc/member[@name="_nvCallBackFunc_e__Union.nvDisplayColorimetryChangeEventCallback"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("NVAPI_CALLBACK_DISPLAY_COLORIMETRY_CHANGE_EVENT")]
            public delegate* unmanaged[Cdecl]<_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA*, void*, void> nvDisplayColorimetryChangeEventCallback;
        }
    }
}
