using System;
using System.Runtime.Versioning;
using Xunit;

namespace NVAPIWrapper.FacadeTests
{
    /// <summary>
    /// Facade tests for DRS helper.
    /// </summary>
    [SupportedOSPlatform("windows")]
    [Collection("Passive")]
    [Trait("Category", "Passive")]
    public class NVAPIDrsHelperFacadeTests
    {
        private readonly NVAPITestFixture _fixture;

        public NVAPIDrsHelperFacadeTests(NVAPITestFixture fixture)
        {
            _fixture = fixture;
        }

        [SkippableFact]
        public void CreateDrsSession_ShouldReturnHelper()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var helper = _fixture.ApiHelper.CreateDrsSession();
            Skip.If(helper == null, "DRS not supported.");
            helper.Dispose();
        }

        [SkippableFact]
        public void LoadSettings_ShouldSucceed()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            using var helper = _fixture.ApiHelper.CreateDrsSession();
            Skip.If(helper == null, "DRS not supported.");

            var loaded = FacadeTestUtils.InvokeOrSkip(() => helper.LoadSettings(), "DRS load unsupported");
            Skip.If(!loaded, "DRS not supported.");
        }

        [SkippableFact]
        public void GetNumProfiles_ShouldReturnValue()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            using var helper = _fixture.ApiHelper.CreateDrsSession();
            Skip.If(helper == null, "DRS not supported.");

            FacadeTestUtils.InvokeOrSkip(() => helper.LoadSettings(), "DRS load unsupported");
            var count = FacadeTestUtils.InvokeOrSkip(() => helper.GetNumProfiles(), "DRS get profile count unsupported");
            Skip.If(count == null, "DRS not supported.");
            Assert.True(count.Value >= 0);
        }

        [SkippableFact]
        public void EnumProfiles_ShouldReturnArray()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            using var helper = _fixture.ApiHelper.CreateDrsSession();
            Skip.If(helper == null, "DRS not supported.");

            FacadeTestUtils.InvokeOrSkip(() => helper.LoadSettings(), "DRS load unsupported");
            var profiles = FacadeTestUtils.InvokeOrSkip(() => helper.EnumProfiles(), "DRS enum profiles unsupported");
            Assert.NotNull(profiles);
        }

        [SkippableFact]
        public void GetCurrentGlobalProfile_ShouldReturnProfile()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            using var helper = _fixture.ApiHelper.CreateDrsSession();
            Skip.If(helper == null, "DRS not supported.");

            FacadeTestUtils.InvokeOrSkip(() => helper.LoadSettings(), "DRS load unsupported");
            var profile = FacadeTestUtils.InvokeOrSkip(() => helper.GetCurrentGlobalProfile(), "DRS global profile unsupported");
            Skip.If(profile == null, "DRS not supported.");

            var dto = profile.Value;
            Assert.False(string.IsNullOrWhiteSpace(dto.ProfileName));
        }
    }
}
