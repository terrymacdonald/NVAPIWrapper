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
    }
}
