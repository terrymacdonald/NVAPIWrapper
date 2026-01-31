using System;
using System.Runtime.Versioning;
using Xunit;

namespace NVAPIWrapper.FacadeTests
{
    [SupportedOSPlatform("windows")]
    internal static class FacadeTestUtils
    {
        internal static T InvokeOrSkip<T>(Func<T> func, string reason)
        {
            try
            {
                return func();
            }
            catch (NVAPIException ex) when (IsUnsupported(ex.Status))
            {
                throw new Xunit.SkipException($"{reason}: {ex.Status}");
            }
            catch (EntryPointNotFoundException ex)
            {
                throw new Xunit.SkipException($"{reason}: {ex.Message}");
            }
        }

        internal static void InvokeOrSkip(Action action, string reason)
        {
            try
            {
                action();
            }
            catch (NVAPIException ex) when (IsUnsupported(ex.Status))
            {
                throw new Xunit.SkipException($"{reason}: {ex.Status}");
            }
            catch (EntryPointNotFoundException ex)
            {
                throw new Xunit.SkipException($"{reason}: {ex.Message}");
            }
        }

        private static bool IsUnsupported(_NvAPI_Status status)
        {
            return status == _NvAPI_Status.NVAPI_NOT_SUPPORTED ||
                   status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION;
        }
    }
}
