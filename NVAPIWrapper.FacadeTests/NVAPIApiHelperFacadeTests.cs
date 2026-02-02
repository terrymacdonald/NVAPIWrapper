using System;
using System.Runtime.Versioning;
using Xunit;

namespace NVAPIWrapper.FacadeTests
{
    /// <summary>
    /// Facade tests for NVAPIApiHelper.
    /// </summary>
    [SupportedOSPlatform("windows")]
    [Collection("Passive")]
    [Trait("Category", "Passive")]
    public class NVAPIApiHelperFacadeTests
    {
        private readonly NVAPITestFixture _fixture;

        public NVAPIApiHelperFacadeTests(NVAPITestFixture fixture)
        {
            _fixture = fixture;
        }

        [SkippableFact]
        public void GetDriverAndBranchVersion_ShouldReturnDto()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var info = FacadeTestUtils.InvokeOrSkip(
                () => _fixture.ApiHelper.GetDriverAndBranchVersion(),
                "Driver and branch version unsupported");

            Skip.If(info == null, "Driver and branch version not supported.");

            var dto = info.Value;
            Assert.True(dto.DriverVersion > 0);
            Assert.NotNull(dto.Branch);
            Assert.True(dto.Equals(dto));
            _ = dto.GetHashCode();
        }

        [SkippableFact]
        public void GetChipSetInfo_ShouldReturnDto()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var info = FacadeTestUtils.InvokeOrSkip(
                () => _fixture.ApiHelper.GetChipSetInfo(),
                "Chipset info unsupported");

            Skip.If(info == null, "Chipset info not supported.");

            var dto = info.Value;
            Assert.NotNull(dto.VendorName);
            Assert.NotNull(dto.ChipsetName);
            Assert.True(dto.Equals(dto));
            _ = dto.GetHashCode();
        }

        [SkippableFact]
        public void GetLidAndDockInfo_ShouldReturnDto()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var info = FacadeTestUtils.InvokeOrSkip(
                () => _fixture.ApiHelper.GetLidAndDockInfo(),
                "Lid and dock info unsupported");

            Skip.If(info == null, "Lid and dock info not supported.");

            var dto = info.Value;
            Assert.True(dto.Equals(dto));
            _ = dto.GetHashCode();
        }

        [SkippableFact]
        public void GetDisplayDriverInfo_ShouldReturnDto()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var info = FacadeTestUtils.InvokeOrSkip(
                () => _fixture.ApiHelper.GetDisplayDriverInfo(),
                "Display driver info unsupported");

            Skip.If(info == null, "Display driver info not supported.");

            var dto = info.Value;
            Assert.True(dto.DriverVersion > 0);
            Assert.NotNull(dto.BuildBranch);
            Assert.True(dto.Equals(dto));
            _ = dto.GetHashCode();
        }

        [SkippableFact]
        public void GetSystemPhysicalGpus_ShouldReturnDtoArray()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = FacadeTestUtils.InvokeOrSkip(
                () => _fixture.ApiHelper.GetPhysicalGpus(),
                "System physical GPU enumeration unsupported");

            Assert.NotNull(gpus);
            Assert.InRange(gpus.Length, 0, NVAPI.NVAPI_MAX_PHYSICAL_GPUS);
            Skip.If(gpus.Length == 0, "No system physical GPUs returned.");

            var first = gpus[0];
            Assert.NotNull(first.PhysicalGpu);
            Assert.True(first.Equals(first));
            _ = first.GetHashCode();
        }

        [SkippableFact]
        public void GetSystemLogicalGpus_ShouldReturnDtoArray()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = FacadeTestUtils.InvokeOrSkip(
                () => _fixture.ApiHelper.GetLogicalGpus(),
                "System logical GPU enumeration unsupported");

            Assert.NotNull(gpus);
            Assert.InRange(gpus.Length, 0, NVAPI.NVAPI_MAX_LOGICAL_GPUS);
            Skip.If(gpus.Length == 0, "No system logical GPUs returned.");

            var first = gpus[0];
            Assert.NotNull(first.LogicalGpu);
            Assert.True(first.Equals(first));
            _ = first.GetHashCode();
        }

        [SkippableFact]
        public void GetGpuIdFromPhysicalGpu_ShouldReturnValue()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var gpuId = FacadeTestUtils.InvokeOrSkip(
                () => _fixture.ApiHelper.GetGpuIdFromPhysicalGpu(gpus[0]),
                "GPU ID lookup unsupported");

            Skip.If(gpuId == null, "GPU ID lookup not supported.");
            Assert.True(gpuId.HasValue);
        }

        [SkippableFact]
        public void GetPhysicalGpuFromGpuId_ShouldReturnHelper()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var gpuId = FacadeTestUtils.InvokeOrSkip(
                () => _fixture.ApiHelper.GetGpuIdFromPhysicalGpu(gpus[0]),
                "GPU ID lookup unsupported");

            Skip.If(gpuId == null, "GPU ID lookup not supported.");

            var helper = FacadeTestUtils.InvokeOrSkip(
                () => _fixture.ApiHelper.GetPhysicalGpuFromGpuId(gpuId.Value),
                "Physical GPU lookup unsupported");

            Skip.If(helper == null, "Physical GPU lookup not supported.");
            Assert.NotNull(helper);
        }

        [SkippableFact]
        public void GetLogicalGpuFromPhysicalGpu_ShouldReturnHelper()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var logical = FacadeTestUtils.InvokeOrSkip(
                () => _fixture.ApiHelper.GetLogicalGpuFromPhysicalGpu(gpus[0]),
                "Logical GPU lookup unsupported");

            Skip.If(logical == null, "Logical GPU lookup not supported.");
            Assert.NotNull(logical);
        }
    }
}
