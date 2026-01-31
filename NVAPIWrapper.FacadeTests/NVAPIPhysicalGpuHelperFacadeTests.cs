using System;
using System.Runtime.Versioning;
using Xunit;

namespace NVAPIWrapper.FacadeTests
{
    /// <summary>
    /// Facade tests for physical GPU helpers.
    /// </summary>
    [SupportedOSPlatform("windows")]
    [Collection("Passive")]
    [Trait("Category", "Passive")]
    public class NVAPIPhysicalGpuHelperFacadeTests
    {
        private readonly NVAPITestFixture _fixture;

        public NVAPIPhysicalGpuHelperFacadeTests(NVAPITestFixture fixture)
        {
            _fixture = fixture;
        }

        [SkippableFact]
        public void EnumeratePhysicalGpus_ShouldReturnArray()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Assert.NotNull(gpus);
            Assert.InRange(gpus.Length, 0, NVAPI.NVAPI_MAX_PHYSICAL_GPUS);
        }

        [SkippableFact]
        public void GetFullName_ShouldReturnValue()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var name = gpus[0].GetFullName();
            Assert.False(string.IsNullOrWhiteSpace(name));
        }

        [SkippableFact]
        public void GetBusId_ShouldReturnValue()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var busId = gpus[0].GetBusId();
            Assert.True(busId.HasValue);
        }

        [SkippableFact]
        public void GetBusType_ShouldReturnValue()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var busType = gpus[0].GetBusType();
            Assert.True(busType.HasValue);
        }

        [SkippableFact]
        public void GetGpuType_ShouldReturnValue()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var gpuType = gpus[0].GetGpuType();
            Assert.True(gpuType.HasValue);
        }

        [SkippableFact]
        public void GetPCIIdentifiers_ShouldReturnValue()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var pci = gpus[0].GetPCIIdentifiers();
            Skip.If(pci == null, "PCI identifiers not supported.");
            Assert.True(pci.HasValue);
        }

        [SkippableFact]
        public void GetBusSlotId_ShouldReturnValue()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var busSlotId = gpus[0].GetBusSlotId();
            Skip.If(busSlotId == null, "Bus slot ID not supported.");
            Assert.True(busSlotId.HasValue);
        }

        [SkippableFact]
        public void GetVbiosVersionString_ShouldReturnValue()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var vbios = gpus[0].GetVbiosVersionString();
            Skip.If(string.IsNullOrWhiteSpace(vbios), "VBIOS version not supported.");
            Assert.False(string.IsNullOrWhiteSpace(vbios));
        }

        [SkippableFact]
        public void GetPhysicalFrameBufferSize_ShouldReturnValue()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var size = gpus[0].GetPhysicalFrameBufferSize();
            Skip.If(size == null, "Physical frame buffer size not supported.");
            Assert.True(size.HasValue);
        }

        [SkippableFact]
        public void GetVirtualFrameBufferSize_ShouldReturnValue()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var size = gpus[0].GetVirtualFrameBufferSize();
            Skip.If(size == null, "Virtual frame buffer size not supported.");
            Assert.True(size.HasValue);
        }

        [SkippableFact]
        public void GetTachReading_ShouldReturnValue()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var tach = gpus[0].GetTachReading();
            Skip.If(tach == null, "Tach reading not supported.");
            Assert.True(tach.HasValue);
        }

        [SkippableFact]
        public void GetMemoryInfo_ShouldReturnDto()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var info = FacadeTestUtils.InvokeOrSkip(() => gpus[0].GetMemoryInfo(), "Memory info unsupported");
            Skip.If(info == null, "Memory info not supported.");

            var dto = info.Value;
            var native = dto.ToNative();
            Assert.Equal(NVAPI.NV_DISPLAY_DRIVER_MEMORY_INFO_VER, native.version);
            Assert.True(dto.Equals(dto));
            _ = dto.GetHashCode();
        }

        [SkippableFact]
        public void GetMemoryInfoEx_ShouldReturnDto()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var info = FacadeTestUtils.InvokeOrSkip(() => gpus[0].GetMemoryInfoEx(), "Extended memory info unsupported");
            Skip.If(info == null, "Extended memory info not supported.");

            var dto = info.Value;
            var native = dto.ToNative();
            Assert.Equal(NVAPI.NV_GPU_MEMORY_INFO_EX_VER, native.version);
            Assert.True(dto.Equals(dto));
            _ = dto.GetHashCode();
        }

        [SkippableFact]
        public void GetDisplayIdFromGpuAndOutputId_ShouldReturnValue()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var displays = gpus[0].EnumerateNvidiaDisplayHandles();
            Skip.If(displays.Length == 0, "No NVIDIA displays found.");

            var outputId = displays[0].GetAssociatedDisplayOutputId();
            Skip.If(outputId == null, "Display output ID not supported.");

            var displayId = FacadeTestUtils.InvokeOrSkip(
                () => gpus[0].GetDisplayIdFromGpuAndOutputId(outputId.Value),
                "Display ID lookup unsupported");

            Skip.If(displayId == null, "Display ID not supported.");
            Assert.True(displayId.HasValue);
        }

        [SkippableFact]
        public void GetShaderSubPipeCount_ShouldReturnValue()
        {
            var gpu = GetFirstGpuOrSkip();
            var count = FacadeTestUtils.InvokeOrSkip(() => gpu.GetShaderSubPipeCount(), "Shader sub-pipe count unsupported");
            Skip.If(count == null, "Shader sub-pipe count not supported.");
            Assert.True(count.HasValue);
        }

        [SkippableFact]
        public void GetGpuCoreCount_ShouldReturnValue()
        {
            var gpu = GetFirstGpuOrSkip();
            var count = FacadeTestUtils.InvokeOrSkip(() => gpu.GetGpuCoreCount(), "GPU core count unsupported");
            Skip.If(count == null, "GPU core count not supported.");
            Assert.True(count.HasValue);
        }

        [SkippableFact]
        public void GetSystemType_ShouldReturnValue()
        {
            var gpu = GetFirstGpuOrSkip();
            var systemType = FacadeTestUtils.InvokeOrSkip(() => gpu.GetSystemType(), "System type unsupported");
            Skip.If(systemType == null, "System type not supported.");
            Assert.True(systemType.HasValue);
        }

        [SkippableFact]
        public void GetActiveOutputs_ShouldReturnValue()
        {
            var gpu = GetFirstGpuOrSkip();
            var outputs = FacadeTestUtils.InvokeOrSkip(() => gpu.GetActiveOutputs(), "Active outputs unsupported");
            Skip.If(outputs == null, "Active outputs not supported.");
            Assert.True(outputs.HasValue);
        }

        [SkippableFact]
        public void GetConnectedDisplayIds_ShouldReturnDtos()
        {
            var gpu = GetFirstGpuOrSkip();
            var ids = FacadeTestUtils.InvokeOrSkip(() => gpu.GetConnectedDisplayIds(), "Connected display IDs unsupported");
            Skip.If(ids.Length == 0, "Connected display IDs not supported or empty.");
            Assert.InRange(ids.Length, 1, NVAPI.NVAPI_MAX_DISPLAYS);

            var native = ids[0].ToNative();
            Assert.Equal(NVAPI.NV_GPU_DISPLAYIDS_VER, native.version);
            Assert.True(ids[0].Equals(ids[0]));
        }

        [SkippableFact]
        public void GetAllDisplayIds_ShouldReturnDtos()
        {
            var gpu = GetFirstGpuOrSkip();
            var ids = FacadeTestUtils.InvokeOrSkip(() => gpu.GetAllDisplayIds(), "All display IDs unsupported");
            Skip.If(ids.Length == 0, "All display IDs not supported or empty.");
            Assert.InRange(ids.Length, 1, NVAPI.NVAPI_MAX_DISPLAYS);

            var native = ids[0].ToNative();
            Assert.Equal(NVAPI.NV_GPU_DISPLAYIDS_VER, native.version);
            Assert.True(ids[0].Equals(ids[0]));
        }

        [SkippableFact]
        public void GetPerfDecreaseInfo_ShouldReturnValue()
        {
            var gpu = GetFirstGpuOrSkip();
            var info = FacadeTestUtils.InvokeOrSkip(() => gpu.GetPerfDecreaseInfo(), "Perf decrease info unsupported");
            Skip.If(info == null, "Perf decrease info not supported.");
            Assert.True(info.HasValue);
        }

        [SkippableFact]
        public void GetCurrentPstate_ShouldReturnValue()
        {
            var gpu = GetFirstGpuOrSkip();
            var pstate = FacadeTestUtils.InvokeOrSkip(() => gpu.GetCurrentPstate(), "Current Pstate unsupported");
            Skip.If(pstate == null, "Current Pstate not supported.");
            Assert.True(pstate.HasValue);
        }

        [SkippableFact]
        public void GetPstates20Info_ShouldReturnDto()
        {
            var gpu = GetFirstGpuOrSkip();
            var info = FacadeTestUtils.InvokeOrSkip(() => gpu.GetPstates20Info(), "Pstates20 unsupported");
            Skip.If(info == null, "Pstates20 not supported.");

            var dto = info.Value;
            var native = dto.ToNative();
            Assert.Equal(NVAPI.NV_GPU_PERF_PSTATES20_INFO_VER, native.version);
            Assert.True(dto.Equals(dto));
            _ = dto.GetHashCode();
        }

        [SkippableFact]
        public void GetDynamicPstatesInfoEx_ShouldReturnDto()
        {
            var gpu = GetFirstGpuOrSkip();
            var info = FacadeTestUtils.InvokeOrSkip(() => gpu.GetDynamicPstatesInfoEx(), "Dynamic Pstates info unsupported");
            Skip.If(info == null, "Dynamic Pstates info not supported.");

            var dto = info.Value;
            var native = dto.ToNative();
            Assert.Equal(NVAPI.NV_GPU_DYNAMIC_PSTATES_INFO_EX_VER, native.version);
            Assert.True(dto.Equals(dto));
            _ = dto.GetHashCode();
        }

        [SkippableFact]
        public void GetThermalSettings_ShouldReturnDto()
        {
            var gpu = GetFirstGpuOrSkip();
            var info = FacadeTestUtils.InvokeOrSkip(() => gpu.GetThermalSettings(), "Thermal settings unsupported");
            Skip.If(info == null, "Thermal settings not supported.");

            var dto = info.Value;
            var native = dto.ToNative();
            Assert.Equal(NVAPI.NV_GPU_THERMAL_SETTINGS_VER, native.version);
            Assert.True(dto.Equals(dto));
            _ = dto.GetHashCode();
        }

        [SkippableFact]
        public void GetAllClockFrequencies_ShouldReturnDto()
        {
            var gpu = GetFirstGpuOrSkip();
            var info = FacadeTestUtils.InvokeOrSkip(() => gpu.GetAllClockFrequencies(), "Clock frequencies unsupported");
            Skip.If(info == null, "Clock frequencies not supported.");

            var dto = info.Value;
            var native = dto.ToNative();
            Assert.Equal(NVAPI.NV_GPU_CLOCK_FREQUENCIES_VER, native.version);
            Assert.True(dto.Equals(dto));
            _ = dto.GetHashCode();
        }

        [SkippableFact]
        public void QueryIlluminationSupport_ShouldReturnDto()
        {
            var gpu = GetFirstGpuOrSkip();
            var info = FacadeTestUtils.InvokeOrSkip(
                () => gpu.QueryIlluminationSupport(_NV_GPU_ILLUMINATION_ATTRIB.NV_GPU_IA_LOGO_BRIGHTNESS),
                "Illumination support unsupported");
            Skip.If(info == null, "Illumination support not supported.");

            var dto = info.Value;
            var native = dto.ToNative();
            Assert.Equal(NVAPI.NV_GPU_QUERY_ILLUMINATION_SUPPORT_PARM_VER, native.version);
            Assert.True(dto.Equals(dto));
        }

        [SkippableFact]
        public void GetIllumination_ShouldReturnDto()
        {
            var gpu = GetFirstGpuOrSkip();
            var info = FacadeTestUtils.InvokeOrSkip(
                () => gpu.GetIllumination(_NV_GPU_ILLUMINATION_ATTRIB.NV_GPU_IA_LOGO_BRIGHTNESS),
                "Illumination unsupported");
            Skip.If(info == null, "Illumination not supported.");

            var dto = info.Value;
            var native = dto.ToNative();
            Assert.Equal(NVAPI.NV_GPU_SET_ILLUMINATION_PARM_VER, native.version);
            Assert.True(dto.Equals(dto));
        }

        [SkippableFact]
        public void GetIlluminationDevicesInfo_ShouldReturnDto()
        {
            var gpu = GetFirstGpuOrSkip();
            var info = FacadeTestUtils.InvokeOrSkip(() => gpu.GetIlluminationDevicesInfo(), "Illumination device info unsupported");
            Skip.If(info == null, "Illumination device info not supported.");

            var dto = info.Value;
            var native = dto.ToNative();
            Assert.Equal(NVAPI.NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_VER, native.version);
            Assert.True(dto.Equals(dto));
            _ = dto.GetHashCode();
        }

        [SkippableFact]
        public void GetIlluminationDevicesControl_ShouldReturnDto()
        {
            var gpu = GetFirstGpuOrSkip();
            var info = FacadeTestUtils.InvokeOrSkip(() => gpu.GetIlluminationDevicesControl(), "Illumination device control unsupported");
            Skip.If(info == null, "Illumination device control not supported.");

            var dto = info.Value;
            var native = dto.ToNative();
            Assert.Equal(NVAPI.NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_VER, native.version);
            Assert.True(dto.Equals(dto));
            _ = dto.GetHashCode();
        }

        [SkippableFact]
        public void GetIlluminationZonesInfo_ShouldReturnDto()
        {
            var gpu = GetFirstGpuOrSkip();
            var info = FacadeTestUtils.InvokeOrSkip(() => gpu.GetIlluminationZonesInfo(), "Illumination zone info unsupported");
            Skip.If(info == null, "Illumination zone info not supported.");

            var dto = info.Value;
            var native = dto.ToNative();
            Assert.Equal(NVAPI.NV_GPU_CLIENT_ILLUM_ZONE_INFO_PARAMS_VER, native.version);
            Assert.True(dto.Equals(dto));
            _ = dto.GetHashCode();
        }

        [SkippableFact]
        public void GetIlluminationZonesControl_ShouldReturnDto()
        {
            var gpu = GetFirstGpuOrSkip();
            var info = FacadeTestUtils.InvokeOrSkip(() => gpu.GetIlluminationZonesControl(), "Illumination zone control unsupported");
            Skip.If(info == null, "Illumination zone control not supported.");

            var dto = info.Value;
            var native = dto.ToNative();
            Assert.Equal(NVAPI.NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_VER, native.version);
            Assert.True(dto.Equals(dto));
            _ = dto.GetHashCode();
        }

        [SkippableFact]
        public void GetVirtualizationInfo_ShouldReturnDto()
        {
            var gpu = GetFirstGpuOrSkip();
            var info = FacadeTestUtils.InvokeOrSkip(() => gpu.GetVirtualizationInfo(), "Virtualization info unsupported");
            Skip.If(info == null, "Virtualization info not supported.");

            var dto = info.Value;
            var native = dto.ToNative();
            Assert.Equal(NVAPI.NV_GPU_VIRTUALIZATION_INFO_VER, native.version);
            Assert.True(dto.Equals(dto));
            _ = dto.GetHashCode();
        }

        [SkippableFact]
        public void GetLicensableFeatures_ShouldReturnDto()
        {
            var gpu = GetFirstGpuOrSkip();
            var info = FacadeTestUtils.InvokeOrSkip(() => gpu.GetLicensableFeatures(), "Licensable features unsupported");
            Skip.If(info == null, "Licensable features not supported.");

            var dto = info.Value;
            var native = dto.ToNative();
            Assert.Equal(NVAPI.NV_LICENSABLE_FEATURES_VER, native.version);
            Assert.True(dto.Equals(dto));
            _ = dto.GetHashCode();
        }

        [SkippableFact]
        public void GetEncoderStatistics_ShouldReturnDto()
        {
            var gpu = GetFirstGpuOrSkip();
            var info = FacadeTestUtils.InvokeOrSkip(() => gpu.GetEncoderStatistics(), "Encoder statistics unsupported");
            Skip.If(info == null, "Encoder statistics not supported.");

            var dto = info.Value;
            var native = dto.ToNative();
            Assert.Equal(NVAPI.NNV_ENCODER_STATISTICS_VER, native.version);
            Assert.True(dto.Equals(dto));
            _ = dto.GetHashCode();
        }

        [SkippableFact]
        public void GetEncoderSessionsInfo_ShouldReturnDto()
        {
            var gpu = GetFirstGpuOrSkip();
            var info = FacadeTestUtils.InvokeOrSkip(() => gpu.GetEncoderSessionsInfo(), "Encoder sessions info unsupported");
            Skip.If(info == null, "Encoder sessions info not supported.");

            var dto = info.Value;
            var native = dto.ToNative();
            Assert.Equal(NVAPI.NV_ENCODER_SESSIONS_INFO_VER, native.version);
            Assert.True(dto.Equals(dto));
            _ = dto.GetHashCode();
        }

        [SkippableFact]
        public void GetVrReadyData_ShouldReturnDto()
        {
            var gpu = GetFirstGpuOrSkip();
            var info = FacadeTestUtils.InvokeOrSkip(() => gpu.GetVrReadyData(), "VR ready data unsupported");
            Skip.If(info == null, "VR ready data not supported.");

            var dto = info.Value;
            var native = dto.ToNative();
            Assert.Equal(NVAPI.NV_GPU_VR_READY_VER, native.version);
            Assert.True(dto.Equals(dto));
            _ = dto.GetHashCode();
        }

        [SkippableFact]
        public void GetGspFeatures_ShouldReturnDto()
        {
            var gpu = GetFirstGpuOrSkip();
            var info = FacadeTestUtils.InvokeOrSkip(() => gpu.GetGspFeatures(), "GSP features unsupported");
            Skip.If(info == null, "GSP features not supported.");

            var dto = info.Value;
            var native = dto.ToNative();
            Assert.Equal(NVAPI.NV_GPU_GSP_INFO_VER, native.version);
            Assert.True(dto.Equals(dto));
            _ = dto.GetHashCode();
        }

        [SkippableFact]
        public void GetNvlinkCaps_ShouldReturnDto()
        {
            var gpu = GetFirstGpuOrSkip();
            var info = FacadeTestUtils.InvokeOrSkip(() => gpu.GetNvlinkCaps(), "NVLINK caps unsupported");
            Skip.If(info == null, "NVLINK caps not supported.");

            var dto = info.Value;
            var native = dto.ToNative();
            Assert.Equal(NVAPI.NVLINK_GET_CAPS_VER, native.version);
            Assert.True(dto.Equals(dto));
            _ = dto.GetHashCode();
        }

        [SkippableFact]
        public void GetNvlinkStatus_ShouldReturnDto()
        {
            var gpu = GetFirstGpuOrSkip();
            var info = FacadeTestUtils.InvokeOrSkip(() => gpu.GetNvlinkStatus(), "NVLINK status unsupported");
            Skip.If(info == null, "NVLINK status not supported.");

            var dto = info.Value;
            var native = dto.ToNative();
            Assert.Equal(NVAPI.NVLINK_GET_STATUS_VER, native.version);
            Assert.True(dto.Equals(dto));
            _ = dto.GetHashCode();
        }

        [SkippableFact]
        public void GetGpuInfo_ShouldReturnDto()
        {
            var gpu = GetFirstGpuOrSkip();
            var info = FacadeTestUtils.InvokeOrSkip(() => gpu.GetGpuInfo(), "GPU info unsupported");
            Skip.If(info == null, "GPU info not supported.");

            var dto = info.Value;
            var native = dto.ToNative();
            Assert.Equal(NVAPI.NV_GPU_INFO_VER, native.version);
            Assert.True(dto.Equals(dto));
            _ = dto.GetHashCode();
        }

        [SkippableFact]
        public void I2CRead_ShouldReturnDto()
        {
            var gpu = GetFirstGpuOrSkip();
            var displays = gpu.EnumerateNvidiaDisplayHandles();
            Skip.If(displays.Length == 0, "No NVIDIA displays found.");

            var outputId = displays[0].GetAssociatedDisplayOutputId();
            Skip.If(outputId == null || outputId.Value == 0, "Display output ID not available.");

            var request = new NVAPII2CInfoDto(
                outputId.Value,
                true,
                0xA0,
                new byte[] { 0x00 },
                new byte[1],
                (uint)NVAPI.NVAPI_I2C_SPEED_DEPRECATED,
                NV_I2C_SPEED.NVAPI_I2C_SPEED_DEFAULT,
                0,
                false);

            NVAPII2CInfoDto? response;
            try
            {
                response = gpu.I2CRead(request);
            }
            catch (NVAPIException ex)
            {
                Skip.If(true, $"I2C read failed: {ex.Status}");
                return;
            }

            Skip.If(response == null, "I2C read not supported.");

            var dto = response.Value;
            var native = dto.ToNative();
            Assert.Equal(NVAPI.NV_I2C_INFO_VER, native.version);
            Assert.True(dto.Equals(dto));
            _ = dto.GetHashCode();
        }

        [SkippableFact]
        public void I2CWrite_ShouldReturnSuccess()
        {
            var gpu = GetFirstGpuOrSkip();
            var displays = gpu.EnumerateNvidiaDisplayHandles();
            Skip.If(displays.Length == 0, "No NVIDIA displays found.");

            var outputId = displays[0].GetAssociatedDisplayOutputId();
            Skip.If(outputId == null || outputId.Value == 0, "Display output ID not available.");

            var request = new NVAPII2CInfoDto(
                outputId.Value,
                true,
                0xA0,
                Array.Empty<byte>(),
                Array.Empty<byte>(),
                (uint)NVAPI.NVAPI_I2C_SPEED_DEPRECATED,
                NV_I2C_SPEED.NVAPI_I2C_SPEED_DEFAULT,
                0,
                false);

            bool? result;
            try
            {
                result = gpu.I2CWrite(request);
            }
            catch (NVAPIException ex)
            {
                Skip.If(true, $"I2C write failed: {ex.Status}");
                return;
            }

            Skip.If(result == null, "I2C write not supported.");
            Skip.If(result != true, "I2C write did not succeed.");
            Assert.True(result.Value);
        }

        private NVAPIPhysicalGpuHelper GetFirstGpuOrSkip()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            return gpus[0];
        }
    }
}
