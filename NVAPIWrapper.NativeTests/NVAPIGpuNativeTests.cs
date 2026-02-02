using System;
using System.Linq;
using System.Runtime.Versioning;
using Xunit;

namespace NVAPIWrapper.NativeTests
{
    /// <summary>
    /// Native GPU API tests.
    /// </summary>
    [SupportedOSPlatform("windows")]
    public class NVAPIGpuNativeTests : IDisposable
    {
        private readonly NVAPIApi? _api;
        private readonly string _skipReason = string.Empty;

        public NVAPIGpuNativeTests()
        {
            if (!NVAPIApi.IsNVAPIDllAvailable(out var dllError))
            {
                _skipReason = dllError;
                return;
            }

            try
            {
                _api = NVAPIApi.Initialize();
            }
            catch (NVAPIException ex)
            {
                _skipReason = $"NVAPI initialization failed: {ex.Message}";
            }
            catch (Exception ex)
            {
                _skipReason = $"NVAPI initialization failed: {ex.Message}";
            }
        }

        [SkippableFact]
        public unsafe void GpuGetShaderSubPipeCount_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_GPU_GetShaderSubPipeCount");

            WithPhysicalGpu(gpu =>
            {
                uint count = 0;
                var status = NVAPI.NvAPI_GPU_GetShaderSubPipeCount(gpu, &count);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU shader sub-pipe count unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetGpuCoreCount_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_GPU_GetGpuCoreCount");

            WithPhysicalGpu(gpu =>
            {
                uint count = 0;
                var status = NVAPI.NvAPI_GPU_GetGpuCoreCount(gpu, &count);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU core count unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetSystemType_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_GPU_GetSystemType");

            WithPhysicalGpu(gpu =>
            {
                NV_SYSTEM_TYPE systemType = default;
                var status = NVAPI.NvAPI_GPU_GetSystemType(gpu, &systemType);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU system type unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetActiveOutputs_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_GPU_GetActiveOutputs");

            WithPhysicalGpu(gpu =>
            {
                uint mask = 0;
                var status = NVAPI.NvAPI_GPU_GetActiveOutputs(gpu, &mask);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU active outputs unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetConnectedDisplayIds_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_GetConnectedDisplayIds");

            WithPhysicalGpu(gpu =>
            {
                var displayIds = new _NV_GPU_DISPLAYIDS[NVAPI.NVAPI_MAX_DISPLAYS];
                for (var i = 0; i < displayIds.Length; i++)
                    displayIds[i].version = NVAPI.NV_GPU_DISPLAYIDS_VER;

                uint count = (uint)displayIds.Length;
                fixed (_NV_GPU_DISPLAYIDS* pDisplayIds = displayIds)
                {
                    var status = NVAPI.NvAPI_GPU_GetConnectedDisplayIds(gpu, pDisplayIds, &count, 0);
                    if (IsUnsupported(status))
                    {
                        Skip.If(true, $"GPU connected display IDs unsupported: {status}");
                        return;
                    }

                    Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
                }
            });
        }

        [SkippableFact]
        public unsafe void GpuGetAllDisplayIds_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_GetAllDisplayIds");

            WithPhysicalGpu(gpu =>
            {
                var displayIds = new _NV_GPU_DISPLAYIDS[NVAPI.NVAPI_MAX_DISPLAYS];
                for (var i = 0; i < displayIds.Length; i++)
                    displayIds[i].version = NVAPI.NV_GPU_DISPLAYIDS_VER;

                uint count = (uint)displayIds.Length;
                fixed (_NV_GPU_DISPLAYIDS* pDisplayIds = displayIds)
                {
                    var status = NVAPI.NvAPI_GPU_GetAllDisplayIds(gpu, pDisplayIds, &count);
                    if (IsUnsupported(status))
                    {
                        Skip.If(true, $"GPU all display IDs unsupported: {status}");
                        return;
                    }

                    Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
                }
            });
        }

        [SkippableFact]
        public unsafe void GpuGetPerfDecreaseInfo_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_GPU_GetPerfDecreaseInfo");

            WithPhysicalGpu(gpu =>
            {
                uint info = 0;
                var status = NVAPI.NvAPI_GPU_GetPerfDecreaseInfo(gpu, &info);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU perf decrease info unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetCurrentPstate_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_GPU_GetCurrentPstate");

            WithPhysicalGpu(gpu =>
            {
                _NV_GPU_PERF_PSTATE_ID pstate = default;
                var status = NVAPI.NvAPI_GPU_GetCurrentPstate(gpu, &pstate);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU current pstate unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetPstates20_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_GetPstates20");

            WithPhysicalGpu(gpu =>
            {
                var info = new _NV_GPU_PERF_PSTATES20_INFO_V2 { version = NVAPI.NV_GPU_PERF_PSTATES20_INFO_VER };
                var status = NVAPI.NvAPI_GPU_GetPstates20(gpu, &info);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU Pstates20 unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetDynamicPstatesInfoEx_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_GetDynamicPstatesInfoEx");

            WithPhysicalGpu(gpu =>
            {
                var info = new NV_GPU_DYNAMIC_PSTATES_INFO_EX { version = NVAPI.NV_GPU_DYNAMIC_PSTATES_INFO_EX_VER };
                var status = NVAPI.NvAPI_GPU_GetDynamicPstatesInfoEx(gpu, &info);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU dynamic Pstates info unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetThermalSettings_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_GetThermalSettings");

            WithPhysicalGpu(gpu =>
            {
                var info = new NV_GPU_THERMAL_SETTINGS_V2 { version = NVAPI.NV_GPU_THERMAL_SETTINGS_VER };
                var status = NVAPI.NvAPI_GPU_GetThermalSettings(gpu, 0, &info);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU thermal settings unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetAllClockFrequencies_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_GetAllClockFrequencies");

            WithPhysicalGpu(gpu =>
            {
                var info = new NV_GPU_CLOCK_FREQUENCIES_V2
                {
                    version = NVAPI.NV_GPU_CLOCK_FREQUENCIES_VER,
                    ClockType = (uint)NV_GPU_CLOCK_FREQUENCIES_CLOCK_TYPE.NV_GPU_CLOCK_FREQUENCIES_CURRENT_FREQ
                };

                var status = NVAPI.NvAPI_GPU_GetAllClockFrequencies(gpu, &info);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU clock frequencies unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuQueryIlluminationSupport_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_QueryIlluminationSupport");

            WithPhysicalGpu(gpu =>
            {
                var request = new _NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_V1
                {
                    version = NVAPI.NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_VER,
                    hPhysicalGpu = gpu,
                    Attribute = _NV_GPU_ILLUMINATION_ATTRIB.NV_GPU_IA_LOGO_BRIGHTNESS
                };

                var status = NVAPI.NvAPI_GPU_QueryIlluminationSupport(&request);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU illumination support unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetIllumination_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_GetIllumination");

            WithPhysicalGpu(gpu =>
            {
                var request = new _NV_GPU_GET_ILLUMINATION_PARM_V1
                {
                    version = NVAPI.NV_GPU_GET_ILLUMINATION_PARM_VER,
                    hPhysicalGpu = gpu,
                    Attribute = _NV_GPU_ILLUMINATION_ATTRIB.NV_GPU_IA_LOGO_BRIGHTNESS
                };

                var status = NVAPI.NvAPI_GPU_GetIllumination(&request);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU illumination unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuClientIllumDevicesGetInfo_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_ClientIllumDevicesGetInfo");

            WithPhysicalGpu(gpu =>
            {
                var info = new _NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_V1 { version = NVAPI.NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_VER };
                var status = NVAPI.NvAPI_GPU_ClientIllumDevicesGetInfo(gpu, &info);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU illum device info unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuClientIllumDevicesGetControl_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_ClientIllumDevicesGetControl");
            SkipIfUnavailable("NvAPI_GPU_ClientIllumDevicesGetInfo");

            WithPhysicalGpu(gpu =>
            {
                var info = new _NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_V1 { version = NVAPI.NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_VER };
                var status = NVAPI.NvAPI_GPU_ClientIllumDevicesGetInfo(gpu, &info);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU illum device info unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);

                var control = new NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_V1
                {
                    version = NVAPI.NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_VER,
                    numIllumDevices = info.numIllumDevices
                };

                status = NVAPI.NvAPI_GPU_ClientIllumDevicesGetControl(gpu, &control);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU illum device control unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuClientIllumZonesGetInfo_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_ClientIllumZonesGetInfo");

            WithPhysicalGpu(gpu =>
            {
                var info = new _NV_GPU_CLIENT_ILLUM_ZONE_INFO_PARAMS_V1 { version = NVAPI.NV_GPU_CLIENT_ILLUM_ZONE_INFO_PARAMS_VER };
                var status = NVAPI.NvAPI_GPU_ClientIllumZonesGetInfo(gpu, &info);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU illum zone info unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuClientIllumZonesGetControl_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_ClientIllumZonesGetControl");
            SkipIfUnavailable("NvAPI_GPU_ClientIllumZonesGetInfo");

            WithPhysicalGpu(gpu =>
            {
                var info = new _NV_GPU_CLIENT_ILLUM_ZONE_INFO_PARAMS_V1 { version = NVAPI.NV_GPU_CLIENT_ILLUM_ZONE_INFO_PARAMS_VER };
                var status = NVAPI.NvAPI_GPU_ClientIllumZonesGetInfo(gpu, &info);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU illum zone info unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);

                var control = new _NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1
                {
                    version = NVAPI.NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_VER,
                    numIllumZonesControl = info.numIllumZones
                };

                status = NVAPI.NvAPI_GPU_ClientIllumZonesGetControl(gpu, &control);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU illum zone control unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetVirtualizationInfo_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_GetVirtualizationInfo");

            WithPhysicalGpu(gpu =>
            {
                var info = new _NV_GPU_VIRTUALIZATION_INFO { version = NVAPI.NV_GPU_VIRTUALIZATION_INFO_VER };
                var status = NVAPI.NvAPI_GPU_GetVirtualizationInfo(gpu, &info);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU virtualization info unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetLicensableFeatures_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_GetLicensableFeatures");

            WithPhysicalGpu(gpu =>
            {
                var info = new _NV_LICENSABLE_FEATURES_V4 { version = NVAPI.NV_LICENSABLE_FEATURES_VER };
                var status = NVAPI.NvAPI_GPU_GetLicensableFeatures(gpu, &info);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU licensable features unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetEncoderStatistics_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_GetEncoderStatistics");

            WithPhysicalGpu(gpu =>
            {
                var info = new _NV_ENCODER_STATISTICS_V1 { version = NVAPI.NNV_ENCODER_STATISTICS_VER };
                var status = NVAPI.NvAPI_GPU_GetEncoderStatistics(gpu, &info);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU encoder statistics unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetEncoderSessionsInfo_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_GetEncoderSessionsInfo");

            WithPhysicalGpu(gpu =>
            {
                var info = new _NV_ENCODER_SESSIONS_INFO_V1 { version = NVAPI.NV_ENCODER_SESSIONS_INFO_VER };
                var status = NVAPI.NvAPI_GPU_GetEncoderSessionsInfo(gpu, &info);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU encoder sessions info unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetVrReadyData_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_GetVRReadyData");

            WithPhysicalGpu(gpu =>
            {
                var info = new _NV_GPU_VR_READY_V1 { version = NVAPI.NV_GPU_VR_READY_VER };
                var status = NVAPI.NvAPI_GPU_GetVRReadyData(gpu, &info);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU VR ready data unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetGspFeatures_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_GetGspFeatures");

            WithPhysicalGpu(gpu =>
            {
                var info = new _NV_GPU_GSP_INFO_V1 { version = NVAPI.NV_GPU_GSP_INFO_VER };
                var status = NVAPI.NvAPI_GPU_GetGspFeatures(gpu, &info);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU GSP features unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuNvlinkGetCaps_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_NVLINK_GetCaps");

            WithPhysicalGpu(gpu =>
            {
                var caps = new NVLINK_GET_CAPS_V1 { version = NVAPI.NVLINK_GET_CAPS_VER };
                var status = NVAPI.NvAPI_GPU_NVLINK_GetCaps(gpu, &caps);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU NVLINK caps unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuNvlinkGetStatus_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_NVLINK_GetStatus");

            WithPhysicalGpu(gpu =>
            {
                var info = new NVLINK_GET_STATUS_V2 { version = NVAPI.NVLINK_GET_STATUS_VER };
                var status = NVAPI.NvAPI_GPU_NVLINK_GetStatus(gpu, &info);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU NVLINK status unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetGpuInfo_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_GetGPUInfo");

            WithPhysicalGpu(gpu =>
            {
                var info = new _NV_GPU_INFO_V2 { version = NVAPI.NV_GPU_INFO_VER };
                var status = NVAPI.NvAPI_GPU_GetGPUInfo(gpu, &info);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU info unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GetGpuIdFromPhysicalGpu_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_GetGPUIDfromPhysicalGPU");

            WithPhysicalGpu(gpu =>
            {
                uint gpuId = 0;
                var status = NVAPI.NvAPI_GetGPUIDfromPhysicalGPU(gpu, &gpuId);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU ID lookup unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GetPhysicalGpuFromGpuId_ShouldReturnHandle()
        {
            SkipIfUnavailable("NvAPI_GetGPUIDfromPhysicalGPU");
            SkipIfUnavailable("NvAPI_GetPhysicalGPUFromGPUID");

            WithPhysicalGpu(gpu =>
            {
                uint gpuId = 0;
                var status = NVAPI.NvAPI_GetGPUIDfromPhysicalGPU(gpu, &gpuId);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU ID lookup unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);

                NvPhysicalGpuHandle__* physical = null;
                status = NVAPI.NvAPI_GetPhysicalGPUFromGPUID(gpuId, &physical);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"Physical GPU lookup unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
                Assert.True(physical != null);
            });
        }

        [SkippableFact]
        public unsafe void GetLogicalGpuFromPhysicalGpu_ShouldReturnHandle()
        {
            SkipIfUnavailable("NvAPI_GetLogicalGPUFromPhysicalGPU");

            WithPhysicalGpu(gpu =>
            {
                NvLogicalGpuHandle__* logical = null;
                var status = NVAPI.NvAPI_GetLogicalGPUFromPhysicalGPU(gpu, &logical);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"Logical GPU lookup unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
                Assert.True(logical != null);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetArchInfo_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_GetArchInfo");

            WithPhysicalGpu(gpu =>
            {
                var info = new NV_GPU_ARCH_INFO_V2 { version = NVAPI.NV_GPU_ARCH_INFO_VER };
                var status = NVAPI.NvAPI_GPU_GetArchInfo(gpu, &info);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU arch info unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetBoardInfo_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_GetBoardInfo");

            WithPhysicalGpu(gpu =>
            {
                var info = new _NV_BOARD_INFO { version = NVAPI.NV_BOARD_INFO_VER };
                var status = NVAPI.NvAPI_GPU_GetBoardInfo(gpu, &info);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU board info unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetVbiosRevision_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_GPU_GetVbiosRevision");

            WithPhysicalGpu(gpu =>
            {
                uint revision = 0;
                var status = NVAPI.NvAPI_GPU_GetVbiosRevision(gpu, &revision);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU VBIOS revision unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetVbiosOemRevision_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_GPU_GetVbiosOEMRevision");

            WithPhysicalGpu(gpu =>
            {
                uint revision = 0;
                var status = NVAPI.NvAPI_GPU_GetVbiosOEMRevision(gpu, &revision);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU VBIOS OEM revision unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetCurrentPcieDownstreamWidth_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_GPU_GetCurrentPCIEDownstreamWidth");

            WithPhysicalGpu(gpu =>
            {
                uint width = 0;
                var status = NVAPI.NvAPI_GPU_GetCurrentPCIEDownstreamWidth(gpu, &width);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU PCIe downstream width unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetRamBusWidth_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_GPU_GetRamBusWidth");

            WithPhysicalGpu(gpu =>
            {
                uint width = 0;
                var status = NVAPI.NvAPI_GPU_GetRamBusWidth(gpu, &width);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU RAM bus width unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetIrq_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_GPU_GetIRQ");

            WithPhysicalGpu(gpu =>
            {
                uint irq = 0;
                var status = NVAPI.NvAPI_GPU_GetIRQ(gpu, &irq);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU IRQ unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetOutputType_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_GPU_GetOutputType");
            SkipIfUnavailable("NvAPI_GPU_GetAllDisplayIds");
            SkipIfUnavailable("NvAPI_SYS_GetGpuAndOutputIdFromDisplayId");

            WithPhysicalGpu(gpu =>
            {
                if (!TryGetOutputId(gpu, out var outputId))
                {
                    Skip.If(true, "No display output ID available.");
                    return;
                }

                _NV_GPU_OUTPUT_TYPE outputType = default;
                var status = NVAPI.NvAPI_GPU_GetOutputType(gpu, outputId, &outputType);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU output type unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuValidateOutputCombination_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_GPU_ValidateOutputCombination");
            SkipIfUnavailable("NvAPI_GPU_GetActiveOutputs");

            WithPhysicalGpu(gpu =>
            {
                uint outputsMask = 0;
                var status = NVAPI.NvAPI_GPU_GetActiveOutputs(gpu, &outputsMask);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU active outputs unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);

                var bitCount = 0;
                var temp = outputsMask;
                while (temp != 0)
                {
                    bitCount += (int)(temp & 1);
                    temp >>= 1;
                }

                if (bitCount < 2)
                {
                    Skip.If(true, "Not enough active outputs to validate combination.");
                    return;
                }

                status = NVAPI.NvAPI_GPU_ValidateOutputCombination(gpu, outputsMask);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU output combination unsupported: {status}");
                    return;
                }

                Assert.True(status == _NvAPI_Status.NVAPI_OK || status == _NvAPI_Status.NVAPI_INVALID_COMBINATION);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetEccConfigurationInfo_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_GetECCConfigurationInfo");

            WithPhysicalGpu(gpu =>
            {
                var info = new NV_GPU_ECC_CONFIGURATION_INFO { version = NVAPI.NV_GPU_ECC_CONFIGURATION_INFO_VER };
                var status = NVAPI.NvAPI_GPU_GetECCConfigurationInfo(gpu, &info);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU ECC configuration unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetEccErrorInfo_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_GetECCErrorInfo");

            WithPhysicalGpu(gpu =>
            {
                var info = new NV_GPU_ECC_ERROR_INFO { version = NVAPI.NV_GPU_ECC_ERROR_INFO_VER };
                var status = NVAPI.NvAPI_GPU_GetECCErrorInfo(gpu, &info);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU ECC error info unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuSetEccConfiguration_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_GPU_GetECCConfigurationInfo");
            SkipIfUnavailable("NvAPI_GPU_SetECCConfiguration");

            WithPhysicalGpu(gpu =>
            {
                var info = new NV_GPU_ECC_CONFIGURATION_INFO { version = NVAPI.NV_GPU_ECC_CONFIGURATION_INFO_VER };
                var status = NVAPI.NvAPI_GPU_GetECCConfigurationInfo(gpu, &info);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU ECC configuration unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);

                var enable = info.isEnabled != 0;
                status = NVAPI.NvAPI_GPU_SetECCConfiguration(gpu, enable ? (byte)1 : (byte)0, 1);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU ECC configuration set unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuResetEccErrorInfo_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_GPU_ResetECCErrorInfo");

            WithPhysicalGpu(gpu =>
            {
                var status = NVAPI.NvAPI_GPU_ResetECCErrorInfo(gpu, 0, 0);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU ECC reset unsupported: {status}");
                    return;
                }

                if (status == _NvAPI_Status.NVAPI_INVALID_ARGUMENT)
                {
                    Skip.If(true, $"GPU ECC reset invalid argument: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetHdcpSupportStatus_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_GetHDCPSupportStatus");

            WithPhysicalGpu(gpu =>
            {
                var info = new NV_GPU_GET_HDCP_SUPPORT_STATUS { version = NVAPI.NV_GPU_GET_HDCP_SUPPORT_STATUS_VER };
                var status = NVAPI.NvAPI_GPU_GetHDCPSupportStatus(gpu, &info);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU HDCP support unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetEdid_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_GetEDID");
            SkipIfUnavailable("NvAPI_GPU_GetAllDisplayIds");
            SkipIfUnavailable("NvAPI_SYS_GetGpuAndOutputIdFromDisplayId");

            WithPhysicalGpu(gpu =>
            {
                if (!TryGetOutputId(gpu, out var outputId))
                {
                    Skip.If(true, "No display output ID available.");
                    return;
                }

                var edid = new NV_EDID_V3 { version = NVAPI.NV_EDID_VER };
                var status = NVAPI.NvAPI_GPU_GetEDID(gpu, outputId, &edid);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU EDID unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuSetEdid_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_GPU_GetEDID");
            SkipIfUnavailable("NvAPI_GPU_SetEDID");
            SkipIfUnavailable("NvAPI_GPU_GetAllDisplayIds");
            SkipIfUnavailable("NvAPI_SYS_GetGpuAndOutputIdFromDisplayId");

            WithPhysicalGpu(gpu =>
            {
                if (!TryGetOutputId(gpu, out var outputId))
                {
                    Skip.If(true, "No display output ID available.");
                    return;
                }

                var edid = new NV_EDID_V3 { version = NVAPI.NV_EDID_VER };
                var status = NVAPI.NvAPI_GPU_GetEDID(gpu, outputId, &edid);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU EDID unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);

                status = NVAPI.NvAPI_GPU_SetEDID(gpu, outputId, &edid);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU set EDID unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetLogicalGpuInfo_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GetLogicalGPUFromPhysicalGPU");
            SkipIfUnavailable("NvAPI_GPU_GetLogicalGpuInfo");

            WithPhysicalGpu(gpu =>
            {
                NvLogicalGpuHandle__* logical = null;
                var status = NVAPI.NvAPI_GetLogicalGPUFromPhysicalGPU(gpu, &logical);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"Logical GPU lookup unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);

                var info = new _NV_LOGICAL_GPU_DATA_V1 { version = NVAPI.NV_LOGICAL_GPU_DATA_VER };
                status = NVAPI.NvAPI_GPU_GetLogicalGpuInfo(logical, &info);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"Logical GPU info unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuClientRegisterForUtilizationSampleUpdates_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_GPU_ClientRegisterForUtilizationSampleUpdates");

            WithPhysicalGpu(gpu =>
            {
                var settings = new _NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS_V1
                {
                    version = NVAPI.NV_GPU_CLIENT_UTILIZATION_PERIODIC_CALLBACK_SETTINGS_VER,
                    callback = null
                };

                var status = NVAPI.NvAPI_GPU_ClientRegisterForUtilizationSampleUpdates(gpu, &settings);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU utilization updates unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetScanoutCompositionParameter_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_GetScanoutCompositionParameter");
            SkipIfUnavailable("NvAPI_GPU_GetAllDisplayIds");

            WithPhysicalGpu(gpu =>
            {
                if (!TryGetDisplayId(gpu, out var displayId))
                {
                    Skip.If(true, "No display ID available.");
                    return;
                }

                NV_GPU_SCANOUT_COMPOSITION_PARAMETER_VALUE value = default;
                float container = 0;
                var status = NVAPI.NvAPI_GPU_GetScanoutCompositionParameter(
                    displayId,
                    NV_GPU_SCANOUT_COMPOSITION_PARAMETER.NV_GPU_SCANOUT_COMPOSITION_PARAMETER_WARPING_RESAMPLING_METHOD,
                    &value,
                    &container);

                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU scanout composition parameter unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuSetScanoutCompositionParameter_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_GPU_GetScanoutCompositionParameter");
            SkipIfUnavailable("NvAPI_GPU_SetScanoutCompositionParameter");
            SkipIfUnavailable("NvAPI_GPU_GetAllDisplayIds");

            WithPhysicalGpu(gpu =>
            {
                if (!TryGetDisplayId(gpu, out var displayId))
                {
                    Skip.If(true, "No display ID available.");
                    return;
                }

                var parameter = NV_GPU_SCANOUT_COMPOSITION_PARAMETER.NV_GPU_SCANOUT_COMPOSITION_PARAMETER_WARPING_RESAMPLING_METHOD;
                NV_GPU_SCANOUT_COMPOSITION_PARAMETER_VALUE value = default;
                float container = 0;
                var status = NVAPI.NvAPI_GPU_GetScanoutCompositionParameter(displayId, parameter, &value, &container);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU scanout composition parameter unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);

                status = NVAPI.NvAPI_GPU_SetScanoutCompositionParameter(displayId, parameter, value, &container);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU scanout composition parameter set unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetScanoutConfiguration_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_GetScanoutConfiguration");
            SkipIfUnavailable("NvAPI_GPU_GetAllDisplayIds");

            WithPhysicalGpu(gpu =>
            {
                if (!TryGetDisplayId(gpu, out var displayId))
                {
                    Skip.If(true, "No display ID available.");
                    return;
                }

                NvSBox desktopRect = default;
                NvSBox scanoutRect = default;
                var status = NVAPI.NvAPI_GPU_GetScanoutConfiguration(displayId, &desktopRect, &scanoutRect);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU scanout configuration unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetScanoutConfigurationEx_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_GetScanoutConfigurationEx");
            SkipIfUnavailable("NvAPI_GPU_GetAllDisplayIds");

            WithPhysicalGpu(gpu =>
            {
                if (!TryGetDisplayId(gpu, out var displayId))
                {
                    Skip.If(true, "No display ID available.");
                    return;
                }

                var info = new _NV_SCANOUT_INFORMATION { version = NVAPI.NV_SCANOUT_INFORMATION_VER };
                var status = NVAPI.NvAPI_GPU_GetScanoutConfigurationEx(displayId, &info);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU scanout configuration ex unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetScanoutIntensityState_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_GetScanoutIntensityState");
            SkipIfUnavailable("NvAPI_GPU_GetAllDisplayIds");

            WithPhysicalGpu(gpu =>
            {
                if (!TryGetDisplayId(gpu, out var displayId))
                {
                    Skip.If(true, "No display ID available.");
                    return;
                }

                var state = new _NV_SCANOUT_INTENSITY_STATE_DATA { version = NVAPI.NV_SCANOUT_INTENSITY_STATE_VER };
                var status = NVAPI.NvAPI_GPU_GetScanoutIntensityState(displayId, &state);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU scanout intensity state unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuGetScanoutWarpingState_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_GetScanoutWarpingState");
            SkipIfUnavailable("NvAPI_GPU_GetAllDisplayIds");

            WithPhysicalGpu(gpu =>
            {
                if (!TryGetDisplayId(gpu, out var displayId))
                {
                    Skip.If(true, "No display ID available.");
                    return;
                }

                var state = new _NV_SCANOUT_WARPING_STATE_DATA { version = NVAPI.NV_SCANOUT_WARPING_STATE_VER };
                var status = NVAPI.NvAPI_GPU_GetScanoutWarpingState(displayId, &state);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU scanout warping state unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuSetScanoutIntensity_ShouldSkip_WhenNoSafeCurrentData()
        {
            SkipIfUnavailable("NvAPI_GPU_SetScanoutIntensity");
            SkipIfUnavailable("NvAPI_GPU_GetScanoutIntensityState");
            SkipIfUnavailable("NvAPI_GPU_GetAllDisplayIds");

            WithPhysicalGpu(gpu =>
            {
                if (!TryGetDisplayId(gpu, out var displayId))
                {
                    Skip.If(true, "No display ID available.");
                    return;
                }

                var state = new _NV_SCANOUT_INTENSITY_STATE_DATA { version = NVAPI.NV_SCANOUT_INTENSITY_STATE_VER };
                var status = NVAPI.NvAPI_GPU_GetScanoutIntensityState(displayId, &state);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU scanout intensity state unsupported: {status}");
                    return;
                }

                Skip.If(true, "No safe set-to-current intensity data available.");
            });
        }

        [SkippableFact]
        public unsafe void GpuSetScanoutWarping_ShouldSkip_WhenNoSafeCurrentData()
        {
            SkipIfUnavailable("NvAPI_GPU_SetScanoutWarping");
            SkipIfUnavailable("NvAPI_GPU_GetScanoutWarpingState");
            SkipIfUnavailable("NvAPI_GPU_GetAllDisplayIds");

            WithPhysicalGpu(gpu =>
            {
                if (!TryGetDisplayId(gpu, out var displayId))
                {
                    Skip.If(true, "No display ID available.");
                    return;
                }

                var state = new _NV_SCANOUT_WARPING_STATE_DATA { version = NVAPI.NV_SCANOUT_WARPING_STATE_VER };
                var status = NVAPI.NvAPI_GPU_GetScanoutWarpingState(displayId, &state);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"GPU scanout warping state unsupported: {status}");
                    return;
                }

                Skip.If(true, "No safe set-to-current warping data available.");
            });
        }

        [SkippableFact]
        public unsafe void GpuQueryWorkstationFeatureSupport_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_GPU_QueryWorkstationFeatureSupport");

            WithPhysicalGpu(gpu =>
            {
                var status = NVAPI.NvAPI_GPU_QueryWorkstationFeatureSupport(
                    gpu,
                    _NV_GPU_WORKSTATION_FEATURE_TYPE.NV_GPU_WORKSTATION_FEATURE_TYPE_PROVIZ);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"Workstation feature support unsupported: {status}");
                    return;
                }

                if (status == _NvAPI_Status.NVAPI_SETTING_NOT_FOUND)
                {
                    Skip.If(true, $"Workstation feature support not found: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuWorkstationFeatureQuery_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_GPU_WorkstationFeatureQuery");

            WithPhysicalGpu(gpu =>
            {
                uint configured = 0;
                uint consistent = 0;
                var status = NVAPI.NvAPI_GPU_WorkstationFeatureQuery(gpu, &configured, &consistent);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"Workstation feature query unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void GpuWorkstationFeatureSetup_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_GPU_WorkstationFeatureQuery");
            SkipIfUnavailable("NvAPI_GPU_WorkstationFeatureSetup");

            WithPhysicalGpu(gpu =>
            {
                uint configured = 0;
                uint consistent = 0;
                var status = NVAPI.NvAPI_GPU_WorkstationFeatureQuery(gpu, &configured, &consistent);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"Workstation feature query unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);

                status = NVAPI.NvAPI_GPU_WorkstationFeatureSetup(gpu, configured, 0);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"Workstation feature setup unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        public void Dispose()
        {
            _api?.Dispose();
        }

        private void SkipIfUnavailable(string functionName)
        {
            Skip.If(_api == null, _skipReason);

            var functions = _api.GetAvailableFunctions();
            var available = functions.Any(entry => entry.Name == functionName && entry.IsAvailable);
            Skip.If(!available, $"NVAPI function '{functionName}' not available.");
        }

        private unsafe bool TryGetDisplayId(NvPhysicalGpuHandle__* gpu, out uint displayId)
        {
            displayId = 0;

            var displayIds = new _NV_GPU_DISPLAYIDS[NVAPI.NVAPI_MAX_DISPLAYS];
            for (var i = 0; i < displayIds.Length; i++)
                displayIds[i].version = NVAPI.NV_GPU_DISPLAYIDS_VER;

            uint count = (uint)displayIds.Length;
            fixed (_NV_GPU_DISPLAYIDS* pDisplayIds = displayIds)
            {
                var status = NVAPI.NvAPI_GPU_GetAllDisplayIds(gpu, pDisplayIds, &count);
                if (IsUnsupported(status))
                    return false;

                if (status != _NvAPI_Status.NVAPI_OK)
                    throw new NVAPIException(status);
            }

            if (count == 0)
                return false;

            displayId = displayIds[0].displayId;
            return displayId != 0;
        }

        private unsafe bool TryGetOutputId(NvPhysicalGpuHandle__* gpu, out uint outputId)
        {
            outputId = 0;

            if (!TryGetDisplayId(gpu, out var displayId))
                return false;

            NvPhysicalGpuHandle__* physical = null;
            uint outputIdLocal = 0;
            var status = NVAPI.NvAPI_SYS_GetGpuAndOutputIdFromDisplayId(displayId, &physical, &outputIdLocal);
            if (IsUnsupported(status))
                return false;

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            outputId = outputIdLocal;
            return outputId != 0;
        }

        private unsafe void WithPhysicalGpu(PhysicalGpuAction action)
        {
            SkipIfUnavailable("NvAPI_EnumPhysicalGPUs");

            var handles = stackalloc NvPhysicalGpuHandle__*[NVAPI.NVAPI_MAX_PHYSICAL_GPUS];
            uint count = 0;
            var status = NVAPI.NvAPI_EnumPhysicalGPUs(handles, &count);
            if (IsUnsupported(status))
            {
                Skip.If(true, $"Physical GPUs not available: {status}");
                return;
            }

            Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            Skip.If(count == 0, "No NVIDIA physical GPUs found.");

            action(handles[0]);
        }

        private unsafe delegate void PhysicalGpuAction(NvPhysicalGpuHandle__* gpu);

        private static bool IsUnsupported(_NvAPI_Status status)
        {
            return status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND;
        }
    }
}
