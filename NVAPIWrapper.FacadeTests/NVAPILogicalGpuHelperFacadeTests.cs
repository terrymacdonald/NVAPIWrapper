using System;
using System.Runtime.Versioning;
using Xunit;

namespace NVAPIWrapper.FacadeTests
{
    /// <summary>
    /// Facade tests for logical GPU helpers.
    /// </summary>
    [SupportedOSPlatform("windows")]
    [Collection("NVAPI")]
    public class NVAPILogicalGpuHelperFacadeTests
    {
        private readonly NVAPITestFixture _fixture;

        public NVAPILogicalGpuHelperFacadeTests(NVAPITestFixture fixture)
        {
            _fixture = fixture;
        }

        [SkippableFact]
        public void EnumerateLogicalGpus_ShouldReturnArray()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumerateLogicalGpus();
            Assert.NotNull(gpus);
            Assert.InRange(gpus.Length, 0, NVAPI.NVAPI_MAX_LOGICAL_GPUS);
        }

        [SkippableFact]
        public void GetPhysicalGpusFromLogicalGpu_ShouldReturnArray()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumerateLogicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA logical GPUs found.");

            var physicalGpus = gpus[0].GetPhysicalGpusFromLogicalGpu();
            Assert.NotNull(physicalGpus);
            Assert.InRange(physicalGpus.Length, 1, NVAPI.NVAPI_MAX_PHYSICAL_GPUS);
        }
    }
}
