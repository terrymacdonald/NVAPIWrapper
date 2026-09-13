using System;
using System.Runtime.Versioning;
using Xunit;

namespace NVAPIWrapper.FacadeTests
{
    /// <summary>
    /// Utility methods for facade tests that convert unsupported NVAPI operations into xUnit skips.
    /// </summary>
    [SupportedOSPlatform("windows")]
    internal static class FacadeTestUtils
    {
        /// <summary>
        /// Invoke a function and skip the current test if the NVAPI call is unsupported.
        /// </summary>
        /// <typeparam name="T">Return type.</typeparam>
        /// <param name="func">Function to invoke.</param>
        /// <param name="reason">Human-readable skip reason prefix.</param>
        /// <returns>The function result.</returns>
        internal static T InvokeOrSkip<T>(Func<T> func, string reason)
        {
            try
            {
                return func();
            }
            catch (NVAPIException ex) when (IsUnsupported(ex.Status))
            {
                throw new SkipException($"{reason}: {ex.Status}");
            }
            catch (EntryPointNotFoundException ex)
            {
                throw new SkipException($"{reason}: {ex.Message}");
            }
        }

        /// <summary>
        /// Invoke an action and skip the current test if the NVAPI call is unsupported.
        /// </summary>
        /// <param name="action">Action to invoke.</param>
        /// <param name="reason">Human-readable skip reason prefix.</param>
        internal static void InvokeOrSkip(Action action, string reason)
        {
            try
            {
                action();
            }
            catch (NVAPIException ex) when (IsUnsupported(ex.Status))
            {
                throw new SkipException($"{reason}: {ex.Status}");
            }
            catch (EntryPointNotFoundException ex)
            {
                throw new SkipException($"{reason}: {ex.Message}");
            }
        }

        /// <summary>
        /// Invoke a display discovery or display configuration bootstrap function and skip the current test if the local driver cannot expose display topology information.
        /// </summary>
        /// <typeparam name="T">Return type.</typeparam>
        /// <param name="func">Function to invoke.</param>
        /// <param name="reason">Human-readable skip reason prefix.</param>
        /// <returns>The function result.</returns>
        /// <remarks>
        /// This helper intentionally treats <see cref="_NvAPI_Status.NVAPI_ERROR"/> as skippable only for display discovery/configuration bootstrap calls such as <c>EnumAllDisplays()</c> and <c>GetDisplayConfig()</c>.
        /// Do not use this helper for ordinary feature calls, because <see cref="_NvAPI_Status.NVAPI_ERROR"/> from those calls may indicate a real wrapper bug.
        /// </remarks>
        internal static T InvokeOrSkipDisplayDiscoveryUnavailable<T>(Func<T> func, string reason)
        {
            try
            {
                return func();
            }
            catch (NVAPIException ex) when (IsDisplayDiscoveryUnavailable(ex.Status))
            {
                throw new SkipException($"{reason}: {ex.Status}");
            }
            catch (EntryPointNotFoundException ex)
            {
                throw new SkipException($"{reason}: {ex.Message}");
            }
        }

        /// <summary>
        /// Invoke a display discovery or display configuration bootstrap action and skip the current test if the local driver cannot expose display topology information.
        /// </summary>
        /// <param name="action">Action to invoke.</param>
        /// <param name="reason">Human-readable skip reason prefix.</param>
        /// <remarks>
        /// This helper intentionally treats <see cref="_NvAPI_Status.NVAPI_ERROR"/> as skippable only for display discovery/configuration bootstrap calls.
        /// Do not use this helper for ordinary feature calls, because <see cref="_NvAPI_Status.NVAPI_ERROR"/> from those calls may indicate a real wrapper bug.
        /// </remarks>
        internal static void InvokeOrSkipDisplayDiscoveryUnavailable(Action action, string reason)
        {
            try
            {
                action();
            }
            catch (NVAPIException ex) when (IsDisplayDiscoveryUnavailable(ex.Status))
            {
                throw new SkipException($"{reason}: {ex.Status}");
            }
            catch (EntryPointNotFoundException ex)
            {
                throw new SkipException($"{reason}: {ex.Message}");
            }
        }

        /// <summary>
        /// Invoke a display discovery or display configuration bootstrap function and skip the current test if display information is unavailable.
        /// </summary>
        /// <typeparam name="T">Return type.</typeparam>
        /// <param name="func">Function to invoke.</param>
        /// <param name="reason">Human-readable skip reason prefix.</param>
        /// <returns>The function result.</returns>
        internal static T InvokeOrSkipDisplayUnavailable<T>(Func<T> func, string reason)
        {
            return InvokeOrSkipDisplayDiscoveryUnavailable(func, reason);
        }

        /// <summary>
        /// Invoke a display discovery or display configuration bootstrap action and skip the current test if display information is unavailable.
        /// </summary>
        /// <param name="action">Action to invoke.</param>
        /// <param name="reason">Human-readable skip reason prefix.</param>
        internal static void InvokeOrSkipDisplayUnavailable(Action action, string reason)
        {
            InvokeOrSkipDisplayDiscoveryUnavailable(action, reason);
        }

        /// <summary>
        /// Determine whether an NVAPI status means the operation is unsupported.
        /// </summary>
        /// <param name="status">NVAPI status value.</param>
        /// <returns>True if the status should skip a general unsupported-operation test.</returns>
        private static bool IsUnsupported(_NvAPI_Status status)
        {
            return status == _NvAPI_Status.NVAPI_NOT_SUPPORTED ||
                   status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION;
        }

        /// <summary>
        /// Determine whether an NVAPI status means display discovery/configuration cannot be queried on this machine or driver.
        /// </summary>
        /// <param name="status">NVAPI status value.</param>
        /// <returns>True if a display discovery/configuration bootstrap test should be skipped.</returns>
        private static bool IsDisplayDiscoveryUnavailable(_NvAPI_Status status)
        {
            return IsUnsupported(status) ||
                   status == _NvAPI_Status.NVAPI_ERROR ||
                   status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND;
        }
    }
}
