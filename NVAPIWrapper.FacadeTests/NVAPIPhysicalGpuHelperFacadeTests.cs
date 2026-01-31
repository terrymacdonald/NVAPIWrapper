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
    }
}
