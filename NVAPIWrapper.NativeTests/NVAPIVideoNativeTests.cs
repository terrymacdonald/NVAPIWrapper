using System;
using System.Linq;
using System.Runtime.Versioning;
using Xunit;

namespace NVAPIWrapper.NativeTests
{
    /// <summary>
    /// Native video API tests (VIO + Stereo globals).
    /// </summary>
    [SupportedOSPlatform("windows")]
    public class NVAPIVideoNativeTests : IDisposable
    {
        #pragma warning disable CS0618

        private readonly NVAPIApi? _api;
        private readonly string _skipReason = string.Empty;

        public NVAPIVideoNativeTests()
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
        public unsafe void VioEnumDevices_ShouldReturnHandles()
        {
            SkipIfUnavailable("NvAPI_VIO_EnumDevices");

            var handles = stackalloc NvVioHandle__*[NVAPI.NVAPI_MAX_VIO_DEVICES];
            uint count = 0;
            var status = NVAPI.NvAPI_VIO_EnumDevices(handles, &count);
            if (IsUnsupported(status))
            {
                Skip.If(true, $"VIO devices unsupported: {status}");
                return;
            }

            Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            Assert.InRange(count, 0u, (uint)NVAPI.NVAPI_MAX_VIO_DEVICES);
        }

        [SkippableFact]
        public unsafe void VioQueryTopology_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_VIO_QueryTopology");

            var topology = new _NV_VIO_TOPOLOGY { version = NVAPI.NV_VIO_TOPOLOGY_VER };
            var status = NVAPI.NvAPI_VIO_QueryTopology(&topology);
            if (IsUnsupported(status))
            {
                Skip.If(true, $"VIO topology unsupported: {status}");
                return;
            }

            Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
        }

        [SkippableFact]
        public unsafe void VioGetCapabilities_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_VIO_GetCapabilities");

            WithVioDevice(handle =>
            {
                var caps = new _NVVIOCAPS { version = NVAPI.NVVIOCAPS_VER };
                var status = NVAPI.NvAPI_VIO_GetCapabilities(handle, &caps);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"VIO capabilities unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void VioGetStatus_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_VIO_Status");

            WithVioDevice(handle =>
            {
                var statusInfo = new _NVVIOSTATUS { version = NVAPI.NVVIOSTATUS_VER };
                var status = NVAPI.NvAPI_VIO_Status(handle, &statusInfo);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"VIO status unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void VioGetConfig_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_VIO_GetConfig");

            WithVioDevice(handle =>
            {
                var config = new _NVVIOCONFIG_V3 { version = NVAPI.NVVIOCONFIG_VER };
                var status = NVAPI.NvAPI_VIO_GetConfig(handle, &config);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"VIO config unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void VioGetPciInfo_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_VIO_GetPCIInfo");

            WithVioDevice(handle =>
            {
                var info = new _NVVIOPCIINFO { version = NVAPI.NVVIOPCIINFO_VER };
                var status = NVAPI.NvAPI_VIO_GetPCIInfo(handle, &info);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"VIO PCI info unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void VioEnumSignalFormats_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_VIO_EnumSignalFormats");

            WithVioDevice(handle =>
            {
                var detail = new _NVVIOSIGNALFORMATDETAIL();
                var status = NVAPI.NvAPI_VIO_EnumSignalFormats(handle, 0, &detail);
                if (status == _NvAPI_Status.NVAPI_END_ENUMERATION)
                {
                    Skip.If(true, "No VIO signal formats available.");
                    return;
                }

                if (IsUnsupported(status))
                {
                    Skip.If(true, $"VIO signal formats unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void VioEnumDataFormats_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_VIO_EnumDataFormats");

            WithVioDevice(handle =>
            {
                var detail = new _NVVIODATAFORMATDETAIL();
                var status = NVAPI.NvAPI_VIO_EnumDataFormats(handle, 0, &detail);
                if (status == _NvAPI_Status.NVAPI_END_ENUMERATION)
                {
                    Skip.If(true, "No VIO data formats available.");
                    return;
                }

                if (IsUnsupported(status))
                {
                    Skip.If(true, $"VIO data formats unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
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

        private unsafe void WithVioDevice(VioDeviceAction action)
        {
            SkipIfUnavailable("NvAPI_VIO_EnumDevices");

            var handles = stackalloc NvVioHandle__*[NVAPI.NVAPI_MAX_VIO_DEVICES];
            uint count = 0;
            var status = NVAPI.NvAPI_VIO_EnumDevices(handles, &count);
            if (IsUnsupported(status))
            {
                Skip.If(true, $"VIO devices not available: {status}");
                return;
            }

            Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            Skip.If(count == 0, "No VIO devices found.");

            action(handles[0]);
        }

        private unsafe delegate void VioDeviceAction(NvVioHandle__* handle);

        private static bool IsUnsupported(_NvAPI_Status status)
        {
            return status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND;
        }

        #pragma warning restore CS0618
    }
}
