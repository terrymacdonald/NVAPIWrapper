using System;
using System.Runtime.Versioning;
using Xunit;

namespace NVAPIWrapper.FacadeTests
{
    /// <summary>
    /// Facade tests for unattached display helpers.
    /// </summary>
    [SupportedOSPlatform("windows")]
    [Collection("Passive")]
    [Trait("Category", "Passive")]
    public sealed class NVAPIUnAttachedDisplayHelperFacadeTests
    {
        private readonly NVAPITestFixture _fixture;

        public NVAPIUnAttachedDisplayHelperFacadeTests(NVAPITestFixture fixture)
        {
            _fixture = fixture;
        }

        [SkippableFact]
        public void EnumerateUnAttachedDisplayHandles_ShouldReturnArray()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var handles = _fixture.ApiHelper.EnumerateUnAttachedDisplayHandles();
            Assert.NotNull(handles);
            Assert.InRange(handles.Length, 0, NVAPI.NVAPI_MAX_DISPLAYS);
        }

        [SkippableFact]
        public void GetUnAttachedAssociatedDisplayName_ShouldReturnValue()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var handles = _fixture.ApiHelper.EnumerateUnAttachedDisplayHandles();
            Skip.If(handles.Length == 0, "No unattached displays found.");

            var name = handles[0].GetUnAttachedAssociatedDisplayName();
            Skip.If(string.IsNullOrWhiteSpace(name), "Unattached display name not supported.");
            Assert.False(string.IsNullOrWhiteSpace(name));
        }

        [SkippableFact]
        public void GetPhysicalGpuFromUnAttachedDisplay_ShouldReturnHelper()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var handles = _fixture.ApiHelper.EnumerateUnAttachedDisplayHandles();
            Skip.If(handles.Length == 0, "No unattached displays found.");

            var gpu = handles[0].GetPhysicalGpuFromUnAttachedDisplay();
            Skip.If(gpu == null, "Physical GPU not supported for unattached display.");
            Assert.NotNull(gpu);
        }

        [SkippableFact]
        public void CreateDisplayFromUnAttachedDisplay_ShouldReturnHelper()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var handles = _fixture.ApiHelper.EnumerateUnAttachedDisplayHandles();
            Skip.If(handles.Length == 0, "No unattached displays found.");

            var display = handles[0].CreateDisplayFromUnAttachedDisplay();
            Skip.If(display == null, "Create display from unattached display not supported.");
            Assert.NotNull(display);
        }

        [SkippableFact]
        public void GetAssociatedUnAttachedNvidiaDisplayHandle_ShouldReturnHelper()
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var handles = _fixture.ApiHelper.EnumerateUnAttachedDisplayHandles();
            Skip.If(handles.Length == 0, "No unattached displays found.");

            var gpus = _fixture.ApiHelper.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var displays = gpus[0].EnumerateNvidiaDisplayHandles();
            Skip.If(displays.Length == 0, "No NVIDIA displays found.");

            var name = displays[0].GetAssociatedNvidiaDisplayName();
            Skip.If(string.IsNullOrWhiteSpace(name), "Display name not supported.");

            var handle = FacadeTestUtils.InvokeOrSkip(
                () => handles[0].GetAssociatedUnAttachedNvidiaDisplayHandle(name!),
                "Associated unattached display handle unsupported");
            Skip.If(handle == null, "Associated unattached display not supported.");
            Assert.NotNull(handle);
        }
    }
}
