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
