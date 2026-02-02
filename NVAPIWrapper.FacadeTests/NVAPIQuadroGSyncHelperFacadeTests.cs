using System;
using System.Runtime.Versioning;
using Xunit;

namespace NVAPIWrapper.FacadeTests
{
    /// <summary>
    /// Facade tests for Quadro G-Sync helpers.
    /// </summary>
    [SupportedOSPlatform("windows")]
    [Collection("Passive")]
    [Trait("Category", "Passive")]
    public sealed class NVAPIQuadroGSyncHelperFacadeTests
    {
        private readonly NVAPITestFixture _fixture;

        public NVAPIQuadroGSyncHelperFacadeTests(NVAPITestFixture fixture)
        {
            _fixture = fixture;
        }

        [SkippableFact]
        public void EnumerateGSyncDevices_ShouldReturnArray()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var devices = _fixture.ApiHelper.EnumerateGSyncDevices();
            Assert.NotNull(devices);
            Assert.InRange(devices.Length, 0, NVAPI.NVAPI_MAX_GSYNC_DEVICES);
        }
    }
}
