
using System;
using System.Collections.Generic;
using System.Runtime.Versioning;
using System.Threading;
using Xunit;
using Xunit.Sdk;
using SkipException = Xunit.SkipException;

namespace NVAPIWrapper.FacadeTests
{
    [SupportedOSPlatform("windows")]
    [Collection("ActiveDisplay")]
    [Trait("Category", "Active")]
    public sealed class NVAPIDisplayHelperActiveTests
    {
        private const int SettlingDelayMs = 2000;
        private readonly NVAPITestFixture _fixture;

        public NVAPIDisplayHelperActiveTests(NVAPITestFixture fixture)
        {
            _fixture = fixture;
        }

        [SkippableFact]
        public void InfoFrameControl_SetProperty_ShouldApplyAndRevert_WhenSupported()
        {
            RunActiveDisplayTest(nameof(InfoFrameControl_SetProperty_ShouldApplyAndRevert_WhenSupported), display =>
            {
                var data = NVAPIDisplayHelper.CreateInfoFrameData();
                data.cmd = (byte)NV_INFOFRAME_CMD.NV_INFOFRAME_CMD_GET_PROPERTY;
                data.type = (byte)NV_INFOFRAME_PROPERTY_TYPE.NV_INFOFRAME_PROPERTY_TYPE_UNKNOWN;

                var current = FacadeTestUtils.InvokeOrSkip(
                    () => display.InfoFrameControl(NVAPIInfoFrameDataDto.FromNative(data)),
                    "InfoFrame control unsupported");

                if (current == null)
                    return false;

                var native = current.Value.Data;
                native.cmd = (byte)NV_INFOFRAME_CMD.NV_INFOFRAME_CMD_SET_PROPERTY;
                var setDto = new NVAPIInfoFrameDataDto(native);

                ApplyAndRevert(
                    () =>
                    {
                        if (display.InfoFrameControl(setDto) == null)
                            throw new SkipException("InfoFrame control unsupported.");
                    },
                    () => display.InfoFrameControl(setDto));

                return true;
            });
        }

        [SkippableFact]
        public void ColorControl_Set_ShouldApplyAndRevert_WhenSupported()
        {
            RunActiveDisplayTest(nameof(ColorControl_Set_ShouldApplyAndRevert_WhenSupported), display =>
            {
                var colorData = NVAPIDisplayHelper.CreateColorData();
                colorData.cmd = (byte)NV_COLOR_CMD.NV_COLOR_CMD_GET;

                var current = FacadeTestUtils.InvokeOrSkip(
                    () => display.ColorControl(NVAPIDisplayColorDataDto.FromNative(colorData)),
                    "Color control unsupported");

                if (current == null)
                    return false;

                var native = current.Value.Data;
                native.cmd = (byte)NV_COLOR_CMD.NV_COLOR_CMD_SET;
                var setDto = new NVAPIDisplayColorDataDto(native);

                ApplyAndRevert(
                    () =>
                    {
                        if (display.ColorControl(setDto) == null)
                            throw new SkipException("Color control unsupported.");
                    },
                    () => display.ColorControl(setDto));

                return true;
            });
        }

        [SkippableFact]
        public void HdrColorControl_Set_ShouldApplyAndRevert_WhenSupported()
        {
            RunActiveDisplayTest(nameof(HdrColorControl_Set_ShouldApplyAndRevert_WhenSupported), display =>
            {
                var caps = display.GetHdrCapabilities();
                if (caps == null || !caps.Value.IsHdrSupported)
                    return false;

                var hdrData = NVAPIDisplayHelper.CreateHdrColorData();
                hdrData.cmd = NV_HDR_CMD.NV_HDR_CMD_GET;

                var current = FacadeTestUtils.InvokeOrSkip(
                    () => display.HdrColorControl(NVAPIHdrColorDataDto.FromNative(hdrData)),
                    "HDR color control unsupported");

                if (current == null)
                    return false;

                var native = current.Value.Data;
                native.cmd = NV_HDR_CMD.NV_HDR_CMD_SET;
                var setDto = new NVAPIHdrColorDataDto(native);

                ApplyAndRevert(
                    () =>
                    {
                        if (display.HdrColorControl(setDto) == null)
                            throw new SkipException("HDR color control unsupported.");
                    },
                    () => display.HdrColorControl(setDto));

                return true;
            });
        }

        [SkippableFact]
        public void SetSourceColorSpace_ShouldApplyAndRevert_WhenSupported()
        {
            RunActiveDisplayTest(nameof(SetSourceColorSpace_ShouldApplyAndRevert_WhenSupported), display =>
            {
                var current = FacadeTestUtils.InvokeOrSkip(
                    () => display.GetSourceColorSpace(),
                    "Source color space unsupported");

                if (current == null)
                    return false;

                ApplyAndRevert(
                    () =>
                    {
                        if (!display.SetSourceColorSpace(current.Value))
                            throw new SkipException("Source color space unsupported.");
                    },
                    () => display.SetSourceColorSpace(current.Value));

                return true;
            });
        }

        [SkippableFact]
        public void SetSourceHdrMetadata_ShouldApplyAndRevert_WhenSupported()
        {
            RunActiveDisplayTest(nameof(SetSourceHdrMetadata_ShouldApplyAndRevert_WhenSupported), display =>
            {
                var caps = display.GetHdrCapabilities();
                if (caps == null || !caps.Value.IsHdrSupported)
                    return false;

                var current = FacadeTestUtils.InvokeOrSkip(
                    () => display.GetSourceHdrMetadata(),
                    "Source HDR metadata unsupported");

                if (current == null)
                    return false;

                ApplyAndRevert(
                    () =>
                    {
                        if (!display.SetSourceHdrMetadata(current.Value))
                            throw new SkipException("Source HDR metadata unsupported.");
                    },
                    () => display.SetSourceHdrMetadata(current.Value));

                return true;
            });
        }

        [SkippableFact]
        public void SetOutputMode_ShouldApplyAndRevert_WhenSupported()
        {
            RunActiveDisplayTest(nameof(SetOutputMode_ShouldApplyAndRevert_WhenSupported), display =>
            {
                var current = FacadeTestUtils.InvokeOrSkip(
                    () => display.GetOutputMode(),
                    "Output mode unsupported");

                if (current == null)
                    return false;

                ApplyAndRevert(
                    () =>
                    {
                        if (!display.SetOutputMode(current.Value))
                            throw new SkipException("Output mode unsupported.");
                    },
                    () => display.SetOutputMode(current.Value));

                return true;
            });
        }

        [SkippableFact]
        public void SetHdrToneMapping_ShouldApplyAndRevert_WhenSupported()
        {
            RunActiveDisplayTest(nameof(SetHdrToneMapping_ShouldApplyAndRevert_WhenSupported), display =>
            {
                var caps = display.GetHdrCapabilities();
                if (caps == null || !caps.Value.IsHdrSupported)
                    return false;

                var current = FacadeTestUtils.InvokeOrSkip(
                    () => display.GetHdrToneMapping(),
                    "HDR tone mapping unsupported");

                if (current == null)
                    return false;

                ApplyAndRevert(
                    () =>
                    {
                        if (!display.SetHdrToneMapping(current.Value))
                            throw new SkipException("HDR tone mapping unsupported.");
                    },
                    () => display.SetHdrToneMapping(current.Value));

                return true;
            });
        }

        [SkippableFact]
        public void TryCustomDisplay_ShouldApplyAndRevert_WhenSupported()
        {
            RunActiveDisplayTest(nameof(TryCustomDisplay_ShouldApplyAndRevert_WhenSupported), display =>
            {
                var displayId = display.GetDisplayIdByDisplayName();
                if (displayId == null)
                    return false;

                var custom = display.EnumCustomDisplay(0, displayId);
                if (custom == null)
                    return false;

                var displayIds = new[] { displayId.Value };
                var customs = new[] { custom.Value };

                ApplyAndRevert(
                    () =>
                    {
                        if (!display.TryCustomDisplay(displayIds, customs))
                            throw new SkipException("Try custom display unsupported.");
                    },
                    () => display.RevertCustomDisplayTrial(displayIds));

                return true;
            });
        }

        [SkippableFact]
        public void SaveCustomDisplay_ShouldApplyAndDelete_WhenSupported()
        {
            RunActiveDisplayTest(nameof(SaveCustomDisplay_ShouldApplyAndDelete_WhenSupported), display =>
            {
                var displayId = display.GetDisplayIdByDisplayName();
                if (displayId == null)
                    return false;

                var custom = display.EnumCustomDisplay(0, displayId);
                if (custom == null)
                    return false;

                var displayIds = new[] { displayId.Value };
                var customs = new[] { custom.Value };

                ApplyAndRevert(
                    () =>
                    {
                        if (!display.TryCustomDisplay(displayIds, customs))
                            throw new SkipException("Try custom display unsupported.");

                        if (!display.SaveCustomDisplay(displayIds, false, false))
                        {
                            display.RevertCustomDisplayTrial(displayIds);
                            throw new SkipException("Save custom display unsupported.");
                        }
                    },
                    () =>
                    {
                        display.DeleteCustomDisplay(displayIds, customs);
                        display.RevertCustomDisplayTrial(displayIds);
                    });

                return true;
            });
        }

        [SkippableFact]
        public void SetNvManagedDedicatedDisplayMetadata_ShouldApplyAndRevert_WhenSupported()
        {
            RunActiveDisplayTest(nameof(SetNvManagedDedicatedDisplayMetadata_ShouldApplyAndRevert_WhenSupported), display =>
            {
                var displayId = display.GetDisplayIdByDisplayName();
                if (displayId == null)
                    return false;

                var current = FacadeTestUtils.InvokeOrSkip(
                    () => display.GetNvManagedDedicatedDisplayMetadata(displayId.Value),
                    "Managed dedicated display metadata unsupported");

                if (current == null)
                    return false;

                var canSetPosition = current.Value.PositionIsAvailable;
                var canSetName = current.Value.NameIsAvailable;
                if (!canSetPosition && !canSetName)
                    return false;

                var update = new NVAPINvManagedDedicatedDisplayMetadataDto(
                    current.Value.DisplayId,
                    canSetPosition,
                    false,
                    current.Value.PositionIsAvailable,
                    canSetName,
                    false,
                    current.Value.NameIsAvailable,
                    current.Value.Reserved,
                    current.Value.PositionX,
                    current.Value.PositionY,
                    current.Value.Name);

                ApplyAndRevert(
                    () =>
                    {
                        if (!display.SetNvManagedDedicatedDisplayMetadata(update))
                            throw new SkipException("Managed dedicated display metadata unsupported.");
                    },
                    () => display.SetNvManagedDedicatedDisplayMetadata(update));

                return true;
            });
        }

        [SkippableFact]
        public void AcquireDedicatedDisplay_ShouldAcquireAndRelease_WhenSupported()
        {
            RunActiveDisplayTest(nameof(AcquireDedicatedDisplay_ShouldAcquireAndRelease_WhenSupported), display =>
            {
                var displayId = display.GetDisplayIdByDisplayName();
                if (displayId == null)
                    return false;

                ApplyAndRevert(
                    () =>
                    {
                        var handle = display.AcquireDedicatedDisplay(displayId.Value);
                        if (handle == null)
                            throw new SkipException("Acquire dedicated display unsupported.");
                    },
                    () =>
                    {
                        if (!display.ReleaseDedicatedDisplay(displayId.Value))
                            throw new InvalidOperationException("Release dedicated display failed.");
                    });

                return true;
            });
        }

        private void RunActiveDisplayTest(string testName, Func<NVAPIDisplayHelper, bool> action)
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper!.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var failures = new List<string>();
            var displayCount = 0;
            var executedDisplays = 0;

            for (var gpuIndex = 0; gpuIndex < gpus.Length; gpuIndex++)
            {
                var gpu = gpus[gpuIndex];
                var gpuLabel = SafeGpuLabel(gpu, gpuIndex);
                NVAPIDisplayHelper[] displays;

                try
                {
                    displays = gpu.EnumerateNvidiaDisplayHandles();
                }
                catch (Exception ex)
                {
                    failures.Add($"{gpuLabel}: EnumerateNvidiaDisplayHandles failed: {ex.Message}");
                    continue;
                }

                for (var displayIndex = 0; displayIndex < displays.Length; displayIndex++)
                {
                    var display = displays[displayIndex];
                    displayCount++;
                    var displayLabel = SafeDisplayLabel(display, displayIndex);

                    try
                    {
                        if (action(display))
                            executedDisplays++;
                    }
                    catch (SkipException)
                    {
                        // Unsupported on this display.
                    }
                    catch (NVAPIException ex) when (IsUnsupportedResult(ex.Status))
                    {
                        // Unsupported on this display.
                    }
                    catch (EntryPointNotFoundException)
                    {
                        // Unsupported on this system.
                    }
                    catch (Exception ex)
                    {
                        failures.Add($"{gpuLabel}/{displayLabel}: {ex.GetType().Name} {ex.Message}");
                    }
                }
            }

            if (displayCount == 0)
                throw new SkipException("No displays returned from NVAPI.");

            if (executedDisplays == 0)
                throw new SkipException($"{testName} unsupported on displays.");

            if (failures.Count > 0)
                throw new XunitException($"{testName} failures:{Environment.NewLine}{string.Join(Environment.NewLine, failures)}");
        }

        private static string SafeGpuLabel(NVAPIPhysicalGpuHelper gpu, int index)
        {
            try
            {
                var name = gpu.GetFullName();
                if (!string.IsNullOrWhiteSpace(name))
                    return name;
            }
            catch
            {
                // Ignore failures.
            }

            return $"GPU-{index}";
        }

        private static string SafeDisplayLabel(NVAPIDisplayHelper display, int index)
        {
            try
            {
                var name = display.GetAssociatedNvidiaDisplayName();
                if (!string.IsNullOrWhiteSpace(name))
                    return name;
            }
            catch
            {
                // Ignore failures.
            }

            return $"Display-{index}";
        }

        private static void ApplyAndRevert(Action apply, Action revert)
        {
            var applied = false;
            try
            {
                apply();
                applied = true;
                Thread.Sleep(500);
                WaitForSettle();
            }
            finally
            {
                if (applied)
                {
                    revert();
                    WaitForSettle();
                }
            }
        }

        private static void WaitForSettle()
        {
            Thread.Sleep(SettlingDelayMs);
        }

        private static bool IsUnsupportedResult(_NvAPI_Status status)
        {
            return status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND
                || status == _NvAPI_Status.NVAPI_INVALID_DISPLAY_ID
                || status == _NvAPI_Status.NVAPI_INVALID_ARGUMENT
                || status == _NvAPI_Status.NVAPI_INVALID_USER_PRIVILEGE
                || status == _NvAPI_Status.NVAPI_RESOURCE_NOT_ACQUIRED
                || status == _NvAPI_Status.NVAPI_UNREGISTERED_RESOURCE
                || status == _NvAPI_Status.NVAPI_RESOURCE_IN_USE;
        }
    }
}
