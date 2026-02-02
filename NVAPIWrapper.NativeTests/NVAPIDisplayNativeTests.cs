
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Xunit;

namespace NVAPIWrapper.NativeTests
{
    /// <summary>
    /// Native display API tests.
    /// </summary>
    [SupportedOSPlatform("windows")]
    public sealed class NVAPIDisplayNativeTests : IDisposable
    {
        private readonly NVAPIApi? _api;
        private readonly string _skipReason = string.Empty;

        public NVAPIDisplayNativeTests()
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
        public unsafe void DispInfoFrameControl_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_Disp_InfoFrameControl");

            WithDisplayId(displayId =>
            {
                var data = new NV_INFOFRAME_DATA
                {
                    version = NVAPI.NV_INFOFRAME_DATA_VER,
                    size = (ushort)sizeof(NV_INFOFRAME_DATA),
                    cmd = (byte)NV_INFOFRAME_CMD.NV_INFOFRAME_CMD_GET_PROPERTY,
                    type = (byte)NV_INFOFRAME_PROPERTY_TYPE.NV_INFOFRAME_PROPERTY_TYPE_UNKNOWN
                };

                var status = NVAPI.NvAPI_Disp_InfoFrameControl(displayId, &data);
                if (status == _NvAPI_Status.NVAPI_INVALID_ARGUMENT)
                {
                    Skip.If(true, $"InfoFrame control invalid argument: {status}");
                    return;
                }

                if (IsUnsupported(status))
                {
                    Skip.If(true, $"InfoFrame control unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void DispColorControl_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_Disp_ColorControl");

            WithDisplayId(displayId =>
            {
                var colorData = new _NV_COLOR_DATA_V5
                {
                    version = NVAPI.NV_COLOR_DATA_VER,
                    size = (ushort)sizeof(_NV_COLOR_DATA_V5),
                    cmd = (byte)NV_COLOR_CMD.NV_COLOR_CMD_GET
                };

                var status = NVAPI.NvAPI_Disp_ColorControl(displayId, &colorData);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"Color control unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void DispGetHdrCapabilities_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_Disp_GetHdrCapabilities");

            WithDisplayId(displayId =>
            {
                var caps = new _NV_HDR_CAPABILITIES_V3
                {
                    version = NVAPI.NV_HDR_CAPABILITIES_VER
                };

                var status = NVAPI.NvAPI_Disp_GetHdrCapabilities(displayId, &caps);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"HDR capabilities unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void DispHdrColorControl_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_Disp_HdrColorControl");

            WithDisplayId(displayId =>
            {
                var hdr = new _NV_HDR_COLOR_DATA_V2
                {
                    version = NVAPI.NV_HDR_COLOR_DATA_VER,
                    cmd = NV_HDR_CMD.NV_HDR_CMD_GET
                };

                var status = NVAPI.NvAPI_Disp_HdrColorControl(displayId, &hdr);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"HDR color control unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void DispGetSourceColorSpace_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_Disp_GetSourceColorSpace");

            WithDisplayId(displayId =>
            {
                _NV_COLORSPACE_TYPE colorSpace = default;
                var status = NVAPI.NvAPI_Disp_GetSourceColorSpace(displayId, &colorSpace, (ulong)NVAPI.NV_SOURCE_PID_CURRENT);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"Source color space unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void DispSetSourceColorSpace_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_Disp_SetSourceColorSpace");
            SkipIfUnavailable("NvAPI_Disp_GetSourceColorSpace");

            WithDisplayId(displayId =>
            {
                _NV_COLORSPACE_TYPE current = default;
                var getStatus = NVAPI.NvAPI_Disp_GetSourceColorSpace(displayId, &current, (ulong)NVAPI.NV_SOURCE_PID_CURRENT);
                if (IsUnsupported(getStatus))
                {
                    Skip.If(true, $"Source color space unsupported: {getStatus}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, getStatus);

                var status = NVAPI.NvAPI_Disp_SetSourceColorSpace(displayId, current);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"Set source color space unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void DispGetSourceHdrMetadata_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_Disp_GetSourceHdrMetadata");

            WithDisplayId(displayId =>
            {
                var metadata = new _NV_HDR_METADATA_V1
                {
                    version = NVAPI.NV_HDR_METADATA_VER
                };

                var status = NVAPI.NvAPI_Disp_GetSourceHdrMetadata(displayId, &metadata, (ulong)NVAPI.NV_SOURCE_PID_CURRENT);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"Source HDR metadata unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void DispSetSourceHdrMetadata_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_Disp_SetSourceHdrMetadata");
            SkipIfUnavailable("NvAPI_Disp_GetSourceHdrMetadata");

            WithDisplayId(displayId =>
            {
                var metadata = new _NV_HDR_METADATA_V1
                {
                    version = NVAPI.NV_HDR_METADATA_VER
                };

                var getStatus = NVAPI.NvAPI_Disp_GetSourceHdrMetadata(displayId, &metadata, (ulong)NVAPI.NV_SOURCE_PID_CURRENT);
                if (IsUnsupported(getStatus))
                {
                    Skip.If(true, $"Source HDR metadata unsupported: {getStatus}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, getStatus);

                var status = NVAPI.NvAPI_Disp_SetSourceHdrMetadata(displayId, &metadata);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"Set source HDR metadata unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void DispGetOutputMode_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_Disp_GetOutputMode");

            WithDisplayId(displayId =>
            {
                _NV_DISPLAY_OUTPUT_MODE mode = default;
                var status = NVAPI.NvAPI_Disp_GetOutputMode(displayId, &mode);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"Output mode unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void DispSetOutputMode_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_Disp_SetOutputMode");
            SkipIfUnavailable("NvAPI_Disp_GetOutputMode");

            WithDisplayId(displayId =>
            {
                _NV_DISPLAY_OUTPUT_MODE mode = default;
                var getStatus = NVAPI.NvAPI_Disp_GetOutputMode(displayId, &mode);
                if (IsUnsupported(getStatus))
                {
                    Skip.If(true, $"Output mode unsupported: {getStatus}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, getStatus);

                var status = NVAPI.NvAPI_Disp_SetOutputMode(displayId, &mode);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"Set output mode unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void DispGetHdrToneMapping_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_Disp_GetHdrToneMapping");

            WithDisplayId(displayId =>
            {
                _NV_HDR_TONEMAPPING_METHOD method = default;
                var status = NVAPI.NvAPI_Disp_GetHdrToneMapping(displayId, &method);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"HDR tone mapping unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void DispSetHdrToneMapping_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_Disp_SetHdrToneMapping");
            SkipIfUnavailable("NvAPI_Disp_GetHdrToneMapping");

            WithDisplayId(displayId =>
            {
                _NV_HDR_TONEMAPPING_METHOD method = default;
                var getStatus = NVAPI.NvAPI_Disp_GetHdrToneMapping(displayId, &method);
                if (IsUnsupported(getStatus))
                {
                    Skip.If(true, $"HDR tone mapping unsupported: {getStatus}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, getStatus);

                var status = NVAPI.NvAPI_Disp_SetHdrToneMapping(displayId, method);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"Set HDR tone mapping unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void DispGetColorimetry_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_Disp_GetColorimetry");

            WithDisplayId(displayId =>
            {
                var colorimetry = new _NV_DISPLAY_COLORIMETRY_V1
                {
                    version = NVAPI.NV_DISPLAY_COLORIMETRY_VER
                };

                var status = NVAPI.NvAPI_Disp_GetColorimetry(displayId, &colorimetry);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"Colorimetry unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void DispGetDisplayIdInfo_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_Disp_GetDisplayIdInfo");

            WithDisplayId(displayId =>
            {
                var info = new _NV_DISPLAY_ID_INFO_DATA_V1
                {
                    version = NVAPI.NV_DISPLAY_ID_INFO_DATA_VER
                };

                var status = NVAPI.NvAPI_Disp_GetDisplayIdInfo(displayId, &info);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"Display ID info unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void DispGetDisplayIdsFromTarget_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_Disp_GetDisplayIdsFromTarget");
            SkipIfUnavailable("NvAPI_Disp_GetDisplayIdInfo");

            WithDisplayId(displayId =>
            {
                var info = new _NV_DISPLAY_ID_INFO_DATA_V1
                {
                    version = NVAPI.NV_DISPLAY_ID_INFO_DATA_VER
                };

                var infoStatus = NVAPI.NvAPI_Disp_GetDisplayIdInfo(displayId, &info);
                if (IsUnsupported(infoStatus))
                {
                    Skip.If(true, $"Display ID info unsupported: {infoStatus}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, infoStatus);

                var targetInfo = new _NV_TARGET_INFO_DATA_V1
                {
                    version = NVAPI.NV_TARGET_INFO_DATA_VER,
                    adapterId = info.adapterId,
                    targetId = info.targetId
                };

                var status = NVAPI.NvAPI_Disp_GetDisplayIdsFromTarget(&targetInfo);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"Display IDs from target unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void DispEnumCustomDisplay_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_DISP_EnumCustomDisplay");

            WithDisplayId(displayId =>
            {
                var custom = new NV_CUSTOM_DISPLAY
                {
                    version = NVAPI.NV_CUSTOM_DISPLAY_VER
                };

                var status = NVAPI.NvAPI_DISP_EnumCustomDisplay(displayId, 0, &custom);
                if (status == _NvAPI_Status.NVAPI_END_ENUMERATION)
                {
                    Skip.If(true, "No custom displays enumerated.");
                    return;
                }

                if (IsUnsupported(status) || status == _NvAPI_Status.NVAPI_INVALID_DISPLAY_ID)
                {
                    Skip.If(true, $"Custom display enumeration unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void DispTryCustomDisplay_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_DISP_TryCustomDisplay");
            SkipIfUnavailable("NvAPI_DISP_EnumCustomDisplay");

            WithDisplayId(displayId =>
            {
                var custom = new NV_CUSTOM_DISPLAY
                {
                    version = NVAPI.NV_CUSTOM_DISPLAY_VER
                };

                var enumStatus = NVAPI.NvAPI_DISP_EnumCustomDisplay(displayId, 0, &custom);
                if (enumStatus == _NvAPI_Status.NVAPI_END_ENUMERATION)
                {
                    Skip.If(true, "No custom displays enumerated.");
                    return;
                }

                if (IsUnsupported(enumStatus) || enumStatus == _NvAPI_Status.NVAPI_INVALID_DISPLAY_ID)
                {
                    Skip.If(true, $"Custom display enumeration unsupported: {enumStatus}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, enumStatus);

                var displayIds = stackalloc uint[1];
                displayIds[0] = displayId;

                var status = NVAPI.NvAPI_DISP_TryCustomDisplay(displayIds, 1, &custom);
                if (IsUnsupported(status) || status == _NvAPI_Status.NVAPI_INVALID_DISPLAY_ID)
                {
                    Skip.If(true, $"Try custom display unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void DispRevertCustomDisplayTrial_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_DISP_RevertCustomDisplayTrial");
            SkipIfUnavailable("NvAPI_DISP_EnumCustomDisplay");

            WithDisplayId(displayId =>
            {
                var custom = new NV_CUSTOM_DISPLAY
                {
                    version = NVAPI.NV_CUSTOM_DISPLAY_VER
                };

                var enumStatus = NVAPI.NvAPI_DISP_EnumCustomDisplay(displayId, 0, &custom);
                if (enumStatus == _NvAPI_Status.NVAPI_END_ENUMERATION)
                {
                    Skip.If(true, "No custom displays enumerated.");
                    return;
                }

                if (IsUnsupported(enumStatus) || enumStatus == _NvAPI_Status.NVAPI_INVALID_DISPLAY_ID)
                {
                    Skip.If(true, $"Custom display enumeration unsupported: {enumStatus}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, enumStatus);

                var displayIds = stackalloc uint[1];
                displayIds[0] = displayId;

                var status = NVAPI.NvAPI_DISP_RevertCustomDisplayTrial(displayIds, 1);
                if (IsUnsupported(status) || status == _NvAPI_Status.NVAPI_INVALID_DISPLAY_ID)
                {
                    Skip.If(true, $"Revert custom display unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void DispSaveCustomDisplay_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_DISP_SaveCustomDisplay");
            SkipIfUnavailable("NvAPI_DISP_EnumCustomDisplay");

            WithDisplayId(displayId =>
            {
                var custom = new NV_CUSTOM_DISPLAY
                {
                    version = NVAPI.NV_CUSTOM_DISPLAY_VER
                };

                var enumStatus = NVAPI.NvAPI_DISP_EnumCustomDisplay(displayId, 0, &custom);
                if (enumStatus == _NvAPI_Status.NVAPI_END_ENUMERATION)
                {
                    Skip.If(true, "No custom displays enumerated.");
                    return;
                }

                if (IsUnsupported(enumStatus) || enumStatus == _NvAPI_Status.NVAPI_INVALID_DISPLAY_ID)
                {
                    Skip.If(true, $"Custom display enumeration unsupported: {enumStatus}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, enumStatus);

                var displayIds = stackalloc uint[1];
                displayIds[0] = displayId;

                var status = NVAPI.NvAPI_DISP_SaveCustomDisplay(displayIds, 1, 0, 0);
                if (IsUnsupported(status) || status == _NvAPI_Status.NVAPI_INVALID_DISPLAY_ID)
                {
                    Skip.If(true, $"Save custom display unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void DispDeleteCustomDisplay_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_DISP_DeleteCustomDisplay");
            SkipIfUnavailable("NvAPI_DISP_EnumCustomDisplay");

            WithDisplayId(displayId =>
            {
                var custom = new NV_CUSTOM_DISPLAY
                {
                    version = NVAPI.NV_CUSTOM_DISPLAY_VER
                };

                var enumStatus = NVAPI.NvAPI_DISP_EnumCustomDisplay(displayId, 0, &custom);
                if (enumStatus == _NvAPI_Status.NVAPI_END_ENUMERATION)
                {
                    Skip.If(true, "No custom displays enumerated.");
                    return;
                }

                if (IsUnsupported(enumStatus) || enumStatus == _NvAPI_Status.NVAPI_INVALID_DISPLAY_ID)
                {
                    Skip.If(true, $"Custom display enumeration unsupported: {enumStatus}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, enumStatus);

                var displayIds = stackalloc uint[1];
                displayIds[0] = displayId;

                var status = NVAPI.NvAPI_DISP_DeleteCustomDisplay(displayIds, 1, &custom);
                if (IsUnsupported(status) || status == _NvAPI_Status.NVAPI_INVALID_DISPLAY_ID)
                {
                    Skip.If(true, $"Delete custom display unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            });
        }

        [SkippableFact]
        public unsafe void DispGetNvManagedDedicatedDisplays_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_DISP_GetNvManagedDedicatedDisplays");

            var count = 0u;
            var status = NVAPI.NvAPI_DISP_GetNvManagedDedicatedDisplays(&count, null);
            if (IsUnsupported(status))
            {
                Skip.If(true, $"Managed dedicated displays unsupported: {status}");
                return;
            }

            Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
        }

        [SkippableFact]
        public unsafe void DispAcquireDedicatedDisplay_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_DISP_AcquireDedicatedDisplay");

            var displayId = GetAnyDisplayId();
            Skip.If(displayId == null, "No display ID available.");

            ulong handle = 0;
            var status = NVAPI.NvAPI_DISP_AcquireDedicatedDisplay(displayId.Value, &handle);
            if (IsUnsupported(status) ||
                status == _NvAPI_Status.NVAPI_UNREGISTERED_RESOURCE ||
                status == _NvAPI_Status.NVAPI_RESOURCE_IN_USE ||
                status == _NvAPI_Status.NVAPI_INVALID_DISPLAY_ID)
            {
                Skip.If(true, $"Acquire dedicated display unsupported: {status}");
                return;
            }

            Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
        }

        [SkippableFact]
        public unsafe void DispReleaseDedicatedDisplay_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_DISP_ReleaseDedicatedDisplay");

            var displayId = GetAnyDisplayId();
            Skip.If(displayId == null, "No display ID available.");

            var status = NVAPI.NvAPI_DISP_ReleaseDedicatedDisplay(displayId.Value);
            if (IsUnsupported(status) ||
                status == _NvAPI_Status.NVAPI_UNREGISTERED_RESOURCE ||
                status == _NvAPI_Status.NVAPI_RESOURCE_NOT_ACQUIRED ||
                status == _NvAPI_Status.NVAPI_INVALID_DISPLAY_ID)
            {
                Skip.If(true, $"Release dedicated display unsupported: {status}");
                return;
            }

            Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
        }

        [SkippableFact]
        public unsafe void DispGetNvManagedDedicatedDisplayMetadata_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_DISP_GetNvManagedDedicatedDisplayMetadata");

            var displayId = GetAnyDisplayId();
            Skip.If(displayId == null, "No display ID available.");

            var metadata = new _NV_MANAGED_DEDICATED_DISPLAY_METADATA
            {
                version = NVAPI.NV_MANAGED_DEDICATED_DISPLAY_METADATA_VER,
                displayId = displayId.Value
            };

            var status = NVAPI.NvAPI_DISP_GetNvManagedDedicatedDisplayMetadata(&metadata);
            if (IsUnsupported(status))
            {
                Skip.If(true, $"Managed dedicated display metadata unsupported: {status}");
                return;
            }

            Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
        }

        [SkippableFact]
        public unsafe void DispSetNvManagedDedicatedDisplayMetadata_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_DISP_SetNvManagedDedicatedDisplayMetadata");
            SkipIfUnavailable("NvAPI_DISP_GetNvManagedDedicatedDisplayMetadata");

            var displayId = GetAnyDisplayId();
            Skip.If(displayId == null, "No display ID available.");

            var metadata = new _NV_MANAGED_DEDICATED_DISPLAY_METADATA
            {
                version = NVAPI.NV_MANAGED_DEDICATED_DISPLAY_METADATA_VER,
                displayId = displayId.Value
            };

            var getStatus = NVAPI.NvAPI_DISP_GetNvManagedDedicatedDisplayMetadata(&metadata);
            if (IsUnsupported(getStatus))
            {
                Skip.If(true, $"Managed dedicated display metadata unsupported: {getStatus}");
                return;
            }

            Assert.Equal(_NvAPI_Status.NVAPI_OK, getStatus);

            var status = NVAPI.NvAPI_DISP_SetNvManagedDedicatedDisplayMetadata(&metadata);
            if (IsUnsupported(status) ||
                status == _NvAPI_Status.NVAPI_INVALID_USER_PRIVILEGE ||
                status == _NvAPI_Status.NVAPI_INVALID_ARGUMENT)
            {
                Skip.If(true, $"Set managed dedicated display metadata unsupported: {status}");
                return;
            }

            Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
        }

        [SkippableFact]
        public unsafe void EnumNvidiaUnAttachedDisplayHandle_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_EnumNvidiaUnAttachedDisplayHandle");

            NvUnAttachedDisplayHandle__* handle;
            var status = NVAPI.NvAPI_EnumNvidiaUnAttachedDisplayHandle(0, &handle);
            if (status == _NvAPI_Status.NVAPI_END_ENUMERATION)
            {
                Skip.If(true, "No unattached displays.");
                return;
            }

            if (IsUnsupported(status))
            {
                Skip.If(true, $"Unattached display enumeration unsupported: {status}");
                return;
            }

            Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
        }

        [SkippableFact]
        public unsafe void DispGetAssociatedUnAttachedNvidiaDisplayHandle_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_DISP_GetAssociatedUnAttachedNvidiaDisplayHandle");
            SkipIfUnavailable("NvAPI_GetAssociatedNvidiaDisplayName");

            var displayName = GetAssociatedDisplayName();
            Skip.If(string.IsNullOrWhiteSpace(displayName), "No display name available.");

            var bytes = System.Text.Encoding.ASCII.GetBytes(displayName + "\0");
            fixed (byte* pBytes = bytes)
            {
                NvUnAttachedDisplayHandle__* handle;
                var status = NVAPI.NvAPI_DISP_GetAssociatedUnAttachedNvidiaDisplayHandle((sbyte*)pBytes, &handle);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"Associated unattached display handle unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            }
        }

        [SkippableFact]
        public unsafe void GetUnAttachedAssociatedDisplayName_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_GetUnAttachedAssociatedDisplayName");
            SkipIfUnavailable("NvAPI_EnumNvidiaUnAttachedDisplayHandle");

            NvUnAttachedDisplayHandle__* handle;
            var enumStatus = NVAPI.NvAPI_EnumNvidiaUnAttachedDisplayHandle(0, &handle);
            if (enumStatus == _NvAPI_Status.NVAPI_END_ENUMERATION)
            {
                Skip.If(true, "No unattached displays.");
                return;
            }

            if (IsUnsupported(enumStatus))
            {
                Skip.If(true, $"Unattached display enumeration unsupported: {enumStatus}");
                return;
            }

            Assert.Equal(_NvAPI_Status.NVAPI_OK, enumStatus);

            Span<sbyte> buffer = stackalloc sbyte[NVAPI.NVAPI_SHORT_STRING_MAX];
            buffer[0] = 0;
            fixed (sbyte* pBuffer = buffer)
            {
                var status = NVAPI.NvAPI_GetUnAttachedAssociatedDisplayName(handle, pBuffer);
                if (IsUnsupported(status))
                {
                    Skip.If(true, $"Unattached display name unsupported: {status}");
                    return;
                }

                Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
            }
        }

        [SkippableFact]
        public unsafe void GetPhysicalGpuFromUnAttachedDisplay_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_GetPhysicalGPUFromUnAttachedDisplay");
            SkipIfUnavailable("NvAPI_EnumNvidiaUnAttachedDisplayHandle");

            NvUnAttachedDisplayHandle__* handle;
            var enumStatus = NVAPI.NvAPI_EnumNvidiaUnAttachedDisplayHandle(0, &handle);
            if (enumStatus == _NvAPI_Status.NVAPI_END_ENUMERATION)
            {
                Skip.If(true, "No unattached displays.");
                return;
            }

            if (IsUnsupported(enumStatus))
            {
                Skip.If(true, $"Unattached display enumeration unsupported: {enumStatus}");
                return;
            }

            Assert.Equal(_NvAPI_Status.NVAPI_OK, enumStatus);

            NvPhysicalGpuHandle__* gpu;
            var status = NVAPI.NvAPI_GetPhysicalGPUFromUnAttachedDisplay(handle, &gpu);
            if (IsUnsupported(status))
            {
                Skip.If(true, $"Physical GPU from unattached display unsupported: {status}");
                return;
            }

            Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
        }

        [SkippableFact]
        public unsafe void CreateDisplayFromUnAttachedDisplay_ShouldReturnValue()
        {
            SkipIfUnavailable("NvAPI_CreateDisplayFromUnAttachedDisplay");
            SkipIfUnavailable("NvAPI_EnumNvidiaUnAttachedDisplayHandle");

            NvUnAttachedDisplayHandle__* handle;
            var enumStatus = NVAPI.NvAPI_EnumNvidiaUnAttachedDisplayHandle(0, &handle);
            if (enumStatus == _NvAPI_Status.NVAPI_END_ENUMERATION)
            {
                Skip.If(true, "No unattached displays.");
                return;
            }

            if (IsUnsupported(enumStatus))
            {
                Skip.If(true, $"Unattached display enumeration unsupported: {enumStatus}");
                return;
            }

            Assert.Equal(_NvAPI_Status.NVAPI_OK, enumStatus);

            NvDisplayHandle__* displayHandle;
            var status = NVAPI.NvAPI_CreateDisplayFromUnAttachedDisplay(handle, &displayHandle);
            if (IsUnsupported(status))
            {
                Skip.If(true, $"Create display from unattached display unsupported: {status}");
                return;
            }

            Assert.Equal(_NvAPI_Status.NVAPI_OK, status);
        }

        private unsafe void SkipIfUnavailable(string functionName)
        {
            Skip.If(_api == null, _skipReason);

            var functions = _api!.GetAvailableFunctions();
            var available = functions.Any(entry => entry.Name == functionName && entry.IsAvailable);
            Skip.If(!available, $"NVAPI function '{functionName}' not available.");
        }

        private unsafe void WithDisplayId(Action<uint> action)
        {
            var displayId = GetAnyDisplayId();
            Skip.If(displayId == null, "No NVIDIA display IDs found.");
            action(displayId.Value);
        }

        private unsafe uint? GetAnyDisplayId()
        {
            SkipIfUnavailable("NvAPI_EnumNvidiaDisplayHandle");
            SkipIfUnavailable("NvAPI_GetAssociatedNvidiaDisplayName");
            SkipIfUnavailable("NvAPI_DISP_GetDisplayIdByDisplayName");

            NvDisplayHandle__* handle;
            var enumStatus = NVAPI.NvAPI_EnumNvidiaDisplayHandle(0, &handle);
            if (enumStatus == _NvAPI_Status.NVAPI_END_ENUMERATION)
                return null;

            if (IsUnsupported(enumStatus))
            {
                Skip.If(true, $"Display handle enumeration unsupported: {enumStatus}");
                return null;
            }

            if (enumStatus != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(enumStatus);

            uint displayId = 0;
            var name = GetAssociatedDisplayName();
            if (string.IsNullOrWhiteSpace(name))
                return null;

            var bytes = System.Text.Encoding.ASCII.GetBytes(name + "\0");
            fixed (byte* pBytes = bytes)
            {
                var status = NVAPI.NvAPI_DISP_GetDisplayIdByDisplayName((sbyte*)pBytes, &displayId);
                if (IsUnsupported(status) || status == _NvAPI_Status.NVAPI_INVALID_ARGUMENT)
                    return null;

                if (status != _NvAPI_Status.NVAPI_OK)
                    throw new NVAPIException(status);
            }

            return displayId;
        }

        private unsafe string? GetAssociatedDisplayName()
        {
            NvDisplayHandle__* handle;
            var status = NVAPI.NvAPI_EnumNvidiaDisplayHandle(0, &handle);
            if (status == _NvAPI_Status.NVAPI_END_ENUMERATION)
                return null;

            if (IsUnsupported(status))
                return null;

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            Span<sbyte> buffer = stackalloc sbyte[NVAPI.NVAPI_SHORT_STRING_MAX];
            buffer[0] = 0;
            fixed (sbyte* pBuffer = buffer)
            {
                var nameStatus = NVAPI.NvAPI_GetAssociatedNvidiaDisplayName(handle, pBuffer);
                if (IsUnsupported(nameStatus))
                    return null;

                if (nameStatus != _NvAPI_Status.NVAPI_OK)
                    throw new NVAPIException(nameStatus);

                return Marshal.PtrToStringAnsi((IntPtr)pBuffer);
            }
        }

        private static bool IsUnsupported(_NvAPI_Status status)
        {
            return status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND;
        }

        public void Dispose()
        {
            _api?.Dispose();
        }
    }
}
