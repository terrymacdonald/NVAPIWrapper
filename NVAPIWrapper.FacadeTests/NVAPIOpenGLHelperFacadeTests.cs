using System.Runtime.Versioning;
using Xunit;

namespace NVAPIWrapper.FacadeTests
{
    /// <summary>
    /// Facade tests for OpenGL helper.
    /// </summary>
    [SupportedOSPlatform("windows")]
    [Collection("Passive")]
    [Trait("Category", "Passive")]
    public class NVAPIOpenGLHelperFacadeTests
    {
        private readonly NVAPITestFixture _fixture;

        public NVAPIOpenGLHelperFacadeTests(NVAPITestFixture fixture)
        {
            _fixture = fixture;
        }

        [SkippableFact]
        public void GetOpenGLHelper_ShouldReturnHelper()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var helper = _fixture.ApiHelper.GetOpenGLHelper();
            Assert.NotNull(helper);
        }

        [SkippableFact]
        public void ExpertModeGet_ShouldReturnDto()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var helper = _fixture.ApiHelper.GetOpenGLHelper();
            var info = FacadeTestUtils.InvokeOrSkip(() => helper.ExpertModeGet(), "OpenGL expert mode get unsupported");
            Skip.If(info == null, "OpenGL expert mode get not supported.");

            var dto = info.Value;
            var native = dto.ToNative();
            Assert.True(dto.Equals(dto));
            _ = dto.GetHashCode();
            Assert.Equal(dto.DetailMask, native.DetailMask);
        }

        [SkippableFact]
        public void ExpertModeDefaultsGet_ShouldReturnDto()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var helper = _fixture.ApiHelper.GetOpenGLHelper();
            var info = FacadeTestUtils.InvokeOrSkip(() => helper.ExpertModeDefaultsGet(), "OpenGL expert defaults get unsupported");
            Skip.If(info == null, "OpenGL expert defaults get not supported.");

            var dto = info.Value;
            var native = dto.ToNative();
            Assert.True(dto.Equals(dto));
            _ = dto.GetHashCode();
            Assert.Equal(dto.DetailMask, native.DetailMask);
        }
    }
}
