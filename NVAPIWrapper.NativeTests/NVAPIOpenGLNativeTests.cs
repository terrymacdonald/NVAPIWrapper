using System;
using System.Linq;
using System.Runtime.Versioning;
using Xunit;

namespace NVAPIWrapper.NativeTests
{
    /// <summary>
    /// Native OpenGL API tests.
    /// </summary>
    [SupportedOSPlatform("windows")]
    public class NVAPIOpenGLNativeTests : IDisposable
    {
        private readonly NVAPIApi? _api;
        private readonly string _skipReason = string.Empty;

        public NVAPIOpenGLNativeTests()
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
        public unsafe void OglExpertModeGet_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_OGL_ExpertModeGet");

            uint detail = 0;
            uint report = 0;
            uint output = 0;
            delegate* unmanaged[Cdecl]<uint, uint, uint, int, sbyte*, void> callback = null;

            var status = NVAPI.NvAPI_OGL_ExpertModeGet(&detail, &report, &output, &callback);
            if (IsUnsupported(status))
            {
                Skip.If(true, $"OpenGL expert mode get unsupported: {status}");
                return;
            }

            if (status == _NvAPI_Status.NVAPI_ERROR || status == _NvAPI_Status.NVAPI_API_NOT_INITIALIZED)
            {
                Skip.If(true, $"OpenGL expert mode get not available: {status}");
                return;
            }

            Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
        }

        [SkippableFact]
        public unsafe void OglExpertModeDefaultsGet_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_OGL_ExpertModeDefaultsGet");

            uint detail = 0;
            uint report = 0;
            uint output = 0;
            var status = NVAPI.NvAPI_OGL_ExpertModeDefaultsGet(&detail, &report, &output);
            if (IsUnsupported(status))
            {
                Skip.If(true, $"OpenGL expert defaults get unsupported: {status}");
                return;
            }

            if (status == _NvAPI_Status.NVAPI_ERROR || status == _NvAPI_Status.NVAPI_API_NOT_INITIALIZED)
            {
                Skip.If(true, $"OpenGL expert defaults get not available: {status}");
                return;
            }

            Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
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

        private static bool IsUnsupported(_NvAPI_Status status)
        {
            return status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND
                || status == _NvAPI_Status.NVAPI_OPENGL_CONTEXT_NOT_CURRENT;
        }
    }
}
