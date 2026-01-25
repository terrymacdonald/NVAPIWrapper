using System;
using System.Runtime.Versioning;
using Xunit;

namespace NVAPIWrapper.NativeTests
{
    /// <summary>
    /// Basic NVAPI initialization and interface version tests.
    /// </summary>
    [SupportedOSPlatform("windows")]
    public class BasicApiTests : IDisposable
    {
        private readonly NVAPIApi? _api;
        private readonly string _skipReason = string.Empty;

        public BasicApiTests()
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
        public void DllAvailability_ShouldFindNVAPIDll()
        {
            var hasDll = NVAPIApi.IsNVAPIDllAvailable(out var dllError);
            Skip.If(!hasDll, dllError);
            Assert.True(hasDll);
        }

        [SkippableFact]
        public void Initialize_ShouldSucceed()
        {
            Skip.If(_api == null, _skipReason);
            Assert.NotNull(_api);
        }

        [SkippableFact]
        public void GetInterfaceVersionString_ShouldReturnValue()
        {
            Skip.If(_api == null, _skipReason);
            var version = _api.GetInterfaceVersionString();
            Assert.False(string.IsNullOrWhiteSpace(version));
        }

        [SkippableFact]
        public void GetAvailableFunctions_ShouldIncludeCoreEntries()
        {
            Skip.If(_api == null, _skipReason);

            var functions = _api.GetAvailableFunctions();
            Assert.NotEmpty(functions);

            Assert.Contains(functions, entry => entry.Name == "NvAPI_Initialize" && entry.IsAvailable);
            Assert.Contains(functions, entry => entry.Name == "NvAPI_Unload" && entry.IsAvailable);
            Assert.Contains(functions, entry => entry.Name == "NvAPI_GetErrorMessage" && entry.IsAvailable);
        }

        [SkippableFact]
        public unsafe void EnumeratePhysicalGpus_ShouldReturnArray()
        {
            Skip.If(_api == null, _skipReason);

            var gpus = _api.EnumeratePhysicalGpus();
            Assert.NotNull(gpus);
            Assert.InRange(gpus.Length, 0, NVAPI.NVAPI_MAX_PHYSICAL_GPUS);
        }

        [SkippableFact]
        public unsafe void EnumerateLogicalGpus_ShouldReturnArray()
        {
            Skip.If(_api == null, _skipReason);

            var gpus = _api.EnumerateLogicalGpus();
            Assert.NotNull(gpus);
            Assert.InRange(gpus.Length, 0, NVAPI.NVAPI_MAX_LOGICAL_GPUS);
        }

        [SkippableFact]
        public unsafe void EnumerateNvidiaDisplayHandles_ShouldReturnArray()
        {
            Skip.If(_api == null, _skipReason);

            var displays = _api.EnumerateNvidiaDisplayHandles();
            Assert.NotNull(displays);
            Assert.InRange(displays.Length, 0, NVAPI.NVAPI_MAX_DISPLAYS);
        }

        public void Dispose()
        {
            _api?.Dispose();
        }
    }
}
