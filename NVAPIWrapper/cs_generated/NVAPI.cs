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
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_SYS_GetDriverAndBranchVersion([NativeTypeName("NvU32 *")] uint* pDriverVersion, [NativeTypeName("NvAPI_ShortString")] sbyte* szBuildBranchString);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetMemoryInfo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 520. Instead, use NvAPI_GPU_GetMemoryInfoEx.")]
        public static extern _NvAPI_Status NvAPI_GPU_GetMemoryInfo([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_DISPLAY_DRIVER_MEMORY_INFO *")] NV_DISPLAY_DRIVER_MEMORY_INFO_V3* pMemoryInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetMemoryInfoEx"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetMemoryInfoEx([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_GPU_MEMORY_INFO_EX *")] NV_GPU_MEMORY_INFO_EX_V1* pMemoryInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_EnumPhysicalGPUs"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_EnumPhysicalGPUs([NativeTypeName("NvPhysicalGpuHandle[64]")] NvPhysicalGpuHandle__** nvGPUHandle, [NativeTypeName("NvU32 *")] uint* pGpuCount);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_GetGDIPrimaryDisplayId"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DISP_GetGDIPrimaryDisplayId([NativeTypeName("NvU32 *")] uint* displayId);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Mosaic_GetDisplayViewportsByResolution"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Mosaic_GetDisplayViewportsByResolution([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NvU32")] uint srcWidth, [NativeTypeName("NvU32")] uint srcHeight, [NativeTypeName("NV_RECT[64]")] _NV_RECT* viewports, [NativeTypeName("NvU8 *")] byte* bezelCorrected);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_Enable"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_Enable();

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_Disable"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_Disable();

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_IsEnabled"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_IsEnabled([NativeTypeName("NvU8 *")] byte* pIsStereoEnabled);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_DestroyHandle"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_DestroyHandle([NativeTypeName("StereoHandle")] void* stereoHandle);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_Activate"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_Activate([NativeTypeName("StereoHandle")] void* stereoHandle);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_Deactivate"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_Deactivate([NativeTypeName("StereoHandle")] void* stereoHandle);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_IsActivated"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_IsActivated([NativeTypeName("StereoHandle")] void* stereoHandle, [NativeTypeName("NvU8 *")] byte* pIsStereoOn);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_GetSeparation"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_GetSeparation([NativeTypeName("StereoHandle")] void* stereoHandle, float* pSeparationPercentage);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_SetSeparation"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_SetSeparation([NativeTypeName("StereoHandle")] void* stereoHandle, float newSeparationPercentage);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_GetConvergence"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_GetConvergence([NativeTypeName("StereoHandle")] void* stereoHandle, float* pConvergence);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_SetConvergence"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_SetConvergence([NativeTypeName("StereoHandle")] void* stereoHandle, float newConvergence);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_SetActiveEye"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_SetActiveEye([NativeTypeName("StereoHandle")] void* hStereoHandle, [NativeTypeName("NV_STEREO_ACTIVE_EYE")] _NV_StereoActiveEye StereoEye);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_SetDriverMode"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_SetDriverMode([NativeTypeName("NV_STEREO_DRIVER_MODE")] _NV_StereoDriverMode mode);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_GetEyeSeparation"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_GetEyeSeparation([NativeTypeName("StereoHandle")] void* hStereoHandle, float* pSeparation);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_IsWindowedModeSupported"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_IsWindowedModeSupported([NativeTypeName("NvU8 *")] byte* bSupported);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_SetSurfaceCreationMode"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_SetSurfaceCreationMode([NativeTypeName("StereoHandle")] void* hStereoHandle, [NativeTypeName("NVAPI_STEREO_SURFACECREATEMODE")] _NVAPI_STEREO_SURFACECREATEMODE creationMode);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_GetSurfaceCreationMode"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_GetSurfaceCreationMode([NativeTypeName("StereoHandle")] void* hStereoHandle, [NativeTypeName("NVAPI_STEREO_SURFACECREATEMODE *")] _NVAPI_STEREO_SURFACECREATEMODE* pCreationMode);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_Debug_WasLastDrawStereoized"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_Debug_WasLastDrawStereoized([NativeTypeName("StereoHandle")] void* hStereoHandle, [NativeTypeName("NvU8 *")] byte* pWasStereoized);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_SetDefaultProfile"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_SetDefaultProfile([NativeTypeName("const char *")] sbyte* szProfileName);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_GetDefaultProfile"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_GetDefaultProfile([NativeTypeName("NvU32")] uint cbSizeIn, [NativeTypeName("char *")] sbyte* szProfileName, [NativeTypeName("NvU32 *")] uint* pcbSizeOut);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Initialize"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Initialize();

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Unload"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Unload();

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetErrorMessage"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GetErrorMessage([NativeTypeName("NvAPI_Status")] _NvAPI_Status nr, [NativeTypeName("NvAPI_ShortString")] sbyte* szDesc);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetInterfaceVersionString"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GetInterfaceVersionString([NativeTypeName("NvAPI_ShortString")] sbyte* szDesc);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetInterfaceVersionStringEx"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GetInterfaceVersionStringEx([NativeTypeName("NvAPI_ShortString")] sbyte* szDesc);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetEDID"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetEDID([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32")] uint displayOutputId, [NativeTypeName("NV_EDID *")] NV_EDID_V3* pEDID);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_SetView"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_DISP_SetDisplayConfig.")]
        public static extern _NvAPI_Status NvAPI_SetView([NativeTypeName("NvDisplayHandle")] NvDisplayHandle__* hNvDisplay, NV_VIEW_TARGET_INFO* pTargetInfo, [NativeTypeName("NV_TARGET_VIEW_MODE")] _NV_TARGET_VIEW_MODE targetView);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_SetViewEx"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_DISP_SetDisplayConfig.")]
        public static extern _NvAPI_Status NvAPI_SetViewEx([NativeTypeName("NvDisplayHandle")] NvDisplayHandle__* hNvDisplay, NV_DISPLAY_PATH_INFO* pPathInfo, [NativeTypeName("NV_TARGET_VIEW_MODE")] _NV_TARGET_VIEW_MODE displayView);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetDisplayDriverVersion"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_SYS_GetDriverAndBranchVersion.")]
        public static extern _NvAPI_Status NvAPI_GetDisplayDriverVersion([NativeTypeName("NvDisplayHandle")] NvDisplayHandle__* hNvDisplay, NV_DISPLAY_DRIVER_VERSION* pVersion);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_OGL_ExpertModeSet"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_OGL_ExpertModeSet([NativeTypeName("NvU32")] uint expertDetailLevel, [NativeTypeName("NvU32")] uint expertReportMask, [NativeTypeName("NvU32")] uint expertOutputMask, [NativeTypeName("NVAPI_OGLEXPERT_CALLBACK")] delegate* unmanaged[Cdecl]<uint, uint, uint, int, sbyte*, void> expertCallback);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_OGL_ExpertModeGet"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_OGL_ExpertModeGet([NativeTypeName("NvU32 *")] uint* pExpertDetailLevel, [NativeTypeName("NvU32 *")] uint* pExpertReportMask, [NativeTypeName("NvU32 *")] uint* pExpertOutputMask, [NativeTypeName("NVAPI_OGLEXPERT_CALLBACK *")] delegate* unmanaged[Cdecl]<uint, uint, uint, int, sbyte*, void>* pExpertCallback);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_OGL_ExpertModeDefaultsSet"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_OGL_ExpertModeDefaultsSet([NativeTypeName("NvU32")] uint expertDetailLevel, [NativeTypeName("NvU32")] uint expertReportMask, [NativeTypeName("NvU32")] uint expertOutputMask);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_OGL_ExpertModeDefaultsGet"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_OGL_ExpertModeDefaultsGet([NativeTypeName("NvU32 *")] uint* pExpertDetailLevel, [NativeTypeName("NvU32 *")] uint* pExpertReportMask, [NativeTypeName("NvU32 *")] uint* pExpertOutputMask);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_EnumTCCPhysicalGPUs"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_EnumTCCPhysicalGPUs([NativeTypeName("NvPhysicalGpuHandle[64]")] NvPhysicalGpuHandle__** nvGPUHandle, [NativeTypeName("NvU32 *")] uint* pGpuCount);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_EnumLogicalGPUs"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_EnumLogicalGPUs([NativeTypeName("NvLogicalGpuHandle[64]")] NvLogicalGpuHandle__** nvGPUHandle, [NativeTypeName("NvU32 *")] uint* pGpuCount);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetPhysicalGPUsFromDisplay"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GetPhysicalGPUsFromDisplay([NativeTypeName("NvDisplayHandle")] NvDisplayHandle__* hNvDisp, [NativeTypeName("NvPhysicalGpuHandle[64]")] NvPhysicalGpuHandle__** nvGPUHandle, [NativeTypeName("NvU32 *")] uint* pGpuCount);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetPhysicalGPUFromUnAttachedDisplay"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GetPhysicalGPUFromUnAttachedDisplay([NativeTypeName("NvUnAttachedDisplayHandle")] NvUnAttachedDisplayHandle__* hNvUnAttachedDisp, [NativeTypeName("NvPhysicalGpuHandle *")] NvPhysicalGpuHandle__** pPhysicalGpu);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetLogicalGPUFromDisplay"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GetLogicalGPUFromDisplay([NativeTypeName("NvDisplayHandle")] NvDisplayHandle__* hNvDisp, [NativeTypeName("NvLogicalGpuHandle *")] NvLogicalGpuHandle__** pLogicalGPU);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetLogicalGPUFromPhysicalGPU"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GetLogicalGPUFromPhysicalGPU([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGPU, [NativeTypeName("NvLogicalGpuHandle *")] NvLogicalGpuHandle__** pLogicalGPU);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetPhysicalGPUsFromLogicalGPU"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GetPhysicalGPUsFromLogicalGPU([NativeTypeName("NvLogicalGpuHandle")] NvLogicalGpuHandle__* hLogicalGPU, [NativeTypeName("NvPhysicalGpuHandle[64]")] NvPhysicalGpuHandle__** hPhysicalGPU, [NativeTypeName("NvU32 *")] uint* pGpuCount);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetPhysicalGPUFromGPUID"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GetPhysicalGPUFromGPUID([NativeTypeName("NvU32")] uint gpuId, [NativeTypeName("NvPhysicalGpuHandle *")] NvPhysicalGpuHandle__** pPhysicalGPU);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetGPUIDfromPhysicalGPU"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GetGPUIDfromPhysicalGPU([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32 *")] uint* pGpuId);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetShaderSubPipeCount"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetShaderSubPipeCount([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32 *")] uint* pCount);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetGpuCoreCount"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetGpuCoreCount([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32 *")] uint* pCount);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetAllOutputs"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_GPU_GetAllDisplayIds.")]
        public static extern _NvAPI_Status NvAPI_GPU_GetAllOutputs([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32 *")] uint* pOutputsMask);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetConnectedOutputs"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_GPU_GetConnectedDisplayIds.")]
        public static extern _NvAPI_Status NvAPI_GPU_GetConnectedOutputs([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32 *")] uint* pOutputsMask);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetConnectedSLIOutputs"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_GPU_GetConnectedDisplayIds.")]
        public static extern _NvAPI_Status NvAPI_GPU_GetConnectedSLIOutputs([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32 *")] uint* pOutputsMask);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetConnectedDisplayIds"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetConnectedDisplayIds([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_GPU_DISPLAYIDS *")] _NV_GPU_DISPLAYIDS* pDisplayIds, [NativeTypeName("NvU32 *")] uint* pDisplayIdCount, [NativeTypeName("NvU32")] uint flags);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetAllDisplayIds"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetAllDisplayIds([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_GPU_DISPLAYIDS *")] _NV_GPU_DISPLAYIDS* pDisplayIds, [NativeTypeName("NvU32 *")] uint* pDisplayIdCount);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetConnectedOutputsWithLidState"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_GPU_GetConnectedDisplayIds.")]
        public static extern _NvAPI_Status NvAPI_GPU_GetConnectedOutputsWithLidState([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32 *")] uint* pOutputsMask);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetConnectedSLIOutputsWithLidState"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_GPU_GetConnectedDisplayIds.")]
        public static extern _NvAPI_Status NvAPI_GPU_GetConnectedSLIOutputsWithLidState([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32 *")] uint* pOutputsMask);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetSystemType"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetSystemType([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, NV_SYSTEM_TYPE* pSystemType);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetActiveOutputs"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetActiveOutputs([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32 *")] uint* pOutputsMask);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_SetEDID"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_SetEDID([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32")] uint displayOutputId, [NativeTypeName("NV_EDID *")] NV_EDID_V3* pEDID);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetOutputType"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetOutputType([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32")] uint outputId, [NativeTypeName("NV_GPU_OUTPUT_TYPE *")] _NV_GPU_OUTPUT_TYPE* pOutputType);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_ValidateOutputCombination"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_ValidateOutputCombination([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32")] uint outputsMask);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetFullName"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetFullName([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvAPI_ShortString")] sbyte* szName);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetPCIIdentifiers"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetPCIIdentifiers([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32 *")] uint* pDeviceId, [NativeTypeName("NvU32 *")] uint* pSubSystemId, [NativeTypeName("NvU32 *")] uint* pRevisionId, [NativeTypeName("NvU32 *")] uint* pExtDeviceId);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetGPUType"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetGPUType([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_GPU_TYPE *")] _NV_GPU_TYPE* pGpuType);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetBusType"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetBusType([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_GPU_BUS_TYPE *")] _NV_GPU_BUS_TYPE* pBusType);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetBusId"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetBusId([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32 *")] uint* pBusId);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetBusSlotId"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetBusSlotId([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32 *")] uint* pBusSlotId);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetIRQ"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetIRQ([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32 *")] uint* pIRQ);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetVbiosRevision"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetVbiosRevision([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32 *")] uint* pBiosRevision);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetVbiosOEMRevision"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetVbiosOEMRevision([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32 *")] uint* pBiosRevision);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetVbiosVersionString"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetVbiosVersionString([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvAPI_ShortString")] sbyte* szBiosRevision);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetAGPAperture"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 455.")]
        public static extern _NvAPI_Status NvAPI_GPU_GetAGPAperture([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32 *")] uint* pSize);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetCurrentAGPRate"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 455.")]
        public static extern _NvAPI_Status NvAPI_GPU_GetCurrentAGPRate([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32 *")] uint* pRate);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetCurrentPCIEDownstreamWidth"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetCurrentPCIEDownstreamWidth([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32 *")] uint* pWidth);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetPhysicalFrameBufferSize"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetPhysicalFrameBufferSize([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32 *")] uint* pSize);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetVirtualFrameBufferSize"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetVirtualFrameBufferSize([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32 *")] uint* pSize);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetQuadroStatus"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 460.")]
        public static extern _NvAPI_Status NvAPI_GPU_GetQuadroStatus([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32 *")] uint* pStatus);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetBoardInfo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetBoardInfo([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_BOARD_INFO *")] _NV_BOARD_INFO* pBoardInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetRamBusWidth"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetRamBusWidth([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32 *")] uint* pBusWidth);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetArchInfo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetArchInfo([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_GPU_ARCH_INFO *")] NV_GPU_ARCH_INFO_V2* pGpuArchInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_I2CRead"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_I2CRead([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_I2C_INFO *")] NV_I2C_INFO_V3* pI2cInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_I2CWrite"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_I2CWrite([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_I2C_INFO *")] NV_I2C_INFO_V3* pI2cInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_WorkstationFeatureSetup"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_WorkstationFeatureSetup([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32")] uint featureEnableMask, [NativeTypeName("NvU32")] uint featureDisableMask);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_WorkstationFeatureQuery"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_WorkstationFeatureQuery([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32 *")] uint* pConfiguredFeatureMask, [NativeTypeName("NvU32 *")] uint* pConsistentFeatureMask);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetHDCPSupportStatus"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetHDCPSupportStatus([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, NV_GPU_GET_HDCP_SUPPORT_STATUS* pGetHDCPSupportStatus);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_CudaEnumComputeCapableGpus"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 319.")]
        public static extern _NvAPI_Status NvAPI_GPU_CudaEnumComputeCapableGpus([NativeTypeName("NV_COMPUTE_GPU_TOPOLOGY *")] _NV_COMPUTE_GPU_TOPOLOGY_V2* pComputeTopo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetTachReading"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetTachReading([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGPU, [NativeTypeName("NvU32 *")] uint* pValue);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetECCStatusInfo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetECCStatusInfo([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, NV_GPU_ECC_STATUS_INFO* pECCStatusInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetECCErrorInfo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetECCErrorInfo([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, NV_GPU_ECC_ERROR_INFO* pECCErrorInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_ResetECCErrorInfo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_ResetECCErrorInfo([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU8")] byte bResetCurrent, [NativeTypeName("NvU8")] byte bResetAggregate);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetECCConfigurationInfo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetECCConfigurationInfo([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, NV_GPU_ECC_CONFIGURATION_INFO* pECCConfigurationInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_SetECCConfiguration"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_SetECCConfiguration([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU8")] byte bEnable, [NativeTypeName("NvU8")] byte bEnableImmediately);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_QueryWorkstationFeatureSupport"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_QueryWorkstationFeatureSupport([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* physicalGpu, [NativeTypeName("NV_GPU_WORKSTATION_FEATURE_TYPE")] _NV_GPU_WORKSTATION_FEATURE_TYPE gpuWorkstationFeature);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_SetScanoutIntensity"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_SetScanoutIntensity([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NV_SCANOUT_INTENSITY_DATA *")] NV_SCANOUT_INTENSITY_DATA_V2* scanoutIntensityData, int* pbSticky);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetScanoutIntensityState"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetScanoutIntensityState([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NV_SCANOUT_INTENSITY_STATE_DATA *")] _NV_SCANOUT_INTENSITY_STATE_DATA* scanoutIntensityStateData);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_SetScanoutWarping"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_SetScanoutWarping([NativeTypeName("NvU32")] uint displayId, NV_SCANOUT_WARPING_DATA* scanoutWarpingData, int* piMaxNumVertices, int* pbSticky);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetScanoutWarpingState"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetScanoutWarpingState([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NV_SCANOUT_WARPING_STATE_DATA *")] _NV_SCANOUT_WARPING_STATE_DATA* scanoutWarpingStateData);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_SetScanoutCompositionParameter"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_SetScanoutCompositionParameter([NativeTypeName("NvU32")] uint displayId, NV_GPU_SCANOUT_COMPOSITION_PARAMETER parameter, NV_GPU_SCANOUT_COMPOSITION_PARAMETER_VALUE parameterValue, float* pContainer);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetScanoutCompositionParameter"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetScanoutCompositionParameter([NativeTypeName("NvU32")] uint displayId, NV_GPU_SCANOUT_COMPOSITION_PARAMETER parameter, NV_GPU_SCANOUT_COMPOSITION_PARAMETER_VALUE* parameterData, float* pContainer);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetScanoutConfiguration"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetScanoutConfiguration([NativeTypeName("NvU32")] uint displayId, NvSBox* desktopRect, NvSBox* scanoutRect);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetScanoutConfigurationEx"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetScanoutConfigurationEx([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NV_SCANOUT_INFORMATION *")] _NV_SCANOUT_INFORMATION* pScanoutInformation);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetAdapterIdFromPhysicalGpu"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 520. Instead, use NvAPI_GPU_GetLogicalGpuInfo.")]
        public static extern _NvAPI_Status NvAPI_GPU_GetAdapterIdFromPhysicalGpu([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, void* pOSAdapterId);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetVirtualizationInfo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetVirtualizationInfo([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_GPU_VIRTUALIZATION_INFO *")] _NV_GPU_VIRTUALIZATION_INFO* pVirtualizationInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetLogicalGpuInfo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetLogicalGpuInfo([NativeTypeName("NvLogicalGpuHandle")] NvLogicalGpuHandle__* hLogicalGpu, [NativeTypeName("NV_LOGICAL_GPU_DATA *")] _NV_LOGICAL_GPU_DATA_V1* pLogicalGpuData);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetLicensableFeatures"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetLicensableFeatures([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_LICENSABLE_FEATURES *")] _NV_LICENSABLE_FEATURES_V4* pLicensableFeatures);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetEncoderStatistics"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetEncoderStatistics([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_ENCODER_STATISTICS *")] _NV_ENCODER_STATISTICS_V1* pEncoderStatistics);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetEncoderSessionsInfo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetEncoderSessionsInfo([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_ENCODER_SESSIONS_INFO *")] _NV_ENCODER_SESSIONS_INFO_V1* pEncoderSessionsInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetGPUInfo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetGPUInfo([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_GPU_INFO *")] _NV_GPU_INFO_V2* pGpuInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetVRReadyData"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetVRReadyData([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_GPU_VR_READY *")] _NV_GPU_VR_READY_V1* pGpuVrReadyData);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetGspFeatures"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetGspFeatures([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_GPU_GSP_INFO *")] _NV_GPU_GSP_INFO_V1* pGspInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_NVLINK_GetCaps"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_NVLINK_GetCaps([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NVLINK_GET_CAPS *")] NVLINK_GET_CAPS_V1* capsParams);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_NVLINK_GetStatus"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_NVLINK_GetStatus([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NVLINK_GET_STATUS *")] NVLINK_GET_STATUS_V2* statusParams);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetPerfDecreaseInfo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetPerfDecreaseInfo([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32 *")] uint* pPerfDecrInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetPstatesInfoEx"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 304. Instead, use NvAPI_GPU_GetPstates20.")]
        public static extern _NvAPI_Status NvAPI_GPU_GetPstatesInfoEx([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_GPU_PERF_PSTATES_INFO *")] NV_GPU_PERF_PSTATES_INFO_V2* pPerfPstatesInfo, [NativeTypeName("NvU32")] uint inputFlags);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetPstates20"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetPstates20([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_GPU_PERF_PSTATES20_INFO *")] _NV_GPU_PERF_PSTATES20_INFO_V2* pPstatesInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetCurrentPstate"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetCurrentPstate([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_GPU_PERF_PSTATE_ID *")] _NV_GPU_PERF_PSTATE_ID* pCurrentPstate);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetDynamicPstatesInfoEx"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetDynamicPstatesInfoEx([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, NV_GPU_DYNAMIC_PSTATES_INFO_EX* pDynamicPstatesInfoEx);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetThermalSettings"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetThermalSettings([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32")] uint sensorIndex, [NativeTypeName("NV_GPU_THERMAL_SETTINGS *")] NV_GPU_THERMAL_SETTINGS_V2* pThermalSettings);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetAllClockFrequencies"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetAllClockFrequencies([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGPU, [NativeTypeName("NV_GPU_CLOCK_FREQUENCIES *")] NV_GPU_CLOCK_FREQUENCIES_V2* pClkFreqs);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_QueryIlluminationSupport"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_QueryIlluminationSupport([NativeTypeName("NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM *")] _NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_V1* pIlluminationSupportInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_GetIllumination"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_GetIllumination([NativeTypeName("NV_GPU_GET_ILLUMINATION_PARM *")] _NV_GPU_GET_ILLUMINATION_PARM_V1* pIlluminationInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_SetIllumination"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_SetIllumination([NativeTypeName("NV_GPU_SET_ILLUMINATION_PARM *")] _NV_GPU_SET_ILLUMINATION_PARM_V1* pIlluminationInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_ClientIllumDevicesGetInfo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_ClientIllumDevicesGetInfo([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS *")] _NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_V1* pIllumDevicesInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_ClientIllumDevicesGetControl"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_ClientIllumDevicesGetControl([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS *")] NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_V1* pClientIllumDevicesControl);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_ClientIllumDevicesSetControl"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_ClientIllumDevicesSetControl([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS *")] NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_V1* pClientIllumDevicesControl);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_ClientIllumZonesGetInfo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_ClientIllumZonesGetInfo([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_GPU_CLIENT_ILLUM_ZONE_INFO_PARAMS *")] _NV_GPU_CLIENT_ILLUM_ZONE_INFO_PARAMS_V1* pIllumZonesInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_ClientIllumZonesGetControl"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_ClientIllumZonesGetControl([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS *")] _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1* pIllumZonesControl);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_ClientIllumZonesSetControl"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_ClientIllumZonesSetControl([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS *")] _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1* pIllumZonesControl);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Event_RegisterCallback"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Event_RegisterCallback([NativeTypeName("PNV_EVENT_REGISTER_CALLBACK")] NV_EVENT_REGISTER_CALLBACK* eventCallback, [NativeTypeName("NvEventHandle *")] NvEventHandle__** phClient);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Event_UnregisterCallback"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Event_UnregisterCallback([NativeTypeName("NvEventHandle")] NvEventHandle__* hClient);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_EnumNvidiaDisplayHandle"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_EnumNvidiaDisplayHandle([NativeTypeName("NvU32")] uint thisEnum, [NativeTypeName("NvDisplayHandle *")] NvDisplayHandle__** pNvDispHandle);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_EnumNvidiaUnAttachedDisplayHandle"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_EnumNvidiaUnAttachedDisplayHandle([NativeTypeName("NvU32")] uint thisEnum, [NativeTypeName("NvUnAttachedDisplayHandle *")] NvUnAttachedDisplayHandle__** pNvUnAttachedDispHandle);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_CreateDisplayFromUnAttachedDisplay"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_CreateDisplayFromUnAttachedDisplay([NativeTypeName("NvUnAttachedDisplayHandle")] NvUnAttachedDisplayHandle__* hNvUnAttachedDisp, [NativeTypeName("NvDisplayHandle *")] NvDisplayHandle__** pNvDisplay);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetAssociatedNvidiaDisplayHandle"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GetAssociatedNvidiaDisplayHandle([NativeTypeName("const char *")] sbyte* szDisplayName, [NativeTypeName("NvDisplayHandle *")] NvDisplayHandle__** pNvDispHandle);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_GetAssociatedUnAttachedNvidiaDisplayHandle"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DISP_GetAssociatedUnAttachedNvidiaDisplayHandle([NativeTypeName("const char *")] sbyte* szDisplayName, [NativeTypeName("NvUnAttachedDisplayHandle *")] NvUnAttachedDisplayHandle__** pNvUnAttachedDispHandle);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetAssociatedNvidiaDisplayName"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GetAssociatedNvidiaDisplayName([NativeTypeName("NvDisplayHandle")] NvDisplayHandle__* NvDispHandle, [NativeTypeName("NvAPI_ShortString")] sbyte* szDisplayName);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetUnAttachedAssociatedDisplayName"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GetUnAttachedAssociatedDisplayName([NativeTypeName("NvUnAttachedDisplayHandle")] NvUnAttachedDisplayHandle__* hNvUnAttachedDisp, [NativeTypeName("NvAPI_ShortString")] sbyte* szDisplayName);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_EnableHWCursor"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_EnableHWCursor([NativeTypeName("NvDisplayHandle")] NvDisplayHandle__* hNvDisplay);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DisableHWCursor"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DisableHWCursor([NativeTypeName("NvDisplayHandle")] NvDisplayHandle__* hNvDisplay);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetVBlankCounter"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GetVBlankCounter([NativeTypeName("NvDisplayHandle")] NvDisplayHandle__* hNvDisplay, [NativeTypeName("NvU32 *")] uint* pCounter);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_SetRefreshRateOverride"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_SetRefreshRateOverride([NativeTypeName("NvDisplayHandle")] NvDisplayHandle__* hNvDisplay, [NativeTypeName("NvU32")] uint outputsMask, float refreshRate, [NativeTypeName("NvU32")] uint bSetDeferred);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetAssociatedDisplayOutputId"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GetAssociatedDisplayOutputId([NativeTypeName("NvDisplayHandle")] NvDisplayHandle__* hNvDisplay, [NativeTypeName("NvU32 *")] uint* pOutputId);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetDisplayPortInfo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GetDisplayPortInfo([NativeTypeName("NvDisplayHandle")] NvDisplayHandle__* hNvDisplay, [NativeTypeName("NvU32")] uint outputId, [NativeTypeName("NV_DISPLAY_PORT_INFO *")] _NV_DISPLAY_PORT_INFO_V1* pInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_SetDisplayPort"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_SetDisplayPort([NativeTypeName("NvDisplayHandle")] NvDisplayHandle__* hNvDisplay, [NativeTypeName("NvU32")] uint outputId, NV_DISPLAY_PORT_CONFIG* pCfg);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetHDMISupportInfo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GetHDMISupportInfo([NativeTypeName("NvDisplayHandle")] NvDisplayHandle__* hNvDisplay, [NativeTypeName("NvU32")] uint outputId, [NativeTypeName("NV_HDMI_SUPPORT_INFO *")] _NV_HDMI_SUPPORT_INFO_V2* pInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_InfoFrameControl"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Disp_InfoFrameControl([NativeTypeName("NvU32")] uint displayId, NV_INFOFRAME_DATA* pInfoframeData);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_ColorControl"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Disp_ColorControl([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NV_COLOR_DATA *")] _NV_COLOR_DATA_V5* pColorData);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_GetHdrCapabilities"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Disp_GetHdrCapabilities([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NV_HDR_CAPABILITIES *")] _NV_HDR_CAPABILITIES_V3* pHdrCapabilities);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_HdrColorControl"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Disp_HdrColorControl([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NV_HDR_COLOR_DATA *")] _NV_HDR_COLOR_DATA_V2* pHdrColorData);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_SetSourceColorSpace"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Disp_SetSourceColorSpace([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NV_COLORSPACE_TYPE")] _NV_COLORSPACE_TYPE colorSpaceType);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_GetSourceColorSpace"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Disp_GetSourceColorSpace([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NV_COLORSPACE_TYPE *")] _NV_COLORSPACE_TYPE* pColorSpaceType, [NativeTypeName("NvU64")] ulong sourcePID);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_SetSourceHdrMetadata"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Disp_SetSourceHdrMetadata([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NV_HDR_METADATA *")] _NV_HDR_METADATA_V1* pMetadata);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_GetSourceHdrMetadata"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Disp_GetSourceHdrMetadata([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NV_HDR_METADATA *")] _NV_HDR_METADATA_V1* pMetadata, [NativeTypeName("NvU64")] ulong sourcePID);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_SetOutputMode"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Disp_SetOutputMode([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NV_DISPLAY_OUTPUT_MODE *")] _NV_DISPLAY_OUTPUT_MODE* pDisplayMode);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_GetOutputMode"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Disp_GetOutputMode([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NV_DISPLAY_OUTPUT_MODE *")] _NV_DISPLAY_OUTPUT_MODE* pDisplayMode);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_SetHdrToneMapping"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Disp_SetHdrToneMapping([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NV_HDR_TONEMAPPING_METHOD")] _NV_HDR_TONEMAPPING_METHOD hdrTonemapping);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_GetHdrToneMapping"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Disp_GetHdrToneMapping([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NV_HDR_TONEMAPPING_METHOD *")] _NV_HDR_TONEMAPPING_METHOD* pHdrTonemapping);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_GetColorimetry"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Disp_GetColorimetry([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NV_DISPLAY_COLORIMETRY *")] _NV_DISPLAY_COLORIMETRY_V1* pColorimetry);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_GetTiming"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DISP_GetTiming([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NV_TIMING_INPUT *")] _NV_TIMING_INPUT* timingInput, [NativeTypeName("NV_TIMING *")] _NV_TIMING* pTiming);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_GetMonitorCapabilities"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DISP_GetMonitorCapabilities([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NV_MONITOR_CAPABILITIES *")] _NV_MONITOR_CAPABILITIES_V1* pMonitorCapabilities);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_GetMonitorColorCapabilities"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DISP_GetMonitorColorCapabilities([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NV_MONITOR_COLOR_CAPS *")] _NV_MONITOR_COLOR_DATA* pMonitorColorCapabilities, [NativeTypeName("NvU32 *")] uint* pColorCapsCount);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_EnumCustomDisplay"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DISP_EnumCustomDisplay([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NvU32")] uint index, NV_CUSTOM_DISPLAY* pCustDisp);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_TryCustomDisplay"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DISP_TryCustomDisplay([NativeTypeName("NvU32 *")] uint* pDisplayIds, [NativeTypeName("NvU32")] uint count, NV_CUSTOM_DISPLAY* pCustDisp);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_DeleteCustomDisplay"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DISP_DeleteCustomDisplay([NativeTypeName("NvU32 *")] uint* pDisplayIds, [NativeTypeName("NvU32")] uint count, NV_CUSTOM_DISPLAY* pCustDisp);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_SaveCustomDisplay"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DISP_SaveCustomDisplay([NativeTypeName("NvU32 *")] uint* pDisplayIds, [NativeTypeName("NvU32")] uint count, [NativeTypeName("NvU32")] uint isThisOutputIdOnly, [NativeTypeName("NvU32")] uint isThisMonitorIdOnly);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_RevertCustomDisplayTrial"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DISP_RevertCustomDisplayTrial([NativeTypeName("NvU32 *")] uint* pDisplayIds, [NativeTypeName("NvU32")] uint count);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetView"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_DISP_GetDisplayConfig.")]
        public static extern _NvAPI_Status NvAPI_GetView([NativeTypeName("NvDisplayHandle")] NvDisplayHandle__* hNvDisplay, NV_VIEW_TARGET_INFO* pTargets, [NativeTypeName("NvU32 *")] uint* pTargetMaskCount, [NativeTypeName("NV_TARGET_VIEW_MODE *")] _NV_TARGET_VIEW_MODE* pTargetView);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetViewEx"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_DISP_GetDisplayConfig.")]
        public static extern _NvAPI_Status NvAPI_GetViewEx([NativeTypeName("NvDisplayHandle")] NvDisplayHandle__* hNvDisplay, NV_DISPLAY_PATH_INFO* pPathInfo, [NativeTypeName("NvU32 *")] uint* pPathCount, [NativeTypeName("NV_TARGET_VIEW_MODE *")] _NV_TARGET_VIEW_MODE* pTargetViewMode);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetSupportedViews"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GetSupportedViews([NativeTypeName("NvDisplayHandle")] NvDisplayHandle__* hNvDisplay, [NativeTypeName("NV_TARGET_VIEW_MODE *")] _NV_TARGET_VIEW_MODE* pTargetViews, [NativeTypeName("NvU32 *")] uint* pViewCount);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_GetDisplayIdByDisplayName"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DISP_GetDisplayIdByDisplayName([NativeTypeName("const char *")] sbyte* displayName, [NativeTypeName("NvU32 *")] uint* displayId);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_GetDisplayConfig"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DISP_GetDisplayConfig([NativeTypeName("NvU32 *")] uint* pathInfoCount, [NativeTypeName("NV_DISPLAYCONFIG_PATH_INFO *")] _NV_DISPLAYCONFIG_PATH_INFO* pathInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_SetDisplayConfig"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DISP_SetDisplayConfig([NativeTypeName("NvU32")] uint pathInfoCount, [NativeTypeName("NV_DISPLAYCONFIG_PATH_INFO *")] _NV_DISPLAYCONFIG_PATH_INFO* pathInfo, [NativeTypeName("NvU32")] uint flags);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_GetEdidData"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DISP_GetEdidData([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NV_EDID_DATA *")] _NV_EDID_DATA_V2* pEdidParams, NV_EDID_FLAG* pFlag);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_GetAdaptiveSyncData"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DISP_GetAdaptiveSyncData([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NV_GET_ADAPTIVE_SYNC_DATA *")] _NV_GET_ADAPTIVE_SYNC_DATA_V1* pAdaptiveSyncData);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_SetAdaptiveSyncData"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DISP_SetAdaptiveSyncData([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NV_SET_ADAPTIVE_SYNC_DATA *")] _NV_SET_ADAPTIVE_SYNC_DATA_V1* pAdaptiveSyncData);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_GetVirtualRefreshRateData"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DISP_GetVirtualRefreshRateData([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NV_GET_VIRTUAL_REFRESH_RATE_DATA *")] _NV_GET_VIRTUAL_REFRESH_RATE_DATA_V2* pVirtualRefreshRateData);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_SetVirtualRefreshRateData"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DISP_SetVirtualRefreshRateData([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NV_SET_VIRTUAL_REFRESH_RATE_DATA *")] _NV_SET_VIRTUAL_REFRESH_RATE_DATA_V2* pVirtualRefreshRateData);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_SetPreferredStereoDisplay"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DISP_SetPreferredStereoDisplay([NativeTypeName("NV_SET_PREFERRED_STEREO_DISPLAY *")] NV_SET_PREFERRED_STEREO_DISPLAY_V1* pPreferredStereoDisplay);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_GetPreferredStereoDisplay"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DISP_GetPreferredStereoDisplay([NativeTypeName("NV_GET_PREFERRED_STEREO_DISPLAY *")] NV_GET_PREFERRED_STEREO_DISPLAY_V1* pPreferredStereoDisplay);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_GetNvManagedDedicatedDisplays"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DISP_GetNvManagedDedicatedDisplays([NativeTypeName("NvU32 *")] uint* pDedicatedDisplayCount, [NativeTypeName("NV_MANAGED_DEDICATED_DISPLAY_INFO *")] _NV_MANAGED_DEDICATED_DISPLAY_INFO* pDedicatedDisplays);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_AcquireDedicatedDisplay"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DISP_AcquireDedicatedDisplay([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NvU64 *")] ulong* pDisplaySourceHandle);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_ReleaseDedicatedDisplay"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DISP_ReleaseDedicatedDisplay([NativeTypeName("NvU32")] uint displayId);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_GetNvManagedDedicatedDisplayMetadata"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DISP_GetNvManagedDedicatedDisplayMetadata([NativeTypeName("NV_MANAGED_DEDICATED_DISPLAY_METADATA *")] _NV_MANAGED_DEDICATED_DISPLAY_METADATA* pDedicatedDisplayMetadata);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DISP_SetNvManagedDedicatedDisplayMetadata"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DISP_SetNvManagedDedicatedDisplayMetadata([NativeTypeName("NV_MANAGED_DEDICATED_DISPLAY_METADATA *")] _NV_MANAGED_DEDICATED_DISPLAY_METADATA* pDedicatedDisplayMetadata);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Disp_GetVRRInfo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Disp_GetVRRInfo([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NV_GET_VRR_INFO *")] _NV_GET_VRR_INFO_V1* pVrrInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Mosaic_GetSupportedTopoInfo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Mosaic_GetSupportedTopoInfo([NativeTypeName("NV_MOSAIC_SUPPORTED_TOPO_INFO *")] _NV_MOSAIC_SUPPORTED_TOPO_INFO_V2* pSupportedTopoInfo, NV_MOSAIC_TOPO_TYPE type);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Mosaic_GetTopoGroup"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Mosaic_GetTopoGroup(NV_MOSAIC_TOPO_BRIEF* pTopoBrief, NV_MOSAIC_TOPO_GROUP* pTopoGroup);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Mosaic_GetOverlapLimits"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Mosaic_GetOverlapLimits(NV_MOSAIC_TOPO_BRIEF* pTopoBrief, [NativeTypeName("NV_MOSAIC_DISPLAY_SETTING *")] NV_MOSAIC_DISPLAY_SETTING_V2* pDisplaySetting, [NativeTypeName("NvS32 *")] int* pMinOverlapX, [NativeTypeName("NvS32 *")] int* pMaxOverlapX, [NativeTypeName("NvS32 *")] int* pMinOverlapY, [NativeTypeName("NvS32 *")] int* pMaxOverlapY);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Mosaic_SetCurrentTopo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Mosaic_SetCurrentTopo(NV_MOSAIC_TOPO_BRIEF* pTopoBrief, [NativeTypeName("NV_MOSAIC_DISPLAY_SETTING *")] NV_MOSAIC_DISPLAY_SETTING_V2* pDisplaySetting, [NativeTypeName("NvS32")] int overlapX, [NativeTypeName("NvS32")] int overlapY, [NativeTypeName("NvU32")] uint enable);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Mosaic_GetCurrentTopo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Mosaic_GetCurrentTopo(NV_MOSAIC_TOPO_BRIEF* pTopoBrief, [NativeTypeName("NV_MOSAIC_DISPLAY_SETTING *")] NV_MOSAIC_DISPLAY_SETTING_V2* pDisplaySetting, [NativeTypeName("NvS32 *")] int* pOverlapX, [NativeTypeName("NvS32 *")] int* pOverlapY);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Mosaic_EnableCurrentTopo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Mosaic_EnableCurrentTopo([NativeTypeName("NvU32")] uint enable);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Mosaic_SetDisplayGrids"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Mosaic_SetDisplayGrids([NativeTypeName("NV_MOSAIC_GRID_TOPO *")] _NV_MOSAIC_GRID_TOPO_V2* pGridTopologies, [NativeTypeName("NvU32")] uint gridCount, [NativeTypeName("NvU32")] uint setTopoFlags);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Mosaic_ValidateDisplayGrids"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Mosaic_ValidateDisplayGrids([NativeTypeName("NvU32")] uint setTopoFlags, [NativeTypeName("NV_MOSAIC_GRID_TOPO *")] _NV_MOSAIC_GRID_TOPO_V2* pGridTopologies, NV_MOSAIC_DISPLAY_TOPO_STATUS* pTopoStatus, [NativeTypeName("NvU32")] uint gridCount);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Mosaic_EnumDisplayModes"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Mosaic_EnumDisplayModes([NativeTypeName("NV_MOSAIC_GRID_TOPO *")] _NV_MOSAIC_GRID_TOPO_V2* pGridTopology, [NativeTypeName("NV_MOSAIC_DISPLAY_SETTING *")] NV_MOSAIC_DISPLAY_SETTING_V2* pDisplaySettings, [NativeTypeName("NvU32 *")] uint* pDisplayCount);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Mosaic_EnumDisplayGrids"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Mosaic_EnumDisplayGrids([NativeTypeName("NV_MOSAIC_GRID_TOPO *")] _NV_MOSAIC_GRID_TOPO_V2* pGridTopologies, [NativeTypeName("NvU32 *")] uint* pGridCount);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetSupportedMosaicTopologies"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GetSupportedMosaicTopologies(NV_MOSAIC_SUPPORTED_TOPOLOGIES* pMosaicTopos);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GetCurrentMosaicTopology"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GetCurrentMosaicTopology(NV_MOSAIC_TOPOLOGY* pMosaicTopo, [NativeTypeName("NvU32 *")] uint* pEnabled);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_SetCurrentMosaicTopology"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_SetCurrentMosaicTopology(NV_MOSAIC_TOPOLOGY* pMosaicTopo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_EnableCurrentMosaicTopology"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_EnableCurrentMosaicTopology([NativeTypeName("NvU32")] uint enable);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GSync_EnumSyncDevices"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GSync_EnumSyncDevices([NativeTypeName("NvGSyncDeviceHandle[4]")] NvGSyncDeviceHandle__** nvGSyncHandles, [NativeTypeName("NvU32 *")] uint* gsyncCount);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GSync_QueryCapabilities"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GSync_QueryCapabilities([NativeTypeName("NvGSyncDeviceHandle")] NvGSyncDeviceHandle__* hNvGSyncDevice, [NativeTypeName("NV_GSYNC_CAPABILITIES *")] _NV_GSYNC_CAPABILITIES_V3* pNvGSyncCapabilities);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GSync_GetTopology"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GSync_GetTopology([NativeTypeName("NvGSyncDeviceHandle")] NvGSyncDeviceHandle__* hNvGSyncDevice, [NativeTypeName("NvU32 *")] uint* gsyncGpuCount, [NativeTypeName("NV_GSYNC_GPU *")] _NV_GSYNC_GPU* gsyncGPUs, [NativeTypeName("NvU32 *")] uint* gsyncDisplayCount, [NativeTypeName("NV_GSYNC_DISPLAY *")] _NV_GSYNC_DISPLAY* gsyncDisplays);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GSync_SetSyncStateSettings"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GSync_SetSyncStateSettings([NativeTypeName("NvU32")] uint gsyncDisplayCount, [NativeTypeName("NV_GSYNC_DISPLAY *")] _NV_GSYNC_DISPLAY* pGsyncDisplays, [NativeTypeName("NvU32")] uint flags);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GSync_GetControlParameters"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GSync_GetControlParameters([NativeTypeName("NvGSyncDeviceHandle")] NvGSyncDeviceHandle__* hNvGSyncDevice, [NativeTypeName("NV_GSYNC_CONTROL_PARAMS *")] _NV_GSYNC_CONTROL_PARAMS_V2* pGsyncControls);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GSync_SetControlParameters"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GSync_SetControlParameters([NativeTypeName("NvGSyncDeviceHandle")] NvGSyncDeviceHandle__* hNvGSyncDevice, [NativeTypeName("NV_GSYNC_CONTROL_PARAMS *")] _NV_GSYNC_CONTROL_PARAMS_V2* pGsyncControls);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GSync_AdjustSyncDelay"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GSync_AdjustSyncDelay([NativeTypeName("NvGSyncDeviceHandle")] NvGSyncDeviceHandle__* hNvGSyncDevice, [NativeTypeName("NVAPI_GSYNC_DELAY_TYPE")] _NVAPI_GSYNC_DELAY_TYPE delayType, [NativeTypeName("NV_GSYNC_DELAY *")] _NV_GSYNC_DELAY* pGsyncDelay, [NativeTypeName("NvU32 *")] uint* syncSteps);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GSync_GetSyncStatus"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GSync_GetSyncStatus([NativeTypeName("NvGSyncDeviceHandle")] NvGSyncDeviceHandle__* hNvGSyncDevice, [NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_GSYNC_STATUS *")] _NV_GSYNC_STATUS* status);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GSync_GetStatusParameters"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GSync_GetStatusParameters([NativeTypeName("NvGSyncDeviceHandle")] NvGSyncDeviceHandle__* hNvGSyncDevice, [NativeTypeName("NV_GSYNC_STATUS_PARAMS *")] _NV_GSYNC_STATUS_PARAMS_V2* pStatusParams);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DestroyPresentBarrierClient"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DestroyPresentBarrierClient([NativeTypeName("NvPresentBarrierClientHandle")] NvPresentBarrierClientHandle__* presentBarrierClient);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_JoinPresentBarrier"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_JoinPresentBarrier([NativeTypeName("NvPresentBarrierClientHandle")] NvPresentBarrierClientHandle__* presentBarrierClient, [NativeTypeName("NV_JOIN_PRESENT_BARRIER_PARAMS *")] _NV_JOIN_PRESENT_BARRIER_PARAMS* pParams);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_LeavePresentBarrier"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_LeavePresentBarrier([NativeTypeName("NvPresentBarrierClientHandle")] NvPresentBarrierClientHandle__* presentBarrierClient);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_QueryPresentBarrierFrameStatistics"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_QueryPresentBarrierFrameStatistics([NativeTypeName("NvPresentBarrierClientHandle")] NvPresentBarrierClientHandle__* presentBarrierClient, [NativeTypeName("NV_PRESENT_BARRIER_FRAME_STATISTICS *")] _NV_PRESENT_BARRIER_FRAME_STATISTICS* pFrameStats);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_NGX_GetNGXOverrideState"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_NGX_GetNGXOverrideState([NativeTypeName("NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS *")] _NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1* pGetOverrideStateParams);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_NGX_SetNGXOverrideState"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_NGX_SetNGXOverrideState([NativeTypeName("NV_NGX_DLSS_OVERRIDE_SET_STATE_PARAMS *")] _NV_NGX_DLSS_OVERRIDE_SET_STATE_PARAMS_V1* pSetOverrideStateParams);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_GetCapabilities"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static extern _NvAPI_Status NvAPI_VIO_GetCapabilities([NativeTypeName("NvVioHandle")] NvVioHandle__* hVioHandle, [NativeTypeName("NVVIOCAPS *")] _NVVIOCAPS* pAdapterCaps);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_Open"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static extern _NvAPI_Status NvAPI_VIO_Open([NativeTypeName("NvVioHandle")] NvVioHandle__* hVioHandle, [NativeTypeName("NvU32")] uint vioClass, [NativeTypeName("NVVIOOWNERTYPE")] _NVVIOOWNERTYPE ownerType);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_Close"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static extern _NvAPI_Status NvAPI_VIO_Close([NativeTypeName("NvVioHandle")] NvVioHandle__* hVioHandle, [NativeTypeName("NvU32")] uint bRelease);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_Status"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static extern _NvAPI_Status NvAPI_VIO_Status([NativeTypeName("NvVioHandle")] NvVioHandle__* hVioHandle, [NativeTypeName("NVVIOSTATUS *")] _NVVIOSTATUS* pStatus);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_SyncFormatDetect"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static extern _NvAPI_Status NvAPI_VIO_SyncFormatDetect([NativeTypeName("NvVioHandle")] NvVioHandle__* hVioHandle, [NativeTypeName("NvU32 *")] uint* pWait);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_GetConfig"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static extern _NvAPI_Status NvAPI_VIO_GetConfig([NativeTypeName("NvVioHandle")] NvVioHandle__* hVioHandle, [NativeTypeName("NVVIOCONFIG *")] _NVVIOCONFIG_V3* pConfig);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_SetConfig"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static extern _NvAPI_Status NvAPI_VIO_SetConfig([NativeTypeName("NvVioHandle")] NvVioHandle__* hVioHandle, [NativeTypeName("const NVVIOCONFIG *")] _NVVIOCONFIG_V3* pConfig);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_SetCSC"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_VIO_SetConfig.")]
        public static extern _NvAPI_Status NvAPI_VIO_SetCSC([NativeTypeName("NvVioHandle")] NvVioHandle__* hVioHandle, [NativeTypeName("NVVIOCOLORCONVERSION *")] _NVVIOCOLORCONVERSION* pCSC);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_GetCSC"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_VIO_GetConfig.")]
        public static extern _NvAPI_Status NvAPI_VIO_GetCSC([NativeTypeName("NvVioHandle")] NvVioHandle__* hVioHandle, [NativeTypeName("NVVIOCOLORCONVERSION *")] _NVVIOCOLORCONVERSION* pCSC);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_SetGamma"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_VIO_SetConfig.")]
        public static extern _NvAPI_Status NvAPI_VIO_SetGamma([NativeTypeName("NvVioHandle")] NvVioHandle__* hVioHandle, [NativeTypeName("NVVIOGAMMACORRECTION *")] _NVVIOGAMMACORRECTION* pGamma);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_GetGamma"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_VIO_GetConfig.")]
        public static extern _NvAPI_Status NvAPI_VIO_GetGamma([NativeTypeName("NvVioHandle")] NvVioHandle__* hVioHandle, [NativeTypeName("NVVIOGAMMACORRECTION *")] _NVVIOGAMMACORRECTION* pGamma);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_SetSyncDelay"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_VIO_SetConfig.")]
        public static extern _NvAPI_Status NvAPI_VIO_SetSyncDelay([NativeTypeName("NvVioHandle")] NvVioHandle__* hVioHandle, [NativeTypeName("const NVVIOSYNCDELAY *")] _NVVIOSYNCDELAY* pSyncDelay);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_GetSyncDelay"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 290. Instead, use NvAPI_VIO_GetConfig.")]
        public static extern _NvAPI_Status NvAPI_VIO_GetSyncDelay([NativeTypeName("NvVioHandle")] NvVioHandle__* hVioHandle, [NativeTypeName("NVVIOSYNCDELAY *")] _NVVIOSYNCDELAY* pSyncDelay);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_GetPCIInfo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static extern _NvAPI_Status NvAPI_VIO_GetPCIInfo([NativeTypeName("NvVioHandle")] NvVioHandle__* hVioHandle, [NativeTypeName("NVVIOPCIINFO *")] _NVVIOPCIINFO* pVioPCIInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_IsRunning"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static extern _NvAPI_Status NvAPI_VIO_IsRunning([NativeTypeName("NvVioHandle")] NvVioHandle__* hVioHandle);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_Start"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static extern _NvAPI_Status NvAPI_VIO_Start([NativeTypeName("NvVioHandle")] NvVioHandle__* hVioHandle);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_Stop"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static extern _NvAPI_Status NvAPI_VIO_Stop([NativeTypeName("NvVioHandle")] NvVioHandle__* hVioHandle);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_IsFrameLockModeCompatible"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static extern _NvAPI_Status NvAPI_VIO_IsFrameLockModeCompatible([NativeTypeName("NvVioHandle")] NvVioHandle__* hVioHandle, [NativeTypeName("NvU32")] uint srcEnumIndex, [NativeTypeName("NvU32")] uint destEnumIndex, [NativeTypeName("NvU32 *")] uint* pbCompatible);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_EnumDevices"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static extern _NvAPI_Status NvAPI_VIO_EnumDevices([NativeTypeName("NvVioHandle[8]")] NvVioHandle__** hVioHandle, [NativeTypeName("NvU32 *")] uint* vioDeviceCount);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_QueryTopology"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static extern _NvAPI_Status NvAPI_VIO_QueryTopology([NativeTypeName("NV_VIO_TOPOLOGY *")] _NV_VIO_TOPOLOGY* pNvVIOTopology);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_EnumSignalFormats"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static extern _NvAPI_Status NvAPI_VIO_EnumSignalFormats([NativeTypeName("NvVioHandle")] NvVioHandle__* hVioHandle, [NativeTypeName("NvU32")] uint enumIndex, [NativeTypeName("NVVIOSIGNALFORMATDETAIL *")] _NVVIOSIGNALFORMATDETAIL* pSignalFormatDetail);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_VIO_EnumDataFormats"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        [Obsolete("Do not use this function - it is deprecated in release 440.")]
        public static extern _NvAPI_Status NvAPI_VIO_EnumDataFormats([NativeTypeName("NvVioHandle")] NvVioHandle__* hVioHandle, [NativeTypeName("NvU32")] uint enumIndex, [NativeTypeName("NVVIODATAFORMATDETAIL *")] _NVVIODATAFORMATDETAIL* pDataFormatDetail);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_CreateConfigurationProfileRegistryKey"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_CreateConfigurationProfileRegistryKey([NativeTypeName("NV_STEREO_REGISTRY_PROFILE_TYPE")] _NV_StereoRegistryProfileType registryProfileType);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_DeleteConfigurationProfileRegistryKey"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_DeleteConfigurationProfileRegistryKey([NativeTypeName("NV_STEREO_REGISTRY_PROFILE_TYPE")] _NV_StereoRegistryProfileType registryProfileType);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_SetConfigurationProfileValue"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_SetConfigurationProfileValue([NativeTypeName("NV_STEREO_REGISTRY_PROFILE_TYPE")] _NV_StereoRegistryProfileType registryProfileType, [NativeTypeName("NV_STEREO_REGISTRY_ID")] _NV_StereoRegistryID valueRegistryID, void* pValue);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_DeleteConfigurationProfileValue"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_DeleteConfigurationProfileValue([NativeTypeName("NV_STEREO_REGISTRY_PROFILE_TYPE")] _NV_StereoRegistryProfileType registryProfileType, [NativeTypeName("NV_STEREO_REGISTRY_ID")] _NV_StereoRegistryID valueRegistryID);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_GetStereoSupport"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_GetStereoSupport([NativeTypeName("NvMonitorHandle")] NvMonitorHandle__* hMonitor, [NativeTypeName("NVAPI_STEREO_CAPS *")] _NVAPI_STEREO_CAPS* pCaps);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_DecreaseSeparation"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_DecreaseSeparation([NativeTypeName("StereoHandle")] void* stereoHandle);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_IncreaseSeparation"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_IncreaseSeparation([NativeTypeName("StereoHandle")] void* stereoHandle);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_DecreaseConvergence"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_DecreaseConvergence([NativeTypeName("StereoHandle")] void* stereoHandle);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_IncreaseConvergence"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_IncreaseConvergence([NativeTypeName("StereoHandle")] void* stereoHandle);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_GetFrustumAdjustMode"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_GetFrustumAdjustMode([NativeTypeName("StereoHandle")] void* stereoHandle, [NativeTypeName("NV_FRUSTUM_ADJUST_MODE *")] _NV_FrustumAdjustMode* pFrustumAdjustMode);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_SetFrustumAdjustMode"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_SetFrustumAdjustMode([NativeTypeName("StereoHandle")] void* stereoHandle, [NativeTypeName("NV_FRUSTUM_ADJUST_MODE")] _NV_FrustumAdjustMode newFrustumAdjustModeValue);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_CaptureJpegImage"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_CaptureJpegImage([NativeTypeName("StereoHandle")] void* stereoHandle, [NativeTypeName("NvU32")] uint quality);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_InitActivation"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_InitActivation([NativeTypeName("StereoHandle")] void* hStereoHandle, [NativeTypeName("NVAPI_STEREO_INIT_ACTIVATION_FLAGS")] _NVAPI_STEREO_INIT_ACTIVATION_FLAGS flags);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_Trigger_Activation"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_Trigger_Activation([NativeTypeName("StereoHandle")] void* hStereoHandle);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_CapturePngImage"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_CapturePngImage([NativeTypeName("StereoHandle")] void* stereoHandle);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_ReverseStereoBlitControl"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_ReverseStereoBlitControl([NativeTypeName("StereoHandle")] void* hStereoHandle, [NativeTypeName("NvU8")] byte TurnOn);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_Stereo_SetNotificationMessage"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_Stereo_SetNotificationMessage([NativeTypeName("StereoHandle")] void* hStereoHandle, [NativeTypeName("NvU64")] ulong hWnd, [NativeTypeName("NvU64")] ulong messageID);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_CreateSession"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_CreateSession([NativeTypeName("NvDRSSessionHandle *")] NvDRSSessionHandle__** phSession);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_DestroySession"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_DestroySession([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_LoadSettings"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_LoadSettings([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_SaveSettings"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_SaveSettings([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_LoadSettingsFromFile"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_LoadSettingsFromFile([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession, [NativeTypeName("NvAPI_UnicodeString")] ushort* fileName);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_SaveSettingsToFile"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_SaveSettingsToFile([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession, [NativeTypeName("NvAPI_UnicodeString")] ushort* fileName);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_CreateProfile"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_CreateProfile([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession, [NativeTypeName("NVDRS_PROFILE *")] _NVDRS_PROFILE_V1* pProfileInfo, [NativeTypeName("NvDRSProfileHandle *")] NvDRSProfileHandle__** phProfile);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_DeleteProfile"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_DeleteProfile([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession, [NativeTypeName("NvDRSProfileHandle")] NvDRSProfileHandle__* hProfile);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_SetCurrentGlobalProfile"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_SetCurrentGlobalProfile([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession, [NativeTypeName("NvAPI_UnicodeString")] ushort* wszGlobalProfileName);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_GetCurrentGlobalProfile"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_GetCurrentGlobalProfile([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession, [NativeTypeName("NvDRSProfileHandle *")] NvDRSProfileHandle__** phProfile);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_GetProfileInfo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_GetProfileInfo([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession, [NativeTypeName("NvDRSProfileHandle")] NvDRSProfileHandle__* hProfile, [NativeTypeName("NVDRS_PROFILE *")] _NVDRS_PROFILE_V1* pProfileInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_SetProfileInfo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_SetProfileInfo([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession, [NativeTypeName("NvDRSProfileHandle")] NvDRSProfileHandle__* hProfile, [NativeTypeName("NVDRS_PROFILE *")] _NVDRS_PROFILE_V1* pProfileInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_FindProfileByName"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_FindProfileByName([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession, [NativeTypeName("NvAPI_UnicodeString")] ushort* profileName, [NativeTypeName("NvDRSProfileHandle *")] NvDRSProfileHandle__** phProfile);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_EnumProfiles"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_EnumProfiles([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession, [NativeTypeName("NvU32")] uint index, [NativeTypeName("NvDRSProfileHandle *")] NvDRSProfileHandle__** phProfile);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_GetNumProfiles"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_GetNumProfiles([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession, [NativeTypeName("NvU32 *")] uint* numProfiles);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_CreateApplication"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_CreateApplication([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession, [NativeTypeName("NvDRSProfileHandle")] NvDRSProfileHandle__* hProfile, [NativeTypeName("NVDRS_APPLICATION *")] _NVDRS_APPLICATION_V4* pApplication);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_DeleteApplicationEx"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_DeleteApplicationEx([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession, [NativeTypeName("NvDRSProfileHandle")] NvDRSProfileHandle__* hProfile, [NativeTypeName("NVDRS_APPLICATION *")] _NVDRS_APPLICATION_V4* pApp);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_DeleteApplication"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_DeleteApplication([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession, [NativeTypeName("NvDRSProfileHandle")] NvDRSProfileHandle__* hProfile, [NativeTypeName("NvAPI_UnicodeString")] ushort* appName);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_GetApplicationInfo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_GetApplicationInfo([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession, [NativeTypeName("NvDRSProfileHandle")] NvDRSProfileHandle__* hProfile, [NativeTypeName("NvAPI_UnicodeString")] ushort* appName, [NativeTypeName("NVDRS_APPLICATION *")] _NVDRS_APPLICATION_V4* pApplication);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_EnumApplications"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_EnumApplications([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession, [NativeTypeName("NvDRSProfileHandle")] NvDRSProfileHandle__* hProfile, [NativeTypeName("NvU32")] uint startIndex, [NativeTypeName("NvU32 *")] uint* appCount, [NativeTypeName("NVDRS_APPLICATION *")] _NVDRS_APPLICATION_V4* pApplication);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_FindApplicationByName"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_FindApplicationByName([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession, [NativeTypeName("NvAPI_UnicodeString")] ushort* appName, [NativeTypeName("NvDRSProfileHandle *")] NvDRSProfileHandle__** phProfile, [NativeTypeName("NVDRS_APPLICATION *")] _NVDRS_APPLICATION_V4* pApplication);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_SetSetting"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_SetSetting([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession, [NativeTypeName("NvDRSProfileHandle")] NvDRSProfileHandle__* hProfile, [NativeTypeName("NVDRS_SETTING *")] _NVDRS_SETTING_V1* pSetting);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_GetSetting"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_GetSetting([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession, [NativeTypeName("NvDRSProfileHandle")] NvDRSProfileHandle__* hProfile, [NativeTypeName("NvU32")] uint settingId, [NativeTypeName("NVDRS_SETTING *")] _NVDRS_SETTING_V1* pSetting);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_EnumSettings"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_EnumSettings([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession, [NativeTypeName("NvDRSProfileHandle")] NvDRSProfileHandle__* hProfile, [NativeTypeName("NvU32")] uint startIndex, [NativeTypeName("NvU32 *")] uint* settingsCount, [NativeTypeName("NVDRS_SETTING *")] _NVDRS_SETTING_V1* pSetting);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_EnumAvailableSettingIds"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_EnumAvailableSettingIds([NativeTypeName("NvU32 *")] uint* pSettingIds, [NativeTypeName("NvU32 *")] uint* pMaxCount);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_EnumAvailableSettingValues"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_EnumAvailableSettingValues([NativeTypeName("NvU32")] uint settingId, [NativeTypeName("NvU32 *")] uint* pMaxNumValues, [NativeTypeName("NVDRS_SETTING_VALUES *")] _NVDRS_SETTING_VALUES* pSettingValues);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_GetSettingIdFromName"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_GetSettingIdFromName([NativeTypeName("NvAPI_UnicodeString")] ushort* settingName, [NativeTypeName("NvU32 *")] uint* pSettingId);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_GetSettingNameFromId"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_GetSettingNameFromId([NativeTypeName("NvU32")] uint settingId, [NativeTypeName("NvAPI_UnicodeString *")] ushort** pSettingName);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_DeleteProfileSetting"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_DeleteProfileSetting([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession, [NativeTypeName("NvDRSProfileHandle")] NvDRSProfileHandle__* hProfile, [NativeTypeName("NvU32")] uint settingId);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_RestoreAllDefaults"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_RestoreAllDefaults([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_RestoreProfileDefault"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_RestoreProfileDefault([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession, [NativeTypeName("NvDRSProfileHandle")] NvDRSProfileHandle__* hProfile);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_RestoreProfileDefaultSetting"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_RestoreProfileDefaultSetting([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession, [NativeTypeName("NvDRSProfileHandle")] NvDRSProfileHandle__* hProfile, [NativeTypeName("NvU32")] uint settingId);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_DRS_GetBaseProfile"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_DRS_GetBaseProfile([NativeTypeName("NvDRSSessionHandle")] NvDRSSessionHandle__* hSession, [NativeTypeName("NvDRSProfileHandle *")] NvDRSProfileHandle__** phProfile);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_SYS_GetChipSetInfo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_SYS_GetChipSetInfo(NV_CHIPSET_INFO_v4* pChipSetInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_SYS_GetLidAndDockInfo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_SYS_GetLidAndDockInfo(NV_LID_DOCK_PARAMS* pLidAndDock);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_SYS_GetDisplayIdFromGpuAndOutputId"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_SYS_GetDisplayIdFromGpuAndOutputId([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NvU32")] uint outputId, [NativeTypeName("NvU32 *")] uint* displayId);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_SYS_GetGpuAndOutputIdFromDisplayId"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_SYS_GetGpuAndOutputIdFromDisplayId([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NvPhysicalGpuHandle *")] NvPhysicalGpuHandle__** hPhysicalGpu, [NativeTypeName("NvU32 *")] uint* outputId);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_SYS_GetPhysicalGpuFromDisplayId"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_SYS_GetPhysicalGpuFromDisplayId([NativeTypeName("NvU32")] uint displayId, [NativeTypeName("NvPhysicalGpuHandle *")] NvPhysicalGpuHandle__** hPhysicalGpu);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_SYS_GetDisplayDriverInfo"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_SYS_GetDisplayDriverInfo([NativeTypeName("NV_DISPLAY_DRIVER_INFO *")] _NV_DISPLAY_DRIVER_INFO_V2* pDriverInfo);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_SYS_GetPhysicalGPUs"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_SYS_GetPhysicalGPUs([NativeTypeName("NV_PHYSICAL_GPUS *")] _NV_PHYSICAL_GPUS* pPhysicalGPUs);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_SYS_GetLogicalGPUs"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_SYS_GetLogicalGPUs([NativeTypeName("NV_LOGICAL_GPUS *")] _NV_LOGICAL_GPUS* pLogicalGPUs);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_GPU_ClientRegisterForUtilizationSampleUpdates"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_GPU_ClientRegisterForUtilizationSampleUpdates([NativeTypeName("NvPhysicalGpuHandle")] NvPhysicalGpuHandle__* hPhysicalGpu, [NativeTypeName("NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS *")] _NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS_V1* pCallbackSettings);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_RegisterRiseCallback"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_RegisterRiseCallback([NativeTypeName("NV_RISE_CALLBACK_SETTINGS *")] _NV_RISE_CALLBACK_SETTINGS_V1* pCallbackSettings);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_RequestRise"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_RequestRise([NativeTypeName("NV_REQUEST_RISE_SETTINGS *")] _NV_REQUEST_RISE_SETTINGS_V1* requestContent);

        /// <include file='NVAPI.xml' path='doc/member[@name="NVAPI.NvAPI_UninstallRise"]/*' />
        [DllImport("nvapi64", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("NvAPI_Status")]
        public static extern _NvAPI_Status NvAPI_UninstallRise([NativeTypeName("NV_UNINSTALL_RISE_SETTINGS *")] _NV_UNINSTALL_RISE_SETTINGS_V1* requestContent);

        [NativeTypeName("struct NVAPI_INTERFACE_TABLE[512]")]
        public static readonly NVAPI_INTERFACE_TABLE[] nvapi_interface_table = new NVAPI_INTERFACE_TABLE[512]
        {
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Initialize"u8,
                id = 0x0150e828,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Unload"u8,
                id = 0xd22bdd7e,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GetErrorMessage"u8,
                id = 0x6c2d048c,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GetInterfaceVersionString"u8,
                id = 0x01053fa5,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetEDID"u8,
                id = 0x37d32e69,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_SetView"u8,
                id = 0x0957d7b6,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_SetViewEx"u8,
                id = 0x06b89e68,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GetDisplayDriverVersion"u8,
                id = 0xf951a4d1,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_SYS_GetDriverAndBranchVersion"u8,
                id = 0x2926aaad,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetMemoryInfo"u8,
                id = 0x07f9b368,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetMemoryInfoEx"u8,
                id = 0xc0599498,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_OGL_ExpertModeSet"u8,
                id = 0x3805ef7a,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_OGL_ExpertModeGet"u8,
                id = 0x22ed9516,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_OGL_ExpertModeDefaultsSet"u8,
                id = 0xb47a657e,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_OGL_ExpertModeDefaultsGet"u8,
                id = 0xae921f12,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_EnumPhysicalGPUs"u8,
                id = 0xe5ac921f,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_EnumTCCPhysicalGPUs"u8,
                id = 0xd9930b07,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_EnumLogicalGPUs"u8,
                id = 0x48b3ea59,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GetPhysicalGPUsFromDisplay"u8,
                id = 0x34ef9506,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GetPhysicalGPUFromUnAttachedDisplay"u8,
                id = 0x5018ed61,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GetLogicalGPUFromDisplay"u8,
                id = 0xee1370cf,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GetLogicalGPUFromPhysicalGPU"u8,
                id = 0xadd604d1,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GetPhysicalGPUsFromLogicalGPU"u8,
                id = 0xaea3fa32,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GetPhysicalGPUFromGPUID"u8,
                id = 0x5380ad1a,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GetGPUIDfromPhysicalGPU"u8,
                id = 0x6533ea3e,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetShaderSubPipeCount"u8,
                id = 0x0be17923,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetGpuCoreCount"u8,
                id = 0xc7026a87,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetAllOutputs"u8,
                id = 0x7d554f8e,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetConnectedOutputs"u8,
                id = 0x1730bfc9,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetConnectedSLIOutputs"u8,
                id = 0x0680de09,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetConnectedDisplayIds"u8,
                id = 0x0078dba2,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetAllDisplayIds"u8,
                id = 0x785210a2,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetConnectedOutputsWithLidState"u8,
                id = 0xcf8caf39,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetConnectedSLIOutputsWithLidState"u8,
                id = 0x96043cc7,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetSystemType"u8,
                id = 0xbaaabfcc,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetActiveOutputs"u8,
                id = 0xe3e89b6f,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_SetEDID"u8,
                id = 0xe83d6456,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetOutputType"u8,
                id = 0x40a505e4,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_ValidateOutputCombination"u8,
                id = 0x34c9c2d4,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetFullName"u8,
                id = 0xceee8e9f,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetPCIIdentifiers"u8,
                id = 0x2ddfb66e,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetGPUType"u8,
                id = 0xc33baeb1,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetBusType"u8,
                id = 0x1bb18724,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetBusId"u8,
                id = 0x1be0b8e5,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetBusSlotId"u8,
                id = 0x2a0a350f,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetIRQ"u8,
                id = 0xe4715417,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetVbiosRevision"u8,
                id = 0xacc3da0a,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetVbiosOEMRevision"u8,
                id = 0x2d43fb31,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetVbiosVersionString"u8,
                id = 0xa561fd7d,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetAGPAperture"u8,
                id = 0x6e042794,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetCurrentAGPRate"u8,
                id = 0xc74925a0,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetCurrentPCIEDownstreamWidth"u8,
                id = 0xd048c3b1,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetPhysicalFrameBufferSize"u8,
                id = 0x46fbeb03,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetVirtualFrameBufferSize"u8,
                id = 0x5a04b644,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetQuadroStatus"u8,
                id = 0xe332fa47,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetBoardInfo"u8,
                id = 0x22d54523,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetRamBusWidth"u8,
                id = 0x7975c581,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetArchInfo"u8,
                id = 0xd8265d24,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_I2CRead"u8,
                id = 0x2fde12c5,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_I2CWrite"u8,
                id = 0xe812eb07,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_WorkstationFeatureSetup"u8,
                id = 0x6c1f3fe4,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_WorkstationFeatureQuery"u8,
                id = 0x004537df,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetHDCPSupportStatus"u8,
                id = 0xf089eef5,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_CudaEnumComputeCapableGpus"u8,
                id = 0x5786cc6e,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetTachReading"u8,
                id = 0x5f608315,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetECCStatusInfo"u8,
                id = 0xca1ddaf3,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetECCErrorInfo"u8,
                id = 0xc71f85a6,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_ResetECCErrorInfo"u8,
                id = 0xc02eec20,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetECCConfigurationInfo"u8,
                id = 0x77a796f3,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_SetECCConfiguration"u8,
                id = 0x1cf639d9,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_QueryWorkstationFeatureSupport"u8,
                id = 0x80b1abb9,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_SetScanoutIntensity"u8,
                id = 0xa57457a4,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetScanoutIntensityState"u8,
                id = 0xe81ce836,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_SetScanoutWarping"u8,
                id = 0xb34bab4f,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetScanoutWarpingState"u8,
                id = 0x6f5435af,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_SetScanoutCompositionParameter"u8,
                id = 0xf898247d,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetScanoutCompositionParameter"u8,
                id = 0x58fe51e6,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetScanoutConfiguration"u8,
                id = 0x6a9f5b63,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetScanoutConfigurationEx"u8,
                id = 0xe2e1e6f0,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetAdapterIdFromPhysicalGpu"u8,
                id = 0x0ff07fde,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetVirtualizationInfo"u8,
                id = 0x44e022a9,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetLogicalGpuInfo"u8,
                id = 0x842b066e,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetLicensableFeatures"u8,
                id = 0x3fc596aa,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetEncoderStatistics"u8,
                id = 0xf0a9aeeb,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetEncoderSessionsInfo"u8,
                id = 0xd8a72ce5,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetGPUInfo"u8,
                id = 0xafd1b02c,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetVRReadyData"u8,
                id = 0x81d629c5,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetGspFeatures"u8,
                id = 0x581c4391,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_NVLINK_GetCaps"u8,
                id = 0xbef1119d,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_NVLINK_GetStatus"u8,
                id = 0xc72a38e3,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetPerfDecreaseInfo"u8,
                id = 0x7f7f4600,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetPstatesInfoEx"u8,
                id = 0x843c0256,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetPstates20"u8,
                id = 0x6ff81213,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetCurrentPstate"u8,
                id = 0x927da4f6,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetDynamicPstatesInfoEx"u8,
                id = 0x60ded2ed,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetThermalSettings"u8,
                id = 0xe3640a56,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetAllClockFrequencies"u8,
                id = 0xdcb616c3,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_QueryIlluminationSupport"u8,
                id = 0xa629da31,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_GetIllumination"u8,
                id = 0x9a1b9365,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_SetIllumination"u8,
                id = 0x0254a187,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_ClientIllumDevicesGetInfo"u8,
                id = 0xd4100e58,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_ClientIllumDevicesGetControl"u8,
                id = 0x73c01d58,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_ClientIllumDevicesSetControl"u8,
                id = 0x57024c62,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_ClientIllumZonesGetInfo"u8,
                id = 0x4b81241b,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_ClientIllumZonesGetControl"u8,
                id = 0x3dbf5764,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_ClientIllumZonesSetControl"u8,
                id = 0x197d065e,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Event_RegisterCallback"u8,
                id = 0xe6dbea69,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Event_UnregisterCallback"u8,
                id = 0xde1f9b45,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_EnumNvidiaDisplayHandle"u8,
                id = 0x9abdd40d,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_EnumNvidiaUnAttachedDisplayHandle"u8,
                id = 0x20de9260,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_CreateDisplayFromUnAttachedDisplay"u8,
                id = 0x63f9799e,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GetAssociatedNvidiaDisplayHandle"u8,
                id = 0x35c29134,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DISP_GetAssociatedUnAttachedNvidiaDisplayHandle"u8,
                id = 0xa70503b2,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GetAssociatedNvidiaDisplayName"u8,
                id = 0x22a78b05,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GetUnAttachedAssociatedDisplayName"u8,
                id = 0x4888d790,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_EnableHWCursor"u8,
                id = 0x2863148d,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DisableHWCursor"u8,
                id = 0xab163097,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GetVBlankCounter"u8,
                id = 0x67b5db55,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_SetRefreshRateOverride"u8,
                id = 0x3092ac32,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GetAssociatedDisplayOutputId"u8,
                id = 0xd995937e,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GetDisplayPortInfo"u8,
                id = 0xc64ff367,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_SetDisplayPort"u8,
                id = 0xfa13e65a,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GetHDMISupportInfo"u8,
                id = 0x6ae16ec3,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Disp_InfoFrameControl"u8,
                id = 0x6067af3f,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Disp_ColorControl"u8,
                id = 0x92f9d80d,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Disp_GetHdrCapabilities"u8,
                id = 0x84f2a8df,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Disp_HdrColorControl"u8,
                id = 0x351da224,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Disp_SetSourceColorSpace"u8,
                id = 0x473b6caf,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Disp_GetSourceColorSpace"u8,
                id = 0xceedc85b,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Disp_SetSourceHdrMetadata"u8,
                id = 0x905eb63b,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Disp_GetSourceHdrMetadata"u8,
                id = 0x0d3f52da,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Disp_SetOutputMode"u8,
                id = 0x98e7661a,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Disp_GetOutputMode"u8,
                id = 0x81fed88d,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Disp_SetHdrToneMapping"u8,
                id = 0xdd6da362,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Disp_GetHdrToneMapping"u8,
                id = 0xfbd36e71,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Disp_GetColorimetry"u8,
                id = 0x00b421ad,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DISP_GetTiming"u8,
                id = 0x175167e9,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DISP_GetMonitorCapabilities"u8,
                id = 0x3b05c7e1,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DISP_GetMonitorColorCapabilities"u8,
                id = 0x6ae4cfb5,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DISP_EnumCustomDisplay"u8,
                id = 0xa2072d59,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DISP_TryCustomDisplay"u8,
                id = 0x1f7db630,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DISP_DeleteCustomDisplay"u8,
                id = 0x552e5b9b,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DISP_SaveCustomDisplay"u8,
                id = 0x49882876,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DISP_RevertCustomDisplayTrial"u8,
                id = 0xcbbd40f0,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GetView"u8,
                id = 0xd6b99d89,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GetViewEx"u8,
                id = 0xdbbc0af4,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GetSupportedViews"u8,
                id = 0x66fb7fc0,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DISP_GetDisplayIdByDisplayName"u8,
                id = 0xae457190,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DISP_GetGDIPrimaryDisplayId"u8,
                id = 0x1e9d8a31,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DISP_GetDisplayConfig"u8,
                id = 0x11abccf8,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DISP_SetDisplayConfig"u8,
                id = 0x5d8cf8de,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DISP_GetEdidData"u8,
                id = 0x436ced76,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DISP_GetAdaptiveSyncData"u8,
                id = 0xb73d1ee9,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DISP_SetAdaptiveSyncData"u8,
                id = 0x3eebba1d,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DISP_GetVirtualRefreshRateData"u8,
                id = 0x8c00429a,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DISP_SetVirtualRefreshRateData"u8,
                id = 0x5abbe6a3,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DISP_SetPreferredStereoDisplay"u8,
                id = 0xc9d0e25f,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DISP_GetPreferredStereoDisplay"u8,
                id = 0x1f6b4666,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DISP_GetNvManagedDedicatedDisplays"u8,
                id = 0xdbdf0cb2,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DISP_AcquireDedicatedDisplay"u8,
                id = 0x47c917ba,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DISP_ReleaseDedicatedDisplay"u8,
                id = 0x1247825f,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DISP_GetNvManagedDedicatedDisplayMetadata"u8,
                id = 0xd645d80c,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DISP_SetNvManagedDedicatedDisplayMetadata"u8,
                id = 0x3d8b129a,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Disp_GetDisplayIdInfo"u8,
                id = 0xbae8aa5e,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Disp_GetDisplayIdsFromTarget"u8,
                id = 0xe7e5f89e,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Disp_GetVRRInfo"u8,
                id = 0xdf8fda57,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Mosaic_GetSupportedTopoInfo"u8,
                id = 0xfdb63c81,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Mosaic_GetTopoGroup"u8,
                id = 0xcb89381d,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Mosaic_GetOverlapLimits"u8,
                id = 0x989685f0,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Mosaic_SetCurrentTopo"u8,
                id = 0x9b542831,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Mosaic_GetCurrentTopo"u8,
                id = 0xec32944e,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Mosaic_EnableCurrentTopo"u8,
                id = 0x5f1aa66c,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Mosaic_GetDisplayViewportsByResolution"u8,
                id = 0xdc6dc8d3,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Mosaic_SetDisplayGrids"u8,
                id = 0x4d959a89,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Mosaic_ValidateDisplayGrids"u8,
                id = 0xcf43903d,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Mosaic_EnumDisplayModes"u8,
                id = 0x78db97d7,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Mosaic_EnumDisplayGrids"u8,
                id = 0xdf2887af,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GetSupportedMosaicTopologies"u8,
                id = 0x410b5c25,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GetCurrentMosaicTopology"u8,
                id = 0xf60852bd,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_SetCurrentMosaicTopology"u8,
                id = 0xd54b8989,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_EnableCurrentMosaicTopology"u8,
                id = 0x74073cc9,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GSync_EnumSyncDevices"u8,
                id = 0xd9639601,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GSync_QueryCapabilities"u8,
                id = 0x44a3f1d1,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GSync_GetTopology"u8,
                id = 0x4562bc38,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GSync_SetSyncStateSettings"u8,
                id = 0x60acdfdd,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GSync_GetControlParameters"u8,
                id = 0x16de1c6a,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GSync_SetControlParameters"u8,
                id = 0x8bbff88b,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GSync_AdjustSyncDelay"u8,
                id = 0x2d11ff51,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GSync_GetSyncStatus"u8,
                id = 0xf1f5b434,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GSync_GetStatusParameters"u8,
                id = 0x70d404ec,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_GetCurrentSLIState"u8,
                id = 0x4b708b54,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D9_RegisterResource"u8,
                id = 0xa064bdfc,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D9_UnregisterResource"u8,
                id = 0xbb2b17aa,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D9_AliasSurfaceAsTexture"u8,
                id = 0xe5ceae41,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D9_StretchRectEx"u8,
                id = 0x22de03aa,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D9_ClearRT"u8,
                id = 0x332d3942,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_GetObjectHandleForResource"u8,
                id = 0xfceac864,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_SetResourceHint"u8,
                id = 0x6c0ed98c,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_BeginResourceRendering"u8,
                id = 0x91123d6a,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_EndResourceRendering"u8,
                id = 0x37e7191c,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D9_GetSurfaceHandle"u8,
                id = 0x0f2dd3f2,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D9_VideoSetStereoInfo"u8,
                id = 0xb852f4db,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D10_SetDepthBoundsTest"u8,
                id = 0x4eadf5d2,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_CreateDevice"u8,
                id = 0x6a16d3a0,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_CreateDeviceAndSwapChain"u8,
                id = 0xbb939ee5,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_SetDepthBoundsTest"u8,
                id = 0x7aaf7a04,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_IsNvShaderExtnOpCodeSupported"u8,
                id = 0x5f68da40,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_SetNvShaderExtnSlot"u8,
                id = 0x8e90bb9f,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_SetNvShaderExtnSlotSpace"u8,
                id = 0xac2dfeb5,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_SetNvShaderExtnSlotSpaceLocalThread"u8,
                id = 0x43d867c0,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_SetNvShaderExtnSlotLocalThread"u8,
                id = 0x0e6482a0,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_BeginUAVOverlapEx"u8,
                id = 0xba08208a,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_BeginUAVOverlap"u8,
                id = 0x65b93ca8,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_EndUAVOverlap"u8,
                id = 0x2216a357,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_GetResourceHandle"u8,
                id = 0x09d52986,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_SetFPSIndicatorState"u8,
                id = 0xa776e8db,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D9_Present"u8,
                id = 0x05650beb,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D9_QueryFrameCount"u8,
                id = 0x9083e53a,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D9_ResetFrameCount"u8,
                id = 0xfa6a0675,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D9_QueryMaxSwapGroup"u8,
                id = 0x5995410d,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D9_QuerySwapGroup"u8,
                id = 0xeba4d232,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D9_JoinSwapGroup"u8,
                id = 0x7d44bb54,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D9_BindSwapBarrier"u8,
                id = 0x9c39c246,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_SetVerticalSyncMode"u8,
                id = 0x5526cfd1,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D1x_Present"u8,
                id = 0x03b845a1,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D1x_QueryFrameCount"u8,
                id = 0x9152e055,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D1x_ResetFrameCount"u8,
                id = 0xfbbb031a,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D1x_QueryMaxSwapGroup"u8,
                id = 0x9bb9d68f,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D1x_QuerySwapGroup"u8,
                id = 0x407f67aa,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D1x_JoinSwapGroup"u8,
                id = 0x14610cd7,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D1x_BindSwapBarrier"u8,
                id = 0x9de8c729,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_QueryPresentBarrierSupport"u8,
                id = 0xa15faef7,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_CreatePresentBarrierClient"u8,
                id = 0x4d815de9,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_RegisterPresentBarrierResources"u8,
                id = 0xd53c9ef0,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DestroyPresentBarrierClient"u8,
                id = 0x3c5c351b,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_JoinPresentBarrier"u8,
                id = 0x17f6bf82,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_LeavePresentBarrier"u8,
                id = 0xc3ec5a7f,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_QueryPresentBarrierFrameStatistics"u8,
                id = 0x61b844a1,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_CreateDDisplayPresentBarrierClient"u8,
                id = 0xb5a21987,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_CreateRasterizerState"u8,
                id = 0xdb8d28af,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_ConfigureAnsel"u8,
                id = 0x341c6c7f,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_CreateTiledTexture2DArray"u8,
                id = 0x7886981a,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_CheckFeatureSupport"u8,
                id = 0x106a487e,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_CreateImplicitMSAATexture2D"u8,
                id = 0xb8f79632,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_CreateCommittedImplicitMSAATexture2D"u8,
                id = 0x24c6a07b,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_ResolveSubresourceRegion"u8,
                id = 0xe6bfedd6,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_ResolveSubresourceRegion"u8,
                id = 0xc24a15bf,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_TiledTexture2DArrayGetDesc"u8,
                id = 0xf1a2b9d5,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_UpdateTileMappings"u8,
                id = 0x9a06ea07,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_CopyTileMappings"u8,
                id = 0xc09ee6bc,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_TiledResourceBarrier"u8,
                id = 0xd6839099,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_AliasMSAATexture2DAsNonMSAA"u8,
                id = 0xf1c54fc9,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_CreateGeometryShaderEx_2"u8,
                id = 0x99ed5c1c,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_CreateVertexShaderEx"u8,
                id = 0x0beaa0b2,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_CreateHullShaderEx"u8,
                id = 0xb53cab00,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_CreateDomainShaderEx"u8,
                id = 0xa0d7180d,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_CreatePixelShaderEx_2"u8,
                id = 0x4162822b,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_CreateFastGeometryShaderExplicit"u8,
                id = 0x71ab7c9c,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_CreateFastGeometryShader"u8,
                id = 0x525d43be,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_DecompressView"u8,
                id = 0x3a94e822,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_CreateGraphicsPipelineState"u8,
                id = 0x2fc28856,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_CreateComputePipelineState"u8,
                id = 0x2762deac,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_SetDepthBoundsTestValues"u8,
                id = 0xb9333fe9,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_CreateReservedResource"u8,
                id = 0x2c85f101,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_CreateHeap"u8,
                id = 0x5cb397cf,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_CreateHeap2"u8,
                id = 0x924be9d6,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_QueryCpuVisibleVidmem"u8,
                id = 0x26322bc3,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_ReservedResourceGetDesc"u8,
                id = 0x9aa2aabb,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_UpdateTileMappings"u8,
                id = 0xc6017a7d,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_CopyTileMappings"u8,
                id = 0x47f78194,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_ResourceAliasingBarrier"u8,
                id = 0xb942bab7,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_CaptureUAVInfo"u8,
                id = 0x6e5ea9db,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_GetResourceGPUVirtualAddressEx"u8,
                id = 0xaf6d14da,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_EnumerateMetaCommands"u8,
                id = 0xc7453ba8,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_CreateMetaCommand"u8,
                id = 0xf505fba0,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_InitializeMetaCommand"u8,
                id = 0xaec629e9,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_ExecuteMetaCommand"u8,
                id = 0x82236c47,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_EnumerateMetaCommands"u8,
                id = 0xcd9141d8,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_CreateMetaCommand"u8,
                id = 0xeb29634b,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_InitializeMetaCommand"u8,
                id = 0xa4125399,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_ExecuteMetaCommand"u8,
                id = 0xde24fc3d,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_CreateCommittedResource"u8,
                id = 0x027e98ae,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_GetCopyableFootprints"u8,
                id = 0xf6305eb5,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_CopyTextureRegion"u8,
                id = 0x82b91b25,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_IsNvShaderExtnOpCodeSupported"u8,
                id = 0x3dfacec8,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_GetOptimalThreadCountForMesh"u8,
                id = 0xb43995cb,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_IsGSyncCapable"u8,
                id = 0x9c1eed78,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_IsGSyncActive"u8,
                id = 0xe942b0ff,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D1x_DisableShaderDiskCache"u8,
                id = 0xd0cbca7d,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_MultiGPU_GetCaps"u8,
                id = 0xd2d25687,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_MultiGPU_Init"u8,
                id = 0x017be49e,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_CreateMultiGPUDevice"u8,
                id = 0xbdb20007,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_QuerySinglePassStereoSupport"u8,
                id = 0x6f5f0a6d,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_SetSinglePassStereoMode"u8,
                id = 0xa39e6e6e,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_QuerySinglePassStereoSupport"u8,
                id = 0x3b03791b,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_SetSinglePassStereoMode"u8,
                id = 0x83556d87,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_QueryMultiViewSupport"u8,
                id = 0xb6e0a41c,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_SetMultiViewMode"u8,
                id = 0x8285c8da,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_QueryModifiedWSupport"u8,
                id = 0xcbf9f4f5,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_SetModifiedWMode"u8,
                id = 0x06ea4bf4,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_QueryModifiedWSupport"u8,
                id = 0x51235248,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_SetModifiedWMode"u8,
                id = 0xe1fdaba7,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_CreateLateLatchObject"u8,
                id = 0x2db27d09,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_QueryLateLatchSupport"u8,
                id = 0x8ceca0ec,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_RegisterDevice"u8,
                id = 0x8c02c4d0,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_MultiDrawInstancedIndirect"u8,
                id = 0xd4e26bbf,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_MultiDrawIndexedInstancedIndirect"u8,
                id = 0x59e890f9,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_ImplicitSLIControl"u8,
                id = 0x2aede111,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_GetNeedsAppFPBlendClamping"u8,
                id = 0x6ef4d2d1,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_UseDriverHeapPriorities"u8,
                id = 0xf0d978a8,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_Mosaic_GetCompanionAllocations"u8,
                id = 0xa46022c7,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_Mosaic_GetViewportAndGpuPartitions"u8,
                id = 0xb092b818,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D1x_GetGraphicsCapabilities"u8,
                id = 0x52b1499a,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_GetGraphicsCapabilities"u8,
                id = 0x01e87354,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_RSSetExclusiveScissorRects"u8,
                id = 0xae4d73ef,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_RSSetViewportsPixelShadingRates"u8,
                id = 0x34f7938f,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_CreateShadingRateResourceView"u8,
                id = 0x99ca2dff,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_RSSetShadingRateResourceView"u8,
                id = 0x1b0c2f83,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_RSGetPixelShadingRateSampleOrder"u8,
                id = 0x092442a1,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_RSSetPixelShadingRateSampleOrder"u8,
                id = 0xa942373a,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_InitializeVRSHelper"u8,
                id = 0x4780d70b,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_InitializeNvGazeHandler"u8,
                id = 0x5b3b7479,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_InitializeSMPAssist"u8,
                id = 0x42763d0c,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_QuerySMPAssistSupport"u8,
                id = 0xc57921de,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_GetSleepStatus"u8,
                id = 0xaef96ca1,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_SetSleepMode"u8,
                id = 0xac1ca9e0,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_Sleep"u8,
                id = 0x852cd1d2,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_SetReflexSync"u8,
                id = 0xb9f6faff,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_GetLatency"u8,
                id = 0x1a587f9c,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D_SetLatencyMarker"u8,
                id = 0xd9984c05,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_SetAsyncFrameMarker"u8,
                id = 0x13c98f73,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_SetAsyncFrameMarker"u8,
                id = 0x59c2c510,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_NotifyOutOfBandCommandQueue"u8,
                id = 0x03d6e8cb,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_SetCreateCommandQueueLowLatencyHint"u8,
                id = 0x548c224f,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_CreateCubinComputeShaderExV2"u8,
                id = 0x299f5fdc,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_CreateCubinComputeShader"u8,
                id = 0x2a2c79e8,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_CreateCubinComputeShaderEx"u8,
                id = 0x3151211b,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_CreateCubinComputeShaderWithName"u8,
                id = 0x1dc7261f,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_LaunchCubinShader"u8,
                id = 0x5c52bb86,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_DestroyCubinComputeShader"u8,
                id = 0x7fb785ba,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_GetCudaMergedTextureSamplerObject"u8,
                id = 0x329fe6e0,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_GetCudaIndependentDescriptorObject"u8,
                id = 0x0ddac234,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_GetCudaTextureObject"u8,
                id = 0x80403fc9,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_GetCudaSurfaceObject"u8,
                id = 0x48f5b2ee,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_IsFatbinPTXSupported"u8,
                id = 0x70c07832,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_CreateCuModule"u8,
                id = 0xad1a677d,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_EnumFunctionsInModule"u8,
                id = 0x7ab88d88,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_CreateCuFunction"u8,
                id = 0xe2436e22,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_LaunchCuKernelChain"u8,
                id = 0x24973538,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_LaunchCuKernelChainEx"u8,
                id = 0x846a9bf0,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_DestroyCuModule"u8,
                id = 0x41c65285,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_DestroyCuFunction"u8,
                id = 0xdf295ea6,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_CreateCubinComputeShaderExV2"u8,
                id = 0xf2c71d48,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_CreateCubinComputeShader"u8,
                id = 0x0ed98181,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_CreateCubinComputeShaderEx"u8,
                id = 0x32c2a0f6,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_CreateCubinComputeShaderWithName"u8,
                id = 0xb672be19,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_LaunchCubinShader"u8,
                id = 0x427e236d,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_DestroyCubinComputeShader"u8,
                id = 0x01682c86,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_IsFatbinPTXSupported"u8,
                id = 0x6086bd93,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_GetCudaIndependentViewObject"u8,
                id = 0x34d2afa8,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_GetCudaMergedTextureSamplerObject"u8,
                id = 0x5d637d8f,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_CreateUnorderedAccessView"u8,
                id = 0x74a497a1,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_CreateShaderResourceView"u8,
                id = 0x65cb431e,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_CreateSamplerState"u8,
                id = 0x89eca416,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_GetCudaTextureObject"u8,
                id = 0x9006fa68,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D11_GetResourceGPUVirtualAddress"u8,
                id = 0x1819b423,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_GetRaytracingCaps"u8,
                id = 0x85a6c2a0,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_EnableRaytracingValidation"u8,
                id = 0x1de5991b,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_RegisterRaytracingValidationMessageCallback"u8,
                id = 0x8554eb38,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_UnregisterRaytracingValidationMessageCallback"u8,
                id = 0x26975da6,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_FlushRaytracingValidationMessages"u8,
                id = 0xb8fb1fcb,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_GetRaytracingDisplacementMicromapArrayPrebuildInfo"u8,
                id = 0xfa99b6de,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_GetRaytracingOpacityMicromapArrayPrebuildInfo"u8,
                id = 0x4726d180,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_SetCreatePipelineStateOptions"u8,
                id = 0x5c607a27,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_CheckDriverMatchingIdentifierEx"u8,
                id = 0xafb237d4,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_GetRaytracingAccelerationStructurePrebuildInfoEx"u8,
                id = 0x8d025b77,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_BuildRaytracingOpacityMicromapArray"u8,
                id = 0x814f8d11,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_RelocateRaytracingOpacityMicromapArray"u8,
                id = 0x0425c538,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_BuildRaytracingDisplacementMicromapArray"u8,
                id = 0x066f569d,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_RelocateRaytracingDisplacementMicromapArray"u8,
                id = 0x1c142308,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_EmitRaytracingDisplacementMicromapArrayPostbuildInfo"u8,
                id = 0x68b9a790,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_EmitRaytracingOpacityMicromapArrayPostbuildInfo"u8,
                id = 0x1d9a39b6,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_BuildRaytracingAccelerationStructureEx"u8,
                id = 0xe24ead45,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_QueryWorkstationFeatureProperties"u8,
                id = 0xa92ea23a,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_CreateCommittedRDMABuffer"u8,
                id = 0xe78dcb44,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_ConvertCooperativeVectorMatrix"u8,
                id = 0x0f252cb3,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_ConvertCooperativeVectorMatrixMultiple"u8,
                id = 0x96ba5235,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_GetPhysicalDeviceCooperativeVectorProperties"u8,
                id = 0x8f182aec,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_GetRaytracingMultiIndirectClusterOperationRequirementsInfo"u8,
                id = 0x5c9163f4,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_RaytracingExecuteMultiIndirectClusterOperation"u8,
                id = 0x67c798af,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_GetRaytracingPartitionedTlasIndirectPrebuildInfo"u8,
                id = 0xcdfdc5f2,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D12_BuildRaytracingPartitionedTlasIndirect"u8,
                id = 0x7cfc6fc3,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_NGX_GetNGXOverrideState"u8,
                id = 0x3fd96fba,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_NGX_SetNGXOverrideState"u8,
                id = 0xb60fcb4e,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DirectD3D12GraphicsCommandList_Create"u8,
                id = 0x74a4e712,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DirectD3D12GraphicsCommandList_Release"u8,
                id = 0x99da3dde,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DirectD3D12GraphicsCommandList_Reset"u8,
                id = 0x999c26d8,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_VIO_GetCapabilities"u8,
                id = 0x1dc91303,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_VIO_Open"u8,
                id = 0x44ee4841,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_VIO_Close"u8,
                id = 0xd01bd237,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_VIO_Status"u8,
                id = 0x0e6ce4f1,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_VIO_SyncFormatDetect"u8,
                id = 0x118d48a3,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_VIO_GetConfig"u8,
                id = 0xd34a789b,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_VIO_SetConfig"u8,
                id = 0x0e4eec07,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_VIO_SetCSC"u8,
                id = 0xa1ec8d74,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_VIO_GetCSC"u8,
                id = 0x7b0d72a3,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_VIO_SetGamma"u8,
                id = 0x964bf452,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_VIO_GetGamma"u8,
                id = 0x51d53d06,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_VIO_SetSyncDelay"u8,
                id = 0x2697a8d1,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_VIO_GetSyncDelay"u8,
                id = 0x462214a9,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_VIO_GetPCIInfo"u8,
                id = 0xb981d935,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_VIO_IsRunning"u8,
                id = 0x96bd040e,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_VIO_Start"u8,
                id = 0xcde8e1a3,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_VIO_Stop"u8,
                id = 0x6ba2a5d6,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_VIO_IsFrameLockModeCompatible"u8,
                id = 0x7bf0a94d,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_VIO_EnumDevices"u8,
                id = 0xfd7c5557,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_VIO_QueryTopology"u8,
                id = 0x869534e2,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_VIO_EnumSignalFormats"u8,
                id = 0xead72fe4,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_VIO_EnumDataFormats"u8,
                id = 0x221fa8e8,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_CreateConfigurationProfileRegistryKey"u8,
                id = 0xbe7692ec,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_DeleteConfigurationProfileRegistryKey"u8,
                id = 0xf117b834,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_SetConfigurationProfileValue"u8,
                id = 0x24409f48,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_DeleteConfigurationProfileValue"u8,
                id = 0x49bceecf,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_Enable"u8,
                id = 0x239c4545,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_Disable"u8,
                id = 0x2ec50c2b,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_IsEnabled"u8,
                id = 0x348ff8e1,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_GetStereoSupport"u8,
                id = 0x296c434d,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_CreateHandleFromIUnknown"u8,
                id = 0xac7e37f4,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_DestroyHandle"u8,
                id = 0x3a153134,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_Activate"u8,
                id = 0xf6a1ad68,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_Deactivate"u8,
                id = 0x2d68de96,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_IsActivated"u8,
                id = 0x1fb0bc30,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_GetSeparation"u8,
                id = 0x451f2134,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_SetSeparation"u8,
                id = 0x5c069fa3,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_DecreaseSeparation"u8,
                id = 0xda044458,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_IncreaseSeparation"u8,
                id = 0xc9a8ecec,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_GetConvergence"u8,
                id = 0x4ab00934,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_SetConvergence"u8,
                id = 0x3dd6b54b,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_DecreaseConvergence"u8,
                id = 0x4c87e317,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_IncreaseConvergence"u8,
                id = 0xa17daabe,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_GetFrustumAdjustMode"u8,
                id = 0xe6839b43,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_SetFrustumAdjustMode"u8,
                id = 0x7be27fa2,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_CaptureJpegImage"u8,
                id = 0x932cb140,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_InitActivation"u8,
                id = 0xc7177702,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_Trigger_Activation"u8,
                id = 0x0d6c6cd2,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_CapturePngImage"u8,
                id = 0x8b7e99b5,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_ReverseStereoBlitControl"u8,
                id = 0x3cd58f89,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_SetNotificationMessage"u8,
                id = 0x6b9b409e,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_SetActiveEye"u8,
                id = 0x96eea9f8,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_SetDriverMode"u8,
                id = 0x5e8f0bec,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_GetEyeSeparation"u8,
                id = 0xce653127,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_IsWindowedModeSupported"u8,
                id = 0x40c8ed5e,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_SetSurfaceCreationMode"u8,
                id = 0xf5dcfcba,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_GetSurfaceCreationMode"u8,
                id = 0x36f1c736,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_Debug_WasLastDrawStereoized"u8,
                id = 0xed4416c5,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_SetDefaultProfile"u8,
                id = 0x44f0ecd1,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Stereo_GetDefaultProfile"u8,
                id = 0x624e21c2,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D1x_CreateSwapChain"u8,
                id = 0x1bc21b66,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_D3D9_CreateSwapChain"u8,
                id = 0x1a131e09,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Vulkan_InitLowLatencyDevice"u8,
                id = 0x5c1696b6,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Vulkan_DestroyLowLatencyDevice"u8,
                id = 0x11a5932b,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Vulkan_GetSleepStatus"u8,
                id = 0xadf966af,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Vulkan_SetSleepMode"u8,
                id = 0x2acfd162,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Vulkan_Sleep"u8,
                id = 0x36732b1e,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Vulkan_GetLatency"u8,
                id = 0x3233d44a,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Vulkan_SetLatencyMarker"u8,
                id = 0xa17d13d6,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_Vulkan_NotifyOutOfBandVkQueue"u8,
                id = 0x5d6d3840,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_CreateSession"u8,
                id = 0x0694d52e,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_DestroySession"u8,
                id = 0xdad9cff8,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_LoadSettings"u8,
                id = 0x375dbd6b,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_SaveSettings"u8,
                id = 0xfcbc7e14,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_LoadSettingsFromFile"u8,
                id = 0xd3ede889,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_SaveSettingsToFile"u8,
                id = 0x2be25df8,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_CreateProfile"u8,
                id = 0xcc176068,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_DeleteProfile"u8,
                id = 0x17093206,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_SetCurrentGlobalProfile"u8,
                id = 0x1c89c5df,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_GetCurrentGlobalProfile"u8,
                id = 0x617bff9f,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_GetProfileInfo"u8,
                id = 0x61cd6fd6,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_SetProfileInfo"u8,
                id = 0x16abd3a9,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_FindProfileByName"u8,
                id = 0x7e4a9a0b,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_EnumProfiles"u8,
                id = 0xbc371ee0,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_GetNumProfiles"u8,
                id = 0x1dae4fbc,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_CreateApplication"u8,
                id = 0x4347a9de,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_DeleteApplicationEx"u8,
                id = 0xc5ea85a1,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_DeleteApplication"u8,
                id = 0x2c694bc6,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_GetApplicationInfo"u8,
                id = 0xed1f8c69,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_EnumApplications"u8,
                id = 0x7fa2173a,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_FindApplicationByName"u8,
                id = 0xeee566b2,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_SetSetting"u8,
                id = 0x577dd202,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_GetSetting"u8,
                id = 0x73bf8338,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_EnumSettings"u8,
                id = 0xae3039da,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_EnumAvailableSettingIds"u8,
                id = 0xf020614a,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_EnumAvailableSettingValues"u8,
                id = 0x2ec39f90,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_GetSettingIdFromName"u8,
                id = 0xcb7309cd,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_GetSettingNameFromId"u8,
                id = 0xd61cbe6e,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_DeleteProfileSetting"u8,
                id = 0xe4a26362,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_RestoreAllDefaults"u8,
                id = 0x5927b094,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_RestoreProfileDefault"u8,
                id = 0xfa5f6134,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_RestoreProfileDefaultSetting"u8,
                id = 0x53f0381e,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_DRS_GetBaseProfile"u8,
                id = 0xda8466a0,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_SYS_GetChipSetInfo"u8,
                id = 0x53dabbca,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_SYS_GetLidAndDockInfo"u8,
                id = 0xcda14d8a,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_SYS_GetDisplayIdFromGpuAndOutputId"u8,
                id = 0x08f2bab4,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_SYS_GetGpuAndOutputIdFromDisplayId"u8,
                id = 0x112ba1a5,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_SYS_GetPhysicalGpuFromDisplayId"u8,
                id = 0x9ea74659,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_SYS_GetDisplayDriverInfo"u8,
                id = 0x721faceb,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_SYS_GetPhysicalGPUs"u8,
                id = 0xd3b24d2d,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_SYS_GetLogicalGPUs"u8,
                id = 0xccfffc10,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_GPU_ClientRegisterForUtilizationSampleUpdates"u8,
                id = 0xadeeaf67,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_RegisterRiseCallback"u8,
                id = 0x9cfe8f94,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_RequestRise"u8,
                id = 0x5047de98,
            },
            new NVAPI_INTERFACE_TABLE
            {
                func = "NvAPI_UninstallRise"u8,
                id = 0xab8d09f6,
            },
        };

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

        [NativeTypeName("#define NVAPI_SDK_VERSION 59145")]
        public const int NVAPI_SDK_VERSION = 59145;

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

        [NativeTypeName("#define NGX_DLSSG_MULTI_FRAME_COUNT_STRING L\"Override DLSSG multi-frame count\"")]
        public const string NGX_DLSSG_MULTI_FRAME_COUNT_STRING = "Override DLSSG multi-frame count";

        [NativeTypeName("#define NGX_DLSS_FG_OVERRIDE_STRING L\"Enable DLSS-FG override\"")]
        public const string NGX_DLSS_FG_OVERRIDE_STRING = "Enable DLSS-FG override";

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
