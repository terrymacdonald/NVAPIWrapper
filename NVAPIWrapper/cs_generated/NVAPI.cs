using System;
using System.Runtime.InteropServices;
using static NVAPIWrapper._NvAPI_Status;

namespace NVAPIWrapper
{
    public static unsafe partial class NVAPI
    {
        [NativeTypeName("const NVDX_SwapChainHandle")]
        public static readonly NVDX_SwapChainHandle__* NVDX_SWAPCHAIN_NONE = null;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_SYS_GetDriverAndBranchVersion"]/*' />
        public static delegate* unmanaged[Cdecl]<uint*, sbyte*, _NvAPI_Status> NvAPI_SYS_GetDriverAndBranchVersion;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetMemoryInfo"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 520. Instead, use NvAPI_GPU_GetMemoryInfoEx.")]
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, NV_DISPLAY_DRIVER_MEMORY_INFO_V3*, _NvAPI_Status> NvAPI_GPU_GetMemoryInfo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetMemoryInfoEx"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, NV_GPU_MEMORY_INFO_EX_V1*, _NvAPI_Status> NvAPI_GPU_GetMemoryInfoEx;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_EnumPhysicalGPUs"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__**, uint*, _NvAPI_Status> NvAPI_EnumPhysicalGPUs;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_GetGDIPrimaryDisplayId"]/*' />
        public static delegate* unmanaged[Cdecl]<uint*, _NvAPI_Status> NvAPI_DISP_GetGDIPrimaryDisplayId;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Mosaic_GetDisplayViewportsByResolution"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, uint, uint, _NV_RECT*, byte*, _NvAPI_Status> NvAPI_Mosaic_GetDisplayViewportsByResolution;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_Enable"]/*' />
        public static delegate* unmanaged[Cdecl]<_NvAPI_Status> NvAPI_Stereo_Enable;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_Disable"]/*' />
        public static delegate* unmanaged[Cdecl]<_NvAPI_Status> NvAPI_Stereo_Disable;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_IsEnabled"]/*' />
        public static delegate* unmanaged[Cdecl]<byte*, _NvAPI_Status> NvAPI_Stereo_IsEnabled;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_DestroyHandle"]/*' />
        public static delegate* unmanaged[Cdecl]<void*, _NvAPI_Status> NvAPI_Stereo_DestroyHandle;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_Activate"]/*' />
        public static delegate* unmanaged[Cdecl]<void*, _NvAPI_Status> NvAPI_Stereo_Activate;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_Deactivate"]/*' />
        public static delegate* unmanaged[Cdecl]<void*, _NvAPI_Status> NvAPI_Stereo_Deactivate;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_IsActivated"]/*' />
        public static delegate* unmanaged[Cdecl]<void*, byte*, _NvAPI_Status> NvAPI_Stereo_IsActivated;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_GetSeparation"]/*' />
        public static delegate* unmanaged[Cdecl]<void*, float*, _NvAPI_Status> NvAPI_Stereo_GetSeparation;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_SetSeparation"]/*' />
        public static delegate* unmanaged[Cdecl]<void*, float, _NvAPI_Status> NvAPI_Stereo_SetSeparation;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_GetConvergence"]/*' />
        public static delegate* unmanaged[Cdecl]<void*, float*, _NvAPI_Status> NvAPI_Stereo_GetConvergence;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_SetConvergence"]/*' />
        public static delegate* unmanaged[Cdecl]<void*, float, _NvAPI_Status> NvAPI_Stereo_SetConvergence;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_SetActiveEye"]/*' />
        public static delegate* unmanaged[Cdecl]<void*, _NV_StereoActiveEye, _NvAPI_Status> NvAPI_Stereo_SetActiveEye;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_SetDriverMode"]/*' />
        public static delegate* unmanaged[Cdecl]<_NV_StereoDriverMode, _NvAPI_Status> NvAPI_Stereo_SetDriverMode;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_GetEyeSeparation"]/*' />
        public static delegate* unmanaged[Cdecl]<void*, float*, _NvAPI_Status> NvAPI_Stereo_GetEyeSeparation;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_IsWindowedModeSupported"]/*' />
        public static delegate* unmanaged[Cdecl]<byte*, _NvAPI_Status> NvAPI_Stereo_IsWindowedModeSupported;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_SetSurfaceCreationMode"]/*' />
        public static delegate* unmanaged[Cdecl]<void*, _NVAPI_STEREO_SURFACECREATEMODE, _NvAPI_Status> NvAPI_Stereo_SetSurfaceCreationMode;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_GetSurfaceCreationMode"]/*' />
        public static delegate* unmanaged[Cdecl]<void*, _NVAPI_STEREO_SURFACECREATEMODE*, _NvAPI_Status> NvAPI_Stereo_GetSurfaceCreationMode;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_Debug_WasLastDrawStereoized"]/*' />
        public static delegate* unmanaged[Cdecl]<void*, byte*, _NvAPI_Status> NvAPI_Stereo_Debug_WasLastDrawStereoized;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_SetDefaultProfile"]/*' />
        public static delegate* unmanaged[Cdecl]<sbyte*, _NvAPI_Status> NvAPI_Stereo_SetDefaultProfile;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_GetDefaultProfile"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, sbyte*, uint*, _NvAPI_Status> NvAPI_Stereo_GetDefaultProfile;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Initialize"]/*' />
        public static delegate* unmanaged[Cdecl]<_NvAPI_Status> NvAPI_Initialize;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Unload"]/*' />
        public static delegate* unmanaged[Cdecl]<_NvAPI_Status> NvAPI_Unload;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetErrorMessage"]/*' />
        public static delegate* unmanaged[Cdecl]<_NvAPI_Status, sbyte*, _NvAPI_Status> NvAPI_GetErrorMessage;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetInterfaceVersionString"]/*' />
        public static delegate* unmanaged[Cdecl]<sbyte*, _NvAPI_Status> NvAPI_GetInterfaceVersionString;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetInterfaceVersionStringEx"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GetInterfaceVersionStringEx([NativeTypeName("NvAPI_ShortString")] sbyte* szDesc);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetEDID"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint, NV_EDID_V3*, _NvAPI_Status> NvAPI_GPU_GetEDID;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_SetView"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_DISP_SetDisplayConfig.")]
        public static delegate* unmanaged[Cdecl]<NvDisplayHandle__*, NV_VIEW_TARGET_INFO*, _NV_TARGET_VIEW_MODE, _NvAPI_Status> NvAPI_SetView;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_SetViewEx"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_DISP_SetDisplayConfig.")]
        public static delegate* unmanaged[Cdecl]<NvDisplayHandle__*, NV_DISPLAY_PATH_INFO*, _NV_TARGET_VIEW_MODE, _NvAPI_Status> NvAPI_SetViewEx;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetDisplayDriverVersion"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_SYS_GetDriverAndBranchVersion.")]
        public static delegate* unmanaged[Cdecl]<NvDisplayHandle__*, NV_DISPLAY_DRIVER_VERSION*, _NvAPI_Status> NvAPI_GetDisplayDriverVersion;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_OGL_ExpertModeSet"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, uint, uint, delegate* unmanaged[Cdecl]<uint, uint, uint, int, sbyte*, void>, _NvAPI_Status> NvAPI_OGL_ExpertModeSet;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_OGL_ExpertModeGet"]/*' />
        public static delegate* unmanaged[Cdecl]<uint*, uint*, uint*, delegate* unmanaged[Cdecl]<uint, uint, uint, int, sbyte*, void>*, _NvAPI_Status> NvAPI_OGL_ExpertModeGet;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_OGL_ExpertModeDefaultsSet"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, uint, uint, _NvAPI_Status> NvAPI_OGL_ExpertModeDefaultsSet;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_OGL_ExpertModeDefaultsGet"]/*' />
        public static delegate* unmanaged[Cdecl]<uint*, uint*, uint*, _NvAPI_Status> NvAPI_OGL_ExpertModeDefaultsGet;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_EnumTCCPhysicalGPUs"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__**, uint*, _NvAPI_Status> NvAPI_EnumTCCPhysicalGPUs;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_EnumLogicalGPUs"]/*' />
        public static delegate* unmanaged[Cdecl]<NvLogicalGpuHandle__**, uint*, _NvAPI_Status> NvAPI_EnumLogicalGPUs;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetPhysicalGPUsFromDisplay"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDisplayHandle__*, NvPhysicalGpuHandle__**, uint*, _NvAPI_Status> NvAPI_GetPhysicalGPUsFromDisplay;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetPhysicalGPUFromUnAttachedDisplay"]/*' />
        public static delegate* unmanaged[Cdecl]<NvUnAttachedDisplayHandle__*, NvPhysicalGpuHandle__**, _NvAPI_Status> NvAPI_GetPhysicalGPUFromUnAttachedDisplay;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetLogicalGPUFromDisplay"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDisplayHandle__*, NvLogicalGpuHandle__**, _NvAPI_Status> NvAPI_GetLogicalGPUFromDisplay;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetLogicalGPUFromPhysicalGPU"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, NvLogicalGpuHandle__**, _NvAPI_Status> NvAPI_GetLogicalGPUFromPhysicalGPU;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetPhysicalGPUsFromLogicalGPU"]/*' />
        public static delegate* unmanaged[Cdecl]<NvLogicalGpuHandle__*, NvPhysicalGpuHandle__**, uint*, _NvAPI_Status> NvAPI_GetPhysicalGPUsFromLogicalGPU;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetPhysicalGPUFromGPUID"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, NvPhysicalGpuHandle__**, _NvAPI_Status> NvAPI_GetPhysicalGPUFromGPUID;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetGPUIDfromPhysicalGPU"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint*, _NvAPI_Status> NvAPI_GetGPUIDfromPhysicalGPU;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetShaderSubPipeCount"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint*, _NvAPI_Status> NvAPI_GPU_GetShaderSubPipeCount;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetGpuCoreCount"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint*, _NvAPI_Status> NvAPI_GPU_GetGpuCoreCount;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetAllOutputs"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_GPU_GetAllDisplayIds.")]
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint*, _NvAPI_Status> NvAPI_GPU_GetAllOutputs;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetConnectedOutputs"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_GPU_GetConnectedDisplayIds.")]
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint*, _NvAPI_Status> NvAPI_GPU_GetConnectedOutputs;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetConnectedSLIOutputs"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_GPU_GetConnectedDisplayIds.")]
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint*, _NvAPI_Status> NvAPI_GPU_GetConnectedSLIOutputs;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetConnectedDisplayIds"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, _NV_GPU_DISPLAYIDS*, uint*, uint, _NvAPI_Status> NvAPI_GPU_GetConnectedDisplayIds;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetAllDisplayIds"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, _NV_GPU_DISPLAYIDS*, uint*, _NvAPI_Status> NvAPI_GPU_GetAllDisplayIds;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetConnectedOutputsWithLidState"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_GPU_GetConnectedDisplayIds.")]
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint*, _NvAPI_Status> NvAPI_GPU_GetConnectedOutputsWithLidState;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetConnectedSLIOutputsWithLidState"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_GPU_GetConnectedDisplayIds.")]
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint*, _NvAPI_Status> NvAPI_GPU_GetConnectedSLIOutputsWithLidState;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetSystemType"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, NV_SYSTEM_TYPE*, _NvAPI_Status> NvAPI_GPU_GetSystemType;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetActiveOutputs"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint*, _NvAPI_Status> NvAPI_GPU_GetActiveOutputs;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_SetEDID"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint, NV_EDID_V3*, _NvAPI_Status> NvAPI_GPU_SetEDID;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetOutputType"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint, _NV_GPU_OUTPUT_TYPE*, _NvAPI_Status> NvAPI_GPU_GetOutputType;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_ValidateOutputCombination"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint, _NvAPI_Status> NvAPI_GPU_ValidateOutputCombination;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetFullName"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, sbyte*, _NvAPI_Status> NvAPI_GPU_GetFullName;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetPCIIdentifiers"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint*, uint*, uint*, uint*, _NvAPI_Status> NvAPI_GPU_GetPCIIdentifiers;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetGPUType"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, _NV_GPU_TYPE*, _NvAPI_Status> NvAPI_GPU_GetGPUType;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetBusType"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, _NV_GPU_BUS_TYPE*, _NvAPI_Status> NvAPI_GPU_GetBusType;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetBusId"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint*, _NvAPI_Status> NvAPI_GPU_GetBusId;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetBusSlotId"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint*, _NvAPI_Status> NvAPI_GPU_GetBusSlotId;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetIRQ"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint*, _NvAPI_Status> NvAPI_GPU_GetIRQ;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetVbiosRevision"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint*, _NvAPI_Status> NvAPI_GPU_GetVbiosRevision;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetVbiosOEMRevision"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint*, _NvAPI_Status> NvAPI_GPU_GetVbiosOEMRevision;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetVbiosVersionString"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, sbyte*, _NvAPI_Status> NvAPI_GPU_GetVbiosVersionString;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetAGPAperture"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 455.")]
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint*, _NvAPI_Status> NvAPI_GPU_GetAGPAperture;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetCurrentAGPRate"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 455.")]
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint*, _NvAPI_Status> NvAPI_GPU_GetCurrentAGPRate;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetCurrentPCIEDownstreamWidth"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint*, _NvAPI_Status> NvAPI_GPU_GetCurrentPCIEDownstreamWidth;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetPhysicalFrameBufferSize"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint*, _NvAPI_Status> NvAPI_GPU_GetPhysicalFrameBufferSize;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetVirtualFrameBufferSize"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint*, _NvAPI_Status> NvAPI_GPU_GetVirtualFrameBufferSize;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetQuadroStatus"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 460.")]
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint*, _NvAPI_Status> NvAPI_GPU_GetQuadroStatus;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetBoardInfo"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, _NV_BOARD_INFO*, _NvAPI_Status> NvAPI_GPU_GetBoardInfo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetRamBusWidth"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint*, _NvAPI_Status> NvAPI_GPU_GetRamBusWidth;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetArchInfo"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, NV_GPU_ARCH_INFO_V2*, _NvAPI_Status> NvAPI_GPU_GetArchInfo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_I2CRead"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, NV_I2C_INFO_V3*, _NvAPI_Status> NvAPI_I2CRead;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_I2CWrite"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, NV_I2C_INFO_V3*, _NvAPI_Status> NvAPI_I2CWrite;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_WorkstationFeatureSetup"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint, uint, _NvAPI_Status> NvAPI_GPU_WorkstationFeatureSetup;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_WorkstationFeatureQuery"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint*, uint*, _NvAPI_Status> NvAPI_GPU_WorkstationFeatureQuery;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetHDCPSupportStatus"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, NV_GPU_GET_HDCP_SUPPORT_STATUS*, _NvAPI_Status> NvAPI_GPU_GetHDCPSupportStatus;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_CudaEnumComputeCapableGpus"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 319.")]
        public static delegate* unmanaged[Cdecl]<_NV_COMPUTE_GPU_TOPOLOGY_V2*, _NvAPI_Status> NvAPI_GPU_CudaEnumComputeCapableGpus;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetTachReading"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint*, _NvAPI_Status> NvAPI_GPU_GetTachReading;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetECCStatusInfo"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, NV_GPU_ECC_STATUS_INFO*, _NvAPI_Status> NvAPI_GPU_GetECCStatusInfo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetECCErrorInfo"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, NV_GPU_ECC_ERROR_INFO*, _NvAPI_Status> NvAPI_GPU_GetECCErrorInfo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_ResetECCErrorInfo"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, byte, byte, _NvAPI_Status> NvAPI_GPU_ResetECCErrorInfo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetECCConfigurationInfo"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, NV_GPU_ECC_CONFIGURATION_INFO*, _NvAPI_Status> NvAPI_GPU_GetECCConfigurationInfo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_SetECCConfiguration"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, byte, byte, _NvAPI_Status> NvAPI_GPU_SetECCConfiguration;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_QueryWorkstationFeatureSupport"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, _NV_GPU_WORKSTATION_FEATURE_TYPE, _NvAPI_Status> NvAPI_GPU_QueryWorkstationFeatureSupport;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_SetScanoutIntensity"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, NV_SCANOUT_INTENSITY_DATA_V2*, int*, _NvAPI_Status> NvAPI_GPU_SetScanoutIntensity;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetScanoutIntensityState"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_SCANOUT_INTENSITY_STATE_DATA*, _NvAPI_Status> NvAPI_GPU_GetScanoutIntensityState;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_SetScanoutWarping"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, NV_SCANOUT_WARPING_DATA*, int*, int*, _NvAPI_Status> NvAPI_GPU_SetScanoutWarping;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetScanoutWarpingState"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_SCANOUT_WARPING_STATE_DATA*, _NvAPI_Status> NvAPI_GPU_GetScanoutWarpingState;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_SetScanoutCompositionParameter"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, NV_GPU_SCANOUT_COMPOSITION_PARAMETER, NV_GPU_SCANOUT_COMPOSITION_PARAMETER_VALUE, float*, _NvAPI_Status> NvAPI_GPU_SetScanoutCompositionParameter;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetScanoutCompositionParameter"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, NV_GPU_SCANOUT_COMPOSITION_PARAMETER, NV_GPU_SCANOUT_COMPOSITION_PARAMETER_VALUE*, float*, _NvAPI_Status> NvAPI_GPU_GetScanoutCompositionParameter;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetScanoutConfiguration"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, NvSBox*, NvSBox*, _NvAPI_Status> NvAPI_GPU_GetScanoutConfiguration;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetScanoutConfigurationEx"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_SCANOUT_INFORMATION*, _NvAPI_Status> NvAPI_GPU_GetScanoutConfigurationEx;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetAdapterIdFromPhysicalGpu"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 520. Instead, use NvAPI_GPU_GetLogicalGpuInfo.")]
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, void*, _NvAPI_Status> NvAPI_GPU_GetAdapterIdFromPhysicalGpu;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetVirtualizationInfo"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, _NV_GPU_VIRTUALIZATION_INFO*, _NvAPI_Status> NvAPI_GPU_GetVirtualizationInfo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetLogicalGpuInfo"]/*' />
        public static delegate* unmanaged[Cdecl]<NvLogicalGpuHandle__*, _NV_LOGICAL_GPU_DATA_V1*, _NvAPI_Status> NvAPI_GPU_GetLogicalGpuInfo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetLicensableFeatures"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, _NV_LICENSABLE_FEATURES_V4*, _NvAPI_Status> NvAPI_GPU_GetLicensableFeatures;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetEncoderStatistics"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, _NV_ENCODER_STATISTICS_V1*, _NvAPI_Status> NvAPI_GPU_GetEncoderStatistics;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetEncoderSessionsInfo"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, _NV_ENCODER_SESSIONS_INFO_V1*, _NvAPI_Status> NvAPI_GPU_GetEncoderSessionsInfo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetGPUInfo"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, _NV_GPU_INFO_V2*, _NvAPI_Status> NvAPI_GPU_GetGPUInfo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetVRReadyData"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, _NV_GPU_VR_READY_V1*, _NvAPI_Status> NvAPI_GPU_GetVRReadyData;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetGspFeatures"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, _NV_GPU_GSP_INFO_V1*, _NvAPI_Status> NvAPI_GPU_GetGspFeatures;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetUUID"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, _NV_GPU_UUID_V1*, _NvAPI_Status> NvAPI_GPU_GetUUID;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_NVLINK_GetCaps"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, NVLINK_GET_CAPS_V1*, _NvAPI_Status> NvAPI_GPU_NVLINK_GetCaps;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_NVLINK_GetStatus"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, NVLINK_GET_STATUS_V2*, _NvAPI_Status> NvAPI_GPU_NVLINK_GetStatus;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetPerfDecreaseInfo"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint*, _NvAPI_Status> NvAPI_GPU_GetPerfDecreaseInfo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetPstatesInfoEx"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 304. Instead, use NvAPI_GPU_GetPstates20.")]
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, NV_GPU_PERF_PSTATES_INFO_V2*, uint, _NvAPI_Status> NvAPI_GPU_GetPstatesInfoEx;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetPstates20"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, _NV_GPU_PERF_PSTATES20_INFO_V2*, _NvAPI_Status> NvAPI_GPU_GetPstates20;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetCurrentPstate"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, _NV_GPU_PERF_PSTATE_ID*, _NvAPI_Status> NvAPI_GPU_GetCurrentPstate;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetDynamicPstatesInfoEx"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, NV_GPU_DYNAMIC_PSTATES_INFO_EX*, _NvAPI_Status> NvAPI_GPU_GetDynamicPstatesInfoEx;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetThermalSettings"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint, NV_GPU_THERMAL_SETTINGS_V2*, _NvAPI_Status> NvAPI_GPU_GetThermalSettings;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetAllClockFrequencies"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, NV_GPU_CLOCK_FREQUENCIES_V2*, _NvAPI_Status> NvAPI_GPU_GetAllClockFrequencies;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_QueryIlluminationSupport"]/*' />
        public static delegate* unmanaged[Cdecl]<_NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_V1*, _NvAPI_Status> NvAPI_GPU_QueryIlluminationSupport;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetIllumination"]/*' />
        public static delegate* unmanaged[Cdecl]<_NV_GPU_GET_ILLUMINATION_PARM_V1*, _NvAPI_Status> NvAPI_GPU_GetIllumination;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_SetIllumination"]/*' />
        public static delegate* unmanaged[Cdecl]<_NV_GPU_SET_ILLUMINATION_PARM_V1*, _NvAPI_Status> NvAPI_GPU_SetIllumination;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_ClientIllumDevicesGetInfo"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, _NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_V1*, _NvAPI_Status> NvAPI_GPU_ClientIllumDevicesGetInfo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_ClientIllumDevicesGetControl"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_V1*, _NvAPI_Status> NvAPI_GPU_ClientIllumDevicesGetControl;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_ClientIllumDevicesSetControl"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_V1*, _NvAPI_Status> NvAPI_GPU_ClientIllumDevicesSetControl;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_ClientIllumZonesGetInfo"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, _NV_GPU_CLIENT_ILLUM_ZONE_INFO_PARAMS_V1*, _NvAPI_Status> NvAPI_GPU_ClientIllumZonesGetInfo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_ClientIllumZonesGetControl"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1*, _NvAPI_Status> NvAPI_GPU_ClientIllumZonesGetControl;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_ClientIllumZonesSetControl"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1*, _NvAPI_Status> NvAPI_GPU_ClientIllumZonesSetControl;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Event_RegisterCallback"]/*' />
        public static delegate* unmanaged[Cdecl]<NV_EVENT_REGISTER_CALLBACK*, NvEventHandle__**, _NvAPI_Status> NvAPI_Event_RegisterCallback;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Event_UnregisterCallback"]/*' />
        public static delegate* unmanaged[Cdecl]<NvEventHandle__*, _NvAPI_Status> NvAPI_Event_UnregisterCallback;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_EnumNvidiaDisplayHandle"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, NvDisplayHandle__**, _NvAPI_Status> NvAPI_EnumNvidiaDisplayHandle;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_EnumNvidiaUnAttachedDisplayHandle"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, NvUnAttachedDisplayHandle__**, _NvAPI_Status> NvAPI_EnumNvidiaUnAttachedDisplayHandle;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_CreateDisplayFromUnAttachedDisplay"]/*' />
        public static delegate* unmanaged[Cdecl]<NvUnAttachedDisplayHandle__*, NvDisplayHandle__**, _NvAPI_Status> NvAPI_CreateDisplayFromUnAttachedDisplay;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetAssociatedNvidiaDisplayHandle"]/*' />
        public static delegate* unmanaged[Cdecl]<sbyte*, NvDisplayHandle__**, _NvAPI_Status> NvAPI_GetAssociatedNvidiaDisplayHandle;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_GetAssociatedUnAttachedNvidiaDisplayHandle"]/*' />
        public static delegate* unmanaged[Cdecl]<sbyte*, NvUnAttachedDisplayHandle__**, _NvAPI_Status> NvAPI_DISP_GetAssociatedUnAttachedNvidiaDisplayHandle;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetAssociatedNvidiaDisplayName"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDisplayHandle__*, sbyte*, _NvAPI_Status> NvAPI_GetAssociatedNvidiaDisplayName;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetUnAttachedAssociatedDisplayName"]/*' />
        public static delegate* unmanaged[Cdecl]<NvUnAttachedDisplayHandle__*, sbyte*, _NvAPI_Status> NvAPI_GetUnAttachedAssociatedDisplayName;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_EnableHWCursor"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDisplayHandle__*, _NvAPI_Status> NvAPI_EnableHWCursor;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DisableHWCursor"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDisplayHandle__*, _NvAPI_Status> NvAPI_DisableHWCursor;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetVBlankCounter"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDisplayHandle__*, uint*, _NvAPI_Status> NvAPI_GetVBlankCounter;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_SetRefreshRateOverride"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDisplayHandle__*, uint, float, uint, _NvAPI_Status> NvAPI_SetRefreshRateOverride;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetAssociatedDisplayOutputId"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDisplayHandle__*, uint*, _NvAPI_Status> NvAPI_GetAssociatedDisplayOutputId;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetDisplayPortInfo"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDisplayHandle__*, uint, _NV_DISPLAY_PORT_INFO_V1*, _NvAPI_Status> NvAPI_GetDisplayPortInfo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_SetDisplayPort"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDisplayHandle__*, uint, NV_DISPLAY_PORT_CONFIG*, _NvAPI_Status> NvAPI_SetDisplayPort;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetHDMISupportInfo"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDisplayHandle__*, uint, _NV_HDMI_SUPPORT_INFO_V2*, _NvAPI_Status> NvAPI_GetHDMISupportInfo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_InfoFrameControl"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, NV_INFOFRAME_DATA*, _NvAPI_Status> NvAPI_Disp_InfoFrameControl;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_ColorControl"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_COLOR_DATA_V5*, _NvAPI_Status> NvAPI_Disp_ColorControl;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_GetHdrCapabilities"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_HDR_CAPABILITIES_V3*, _NvAPI_Status> NvAPI_Disp_GetHdrCapabilities;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_HdrColorControl"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_HDR_COLOR_DATA_V2*, _NvAPI_Status> NvAPI_Disp_HdrColorControl;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_SetSourceColorSpace"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_COLORSPACE_TYPE, _NvAPI_Status> NvAPI_Disp_SetSourceColorSpace;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_GetSourceColorSpace"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_COLORSPACE_TYPE*, ulong, _NvAPI_Status> NvAPI_Disp_GetSourceColorSpace;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_SetSourceHdrMetadata"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_HDR_METADATA_V1*, _NvAPI_Status> NvAPI_Disp_SetSourceHdrMetadata;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_GetSourceHdrMetadata"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_HDR_METADATA_V1*, ulong, _NvAPI_Status> NvAPI_Disp_GetSourceHdrMetadata;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_SetOutputMode"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_DISPLAY_OUTPUT_MODE*, _NvAPI_Status> NvAPI_Disp_SetOutputMode;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_GetOutputMode"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_DISPLAY_OUTPUT_MODE*, _NvAPI_Status> NvAPI_Disp_GetOutputMode;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_SetHdrToneMapping"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_HDR_TONEMAPPING_METHOD, _NvAPI_Status> NvAPI_Disp_SetHdrToneMapping;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_GetHdrToneMapping"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_HDR_TONEMAPPING_METHOD*, _NvAPI_Status> NvAPI_Disp_GetHdrToneMapping;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_GetColorimetry"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_DISPLAY_COLORIMETRY_V1*, _NvAPI_Status> NvAPI_Disp_GetColorimetry;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_GetTiming"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_TIMING_INPUT*, _NV_TIMING*, _NvAPI_Status> NvAPI_DISP_GetTiming;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_GetMonitorCapabilities"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_MONITOR_CAPABILITIES_V1*, _NvAPI_Status> NvAPI_DISP_GetMonitorCapabilities;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_GetMonitorColorCapabilities"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_MONITOR_COLOR_DATA*, uint*, _NvAPI_Status> NvAPI_DISP_GetMonitorColorCapabilities;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_EnumCustomDisplay"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, uint, NV_CUSTOM_DISPLAY*, _NvAPI_Status> NvAPI_DISP_EnumCustomDisplay;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_TryCustomDisplay"]/*' />
        public static delegate* unmanaged[Cdecl]<uint*, uint, NV_CUSTOM_DISPLAY*, _NvAPI_Status> NvAPI_DISP_TryCustomDisplay;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_DeleteCustomDisplay"]/*' />
        public static delegate* unmanaged[Cdecl]<uint*, uint, NV_CUSTOM_DISPLAY*, _NvAPI_Status> NvAPI_DISP_DeleteCustomDisplay;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_SaveCustomDisplay"]/*' />
        public static delegate* unmanaged[Cdecl]<uint*, uint, uint, uint, _NvAPI_Status> NvAPI_DISP_SaveCustomDisplay;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_RevertCustomDisplayTrial"]/*' />
        public static delegate* unmanaged[Cdecl]<uint*, uint, _NvAPI_Status> NvAPI_DISP_RevertCustomDisplayTrial;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetView"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_DISP_GetDisplayConfig.")]
        public static delegate* unmanaged[Cdecl]<NvDisplayHandle__*, NV_VIEW_TARGET_INFO*, uint*, _NV_TARGET_VIEW_MODE*, _NvAPI_Status> NvAPI_GetView;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetViewEx"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_DISP_GetDisplayConfig.")]
        public static delegate* unmanaged[Cdecl]<NvDisplayHandle__*, NV_DISPLAY_PATH_INFO*, uint*, _NV_TARGET_VIEW_MODE*, _NvAPI_Status> NvAPI_GetViewEx;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetSupportedViews"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDisplayHandle__*, _NV_TARGET_VIEW_MODE*, uint*, _NvAPI_Status> NvAPI_GetSupportedViews;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_GetDisplayIdByDisplayName"]/*' />
        public static delegate* unmanaged[Cdecl]<sbyte*, uint*, _NvAPI_Status> NvAPI_DISP_GetDisplayIdByDisplayName;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_GetDisplayConfig"]/*' />
        public static delegate* unmanaged[Cdecl]<uint*, _NV_DISPLAYCONFIG_PATH_INFO*, _NvAPI_Status> NvAPI_DISP_GetDisplayConfig;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_SetDisplayConfig"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_DISPLAYCONFIG_PATH_INFO*, uint, _NvAPI_Status> NvAPI_DISP_SetDisplayConfig;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_GetEdidData"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_EDID_DATA_V2*, NV_EDID_FLAG*, _NvAPI_Status> NvAPI_DISP_GetEdidData;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_GetAdaptiveSyncData"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_GET_ADAPTIVE_SYNC_DATA_V1*, _NvAPI_Status> NvAPI_DISP_GetAdaptiveSyncData;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_SetAdaptiveSyncData"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_SET_ADAPTIVE_SYNC_DATA_V1*, _NvAPI_Status> NvAPI_DISP_SetAdaptiveSyncData;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_GetVirtualRefreshRateData"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_GET_VIRTUAL_REFRESH_RATE_DATA_V2*, _NvAPI_Status> NvAPI_DISP_GetVirtualRefreshRateData;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_SetVirtualRefreshRateData"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_SET_VIRTUAL_REFRESH_RATE_DATA_V2*, _NvAPI_Status> NvAPI_DISP_SetVirtualRefreshRateData;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_SetPreferredStereoDisplay"]/*' />
        public static delegate* unmanaged[Cdecl]<NV_SET_PREFERRED_STEREO_DISPLAY_V1*, _NvAPI_Status> NvAPI_DISP_SetPreferredStereoDisplay;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_GetPreferredStereoDisplay"]/*' />
        public static delegate* unmanaged[Cdecl]<NV_GET_PREFERRED_STEREO_DISPLAY_V1*, _NvAPI_Status> NvAPI_DISP_GetPreferredStereoDisplay;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_GetNvManagedDedicatedDisplays"]/*' />
        public static delegate* unmanaged[Cdecl]<uint*, _NV_MANAGED_DEDICATED_DISPLAY_INFO*, _NvAPI_Status> NvAPI_DISP_GetNvManagedDedicatedDisplays;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_AcquireDedicatedDisplay"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, ulong*, _NvAPI_Status> NvAPI_DISP_AcquireDedicatedDisplay;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_ReleaseDedicatedDisplay"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NvAPI_Status> NvAPI_DISP_ReleaseDedicatedDisplay;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_GetNvManagedDedicatedDisplayMetadata"]/*' />
        public static delegate* unmanaged[Cdecl]<_NV_MANAGED_DEDICATED_DISPLAY_METADATA*, _NvAPI_Status> NvAPI_DISP_GetNvManagedDedicatedDisplayMetadata;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_SetNvManagedDedicatedDisplayMetadata"]/*' />
        public static delegate* unmanaged[Cdecl]<_NV_MANAGED_DEDICATED_DISPLAY_METADATA*, _NvAPI_Status> NvAPI_DISP_SetNvManagedDedicatedDisplayMetadata;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_GetDisplayIdInfo"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_DISPLAY_ID_INFO_DATA_V1*, _NvAPI_Status> NvAPI_Disp_GetDisplayIdInfo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_GetDisplayIdsFromTarget"]/*' />
        public static delegate* unmanaged[Cdecl]<_NV_TARGET_INFO_DATA_V1*, _NvAPI_Status> NvAPI_Disp_GetDisplayIdsFromTarget;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_GetVRRInfo"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_GET_VRR_INFO_V1*, _NvAPI_Status> NvAPI_Disp_GetVRRInfo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Mosaic_GetSupportedTopoInfo"]/*' />
        public static delegate* unmanaged[Cdecl]<_NV_MOSAIC_SUPPORTED_TOPO_INFO_V2*, NV_MOSAIC_TOPO_TYPE, _NvAPI_Status> NvAPI_Mosaic_GetSupportedTopoInfo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Mosaic_GetTopoGroup"]/*' />
        public static delegate* unmanaged[Cdecl]<NV_MOSAIC_TOPO_BRIEF*, NV_MOSAIC_TOPO_GROUP*, _NvAPI_Status> NvAPI_Mosaic_GetTopoGroup;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Mosaic_GetOverlapLimits"]/*' />
        public static delegate* unmanaged[Cdecl]<NV_MOSAIC_TOPO_BRIEF*, NV_MOSAIC_DISPLAY_SETTING_V2*, int*, int*, int*, int*, _NvAPI_Status> NvAPI_Mosaic_GetOverlapLimits;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Mosaic_SetCurrentTopo"]/*' />
        public static delegate* unmanaged[Cdecl]<NV_MOSAIC_TOPO_BRIEF*, NV_MOSAIC_DISPLAY_SETTING_V2*, int, int, uint, _NvAPI_Status> NvAPI_Mosaic_SetCurrentTopo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Mosaic_GetCurrentTopo"]/*' />
        public static delegate* unmanaged[Cdecl]<NV_MOSAIC_TOPO_BRIEF*, NV_MOSAIC_DISPLAY_SETTING_V2*, int*, int*, _NvAPI_Status> NvAPI_Mosaic_GetCurrentTopo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Mosaic_EnableCurrentTopo"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NvAPI_Status> NvAPI_Mosaic_EnableCurrentTopo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Mosaic_SetDisplayGrids"]/*' />
        public static delegate* unmanaged[Cdecl]<_NV_MOSAIC_GRID_TOPO_V2*, uint, uint, _NvAPI_Status> NvAPI_Mosaic_SetDisplayGrids;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Mosaic_ValidateDisplayGrids"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_MOSAIC_GRID_TOPO_V2*, NV_MOSAIC_DISPLAY_TOPO_STATUS*, uint, _NvAPI_Status> NvAPI_Mosaic_ValidateDisplayGrids;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Mosaic_EnumDisplayModes"]/*' />
        public static delegate* unmanaged[Cdecl]<_NV_MOSAIC_GRID_TOPO_V2*, NV_MOSAIC_DISPLAY_SETTING_V2*, uint*, _NvAPI_Status> NvAPI_Mosaic_EnumDisplayModes;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Mosaic_EnumDisplayGrids"]/*' />
        public static delegate* unmanaged[Cdecl]<_NV_MOSAIC_GRID_TOPO_V2*, uint*, _NvAPI_Status> NvAPI_Mosaic_EnumDisplayGrids;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetSupportedMosaicTopologies"]/*' />
        public static delegate* unmanaged[Cdecl]<NV_MOSAIC_SUPPORTED_TOPOLOGIES*, _NvAPI_Status> NvAPI_GetSupportedMosaicTopologies;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetCurrentMosaicTopology"]/*' />
        public static delegate* unmanaged[Cdecl]<NV_MOSAIC_TOPOLOGY*, uint*, _NvAPI_Status> NvAPI_GetCurrentMosaicTopology;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_SetCurrentMosaicTopology"]/*' />
        public static delegate* unmanaged[Cdecl]<NV_MOSAIC_TOPOLOGY*, _NvAPI_Status> NvAPI_SetCurrentMosaicTopology;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_EnableCurrentMosaicTopology"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NvAPI_Status> NvAPI_EnableCurrentMosaicTopology;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GSync_EnumSyncDevices"]/*' />
        public static delegate* unmanaged[Cdecl]<NvGSyncDeviceHandle__**, uint*, _NvAPI_Status> NvAPI_GSync_EnumSyncDevices;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GSync_QueryCapabilities"]/*' />
        public static delegate* unmanaged[Cdecl]<NvGSyncDeviceHandle__*, _NV_GSYNC_CAPABILITIES_V3*, _NvAPI_Status> NvAPI_GSync_QueryCapabilities;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GSync_GetTopology"]/*' />
        public static delegate* unmanaged[Cdecl]<NvGSyncDeviceHandle__*, uint*, _NV_GSYNC_GPU*, uint*, _NV_GSYNC_DISPLAY*, _NvAPI_Status> NvAPI_GSync_GetTopology;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GSync_SetSyncStateSettings"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, _NV_GSYNC_DISPLAY*, uint, _NvAPI_Status> NvAPI_GSync_SetSyncStateSettings;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GSync_GetControlParameters"]/*' />
        public static delegate* unmanaged[Cdecl]<NvGSyncDeviceHandle__*, _NV_GSYNC_CONTROL_PARAMS_V2*, _NvAPI_Status> NvAPI_GSync_GetControlParameters;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GSync_SetControlParameters"]/*' />
        public static delegate* unmanaged[Cdecl]<NvGSyncDeviceHandle__*, _NV_GSYNC_CONTROL_PARAMS_V2*, _NvAPI_Status> NvAPI_GSync_SetControlParameters;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GSync_AdjustSyncDelay"]/*' />
        public static delegate* unmanaged[Cdecl]<NvGSyncDeviceHandle__*, _NVAPI_GSYNC_DELAY_TYPE, _NV_GSYNC_DELAY*, uint*, _NvAPI_Status> NvAPI_GSync_AdjustSyncDelay;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GSync_GetSyncStatus"]/*' />
        public static delegate* unmanaged[Cdecl]<NvGSyncDeviceHandle__*, NvPhysicalGpuHandle__*, _NV_GSYNC_STATUS*, _NvAPI_Status> NvAPI_GSync_GetSyncStatus;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GSync_GetStatusParameters"]/*' />
        public static delegate* unmanaged[Cdecl]<NvGSyncDeviceHandle__*, _NV_GSYNC_STATUS_PARAMS_V2*, _NvAPI_Status> NvAPI_GSync_GetStatusParameters;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DestroyPresentBarrierClient"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPresentBarrierClientHandle__*, _NvAPI_Status> NvAPI_DestroyPresentBarrierClient;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_JoinPresentBarrier"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPresentBarrierClientHandle__*, _NV_JOIN_PRESENT_BARRIER_PARAMS*, _NvAPI_Status> NvAPI_JoinPresentBarrier;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_LeavePresentBarrier"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPresentBarrierClientHandle__*, _NvAPI_Status> NvAPI_LeavePresentBarrier;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_QueryPresentBarrierFrameStatistics"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPresentBarrierClientHandle__*, _NV_PRESENT_BARRIER_FRAME_STATISTICS*, _NvAPI_Status> NvAPI_QueryPresentBarrierFrameStatistics;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_NGX_GetNGXOverrideState"]/*' />
        public static delegate* unmanaged[Cdecl]<_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1*, _NvAPI_Status> NvAPI_NGX_GetNGXOverrideState;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_NGX_SetNGXOverrideState"]/*' />
        public static delegate* unmanaged[Cdecl]<_NV_NGX_DLSS_OVERRIDE_SET_STATE_PARAMS_V1*, _NvAPI_Status> NvAPI_NGX_SetNGXOverrideState;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_GetCapabilities"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static delegate* unmanaged[Cdecl]<NvVioHandle__*, _NVVIOCAPS*, _NvAPI_Status> NvAPI_VIO_GetCapabilities;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_Open"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static delegate* unmanaged[Cdecl]<NvVioHandle__*, uint, _NVVIOOWNERTYPE, _NvAPI_Status> NvAPI_VIO_Open;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_Close"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static delegate* unmanaged[Cdecl]<NvVioHandle__*, uint, _NvAPI_Status> NvAPI_VIO_Close;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_Status"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static delegate* unmanaged[Cdecl]<NvVioHandle__*, _NVVIOSTATUS*, _NvAPI_Status> NvAPI_VIO_Status;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_SyncFormatDetect"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static delegate* unmanaged[Cdecl]<NvVioHandle__*, uint*, _NvAPI_Status> NvAPI_VIO_SyncFormatDetect;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_GetConfig"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static delegate* unmanaged[Cdecl]<NvVioHandle__*, _NVVIOCONFIG_V3*, _NvAPI_Status> NvAPI_VIO_GetConfig;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_SetConfig"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static delegate* unmanaged[Cdecl]<NvVioHandle__*, _NVVIOCONFIG_V3*, _NvAPI_Status> NvAPI_VIO_SetConfig;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_SetCSC"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_VIO_SetConfig.")]
        public static delegate* unmanaged[Cdecl]<NvVioHandle__*, _NVVIOCOLORCONVERSION*, _NvAPI_Status> NvAPI_VIO_SetCSC;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_GetCSC"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_VIO_GetConfig.")]
        public static delegate* unmanaged[Cdecl]<NvVioHandle__*, _NVVIOCOLORCONVERSION*, _NvAPI_Status> NvAPI_VIO_GetCSC;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_SetGamma"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_VIO_SetConfig.")]
        public static delegate* unmanaged[Cdecl]<NvVioHandle__*, _NVVIOGAMMACORRECTION*, _NvAPI_Status> NvAPI_VIO_SetGamma;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_GetGamma"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_VIO_GetConfig.")]
        public static delegate* unmanaged[Cdecl]<NvVioHandle__*, _NVVIOGAMMACORRECTION*, _NvAPI_Status> NvAPI_VIO_GetGamma;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_SetSyncDelay"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_VIO_SetConfig.")]
        public static delegate* unmanaged[Cdecl]<NvVioHandle__*, _NVVIOSYNCDELAY*, _NvAPI_Status> NvAPI_VIO_SetSyncDelay;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_GetSyncDelay"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_VIO_GetConfig.")]
        public static delegate* unmanaged[Cdecl]<NvVioHandle__*, _NVVIOSYNCDELAY*, _NvAPI_Status> NvAPI_VIO_GetSyncDelay;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_GetPCIInfo"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static delegate* unmanaged[Cdecl]<NvVioHandle__*, _NVVIOPCIINFO*, _NvAPI_Status> NvAPI_VIO_GetPCIInfo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_IsRunning"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static delegate* unmanaged[Cdecl]<NvVioHandle__*, _NvAPI_Status> NvAPI_VIO_IsRunning;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_Start"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static delegate* unmanaged[Cdecl]<NvVioHandle__*, _NvAPI_Status> NvAPI_VIO_Start;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_Stop"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static delegate* unmanaged[Cdecl]<NvVioHandle__*, _NvAPI_Status> NvAPI_VIO_Stop;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_IsFrameLockModeCompatible"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static delegate* unmanaged[Cdecl]<NvVioHandle__*, uint, uint, uint*, _NvAPI_Status> NvAPI_VIO_IsFrameLockModeCompatible;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_EnumDevices"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static delegate* unmanaged[Cdecl]<NvVioHandle__**, uint*, _NvAPI_Status> NvAPI_VIO_EnumDevices;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_QueryTopology"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static delegate* unmanaged[Cdecl]<_NV_VIO_TOPOLOGY*, _NvAPI_Status> NvAPI_VIO_QueryTopology;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_EnumSignalFormats"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static delegate* unmanaged[Cdecl]<NvVioHandle__*, uint, _NVVIOSIGNALFORMATDETAIL*, _NvAPI_Status> NvAPI_VIO_EnumSignalFormats;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_EnumDataFormats"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static delegate* unmanaged[Cdecl]<NvVioHandle__*, uint, _NVVIODATAFORMATDETAIL*, _NvAPI_Status> NvAPI_VIO_EnumDataFormats;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_CreateConfigurationProfileRegistryKey"]/*' />
        public static delegate* unmanaged[Cdecl]<_NV_StereoRegistryProfileType, _NvAPI_Status> NvAPI_Stereo_CreateConfigurationProfileRegistryKey;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_DeleteConfigurationProfileRegistryKey"]/*' />
        public static delegate* unmanaged[Cdecl]<_NV_StereoRegistryProfileType, _NvAPI_Status> NvAPI_Stereo_DeleteConfigurationProfileRegistryKey;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_SetConfigurationProfileValue"]/*' />
        public static delegate* unmanaged[Cdecl]<_NV_StereoRegistryProfileType, _NV_StereoRegistryID, void*, _NvAPI_Status> NvAPI_Stereo_SetConfigurationProfileValue;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_DeleteConfigurationProfileValue"]/*' />
        public static delegate* unmanaged[Cdecl]<_NV_StereoRegistryProfileType, _NV_StereoRegistryID, _NvAPI_Status> NvAPI_Stereo_DeleteConfigurationProfileValue;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_GetStereoSupport"]/*' />
        public static delegate* unmanaged[Cdecl]<NvMonitorHandle__*, _NVAPI_STEREO_CAPS*, _NvAPI_Status> NvAPI_Stereo_GetStereoSupport;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_DecreaseSeparation"]/*' />
        public static delegate* unmanaged[Cdecl]<void*, _NvAPI_Status> NvAPI_Stereo_DecreaseSeparation;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_IncreaseSeparation"]/*' />
        public static delegate* unmanaged[Cdecl]<void*, _NvAPI_Status> NvAPI_Stereo_IncreaseSeparation;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_DecreaseConvergence"]/*' />
        public static delegate* unmanaged[Cdecl]<void*, _NvAPI_Status> NvAPI_Stereo_DecreaseConvergence;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_IncreaseConvergence"]/*' />
        public static delegate* unmanaged[Cdecl]<void*, _NvAPI_Status> NvAPI_Stereo_IncreaseConvergence;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_GetFrustumAdjustMode"]/*' />
        public static delegate* unmanaged[Cdecl]<void*, _NV_FrustumAdjustMode*, _NvAPI_Status> NvAPI_Stereo_GetFrustumAdjustMode;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_SetFrustumAdjustMode"]/*' />
        public static delegate* unmanaged[Cdecl]<void*, _NV_FrustumAdjustMode, _NvAPI_Status> NvAPI_Stereo_SetFrustumAdjustMode;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_CaptureJpegImage"]/*' />
        public static delegate* unmanaged[Cdecl]<void*, uint, _NvAPI_Status> NvAPI_Stereo_CaptureJpegImage;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_InitActivation"]/*' />
        public static delegate* unmanaged[Cdecl]<void*, _NVAPI_STEREO_INIT_ACTIVATION_FLAGS, _NvAPI_Status> NvAPI_Stereo_InitActivation;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_Trigger_Activation"]/*' />
        public static delegate* unmanaged[Cdecl]<void*, _NvAPI_Status> NvAPI_Stereo_Trigger_Activation;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_CapturePngImage"]/*' />
        public static delegate* unmanaged[Cdecl]<void*, _NvAPI_Status> NvAPI_Stereo_CapturePngImage;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_ReverseStereoBlitControl"]/*' />
        public static delegate* unmanaged[Cdecl]<void*, byte, _NvAPI_Status> NvAPI_Stereo_ReverseStereoBlitControl;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_SetNotificationMessage"]/*' />
        public static delegate* unmanaged[Cdecl]<void*, ulong, ulong, _NvAPI_Status> NvAPI_Stereo_SetNotificationMessage;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Vulkan_InitLowLatencyDevice"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 565.")]
        public static delegate* unmanaged[Cdecl]<void*, void**, _NvAPI_Status> NvAPI_Vulkan_InitLowLatencyDevice;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Vulkan_DestroyLowLatencyDevice"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 565.")]
        public static delegate* unmanaged[Cdecl]<void*, _NvAPI_Status> NvAPI_Vulkan_DestroyLowLatencyDevice;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Vulkan_GetSleepStatus"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 565.")]
        public static delegate* unmanaged[Cdecl]<void*, _NV_VULKAN_GET_SLEEP_STATUS_PARAMS*, _NvAPI_Status> NvAPI_Vulkan_GetSleepStatus;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Vulkan_SetSleepMode"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 565.")]
        public static delegate* unmanaged[Cdecl]<void*, _NV_VULKAN_SET_SLEEP_MODE_PARAMS*, _NvAPI_Status> NvAPI_Vulkan_SetSleepMode;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Vulkan_Sleep"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 565.")]
        public static delegate* unmanaged[Cdecl]<void*, ulong, _NvAPI_Status> NvAPI_Vulkan_Sleep;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Vulkan_GetLatency"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 565.")]
        public static delegate* unmanaged[Cdecl]<void*, _NV_VULKAN_LATENCY_RESULT_PARAMS*, _NvAPI_Status> NvAPI_Vulkan_GetLatency;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Vulkan_SetLatencyMarker"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 565.")]
        public static delegate* unmanaged[Cdecl]<void*, _NV_VULKAN_LATENCY_MARKER_PARAMS*, _NvAPI_Status> NvAPI_Vulkan_SetLatencyMarker;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Vulkan_NotifyOutOfBandVkQueue"]/*' />
        [Obsolete("Do not use this function - it is deprecated in release 565.")]
        public static delegate* unmanaged[Cdecl]<void*, void*, NV_VULKAN_OUT_OF_BAND_QUEUE_TYPE, _NvAPI_Status> NvAPI_Vulkan_NotifyOutOfBandVkQueue;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_CreateSession"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__**, _NvAPI_Status> NvAPI_DRS_CreateSession;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_DestroySession"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, _NvAPI_Status> NvAPI_DRS_DestroySession;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_LoadSettings"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, _NvAPI_Status> NvAPI_DRS_LoadSettings;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_SaveSettings"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, _NvAPI_Status> NvAPI_DRS_SaveSettings;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_LoadSettingsFromFile"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, ushort*, _NvAPI_Status> NvAPI_DRS_LoadSettingsFromFile;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_SaveSettingsToFile"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, ushort*, _NvAPI_Status> NvAPI_DRS_SaveSettingsToFile;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_CreateProfile"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, _NVDRS_PROFILE_V1*, NvDRSProfileHandle__**, _NvAPI_Status> NvAPI_DRS_CreateProfile;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_DeleteProfile"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, NvDRSProfileHandle__*, _NvAPI_Status> NvAPI_DRS_DeleteProfile;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_SetCurrentGlobalProfile"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, ushort*, _NvAPI_Status> NvAPI_DRS_SetCurrentGlobalProfile;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_GetCurrentGlobalProfile"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, NvDRSProfileHandle__**, _NvAPI_Status> NvAPI_DRS_GetCurrentGlobalProfile;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_GetProfileInfo"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, NvDRSProfileHandle__*, _NVDRS_PROFILE_V1*, _NvAPI_Status> NvAPI_DRS_GetProfileInfo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_SetProfileInfo"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, NvDRSProfileHandle__*, _NVDRS_PROFILE_V1*, _NvAPI_Status> NvAPI_DRS_SetProfileInfo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_FindProfileByName"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, ushort*, NvDRSProfileHandle__**, _NvAPI_Status> NvAPI_DRS_FindProfileByName;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_EnumProfiles"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, uint, NvDRSProfileHandle__**, _NvAPI_Status> NvAPI_DRS_EnumProfiles;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_GetNumProfiles"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, uint*, _NvAPI_Status> NvAPI_DRS_GetNumProfiles;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_CreateApplication"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, NvDRSProfileHandle__*, _NVDRS_APPLICATION_V4*, _NvAPI_Status> NvAPI_DRS_CreateApplication;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_DeleteApplicationEx"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, NvDRSProfileHandle__*, _NVDRS_APPLICATION_V4*, _NvAPI_Status> NvAPI_DRS_DeleteApplicationEx;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_DeleteApplication"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, NvDRSProfileHandle__*, ushort*, _NvAPI_Status> NvAPI_DRS_DeleteApplication;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_GetApplicationInfo"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, NvDRSProfileHandle__*, ushort*, _NVDRS_APPLICATION_V4*, _NvAPI_Status> NvAPI_DRS_GetApplicationInfo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_EnumApplications"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, NvDRSProfileHandle__*, uint, uint*, _NVDRS_APPLICATION_V4*, _NvAPI_Status> NvAPI_DRS_EnumApplications;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_FindApplicationByName"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, ushort*, NvDRSProfileHandle__**, _NVDRS_APPLICATION_V4*, _NvAPI_Status> NvAPI_DRS_FindApplicationByName;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_SetSetting"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, NvDRSProfileHandle__*, _NVDRS_SETTING_V1*, _NvAPI_Status> NvAPI_DRS_SetSetting;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_GetSetting"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, NvDRSProfileHandle__*, uint, _NVDRS_SETTING_V1*, _NvAPI_Status> NvAPI_DRS_GetSetting;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_EnumSettings"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, NvDRSProfileHandle__*, uint, uint*, _NVDRS_SETTING_V1*, _NvAPI_Status> NvAPI_DRS_EnumSettings;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_EnumAvailableSettingIds"]/*' />
        public static delegate* unmanaged[Cdecl]<uint*, uint*, _NvAPI_Status> NvAPI_DRS_EnumAvailableSettingIds;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_EnumAvailableSettingValues"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, uint*, _NVDRS_SETTING_VALUES*, _NvAPI_Status> NvAPI_DRS_EnumAvailableSettingValues;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_GetSettingIdFromName"]/*' />
        public static delegate* unmanaged[Cdecl]<ushort*, uint*, _NvAPI_Status> NvAPI_DRS_GetSettingIdFromName;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_GetSettingNameFromId"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, ushort**, _NvAPI_Status> NvAPI_DRS_GetSettingNameFromId;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_DeleteProfileSetting"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, NvDRSProfileHandle__*, uint, _NvAPI_Status> NvAPI_DRS_DeleteProfileSetting;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_RestoreAllDefaults"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, _NvAPI_Status> NvAPI_DRS_RestoreAllDefaults;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_RestoreProfileDefault"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, NvDRSProfileHandle__*, _NvAPI_Status> NvAPI_DRS_RestoreProfileDefault;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_RestoreProfileDefaultSetting"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, NvDRSProfileHandle__*, uint, _NvAPI_Status> NvAPI_DRS_RestoreProfileDefaultSetting;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_GetBaseProfile"]/*' />
        public static delegate* unmanaged[Cdecl]<NvDRSSessionHandle__*, NvDRSProfileHandle__**, _NvAPI_Status> NvAPI_DRS_GetBaseProfile;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_SYS_GetChipSetInfo"]/*' />
        public static delegate* unmanaged[Cdecl]<NV_CHIPSET_INFO_v4*, _NvAPI_Status> NvAPI_SYS_GetChipSetInfo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_SYS_GetLidAndDockInfo"]/*' />
        public static delegate* unmanaged[Cdecl]<NV_LID_DOCK_PARAMS*, _NvAPI_Status> NvAPI_SYS_GetLidAndDockInfo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_SYS_GetDisplayIdFromGpuAndOutputId"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, uint, uint*, _NvAPI_Status> NvAPI_SYS_GetDisplayIdFromGpuAndOutputId;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_SYS_GetGpuAndOutputIdFromDisplayId"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, NvPhysicalGpuHandle__**, uint*, _NvAPI_Status> NvAPI_SYS_GetGpuAndOutputIdFromDisplayId;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_SYS_GetPhysicalGpuFromDisplayId"]/*' />
        public static delegate* unmanaged[Cdecl]<uint, NvPhysicalGpuHandle__**, _NvAPI_Status> NvAPI_SYS_GetPhysicalGpuFromDisplayId;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_SYS_GetDisplayDriverInfo"]/*' />
        public static delegate* unmanaged[Cdecl]<_NV_DISPLAY_DRIVER_INFO_V2*, _NvAPI_Status> NvAPI_SYS_GetDisplayDriverInfo;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_SYS_GetPhysicalGPUs"]/*' />
        public static delegate* unmanaged[Cdecl]<_NV_PHYSICAL_GPUS*, _NvAPI_Status> NvAPI_SYS_GetPhysicalGPUs;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_SYS_GetLogicalGPUs"]/*' />
        public static delegate* unmanaged[Cdecl]<_NV_LOGICAL_GPUS*, _NvAPI_Status> NvAPI_SYS_GetLogicalGPUs;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_NGX_GetDriverFeatureSupport"]/*' />
        public static delegate* unmanaged[Cdecl]<_NV_NGX_GET_DRIVER_FEATURE_SUPPORT_PARAMS_V1*, _NvAPI_Status> NvAPI_NGX_GetDriverFeatureSupport;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_ClientRegisterForUtilizationSampleUpdates"]/*' />
        public static delegate* unmanaged[Cdecl]<NvPhysicalGpuHandle__*, _NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS_V1*, _NvAPI_Status> NvAPI_GPU_ClientRegisterForUtilizationSampleUpdates;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_RegisterRiseCallback"]/*' />
        public static delegate* unmanaged[Cdecl]<_NV_RISE_CALLBACK_SETTINGS_V1*, _NvAPI_Status> NvAPI_RegisterRiseCallback;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_RequestRise"]/*' />
        public static delegate* unmanaged[Cdecl]<_NV_REQUEST_RISE_SETTINGS_V1*, _NvAPI_Status> NvAPI_RequestRise;

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_UninstallRise"]/*' />
        public static delegate* unmanaged[Cdecl]<_NV_UNINSTALL_RISE_SETTINGS_V1*, _NvAPI_Status> NvAPI_UninstallRise;

        [NativeTypeName("#define NV_U8_MAX (+255U)")]
        public const uint NV_U8_MAX = (+255U);

        [NativeTypeName("#define NV_U16_MAX (+65535U)")]
        public const uint NV_U16_MAX = (+65535U);

        [NativeTypeName("#define NV_S32_MAX (+2147483647)")]
        public const int NV_S32_MAX = (+2147483647);

        [NativeTypeName("#define NV_U32_MIN (0U)")]
        public const uint NV_U32_MIN = (0U);

        [NativeTypeName("#define NV_U32_MAX (+4294967295U)")]
        public const uint NV_U32_MAX = (+4294967295U);

        [NativeTypeName("#define NV_U64_MAX (+18446744073709551615ULL)")]
        public const ulong NV_U64_MAX = (+18446744073709551615UL);

        [NativeTypeName("#define NVAPI_USE_STDINT 0")]
        public const int NVAPI_USE_STDINT = 0;

        [NativeTypeName("#define NVAPI_SDK_VERSION 59596")]
        public const int NVAPI_SDK_VERSION = 59596;

        [NativeTypeName("#define NVAPI_DEFAULT_HANDLE 0")]
        public const int NVAPI_DEFAULT_HANDLE = 0;

        [NativeTypeName("#define NVAPI_GENERIC_STRING_MAX 4096")]
        public const int NVAPI_GENERIC_STRING_MAX = 4096;

        [NativeTypeName("#define NVAPI_LONG_STRING_MAX 256")]
        public const int NVAPI_LONG_STRING_MAX = 256;

        [NativeTypeName("#define NVAPI_SHORT_STRING_MAX 64")]
        public const int NVAPI_SHORT_STRING_MAX = 64;

        [NativeTypeName("#define NVAPI_MAX_PHYSICAL_GPUS 64")]
        public const int NVAPI_MAX_PHYSICAL_GPUS = 64;

        [NativeTypeName("#define NVAPI_MAX_PHYSICAL_BRIDGES 100")]
        public const int NVAPI_MAX_PHYSICAL_BRIDGES = 100;

        [NativeTypeName("#define NVAPI_PHYSICAL_GPUS 32")]
        public const int NVAPI_PHYSICAL_GPUS = 32;

        [NativeTypeName("#define NVAPI_MAX_LOGICAL_GPUS 64")]
        public const int NVAPI_MAX_LOGICAL_GPUS = 64;

        [NativeTypeName("#define NVAPI_MAX_AVAILABLE_GPU_TOPOLOGIES 256")]
        public const int NVAPI_MAX_AVAILABLE_GPU_TOPOLOGIES = 256;

        [NativeTypeName("#define NVAPI_MAX_AVAILABLE_SLI_GROUPS 256")]
        public const int NVAPI_MAX_AVAILABLE_SLI_GROUPS = 256;

        [NativeTypeName("#define NVAPI_MAX_GPU_TOPOLOGIES NVAPI_MAX_PHYSICAL_GPUS")]
        public const int NVAPI_MAX_GPU_TOPOLOGIES = 64;

        [NativeTypeName("#define NVAPI_MAX_GPU_PER_TOPOLOGY 8")]
        public const int NVAPI_MAX_GPU_PER_TOPOLOGY = 8;

        [NativeTypeName("#define NVAPI_MAX_DISPLAY_HEADS 2")]
        public const int NVAPI_MAX_DISPLAY_HEADS = 2;

        [NativeTypeName("#define NVAPI_ADVANCED_DISPLAY_HEADS 4")]
        public const int NVAPI_ADVANCED_DISPLAY_HEADS = 4;

        [NativeTypeName("#define NVAPI_MAX_DISPLAYS NVAPI_PHYSICAL_GPUS * NVAPI_ADVANCED_DISPLAY_HEADS")]
        public const int NVAPI_MAX_DISPLAYS = 32 * 4;

        [NativeTypeName("#define NVAPI_MAX_ACPI_IDS 16")]
        public const int NVAPI_MAX_ACPI_IDS = 16;

        [NativeTypeName("#define NVAPI_MAX_VIEW_MODES 8")]
        public const int NVAPI_MAX_VIEW_MODES = 8;

        [NativeTypeName("#define NVAPI_SYSTEM_MAX_HWBCS 128")]
        public const int NVAPI_SYSTEM_MAX_HWBCS = 128;

        [NativeTypeName("#define NVAPI_SYSTEM_HWBC_INVALID_ID 0xffffffff")]
        public const uint NVAPI_SYSTEM_HWBC_INVALID_ID = 0xffffffff;

        [NativeTypeName("#define NVAPI_UUID_LEN 16")]
        public const int NVAPI_UUID_LEN = 16;

        [NativeTypeName("#define NVAPI_SYSTEM_MAX_DISPLAYS NVAPI_MAX_PHYSICAL_GPUS * NV_MAX_HEADS")]
        public const int NVAPI_SYSTEM_MAX_DISPLAYS = 64 * 4;

        [NativeTypeName("#define NV_MAX_HEADS 4")]
        public const int NV_MAX_HEADS = 4;

        [NativeTypeName("#define NVAPI_MAX_HEADS_PER_GPU 32")]
        public const int NVAPI_MAX_HEADS_PER_GPU = 32;

        [NativeTypeName("#define NV_MAX_VID_STREAMS 4")]
        public const int NV_MAX_VID_STREAMS = 4;

        [NativeTypeName("#define NV_MAX_VID_STREAMS_EX 20")]
        public const int NV_MAX_VID_STREAMS_EX = 20;

        [NativeTypeName("#define NV_MAX_VID_PROFILES 4")]
        public const int NV_MAX_VID_PROFILES = 4;

        [NativeTypeName("#define NVAPI_MAX_AUDIO_DEVICES 16")]
        public const int NVAPI_MAX_AUDIO_DEVICES = 16;

        [NativeTypeName("#define NV_DISPLAY_DRIVER_MEMORY_INFO_VER_1 MAKE_NVAPI_VERSION(NV_DISPLAY_DRIVER_MEMORY_INFO_V1,1)")]
        public const uint NV_DISPLAY_DRIVER_MEMORY_INFO_VER_1 = (uint)(20 | ((1) << 16));

        [NativeTypeName("#define NV_DISPLAY_DRIVER_MEMORY_INFO_VER_2 MAKE_NVAPI_VERSION(NV_DISPLAY_DRIVER_MEMORY_INFO_V2,2)")]
        public const uint NV_DISPLAY_DRIVER_MEMORY_INFO_VER_2 = (uint)(24 | ((2) << 16));

        [NativeTypeName("#define NV_DISPLAY_DRIVER_MEMORY_INFO_VER_3 MAKE_NVAPI_VERSION(NV_DISPLAY_DRIVER_MEMORY_INFO_V3,3)")]
        public const uint NV_DISPLAY_DRIVER_MEMORY_INFO_VER_3 = (uint)(32 | ((3) << 16));

        [NativeTypeName("#define NV_DISPLAY_DRIVER_MEMORY_INFO_VER NV_DISPLAY_DRIVER_MEMORY_INFO_VER_3")]
        public const uint NV_DISPLAY_DRIVER_MEMORY_INFO_VER = (uint)(32 | ((3) << 16));

        [NativeTypeName("#define NV_GPU_MEMORY_INFO_EX_VER_1 MAKE_NVAPI_VERSION(NV_GPU_MEMORY_INFO_EX_V1,1)")]
        public const uint NV_GPU_MEMORY_INFO_EX_VER_1 = (uint)(80 | ((1) << 16));

        [NativeTypeName("#define NV_GPU_MEMORY_INFO_EX_VER NV_GPU_MEMORY_INFO_EX_VER_1")]
        public const uint NV_GPU_MEMORY_INFO_EX_VER = (uint)(80 | ((1) << 16));

        [NativeTypeName("#define NV_GET_CURRENT_SLI_STATE_VER1 MAKE_NVAPI_VERSION(NV_GET_CURRENT_SLI_STATE_V1,1)")]
        public const uint NV_GET_CURRENT_SLI_STATE_VER1 = (uint)(28 | ((1) << 16));

        [NativeTypeName("#define NV_GET_CURRENT_SLI_STATE_VER2 MAKE_NVAPI_VERSION(NV_GET_CURRENT_SLI_STATE_V2,1)")]
        public const uint NV_GET_CURRENT_SLI_STATE_VER2 = (uint)(32 | ((1) << 16));

        [NativeTypeName("#define NV_GET_CURRENT_SLI_STATE_VER NV_GET_CURRENT_SLI_STATE_VER2")]
        public const uint NV_GET_CURRENT_SLI_STATE_VER = (uint)(32 | ((1) << 16));

        [NativeTypeName("#define NV_MOSAIC_MAX_DISPLAYS (64)")]
        public const int NV_MOSAIC_MAX_DISPLAYS = (64);

        [NativeTypeName("#define NVAPI_API_NOT_INTIALIZED NVAPI_API_NOT_INITIALIZED")]
        public const _NvAPI_Status NVAPI_API_NOT_INTIALIZED = NVAPI_API_NOT_INITIALIZED;

        [NativeTypeName("#define NV_EDID_V1_DATA_SIZE 256")]
        public const int NV_EDID_V1_DATA_SIZE = 256;

        [NativeTypeName("#define NV_EDID_DATA_SIZE NV_EDID_V1_DATA_SIZE")]
        public const int NV_EDID_DATA_SIZE = 256;

        [NativeTypeName("#define NV_EDID_VER1 MAKE_NVAPI_VERSION(NV_EDID_V1,1)")]
        public const uint NV_EDID_VER1 = (uint)(260 | ((1) << 16));

        [NativeTypeName("#define NV_EDID_VER2 MAKE_NVAPI_VERSION(NV_EDID_V2,2)")]
        public const uint NV_EDID_VER2 = (uint)(264 | ((2) << 16));

        [NativeTypeName("#define NV_EDID_VER3 MAKE_NVAPI_VERSION(NV_EDID_V3,3)")]
        public const uint NV_EDID_VER3 = (uint)(272 | ((3) << 16));

        [NativeTypeName("#define NV_EDID_VER NV_EDID_VER3")]
        public const uint NV_EDID_VER = (uint)(272 | ((3) << 16));

        [NativeTypeName("#define NV_EDID_DATA_SIZE_MAX 1024")]
        public const int NV_EDID_DATA_SIZE_MAX = 1024;

        [NativeTypeName("#define NVAPI_MAX_VIEW_TARGET 2")]
        public const int NVAPI_MAX_VIEW_TARGET = 2;

        [NativeTypeName("#define NVAPI_ADVANCED_MAX_VIEW_TARGET 4")]
        public const int NVAPI_ADVANCED_MAX_VIEW_TARGET = 4;

        [NativeTypeName("#define NV_TIMING_H_SYNC_POSITIVE 0")]
        public const int NV_TIMING_H_SYNC_POSITIVE = 0;

        [NativeTypeName("#define NV_TIMING_H_SYNC_NEGATIVE 1")]
        public const int NV_TIMING_H_SYNC_NEGATIVE = 1;

        [NativeTypeName("#define NV_TIMING_H_SYNC_DEFAULT NV_TIMING_H_SYNC_NEGATIVE")]
        public const int NV_TIMING_H_SYNC_DEFAULT = 1;

        [NativeTypeName("#define NV_TIMING_V_SYNC_POSITIVE 0")]
        public const int NV_TIMING_V_SYNC_POSITIVE = 0;

        [NativeTypeName("#define NV_TIMING_V_SYNC_NEGATIVE 1")]
        public const int NV_TIMING_V_SYNC_NEGATIVE = 1;

        [NativeTypeName("#define NV_TIMING_V_SYNC_DEFAULT NV_TIMING_V_SYNC_POSITIVE")]
        public const int NV_TIMING_V_SYNC_DEFAULT = 0;

        [NativeTypeName("#define NV_TIMING_PROGRESSIVE 0")]
        public const int NV_TIMING_PROGRESSIVE = 0;

        [NativeTypeName("#define NV_TIMING_INTERLACED 1")]
        public const int NV_TIMING_INTERLACED = 1;

        [NativeTypeName("#define NV_TIMING_INTERLACED_EXTRA_VBLANK_ON_FIELD2 1")]
        public const int NV_TIMING_INTERLACED_EXTRA_VBLANK_ON_FIELD2 = 1;

        [NativeTypeName("#define NV_TIMING_INTERLACED_NO_EXTRA_VBLANK_ON_FIELD2 2")]
        public const int NV_TIMING_INTERLACED_NO_EXTRA_VBLANK_ON_FIELD2 = 2;

        [NativeTypeName("#define NV_VIEW_TARGET_INFO_VER MAKE_NVAPI_VERSION(NV_VIEW_TARGET_INFO,2)")]
        public const uint NV_VIEW_TARGET_INFO_VER = (uint)(32 | ((2) << 16));

        [NativeTypeName("#define NVAPI_MAX_DISPLAY_PATH NVAPI_MAX_VIEW_TARGET")]
        public const int NVAPI_MAX_DISPLAY_PATH = 2;

        [NativeTypeName("#define NVAPI_ADVANCED_MAX_DISPLAY_PATH NVAPI_ADVANCED_MAX_VIEW_TARGET")]
        public const int NVAPI_ADVANCED_MAX_DISPLAY_PATH = 4;

        [NativeTypeName("#define NV_DISPLAY_PATH_INFO_VER NV_DISPLAY_PATH_INFO_VER4")]
        public const uint NV_DISPLAY_PATH_INFO_VER = (uint)(232 | ((4) << 16));

        [NativeTypeName("#define NV_DISPLAY_PATH_INFO_VER4 MAKE_NVAPI_VERSION(NV_DISPLAY_PATH_INFO,4)")]
        public const uint NV_DISPLAY_PATH_INFO_VER4 = (uint)(232 | ((4) << 16));

        [NativeTypeName("#define NV_DISPLAY_PATH_INFO_VER3 MAKE_NVAPI_VERSION(NV_DISPLAY_PATH_INFO,3)")]
        public const uint NV_DISPLAY_PATH_INFO_VER3 = (uint)(232 | ((3) << 16));

        [NativeTypeName("#define NV_DISPLAY_PATH_INFO_VER2 MAKE_NVAPI_VERSION(NV_DISPLAY_PATH_INFO,2)")]
        public const uint NV_DISPLAY_PATH_INFO_VER2 = (uint)(232 | ((2) << 16));

        [NativeTypeName("#define NV_DISPLAY_PATH_INFO_VER1 MAKE_NVAPI_VERSION(NV_DISPLAY_PATH_INFO,1)")]
        public const uint NV_DISPLAY_PATH_INFO_VER1 = (uint)(232 | ((1) << 16));

        [NativeTypeName("#define NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_VER1 MAKE_NVAPI_VERSION(NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1,1)")]
        public const uint NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_VER1 = (uint)(128 | ((1) << 16));

        [NativeTypeName("#define NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_VER NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_VER1")]
        public const uint NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_VER = (uint)(128 | ((1) << 16));

        [NativeTypeName("#define NV_DISPLAYCONFIG_PATH_INFO_VER1 MAKE_NVAPI_VERSION(NV_DISPLAYCONFIG_PATH_INFO_V1,1)")]
        public static readonly uint NV_DISPLAYCONFIG_PATH_INFO_VER1 = unchecked((uint)(sizeof(_NV_DISPLAYCONFIG_PATH_INFO_V1) | ((1) << 16)));

        [NativeTypeName("#define NV_DISPLAYCONFIG_PATH_INFO_VER2 MAKE_NVAPI_VERSION(NV_DISPLAYCONFIG_PATH_INFO_V2,2)")]
        public static readonly uint NV_DISPLAYCONFIG_PATH_INFO_VER2 = unchecked((uint)(sizeof(_NV_DISPLAYCONFIG_PATH_INFO) | ((2) << 16)));

        [NativeTypeName("#define NV_DISPLAYCONFIG_PATH_INFO_VER NV_DISPLAYCONFIG_PATH_INFO_VER2")]
        public static readonly uint NV_DISPLAYCONFIG_PATH_INFO_VER = unchecked((uint)(sizeof(_NV_DISPLAYCONFIG_PATH_INFO) | ((2) << 16)));

        [NativeTypeName("#define NVAPI_UNICODE_STRING_MAX 2048")]
        public const int NVAPI_UNICODE_STRING_MAX = 2048;

        [NativeTypeName("#define NVAPI_BINARY_DATA_MAX 4096")]
        public const int NVAPI_BINARY_DATA_MAX = 4096;

        [NativeTypeName("#define NVAPI_MAX_GPU_CLOCKS 32")]
        public const int NVAPI_MAX_GPU_CLOCKS = 32;

        [NativeTypeName("#define NVAPI_MAX_GPU_PUBLIC_CLOCKS 32")]
        public const int NVAPI_MAX_GPU_PUBLIC_CLOCKS = 32;

        [NativeTypeName("#define NVAPI_MAX_GPU_PERF_CLOCKS 32")]
        public const int NVAPI_MAX_GPU_PERF_CLOCKS = 32;

        [NativeTypeName("#define NVAPI_MAX_GPU_PERF_VOLTAGES 16")]
        public const int NVAPI_MAX_GPU_PERF_VOLTAGES = 16;

        [NativeTypeName("#define NVAPI_MAX_GPU_PERF_PSTATES 16")]
        public const int NVAPI_MAX_GPU_PERF_PSTATES = 16;

        [NativeTypeName("#define NVAPI_MAX_GPU_PSTATE20_PSTATES 16")]
        public const int NVAPI_MAX_GPU_PSTATE20_PSTATES = 16;

        [NativeTypeName("#define NVAPI_MAX_GPU_PSTATE20_CLOCKS 8")]
        public const int NVAPI_MAX_GPU_PSTATE20_CLOCKS = 8;

        [NativeTypeName("#define NVAPI_MAX_GPU_PSTATE20_BASE_VOLTAGES 4")]
        public const int NVAPI_MAX_GPU_PSTATE20_BASE_VOLTAGES = 4;

        [NativeTypeName("#define NV_GPU_PERF_PSTATES20_INFO_VER1 MAKE_NVAPI_VERSION(NV_GPU_PERF_PSTATES20_INFO_V1,1)")]
        public const uint NV_GPU_PERF_PSTATES20_INFO_VER1 = (uint)(7316 | ((1) << 16));

        [NativeTypeName("#define NV_GPU_PERF_PSTATES20_INFO_VER2 MAKE_NVAPI_VERSION(NV_GPU_PERF_PSTATES20_INFO_V2,2)")]
        public const uint NV_GPU_PERF_PSTATES20_INFO_VER2 = (uint)(7416 | ((2) << 16));

        [NativeTypeName("#define NV_GPU_PERF_PSTATES20_INFO_VER3 MAKE_NVAPI_VERSION(NV_GPU_PERF_PSTATES20_INFO_V2,3)")]
        public const uint NV_GPU_PERF_PSTATES20_INFO_VER3 = (uint)(7416 | ((3) << 16));

        [NativeTypeName("#define NV_GPU_PERF_PSTATES20_INFO_VER NV_GPU_PERF_PSTATES20_INFO_VER3")]
        public const uint NV_GPU_PERF_PSTATES20_INFO_VER = (uint)(7416 | ((3) << 16));

        [NativeTypeName("#define NV_DISPLAY_DRIVER_VERSION_VER MAKE_NVAPI_VERSION(NV_DISPLAY_DRIVER_VERSION,1)")]
        public const uint NV_DISPLAY_DRIVER_VERSION_VER = (uint)(140 | ((1) << 16));

        [NativeTypeName("#define NVAPI_OGLEXPERT_DETAIL_NONE 0x00000000")]
        public const int NVAPI_OGLEXPERT_DETAIL_NONE = 0x00000000;

        [NativeTypeName("#define NVAPI_OGLEXPERT_DETAIL_ERROR 0x00000001")]
        public const int NVAPI_OGLEXPERT_DETAIL_ERROR = 0x00000001;

        [NativeTypeName("#define NVAPI_OGLEXPERT_DETAIL_SWFALLBACK 0x00000002")]
        public const int NVAPI_OGLEXPERT_DETAIL_SWFALLBACK = 0x00000002;

        [NativeTypeName("#define NVAPI_OGLEXPERT_DETAIL_BASIC_INFO 0x00000004")]
        public const int NVAPI_OGLEXPERT_DETAIL_BASIC_INFO = 0x00000004;

        [NativeTypeName("#define NVAPI_OGLEXPERT_DETAIL_DETAILED_INFO 0x00000008")]
        public const int NVAPI_OGLEXPERT_DETAIL_DETAILED_INFO = 0x00000008;

        [NativeTypeName("#define NVAPI_OGLEXPERT_DETAIL_PERFORMANCE_WARNING 0x00000010")]
        public const int NVAPI_OGLEXPERT_DETAIL_PERFORMANCE_WARNING = 0x00000010;

        [NativeTypeName("#define NVAPI_OGLEXPERT_DETAIL_QUALITY_WARNING 0x00000020")]
        public const int NVAPI_OGLEXPERT_DETAIL_QUALITY_WARNING = 0x00000020;

        [NativeTypeName("#define NVAPI_OGLEXPERT_DETAIL_USAGE_WARNING 0x00000040")]
        public const int NVAPI_OGLEXPERT_DETAIL_USAGE_WARNING = 0x00000040;

        [NativeTypeName("#define NVAPI_OGLEXPERT_DETAIL_ALL 0xFFFFFFFF")]
        public const uint NVAPI_OGLEXPERT_DETAIL_ALL = 0xFFFFFFFF;

        [NativeTypeName("#define NVAPI_OGLEXPERT_REPORT_NONE 0x00000000")]
        public const int NVAPI_OGLEXPERT_REPORT_NONE = 0x00000000;

        [NativeTypeName("#define NVAPI_OGLEXPERT_REPORT_ERROR 0x00000001")]
        public const int NVAPI_OGLEXPERT_REPORT_ERROR = 0x00000001;

        [NativeTypeName("#define NVAPI_OGLEXPERT_REPORT_SWFALLBACK 0x00000002")]
        public const int NVAPI_OGLEXPERT_REPORT_SWFALLBACK = 0x00000002;

        [NativeTypeName("#define NVAPI_OGLEXPERT_REPORT_PIPELINE_VERTEX 0x00000004")]
        public const int NVAPI_OGLEXPERT_REPORT_PIPELINE_VERTEX = 0x00000004;

        [NativeTypeName("#define NVAPI_OGLEXPERT_REPORT_PIPELINE_GEOMETRY 0x00000008")]
        public const int NVAPI_OGLEXPERT_REPORT_PIPELINE_GEOMETRY = 0x00000008;

        [NativeTypeName("#define NVAPI_OGLEXPERT_REPORT_PIPELINE_XFB 0x00000010")]
        public const int NVAPI_OGLEXPERT_REPORT_PIPELINE_XFB = 0x00000010;

        [NativeTypeName("#define NVAPI_OGLEXPERT_REPORT_PIPELINE_RASTER 0x00000020")]
        public const int NVAPI_OGLEXPERT_REPORT_PIPELINE_RASTER = 0x00000020;

        [NativeTypeName("#define NVAPI_OGLEXPERT_REPORT_PIPELINE_FRAGMENT 0x00000040")]
        public const int NVAPI_OGLEXPERT_REPORT_PIPELINE_FRAGMENT = 0x00000040;

        [NativeTypeName("#define NVAPI_OGLEXPERT_REPORT_PIPELINE_ROP 0x00000080")]
        public const int NVAPI_OGLEXPERT_REPORT_PIPELINE_ROP = 0x00000080;

        [NativeTypeName("#define NVAPI_OGLEXPERT_REPORT_PIPELINE_FRAMEBUFFER 0x00000100")]
        public const int NVAPI_OGLEXPERT_REPORT_PIPELINE_FRAMEBUFFER = 0x00000100;

        [NativeTypeName("#define NVAPI_OGLEXPERT_REPORT_PIPELINE_PIXEL 0x00000200")]
        public const int NVAPI_OGLEXPERT_REPORT_PIPELINE_PIXEL = 0x00000200;

        [NativeTypeName("#define NVAPI_OGLEXPERT_REPORT_PIPELINE_TEXTURE 0x00000400")]
        public const int NVAPI_OGLEXPERT_REPORT_PIPELINE_TEXTURE = 0x00000400;

        [NativeTypeName("#define NVAPI_OGLEXPERT_REPORT_OBJECT_BUFFEROBJECT 0x00000800")]
        public const int NVAPI_OGLEXPERT_REPORT_OBJECT_BUFFEROBJECT = 0x00000800;

        [NativeTypeName("#define NVAPI_OGLEXPERT_REPORT_OBJECT_TEXTURE 0x00001000")]
        public const int NVAPI_OGLEXPERT_REPORT_OBJECT_TEXTURE = 0x00001000;

        [NativeTypeName("#define NVAPI_OGLEXPERT_REPORT_OBJECT_PROGRAM 0x00002000")]
        public const int NVAPI_OGLEXPERT_REPORT_OBJECT_PROGRAM = 0x00002000;

        [NativeTypeName("#define NVAPI_OGLEXPERT_REPORT_OBJECT_FBO 0x00004000")]
        public const int NVAPI_OGLEXPERT_REPORT_OBJECT_FBO = 0x00004000;

        [NativeTypeName("#define NVAPI_OGLEXPERT_REPORT_FEATURE_SLI 0x00008000")]
        public const int NVAPI_OGLEXPERT_REPORT_FEATURE_SLI = 0x00008000;

        [NativeTypeName("#define NVAPI_OGLEXPERT_REPORT_ALL 0xFFFFFFFF")]
        public const uint NVAPI_OGLEXPERT_REPORT_ALL = 0xFFFFFFFF;

        [NativeTypeName("#define NVAPI_OGLEXPERT_OUTPUT_TO_NONE 0x00000000")]
        public const int NVAPI_OGLEXPERT_OUTPUT_TO_NONE = 0x00000000;

        [NativeTypeName("#define NVAPI_OGLEXPERT_OUTPUT_TO_CONSOLE 0x00000001")]
        public const int NVAPI_OGLEXPERT_OUTPUT_TO_CONSOLE = 0x00000001;

        [NativeTypeName("#define NVAPI_OGLEXPERT_OUTPUT_TO_DEBUGGER 0x00000004")]
        public const int NVAPI_OGLEXPERT_OUTPUT_TO_DEBUGGER = 0x00000004;

        [NativeTypeName("#define NVAPI_OGLEXPERT_OUTPUT_TO_CALLBACK 0x00000008")]
        public const int NVAPI_OGLEXPERT_OUTPUT_TO_CALLBACK = 0x00000008;

        [NativeTypeName("#define NVAPI_OGLEXPERT_OUTPUT_TO_ALL 0xFFFFFFFF")]
        public const uint NVAPI_OGLEXPERT_OUTPUT_TO_ALL = 0xFFFFFFFF;

        [NativeTypeName("#define NV_GPU_CONNECTED_IDS_FLAG_UNCACHED NV_BIT(0)")]
        public const int NV_GPU_CONNECTED_IDS_FLAG_UNCACHED = (1 << (0));

        [NativeTypeName("#define NV_GPU_CONNECTED_IDS_FLAG_SLI NV_BIT(1)")]
        public const int NV_GPU_CONNECTED_IDS_FLAG_SLI = (1 << (1));

        [NativeTypeName("#define NV_GPU_CONNECTED_IDS_FLAG_LIDSTATE NV_BIT(2)")]
        public const int NV_GPU_CONNECTED_IDS_FLAG_LIDSTATE = (1 << (2));

        [NativeTypeName("#define NV_GPU_CONNECTED_IDS_FLAG_FAKE NV_BIT(3)")]
        public const int NV_GPU_CONNECTED_IDS_FLAG_FAKE = (1 << (3));

        [NativeTypeName("#define NV_GPU_CONNECTED_IDS_FLAG_EXCLUDE_MST NV_BIT(4)")]
        public const int NV_GPU_CONNECTED_IDS_FLAG_EXCLUDE_MST = (1 << (4));

        [NativeTypeName("#define NV_GPU_DISPLAYIDS_VER1 MAKE_NVAPI_VERSION(NV_GPU_DISPLAYIDS,1)")]
        public const uint NV_GPU_DISPLAYIDS_VER1 = (uint)(16 | ((1) << 16));

        [NativeTypeName("#define NV_GPU_DISPLAYIDS_VER2 MAKE_NVAPI_VERSION(NV_GPU_DISPLAYIDS,3)")]
        public const uint NV_GPU_DISPLAYIDS_VER2 = (uint)(16 | ((3) << 16));

        [NativeTypeName("#define NV_GPU_DISPLAYIDS_VER NV_GPU_DISPLAYIDS_VER2")]
        public const uint NV_GPU_DISPLAYIDS_VER = (uint)(16 | ((3) << 16));

        [NativeTypeName("#define NV_BOARD_INFO_VER1 MAKE_NVAPI_VERSION(NV_BOARD_INFO_V1,1)")]
        public const uint NV_BOARD_INFO_VER1 = (uint)(20 | ((1) << 16));

        [NativeTypeName("#define NV_BOARD_INFO_VER NV_BOARD_INFO_VER1")]
        public const uint NV_BOARD_INFO_VER = (uint)(20 | ((1) << 16));

        [NativeTypeName("#define NV_GPU_ARCH_INFO_VER_1 MAKE_NVAPI_VERSION(NV_GPU_ARCH_INFO_V1,1)")]
        public const uint NV_GPU_ARCH_INFO_VER_1 = (uint)(16 | ((1) << 16));

        [NativeTypeName("#define NV_GPU_ARCH_INFO_VER_2 MAKE_NVAPI_VERSION(NV_GPU_ARCH_INFO_V2,2)")]
        public const uint NV_GPU_ARCH_INFO_VER_2 = (uint)(16 | ((2) << 16));

        [NativeTypeName("#define NV_GPU_ARCH_INFO_VER NV_GPU_ARCH_INFO_VER_2")]
        public const uint NV_GPU_ARCH_INFO_VER = (uint)(16 | ((2) << 16));

        [NativeTypeName("#define NVAPI_MAX_SIZEOF_I2C_DATA_BUFFER 4096")]
        public const int NVAPI_MAX_SIZEOF_I2C_DATA_BUFFER = 4096;

        [NativeTypeName("#define NVAPI_MAX_SIZEOF_I2C_REG_ADDRESS 4")]
        public const int NVAPI_MAX_SIZEOF_I2C_REG_ADDRESS = 4;

        [NativeTypeName("#define NVAPI_DISPLAY_DEVICE_MASK_MAX 24")]
        public const int NVAPI_DISPLAY_DEVICE_MASK_MAX = 24;

        [NativeTypeName("#define NVAPI_I2C_SPEED_DEPRECATED 0xFFFF")]
        public const int NVAPI_I2C_SPEED_DEPRECATED = 0xFFFF;

        [NativeTypeName("#define NV_I2C_INFO_VER3 MAKE_NVAPI_VERSION(NV_I2C_INFO_V3,3)")]
        public static readonly uint NV_I2C_INFO_VER3 = unchecked((uint)(sizeof(NV_I2C_INFO_V3) | ((3) << 16)));

        [NativeTypeName("#define NV_I2C_INFO_VER2 MAKE_NVAPI_VERSION(NV_I2C_INFO_V2,2)")]
        public static readonly uint NV_I2C_INFO_VER2 = unchecked((uint)(sizeof(NV_I2C_INFO_V2) | ((2) << 16)));

        [NativeTypeName("#define NV_I2C_INFO_VER1 MAKE_NVAPI_VERSION(NV_I2C_INFO_V1,1)")]
        public static readonly uint NV_I2C_INFO_VER1 = unchecked((uint)(sizeof(NV_I2C_INFO_V1) | ((1) << 16)));

        [NativeTypeName("#define NV_I2C_INFO_VER NV_I2C_INFO_VER3")]
        public static readonly uint NV_I2C_INFO_VER = unchecked((uint)(sizeof(NV_I2C_INFO_V3) | ((3) << 16)));

        [NativeTypeName("#define NV_GPU_GET_HDCP_SUPPORT_STATUS_VER MAKE_NVAPI_VERSION(NV_GPU_GET_HDCP_SUPPORT_STATUS,1)")]
        public const uint NV_GPU_GET_HDCP_SUPPORT_STATUS_VER = (uint)(16 | ((1) << 16));

        [NativeTypeName("#define NV_COMPUTE_GPU_TOPOLOGY_PHYSICS_CAPABLE NV_BIT(0)")]
        public const int NV_COMPUTE_GPU_TOPOLOGY_PHYSICS_CAPABLE = (1 << (0));

        [NativeTypeName("#define NV_COMPUTE_GPU_TOPOLOGY_PHYSICS_ENABLE NV_BIT(1)")]
        public const int NV_COMPUTE_GPU_TOPOLOGY_PHYSICS_ENABLE = (1 << (1));

        [NativeTypeName("#define NV_COMPUTE_GPU_TOPOLOGY_PHYSICS_DEDICATED NV_BIT(2)")]
        public const int NV_COMPUTE_GPU_TOPOLOGY_PHYSICS_DEDICATED = (1 << (2));

        [NativeTypeName("#define NV_COMPUTE_GPU_TOPOLOGY_PHYSICS_RECOMMENDED NV_BIT(3)")]
        public const int NV_COMPUTE_GPU_TOPOLOGY_PHYSICS_RECOMMENDED = (1 << (3));

        [NativeTypeName("#define NV_COMPUTE_GPU_TOPOLOGY_CUDA_AVAILABLE NV_BIT(4)")]
        public const int NV_COMPUTE_GPU_TOPOLOGY_CUDA_AVAILABLE = (1 << (4));

        [NativeTypeName("#define NV_COMPUTE_GPU_TOPOLOGY_CUDA_CAPABLE NV_BIT(16)")]
        public const int NV_COMPUTE_GPU_TOPOLOGY_CUDA_CAPABLE = (1 << (16));

        [NativeTypeName("#define NV_COMPUTE_GPU_TOPOLOGY_CUDA_DISABLED NV_BIT(17)")]
        public const int NV_COMPUTE_GPU_TOPOLOGY_CUDA_DISABLED = (1 << (17));

        [NativeTypeName("#define NV_COMPUTE_GPU_TOPOLOGY_PHYSICS_AVAILABLE NV_BIT(21)")]
        public const int NV_COMPUTE_GPU_TOPOLOGY_PHYSICS_AVAILABLE = (1 << (21));

        [NativeTypeName("#define NV_COMPUTE_GPU_TOPOLOGY_VER1 MAKE_NVAPI_VERSION(NV_COMPUTE_GPU_TOPOLOGY_V1,1)")]
        public static readonly uint NV_COMPUTE_GPU_TOPOLOGY_VER1 = unchecked((uint)(sizeof(NV_COMPUTE_GPU_TOPOLOGY_V1) | ((1) << 16)));

        [NativeTypeName("#define NV_COMPUTE_GPU_TOPOLOGY_VER MAKE_NVAPI_VERSION(NV_COMPUTE_GPU_TOPOLOGY_V2,2)")]
        public static readonly uint NV_COMPUTE_GPU_TOPOLOGY_VER = unchecked((uint)(sizeof(_NV_COMPUTE_GPU_TOPOLOGY_V2) | ((2) << 16)));

        [NativeTypeName("#define NV_GPU_ECC_STATUS_INFO_VER MAKE_NVAPI_VERSION(NV_GPU_ECC_STATUS_INFO,1)")]
        public const uint NV_GPU_ECC_STATUS_INFO_VER = (uint)(12 | ((1) << 16));

        [NativeTypeName("#define NV_GPU_ECC_ERROR_INFO_VER MAKE_NVAPI_VERSION(NV_GPU_ECC_ERROR_INFO,1)")]
        public const uint NV_GPU_ECC_ERROR_INFO_VER = (uint)(40 | ((1) << 16));

        [NativeTypeName("#define NV_GPU_ECC_CONFIGURATION_INFO_VER MAKE_NVAPI_VERSION(NV_GPU_ECC_CONFIGURATION_INFO,1)")]
        public const uint NV_GPU_ECC_CONFIGURATION_INFO_VER = (uint)(8 | ((1) << 16));

        [NativeTypeName("#define NV_EVENT_REGISTER_CALLBACK_VERSION MAKE_NVAPI_VERSION(NV_EVENT_REGISTER_CALLBACK,1)")]
        public static readonly uint NV_EVENT_REGISTER_CALLBACK_VERSION = unchecked((uint)(sizeof(NV_EVENT_REGISTER_CALLBACK) | ((1) << 16)));

        [NativeTypeName("#define NV_SCANOUT_INTENSITY_DATA_VER1 MAKE_NVAPI_VERSION(NV_SCANOUT_INTENSITY_DATA_V1, 1)")]
        public static readonly uint NV_SCANOUT_INTENSITY_DATA_VER1 = unchecked((uint)(sizeof(NV_SCANOUT_INTENSITY_DATA_V1) | ((1) << 16)));

        [NativeTypeName("#define NV_SCANOUT_INTENSITY_DATA_VER2 MAKE_NVAPI_VERSION(NV_SCANOUT_INTENSITY_DATA_V2, 2)")]
        public static readonly uint NV_SCANOUT_INTENSITY_DATA_VER2 = unchecked((uint)(sizeof(NV_SCANOUT_INTENSITY_DATA_V2) | ((2) << 16)));

        [NativeTypeName("#define NV_SCANOUT_INTENSITY_DATA_VER NV_SCANOUT_INTENSITY_DATA_VER2")]
        public static readonly uint NV_SCANOUT_INTENSITY_DATA_VER = unchecked((uint)(sizeof(NV_SCANOUT_INTENSITY_DATA_V2) | ((2) << 16)));

        [NativeTypeName("#define NV_SCANOUT_INTENSITY_STATE_VER MAKE_NVAPI_VERSION(NV_SCANOUT_INTENSITY_STATE_DATA, 1)")]
        public const uint NV_SCANOUT_INTENSITY_STATE_VER = (uint)(8 | ((1) << 16));

        [NativeTypeName("#define NV_SCANOUT_WARPING_VER MAKE_NVAPI_VERSION(NV_SCANOUT_WARPING_DATA, 1)")]
        public static readonly uint NV_SCANOUT_WARPING_VER = unchecked((uint)(sizeof(NV_SCANOUT_WARPING_DATA) | ((1) << 16)));

        [NativeTypeName("#define NV_SCANOUT_WARPING_STATE_VER MAKE_NVAPI_VERSION(NV_SCANOUT_WARPING_STATE_DATA, 1)")]
        public const uint NV_SCANOUT_WARPING_STATE_VER = (uint)(8 | ((1) << 16));

        [NativeTypeName("#define NV_SCANOUT_INFORMATION_VER MAKE_NVAPI_VERSION(NV_SCANOUT_INFORMATION,1)")]
        public const uint NV_SCANOUT_INFORMATION_VER = (uint)(68 | ((1) << 16));

        [NativeTypeName("#define NV_GPU_VIRTUALIZATION_INFO_VER1 MAKE_NVAPI_VERSION(NV_GPU_VIRTUALIZATION_INFO_V1,1)")]
        public const uint NV_GPU_VIRTUALIZATION_INFO_VER1 = (uint)(12 | ((1) << 16));

        [NativeTypeName("#define NV_GPU_VIRTUALIZATION_INFO_VER NV_GPU_VIRTUALIZATION_INFO_VER1")]
        public const uint NV_GPU_VIRTUALIZATION_INFO_VER = (uint)(12 | ((1) << 16));

        [NativeTypeName("#define NV_LOGICAL_GPU_DATA_VER1 MAKE_NVAPI_VERSION(NV_LOGICAL_GPU_DATA_V1,1)")]
        public static readonly uint NV_LOGICAL_GPU_DATA_VER1 = unchecked((uint)(sizeof(_NV_LOGICAL_GPU_DATA_V1) | ((1) << 16)));

        [NativeTypeName("#define NV_LOGICAL_GPU_DATA_VER NV_LOGICAL_GPU_DATA_VER1")]
        public static readonly uint NV_LOGICAL_GPU_DATA_VER = unchecked((uint)(sizeof(_NV_LOGICAL_GPU_DATA_V1) | ((1) << 16)));

        [NativeTypeName("#define NV_LICENSE_MAX_COUNT 3")]
        public const int NV_LICENSE_MAX_COUNT = 3;

        [NativeTypeName("#define NV_LICENSE_SIGNATURE_SIZE (128)")]
        public const int NV_LICENSE_SIGNATURE_SIZE = (128);

        [NativeTypeName("#define NV_LICENSE_INFO_MAX_LENGTH (128)")]
        public const int NV_LICENSE_INFO_MAX_LENGTH = (128);

        [NativeTypeName("#define NV_LICENSE_FEATURE_DETAILS_VER1 MAKE_NVAPI_VERSION(NV_LICENSE_FEATURE_DETAILS_V1, 1)")]
        public const uint NV_LICENSE_FEATURE_DETAILS_VER1 = (uint)(140 | ((1) << 16));

        [NativeTypeName("#define NV_LICENSE_FEATURE_DETAILS_VER NV_LICENSE_FEATURE_DETAILS_VER1")]
        public const uint NV_LICENSE_FEATURE_DETAILS_VER = (uint)(140 | ((1) << 16));

        [NativeTypeName("#define NV_LICENSABLE_FEATURES_VER1 MAKE_NVAPI_VERSION(NV_LICENSABLE_FEATURES_V1, 1)")]
        public const uint NV_LICENSABLE_FEATURES_VER1 = (uint)(560 | ((1) << 16));

        [NativeTypeName("#define NV_LICENSABLE_FEATURES_VER2 MAKE_NVAPI_VERSION(NV_LICENSABLE_FEATURES_V2, 2)")]
        public const uint NV_LICENSABLE_FEATURES_VER2 = (uint)(944 | ((2) << 16));

        [NativeTypeName("#define NV_LICENSABLE_FEATURES_VER3 MAKE_NVAPI_VERSION(NV_LICENSABLE_FEATURES_V3, 3)")]
        public const uint NV_LICENSABLE_FEATURES_VER3 = (uint)(944 | ((3) << 16));

        [NativeTypeName("#define NV_LICENSABLE_FEATURES_VER4 MAKE_NVAPI_VERSION(NV_LICENSABLE_FEATURES_V4, 4)")]
        public const uint NV_LICENSABLE_FEATURES_VER4 = (uint)(992 | ((4) << 16));

        [NativeTypeName("#define NV_LICENSABLE_FEATURES_VER NV_LICENSABLE_FEATURES_VER4")]
        public const uint NV_LICENSABLE_FEATURES_VER = (uint)(992 | ((4) << 16));

        [NativeTypeName("#define NV_ENCODER_STATISTICS_VER1 MAKE_NVAPI_VERSION(NV_ENCODER_STATISTICS_V1, 1)")]
        public const uint NV_ENCODER_STATISTICS_VER1 = (uint)(16 | ((1) << 16));

        [NativeTypeName("#define NNV_ENCODER_STATISTICS_VER NV_ENCODER_STATISTICS_VER1")]
        public const uint NNV_ENCODER_STATISTICS_VER = (uint)(16 | ((1) << 16));

        [NativeTypeName("#define NV_ENCODER_SESSION_INFO_MAX_ENTRIES_V1 0x200")]
        public const int NV_ENCODER_SESSION_INFO_MAX_ENTRIES_V1 = 0x200;

        [NativeTypeName("#define NV_ENCODER_SESSIONS_INFO_VER1 MAKE_NVAPI_VERSION(NV_ENCODER_SESSIONS_INFO_V1, 1)")]
        public static readonly uint NV_ENCODER_SESSIONS_INFO_VER1 = unchecked((uint)(sizeof(_NV_ENCODER_SESSIONS_INFO_V1) | ((1) << 16)));

        [NativeTypeName("#define NV_ENCODER_SESSIONS_INFO_VER NV_ENCODER_SESSIONS_INFO_VER1")]
        public static readonly uint NV_ENCODER_SESSIONS_INFO_VER = unchecked((uint)(sizeof(_NV_ENCODER_SESSIONS_INFO_V1) | ((1) << 16)));

        [NativeTypeName("#define NV_GPU_INFO_VER1 MAKE_NVAPI_VERSION(NV_GPU_INFO_V1, 1)")]
        public const uint NV_GPU_INFO_VER1 = (uint)(8 | ((1) << 16));

        [NativeTypeName("#define NV_GPU_INFO_VER2 MAKE_NVAPI_VERSION(NV_GPU_INFO_V2, 2)")]
        public const uint NV_GPU_INFO_VER2 = (uint)(80 | ((2) << 16));

        [NativeTypeName("#define NV_GPU_INFO_VER NV_GPU_INFO_VER2")]
        public const uint NV_GPU_INFO_VER = (uint)(80 | ((2) << 16));

        [NativeTypeName("#define NV_GPU_VR_READY_VER1 MAKE_NVAPI_VERSION(NV_GPU_VR_READY_V1, 1)")]
        public const uint NV_GPU_VR_READY_VER1 = (uint)(8 | ((1) << 16));

        [NativeTypeName("#define NV_GPU_VR_READY_VER NV_GPU_VR_READY_VER1")]
        public const uint NV_GPU_VR_READY_VER = (uint)(8 | ((1) << 16));

        [NativeTypeName("#define NVAPI_GPU_MAX_BUILD_VERSION_LENGTH (0x0000040)")]
        public const int NVAPI_GPU_MAX_BUILD_VERSION_LENGTH = (0x0000040);

        [NativeTypeName("#define NV_GPU_GSP_INFO_VER1 MAKE_NVAPI_VERSION(NV_GPU_GSP_INFO_V1, 1)")]
        public const uint NV_GPU_GSP_INFO_VER1 = (uint)(72 | ((1) << 16));

        [NativeTypeName("#define NV_GPU_GSP_INFO_VER NV_GPU_GSP_INFO_VER1")]
        public const uint NV_GPU_GSP_INFO_VER = (uint)(72 | ((1) << 16));

        [NativeTypeName("#define NV_GPU_UUID_VER1 MAKE_NVAPI_VERSION(NV_GPU_UUID_V1,1)")]
        public const uint NV_GPU_UUID_VER1 = (uint)(20 | ((1) << 16));

        [NativeTypeName("#define NV_GPU_UUID_VER NV_GPU_UUID_VER1")]
        public const uint NV_GPU_UUID_VER = (uint)(20 | ((1) << 16));

        [NativeTypeName("#define NVAPI_NVLINK_COUNTER_MAX_TYPES 32")]
        public const int NVAPI_NVLINK_COUNTER_MAX_TYPES = 32;

        [NativeTypeName("#define NVAPI_NVLINK_MAX_LINKS 32")]
        public const int NVAPI_NVLINK_MAX_LINKS = 32;

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_SUPPORTED 0x00000001")]
        public const int NVAPI_NVLINK_CAPS_SUPPORTED = 0x00000001;

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_P2P_SUPPORTED 0x00000002")]
        public const int NVAPI_NVLINK_CAPS_P2P_SUPPORTED = 0x00000002;

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_SYSMEM_ACCESS 0x00000004")]
        public const int NVAPI_NVLINK_CAPS_SYSMEM_ACCESS = 0x00000004;

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_P2P_ATOMICS 0x00000008")]
        public const int NVAPI_NVLINK_CAPS_P2P_ATOMICS = 0x00000008;

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_SYSMEM_ATOMICS 0x00000010")]
        public const int NVAPI_NVLINK_CAPS_SYSMEM_ATOMICS = 0x00000010;

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_PEX_TUNNELING 0x00000020")]
        public const int NVAPI_NVLINK_CAPS_PEX_TUNNELING = 0x00000020;

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_SLI_BRIDGE 0x00000040")]
        public const int NVAPI_NVLINK_CAPS_SLI_BRIDGE = 0x00000040;

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_SLI_BRIDGE_SENSABLE 0x00000080")]
        public const int NVAPI_NVLINK_CAPS_SLI_BRIDGE_SENSABLE = 0x00000080;

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_POWER_STATE_L0 0x00000100")]
        public const int NVAPI_NVLINK_CAPS_POWER_STATE_L0 = 0x00000100;

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_POWER_STATE_L1 0x00000200")]
        public const int NVAPI_NVLINK_CAPS_POWER_STATE_L1 = 0x00000200;

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_POWER_STATE_L2 0x00000400")]
        public const int NVAPI_NVLINK_CAPS_POWER_STATE_L2 = 0x00000400;

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_POWER_STATE_L3 0x00000800")]
        public const int NVAPI_NVLINK_CAPS_POWER_STATE_L3 = 0x00000800;

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_VALID 0x00001000")]
        public const int NVAPI_NVLINK_CAPS_VALID = 0x00001000;

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_UNCONTAINED_ERROR_RECOVERY 0x00002000")]
        public const int NVAPI_NVLINK_CAPS_UNCONTAINED_ERROR_RECOVERY = 0x00002000;

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_NVLINK_VERSION_INVALID (0x00000000)")]
        public const int NVAPI_NVLINK_CAPS_NVLINK_VERSION_INVALID = (0x00000000);

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_NVLINK_VERSION_1_0 (0x00000001)")]
        public const int NVAPI_NVLINK_CAPS_NVLINK_VERSION_1_0 = (0x00000001);

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_NVLINK_VERSION_2_0 (0x00000002)")]
        public const int NVAPI_NVLINK_CAPS_NVLINK_VERSION_2_0 = (0x00000002);

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_NVLINK_VERSION_2_2 (0x00000004U)")]
        public const uint NVAPI_NVLINK_CAPS_NVLINK_VERSION_2_2 = (0x00000004U);

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_NVLINK_VERSION_3_0 (0x00000005U)")]
        public const uint NVAPI_NVLINK_CAPS_NVLINK_VERSION_3_0 = (0x00000005U);

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_NVLINK_VERSION_3_1 (0x00000006U)")]
        public const uint NVAPI_NVLINK_CAPS_NVLINK_VERSION_3_1 = (0x00000006U);

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_NVLINK_VERSION_4_0 (0x00000007U)")]
        public const uint NVAPI_NVLINK_CAPS_NVLINK_VERSION_4_0 = (0x00000007U);

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_NVLINK_VERSION_5_0 (0x00000008U)")]
        public const uint NVAPI_NVLINK_CAPS_NVLINK_VERSION_5_0 = (0x00000008U);

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_NCI_VERSION_INVALID (0x00000000)")]
        public const int NVAPI_NVLINK_CAPS_NCI_VERSION_INVALID = (0x00000000);

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_NCI_VERSION_1_0 (0x00000001)")]
        public const int NVAPI_NVLINK_CAPS_NCI_VERSION_1_0 = (0x00000001);

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_NCI_VERSION_2_0 (0x00000002)")]
        public const int NVAPI_NVLINK_CAPS_NCI_VERSION_2_0 = (0x00000002);

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_NCI_VERSION_2_2 (0x00000004U)")]
        public const uint NVAPI_NVLINK_CAPS_NCI_VERSION_2_2 = (0x00000004U);

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_NCI_VERSION_3_0 (0x00000005U)")]
        public const uint NVAPI_NVLINK_CAPS_NCI_VERSION_3_0 = (0x00000005U);

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_NCI_VERSION_3_1 (0x00000006U)")]
        public const uint NVAPI_NVLINK_CAPS_NCI_VERSION_3_1 = (0x00000006U);

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_NCI_VERSION_4_0 (0x00000007U)")]
        public const uint NVAPI_NVLINK_CAPS_NCI_VERSION_4_0 = (0x00000007U);

        [NativeTypeName("#define NVAPI_NVLINK_CAPS_NCI_VERSION_5_0 (0x00000008U)")]
        public const uint NVAPI_NVLINK_CAPS_NCI_VERSION_5_0 = (0x00000008U);

        [NativeTypeName("#define NVLINK_GET_CAPS_VER1 MAKE_NVAPI_VERSION(NVLINK_GET_CAPS_V1, 1)")]
        public const uint NVLINK_GET_CAPS_VER1 = (uint)(16 | ((1) << 16));

        [NativeTypeName("#define NVLINK_GET_CAPS_VER NVLINK_GET_CAPS_VER1")]
        public const uint NVLINK_GET_CAPS_VER = (uint)(16 | ((1) << 16));

        [NativeTypeName("#define NVAPI_NVLINK_DEVICE_INFO_DEVICE_ID_FLAGS_NONE (0x00000000)")]
        public const int NVAPI_NVLINK_DEVICE_INFO_DEVICE_ID_FLAGS_NONE = (0x00000000);

        [NativeTypeName("#define NVAPI_NVLINK_DEVICE_INFO_DEVICE_ID_FLAGS_PCI (0x00000001)")]
        public const int NVAPI_NVLINK_DEVICE_INFO_DEVICE_ID_FLAGS_PCI = (0x00000001);

        [NativeTypeName("#define NVAPI_NVLINK_DEVICE_INFO_DEVICE_ID_FLAGS_UUID (0x00000002)")]
        public const int NVAPI_NVLINK_DEVICE_INFO_DEVICE_ID_FLAGS_UUID = (0x00000002);

        [NativeTypeName("#define NVAPI_NVLINK_STATUS_PHY_NVHS (0x00000001)")]
        public const int NVAPI_NVLINK_STATUS_PHY_NVHS = (0x00000001);

        [NativeTypeName("#define NVAPI_NVLINK_STATUS_PHY_GRS (0x00000002)")]
        public const int NVAPI_NVLINK_STATUS_PHY_GRS = (0x00000002);

        [NativeTypeName("#define NVAPI_NVLINK_STATUS_PHY_INVALID (0x000000FF)")]
        public const int NVAPI_NVLINK_STATUS_PHY_INVALID = (0x000000FF);

        [NativeTypeName("#define NVAPI_NVLINK_STATUS_NVLINK_VERSION_1_0 (0x00000001)")]
        public const int NVAPI_NVLINK_STATUS_NVLINK_VERSION_1_0 = (0x00000001);

        [NativeTypeName("#define NVAPI_NVLINK_STATUS_NVLINK_VERSION_2_0 (0x00000002)")]
        public const int NVAPI_NVLINK_STATUS_NVLINK_VERSION_2_0 = (0x00000002);

        [NativeTypeName("#define NVAPI_NVLINK_STATUS_NVLINK_VERSION_INVALID (0x000000FF)")]
        public const int NVAPI_NVLINK_STATUS_NVLINK_VERSION_INVALID = (0x000000FF);

        [NativeTypeName("#define NVAPI_NVLINK_STATUS_NCI_VERSION_1_0 (0x00000001)")]
        public const int NVAPI_NVLINK_STATUS_NCI_VERSION_1_0 = (0x00000001);

        [NativeTypeName("#define NVAPI_NVLINK_STATUS_NCI_VERSION_2_0 (0x00000002)")]
        public const int NVAPI_NVLINK_STATUS_NCI_VERSION_2_0 = (0x00000002);

        [NativeTypeName("#define NVAPI_NVLINK_STATUS_NCI_VERSION_INVALID (0x000000FF)")]
        public const int NVAPI_NVLINK_STATUS_NCI_VERSION_INVALID = (0x000000FF);

        [NativeTypeName("#define NVAPI_NVLINK_STATUS_NVHS_VERSION_1_0 (0x00000001)")]
        public const int NVAPI_NVLINK_STATUS_NVHS_VERSION_1_0 = (0x00000001);

        [NativeTypeName("#define NVAPI_NVLINK_STATUS_NVHS_VERSION_INVALID (0x000000FF)")]
        public const int NVAPI_NVLINK_STATUS_NVHS_VERSION_INVALID = (0x000000FF);

        [NativeTypeName("#define NVAPI_NVLINK_STATUS_GRS_VERSION_1_0 (0x00000001)")]
        public const int NVAPI_NVLINK_STATUS_GRS_VERSION_1_0 = (0x00000001);

        [NativeTypeName("#define NVAPI_NVLINK_STATUS_GRS_VERSION_INVALID (0x000000FF)")]
        public const int NVAPI_NVLINK_STATUS_GRS_VERSION_INVALID = (0x000000FF);

        [NativeTypeName("#define NVAPI_NVLINK_STATUS_CONNECTED_TRUE (0x00000001)")]
        public const int NVAPI_NVLINK_STATUS_CONNECTED_TRUE = (0x00000001);

        [NativeTypeName("#define NVAPI_NVLINK_STATUS_CONNECTED_FALSE (0x00000000)")]
        public const int NVAPI_NVLINK_STATUS_CONNECTED_FALSE = (0x00000000);

        [NativeTypeName("#define NVAPI_NVLINK_STATUS_LOOP_PROPERTY_LOOPBACK (0x00000001)")]
        public const int NVAPI_NVLINK_STATUS_LOOP_PROPERTY_LOOPBACK = (0x00000001);

        [NativeTypeName("#define NVAPI_NVLINK_STATUS_LOOP_PROPERTY_LOOPOUT (0x00000002)")]
        public const int NVAPI_NVLINK_STATUS_LOOP_PROPERTY_LOOPOUT = (0x00000002);

        [NativeTypeName("#define NVAPI_NVLINK_STATUS_LOOP_PROPERTY_NONE (0x00000000)")]
        public const int NVAPI_NVLINK_STATUS_LOOP_PROPERTY_NONE = (0x00000000);

        [NativeTypeName("#define NVAPI_NVLINK_STATUS_REMOTE_LINK_NUMBER_INVALID (0x000000FF)")]
        public const int NVAPI_NVLINK_STATUS_REMOTE_LINK_NUMBER_INVALID = (0x000000FF);

        [NativeTypeName("#define NVAPI_NVLINK_REFCLK_TYPE_INVALID (0x00)")]
        public const int NVAPI_NVLINK_REFCLK_TYPE_INVALID = (0x00);

        [NativeTypeName("#define NVAPI_NVLINK_REFCLK_TYPE_NVHS (0x01)")]
        public const int NVAPI_NVLINK_REFCLK_TYPE_NVHS = (0x01);

        [NativeTypeName("#define NVAPI_NVLINK_REFCLK_TYPE_PEX (0x02)")]
        public const int NVAPI_NVLINK_REFCLK_TYPE_PEX = (0x02);

        [NativeTypeName("#define NVLINK_GET_STATUS_VER1 MAKE_NVAPI_VERSION(NVLINK_GET_STATUS_V1, 1)")]
        public const uint NVLINK_GET_STATUS_VER1 = (uint)(2824 | ((1) << 16));

        [NativeTypeName("#define NVLINK_GET_STATUS_VER2 MAKE_NVAPI_VERSION(NVLINK_GET_STATUS_V2, 2)")]
        public const uint NVLINK_GET_STATUS_VER2 = (uint)(5640 | ((2) << 16));

        [NativeTypeName("#define NVLINK_GET_STATUS_VER NVLINK_GET_STATUS_VER2")]
        public const uint NVLINK_GET_STATUS_VER = (uint)(5640 | ((2) << 16));

        [NativeTypeName("#define NV_GPU_PERF_PSTATES_INFO_VER1 MAKE_NVAPI_VERSION(NV_GPU_PERF_PSTATES_INFO_V1,1)")]
        public const uint NV_GPU_PERF_PSTATES_INFO_VER1 = (uint)(6288 | ((1) << 16));

        [NativeTypeName("#define NV_GPU_PERF_PSTATES_INFO_VER2 MAKE_NVAPI_VERSION(NV_GPU_PERF_PSTATES_INFO_V2,2)")]
        public const uint NV_GPU_PERF_PSTATES_INFO_VER2 = (uint)(9364 | ((2) << 16));

        [NativeTypeName("#define NV_GPU_PERF_PSTATES_INFO_VER3 MAKE_NVAPI_VERSION(NV_GPU_PERF_PSTATES_INFO_V2,3)")]
        public const uint NV_GPU_PERF_PSTATES_INFO_VER3 = (uint)(9364 | ((3) << 16));

        [NativeTypeName("#define NV_GPU_PERF_PSTATES_INFO_VER NV_GPU_PERF_PSTATES_INFO_VER3")]
        public const uint NV_GPU_PERF_PSTATES_INFO_VER = (uint)(9364 | ((3) << 16));

        [NativeTypeName("#define NVAPI_MAX_GPU_UTILIZATIONS 8")]
        public const int NVAPI_MAX_GPU_UTILIZATIONS = 8;

        [NativeTypeName("#define NV_GPU_DYNAMIC_PSTATES_INFO_EX_VER MAKE_NVAPI_VERSION(NV_GPU_DYNAMIC_PSTATES_INFO_EX,1)")]
        public const uint NV_GPU_DYNAMIC_PSTATES_INFO_EX_VER = (uint)(72 | ((1) << 16));

        [NativeTypeName("#define NVAPI_MAX_THERMAL_SENSORS_PER_GPU 3")]
        public const int NVAPI_MAX_THERMAL_SENSORS_PER_GPU = 3;

        [NativeTypeName("#define NV_GPU_THERMAL_SETTINGS_VER_1 MAKE_NVAPI_VERSION(NV_GPU_THERMAL_SETTINGS_V1,1)")]
        public const uint NV_GPU_THERMAL_SETTINGS_VER_1 = (uint)(68 | ((1) << 16));

        [NativeTypeName("#define NV_GPU_THERMAL_SETTINGS_VER_2 MAKE_NVAPI_VERSION(NV_GPU_THERMAL_SETTINGS_V2,2)")]
        public const uint NV_GPU_THERMAL_SETTINGS_VER_2 = (uint)(68 | ((2) << 16));

        [NativeTypeName("#define NV_GPU_THERMAL_SETTINGS_VER NV_GPU_THERMAL_SETTINGS_VER_2")]
        public const uint NV_GPU_THERMAL_SETTINGS_VER = (uint)(68 | ((2) << 16));

        [NativeTypeName("#define NV_GPU_MAX_CLOCK_FREQUENCIES 3")]
        public const int NV_GPU_MAX_CLOCK_FREQUENCIES = 3;

        [NativeTypeName("#define NV_GPU_CLOCK_FREQUENCIES_VER_1 MAKE_NVAPI_VERSION(NV_GPU_CLOCK_FREQUENCIES_V1,1)")]
        public const uint NV_GPU_CLOCK_FREQUENCIES_VER_1 = (uint)(264 | ((1) << 16));

        [NativeTypeName("#define NV_GPU_CLOCK_FREQUENCIES_VER_2 MAKE_NVAPI_VERSION(NV_GPU_CLOCK_FREQUENCIES_V2,2)")]
        public const uint NV_GPU_CLOCK_FREQUENCIES_VER_2 = (uint)(264 | ((2) << 16));

        [NativeTypeName("#define NV_GPU_CLOCK_FREQUENCIES_VER_3 MAKE_NVAPI_VERSION(NV_GPU_CLOCK_FREQUENCIES_V2,3)")]
        public const uint NV_GPU_CLOCK_FREQUENCIES_VER_3 = (uint)(264 | ((3) << 16));

        [NativeTypeName("#define NV_GPU_CLOCK_FREQUENCIES_VER NV_GPU_CLOCK_FREQUENCIES_VER_3")]
        public const uint NV_GPU_CLOCK_FREQUENCIES_VER = (uint)(264 | ((3) << 16));

        [NativeTypeName("#define NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_VER_1 MAKE_NVAPI_VERSION(NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_V1,1)")]
        public static readonly uint NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_VER_1 = unchecked((uint)(sizeof(_NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_V1) | ((1) << 16)));

        [NativeTypeName("#define NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_VER NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_VER_1")]
        public static readonly uint NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_VER = unchecked((uint)(sizeof(_NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_V1) | ((1) << 16)));

        [NativeTypeName("#define NV_GPU_GET_ILLUMINATION_PARM_VER_1 MAKE_NVAPI_VERSION(NV_GPU_GET_ILLUMINATION_PARM_V1,1)")]
        public static readonly uint NV_GPU_GET_ILLUMINATION_PARM_VER_1 = unchecked((uint)(sizeof(_NV_GPU_GET_ILLUMINATION_PARM_V1) | ((1) << 16)));

        [NativeTypeName("#define NV_GPU_GET_ILLUMINATION_PARM_VER NV_GPU_GET_ILLUMINATION_PARM_VER_1")]
        public static readonly uint NV_GPU_GET_ILLUMINATION_PARM_VER = unchecked((uint)(sizeof(_NV_GPU_GET_ILLUMINATION_PARM_V1) | ((1) << 16)));

        [NativeTypeName("#define NV_GPU_SET_ILLUMINATION_PARM_VER_1 MAKE_NVAPI_VERSION(NV_GPU_SET_ILLUMINATION_PARM_V1,1)")]
        public static readonly uint NV_GPU_SET_ILLUMINATION_PARM_VER_1 = unchecked((uint)(sizeof(_NV_GPU_SET_ILLUMINATION_PARM_V1) | ((1) << 16)));

        [NativeTypeName("#define NV_GPU_SET_ILLUMINATION_PARM_VER NV_GPU_SET_ILLUMINATION_PARM_VER_1")]
        public static readonly uint NV_GPU_SET_ILLUMINATION_PARM_VER = unchecked((uint)(sizeof(_NV_GPU_SET_ILLUMINATION_PARM_V1) | ((1) << 16)));

        [NativeTypeName("#define NV_GPU_CLIENT_ILLUM_CTRL_MODE_PIECEWISE_LINEAR_COLOR_ENDPOINTS 2")]
        public const int NV_GPU_CLIENT_ILLUM_CTRL_MODE_PIECEWISE_LINEAR_COLOR_ENDPOINTS = 2;

        [NativeTypeName("#define NV_GPU_CLIENT_ILLUM_DEVICE_NUM_DEVICES_MAX 32")]
        public const int NV_GPU_CLIENT_ILLUM_DEVICE_NUM_DEVICES_MAX = 32;

        [NativeTypeName("#define NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_VER_1 MAKE_NVAPI_VERSION(NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_V1, 1)")]
        public const uint NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_VER_1 = (uint)(4424 | ((1) << 16));

        [NativeTypeName("#define NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_VER NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_VER_1")]
        public const uint NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_VER = (uint)(4424 | ((1) << 16));

        [NativeTypeName("#define NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_VER_1 MAKE_NVAPI_VERSION(NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_V1, 1)")]
        public const uint NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_VER_1 = (uint)(4936 | ((1) << 16));

        [NativeTypeName("#define NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_VER NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_VER_1")]
        public const uint NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_VER = (uint)(4936 | ((1) << 16));

        [NativeTypeName("#define NV_GPU_CLIENT_ILLUM_ZONE_NUM_ZONES_MAX 32")]
        public const int NV_GPU_CLIENT_ILLUM_ZONE_NUM_ZONES_MAX = 32;

        [NativeTypeName("#define NV_GPU_CLIENT_ILLUM_ZONE_INFO_PARAMS_VER_1 MAKE_NVAPI_VERSION(NV_GPU_CLIENT_ILLUM_ZONE_INFO_PARAMS_V1, 1)")]
        public const uint NV_GPU_CLIENT_ILLUM_ZONE_INFO_PARAMS_VER_1 = (uint)(4552 | ((1) << 16));

        [NativeTypeName("#define NV_GPU_CLIENT_ILLUM_ZONE_INFO_PARAMS_VER NV_GPU_CLIENT_ILLUM_ZONE_INFO_PARAMS_VER_1")]
        public const uint NV_GPU_CLIENT_ILLUM_ZONE_INFO_PARAMS_VER = (uint)(4552 | ((1) << 16));

        [NativeTypeName("#define NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_VER_1 MAKE_NVAPI_VERSION(NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1, 1)")]
        public const uint NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_VER_1 = (uint)(6476 | ((1) << 16));

        [NativeTypeName("#define NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_VER NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_VER_1")]
        public const uint NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_VER = (uint)(6476 | ((1) << 16));

        [NativeTypeName("#define NV_DISPLAY_PORT_INFO_VER1 MAKE_NVAPI_VERSION(NV_DISPLAY_PORT_INFO,1)")]
        public const uint NV_DISPLAY_PORT_INFO_VER1 = (uint)(44 | ((1) << 16));

        [NativeTypeName("#define NV_DISPLAY_PORT_INFO_VER2 MAKE_NVAPI_VERSION(NV_DISPLAY_PORT_INFO,2)")]
        public const uint NV_DISPLAY_PORT_INFO_VER2 = (uint)(44 | ((2) << 16));

        [NativeTypeName("#define NV_DISPLAY_PORT_INFO_VER NV_DISPLAY_PORT_INFO_VER2")]
        public const uint NV_DISPLAY_PORT_INFO_VER = (uint)(44 | ((2) << 16));

        [NativeTypeName("#define NV_DISPLAY_PORT_CONFIG_VER MAKE_NVAPI_VERSION(NV_DISPLAY_PORT_CONFIG,2)")]
        public const uint NV_DISPLAY_PORT_CONFIG_VER = (uint)(32 | ((2) << 16));

        [NativeTypeName("#define NV_DISPLAY_PORT_CONFIG_VER_1 MAKE_NVAPI_VERSION(NV_DISPLAY_PORT_CONFIG,1)")]
        public const uint NV_DISPLAY_PORT_CONFIG_VER_1 = (uint)(32 | ((1) << 16));

        [NativeTypeName("#define NV_DISPLAY_PORT_CONFIG_VER_2 MAKE_NVAPI_VERSION(NV_DISPLAY_PORT_CONFIG,2)")]
        public const uint NV_DISPLAY_PORT_CONFIG_VER_2 = (uint)(32 | ((2) << 16));

        [NativeTypeName("#define NV_HDMI_SUPPORT_INFO_VER1 MAKE_NVAPI_VERSION(NV_HDMI_SUPPORT_INFO_V1, 1)")]
        public const uint NV_HDMI_SUPPORT_INFO_VER1 = (uint)(12 | ((1) << 16));

        [NativeTypeName("#define NV_HDMI_SUPPORT_INFO_VER2 MAKE_NVAPI_VERSION(NV_HDMI_SUPPORT_INFO_V2, 2)")]
        public const uint NV_HDMI_SUPPORT_INFO_VER2 = (uint)(12 | ((2) << 16));

        [NativeTypeName("#define NV_HDMI_SUPPORT_INFO_VER NV_HDMI_SUPPORT_INFO_VER2")]
        public const uint NV_HDMI_SUPPORT_INFO_VER = (uint)(12 | ((2) << 16));

        [NativeTypeName("#define NV_INFOFRAME_DATA_VER MAKE_NVAPI_VERSION(NV_INFOFRAME_DATA,1)")]
        public const uint NV_INFOFRAME_DATA_VER = (uint)(32 | ((1) << 16));

        [NativeTypeName("#define NV_COLOR_DATA_VER1 MAKE_NVAPI_VERSION(NV_COLOR_DATA_V1, 1)")]
        public const uint NV_COLOR_DATA_VER1 = (uint)(12 | ((1) << 16));

        [NativeTypeName("#define NV_COLOR_DATA_VER2 MAKE_NVAPI_VERSION(NV_COLOR_DATA_V2, 2)")]
        public const uint NV_COLOR_DATA_VER2 = (uint)(12 | ((2) << 16));

        [NativeTypeName("#define NV_COLOR_DATA_VER3 MAKE_NVAPI_VERSION(NV_COLOR_DATA_V3, 3)")]
        public const uint NV_COLOR_DATA_VER3 = (uint)(16 | ((3) << 16));

        [NativeTypeName("#define NV_COLOR_DATA_VER4 MAKE_NVAPI_VERSION(NV_COLOR_DATA_V4, 4)")]
        public const uint NV_COLOR_DATA_VER4 = (uint)(20 | ((4) << 16));

        [NativeTypeName("#define NV_COLOR_DATA_VER5 MAKE_NVAPI_VERSION(NV_COLOR_DATA_V5, 5)")]
        public const uint NV_COLOR_DATA_VER5 = (uint)(24 | ((5) << 16));

        [NativeTypeName("#define NV_COLOR_DATA_VER NV_COLOR_DATA_VER5")]
        public const uint NV_COLOR_DATA_VER = (uint)(24 | ((5) << 16));

        [NativeTypeName("#define NV_HDR_CAPABILITIES_VER1 MAKE_NVAPI_VERSION(NV_HDR_CAPABILITIES_V1, 1)")]
        public const uint NV_HDR_CAPABILITIES_VER1 = (uint)(36 | ((1) << 16));

        [NativeTypeName("#define NV_HDR_CAPABILITIES_VER2 MAKE_NVAPI_VERSION(NV_HDR_CAPABILITIES_V2, 2)")]
        public const uint NV_HDR_CAPABILITIES_VER2 = (uint)(60 | ((2) << 16));

        [NativeTypeName("#define NV_HDR_CAPABILITIES_VER3 MAKE_NVAPI_VERSION(NV_HDR_CAPABILITIES_V3, 3)")]
        public const uint NV_HDR_CAPABILITIES_VER3 = (uint)(64 | ((3) << 16));

        [NativeTypeName("#define NV_HDR_CAPABILITIES_VER NV_HDR_CAPABILITIES_VER3")]
        public const uint NV_HDR_CAPABILITIES_VER = (uint)(64 | ((3) << 16));

        [NativeTypeName("#define NV_HDR_COLOR_DATA_VER1 MAKE_NVAPI_VERSION(NV_HDR_COLOR_DATA_V1, 1)")]
        public const uint NV_HDR_COLOR_DATA_VER1 = (uint)(40 | ((1) << 16));

        [NativeTypeName("#define NV_HDR_COLOR_DATA_VER2 MAKE_NVAPI_VERSION(NV_HDR_COLOR_DATA_V2, 2)")]
        public const uint NV_HDR_COLOR_DATA_VER2 = (uint)(52 | ((2) << 16));

        [NativeTypeName("#define NV_HDR_COLOR_DATA_VER NV_HDR_COLOR_DATA_VER2")]
        public const uint NV_HDR_COLOR_DATA_VER = (uint)(52 | ((2) << 16));

        [NativeTypeName("#define NV_SOURCE_PID_CURRENT 0")]
        public const int NV_SOURCE_PID_CURRENT = 0;

        [NativeTypeName("#define NV_HDR_METADATA_VER1 MAKE_NVAPI_VERSION(NV_HDR_METADATA_V1, 1)")]
        public const uint NV_HDR_METADATA_VER1 = (uint)(28 | ((1) << 16));

        [NativeTypeName("#define NV_HDR_METADATA_VER NV_HDR_METADATA_VER1")]
        public const uint NV_HDR_METADATA_VER = (uint)(28 | ((1) << 16));

        [NativeTypeName("#define NV_DISPLAY_COLORIMETRY_VER1 MAKE_NVAPI_VERSION(NV_DISPLAY_COLORIMETRY_V1, 1)")]
        public const uint NV_DISPLAY_COLORIMETRY_VER1 = (uint)(52 | ((1) << 16));

        [NativeTypeName("#define NV_DISPLAY_COLORIMETRY_VER NV_DISPLAY_COLORIMETRY_VER1")]
        public const uint NV_DISPLAY_COLORIMETRY_VER = (uint)(52 | ((1) << 16));

        [NativeTypeName("#define NV_TIMING_INPUT_VER MAKE_NVAPI_VERSION(NV_TIMING_INPUT,1)")]
        public const uint NV_TIMING_INPUT_VER = (uint)(28 | ((1) << 16));

        [NativeTypeName("#define NV_MONITOR_CAPABILITIES_VER1 MAKE_NVAPI_VERSION(NV_MONITOR_CAPABILITIES_V1,1)")]
        public const uint NV_MONITOR_CAPABILITIES_VER1 = (uint)(68 | ((1) << 16));

        [NativeTypeName("#define NV_MONITOR_CAPABILITIES_VER NV_MONITOR_CAPABILITIES_VER1")]
        public const uint NV_MONITOR_CAPABILITIES_VER = (uint)(68 | ((1) << 16));

        [NativeTypeName("#define NV_MONITOR_COLOR_CAPS_VER1 MAKE_NVAPI_VERSION(NV_MONITOR_COLOR_CAPS_V1,1)")]
        public const uint NV_MONITOR_COLOR_CAPS_VER1 = (uint)(12 | ((1) << 16));

        [NativeTypeName("#define NV_MONITOR_COLOR_CAPS_VER NV_MONITOR_COLOR_CAPS_VER1")]
        public const uint NV_MONITOR_COLOR_CAPS_VER = (uint)(12 | ((1) << 16));

        [NativeTypeName("#define NV_CUSTOM_DISPLAY_VER MAKE_NVAPI_VERSION(NV_CUSTOM_DISPLAY,1)")]
        public const uint NV_CUSTOM_DISPLAY_VER = (uint)(144 | ((1) << 16));

        [NativeTypeName("#define NV_EDID_DATA_VER1 MAKE_NVAPI_VERSION(NV_EDID_DATA_V1, 1)")]
        public static readonly uint NV_EDID_DATA_VER1 = unchecked((uint)(sizeof(_NV_EDID_DATA_V1) | ((1) << 16)));

        [NativeTypeName("#define NV_EDID_DATA_VER2 MAKE_NVAPI_VERSION(NV_EDID_DATA_V2, 2)")]
        public static readonly uint NV_EDID_DATA_VER2 = unchecked((uint)(sizeof(_NV_EDID_DATA_V2) | ((2) << 16)));

        [NativeTypeName("#define NV_EDID_DATA_VER NV_EDID_DATA_VER2")]
        public static readonly uint NV_EDID_DATA_VER = unchecked((uint)(sizeof(_NV_EDID_DATA_V2) | ((2) << 16)));

        [NativeTypeName("#define NV_GET_ADAPTIVE_SYNC_DATA_VER1 MAKE_NVAPI_VERSION(NV_GET_ADAPTIVE_SYNC_DATA_V1,1)")]
        public const uint NV_GET_ADAPTIVE_SYNC_DATA_VER1 = (uint)(40 | ((1) << 16));

        [NativeTypeName("#define NV_GET_ADAPTIVE_SYNC_DATA_VER NV_GET_ADAPTIVE_SYNC_DATA_VER1")]
        public const uint NV_GET_ADAPTIVE_SYNC_DATA_VER = (uint)(40 | ((1) << 16));

        [NativeTypeName("#define NV_SET_ADAPTIVE_SYNC_DATA_VER1 MAKE_NVAPI_VERSION(NV_SET_ADAPTIVE_SYNC_DATA_V1,1)")]
        public const uint NV_SET_ADAPTIVE_SYNC_DATA_VER1 = (uint)(40 | ((1) << 16));

        [NativeTypeName("#define NV_SET_ADAPTIVE_SYNC_DATA_VER2 MAKE_NVAPI_VERSION(NV_SET_ADAPTIVE_SYNC_DATA_V1,2)")]
        public const uint NV_SET_ADAPTIVE_SYNC_DATA_VER2 = (uint)(40 | ((2) << 16));

        [NativeTypeName("#define NV_SET_ADAPTIVE_SYNC_DATA_VER NV_SET_ADAPTIVE_SYNC_DATA_VER2")]
        public const uint NV_SET_ADAPTIVE_SYNC_DATA_VER = (uint)(40 | ((2) << 16));

        [NativeTypeName("#define NV_GET_VIRTUAL_REFRESH_RATE_DATA_VER1 MAKE_NVAPI_VERSION(_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V1,1)")]
        public const uint NV_GET_VIRTUAL_REFRESH_RATE_DATA_VER1 = (uint)(40 | ((1) << 16));

        [NativeTypeName("#define NV_GET_VIRTUAL_REFRESH_RATE_DATA_VER2 MAKE_NVAPI_VERSION(_NV_GET_VIRTUAL_REFRESH_RATE_DATA_V2,2)")]
        public const uint NV_GET_VIRTUAL_REFRESH_RATE_DATA_VER2 = (uint)(40 | ((2) << 16));

        [NativeTypeName("#define NV_GET_VIRTUAL_REFRESH_RATE_DATA_VER NV_GET_VIRTUAL_REFRESH_RATE_DATA_VER2")]
        public const uint NV_GET_VIRTUAL_REFRESH_RATE_DATA_VER = (uint)(40 | ((2) << 16));

        [NativeTypeName("#define NV_SET_VIRTUAL_REFRESH_RATE_DATA_VER1 MAKE_NVAPI_VERSION(_NV_SET_VIRTUAL_REFRESH_RATE_DATA_V1,1)")]
        public const uint NV_SET_VIRTUAL_REFRESH_RATE_DATA_VER1 = (uint)(40 | ((1) << 16));

        [NativeTypeName("#define NV_SET_VIRTUAL_REFRESH_RATE_DATA_VER2 MAKE_NVAPI_VERSION(_NV_SET_VIRTUAL_REFRESH_RATE_DATA_V2,2)")]
        public const uint NV_SET_VIRTUAL_REFRESH_RATE_DATA_VER2 = (uint)(40 | ((2) << 16));

        [NativeTypeName("#define NV_SET_VIRTUAL_REFRESH_RATE_DATA_VER NV_SET_VIRTUAL_REFRESH_RATE_DATA_VER2")]
        public const uint NV_SET_VIRTUAL_REFRESH_RATE_DATA_VER = (uint)(40 | ((2) << 16));

        [NativeTypeName("#define NV_SET_PREFERRED_STEREO_DISPLAY_VER1 MAKE_NVAPI_VERSION(NV_SET_PREFERRED_STEREO_DISPLAY_V1,1)")]
        public const uint NV_SET_PREFERRED_STEREO_DISPLAY_VER1 = (uint)(12 | ((1) << 16));

        [NativeTypeName("#define NV_SET_PREFERRED_STEREO_DISPLAY_VER NV_SET_PREFERRED_STEREO_DISPLAY_VER1")]
        public const uint NV_SET_PREFERRED_STEREO_DISPLAY_VER = (uint)(12 | ((1) << 16));

        [NativeTypeName("#define NV_GET_PREFERRED_STEREO_DISPLAY_VER1 MAKE_NVAPI_VERSION(NV_GET_PREFERRED_STEREO_DISPLAY_V1,1)")]
        public const uint NV_GET_PREFERRED_STEREO_DISPLAY_VER1 = (uint)(12 | ((1) << 16));

        [NativeTypeName("#define NV_GET_PREFERRED_STEREO_DISPLAY_VER NV_GET_PREFERRED_STEREO_DISPLAY_VER1")]
        public const uint NV_GET_PREFERRED_STEREO_DISPLAY_VER = (uint)(12 | ((1) << 16));

        [NativeTypeName("#define NV_MANAGED_DEDICATED_DISPLAY_INFO_VER1 MAKE_NVAPI_VERSION(NV_MANAGED_DEDICATED_DISPLAY_INFO_V1,1)")]
        public const uint NV_MANAGED_DEDICATED_DISPLAY_INFO_VER1 = (uint)(12 | ((1) << 16));

        [NativeTypeName("#define NV_MANAGED_DEDICATED_DISPLAY_INFO_VER NV_MANAGED_DEDICATED_DISPLAY_INFO_VER1")]
        public const uint NV_MANAGED_DEDICATED_DISPLAY_INFO_VER = (uint)(12 | ((1) << 16));

        [NativeTypeName("#define NV_MANAGED_DEDICATED_DISPLAY_METADATA_VER1 MAKE_NVAPI_VERSION(NV_MANAGED_DEDICATED_DISPLAY_METADATA_V1,1)")]
        public const uint NV_MANAGED_DEDICATED_DISPLAY_METADATA_VER1 = (uint)(84 | ((1) << 16));

        [NativeTypeName("#define NV_MANAGED_DEDICATED_DISPLAY_METADATA_VER NV_MANAGED_DEDICATED_DISPLAY_METADATA_VER1")]
        public const uint NV_MANAGED_DEDICATED_DISPLAY_METADATA_VER = (uint)(84 | ((1) << 16));

        [NativeTypeName("#define NV_DISPLAY_ID_INFO_DATA_VER1 MAKE_NVAPI_VERSION(NV_DISPLAY_ID_INFO_DATA_V1,1)")]
        public const uint NV_DISPLAY_ID_INFO_DATA_VER1 = (uint)(32 | ((1) << 16));

        [NativeTypeName("#define NV_DISPLAY_ID_INFO_DATA_VER NV_DISPLAY_ID_INFO_DATA_VER1")]
        public const uint NV_DISPLAY_ID_INFO_DATA_VER = (uint)(32 | ((1) << 16));

        [NativeTypeName("#define NV_TARGET_INFO_DATA_VER1 MAKE_NVAPI_VERSION(NV_TARGET_INFO_DATA_V1,1)")]
        public const uint NV_TARGET_INFO_DATA_VER1 = (uint)(548 | ((1) << 16));

        [NativeTypeName("#define NV_TARGET_INFO_DATA_VER NV_TARGET_INFO_DATA_VER1")]
        public const uint NV_TARGET_INFO_DATA_VER = (uint)(548 | ((1) << 16));

        [NativeTypeName("#define NV_GET_VRR_INFO_VER1 MAKE_NVAPI_VERSION(NV_GET_VRR_INFO_V1,1)")]
        public const uint NV_GET_VRR_INFO_VER1 = (uint)(24 | ((1) << 16));

        [NativeTypeName("#define NV_GET_VRR_INFO_VER NV_GET_VRR_INFO_VER1")]
        public const uint NV_GET_VRR_INFO_VER = (uint)(24 | ((1) << 16));

        [NativeTypeName("#define NVAPI_MAX_MOSAIC_DISPLAY_ROWS 8")]
        public const int NVAPI_MAX_MOSAIC_DISPLAY_ROWS = 8;

        [NativeTypeName("#define NVAPI_MAX_MOSAIC_DISPLAY_COLUMNS 8")]
        public const int NVAPI_MAX_MOSAIC_DISPLAY_COLUMNS = 8;

        [NativeTypeName("#define NV_MOSAIC_TOPO_VALIDITY_VALID 0x00000000")]
        public const int NV_MOSAIC_TOPO_VALIDITY_VALID = 0x00000000;

        [NativeTypeName("#define NV_MOSAIC_TOPO_VALIDITY_MISSING_GPU 0x00000001")]
        public const int NV_MOSAIC_TOPO_VALIDITY_MISSING_GPU = 0x00000001;

        [NativeTypeName("#define NV_MOSAIC_TOPO_VALIDITY_MISSING_DISPLAY 0x00000002")]
        public const int NV_MOSAIC_TOPO_VALIDITY_MISSING_DISPLAY = 0x00000002;

        [NativeTypeName("#define NV_MOSAIC_TOPO_VALIDITY_MIXED_DISPLAY_TYPES 0x00000004")]
        public const int NV_MOSAIC_TOPO_VALIDITY_MIXED_DISPLAY_TYPES = 0x00000004;

        [NativeTypeName("#define NVAPI_MOSAIC_TOPO_DETAILS_VER MAKE_NVAPI_VERSION(NV_MOSAIC_TOPO_DETAILS,1)")]
        public static readonly uint NVAPI_MOSAIC_TOPO_DETAILS_VER = unchecked((uint)(sizeof(NV_MOSAIC_TOPO_DETAILS) | ((1) << 16)));

        [NativeTypeName("#define NVAPI_MOSAIC_TOPO_BRIEF_VER MAKE_NVAPI_VERSION(NV_MOSAIC_TOPO_BRIEF,1)")]
        public const uint NVAPI_MOSAIC_TOPO_BRIEF_VER = (uint)(16 | ((1) << 16));

        [NativeTypeName("#define NVAPI_MOSAIC_DISPLAY_SETTING_VER1 MAKE_NVAPI_VERSION(NV_MOSAIC_DISPLAY_SETTING_V1,1)")]
        public const uint NVAPI_MOSAIC_DISPLAY_SETTING_VER1 = (uint)(20 | ((1) << 16));

        [NativeTypeName("#define NVAPI_MOSAIC_DISPLAY_SETTING_VER2 MAKE_NVAPI_VERSION(NV_MOSAIC_DISPLAY_SETTING_V2,2)")]
        public const uint NVAPI_MOSAIC_DISPLAY_SETTING_VER2 = (uint)(24 | ((2) << 16));

        [NativeTypeName("#define NVAPI_MOSAIC_DISPLAY_SETTING_VER NVAPI_MOSAIC_DISPLAY_SETTING_VER2")]
        public const uint NVAPI_MOSAIC_DISPLAY_SETTING_VER = (uint)(24 | ((2) << 16));

        [NativeTypeName("#define NV_MOSAIC_DISPLAY_SETTINGS_MAX 40")]
        public const int NV_MOSAIC_DISPLAY_SETTINGS_MAX = 40;

        [NativeTypeName("#define NVAPI_MOSAIC_SUPPORTED_TOPO_INFO_VER1 MAKE_NVAPI_VERSION(NV_MOSAIC_SUPPORTED_TOPO_INFO_V1,1)")]
        public const uint NVAPI_MOSAIC_SUPPORTED_TOPO_INFO_VER1 = (uint)(1372 | ((1) << 16));

        [NativeTypeName("#define NVAPI_MOSAIC_SUPPORTED_TOPO_INFO_VER2 MAKE_NVAPI_VERSION(NV_MOSAIC_SUPPORTED_TOPO_INFO_V2,2)")]
        public const uint NVAPI_MOSAIC_SUPPORTED_TOPO_INFO_VER2 = (uint)(1532 | ((2) << 16));

        [NativeTypeName("#define NVAPI_MOSAIC_SUPPORTED_TOPO_INFO_VER NVAPI_MOSAIC_SUPPORTED_TOPO_INFO_VER2")]
        public const uint NVAPI_MOSAIC_SUPPORTED_TOPO_INFO_VER = (uint)(1532 | ((2) << 16));

        [NativeTypeName("#define NV_MOSAIC_TOPO_IDX_DEFAULT 0")]
        public const int NV_MOSAIC_TOPO_IDX_DEFAULT = 0;

        [NativeTypeName("#define NV_MOSAIC_TOPO_IDX_LEFT_EYE 0")]
        public const int NV_MOSAIC_TOPO_IDX_LEFT_EYE = 0;

        [NativeTypeName("#define NV_MOSAIC_TOPO_IDX_RIGHT_EYE 1")]
        public const int NV_MOSAIC_TOPO_IDX_RIGHT_EYE = 1;

        [NativeTypeName("#define NV_MOSAIC_TOPO_NUM_EYES 2")]
        public const int NV_MOSAIC_TOPO_NUM_EYES = 2;

        [NativeTypeName("#define NV_MOSAIC_MAX_TOPO_PER_TOPO_GROUP 2")]
        public const int NV_MOSAIC_MAX_TOPO_PER_TOPO_GROUP = 2;

        [NativeTypeName("#define NVAPI_MOSAIC_TOPO_GROUP_VER MAKE_NVAPI_VERSION(NV_MOSAIC_TOPO_GROUP,1)")]
        public static readonly uint NVAPI_MOSAIC_TOPO_GROUP_VER = unchecked((uint)(sizeof(NV_MOSAIC_TOPO_GROUP) | ((1) << 16)));

        [NativeTypeName("#define NV_MOSAIC_GRID_TOPO_VER1 MAKE_NVAPI_VERSION(NV_MOSAIC_GRID_TOPO_V1,1)")]
        public const uint NV_MOSAIC_GRID_TOPO_VER1 = (uint)(1320 | ((1) << 16));

        [NativeTypeName("#define NV_MOSAIC_GRID_TOPO_VER2 MAKE_NVAPI_VERSION(NV_MOSAIC_GRID_TOPO_V2,2)")]
        public const uint NV_MOSAIC_GRID_TOPO_VER2 = (uint)(1832 | ((2) << 16));

        [NativeTypeName("#define NV_MOSAIC_GRID_TOPO_VER NV_MOSAIC_GRID_TOPO_VER2")]
        public const uint NV_MOSAIC_GRID_TOPO_VER = (uint)(1832 | ((2) << 16));

        [NativeTypeName("#define NV_MOSAIC_DISPLAYCAPS_PROBLEM_DISPLAY_ON_INVALID_GPU NV_BIT(0)")]
        public const int NV_MOSAIC_DISPLAYCAPS_PROBLEM_DISPLAY_ON_INVALID_GPU = (1 << (0));

        [NativeTypeName("#define NV_MOSAIC_DISPLAYCAPS_PROBLEM_DISPLAY_ON_WRONG_CONNECTOR NV_BIT(1)")]
        public const int NV_MOSAIC_DISPLAYCAPS_PROBLEM_DISPLAY_ON_WRONG_CONNECTOR = (1 << (1));

        [NativeTypeName("#define NV_MOSAIC_DISPLAYCAPS_PROBLEM_NO_COMMON_TIMINGS NV_BIT(2)")]
        public const int NV_MOSAIC_DISPLAYCAPS_PROBLEM_NO_COMMON_TIMINGS = (1 << (2));

        [NativeTypeName("#define NV_MOSAIC_DISPLAYCAPS_PROBLEM_NO_EDID_AVAILABLE NV_BIT(3)")]
        public const int NV_MOSAIC_DISPLAYCAPS_PROBLEM_NO_EDID_AVAILABLE = (1 << (3));

        [NativeTypeName("#define NV_MOSAIC_DISPLAYCAPS_PROBLEM_MISMATCHED_OUTPUT_TYPE NV_BIT(4)")]
        public const int NV_MOSAIC_DISPLAYCAPS_PROBLEM_MISMATCHED_OUTPUT_TYPE = (1 << (4));

        [NativeTypeName("#define NV_MOSAIC_DISPLAYCAPS_PROBLEM_NO_DISPLAY_CONNECTED NV_BIT(5)")]
        public const int NV_MOSAIC_DISPLAYCAPS_PROBLEM_NO_DISPLAY_CONNECTED = (1 << (5));

        [NativeTypeName("#define NV_MOSAIC_DISPLAYCAPS_PROBLEM_NO_GPU_TOPOLOGY NV_BIT(6)")]
        public const int NV_MOSAIC_DISPLAYCAPS_PROBLEM_NO_GPU_TOPOLOGY = (1 << (6));

        [NativeTypeName("#define NV_MOSAIC_DISPLAYCAPS_PROBLEM_NOT_SUPPORTED NV_BIT(7)")]
        public const int NV_MOSAIC_DISPLAYCAPS_PROBLEM_NOT_SUPPORTED = (1 << (7));

        [NativeTypeName("#define NV_MOSAIC_DISPLAYCAPS_PROBLEM_NO_SLI_BRIDGE NV_BIT(8)")]
        public const int NV_MOSAIC_DISPLAYCAPS_PROBLEM_NO_SLI_BRIDGE = (1 << (8));

        [NativeTypeName("#define NV_MOSAIC_DISPLAYCAPS_PROBLEM_ECC_ENABLED NV_BIT(9)")]
        public const int NV_MOSAIC_DISPLAYCAPS_PROBLEM_ECC_ENABLED = (1 << (9));

        [NativeTypeName("#define NV_MOSAIC_DISPLAYCAPS_PROBLEM_GPU_TOPOLOGY_NOT_SUPPORTED NV_BIT(10)")]
        public const int NV_MOSAIC_DISPLAYCAPS_PROBLEM_GPU_TOPOLOGY_NOT_SUPPORTED = (1 << (10));

        [NativeTypeName("#define NV_MOSAIC_SETDISPLAYTOPO_FLAG_CURRENT_GPU_TOPOLOGY NV_BIT(0)")]
        public const int NV_MOSAIC_SETDISPLAYTOPO_FLAG_CURRENT_GPU_TOPOLOGY = (1 << (0));

        [NativeTypeName("#define NV_MOSAIC_SETDISPLAYTOPO_FLAG_NO_DRIVER_RELOAD NV_BIT(1)")]
        public const int NV_MOSAIC_SETDISPLAYTOPO_FLAG_NO_DRIVER_RELOAD = (1 << (1));

        [NativeTypeName("#define NV_MOSAIC_SETDISPLAYTOPO_FLAG_MAXIMIZE_PERFORMANCE NV_BIT(2)")]
        public const int NV_MOSAIC_SETDISPLAYTOPO_FLAG_MAXIMIZE_PERFORMANCE = (1 << (2));

        [NativeTypeName("#define NV_MOSAIC_SETDISPLAYTOPO_FLAG_ALLOW_INVALID NV_BIT(3)")]
        public const int NV_MOSAIC_SETDISPLAYTOPO_FLAG_ALLOW_INVALID = (1 << (3));

        [NativeTypeName("#define NV_MOSAIC_DISPLAYTOPO_WARNING_DISPLAY_POSITION NV_BIT(0)")]
        public const int NV_MOSAIC_DISPLAYTOPO_WARNING_DISPLAY_POSITION = (1 << (0));

        [NativeTypeName("#define NV_MOSAIC_DISPLAYTOPO_WARNING_DRIVER_RELOAD_REQUIRED NV_BIT(1)")]
        public const int NV_MOSAIC_DISPLAYTOPO_WARNING_DRIVER_RELOAD_REQUIRED = (1 << (1));

        [NativeTypeName("#define NV_MOSAIC_DISPLAY_TOPO_STATUS_VER MAKE_NVAPI_VERSION(NV_MOSAIC_DISPLAY_TOPO_STATUS,1)")]
        public const uint NV_MOSAIC_DISPLAY_TOPO_STATUS_VER = (uint)(2064 | ((1) << 16));

        [NativeTypeName("#define NVAPI_MAX_MOSAIC_TOPOS 16")]
        public const int NVAPI_MAX_MOSAIC_TOPOS = 16;

        [NativeTypeName("#define NVAPI_MOSAIC_TOPOLOGY_VER MAKE_NVAPI_VERSION(NV_MOSAIC_TOPOLOGY,1)")]
        public static readonly uint NVAPI_MOSAIC_TOPOLOGY_VER = unchecked((uint)(sizeof(NV_MOSAIC_TOPOLOGY) | ((1) << 16)));

        [NativeTypeName("#define NVAPI_MOSAIC_SUPPORTED_TOPOLOGIES_VER MAKE_NVAPI_VERSION(NV_MOSAIC_SUPPORTED_TOPOLOGIES,1)")]
        public static readonly uint NVAPI_MOSAIC_SUPPORTED_TOPOLOGIES_VER = unchecked((uint)(sizeof(NV_MOSAIC_SUPPORTED_TOPOLOGIES) | ((1) << 16)));

        [NativeTypeName("#define NVAPI_MAX_GSYNC_DEVICES 4")]
        public const int NVAPI_MAX_GSYNC_DEVICES = 4;

        [NativeTypeName("#define NVAPI_GSYNC_BOARD_ID_P358 856")]
        public const int NVAPI_GSYNC_BOARD_ID_P358 = 856;

        [NativeTypeName("#define NVAPI_GSYNC_BOARD_ID_P2060 8288")]
        public const int NVAPI_GSYNC_BOARD_ID_P2060 = 8288;

        [NativeTypeName("#define NVAPI_GSYNC_BOARD_ID_P2061 8289")]
        public const int NVAPI_GSYNC_BOARD_ID_P2061 = 8289;

        [NativeTypeName("#define NV_GSYNC_CAPABILITIES_VER1 MAKE_NVAPI_VERSION(NV_GSYNC_CAPABILITIES_V1,1)")]
        public const uint NV_GSYNC_CAPABILITIES_VER1 = (uint)(16 | ((1) << 16));

        [NativeTypeName("#define NV_GSYNC_CAPABILITIES_VER2 MAKE_NVAPI_VERSION(NV_GSYNC_CAPABILITIES_V2,2)")]
        public const uint NV_GSYNC_CAPABILITIES_VER2 = (uint)(20 | ((2) << 16));

        [NativeTypeName("#define NV_GSYNC_CAPABILITIES_VER3 MAKE_NVAPI_VERSION(NV_GSYNC_CAPABILITIES_V3,3)")]
        public const uint NV_GSYNC_CAPABILITIES_VER3 = (uint)(28 | ((3) << 16));

        [NativeTypeName("#define NV_GSYNC_CAPABILITIES_VER NV_GSYNC_CAPABILITIES_VER3")]
        public const uint NV_GSYNC_CAPABILITIES_VER = (uint)(28 | ((3) << 16));

        [NativeTypeName("#define NV_GSYNC_DISPLAY_VER MAKE_NVAPI_VERSION(NV_GSYNC_DISPLAY,1)")]
        public const uint NV_GSYNC_DISPLAY_VER = (uint)(16 | ((1) << 16));

        [NativeTypeName("#define NV_GSYNC_GPU_VER MAKE_NVAPI_VERSION(NV_GSYNC_GPU,1)")]
        public static readonly uint NV_GSYNC_GPU_VER = unchecked((uint)(sizeof(_NV_GSYNC_GPU) | ((1) << 16)));

        [NativeTypeName("#define NV_GSYNC_DELAY_VER MAKE_NVAPI_VERSION(NV_GSYNC_DELAY,1)")]
        public const uint NV_GSYNC_DELAY_VER = (uint)(20 | ((1) << 16));

        [NativeTypeName("#define NV_GSYNC_CONTROL_PARAMS_VER1 MAKE_NVAPI_VERSION(NV_GSYNC_CONTROL_PARAMS_V1,1)")]
        public const uint NV_GSYNC_CONTROL_PARAMS_VER1 = (uint)(64 | ((1) << 16));

        [NativeTypeName("#define NV_GSYNC_CONTROL_PARAMS_VER2 MAKE_NVAPI_VERSION(NV_GSYNC_CONTROL_PARAMS_V2,2)")]
        public const uint NV_GSYNC_CONTROL_PARAMS_VER2 = (uint)(72 | ((2) << 16));

        [NativeTypeName("#define NV_GSYNC_CONTROL_PARAMS_VER NV_GSYNC_CONTROL_PARAMS_VER2")]
        public const uint NV_GSYNC_CONTROL_PARAMS_VER = (uint)(72 | ((2) << 16));

        [NativeTypeName("#define NV_GSYNC_STATUS_VER MAKE_NVAPI_VERSION(NV_GSYNC_STATUS,1)")]
        public const uint NV_GSYNC_STATUS_VER = (uint)(16 | ((1) << 16));

        [NativeTypeName("#define NVAPI_MAX_RJ45_PER_GSYNC 2")]
        public const int NVAPI_MAX_RJ45_PER_GSYNC = 2;

        [NativeTypeName("#define NV_GSYNC_STATUS_PARAMS_VER1 MAKE_NVAPI_VERSION(NV_GSYNC_STATUS_PARAMS_V1,1)")]
        public const uint NV_GSYNC_STATUS_PARAMS_VER1 = (uint)(32 | ((1) << 16));

        [NativeTypeName("#define NV_GSYNC_STATUS_PARAMS_VER2 MAKE_NVAPI_VERSION(NV_GSYNC_STATUS_PARAMS_V2,2)")]
        public const uint NV_GSYNC_STATUS_PARAMS_VER2 = (uint)(36 | ((2) << 16));

        [NativeTypeName("#define NV_GSYNC_STATUS_PARAMS_VER NV_GSYNC_STATUS_PARAMS_VER2")]
        public const uint NV_GSYNC_STATUS_PARAMS_VER = (uint)(36 | ((2) << 16));

        [NativeTypeName("#define NV_JOIN_PRESENT_BARRIER_PARAMS_VER1 MAKE_NVAPI_VERSION(NV_JOIN_PRESENT_BARRIER_PARAMS, 1)")]
        public const uint NV_JOIN_PRESENT_BARRIER_PARAMS_VER1 = (uint)(4 | ((1) << 16));

        [NativeTypeName("#define NV_PRESENT_BARRIER_FRAME_STATICS_VER1 MAKE_NVAPI_VERSION(NV_PRESENT_BARRIER_FRAME_STATISTICS,1)")]
        public const uint NV_PRESENT_BARRIER_FRAME_STATICS_VER1 = (uint)(24 | ((1) << 16));

        [NativeTypeName("#define NVAPI_MAX_FRAMES_PER_FLIP_BATCH 8")]
        public const int NVAPI_MAX_FRAMES_PER_FLIP_BATCH = 8;

        [NativeTypeName("#define NV_QUERY_SINGLE_PASS_STEREO_SUPPORT_PARAMS_VER1 MAKE_NVAPI_VERSION(NV_QUERY_SINGLE_PASS_STEREO_SUPPORT_PARAMS_V1, 1)")]
        public const uint NV_QUERY_SINGLE_PASS_STEREO_SUPPORT_PARAMS_VER1 = (uint)(8 | ((1) << 16));

        [NativeTypeName("#define NV_QUERY_SINGLE_PASS_STEREO_SUPPORT_PARAMS_VER2 MAKE_NVAPI_VERSION(NV_QUERY_SINGLE_PASS_STEREO_SUPPORT_PARAMS_V2, 2)")]
        public const uint NV_QUERY_SINGLE_PASS_STEREO_SUPPORT_PARAMS_VER2 = (uint)(8 | ((2) << 16));

        [NativeTypeName("#define NV_QUERY_SINGLE_PASS_STEREO_SUPPORT_PARAMS_VER NV_QUERY_SINGLE_PASS_STEREO_SUPPORT_PARAMS_VER2")]
        public const uint NV_QUERY_SINGLE_PASS_STEREO_SUPPORT_PARAMS_VER = (uint)(8 | ((2) << 16));

        [NativeTypeName("#define NV_QUERY_MULTIVIEW_SUPPORT_PARAMS_VER1 MAKE_NVAPI_VERSION(NV_QUERY_MULTIVIEW_SUPPORT_PARAMS_V1, 1)")]
        public const uint NV_QUERY_MULTIVIEW_SUPPORT_PARAMS_VER1 = (uint)(8 | ((1) << 16));

        [NativeTypeName("#define NV_QUERY_MULTIVIEW_SUPPORT_PARAMS_VER NV_QUERY_MULTIVIEW_SUPPORT_PARAMS_VER1")]
        public const uint NV_QUERY_MULTIVIEW_SUPPORT_PARAMS_VER = (uint)(8 | ((1) << 16));

        [NativeTypeName("#define NV_MULTIVIEW_MAX_SUPPORTED_VIEWS 4")]
        public const int NV_MULTIVIEW_MAX_SUPPORTED_VIEWS = 4;

        [NativeTypeName("#define NV_MULTIVIEW_PARAMS_VER1 MAKE_NVAPI_VERSION(NV_MULTIVIEW_PARAMS_V1, 1)")]
        public const uint NV_MULTIVIEW_PARAMS_VER1 = (uint)(28 | ((1) << 16));

        [NativeTypeName("#define NV_MULTIVIEW_PARAMS_VER NV_MULTIVIEW_PARAMS_VER1")]
        public const uint NV_MULTIVIEW_PARAMS_VER = (uint)(28 | ((1) << 16));

        [NativeTypeName("#define NV_QUERY_MODIFIED_W_SUPPORT_PARAMS_VER1 MAKE_NVAPI_VERSION(NV_QUERY_MODIFIED_W_SUPPORT_PARAMS_V1, 1)")]
        public const uint NV_QUERY_MODIFIED_W_SUPPORT_PARAMS_VER1 = (uint)(8 | ((1) << 16));

        [NativeTypeName("#define NV_QUERY_MODIFIED_W_SUPPORT_PARAMS_VER NV_QUERY_MODIFIED_W_SUPPORT_PARAMS_VER1")]
        public const uint NV_QUERY_MODIFIED_W_SUPPORT_PARAMS_VER = (uint)(8 | ((1) << 16));

        [NativeTypeName("#define NV_MODIFIED_W_MAX_VIEWPORTS 16")]
        public const int NV_MODIFIED_W_MAX_VIEWPORTS = 16;

        [NativeTypeName("#define NV_MODIFIED_W_PARAMS_VER1 MAKE_NVAPI_VERSION(NV_MODIFIED_W_PARAMS_V1, 1)")]
        public const uint NV_MODIFIED_W_PARAMS_VER1 = (uint)(460 | ((1) << 16));

        [NativeTypeName("#define NV_MODIFIED_W_PARAMS_VER NV_MODIFIED_W_PARAMS_VER1")]
        public const uint NV_MODIFIED_W_PARAMS_VER = (uint)(460 | ((1) << 16));

        [NativeTypeName("#define NV_GET_SLEEP_STATUS_PARAMS_VER1 MAKE_NVAPI_VERSION(NV_GET_SLEEP_STATUS_PARAMS_V1, 1)")]
        public const uint NV_GET_SLEEP_STATUS_PARAMS_VER1 = (uint)(136 | ((1) << 16));

        [NativeTypeName("#define NV_GET_SLEEP_STATUS_PARAMS_VER NV_GET_SLEEP_STATUS_PARAMS_VER1")]
        public const uint NV_GET_SLEEP_STATUS_PARAMS_VER = (uint)(136 | ((1) << 16));

        [NativeTypeName("#define NV_SET_SLEEP_MODE_PARAMS_VER1 MAKE_NVAPI_VERSION(NV_SET_SLEEP_MODE_PARAMS_V1, 1)")]
        public const uint NV_SET_SLEEP_MODE_PARAMS_VER1 = (uint)(44 | ((1) << 16));

        [NativeTypeName("#define NV_SET_SLEEP_MODE_PARAMS_VER NV_SET_SLEEP_MODE_PARAMS_VER1")]
        public const uint NV_SET_SLEEP_MODE_PARAMS_VER = (uint)(44 | ((1) << 16));

        [NativeTypeName("#define NV_SET_REFLEX_SYNC_PARAMS_VER1 MAKE_NVAPI_VERSION(NV_SET_REFLEX_SYNC_PARAMS_V1, 1)")]
        public const uint NV_SET_REFLEX_SYNC_PARAMS_VER1 = (uint)(48 | ((1) << 16));

        [NativeTypeName("#define NV_SET_REFLEX_SYNC_PARAMS_VER NV_SET_REFLEX_SYNC_PARAMS_VER1")]
        public const uint NV_SET_REFLEX_SYNC_PARAMS_VER = (uint)(48 | ((1) << 16));

        [NativeTypeName("#define NV_LATENCY_RESULT_PARAMS_VER1 MAKE_NVAPI_VERSION(NV_LATENCY_RESULT_PARAMS_V1, 1)")]
        public const uint NV_LATENCY_RESULT_PARAMS_VER1 = (uint)(15400 | ((1) << 16));

        [NativeTypeName("#define NV_LATENCY_RESULT_PARAMS_VER NV_LATENCY_RESULT_PARAMS_VER1")]
        public const uint NV_LATENCY_RESULT_PARAMS_VER = (uint)(15400 | ((1) << 16));

        [NativeTypeName("#define NV_LATENCY_MARKER_PARAMS_VER1 MAKE_NVAPI_VERSION(NV_LATENCY_MARKER_PARAMS_V1, 1)")]
        public const uint NV_LATENCY_MARKER_PARAMS_VER1 = (uint)(88 | ((1) << 16));

        [NativeTypeName("#define NV_LATENCY_MARKER_PARAMS_VER NV_LATENCY_MARKER_PARAMS_VER1")]
        public const uint NV_LATENCY_MARKER_PARAMS_VER = (uint)(88 | ((1) << 16));

        [NativeTypeName("#define NV_ASYNC_FRAME_MARKER_PARAMS_VER1 MAKE_NVAPI_VERSION(NV_ASYNC_FRAME_MARKER_PARAMS_V1, 1)")]
        public const uint NV_ASYNC_FRAME_MARKER_PARAMS_VER1 = (uint)(88 | ((1) << 16));

        [NativeTypeName("#define NV_ASYNC_FRAME_MARKER_PARAMS_VER NV_ASYNC_FRAME_MARKER_PARAMS_VER1")]
        public const uint NV_ASYNC_FRAME_MARKER_PARAMS_VER = (uint)(88 | ((1) << 16));

        [NativeTypeName("#define NVAPI_D3D12_WORKSTATION_FEATURE_PROPERTIES_PARAMS_VER1 MAKE_NVAPI_VERSION(NVAPI_D3D12_WORKSTATION_FEATURE_PROPERTIES_PARAMS_V1,1)")]
        public const uint NVAPI_D3D12_WORKSTATION_FEATURE_PROPERTIES_PARAMS_VER1 = (uint)(24 | ((1) << 16));

        [NativeTypeName("#define NVAPI_D3D12_WORKSTATION_FEATURE_PROPERTIES_PARAMS_VER NVAPI_D3D12_WORKSTATION_FEATURE_PROPERTIES_PARAMS_VER1")]
        public const uint NVAPI_D3D12_WORKSTATION_FEATURE_PROPERTIES_PARAMS_VER = (uint)(24 | ((1) << 16));

        [NativeTypeName("#define NV_NGX_DLSS_OVERRIDE_FEATURE_INDEX_SR 1")]
        public const int NV_NGX_DLSS_OVERRIDE_FEATURE_INDEX_SR = 1;

        [NativeTypeName("#define NV_NGX_DLSS_OVERRIDE_FEATURE_INDEX_RR 2")]
        public const int NV_NGX_DLSS_OVERRIDE_FEATURE_INDEX_RR = 2;

        [NativeTypeName("#define NV_NGX_DLSS_OVERRIDE_FEATURE_INDEX_FG 3")]
        public const int NV_NGX_DLSS_OVERRIDE_FEATURE_INDEX_FG = 3;

        [NativeTypeName("#define NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_VER1 MAKE_NVAPI_VERSION(NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1, 1)")]
        public const uint NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_VER1 = (uint)(64 | ((1) << 16));

        [NativeTypeName("#define NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_VER NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_VER1")]
        public const uint NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_VER = (uint)(64 | ((1) << 16));

        [NativeTypeName("#define NV_NGX_DLSS_OVERRIDE_SET_STATE_PARAMS_VER1 MAKE_NVAPI_VERSION(NV_NGX_DLSS_OVERRIDE_SET_STATE_PARAMS_V1, 1)")]
        public const uint NV_NGX_DLSS_OVERRIDE_SET_STATE_PARAMS_VER1 = (uint)(56 | ((1) << 16));

        [NativeTypeName("#define NV_NGX_DLSS_OVERRIDE_SET_STATE_PARAMS_VER NV_NGX_DLSS_OVERRIDE_SET_STATE_PARAMS_VER1")]
        public const uint NV_NGX_DLSS_OVERRIDE_SET_STATE_PARAMS_VER = (uint)(56 | ((1) << 16));

        [NativeTypeName("#define NVVIOOWNERID_NONE 0")]
        public const int NVVIOOWNERID_NONE = 0;

        [NativeTypeName("#define NVVIO_O_READ 0x00000000")]
        public const int NVVIO_O_READ = 0x00000000;

        [NativeTypeName("#define NVVIO_O_WRITE_EXCLUSIVE 0x00010001")]
        public const int NVVIO_O_WRITE_EXCLUSIVE = 0x00010001;

        [NativeTypeName("#define NVVIO_VALID_ACCESSRIGHTS (NVVIO_O_READ              | \\\n                                             NVVIO_O_WRITE_EXCLUSIVE   )")]
        public const int NVVIO_VALID_ACCESSRIGHTS = (0x00000000 | 0x00010001);

        [NativeTypeName("#define NVVIO_OWNERID_INITIALIZED 0x80000000")]
        public const uint NVVIO_OWNERID_INITIALIZED = 0x80000000;

        [NativeTypeName("#define NVVIO_OWNERID_EXCLUSIVE 0x40000000")]
        public const int NVVIO_OWNERID_EXCLUSIVE = 0x40000000;

        [NativeTypeName("#define NVVIO_OWNERID_TYPEMASK 0x0FFFFFFF")]
        public const int NVVIO_OWNERID_TYPEMASK = 0x0FFFFFFF;

        [NativeTypeName("#define NVAPI_MAX_VIO_DEVICES 8")]
        public const int NVAPI_MAX_VIO_DEVICES = 8;

        [NativeTypeName("#define NVAPI_MAX_VIO_JACKS 4")]
        public const int NVAPI_MAX_VIO_JACKS = 4;

        [NativeTypeName("#define NVAPI_MAX_VIO_CHANNELS_PER_JACK 2")]
        public const int NVAPI_MAX_VIO_CHANNELS_PER_JACK = 2;

        [NativeTypeName("#define NVAPI_MAX_VIO_STREAMS 4")]
        public const int NVAPI_MAX_VIO_STREAMS = 4;

        [NativeTypeName("#define NVAPI_MIN_VIO_STREAMS 1")]
        public const int NVAPI_MIN_VIO_STREAMS = 1;

        [NativeTypeName("#define NVAPI_MAX_VIO_LINKS_PER_STREAM 2")]
        public const int NVAPI_MAX_VIO_LINKS_PER_STREAM = 2;

        [NativeTypeName("#define NVAPI_MAX_FRAMELOCK_MAPPING_MODES 20")]
        public const int NVAPI_MAX_FRAMELOCK_MAPPING_MODES = 20;

        [NativeTypeName("#define NVAPI_GVI_MIN_RAW_CAPTURE_IMAGES 1")]
        public const int NVAPI_GVI_MIN_RAW_CAPTURE_IMAGES = 1;

        [NativeTypeName("#define NVAPI_GVI_MAX_RAW_CAPTURE_IMAGES 32")]
        public const int NVAPI_GVI_MAX_RAW_CAPTURE_IMAGES = 32;

        [NativeTypeName("#define NVAPI_GVI_DEFAULT_RAW_CAPTURE_IMAGES 5")]
        public const int NVAPI_GVI_DEFAULT_RAW_CAPTURE_IMAGES = 5;

        [NativeTypeName("#define NVVIOCAPS_VIDOUT_SDI 0x00000001")]
        public const int NVVIOCAPS_VIDOUT_SDI = 0x00000001;

        [NativeTypeName("#define NVVIOCAPS_SYNC_INTERNAL 0x00000100")]
        public const int NVVIOCAPS_SYNC_INTERNAL = 0x00000100;

        [NativeTypeName("#define NVVIOCAPS_SYNC_GENLOCK 0x00000200")]
        public const int NVVIOCAPS_SYNC_GENLOCK = 0x00000200;

        [NativeTypeName("#define NVVIOCAPS_SYNCSRC_SDI 0x00001000")]
        public const int NVVIOCAPS_SYNCSRC_SDI = 0x00001000;

        [NativeTypeName("#define NVVIOCAPS_SYNCSRC_COMP 0x00002000")]
        public const int NVVIOCAPS_SYNCSRC_COMP = 0x00002000;

        [NativeTypeName("#define NVVIOCAPS_OUTPUTMODE_DESKTOP 0x00010000")]
        public const int NVVIOCAPS_OUTPUTMODE_DESKTOP = 0x00010000;

        [NativeTypeName("#define NVVIOCAPS_OUTPUTMODE_OPENGL 0x00020000")]
        public const int NVVIOCAPS_OUTPUTMODE_OPENGL = 0x00020000;

        [NativeTypeName("#define NVVIOCAPS_VIDIN_SDI 0x00100000")]
        public const int NVVIOCAPS_VIDIN_SDI = 0x00100000;

        [NativeTypeName("#define NVVIOCAPS_PACKED_ANC_SUPPORTED 0x00200000")]
        public const int NVVIOCAPS_PACKED_ANC_SUPPORTED = 0x00200000;

        [NativeTypeName("#define NVVIOCAPS_AUDIO_BLANKING_SUPPORTED 0x00400000")]
        public const int NVVIOCAPS_AUDIO_BLANKING_SUPPORTED = 0x00400000;

        [NativeTypeName("#define NVVIOCLASS_SDI 0x00000001")]
        public const int NVVIOCLASS_SDI = 0x00000001;

        [NativeTypeName("#define NVVIOCAPS_VER1 MAKE_NVAPI_VERSION(NVVIOCAPS,1)")]
        public const uint NVVIOCAPS_VER1 = (uint)(4144 | ((1) << 16));

        [NativeTypeName("#define NVVIOCAPS_VER2 MAKE_NVAPI_VERSION(NVVIOCAPS,2)")]
        public const uint NVVIOCAPS_VER2 = (uint)(4144 | ((2) << 16));

        [NativeTypeName("#define NVVIOCAPS_VER NVVIOCAPS_VER2")]
        public const uint NVVIOCAPS_VER = (uint)(4144 | ((2) << 16));

        [NativeTypeName("#define NVVIOSTATUS_VER MAKE_NVAPI_VERSION(NVVIOSTATUS,1)")]
        public const uint NVVIOSTATUS_VER = (uint)(204 | ((1) << 16));

        [NativeTypeName("#define NVVIOSYNCDELAY_VER MAKE_NVAPI_VERSION(NVVIOSYNCDELAY,1)")]
        public const uint NVVIOSYNCDELAY_VER = (uint)(12 | ((1) << 16));

        [NativeTypeName("#define NVVIOBUFFERFORMAT_R8G8B8 0x00000001")]
        public const int NVVIOBUFFERFORMAT_R8G8B8 = 0x00000001;

        [NativeTypeName("#define NVVIOBUFFERFORMAT_R8G8B8Z24 0x00000002")]
        public const int NVVIOBUFFERFORMAT_R8G8B8Z24 = 0x00000002;

        [NativeTypeName("#define NVVIOBUFFERFORMAT_R8G8B8A8 0x00000004")]
        public const int NVVIOBUFFERFORMAT_R8G8B8A8 = 0x00000004;

        [NativeTypeName("#define NVVIOBUFFERFORMAT_R8G8B8A8Z24 0x00000008")]
        public const int NVVIOBUFFERFORMAT_R8G8B8A8Z24 = 0x00000008;

        [NativeTypeName("#define NVVIOBUFFERFORMAT_R16FPG16FPB16FP 0x00000010")]
        public const int NVVIOBUFFERFORMAT_R16FPG16FPB16FP = 0x00000010;

        [NativeTypeName("#define NVVIOBUFFERFORMAT_R16FPG16FPB16FPZ24 0x00000020")]
        public const int NVVIOBUFFERFORMAT_R16FPG16FPB16FPZ24 = 0x00000020;

        [NativeTypeName("#define NVVIOBUFFERFORMAT_R16FPG16FPB16FPA16FP 0x00000040")]
        public const int NVVIOBUFFERFORMAT_R16FPG16FPB16FPA16FP = 0x00000040;

        [NativeTypeName("#define NVVIOBUFFERFORMAT_R16FPG16FPB16FPA16FPZ24 0x00000080")]
        public const int NVVIOBUFFERFORMAT_R16FPG16FPB16FPA16FPZ24 = 0x00000080;

        [NativeTypeName("#define NVVIOCOLORCONVERSION_VER MAKE_NVAPI_VERSION(NVVIOCOLORCONVERSION,1)")]
        public const uint NVVIOCOLORCONVERSION_VER = (uint)(68 | ((1) << 16));

        [NativeTypeName("#define NVVIOGAMMACORRECTION_VER MAKE_NVAPI_VERSION(NVVIOGAMMACORRECTION,1)")]
        public const uint NVVIOGAMMACORRECTION_VER = (uint)(6164 | ((1) << 16));

        [NativeTypeName("#define MAX_NUM_COMPOSITE_RANGE 2")]
        public const int MAX_NUM_COMPOSITE_RANGE = 2;

        [NativeTypeName("#define NVVIOCONFIG_SIGNALFORMAT 0x00000001")]
        public const int NVVIOCONFIG_SIGNALFORMAT = 0x00000001;

        [NativeTypeName("#define NVVIOCONFIG_DATAFORMAT 0x00000002")]
        public const int NVVIOCONFIG_DATAFORMAT = 0x00000002;

        [NativeTypeName("#define NVVIOCONFIG_OUTPUTREGION 0x00000004")]
        public const int NVVIOCONFIG_OUTPUTREGION = 0x00000004;

        [NativeTypeName("#define NVVIOCONFIG_OUTPUTAREA 0x00000008")]
        public const int NVVIOCONFIG_OUTPUTAREA = 0x00000008;

        [NativeTypeName("#define NVVIOCONFIG_COLORCONVERSION 0x00000010")]
        public const int NVVIOCONFIG_COLORCONVERSION = 0x00000010;

        [NativeTypeName("#define NVVIOCONFIG_GAMMACORRECTION 0x00000020")]
        public const int NVVIOCONFIG_GAMMACORRECTION = 0x00000020;

        [NativeTypeName("#define NVVIOCONFIG_SYNCSOURCEENABLE 0x00000040")]
        public const int NVVIOCONFIG_SYNCSOURCEENABLE = 0x00000040;

        [NativeTypeName("#define NVVIOCONFIG_SYNCDELAY 0x00000080")]
        public const int NVVIOCONFIG_SYNCDELAY = 0x00000080;

        [NativeTypeName("#define NVVIOCONFIG_COMPOSITESYNCTYPE 0x00000100")]
        public const int NVVIOCONFIG_COMPOSITESYNCTYPE = 0x00000100;

        [NativeTypeName("#define NVVIOCONFIG_FRAMELOCKENABLE 0x00000200")]
        public const int NVVIOCONFIG_FRAMELOCKENABLE = 0x00000200;

        [NativeTypeName("#define NVVIOCONFIG_422FILTER 0x00000400")]
        public const int NVVIOCONFIG_422FILTER = 0x00000400;

        [NativeTypeName("#define NVVIOCONFIG_COMPOSITETERMINATE 0x00000800")]
        public const int NVVIOCONFIG_COMPOSITETERMINATE = 0x00000800;

        [NativeTypeName("#define NVVIOCONFIG_DATAINTEGRITYCHECK 0x00001000")]
        public const int NVVIOCONFIG_DATAINTEGRITYCHECK = 0x00001000;

        [NativeTypeName("#define NVVIOCONFIG_CSCOVERRIDE 0x00002000")]
        public const int NVVIOCONFIG_CSCOVERRIDE = 0x00002000;

        [NativeTypeName("#define NVVIOCONFIG_FLIPQUEUELENGTH 0x00004000")]
        public const int NVVIOCONFIG_FLIPQUEUELENGTH = 0x00004000;

        [NativeTypeName("#define NVVIOCONFIG_ANCTIMECODEGENERATION 0x00008000")]
        public const int NVVIOCONFIG_ANCTIMECODEGENERATION = 0x00008000;

        [NativeTypeName("#define NVVIOCONFIG_COMPOSITE 0x00010000")]
        public const int NVVIOCONFIG_COMPOSITE = 0x00010000;

        [NativeTypeName("#define NVVIOCONFIG_ALPHAKEYCOMPOSITE 0x00020000")]
        public const int NVVIOCONFIG_ALPHAKEYCOMPOSITE = 0x00020000;

        [NativeTypeName("#define NVVIOCONFIG_COMPOSITE_Y 0x00040000")]
        public const int NVVIOCONFIG_COMPOSITE_Y = 0x00040000;

        [NativeTypeName("#define NVVIOCONFIG_COMPOSITE_CR 0x00080000")]
        public const int NVVIOCONFIG_COMPOSITE_CR = 0x00080000;

        [NativeTypeName("#define NVVIOCONFIG_COMPOSITE_CB 0x00100000")]
        public const int NVVIOCONFIG_COMPOSITE_CB = 0x00100000;

        [NativeTypeName("#define NVVIOCONFIG_FULL_COLOR_RANGE 0x00200000")]
        public const int NVVIOCONFIG_FULL_COLOR_RANGE = 0x00200000;

        [NativeTypeName("#define NVVIOCONFIG_RGB_DATA 0x00400000")]
        public const int NVVIOCONFIG_RGB_DATA = 0x00400000;

        [NativeTypeName("#define NVVIOCONFIG_RESERVED_SDIOUTPUTENABLE 0x00800000")]
        public const int NVVIOCONFIG_RESERVED_SDIOUTPUTENABLE = 0x00800000;

        [NativeTypeName("#define NVVIOCONFIG_STREAMS 0x01000000")]
        public const int NVVIOCONFIG_STREAMS = 0x01000000;

        [NativeTypeName("#define NVVIOCONFIG_ANC_PARITY_COMPUTATION 0x02000000")]
        public const int NVVIOCONFIG_ANC_PARITY_COMPUTATION = 0x02000000;

        [NativeTypeName("#define NVVIOCONFIG_ANC_AUDIO_REPEAT 0x04000000")]
        public const int NVVIOCONFIG_ANC_AUDIO_REPEAT = 0x04000000;

        [NativeTypeName("#define NVVIOCONFIG_ALLFIELDS ( NVVIOCONFIG_SIGNALFORMAT          | \\\n                                  NVVIOCONFIG_DATAFORMAT            | \\\n                                  NVVIOCONFIG_OUTPUTREGION          | \\\n                                  NVVIOCONFIG_OUTPUTAREA            | \\\n                                  NVVIOCONFIG_COLORCONVERSION       | \\\n                                  NVVIOCONFIG_GAMMACORRECTION       | \\\n                                  NVVIOCONFIG_SYNCSOURCEENABLE      | \\\n                                  NVVIOCONFIG_SYNCDELAY             | \\\n                                  NVVIOCONFIG_COMPOSITESYNCTYPE     | \\\n                                  NVVIOCONFIG_FRAMELOCKENABLE       | \\\n                                  NVVIOCONFIG_422FILTER             | \\\n                                  NVVIOCONFIG_COMPOSITETERMINATE    | \\\n                                  NVVIOCONFIG_DATAINTEGRITYCHECK    | \\\n                                  NVVIOCONFIG_CSCOVERRIDE           | \\\n                                  NVVIOCONFIG_FLIPQUEUELENGTH       | \\\n                                  NVVIOCONFIG_ANCTIMECODEGENERATION | \\\n                                  NVVIOCONFIG_COMPOSITE             | \\\n                                  NVVIOCONFIG_ALPHAKEYCOMPOSITE     | \\\n                                  NVVIOCONFIG_COMPOSITE_Y           | \\\n                                  NVVIOCONFIG_COMPOSITE_CR          | \\\n                                  NVVIOCONFIG_COMPOSITE_CB          | \\\n                                  NVVIOCONFIG_FULL_COLOR_RANGE      | \\\n                                  NVVIOCONFIG_RGB_DATA              | \\\n                                  NVVIOCONFIG_RESERVED_SDIOUTPUTENABLE | \\\n                                  NVVIOCONFIG_STREAMS               | \\\n                                  NVVIOCONFIG_ANC_PARITY_COMPUTATION | \\\n\t\t\t\t\t\t\t\t  NVVIOCONFIG_ANC_AUDIO_REPEAT )")]
        public const int NVVIOCONFIG_ALLFIELDS = (0x00000001 | 0x00000002 | 0x00000004 | 0x00000008 | 0x00000010 | 0x00000020 | 0x00000040 | 0x00000080 | 0x00000100 | 0x00000200 | 0x00000400 | 0x00000800 | 0x00001000 | 0x00002000 | 0x00004000 | 0x00008000 | 0x00010000 | 0x00020000 | 0x00040000 | 0x00080000 | 0x00100000 | 0x00200000 | 0x00400000 | 0x00800000 | 0x01000000 | 0x02000000 | 0x04000000);

        [NativeTypeName("#define NVVIOCONFIG_VALIDFIELDS ( NVVIOCONFIG_SIGNALFORMAT          | \\\n                                   NVVIOCONFIG_DATAFORMAT            | \\\n                                   NVVIOCONFIG_OUTPUTREGION          | \\\n                                   NVVIOCONFIG_OUTPUTAREA            | \\\n                                   NVVIOCONFIG_COLORCONVERSION       | \\\n                                   NVVIOCONFIG_GAMMACORRECTION       | \\\n                                   NVVIOCONFIG_SYNCSOURCEENABLE      | \\\n                                   NVVIOCONFIG_SYNCDELAY             | \\\n                                   NVVIOCONFIG_COMPOSITESYNCTYPE     | \\\n                                   NVVIOCONFIG_FRAMELOCKENABLE       | \\\n                                   NVVIOCONFIG_RESERVED_SDIOUTPUTENABLE | \\\n                                   NVVIOCONFIG_422FILTER             | \\\n                                   NVVIOCONFIG_COMPOSITETERMINATE    | \\\n                                   NVVIOCONFIG_DATAINTEGRITYCHECK    | \\\n                                   NVVIOCONFIG_CSCOVERRIDE           | \\\n                                   NVVIOCONFIG_FLIPQUEUELENGTH       | \\\n                                   NVVIOCONFIG_ANCTIMECODEGENERATION | \\\n                                   NVVIOCONFIG_COMPOSITE             | \\\n                                   NVVIOCONFIG_ALPHAKEYCOMPOSITE     | \\\n                                   NVVIOCONFIG_COMPOSITE_Y           | \\\n                                   NVVIOCONFIG_COMPOSITE_CR          | \\\n                                   NVVIOCONFIG_COMPOSITE_CB          | \\\n                                   NVVIOCONFIG_FULL_COLOR_RANGE      | \\\n                                   NVVIOCONFIG_RGB_DATA              | \\\n                                   NVVIOCONFIG_RESERVED_SDIOUTPUTENABLE | \\\n                                   NVVIOCONFIG_STREAMS               | \\\n                                   NVVIOCONFIG_ANC_PARITY_COMPUTATION | \\\n\t\t\t\t\t\t\t\t   NVVIOCONFIG_ANC_AUDIO_REPEAT)")]
        public const int NVVIOCONFIG_VALIDFIELDS = (0x00000001 | 0x00000002 | 0x00000004 | 0x00000008 | 0x00000010 | 0x00000020 | 0x00000040 | 0x00000080 | 0x00000100 | 0x00000200 | 0x00800000 | 0x00000400 | 0x00000800 | 0x00001000 | 0x00002000 | 0x00004000 | 0x00008000 | 0x00010000 | 0x00020000 | 0x00040000 | 0x00080000 | 0x00100000 | 0x00200000 | 0x00400000 | 0x00800000 | 0x01000000 | 0x02000000 | 0x04000000);

        [NativeTypeName("#define NVVIOCONFIG_DRIVERFIELDS ( NVVIOCONFIG_OUTPUTREGION          | \\\n                                   NVVIOCONFIG_OUTPUTAREA            | \\\n                                   NVVIOCONFIG_COLORCONVERSION       | \\\n                                   NVVIOCONFIG_FLIPQUEUELENGTH)")]
        public const int NVVIOCONFIG_DRIVERFIELDS = (0x00000004 | 0x00000008 | 0x00000010 | 0x00004000);

        [NativeTypeName("#define NVVIOCONFIG_GAMMAFIELDS ( NVVIOCONFIG_GAMMACORRECTION       )")]
        public const int NVVIOCONFIG_GAMMAFIELDS = (0x00000020);

        [NativeTypeName("#define NVVIOCONFIG_RMCTRLFIELDS ( NVVIOCONFIG_SIGNALFORMAT          | \\\n                                   NVVIOCONFIG_DATAFORMAT            | \\\n                                   NVVIOCONFIG_SYNCSOURCEENABLE      | \\\n                                   NVVIOCONFIG_COMPOSITESYNCTYPE     | \\\n                                   NVVIOCONFIG_FRAMELOCKENABLE       | \\\n                                   NVVIOCONFIG_422FILTER             | \\\n                                   NVVIOCONFIG_COMPOSITETERMINATE    | \\\n                                   NVVIOCONFIG_DATAINTEGRITYCHECK    | \\\n                                   NVVIOCONFIG_COMPOSITE             | \\\n                                   NVVIOCONFIG_ALPHAKEYCOMPOSITE     | \\\n                                   NVVIOCONFIG_COMPOSITE_Y           | \\\n                                   NVVIOCONFIG_COMPOSITE_CR          | \\\n                                   NVVIOCONFIG_COMPOSITE_CB)")]
        public const int NVVIOCONFIG_RMCTRLFIELDS = (0x00000001 | 0x00000002 | 0x00000040 | 0x00000100 | 0x00000200 | 0x00000400 | 0x00000800 | 0x00001000 | 0x00010000 | 0x00020000 | 0x00040000 | 0x00080000 | 0x00100000);

        [NativeTypeName("#define NVVIOCONFIG_RMSKEWFIELDS ( NVVIOCONFIG_SYNCDELAY             )")]
        public const int NVVIOCONFIG_RMSKEWFIELDS = (0x00000080);

        [NativeTypeName("#define NVVIOCONFIG_ALLOWSDIRUNNING_FIELDS ( NVVIOCONFIG_DATAINTEGRITYCHECK     | \\\n                                             NVVIOCONFIG_SYNCDELAY              | \\\n                                             NVVIOCONFIG_CSCOVERRIDE            | \\\n                                             NVVIOCONFIG_ANCTIMECODEGENERATION  | \\\n                                             NVVIOCONFIG_COMPOSITE              | \\\n                                             NVVIOCONFIG_ALPHAKEYCOMPOSITE      | \\\n                                             NVVIOCONFIG_COMPOSITE_Y            | \\\n                                             NVVIOCONFIG_COMPOSITE_CR           | \\\n                                             NVVIOCONFIG_COMPOSITE_CB           | \\\n                                             NVVIOCONFIG_ANC_PARITY_COMPUTATION)")]
        public const int NVVIOCONFIG_ALLOWSDIRUNNING_FIELDS = (0x00001000 | 0x00000080 | 0x00002000 | 0x00008000 | 0x00010000 | 0x00020000 | 0x00040000 | 0x00080000 | 0x00100000 | 0x02000000);

        [NativeTypeName("#define NVVIOCONFIG_RMMODESET_FIELDS ( NVVIOCONFIG_SIGNALFORMAT         | \\\n                                        NVVIOCONFIG_DATAFORMAT           | \\\n                                        NVVIOCONFIG_SYNCSOURCEENABLE     | \\\n                                        NVVIOCONFIG_FRAMELOCKENABLE      | \\\n                                        NVVIOCONFIG_COMPOSITESYNCTYPE\t | \\\n\t\t\t\t\t\t\t\t\t\tNVVIOCONFIG_ANC_AUDIO_REPEAT)")]
        public const int NVVIOCONFIG_RMMODESET_FIELDS = (0x00000001 | 0x00000002 | 0x00000040 | 0x00000200 | 0x00000100 | 0x04000000);

        [NativeTypeName("#define NVVIOCONFIG_VER1 MAKE_NVAPI_VERSION(NVVIOCONFIG_V1,1)")]
        public const uint NVVIOCONFIG_VER1 = (uint)(6616 | ((1) << 16));

        [NativeTypeName("#define NVVIOCONFIG_VER2 MAKE_NVAPI_VERSION(NVVIOCONFIG_V2,2)")]
        public const uint NVVIOCONFIG_VER2 = (uint)(6620 | ((2) << 16));

        [NativeTypeName("#define NVVIOCONFIG_VER3 MAKE_NVAPI_VERSION(NVVIOCONFIG_V3,3)")]
        public const uint NVVIOCONFIG_VER3 = (uint)(6624 | ((3) << 16));

        [NativeTypeName("#define NVVIOCONFIG_VER NVVIOCONFIG_VER3")]
        public const uint NVVIOCONFIG_VER = (uint)(6624 | ((3) << 16));

        [NativeTypeName("#define NV_VIO_TOPOLOGY_VER MAKE_NVAPI_VERSION(NV_VIO_TOPOLOGY,1)")]
        public static readonly uint NV_VIO_TOPOLOGY_VER = unchecked((uint)(sizeof(_NV_VIO_TOPOLOGY) | ((1) << 16)));

        [NativeTypeName("#define NVVIOTOPOLOGY_VER MAKE_NVAPI_VERSION(NVVIOTOPOLOGY,1)")]
        public static readonly uint NVVIOTOPOLOGY_VER = unchecked((uint)(sizeof(_NV_VIO_TOPOLOGY) | ((1) << 16)));

        [NativeTypeName("#define NVVIOPCIINFO_VER1 MAKE_NVAPI_VERSION(NVVIOPCIINFO_V1,1)")]
        public const uint NVVIOPCIINFO_VER1 = (uint)(36 | ((1) << 16));

        [NativeTypeName("#define NVVIOPCIINFO_VER NVVIOPCIINFO_VER1")]
        public const uint NVVIOPCIINFO_VER = (uint)(36 | ((1) << 16));

        [NativeTypeName("#define NVAPI_STEREO_CAPS_VER1 MAKE_NVAPI_VERSION(NVAPI_STEREO_CAPS,1)")]
        public const uint NVAPI_STEREO_CAPS_VER1 = (uint)(20 | ((1) << 16));

        [NativeTypeName("#define NVAPI_STEREO_CAPS_VER NVAPI_STEREO_CAPS_VER1")]
        public const uint NVAPI_STEREO_CAPS_VER = (uint)(20 | ((1) << 16));

        [NativeTypeName("#define NVAPI_STEREO_QUADBUFFERED_API_VERSION 0x2")]
        public const int NVAPI_STEREO_QUADBUFFERED_API_VERSION = 0x2;

        [NativeTypeName("#define NV_VULKAN_GET_SLEEP_STATUS_PARAMS_VER1 MAKE_NVAPI_VERSION(NV_VULKAN_GET_SLEEP_STATUS_PARAMS_V1, 1)")]
        public const uint NV_VULKAN_GET_SLEEP_STATUS_PARAMS_VER1 = (uint)(136 | ((1) << 16));

        [NativeTypeName("#define NV_VULKAN_GET_SLEEP_STATUS_PARAMS_VER NV_VULKAN_GET_SLEEP_STATUS_PARAMS_VER1")]
        public const uint NV_VULKAN_GET_SLEEP_STATUS_PARAMS_VER = (uint)(136 | ((1) << 16));

        [NativeTypeName("#define NV_VULKAN_SET_SLEEP_MODE_PARAMS_VER1 MAKE_NVAPI_VERSION(NV_VULKAN_SET_SLEEP_MODE_PARAMS_V1, 1)")]
        public const uint NV_VULKAN_SET_SLEEP_MODE_PARAMS_VER1 = (uint)(44 | ((1) << 16));

        [NativeTypeName("#define NV_VULKAN_SET_SLEEP_MODE_PARAMS_VER NV_VULKAN_SET_SLEEP_MODE_PARAMS_VER1")]
        public const uint NV_VULKAN_SET_SLEEP_MODE_PARAMS_VER = (uint)(44 | ((1) << 16));

        [NativeTypeName("#define NV_VULKAN_LATENCY_RESULT_PARAMS_VER1 MAKE_NVAPI_VERSION(NV_VULKAN_LATENCY_RESULT_PARAMS_V1, 1)")]
        public const uint NV_VULKAN_LATENCY_RESULT_PARAMS_VER1 = (uint)(15400 | ((1) << 16));

        [NativeTypeName("#define NV_VULKAN_LATENCY_RESULT_PARAMS_VER NV_VULKAN_LATENCY_RESULT_PARAMS_VER1")]
        public const uint NV_VULKAN_LATENCY_RESULT_PARAMS_VER = (uint)(15400 | ((1) << 16));

        [NativeTypeName("#define NV_VULKAN_LATENCY_MARKER_PARAMS_VER1 MAKE_NVAPI_VERSION(NV_VULKAN_LATENCY_MARKER_PARAMS_V1, 1)")]
        public const uint NV_VULKAN_LATENCY_MARKER_PARAMS_VER1 = (uint)(88 | ((1) << 16));

        [NativeTypeName("#define NV_VULKAN_LATENCY_MARKER_PARAMS_VER NV_VULKAN_LATENCY_MARKER_PARAMS_VER1")]
        public const uint NV_VULKAN_LATENCY_MARKER_PARAMS_VER = (uint)(88 | ((1) << 16));

        [NativeTypeName("#define NVAPI_DRS_GLOBAL_PROFILE ((NvDRSProfileHandle) -1)")]
        public static readonly NvDRSProfileHandle__* NVAPI_DRS_GLOBAL_PROFILE = unchecked((NvDRSProfileHandle__*)(-1));

        [NativeTypeName("#define NVAPI_SETTING_MAX_VALUES 100")]
        public const int NVAPI_SETTING_MAX_VALUES = 100;

        [NativeTypeName("#define NVDRS_SETTING_VALUES_VER MAKE_NVAPI_VERSION(NVDRS_SETTING_VALUES,1)")]
        public const uint NVDRS_SETTING_VALUES_VER = (uint)(414112 | ((1) << 16));

        [NativeTypeName("#define NVDRS_SETTING_VER1 MAKE_NVAPI_VERSION(NVDRS_SETTING_V1, 1)")]
        public const uint NVDRS_SETTING_VER1 = (uint)(12320 | ((1) << 16));

        [NativeTypeName("#define NVDRS_SETTING_VER NVDRS_SETTING_VER1")]
        public const uint NVDRS_SETTING_VER = (uint)(12320 | ((1) << 16));

        [NativeTypeName("#define NVDRS_APPLICATION_VER_V1 MAKE_NVAPI_VERSION(NVDRS_APPLICATION_V1,1)")]
        public const uint NVDRS_APPLICATION_VER_V1 = (uint)(12296 | ((1) << 16));

        [NativeTypeName("#define NVDRS_APPLICATION_VER_V2 MAKE_NVAPI_VERSION(NVDRS_APPLICATION_V2,2)")]
        public const uint NVDRS_APPLICATION_VER_V2 = (uint)(16392 | ((2) << 16));

        [NativeTypeName("#define NVDRS_APPLICATION_VER_V3 MAKE_NVAPI_VERSION(NVDRS_APPLICATION_V3,3)")]
        public const uint NVDRS_APPLICATION_VER_V3 = (uint)(16396 | ((3) << 16));

        [NativeTypeName("#define NVDRS_APPLICATION_VER_V4 MAKE_NVAPI_VERSION(NVDRS_APPLICATION_V4,4)")]
        public const uint NVDRS_APPLICATION_VER_V4 = (uint)(20492 | ((4) << 16));

        [NativeTypeName("#define NVDRS_APPLICATION_VER NVDRS_APPLICATION_VER_V4")]
        public const uint NVDRS_APPLICATION_VER = (uint)(20492 | ((4) << 16));

        [NativeTypeName("#define NVDRS_PROFILE_VER1 MAKE_NVAPI_VERSION(NVDRS_PROFILE_V1,1)")]
        public const uint NVDRS_PROFILE_VER1 = (uint)(4116 | ((1) << 16));

        [NativeTypeName("#define NVDRS_PROFILE_VER NVDRS_PROFILE_VER1")]
        public const uint NVDRS_PROFILE_VER = (uint)(4116 | ((1) << 16));

        [NativeTypeName("#define NV_CHIPSET_INFO_VER_1 MAKE_NVAPI_VERSION(NV_CHIPSET_INFO_v1,1)")]
        public const uint NV_CHIPSET_INFO_VER_1 = (uint)(140 | ((1) << 16));

        [NativeTypeName("#define NV_CHIPSET_INFO_VER_2 MAKE_NVAPI_VERSION(NV_CHIPSET_INFO_v2,2)")]
        public const uint NV_CHIPSET_INFO_VER_2 = (uint)(144 | ((2) << 16));

        [NativeTypeName("#define NV_CHIPSET_INFO_VER_3 MAKE_NVAPI_VERSION(NV_CHIPSET_INFO_v3,3)")]
        public const uint NV_CHIPSET_INFO_VER_3 = (uint)(216 | ((3) << 16));

        [NativeTypeName("#define NV_CHIPSET_INFO_VER_4 MAKE_NVAPI_VERSION(NV_CHIPSET_INFO_v4,4)")]
        public const uint NV_CHIPSET_INFO_VER_4 = (uint)(232 | ((4) << 16));

        [NativeTypeName("#define NV_CHIPSET_INFO_VER NV_CHIPSET_INFO_VER_4")]
        public const uint NV_CHIPSET_INFO_VER = (uint)(232 | ((4) << 16));

        [NativeTypeName("#define NV_LID_DOCK_PARAMS_VER MAKE_NVAPI_VERSION(NV_LID_DOCK_PARAMS,1)")]
        public const uint NV_LID_DOCK_PARAMS_VER = (uint)(28 | ((1) << 16));

        [NativeTypeName("#define NV_DISPLAY_DRIVER_INFO_VER1 MAKE_NVAPI_VERSION(NV_DISPLAY_DRIVER_INFO_V1, 1)")]
        public const uint NV_DISPLAY_DRIVER_INFO_VER1 = (uint)(76 | ((1) << 16));

        [NativeTypeName("#define NV_DISPLAY_DRIVER_INFO_VER2 MAKE_NVAPI_VERSION(NV_DISPLAY_DRIVER_INFO_V2, 2)")]
        public const uint NV_DISPLAY_DRIVER_INFO_VER2 = (uint)(144 | ((2) << 16));

        [NativeTypeName("#define NV_DISPLAY_DRIVER_INFO_VER NV_DISPLAY_DRIVER_INFO_VER2")]
        public const uint NV_DISPLAY_DRIVER_INFO_VER = (uint)(144 | ((2) << 16));

        [NativeTypeName("#define NV_PHYSICAL_GPUS_VER1 MAKE_NVAPI_VERSION(NV_PHYSICAL_GPUS_V1, 1)")]
        public static readonly uint NV_PHYSICAL_GPUS_VER1 = unchecked((uint)(sizeof(_NV_PHYSICAL_GPUS) | ((1) << 16)));

        [NativeTypeName("#define NV_PHYSICAL_GPUS_VER NV_PHYSICAL_GPUS_VER1")]
        public static readonly uint NV_PHYSICAL_GPUS_VER = unchecked((uint)(sizeof(_NV_PHYSICAL_GPUS) | ((1) << 16)));

        [NativeTypeName("#define NV_LOGICAL_GPUS_VER1 MAKE_NVAPI_VERSION(NV_LOGICAL_GPUS_V1, 1)")]
        public static readonly uint NV_LOGICAL_GPUS_VER1 = unchecked((uint)(sizeof(_NV_LOGICAL_GPUS) | ((1) << 16)));

        [NativeTypeName("#define NV_LOGICAL_GPUS_VER NV_LOGICAL_GPUS_VER1")]
        public static readonly uint NV_LOGICAL_GPUS_VER = unchecked((uint)(sizeof(_NV_LOGICAL_GPUS) | ((1) << 16)));

        [NativeTypeName("#define NVAPI_MAX_NGX_FEATURES_PER_QUERY 16")]
        public const int NVAPI_MAX_NGX_FEATURES_PER_QUERY = 16;

        [NativeTypeName("#define NV_NGX_GET_DRIVER_FEATURE_SUPPORT_PARAMS_VER1 MAKE_NVAPI_VERSION(NV_NGX_GET_DRIVER_FEATURE_SUPPORT_PARAMS_V1,1)")]
        public const uint NV_NGX_GET_DRIVER_FEATURE_SUPPORT_PARAMS_VER1 = (uint)(288 | ((1) << 16));

        [NativeTypeName("#define NV_NGX_GET_DRIVER_FEATURE_SUPPORT_PARAMS_VER NV_NGX_GET_DRIVER_FEATURE_SUPPORT_PARAMS_VER1")]
        public const uint NV_NGX_GET_DRIVER_FEATURE_SUPPORT_PARAMS_VER = (uint)(288 | ((1) << 16));

        [NativeTypeName("#define NV_GPU_CLIENT_UTIL_DOMAINS_MAX_V1 (4)")]
        public const int NV_GPU_CLIENT_UTIL_DOMAINS_MAX_V1 = (4);

        [NativeTypeName("#define NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS_VER1 MAKE_NVAPI_VERSION(NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS_V1, 1)")]
        public static readonly uint NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS_VER1 = unchecked((uint)(sizeof(_NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS_V1) | ((1) << 16)));

        [NativeTypeName("#define NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS_VER NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS_VER1")]
        public static readonly uint NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS_VER = unchecked((uint)(sizeof(_NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS_V1) | ((1) << 16)));

        [NativeTypeName("#define NV_RISE_CALLBACK_SETTINGS_VER1 MAKE_NVAPI_VERSION(NV_RISE_CALLBACK_SETTINGS_V1, 1)")]
        public static readonly uint NV_RISE_CALLBACK_SETTINGS_VER1 = unchecked((uint)(sizeof(_NV_RISE_CALLBACK_SETTINGS_V1) | ((1) << 16)));

        [NativeTypeName("#define NV_RISE_CALLBACK_SETTINGS_VER NV_RISE_CALLBACK_SETTINGS_VER1")]
        public static readonly uint NV_RISE_CALLBACK_SETTINGS_VER = unchecked((uint)(sizeof(_NV_RISE_CALLBACK_SETTINGS_V1) | ((1) << 16)));

        [NativeTypeName("#define NV_REQUEST_RISE_SETTINGS_VER1 MAKE_NVAPI_VERSION(NV_REQUEST_RISE_SETTINGS_V1, 1)")]
        public const uint NV_REQUEST_RISE_SETTINGS_VER1 = (uint)(4140 | ((1) << 16));

        [NativeTypeName("#define NV_REQUEST_RISE_SETTINGS_VER NV_REQUEST_RISE_SETTINGS_VER1")]
        public const uint NV_REQUEST_RISE_SETTINGS_VER = (uint)(4140 | ((1) << 16));

        [NativeTypeName("#define NV_UNINSTALL_RISE_SETTINGS_VER1 MAKE_NVAPI_VERSION(NV_UNINSTALL_RISE_SETTINGS_V1, 1)")]
        public const uint NV_UNINSTALL_RISE_SETTINGS_VER1 = (uint)(36 | ((1) << 16));

        [NativeTypeName("#define NV_UNINSTALL_RISE_SETTINGS_VER NV_UNINSTALL_RISE_SETTINGS_VER1")]
        public const uint NV_UNINSTALL_RISE_SETTINGS_VER = (uint)(36 | ((1) << 16));

        [NativeTypeName("#define OGL_AA_LINE_GAMMA_STRING L\"Antialiasing - Line gamma\"")]
        public const string OGL_AA_LINE_GAMMA_STRING = "Antialiasing - Line gamma";

        [NativeTypeName("#define OGL_CPL_GDI_COMPATIBILITY_STRING L\"OpenGL GDI compatibility\"")]
        public const string OGL_CPL_GDI_COMPATIBILITY_STRING = "OpenGL GDI compatibility";

        [NativeTypeName("#define OGL_CPL_PREFER_DXPRESENT_STRING L\"Vulkan/OpenGL present method\"")]
        public const string OGL_CPL_PREFER_DXPRESENT_STRING = "Vulkan/OpenGL present method";

        [NativeTypeName("#define OGL_DEEP_COLOR_SCANOUT_STRING L\"Deep color for 3D applications\"")]
        public const string OGL_DEEP_COLOR_SCANOUT_STRING = "Deep color for 3D applications";

        [NativeTypeName("#define OGL_DEFAULT_SWAP_INTERVAL_STRING L\"OpenGL default swap interval\"")]
        public const string OGL_DEFAULT_SWAP_INTERVAL_STRING = "OpenGL default swap interval";

        [NativeTypeName("#define OGL_DEFAULT_SWAP_INTERVAL_FRACTIONAL_STRING L\"OpenGL default swap interval fraction\"")]
        public const string OGL_DEFAULT_SWAP_INTERVAL_FRACTIONAL_STRING = "OpenGL default swap interval fraction";

        [NativeTypeName("#define OGL_DEFAULT_SWAP_INTERVAL_SIGN_STRING L\"OpenGL default swap interval sign\"")]
        public const string OGL_DEFAULT_SWAP_INTERVAL_SIGN_STRING = "OpenGL default swap interval sign";

        [NativeTypeName("#define OGL_EVENT_LOG_SEVERITY_THRESHOLD_STRING L\"Event Log Severity Threshold\"")]
        public const string OGL_EVENT_LOG_SEVERITY_THRESHOLD_STRING = "Event Log Severity Threshold";

        [NativeTypeName("#define OGL_EXTENSION_STRING_VERSION_STRING L\"Extension String version\"")]
        public const string OGL_EXTENSION_STRING_VERSION_STRING = "Extension String version";

        [NativeTypeName("#define OGL_FORCE_BLIT_STRING L\"Buffer-flipping mode\"")]
        public const string OGL_FORCE_BLIT_STRING = "Buffer-flipping mode";

        [NativeTypeName("#define OGL_FORCE_STEREO_STRING L\"Force Stereo shuttering\"")]
        public const string OGL_FORCE_STEREO_STRING = "Force Stereo shuttering";

        [NativeTypeName("#define OGL_IMPLICIT_GPU_AFFINITY_STRING L\"Preferred OpenGL GPU\"")]
        public const string OGL_IMPLICIT_GPU_AFFINITY_STRING = "Preferred OpenGL GPU";

        [NativeTypeName("#define OGL_MAX_FRAMES_ALLOWED_STRING L\"Maximum frames allowed\"")]
        public const string OGL_MAX_FRAMES_ALLOWED_STRING = "Maximum frames allowed";

        [NativeTypeName("#define OGL_OVERLAY_PIXEL_TYPE_STRING L\"Exported Overlay pixel types\"")]
        public const string OGL_OVERLAY_PIXEL_TYPE_STRING = "Exported Overlay pixel types";

        [NativeTypeName("#define OGL_OVERLAY_SUPPORT_STRING L\"Enable overlay\"")]
        public const string OGL_OVERLAY_SUPPORT_STRING = "Enable overlay";

        [NativeTypeName("#define OGL_QUALITY_ENHANCEMENTS_STRING L\"High level control of the rendering quality on OpenGL\"")]
        public const string OGL_QUALITY_ENHANCEMENTS_STRING = "High level control of the rendering quality on OpenGL";

        [NativeTypeName("#define OGL_SINGLE_BACKDEPTH_BUFFER_STRING L\"Unified back/depth buffer\"")]
        public const string OGL_SINGLE_BACKDEPTH_BUFFER_STRING = "Unified back/depth buffer";

        [NativeTypeName("#define OGL_SLI_MULTICAST_STRING L\"Enable NV_gpu_multicast extension\"")]
        public const string OGL_SLI_MULTICAST_STRING = "Enable NV_gpu_multicast extension";

        [NativeTypeName("#define OGL_THREAD_CONTROL_STRING L\"Threaded optimization\"")]
        public const string OGL_THREAD_CONTROL_STRING = "Threaded optimization";

        [NativeTypeName("#define OGL_TMON_LEVEL_STRING L\"Event Log Tmon Severity Threshold\"")]
        public const string OGL_TMON_LEVEL_STRING = "Event Log Tmon Severity Threshold";

        [NativeTypeName("#define OGL_TRIPLE_BUFFER_STRING L\"Triple buffering\"")]
        public const string OGL_TRIPLE_BUFFER_STRING = "Triple buffering";

        [NativeTypeName("#define AA_BEHAVIOR_FLAGS_STRING L\"Antialiasing - Behavior Flags\"")]
        public const string AA_BEHAVIOR_FLAGS_STRING = "Antialiasing - Behavior Flags";

        [NativeTypeName("#define AA_MODE_ALPHATOCOVERAGE_STRING L\"Antialiasing - Transparency Multisampling\"")]
        public const string AA_MODE_ALPHATOCOVERAGE_STRING = "Antialiasing - Transparency Multisampling";

        [NativeTypeName("#define AA_MODE_GAMMACORRECTION_STRING L\"Antialiasing - Gamma correction\"")]
        public const string AA_MODE_GAMMACORRECTION_STRING = "Antialiasing - Gamma correction";

        [NativeTypeName("#define AA_MODE_METHOD_STRING L\"Antialiasing - Setting\"")]
        public const string AA_MODE_METHOD_STRING = "Antialiasing - Setting";

        [NativeTypeName("#define AA_MODE_REPLAY_STRING L\"Antialiasing - Transparency Supersampling\"")]
        public const string AA_MODE_REPLAY_STRING = "Antialiasing - Transparency Supersampling";

        [NativeTypeName("#define AA_MODE_SELECTOR_STRING L\"Antialiasing - Mode\"")]
        public const string AA_MODE_SELECTOR_STRING = "Antialiasing - Mode";

        [NativeTypeName("#define AA_MODE_SELECTOR_SLIAA_STRING L\"Antialiasing - SLI AA\"")]
        public const string AA_MODE_SELECTOR_SLIAA_STRING = "Antialiasing - SLI AA";

        [NativeTypeName("#define ANISO_MODE_LEVEL_STRING L\"Anisotropic filtering setting\"")]
        public const string ANISO_MODE_LEVEL_STRING = "Anisotropic filtering setting";

        [NativeTypeName("#define ANISO_MODE_SELECTOR_STRING L\"Anisotropic filtering mode\"")]
        public const string ANISO_MODE_SELECTOR_STRING = "Anisotropic filtering mode";

        [NativeTypeName("#define ANSEL_ALLOW_STRING L\"NVIDIA Predefined Ansel Usage\"")]
        public const string ANSEL_ALLOW_STRING = "NVIDIA Predefined Ansel Usage";

        [NativeTypeName("#define ANSEL_ALLOWLISTED_STRING L\"Ansel flags for enabled applications\"")]
        public const string ANSEL_ALLOWLISTED_STRING = "Ansel flags for enabled applications";

        [NativeTypeName("#define ANSEL_ENABLE_STRING L\"Enable Ansel\"")]
        public const string ANSEL_ENABLE_STRING = "Enable Ansel";

        [NativeTypeName("#define APPIDLE_DYNAMIC_FRL_FPS_STRING L\"Idle Application Max FPS Limit\"")]
        public const string APPIDLE_DYNAMIC_FRL_FPS_STRING = "Idle Application Max FPS Limit";

        [NativeTypeName("#define APPIDLE_DYNAMIC_FRL_THRESHOLD_TIME_STRING L\"Idle Application Threshold Time out in seconds\"")]
        public const string APPIDLE_DYNAMIC_FRL_THRESHOLD_TIME_STRING = "Idle Application Threshold Time out in seconds";

        [NativeTypeName("#define APPLICATION_PROFILE_NOTIFICATION_TIMEOUT_STRING L\"Application Profile Notification Popup Timeout\"")]
        public const string APPLICATION_PROFILE_NOTIFICATION_TIMEOUT_STRING = "Application Profile Notification Popup Timeout";

        [NativeTypeName("#define APPLICATION_STEAM_ID_STRING L\"Steam Application ID\"")]
        public const string APPLICATION_STEAM_ID_STRING = "Steam Application ID";

        [NativeTypeName("#define BATTERY_BOOST_APP_FPS_STRING L\"Battery Boost Application FPS\"")]
        public const string BATTERY_BOOST_APP_FPS_STRING = "Battery Boost Application FPS";

        [NativeTypeName("#define CPL_HIDDEN_PROFILE_STRING L\"Do not display this profile in the Control Panel\"")]
        public const string CPL_HIDDEN_PROFILE_STRING = "Do not display this profile in the Control Panel";

        [NativeTypeName("#define CUDA_EXCLUDED_GPUS_STRING L\"List of Universal GPU ids\"")]
        public const string CUDA_EXCLUDED_GPUS_STRING = "List of Universal GPU ids";

        [NativeTypeName("#define D3DOGL_GPU_MAX_POWER_STRING L\"Maximum GPU Power\"")]
        public const string D3DOGL_GPU_MAX_POWER_STRING = "Maximum GPU Power";

        [NativeTypeName("#define EXPORT_PERF_COUNTERS_STRING L\"Export Performance Counters\"")]
        public const string EXPORT_PERF_COUNTERS_STRING = "Export Performance Counters";

        [NativeTypeName("#define EXTERNAL_QUIET_MODE_STRING L\"External Quiet Mode (XQM)\"")]
        public const string EXTERNAL_QUIET_MODE_STRING = "External Quiet Mode (XQM)";

        [NativeTypeName("#define FRL_FPS_STRING L\"Frame Rate Limiter\"")]
        public const string FRL_FPS_STRING = "Frame Rate Limiter";

        [NativeTypeName("#define FXAA_ALLOW_STRING L\"NVIDIA Predefined FXAA Usage\"")]
        public const string FXAA_ALLOW_STRING = "NVIDIA Predefined FXAA Usage";

        [NativeTypeName("#define FXAA_ENABLE_STRING L\"Enable FXAA\"")]
        public const string FXAA_ENABLE_STRING = "Enable FXAA";

        [NativeTypeName("#define FXAA_INDICATOR_ENABLE_STRING L\"Enable FXAA Indicator\"")]
        public const string FXAA_INDICATOR_ENABLE_STRING = "Enable FXAA Indicator";

        [NativeTypeName("#define LATENCY_INDICATOR_AUTOALIGN_STRING L\"Autoalign flash indicator\"")]
        public const string LATENCY_INDICATOR_AUTOALIGN_STRING = "Autoalign flash indicator";

        [NativeTypeName("#define MCSFRSHOWSPLIT_STRING L\"SLI indicator\"")]
        public const string MCSFRSHOWSPLIT_STRING = "SLI indicator";

        [NativeTypeName("#define NGX_DLAA_OVERRIDE_STRING L\"Override DLSS mode to be DLAA\"")]
        public const string NGX_DLAA_OVERRIDE_STRING = "Override DLSS mode to be DLAA";

        [NativeTypeName("#define NGX_DLSSG_DYNAMIC_MULTI_FRAME_COUNT_MAX_STRING L\"Override maximum DLSSG dynamic multi frame count\"")]
        public const string NGX_DLSSG_DYNAMIC_MULTI_FRAME_COUNT_MAX_STRING = "Override maximum DLSSG dynamic multi frame count";

        [NativeTypeName("#define NGX_DLSSG_DYNAMIC_TARGET_FRAME_RATE_STRING L\"Override DLSSG Target Frame Rate\"")]
        public const string NGX_DLSSG_DYNAMIC_TARGET_FRAME_RATE_STRING = "Override DLSSG Target Frame Rate";

        [NativeTypeName("#define NGX_DLSSG_MODE_STRING L\"Override DLSSG mode\"")]
        public const string NGX_DLSSG_MODE_STRING = "Override DLSSG mode";

        [NativeTypeName("#define NGX_DLSSG_MULTI_FRAME_COUNT_STRING L\"Override DLSSG multi-frame count\"")]
        public const string NGX_DLSSG_MULTI_FRAME_COUNT_STRING = "Override DLSSG multi-frame count";

        [NativeTypeName("#define NGX_DLSS_FG_OVERRIDE_STRING L\"Enable DLSS-FG override\"")]
        public const string NGX_DLSS_FG_OVERRIDE_STRING = "Enable DLSS-FG override";

        [NativeTypeName("#define NGX_DLSS_FG_OVERRIDE_RENDER_PRESET_SELECTION_STRING L\"Override DLSS-FG preset\"")]
        public const string NGX_DLSS_FG_OVERRIDE_RENDER_PRESET_SELECTION_STRING = "Override DLSS-FG preset";

        [NativeTypeName("#define NGX_DLSS_FG_OVERRIDE_RESERVED_KEY1_STRING L\"Override reserved key 1 for FG\"")]
        public const string NGX_DLSS_FG_OVERRIDE_RESERVED_KEY1_STRING = "Override reserved key 1 for FG";

        [NativeTypeName("#define NGX_DLSS_FG_OVERRIDE_RESERVED_KEY2_STRING L\"Override reserved key 2 for FG\"")]
        public const string NGX_DLSS_FG_OVERRIDE_RESERVED_KEY2_STRING = "Override reserved key 2 for FG";

        [NativeTypeName("#define NGX_DLSS_OVERRIDE_OPTIMAL_SETTINGS_STRING L\"Override DLSS performance mode to be ultra-perfomance\"")]
        public const string NGX_DLSS_OVERRIDE_OPTIMAL_SETTINGS_STRING = "Override DLSS performance mode to be ultra-perfomance";

        [NativeTypeName("#define NGX_DLSS_RR_MODE_STRING L\"Override DLSS-RR performance mode\"")]
        public const string NGX_DLSS_RR_MODE_STRING = "Override DLSS-RR performance mode";

        [NativeTypeName("#define NGX_DLSS_RR_OVERRIDE_STRING L\"Enable DLSS-RR override\"")]
        public const string NGX_DLSS_RR_OVERRIDE_STRING = "Enable DLSS-RR override";

        [NativeTypeName("#define NGX_DLSS_RR_OVERRIDE_RENDER_PRESET_SELECTION_STRING L\"Override DLSS-RR preset\"")]
        public const string NGX_DLSS_RR_OVERRIDE_RENDER_PRESET_SELECTION_STRING = "Override DLSS-RR preset";

        [NativeTypeName("#define NGX_DLSS_RR_OVERRIDE_RESERVED_KEY1_STRING L\"Override reserved key 1 for RR\"")]
        public const string NGX_DLSS_RR_OVERRIDE_RESERVED_KEY1_STRING = "Override reserved key 1 for RR";

        [NativeTypeName("#define NGX_DLSS_RR_OVERRIDE_RESERVED_KEY2_STRING L\"Override reserved key 2 for RR\"")]
        public const string NGX_DLSS_RR_OVERRIDE_RESERVED_KEY2_STRING = "Override reserved key 2 for RR";

        [NativeTypeName("#define NGX_DLSS_RR_OVERRIDE_SCALING_RATIO_STRING L\"Override scaling ratio for DLSS-RR\"")]
        public const string NGX_DLSS_RR_OVERRIDE_SCALING_RATIO_STRING = "Override scaling ratio for DLSS-RR";

        [NativeTypeName("#define NGX_DLSS_SR_MODE_STRING L\"Override DLSS-SR performance mode\"")]
        public const string NGX_DLSS_SR_MODE_STRING = "Override DLSS-SR performance mode";

        [NativeTypeName("#define NGX_DLSS_SR_OVERRIDE_STRING L\"Enable DLSS-SR override\"")]
        public const string NGX_DLSS_SR_OVERRIDE_STRING = "Enable DLSS-SR override";

        [NativeTypeName("#define NGX_DLSS_SR_OVERRIDE_RENDER_PRESET_SELECTION_STRING L\"Override DLSS-SR presets\"")]
        public const string NGX_DLSS_SR_OVERRIDE_RENDER_PRESET_SELECTION_STRING = "Override DLSS-SR presets";

        [NativeTypeName("#define NGX_DLSS_SR_OVERRIDE_RESERVED_KEY1_STRING L\"Override reserved key 1 for SR\"")]
        public const string NGX_DLSS_SR_OVERRIDE_RESERVED_KEY1_STRING = "Override reserved key 1 for SR";

        [NativeTypeName("#define NGX_DLSS_SR_OVERRIDE_RESERVED_KEY2_STRING L\"Override reserved key 2 for SR\"")]
        public const string NGX_DLSS_SR_OVERRIDE_RESERVED_KEY2_STRING = "Override reserved key 2 for SR";

        [NativeTypeName("#define NGX_DLSS_SR_OVERRIDE_SCALING_RATIO_STRING L\"Override scaling ratio for DLSS-SR\"")]
        public const string NGX_DLSS_SR_OVERRIDE_SCALING_RATIO_STRING = "Override scaling ratio for DLSS-SR";

        [NativeTypeName("#define NV_QUALITY_UPSCALING_STRING L\"NVIDIA Quality upscaling\"")]
        public const string NV_QUALITY_UPSCALING_STRING = "NVIDIA Quality upscaling";

        [NativeTypeName("#define OPTIMUS_MAXAA_STRING L\"Maximum AA samples allowed for a given application\"")]
        public const string OPTIMUS_MAXAA_STRING = "Maximum AA samples allowed for a given application";

        [NativeTypeName("#define PHYSXINDICATOR_STRING L\"Display the PhysX indicator\"")]
        public const string PHYSXINDICATOR_STRING = "Display the PhysX indicator";

        [NativeTypeName("#define PREFERRED_PSTATE_STRING L\"Power management mode\"")]
        public const string PREFERRED_PSTATE_STRING = "Power management mode";

        [NativeTypeName("#define PREVENT_UI_AF_OVERRIDE_STRING L\"No override of Anisotropic filtering\"")]
        public const string PREVENT_UI_AF_OVERRIDE_STRING = "No override of Anisotropic filtering";

        [NativeTypeName("#define SHIM_MAXRES_STRING L\"Maximum resolution allowed for a given application\"")]
        public const string SHIM_MAXRES_STRING = "Maximum resolution allowed for a given application";

        [NativeTypeName("#define SHIM_MCCOMPAT_STRING L\"Optimus flags for enabled applications\"")]
        public const string SHIM_MCCOMPAT_STRING = "Optimus flags for enabled applications";

        [NativeTypeName("#define SHIM_RENDERING_MODE_STRING L\"Enable application for Optimus\"")]
        public const string SHIM_RENDERING_MODE_STRING = "Enable application for Optimus";

        [NativeTypeName("#define SHIM_RENDERING_OPTIONS_STRING L\"Shim Rendering Mode Options per application for Optimus\"")]
        public const string SHIM_RENDERING_OPTIONS_STRING = "Shim Rendering Mode Options per application for Optimus";

        [NativeTypeName("#define SLI_GPU_COUNT_STRING L\"Number of GPUs to use on SLI rendering mode\"")]
        public const string SLI_GPU_COUNT_STRING = "Number of GPUs to use on SLI rendering mode";

        [NativeTypeName("#define SLI_PREDEFINED_GPU_COUNT_STRING L\"NVIDIA predefined number of GPUs to use on SLI rendering mode\"")]
        public const string SLI_PREDEFINED_GPU_COUNT_STRING = "NVIDIA predefined number of GPUs to use on SLI rendering mode";

        [NativeTypeName("#define SLI_PREDEFINED_GPU_COUNT_DX10_STRING L\"NVIDIA predefined number of GPUs to use on SLI rendering mode on DirectX 10\"")]
        public const string SLI_PREDEFINED_GPU_COUNT_DX10_STRING = "NVIDIA predefined number of GPUs to use on SLI rendering mode on DirectX 10";

        [NativeTypeName("#define SLI_PREDEFINED_MODE_STRING L\"NVIDIA predefined SLI mode\"")]
        public const string SLI_PREDEFINED_MODE_STRING = "NVIDIA predefined SLI mode";

        [NativeTypeName("#define SLI_PREDEFINED_MODE_DX10_STRING L\"NVIDIA predefined SLI mode on DirectX 10\"")]
        public const string SLI_PREDEFINED_MODE_DX10_STRING = "NVIDIA predefined SLI mode on DirectX 10";

        [NativeTypeName("#define SLI_RENDERING_MODE_STRING L\"SLI rendering mode\"")]
        public const string SLI_RENDERING_MODE_STRING = "SLI rendering mode";

        [NativeTypeName("#define VRPRERENDERLIMIT_STRING L\"Virtual Reality pre-rendered frames\"")]
        public const string VRPRERENDERLIMIT_STRING = "Virtual Reality pre-rendered frames";

        [NativeTypeName("#define VRRFEATUREINDICATOR_STRING L\"Toggle the VRR global feature\"")]
        public const string VRRFEATUREINDICATOR_STRING = "Toggle the VRR global feature";

        [NativeTypeName("#define VRROVERLAYINDICATOR_STRING L\"Display the VRR Overlay Indicator\"")]
        public const string VRROVERLAYINDICATOR_STRING = "Display the VRR Overlay Indicator";

        [NativeTypeName("#define VRRREQUESTSTATE_STRING L\"VRR requested state\"")]
        public const string VRRREQUESTSTATE_STRING = "VRR requested state";

        [NativeTypeName("#define VRR_APP_OVERRIDE_STRING L\"G-SYNC\"")]
        public const string VRR_APP_OVERRIDE_STRING = "G-SYNC";

        [NativeTypeName("#define VRR_APP_OVERRIDE_REQUEST_STATE_STRING L\"G-SYNC\"")]
        public const string VRR_APP_OVERRIDE_REQUEST_STATE_STRING = "G-SYNC";

        [NativeTypeName("#define VRR_MODE_STRING L\"Enable G-SYNC globally\"")]
        public const string VRR_MODE_STRING = "Enable G-SYNC globally";

        [NativeTypeName("#define VSYNCSMOOTHAFR_STRING L\"Flag to control smooth AFR behavior\"")]
        public const string VSYNCSMOOTHAFR_STRING = "Flag to control smooth AFR behavior";

        [NativeTypeName("#define VSYNCVRRCONTROL_STRING L\"Variable refresh Rate\"")]
        public const string VSYNCVRRCONTROL_STRING = "Variable refresh Rate";

        [NativeTypeName("#define VSYNC_BEHAVIOR_FLAGS_STRING L\"Vsync - Behavior Flags\"")]
        public const string VSYNC_BEHAVIOR_FLAGS_STRING = "Vsync - Behavior Flags";

        [NativeTypeName("#define WKS_API_STEREO_EYES_EXCHANGE_STRING L\"Stereo - Swap eyes\"")]
        public const string WKS_API_STEREO_EYES_EXCHANGE_STRING = "Stereo - Swap eyes";

        [NativeTypeName("#define WKS_API_STEREO_MODE_STRING L\"Stereo - Display mode\"")]
        public const string WKS_API_STEREO_MODE_STRING = "Stereo - Display mode";

        [NativeTypeName("#define WKS_STEREO_DONGLE_SUPPORT_STRING L\"Stereo - Dongle Support\"")]
        public const string WKS_STEREO_DONGLE_SUPPORT_STRING = "Stereo - Dongle Support";

        [NativeTypeName("#define WKS_STEREO_SUPPORT_STRING L\"Stereo - Enable\"")]
        public const string WKS_STEREO_SUPPORT_STRING = "Stereo - Enable";

        [NativeTypeName("#define WKS_STEREO_SWAP_MODE_STRING L\"Stereo - swap mode\"")]
        public const string WKS_STEREO_SWAP_MODE_STRING = "Stereo - swap mode";

        [NativeTypeName("#define AO_MODE_STRING L\"Ambient Occlusion\"")]
        public const string AO_MODE_STRING = "Ambient Occlusion";

        [NativeTypeName("#define AO_MODE_ACTIVE_STRING L\"NVIDIA Predefined Ambient Occlusion Usage\"")]
        public const string AO_MODE_ACTIVE_STRING = "NVIDIA Predefined Ambient Occlusion Usage";

        [NativeTypeName("#define AUTO_LODBIASADJUST_STRING L\"Texture filtering - Driver Controlled LOD Bias\"")]
        public const string AUTO_LODBIASADJUST_STRING = "Texture filtering - Driver Controlled LOD Bias";

        [NativeTypeName("#define EXPORT_PERF_COUNTERS_DX9_ONLY_STRING L\"Export Performance Counters for DX9 only\"")]
        public const string EXPORT_PERF_COUNTERS_DX9_ONLY_STRING = "Export Performance Counters for DX9 only";

        [NativeTypeName("#define ICAFE_LOGO_CONFIG_STRING L\"ICafe Settings\"")]
        public const string ICAFE_LOGO_CONFIG_STRING = "ICafe Settings";

        [NativeTypeName("#define LODBIASADJUST_STRING L\"Texture filtering - LOD Bias\"")]
        public const string LODBIASADJUST_STRING = "Texture filtering - LOD Bias";

        [NativeTypeName("#define MAXWELL_B_SAMPLE_INTERLEAVE_STRING L\"Enable sample interleaving (MFAA)\"")]
        public const string MAXWELL_B_SAMPLE_INTERLEAVE_STRING = "Enable sample interleaving (MFAA)";

        [NativeTypeName("#define PRERENDERLIMIT_STRING L\"Maximum pre-rendered frames\"")]
        public const string PRERENDERLIMIT_STRING = "Maximum pre-rendered frames";

        [NativeTypeName("#define PS_OFFLINE_SHADER_COMPILER_STRING L\"Offline Shader Compile\"")]
        public const string PS_OFFLINE_SHADER_COMPILER_STRING = "Offline Shader Compile";

        [NativeTypeName("#define PS_SHADERDISKCACHE_STRING L\"Shader Cache\"")]
        public const string PS_SHADERDISKCACHE_STRING = "Shader Cache";

        [NativeTypeName("#define PS_SHADERDISKCACHE_DLL_PATH_WCHAR_STRING L\"shader cache path to dll\"")]
        public const string PS_SHADERDISKCACHE_DLL_PATH_WCHAR_STRING = "shader cache path to dll";

        [NativeTypeName("#define PS_SHADERDISKCACHE_MAX_SIZE_STRING L\"Shader disk cache maximum size\"")]
        public const string PS_SHADERDISKCACHE_MAX_SIZE_STRING = "Shader disk cache maximum size";

        [NativeTypeName("#define PS_TEXFILTER_ANISO_OPTS2_STRING L\"Texture filtering - Anisotropic sample optimization\"")]
        public const string PS_TEXFILTER_ANISO_OPTS2_STRING = "Texture filtering - Anisotropic sample optimization";

        [NativeTypeName("#define PS_TEXFILTER_BILINEAR_IN_ANISO_STRING L\"Texture filtering - Anisotropic filter optimization\"")]
        public const string PS_TEXFILTER_BILINEAR_IN_ANISO_STRING = "Texture filtering - Anisotropic filter optimization";

        [NativeTypeName("#define PS_TEXFILTER_DISABLE_TRILIN_SLOPE_STRING L\"Texture filtering - Trilinear optimization\"")]
        public const string PS_TEXFILTER_DISABLE_TRILIN_SLOPE_STRING = "Texture filtering - Trilinear optimization";

        [NativeTypeName("#define PS_TEXFILTER_NO_NEG_LODBIAS_STRING L\"Texture filtering - Negative LOD bias\"")]
        public const string PS_TEXFILTER_NO_NEG_LODBIAS_STRING = "Texture filtering - Negative LOD bias";

        [NativeTypeName("#define QUALITY_ENHANCEMENTS_STRING L\"Texture filtering - Quality\"")]
        public const string QUALITY_ENHANCEMENTS_STRING = "Texture filtering - Quality";

        [NativeTypeName("#define QUALITY_ENHANCEMENT_SUBSTITUTION_STRING L\"Texture filtering - Quality Substitution\"")]
        public const string QUALITY_ENHANCEMENT_SUBSTITUTION_STRING = "Texture filtering - Quality Substitution";

        [NativeTypeName("#define REFRESH_RATE_OVERRIDE_STRING L\"Preferred refresh rate\"")]
        public const string REFRESH_RATE_OVERRIDE_STRING = "Preferred refresh rate";

        [NativeTypeName("#define SET_POWER_THROTTLE_FOR_PCIe_COMPLIANCE_STRING L\"PowerThrottle\"")]
        public const string SET_POWER_THROTTLE_FOR_PCIe_COMPLIANCE_STRING = "PowerThrottle";

        [NativeTypeName("#define SET_VAB_DATA_STRING L\"VAB Default Data\"")]
        public const string SET_VAB_DATA_STRING = "VAB Default Data";

        [NativeTypeName("#define VSYNCMODE_STRING L\"Vertical Sync\"")]
        public const string VSYNCMODE_STRING = "Vertical Sync";

        [NativeTypeName("#define VSYNCTEARCONTROL_STRING L\"Vertical Sync Tear Control\"")]
        public const string VSYNCTEARCONTROL_STRING = "Vertical Sync Tear Control";

        [NativeTypeName("#define OGL_IMPLICIT_GPU_AFFINITY_ENV_VAR L\"OGL_DEFAULT_RENDERING_GPU\"")]
        public const string OGL_IMPLICIT_GPU_AFFINITY_ENV_VAR = "OGL_DEFAULT_RENDERING_GPU";

        [NativeTypeName("#define OGL_IMPLICIT_GPU_AFFINITY_AUTOSELECT L\"autoselect\"")]
        public const string OGL_IMPLICIT_GPU_AFFINITY_AUTOSELECT = "autoselect";

        [NativeTypeName("#define OGL_IMPLICIT_GPU_AFFINITY_NUM_VALUES 1")]
        public const int OGL_IMPLICIT_GPU_AFFINITY_NUM_VALUES = 1;

        [NativeTypeName("#define OGL_IMPLICIT_GPU_AFFINITY_DEFAULT OGL_IMPLICIT_GPU_AFFINITY_AUTOSELECT")]
        public const string OGL_IMPLICIT_GPU_AFFINITY_DEFAULT = "autoselect";

        [NativeTypeName("#define CUDA_EXCLUDED_GPUS_NONE L\"none\"")]
        public const string CUDA_EXCLUDED_GPUS_NONE = "none";

        [NativeTypeName("#define CUDA_EXCLUDED_GPUS_NUM_VALUES 1")]
        public const int CUDA_EXCLUDED_GPUS_NUM_VALUES = 1;

        [NativeTypeName("#define CUDA_EXCLUDED_GPUS_DEFAULT CUDA_EXCLUDED_GPUS_NONE")]
        public const string CUDA_EXCLUDED_GPUS_DEFAULT = "none";

        [NativeTypeName("#define D3DOGL_GPU_MAX_POWER_DEFAULTPOWER L\"0\"")]
        public const string D3DOGL_GPU_MAX_POWER_DEFAULTPOWER = "0";

        [NativeTypeName("#define D3DOGL_GPU_MAX_POWER_NUM_VALUES 1")]
        public const int D3DOGL_GPU_MAX_POWER_NUM_VALUES = 1;

        [NativeTypeName("#define D3DOGL_GPU_MAX_POWER_DEFAULT D3DOGL_GPU_MAX_POWER_DEFAULTPOWER")]
        public const string D3DOGL_GPU_MAX_POWER_DEFAULT = "0";
    }
}
