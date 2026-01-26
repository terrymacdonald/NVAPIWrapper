using System;

namespace NVAPIWrapper.FacadeTests
{
    /// <summary>
    /// Shared NVAPI helper fixture for facade tests.
    /// </summary>
    public sealed class NVAPITestFixture : IDisposable
    {
        public NVAPIApiHelper? ApiHelper { get; }
        public string SkipReason { get; } = string.Empty;

        public NVAPITestFixture()
        {
            if (!NVAPIApi.IsNVAPIDllAvailable(out var dllError))
            {
                SkipReason = dllError;
                return;
            }

            try
            {
                ApiHelper = NVAPIApiHelper.Initialize();
            }
            catch (NVAPIException ex)
            {
                SkipReason = $"NVAPI initialization failed: {ex.Message}";
            }
            catch (Exception ex)
            {
                SkipReason = $"NVAPI initialization failed: {ex.Message}";
            }
        }

        public void Dispose()
        {
            ApiHelper?.Dispose();
        }
    }
}
