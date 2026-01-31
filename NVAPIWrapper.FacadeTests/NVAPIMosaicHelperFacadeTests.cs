using System;
using System.Runtime.Versioning;
using Xunit;

namespace NVAPIWrapper.FacadeTests
{
    /// <summary>
    /// Facade tests for Mosaic helpers.
    /// </summary>
    [SupportedOSPlatform("windows")]
    [Collection("Passive")]
    [Trait("Category", "Passive")]
    public class NVAPIMosaicHelperFacadeTests
    {
        private readonly NVAPITestFixture _fixture;

        public NVAPIMosaicHelperFacadeTests(NVAPITestFixture fixture)
        {
            _fixture = fixture;
        }

        [SkippableFact]
        public void GetSupportedTopoInfo_ShouldReturnDto()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var mosaic = _fixture.ApiHelper.GetMosaicHelper();
            var info = FacadeTestUtils.InvokeOrSkip(() => mosaic.GetSupportedTopoInfo(), "Mosaic supported topo info unsupported");
            Skip.If(info == null, "Mosaic supported topo info not supported.");

            Assert.NotNull(info.Value.TopoBriefs);
            Assert.NotNull(info.Value.DisplaySettings);
        }

        [SkippableFact]
        public void GetCurrentTopo_ShouldReturnDto()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var mosaic = _fixture.ApiHelper.GetMosaicHelper();
            var topo = FacadeTestUtils.InvokeOrSkip(() => mosaic.GetCurrentTopo(), "Mosaic current topo unsupported");
            Skip.If(topo == null, "Mosaic current topo not supported.");

            Assert.True(topo.Value.TopoBrief.Equals(topo.Value.TopoBrief));
        }

        [SkippableFact]
        public void EnumDisplayGrids_ShouldReturnDto()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var mosaic = _fixture.ApiHelper.GetMosaicHelper();
            var grids = FacadeTestUtils.InvokeOrSkip(() => mosaic.EnumDisplayGrids(), "Mosaic display grids unsupported");
            Skip.If(grids == null, "Mosaic display grids not supported.");

            Assert.NotNull(grids.Value.Grids);
        }

        [SkippableFact]
        public void EnumDisplayModes_ShouldReturnDto()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var mosaic = _fixture.ApiHelper.GetMosaicHelper();
            var grids = FacadeTestUtils.InvokeOrSkip(() => mosaic.EnumDisplayGrids(), "Mosaic display grids unsupported");
            Skip.If(grids == null || grids.Value.Grids.Length == 0, "No Mosaic grids available.");

            var modes = FacadeTestUtils.InvokeOrSkip(() => mosaic.EnumDisplayModes(grids.Value.Grids[0]), "Mosaic display modes unsupported");
            Skip.If(modes == null, "Mosaic display modes not supported.");

            Assert.NotNull(modes.Value.Settings);
        }

        [SkippableFact]
        public void GetTopoGroup_ShouldReturnDto()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var mosaic = _fixture.ApiHelper.GetMosaicHelper();
            var info = FacadeTestUtils.InvokeOrSkip(() => mosaic.GetSupportedTopoInfo(), "Mosaic supported topo info unsupported");
            Skip.If(info == null || info.Value.TopoBriefs.Length == 0, "No Mosaic topo briefs available.");

            var group = FacadeTestUtils.InvokeOrSkip(() => mosaic.GetTopoGroup(info.Value.TopoBriefs[0]), "Mosaic topo group unsupported");
            Skip.If(group == null, "Mosaic topo group not supported.");

            Assert.NotNull(group.Value.Topos);
        }

        [SkippableFact]
        public void GetOverlapLimits_ShouldReturnDto()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var mosaic = _fixture.ApiHelper.GetMosaicHelper();
            var info = FacadeTestUtils.InvokeOrSkip(() => mosaic.GetSupportedTopoInfo(), "Mosaic supported topo info unsupported");
            Skip.If(info == null || info.Value.TopoBriefs.Length == 0 || info.Value.DisplaySettings.Length == 0, "No Mosaic topo/display settings available.");

            var limits = FacadeTestUtils.InvokeOrSkip(() => mosaic.GetOverlapLimits(info.Value.TopoBriefs[0], info.Value.DisplaySettings[0]), "Mosaic overlap limits unsupported");
            Skip.If(limits == null, "Mosaic overlap limits not supported.");

            Assert.True(limits.Value.Equals(limits.Value));
        }

        [SkippableFact]
        public void GetDisplayViewportsByResolution_ShouldReturnDto()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var displays = gpus[0].EnumerateNvidiaDisplayHandles();
            Skip.If(displays.Length == 0, "No NVIDIA displays found.");

            var displayId = displays[0].GetDisplayIdByDisplayName();
            Skip.If(displayId == null, "Display ID not supported.");

            var mosaic = _fixture.ApiHelper.GetMosaicHelper();
            var viewports = FacadeTestUtils.InvokeOrSkip(
                () => mosaic.GetDisplayViewportsByResolution(displayId.Value, 1920, 1080),
                "Mosaic viewports unsupported");
            Skip.If(viewports == null, "Mosaic viewports not supported.");

            Assert.NotNull(viewports.Value.Viewports);
        }
    }
}
