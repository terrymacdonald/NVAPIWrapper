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
    [Collection("ActiveCombined")]
    [Trait("Category", "Active")]
    public sealed class NVAPIPhysicalGpuHelperActiveTests
    {
        private const int SettlingDelayMs = 2000;
        private readonly NVAPITestFixture _fixture;

        public NVAPIPhysicalGpuHelperActiveTests(NVAPITestFixture fixture)
        {
            _fixture = fixture;
        }

        [SkippableFact]
        public void SetEccConfiguration_ShouldApplyAndRevert_WhenSupported()
        {
            RunActiveGpuTest(nameof(SetEccConfiguration_ShouldApplyAndRevert_WhenSupported), gpu =>
            {
                var current = FacadeTestUtils.InvokeOrSkip(() => gpu.GetEccConfigurationInfo(), "ECC configuration unsupported");
                if (current == null)
                    return false;

                var enable = current.Value.IsEnabled;
                ApplyAndRevert(
                    () =>
                    {
                        if (!gpu.SetEccConfiguration(enable, true))
                            throw new SkipException("ECC configuration unsupported.");
                    },
                    () => gpu.SetEccConfiguration(enable, true));

                return true;
            });
        }

        [SkippableFact]
        public void SetEdid_ShouldApply_WhenSupported()
        {
            RunActiveGpuTest(nameof(SetEdid_ShouldApply_WhenSupported), gpu =>
            {
                if (!TryGetOutputId(gpu, out var outputId))
                    return false;

                var current = FacadeTestUtils.InvokeOrSkip(() => gpu.GetEdid(outputId), "EDID unsupported");
                if (current == null)
                    return false;

                ApplyAndRevert(
                    () =>
                    {
                        if (!gpu.SetEdid(outputId, current.Value))
                            throw new SkipException("EDID unsupported.");
                    },
                    () => gpu.SetEdid(outputId, current.Value));

                return true;
            });
        }

        [SkippableFact]
        public void SetScanoutCompositionParameter_ShouldApplyAndRevert_WhenSupported()
        {
            RunActiveGpuTest(nameof(SetScanoutCompositionParameter_ShouldApplyAndRevert_WhenSupported), gpu =>
            {
                if (!TryGetDisplayId(gpu, out var displayId))
                    return false;

                var parameter = NV_GPU_SCANOUT_COMPOSITION_PARAMETER.NV_GPU_SCANOUT_COMPOSITION_PARAMETER_WARPING_RESAMPLING_METHOD;
                var current = FacadeTestUtils.InvokeOrSkip(
                    () => gpu.GetScanoutCompositionParameter(displayId, parameter),
                    "Scanout composition parameter unsupported");
                if (current == null)
                    return false;

                ApplyAndRevert(
                    () =>
                    {
                        if (!gpu.SetScanoutCompositionParameter(displayId, current.Value))
                            throw new SkipException("Scanout composition parameter unsupported.");
                    },
                    () => gpu.SetScanoutCompositionParameter(displayId, current.Value));

                return true;
            });
        }

        [SkippableFact]
        public void SetScanoutIntensity_ShouldSkip_WhenNoSafeCurrentData()
        {
            RunActiveGpuTest(nameof(SetScanoutIntensity_ShouldSkip_WhenNoSafeCurrentData), gpu =>
            {
                if (!TryGetDisplayId(gpu, out var displayId))
                    return false;

                var state = FacadeTestUtils.InvokeOrSkip(
                    () => gpu.GetScanoutIntensityState(displayId),
                    "Scanout intensity state unsupported");
                if (state == null)
                    return false;

                throw new SkipException("No safe set-to-current intensity data available.");
            });
        }

        [SkippableFact]
        public void SetScanoutWarping_ShouldSkip_WhenNoSafeCurrentData()
        {
            RunActiveGpuTest(nameof(SetScanoutWarping_ShouldSkip_WhenNoSafeCurrentData), gpu =>
            {
                if (!TryGetDisplayId(gpu, out var displayId))
                    return false;

                var state = FacadeTestUtils.InvokeOrSkip(
                    () => gpu.GetScanoutWarpingState(displayId),
                    "Scanout warping state unsupported");
                if (state == null)
                    return false;

                throw new SkipException("No safe set-to-current warping data available.");
            });
        }

        [SkippableFact]
        public void WorkstationFeatureSetup_ShouldApply_WhenSupported()
        {
            RunActiveGpuTest(nameof(WorkstationFeatureSetup_ShouldApply_WhenSupported), gpu =>
            {
                var current = FacadeTestUtils.InvokeOrSkip(() => gpu.WorkstationFeatureQuery(), "Workstation feature query unsupported");
                if (current == null)
                    return false;

                ApplyAndRevert(
                    () =>
                    {
                        if (!gpu.WorkstationFeatureSetup(current.Value.ConfiguredFeatureMask, 0))
                            throw new SkipException("Workstation feature setup unsupported.");
                    },
                    () => gpu.WorkstationFeatureSetup(current.Value.ConfiguredFeatureMask, 0));

                return true;
            });
        }

        private void RunActiveGpuTest(string testName, Func<NVAPIPhysicalGpuHelper, bool> action)
        {
            Skip.If(_fixture.ApiHelper == null, _fixture.SkipReason);

            var gpus = _fixture.ApiHelper!.EnumeratePhysicalGpus();
            Skip.If(gpus.Length == 0, "No NVIDIA physical GPUs found.");

            var failures = new List<string>();
            var executedGpus = 0;

            for (var gpuIndex = 0; gpuIndex < gpus.Length; gpuIndex++)
            {
                var gpu = gpus[gpuIndex];
                var gpuLabel = SafeGpuLabel(gpu, gpuIndex);

                try
                {
                    if (action(gpu))
                        executedGpus++;
                }
                catch (SkipException)
                {
                    // Unsupported on this GPU.
                }
                catch (NVAPIException ex) when (IsUnsupportedResult(ex.Status))
                {
                    // Unsupported on this GPU.
                }
                catch (EntryPointNotFoundException)
                {
                    // Unsupported on this system.
                }
                catch (Exception ex)
                {
                    failures.Add($"{gpuLabel}: {ex.GetType().Name} {ex.Message}");
                }
            }

            if (executedGpus == 0)
                throw new SkipException($"{testName} unsupported on GPUs.");

            if (failures.Count > 0)
                throw new XunitException($"{testName} failures:{Environment.NewLine}{string.Join(Environment.NewLine, failures)}");
        }

        private static bool TryGetDisplayId(NVAPIPhysicalGpuHelper gpu, out uint displayId)
        {
            displayId = 0;
            try
            {
                var displays = gpu.EnumAllDisplays();
                if (displays.Length == 0)
                    return false;

                var id = displays[0].GetDisplayIdByDisplayName();
                if (id == null)
                    return false;

                displayId = id.Value;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool TryGetOutputId(NVAPIPhysicalGpuHelper gpu, out uint outputId)
        {
            outputId = 0;
            try
            {
                var displays = gpu.EnumAllDisplays();
                if (displays.Length == 0)
                    return false;

                var id = displays[0].GetAssociatedDisplayOutputId();
                if (id == null || id.Value == 0)
                    return false;

                outputId = id.Value;
                return true;
            }
            catch
            {
                return false;
            }
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
                || status == _NvAPI_Status.NVAPI_INVALID_ARGUMENT
                || status == _NvAPI_Status.NVAPI_INVALID_USER_PRIVILEGE;
        }
    }
}
