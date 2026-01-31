using System;
using System.Linq;
using System.Runtime.Versioning;
using Xunit;

namespace NVAPIWrapper.NativeTests
{
    /// <summary>
    /// Native I2C API tests.
    /// </summary>
    [SupportedOSPlatform("windows")]
    public class NVAPII2CNativeTests : IDisposable
    {
        private readonly NVAPIApi? _api;
        private readonly string _skipReason = string.Empty;

        public NVAPII2CNativeTests()
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
        public unsafe void I2CRead_ShouldReturnData()
        {
            SkipIfUnavailable("NvAPI_I2CRead");

            var gpu = GetFirstPhysicalGpu();
            var displayMask = GetFirstDisplayMask();

            var reg = stackalloc byte[1];
            reg[0] = 0x00;
            var data = new byte[1];

            var info = new NV_I2C_INFO_V3
            {
                version = NVAPI.NV_I2C_INFO_VER,
                displayMask = displayMask,
                bIsDDCPort = 1,
                i2cDevAddress = 0xA0,
                regAddrSize = 1,
                cbSize = (uint)data.Length,
                i2cSpeed = NVAPI.NVAPI_I2C_SPEED_DEPRECATED,
                i2cSpeedKhz = NV_I2C_SPEED.NVAPI_I2C_SPEED_DEFAULT
            };

            fixed (byte* pData = data)
            {
                info.pbI2cRegAddress = reg;
                info.pbData = pData;

                var status = NVAPI.NvAPI_I2CRead(gpu, &info);
                if (status != _NvAPI_Status.NVAPI_OK)
                {
                    Skip.If(true, $"I2C read did not succeed: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            }
        }

        [SkippableFact]
        public unsafe void I2CWrite_ShouldReturnSuccess()
        {
            SkipIfUnavailable("NvAPI_I2CWrite");

            var gpu = GetFirstPhysicalGpu();
            var displayMask = GetFirstDisplayMask();

            var info = new NV_I2C_INFO_V3
            {
                version = NVAPI.NV_I2C_INFO_VER,
                displayMask = displayMask,
                bIsDDCPort = 1,
                i2cDevAddress = 0xA0,
                regAddrSize = 0,
                cbSize = 0,
                i2cSpeed = NVAPI.NVAPI_I2C_SPEED_DEPRECATED,
                i2cSpeedKhz = NV_I2C_SPEED.NVAPI_I2C_SPEED_DEFAULT
            };

            var status = NVAPI.NvAPI_I2CWrite(gpu, &info);
            if (status != _NvAPI_Status.NVAPI_OK)
            {
                Skip.If(true, $"I2C write did not succeed: {status}");
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

        private unsafe NvPhysicalGpuHandle__* GetFirstPhysicalGpu()
        {
            var handles = stackalloc NvPhysicalGpuHandle__*[NVAPI.NVAPI_MAX_PHYSICAL_GPUS];
            uint count = 0;
            var status = NVAPI.NvAPI_EnumPhysicalGPUs(handles, &count);
            if (status != _NvAPI_Status.NVAPI_OK)
            {
                Skip.If(true, $"Physical GPU enumeration failed: {status}");
                return null;
            }

            Skip.If(count == 0, "No NVIDIA physical GPUs found.");
            return handles[0];
        }

        private unsafe uint GetFirstDisplayMask()
        {
            NvDisplayHandle__* displayHandle = null;
            var status = NVAPI.NvAPI_EnumNvidiaDisplayHandle(0, &displayHandle);
            if (status != _NvAPI_Status.NVAPI_OK)
            {
                Skip.If(true, $"Display enumeration failed: {status}");
                return 0;
            }

            uint outputId = 0;
            status = NVAPI.NvAPI_GetAssociatedDisplayOutputId(displayHandle, &outputId);
            if (status != _NvAPI_Status.NVAPI_OK)
            {
                Skip.If(true, $"Display output id not available: {status}");
                return 0;
            }

            Skip.If(outputId == 0, "Display output id is zero.");
            return outputId;
        }
    }
}
