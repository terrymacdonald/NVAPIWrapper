using System;
using System.Linq;
using System.Runtime.Versioning;
using Xunit;

namespace NVAPIWrapper.NativeTests
{
    /// <summary>
    /// Native G-Sync API tests.
    /// </summary>
    [SupportedOSPlatform("windows")]
    public sealed class NVAPIGSyncNativeTests : IDisposable
    {
        private readonly NVAPIApi? _api;
        private readonly string _skipReason = string.Empty;

        public NVAPIGSyncNativeTests()
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
        public unsafe void GSyncEnumSyncDevices_ShouldReturnArray()
        {
            SkipIfUnavailable("NvAPI_GSync_EnumSyncDevices");

            var devices = _api!.EnumerateGSyncDevices();
            Assert.NotNull(devices);
            Assert.InRange(devices.Length, 0, NVAPI.NVAPI_MAX_GSYNC_DEVICES);
        }

        private void SkipIfUnavailable(string functionName)
        {
            Skip.If(_api == null, _skipReason);

            var functions = _api!.GetAvailableFunctions();
            var available = functions.Any(entry => entry.Name == functionName && entry.IsAvailable);
            Skip.If(!available, $"NVAPI function '{functionName}' not available.");
        }

        public void Dispose()
        {
            _api?.Dispose();
        }
    }
}
