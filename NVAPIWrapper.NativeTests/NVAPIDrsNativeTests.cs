using System;
using System.Linq;
using System.Runtime.Versioning;
using Xunit;

namespace NVAPIWrapper.NativeTests
{
    /// <summary>
    /// Native DRS (Driver Settings) API tests.
    /// </summary>
    [SupportedOSPlatform("windows")]
    public class NVAPIDrsNativeTests : IDisposable
    {
        private readonly NVAPIApi? _api;
        private readonly string _skipReason = string.Empty;

        public NVAPIDrsNativeTests()
        {
            if (!NVAPIApi.IsNVAPIDllAvailable(out var dllError))
            {
                _skipReason = dllError;
                return;
            }

            try
            {
                _api = NVAPIApi.Initialize();
            }
            catch (NVAPIException ex)
            {
                _skipReason = $"NVAPI initialization failed: {ex.Message}";
            }
            catch (Exception ex)
            {
                _skipReason = $"NVAPI initialization failed: {ex.Message}";
            }
        }

        [SkippableFact]
        public unsafe void DrsCreateSession_ShouldSucceed()
        {
            SkipIfUnavailable("NvAPI_DRS_CreateSession");
            SkipIfUnavailable("NvAPI_DRS_DestroySession");

            NvDRSSessionHandle__* session;
            var status = NVAPI.NvAPI_DRS_CreateSession(&session);

            if (IsUnsupported(status))
            {
                Skip.If(true, $"DRS not supported: {status}");
                return;
            }

            Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            var destroyStatus = NVAPI.NvAPI_DRS_DestroySession(session);
            Assert.Equal(_NvAPI_Status.NVAPI_OK, destroyStatus);
        }

        [SkippableFact]
        public unsafe void DrsLoadSettings_ShouldSucceed()
        {
            SkipIfUnavailable("NvAPI_DRS_LoadSettings");
            WithSession(session =>
            {
                var status = NVAPI.NvAPI_DRS_LoadSettings(session);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"DRS not supported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void DrsGetNumProfiles_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_DRS_GetNumProfiles");
            WithSession(session =>
            {
                uint count = 0;
                var status = NVAPI.NvAPI_DRS_GetNumProfiles(session, &count);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"DRS not supported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
                Assert.True(count >= 0);
            });
        }

        [SkippableFact]
        public unsafe void DrsEnumProfiles_ShouldReturnProfileInfo()
        {
            SkipIfUnavailable("NvAPI_DRS_EnumProfiles");
            SkipIfUnavailable("NvAPI_DRS_GetProfileInfo");

            WithSession(session =>
            {
                NvDRSProfileHandle__* handle;
                var status = NVAPI.NvAPI_DRS_EnumProfiles(session, 0, &handle);
                if (status == _NvAPI_Status.NVAPI_END_ENUMERATION)
                    return;

                if (IsUnsupported(status))
                {
                    Skip.If(true, $"DRS not supported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);

                var profileInfo = new _NVDRS_PROFILE_V1 { version = NVAPI.NVDRS_PROFILE_VER };
                status = NVAPI.NvAPI_DRS_GetProfileInfo(session, handle, &profileInfo);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"DRS not supported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void DrsGetCurrentGlobalProfile_ShouldReturnHandle()
        {
            SkipIfUnavailable("NvAPI_DRS_GetCurrentGlobalProfile");

            WithSession(session =>
            {
                NvDRSProfileHandle__* handle;
                var status = NVAPI.NvAPI_DRS_GetCurrentGlobalProfile(session, &handle);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"DRS not supported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
                Assert.True(handle != null);
            });
        }

        public void Dispose()
        {
            _api?.Dispose();
        }

        private void SkipIfUnavailable(string functionName)
        {
            Skip.If(_api == null, _skipReason);

            var functions = _api.GetAvailableFunctions();
            var available = functions.Any(entry => entry.Name == functionName && entry.IsAvailable);
            Skip.If(!available, $"NVAPI function '{functionName}' not available.");
        }

        private unsafe void WithSession(DrsSessionAction action)
        {
            SkipIfUnavailable("NvAPI_DRS_CreateSession");
            SkipIfUnavailable("NvAPI_DRS_DestroySession");

            NvDRSSessionHandle__* session;
            var status = NVAPI.NvAPI_DRS_CreateSession(&session);

            if (IsUnsupported(status))
            {
                Skip.If(true, $"DRS not supported: {status}");
                return;
            }

            Assert.Equal(_NvAPI_Status.NVAPI_OK, status);

            try
            {
                action(session);
            }
            finally
            {
                NVAPI.NvAPI_DRS_DestroySession(session);
            }
        }

        private unsafe delegate void DrsSessionAction(NvDRSSessionHandle__* session);

        private static bool IsUnsupported(_NvAPI_Status status)
        {
            return status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND;
        }
    }
}
