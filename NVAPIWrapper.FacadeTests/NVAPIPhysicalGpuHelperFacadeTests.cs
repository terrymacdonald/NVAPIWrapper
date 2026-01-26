using System;
using System.Runtime.Versioning;
using Xunit;

namespace NVAPIWrapper.FacadeTests
{
    /// <summary>
    /// Facade tests for physical GPU helpers.
    /// </summary>
    [SupportedOSPlatform("windows")]
    [Collection("NVAPI")]
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
    }
}
