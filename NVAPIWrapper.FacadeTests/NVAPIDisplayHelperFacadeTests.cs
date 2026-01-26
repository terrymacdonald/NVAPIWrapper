using System;
using System.Runtime.Versioning;
using Xunit;

namespace NVAPIWrapper.FacadeTests
{
    /// <summary>
    /// Facade tests for display helpers.
    /// </summary>
    [SupportedOSPlatform("windows")]
    [Collection("NVAPI")]
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
    }
}
