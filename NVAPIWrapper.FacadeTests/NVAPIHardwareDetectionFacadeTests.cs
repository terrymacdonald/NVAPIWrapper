using System;
using System.Runtime.Versioning;
using Xunit;

namespace NVAPIWrapper.FacadeTests
{
    /// <summary>
    /// Facade tests for NVAPIHardwareDetection.
    /// </summary>
    [SupportedOSPlatform("windows")]
    [Collection("Passive")]
    [Trait("Category", "Passive")]
    public class NVAPIHardwareDetectionFacadeTests
    {
        [SkippableFact]
        public void HasNVIDIAGPU_ShouldDetectGPU()
        {
            var hasGpu = NVAPIHardwareDetection.HasNVIDIAGPU(out string errorMessage);

            Skip.If(!hasGpu, errorMessage);

            Assert.True(hasGpu);
            Assert.Equal(string.Empty, errorMessage);
        }

        [SkippableFact]
        public void GetNVIDIAGPUNames_ShouldReturnNames()
        {
            var hasGpu = NVAPIHardwareDetection.HasNVIDIAGPU(out string errorMessage);
            Skip.If(!hasGpu, errorMessage);

            var names = NVAPIHardwareDetection.GetNVIDIAGPUNames();

            Assert.NotNull(names);
            Assert.NotEmpty(names);

            foreach (var name in names)
            {
                Assert.NotNull(name);
                Assert.NotEmpty(name);
            }
        }

        [Fact]
        public void HasNVIDIAGPU_ShouldNotThrow()
        {
            var exception = Record.Exception(() =>
            {
                NVAPIHardwareDetection.HasNVIDIAGPU(out _);
            });

            Assert.Null(exception);
        }

        [Fact]
        public void GetNVIDIAGPUNames_ShouldNotThrow()
        {
            var exception = Record.Exception(() =>
            {
                NVAPIHardwareDetection.GetNVIDIAGPUNames();
            });

            Assert.Null(exception);
        }
    }
}
