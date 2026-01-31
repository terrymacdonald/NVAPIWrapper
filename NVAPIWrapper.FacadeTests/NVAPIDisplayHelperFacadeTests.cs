using System;
using System.Runtime.Versioning;
using Xunit;

namespace NVAPIWrapper.FacadeTests
{
    /// <summary>
    /// Facade tests for display helpers.
    /// </summary>
    [SupportedOSPlatform("windows")]
    [Collection("Passive")]
    [Trait("Category", "Passive")]
    public class NVAPIDisplayHelperFacadeTests
    {
        private readonly NVAPITestFixture _fixture;

        public NVAPIDisplayHelperFacadeTests(NVAPITestFixture fixture)
        {
            _fixture = fixture;
        }

        [SkippableFact]
        public void EnumerateNvidiaDisplayHandles_ShouldReturnArray()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var displays = gpus[0].EnumerateNvidiaDisplayHandles();
            Assert.NotNull(displays);
            Assert.InRange(displays.Length, 0, NVAPI.NVAPI_MAX_DISPLAYS);
        }

        [SkippableFact]
        public void GetPhysicalGpusFromDisplay_ShouldReturnArray()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var displays = gpus[0].EnumerateNvidiaDisplayHandles();
            Skip.If(displays.Length == 0, "No NVIDIA displays found.");

            var physicalGpus = displays[0].GetPhysicalGpusFromDisplay();
            Assert.NotNull(physicalGpus);
            Assert.InRange(physicalGpus.Length, 1, NVAPI.NVAPI_MAX_PHYSICAL_GPUS);
        }

        [SkippableFact]
        public void GetLogicalGpuFromDisplay_ShouldReturnHelper()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var displays = gpus[0].EnumerateNvidiaDisplayHandles();
            Skip.If(displays.Length == 0, "No NVIDIA displays found.");

            var logicalGpu = displays[0].GetLogicalGpuFromDisplay();
            Skip.If(logicalGpu == null, "Logical GPU not available for display.");
            Assert.NotNull(logicalGpu);
        }

        [SkippableFact]
        public void GetAssociatedNvidiaDisplayName_ShouldReturnValue()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var displays = gpus[0].EnumerateNvidiaDisplayHandles();
            Skip.If(displays.Length == 0, "No NVIDIA displays found.");

            var name = displays[0].GetAssociatedNvidiaDisplayName();
            Skip.If(string.IsNullOrWhiteSpace(name), "Display name not supported.");
            Assert.False(string.IsNullOrWhiteSpace(name));
        }

        [SkippableFact]
        public void GetAssociatedDisplayOutputId_ShouldReturnValue()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var displays = gpus[0].EnumerateNvidiaDisplayHandles();
            Skip.If(displays.Length == 0, "No NVIDIA displays found.");

            var outputId = displays[0].GetAssociatedDisplayOutputId();
            Skip.If(outputId == null, "Display output ID not supported.");
            Assert.True(outputId.HasValue);
        }

        [SkippableFact]
        public void GetGpuAndOutputIdFromDisplayId_ShouldReturnDto()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var displays = gpus[0].EnumerateNvidiaDisplayHandles();
            Skip.If(displays.Length == 0, "No NVIDIA displays found.");

            var info = FacadeTestUtils.InvokeOrSkip(() => displays[0].GetGpuAndOutputIdFromDisplayId(), "GPU/output ID unsupported");
            Skip.If(info == null, "GPU/output ID not supported.");

            var dto = info.Value;
            Assert.NotNull(dto.PhysicalGpu);
            Assert.True(dto.Equals(dto));
            _ = dto.GetHashCode();
        }

        [SkippableFact]
        public void GetPhysicalGpuFromDisplayId_ShouldReturnHelper()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var displays = gpus[0].EnumerateNvidiaDisplayHandles();
            Skip.If(displays.Length == 0, "No NVIDIA displays found.");

            var physicalGpu = FacadeTestUtils.InvokeOrSkip(() => displays[0].GetPhysicalGpuFromDisplayId(), "Physical GPU lookup unsupported");
            Skip.If(physicalGpu == null, "Physical GPU lookup not supported.");
            Assert.NotNull(physicalGpu);
        }

        [SkippableFact]
        public void GetVBlankCounter_ShouldReturnValue()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var displays = gpus[0].EnumerateNvidiaDisplayHandles();
            Skip.If(displays.Length == 0, "No NVIDIA displays found.");

            var counter = displays[0].GetVBlankCounter();
            Skip.If(counter == null, "VBlank counter not supported.");
            Assert.True(counter.HasValue);
        }

        [SkippableFact]
        public void GetDisplayConfig_ShouldReturnSnapshot()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var displays = gpus[0].EnumerateNvidiaDisplayHandles();
            Skip.If(displays.Length == 0, "No NVIDIA displays found.");

            var config = displays[0].GetDisplayConfig();
            Skip.If(config == null, "Display config not supported.");

            Assert.NotNull(config.Value.Paths);
            Assert.InRange(config.Value.Paths.Length, 0, NVAPI.NVAPI_MAX_DISPLAYS);
        }

        [SkippableFact]
        public void GetDisplayIdByDisplayName_ShouldReturnValue()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var displays = gpus[0].EnumerateNvidiaDisplayHandles();
            Skip.If(displays.Length == 0, "No NVIDIA displays found.");

            var displayId = displays[0].GetDisplayIdByDisplayName();
            Skip.If(displayId == null, "Display ID not supported.");
            Assert.True(displayId.HasValue);
        }

        [SkippableFact]
        public void GetGdiPrimaryDisplayId_ShouldReturnValue()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var displays = gpus[0].EnumerateNvidiaDisplayHandles();
            Skip.If(displays.Length == 0, "No NVIDIA displays found.");

            var displayId = displays[0].GetGdiPrimaryDisplayId();
            Skip.If(displayId == null, "GDI primary display ID not supported.");
            Assert.True(displayId.HasValue);
        }

        [SkippableFact]
        public void GetSupportedViews_ShouldReturnDto()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var displays = gpus[0].EnumerateNvidiaDisplayHandles();
            Skip.If(displays.Length == 0, "No NVIDIA displays found.");

            var views = displays[0].GetSupportedViews();
            Skip.If(views == null, "Supported views not available.");
            Assert.NotNull(views.Value.Views);
        }

        [SkippableFact]
        public void GetEdidData_ShouldReturnDto()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var displays = gpus[0].EnumerateNvidiaDisplayHandles();
            Skip.If(displays.Length == 0, "No NVIDIA displays found.");

            var edid = displays[0].GetEdidData();
            Skip.If(edid == null, "EDID data not supported.");
            Assert.Equal((int)edid.Value.SizeOfEdid, edid.Value.Data.Length);
        }

        [SkippableFact]
        public void GetTiming_ShouldReturnDto()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var displays = gpus[0].EnumerateNvidiaDisplayHandles();
            Skip.If(displays.Length == 0, "No NVIDIA displays found.");

            var config = displays[0].GetDisplayConfig();
            Skip.If(config == null || config.Value.Paths.Length == 0, "Display config not available.");

            var path = config.Value.Paths[0];
            Skip.If(!path.SourceModeInfo.HasValue, "Source mode info not available.");
            Skip.If(path.Targets.Length == 0 || !path.Targets[0].Details.HasValue, "Target details not available.");

            var source = path.SourceModeInfo.Value;
            var details = path.Targets[0].Details.GetValueOrDefault();
            Skip.If(details.RefreshRate1K == 0, "Refresh rate not available.");

            var input = new NVAPITimingInputDto(
                source.Resolution.width,
                source.Resolution.height,
                details.RefreshRate1K / 1000.0f,
                default,
                details.TimingOverride);

            var timing = displays[0].GetTiming(input);
            Skip.If(timing == null, "Timing not supported.");
            Assert.NotNull(timing);
        }

        [SkippableFact]
        public void GetMonitorCapabilities_ShouldReturnDto()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var displays = gpus[0].EnumerateNvidiaDisplayHandles();
            Skip.If(displays.Length == 0, "No NVIDIA displays found.");

            var caps = displays[0].GetMonitorCapabilities();
            Skip.If(caps == null, "Monitor capabilities not supported.");
            Assert.NotNull(caps);
        }

        [SkippableFact]
        public void GetMonitorColorCapabilities_ShouldReturnDto()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var displays = gpus[0].EnumerateNvidiaDisplayHandles();
            Skip.If(displays.Length == 0, "No NVIDIA displays found.");

            var caps = displays[0].GetMonitorColorCapabilities();
            Skip.If(caps == null, "Monitor color capabilities not supported.");
            Assert.NotNull(caps.Value.Capabilities);
        }

        [SkippableFact]
        public void GetDisplayPortInfo_ShouldReturnDto()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var displays = gpus[0].EnumerateNvidiaDisplayHandles();
            Skip.If(displays.Length == 0, "No NVIDIA displays found.");

            var info = displays[0].GetDisplayPortInfo();
            Skip.If(info == null, "DisplayPort info not supported.");
            Assert.NotNull(info);
        }

        [SkippableFact]
        public void GetHdmiSupportInfo_ShouldReturnDto()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var displays = gpus[0].EnumerateNvidiaDisplayHandles();
            Skip.If(displays.Length == 0, "No NVIDIA displays found.");

            var info = displays[0].GetHdmiSupportInfo();
            Skip.If(info == null, "HDMI support info not supported.");
            Assert.NotNull(info);
        }

        [SkippableFact]
        public void GetVrrInfo_ShouldReturnDto()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var displays = gpus[0].EnumerateNvidiaDisplayHandles();
            Skip.If(displays.Length == 0, "No NVIDIA displays found.");

            var info = displays[0].GetVrrInfo();
            Skip.If(info == null, "VRR info not supported.");
            Assert.NotNull(info);
        }

        [SkippableFact]
        public void GetAdaptiveSyncData_ShouldReturnDto()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var displays = gpus[0].EnumerateNvidiaDisplayHandles();
            Skip.If(displays.Length == 0, "No NVIDIA displays found.");

            var data = displays[0].GetAdaptiveSyncData();
            Skip.If(data == null, "Adaptive sync data not supported.");
            Assert.NotNull(data);
        }

        [SkippableFact]
        public void GetVirtualRefreshRateData_ShouldReturnDto()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var displays = gpus[0].EnumerateNvidiaDisplayHandles();
            Skip.If(displays.Length == 0, "No NVIDIA displays found.");

            var data = displays[0].GetVirtualRefreshRateData();
            Skip.If(data == null, "Virtual refresh rate data not supported.");
            Assert.NotNull(data);
        }

        [SkippableFact]
        public void GetPreferredStereoDisplay_ShouldReturnDto()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var displays = gpus[0].EnumerateNvidiaDisplayHandles();
            Skip.If(displays.Length == 0, "No NVIDIA displays found.");

            var display = displays[0].GetPreferredStereoDisplay();
            Skip.If(display == null, "Preferred stereo display not supported.");
            Assert.NotNull(display);
        }
    }
}
