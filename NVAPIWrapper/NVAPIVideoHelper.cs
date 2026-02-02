using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NVAPIWrapper
{
    /// <summary>
    /// Facade helper for video-related NVAPI functions (VIO + Stereo globals).
    /// </summary>
    public sealed class NVAPIVideoHelper : IDisposable
    {
        internal const uint NvApiIdVioGetCapabilities = 0x1DC91303;
        internal const uint NvApiIdVioOpen = 0x44EE4841;
        internal const uint NvApiIdVioClose = 0xD01BD237;
        internal const uint NvApiIdVioStatus = 0x0E6CE4F1;
        internal const uint NvApiIdVioSyncFormatDetect = 0x118D48A3;
        internal const uint NvApiIdVioGetConfig = 0xD34A789B;
        internal const uint NvApiIdVioSetConfig = 0x0E4EEC07;
        internal const uint NvApiIdVioSetCsc = 0xA1EC8D74;
        internal const uint NvApiIdVioGetCsc = 0x7B0D72A3;
        internal const uint NvApiIdVioSetGamma = 0x964BF452;
        internal const uint NvApiIdVioGetGamma = 0x51D53D06;
        internal const uint NvApiIdVioSetSyncDelay = 0x2697A8D1;
        internal const uint NvApiIdVioGetSyncDelay = 0x462214A9;
        internal const uint NvApiIdVioGetPciInfo = 0xB981D935;
        internal const uint NvApiIdVioIsRunning = 0x96BD040E;
        internal const uint NvApiIdVioStart = 0xCDE8E1A3;
        internal const uint NvApiIdVioStop = 0x6BA2A5D6;
        internal const uint NvApiIdVioIsFrameLockModeCompatible = 0x7BF0A94D;
        internal const uint NvApiIdVioEnumDevices = 0xFD7C5557;
        internal const uint NvApiIdVioQueryTopology = 0x869534E2;
        internal const uint NvApiIdVioEnumSignalFormats = 0xEAD72FE4;
        internal const uint NvApiIdVioEnumDataFormats = 0x221FA8E8;

        private const uint NvApiIdStereoCreateConfigurationProfileRegistryKey = 0xBE7692EC;
        private const uint NvApiIdStereoDeleteConfigurationProfileRegistryKey = 0xF117B834;
        private const uint NvApiIdStereoDeleteConfigurationProfileValue = 0x49BCEECF;
        private const uint NvApiIdStereoEnable = 0x239C4545;
        private const uint NvApiIdStereoDisable = 0x2EC50C2B;
        private const uint NvApiIdStereoIsEnabled = 0x348FF8E1;
        private const uint NvApiIdStereoIsWindowedModeSupported = 0x40C8ED5E;
        private const uint NvApiIdStereoSetDriverMode = 0x5E8F0BEC;
        private const uint NvApiIdStereoSetDefaultProfile = 0x44F0ECD1;
        private const uint NvApiIdStereoGetDefaultProfile = 0x624E21C2;

        internal const int VioAdapterNameMax = 4096;

        private readonly NVAPIApiHelper _apiHelper;
        private bool _disposed;

        internal NVAPIVideoHelper(NVAPIApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        /// <summary>
        /// Enumerate available VIO devices.
        /// </summary>
        /// <returns>Array of VIO device helpers, or empty if unavailable.</returns>
        public unsafe NVAPIVioDeviceHelper[] EnumerateVioDevices()
        {
            ThrowIfDisposed();

            var enumDevices = GetDelegate<NvApiVioEnumDevicesDelegate>(NvApiIdVioEnumDevices, "NvAPI_VIO_EnumDevices");
            var handles = stackalloc NvVioHandle__*[NVAPI.NVAPI_MAX_VIO_DEVICES];
            uint count = 0;
            var status = enumDevices(handles, &count);

            if (IsUnsupported(status))
                return Array.Empty<NVAPIVioDeviceHelper>();

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            var deviceCount = (int)Math.Min(count, NVAPI.NVAPI_MAX_VIO_DEVICES);
            if (deviceCount == 0)
                return Array.Empty<NVAPIVioDeviceHelper>();

            var result = new NVAPIVioDeviceHelper[deviceCount];
            for (var i = 0; i < deviceCount; i++)
            {
                result[i] = new NVAPIVioDeviceHelper(_apiHelper, (IntPtr)handles[i]);
            }

            return result;
        }

        /// <summary>
        /// Query VIO topology.
        /// </summary>
        /// <returns>Topology DTO, or null if unavailable.</returns>
        public unsafe NVAPIVioTopologyDto? QueryTopology()
        {
            ThrowIfDisposed();

            var query = GetDelegate<NvApiVioQueryTopologyDelegate>(NvApiIdVioQueryTopology, "NvAPI_VIO_QueryTopology");
            var topology = new _NV_VIO_TOPOLOGY { version = NVAPI.NV_VIO_TOPOLOGY_VER };

            var status = query(&topology);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIVioTopologyDto.FromNative(topology);

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Enable stereo driver mode globally.
        /// </summary>
        /// <returns>True if enabled, null if unsupported.</returns>
        public unsafe bool? StereoEnable()
        {
            ThrowIfDisposed();

            var enable = GetDelegate<NvApiStereoEnableDelegate>(NvApiIdStereoEnable, "NvAPI_Stereo_Enable");
            var status = enable();
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Disable stereo driver mode globally.
        /// </summary>
        /// <returns>True if disabled, null if unsupported.</returns>
        public unsafe bool? StereoDisable()
        {
            ThrowIfDisposed();

            var disable = GetDelegate<NvApiStereoDisableDelegate>(NvApiIdStereoDisable, "NvAPI_Stereo_Disable");
            var status = disable();
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get whether stereo is enabled.
        /// </summary>
        /// <returns>True if enabled, false if disabled, or null if unsupported.</returns>
        public unsafe bool? StereoIsEnabled()
        {
            ThrowIfDisposed();

            var isEnabled = GetDelegate<NvApiStereoIsEnabledDelegate>(NvApiIdStereoIsEnabled, "NvAPI_Stereo_IsEnabled");
            byte enabled = 0;
            var status = isEnabled(&enabled);
            if (status == _NvAPI_Status.NVAPI_OK)
                return enabled != 0;

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Check whether windowed stereo is supported.
        /// </summary>
        /// <returns>True if supported, false if not, or null if unsupported.</returns>
        public unsafe bool? StereoIsWindowedModeSupported()
        {
            ThrowIfDisposed();

            var isSupported = GetDelegate<NvApiStereoIsWindowedModeSupportedDelegate>(
                NvApiIdStereoIsWindowedModeSupported,
                "NvAPI_Stereo_IsWindowedModeSupported");

            byte supported = 0;
            var status = isSupported(&supported);
            if (status == _NvAPI_Status.NVAPI_OK)
                return supported != 0;

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Set stereo driver mode.
        /// </summary>
        /// <param name="mode">Driver mode.</param>
        /// <returns>True if applied, null if unsupported.</returns>
        public unsafe bool? StereoSetDriverMode(_NV_StereoDriverMode mode)
        {
            ThrowIfDisposed();

            var setMode = GetDelegate<NvApiStereoSetDriverModeDelegate>(NvApiIdStereoSetDriverMode, "NvAPI_Stereo_SetDriverMode");
            var status = setMode(mode);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Set the default stereo profile.
        /// </summary>
        /// <param name="profileName">Profile name.</param>
        /// <returns>True if applied, null if unsupported.</returns>
        public unsafe bool? StereoSetDefaultProfile(string profileName)
        {
            ThrowIfDisposed();

            var setProfile = GetDelegate<NvApiStereoSetDefaultProfileDelegate>(NvApiIdStereoSetDefaultProfile, "NvAPI_Stereo_SetDefaultProfile");
            var bytes = Encoding.ASCII.GetBytes(profileName ?? string.Empty);
            var buffer = new sbyte[bytes.Length + 1];
            for (var i = 0; i < bytes.Length; i++)
                buffer[i] = (sbyte)bytes[i];
            buffer[buffer.Length - 1] = 0;

            fixed (sbyte* pName = buffer)
            {
                var status = setProfile(pName);
                if (status == _NvAPI_Status.NVAPI_OK)
                    return true;

                if (IsUnsupported(status))
                    return null;

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Get the default stereo profile name.
        /// </summary>
        /// <returns>Profile name, or null if unsupported.</returns>
        public unsafe string? StereoGetDefaultProfile()
        {
            ThrowIfDisposed();

            var getProfile = GetDelegate<NvApiStereoGetDefaultProfileDelegate>(NvApiIdStereoGetDefaultProfile, "NvAPI_Stereo_GetDefaultProfile");
            Span<sbyte> buffer = stackalloc sbyte[NVAPI.NVAPI_LONG_STRING_MAX];
            buffer.Clear();
            uint size = (uint)buffer.Length;

            fixed (sbyte* pBuffer = buffer)
            {
                var status = getProfile(size, pBuffer, &size);
                if (status == _NvAPI_Status.NVAPI_OK)
                    return Marshal.PtrToStringAnsi((IntPtr)pBuffer) ?? string.Empty;

                if (IsUnsupported(status))
                    return null;

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Create the stereo configuration profile registry key.
        /// </summary>
        /// <param name="profileType">Registry profile type.</param>
        /// <returns>True if created, null if unsupported.</returns>
        public unsafe bool? StereoCreateConfigurationProfileRegistryKey(_NV_StereoRegistryProfileType profileType)
        {
            ThrowIfDisposed();

            var createKey = GetDelegate<NvApiStereoCreateConfigurationProfileRegistryKeyDelegate>(
                NvApiIdStereoCreateConfigurationProfileRegistryKey,
                "NvAPI_Stereo_CreateConfigurationProfileRegistryKey");

            var status = createKey(profileType);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Delete the stereo configuration profile registry key.
        /// </summary>
        /// <param name="profileType">Registry profile type.</param>
        /// <returns>True if deleted, null if unsupported.</returns>
        public unsafe bool? StereoDeleteConfigurationProfileRegistryKey(_NV_StereoRegistryProfileType profileType)
        {
            ThrowIfDisposed();

            var deleteKey = GetDelegate<NvApiStereoDeleteConfigurationProfileRegistryKeyDelegate>(
                NvApiIdStereoDeleteConfigurationProfileRegistryKey,
                "NvAPI_Stereo_DeleteConfigurationProfileRegistryKey");

            var status = deleteKey(profileType);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Delete a stereo configuration profile value.
        /// </summary>
        /// <param name="profileType">Registry profile type.</param>
        /// <param name="valueId">Value identifier.</param>
        /// <returns>True if deleted, null if unsupported.</returns>
        public unsafe bool? StereoDeleteConfigurationProfileValue(_NV_StereoRegistryProfileType profileType, _NV_StereoRegistryID valueId)
        {
            ThrowIfDisposed();

            var deleteValue = GetDelegate<NvApiStereoDeleteConfigurationProfileValueDelegate>(
                NvApiIdStereoDeleteConfigurationProfileValue,
                "NvAPI_Stereo_DeleteConfigurationProfileValue");

            var status = deleteValue(profileType, valueId);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        private T GetDelegate<T>(uint id, string name) where T : Delegate
        {
            var functionPtr = _apiHelper.Api.TryGetFunctionPointer(id);
            if (functionPtr == IntPtr.Zero)
            {
                throw new NVAPIException(_NvAPI_Status.NVAPI_NO_IMPLEMENTATION, $"NVAPI function '{name}' (0x{id:X8}) not available.");
            }

            return Marshal.GetDelegateForFunctionPointer<T>(functionPtr);
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(NVAPIVideoHelper));

            _apiHelper.ThrowIfDisposed();
        }

        /// <summary>
        /// Dispose the helper and prevent further use.
        /// </summary>
        public void Dispose()
        {
            _disposed = true;
        }

        private static bool IsUnsupported(_NvAPI_Status status)
        {
            return status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiVioEnumDevicesDelegate(NvVioHandle__** hVioHandle, uint* vioDeviceCount);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiVioQueryTopologyDelegate(_NV_VIO_TOPOLOGY* pTopology);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate _NvAPI_Status NvApiStereoEnableDelegate();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate _NvAPI_Status NvApiStereoDisableDelegate();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiStereoIsEnabledDelegate(byte* pEnabled);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiStereoIsWindowedModeSupportedDelegate(byte* pSupported);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate _NvAPI_Status NvApiStereoSetDriverModeDelegate(_NV_StereoDriverMode mode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiStereoSetDefaultProfileDelegate(sbyte* profileName);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiStereoGetDefaultProfileDelegate(uint cbSizeIn, sbyte* profileName, uint* pcbSizeOut);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate _NvAPI_Status NvApiStereoCreateConfigurationProfileRegistryKeyDelegate(_NV_StereoRegistryProfileType profileType);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate _NvAPI_Status NvApiStereoDeleteConfigurationProfileRegistryKeyDelegate(_NV_StereoRegistryProfileType profileType);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate _NvAPI_Status NvApiStereoDeleteConfigurationProfileValueDelegate(_NV_StereoRegistryProfileType profileType, _NV_StereoRegistryID valueId);
    }

    /// <summary>
    /// Facade helper for a VIO device handle.
    /// </summary>
    public sealed class NVAPIVioDeviceHelper : IDisposable
    {
        private readonly NVAPIApiHelper _apiHelper;
        private readonly IntPtr _handle;
        private bool _disposed;

        internal NVAPIVioDeviceHelper(NVAPIApiHelper apiHelper, IntPtr handle)
        {
            _apiHelper = apiHelper;
            _handle = handle;
        }

        /// <summary>
        /// Get VIO capabilities.
        /// </summary>
        /// <returns>Capabilities DTO, or null if unavailable.</returns>
        public unsafe NVAPIVioCapsDto? GetCapabilities()
        {
            ThrowIfDisposed();

            var getCaps = GetDelegate<NvApiVioGetCapabilitiesDelegate>(NVAPIVideoHelper.NvApiIdVioGetCapabilities, "NvAPI_VIO_GetCapabilities");
            var caps = new _NVVIOCAPS { version = NVAPI.NVVIOCAPS_VER };

            var status = getCaps((NvVioHandle__*)_handle, &caps);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIVioCapsDto.FromNative(caps);

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Open the VIO device.
        /// </summary>
        /// <param name="vioClass">VIO class.</param>
        /// <param name="ownerType">Owner type.</param>
        /// <returns>True if opened, null if unsupported.</returns>
        public unsafe bool? Open(uint vioClass, _NVVIOOWNERTYPE ownerType)
        {
            ThrowIfDisposed();

            var open = GetDelegate<NvApiVioOpenDelegate>(NVAPIVideoHelper.NvApiIdVioOpen, "NvAPI_VIO_Open");
            var status = open((NvVioHandle__*)_handle, vioClass, ownerType);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Close the VIO device.
        /// </summary>
        /// <param name="release">Release resources.</param>
        /// <returns>True if closed, null if unsupported.</returns>
        public unsafe bool? Close(bool release = true)
        {
            ThrowIfDisposed();

            var close = GetDelegate<NvApiVioCloseDelegate>(NVAPIVideoHelper.NvApiIdVioClose, "NvAPI_VIO_Close");
            var status = close((NvVioHandle__*)_handle, release ? 1u : 0u);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get VIO status.
        /// </summary>
        /// <returns>Status DTO, or null if unavailable.</returns>
        public unsafe NVAPIVioStatusDto? GetStatus()
        {
            ThrowIfDisposed();

            var getStatus = GetDelegate<NvApiVioStatusDelegate>(NVAPIVideoHelper.NvApiIdVioStatus, "NvAPI_VIO_Status");
            var statusInfo = new _NVVIOSTATUS { version = NVAPI.NVVIOSTATUS_VER };

            var status = getStatus((NvVioHandle__*)_handle, &statusInfo);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIVioStatusDto.FromNative(statusInfo);

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Detect sync format.
        /// </summary>
        /// <param name="wait">Wait value.</param>
        /// <returns>Updated wait value, or null if unsupported.</returns>
        public unsafe uint? SyncFormatDetect(uint wait = 0)
        {
            ThrowIfDisposed();

            var detect = GetDelegate<NvApiVioSyncFormatDetectDelegate>(NVAPIVideoHelper.NvApiIdVioSyncFormatDetect, "NvAPI_VIO_SyncFormatDetect");
            var waitValue = wait;
            var status = detect((NvVioHandle__*)_handle, &waitValue);
            if (status == _NvAPI_Status.NVAPI_OK)
                return waitValue;

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get VIO configuration.
        /// </summary>
        /// <returns>Configuration DTO, or null if unavailable.</returns>
        public unsafe NVAPIVioConfigDto? GetConfig()
        {
            ThrowIfDisposed();

            var getConfig = GetDelegate<NvApiVioGetConfigDelegate>(NVAPIVideoHelper.NvApiIdVioGetConfig, "NvAPI_VIO_GetConfig");
            var config = new _NVVIOCONFIG_V3 { version = NVAPI.NVVIOCONFIG_VER };

            var status = getConfig((NvVioHandle__*)_handle, &config);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIVioConfigDto.FromNative(config);

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Set VIO configuration.
        /// </summary>
        /// <param name="config">Configuration DTO.</param>
        /// <returns>True if applied, null if unsupported.</returns>
        public unsafe bool? SetConfig(NVAPIVioConfigDto config)
        {
            ThrowIfDisposed();

            var current = GetConfig();
            if (current.HasValue && current.Value.Equals(config))
                return true;

            var setConfig = GetDelegate<NvApiVioSetConfigDelegate>(NVAPIVideoHelper.NvApiIdVioSetConfig, "NvAPI_VIO_SetConfig");
            var native = config.ToNative();

            var status = setConfig((NvVioHandle__*)_handle, &native);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get VIO color conversion (deprecated).
        /// </summary>
        /// <returns>Color conversion DTO, or null if unavailable.</returns>
        [Obsolete("Deprecated by NVAPI. Prefer GetConfig/SetConfig.")]
        public unsafe NVAPIVioColorConversionDto? GetCsc()
        {
            ThrowIfDisposed();

            var getCsc = GetDelegate<NvApiVioGetCscDelegate>(NVAPIVideoHelper.NvApiIdVioGetCsc, "NvAPI_VIO_GetCSC");
            var csc = new _NVVIOCOLORCONVERSION { version = NVAPI.NVVIOCOLORCONVERSION_VER };

            var status = getCsc((NvVioHandle__*)_handle, &csc);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIVioColorConversionDto.FromNative(csc);

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Set VIO color conversion (deprecated).
        /// </summary>
        /// <param name="conversion">Color conversion DTO.</param>
        /// <returns>True if applied, null if unsupported.</returns>
        [Obsolete("Deprecated by NVAPI. Prefer GetConfig/SetConfig.")]
        public unsafe bool? SetCsc(NVAPIVioColorConversionDto conversion)
        {
            ThrowIfDisposed();

            var setCsc = GetDelegate<NvApiVioSetCscDelegate>(NVAPIVideoHelper.NvApiIdVioSetCsc, "NvAPI_VIO_SetCSC");
            var native = conversion.ToNative();

            var status = setCsc((NvVioHandle__*)_handle, &native);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get VIO gamma correction (deprecated).
        /// </summary>
        /// <returns>Gamma DTO, or null if unavailable.</returns>
        [Obsolete("Deprecated by NVAPI. Prefer GetConfig/SetConfig.")]
        public unsafe NVAPIVioGammaDto? GetGamma()
        {
            ThrowIfDisposed();

            var getGamma = GetDelegate<NvApiVioGetGammaDelegate>(NVAPIVideoHelper.NvApiIdVioGetGamma, "NvAPI_VIO_GetGamma");
            var gamma = new _NVVIOGAMMACORRECTION { version = NVAPI.NVVIOGAMMACORRECTION_VER };

            var status = getGamma((NvVioHandle__*)_handle, &gamma);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIVioGammaDto.FromNative(gamma);

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Set VIO gamma correction (deprecated).
        /// </summary>
        /// <param name="gamma">Gamma DTO.</param>
        /// <returns>True if applied, null if unsupported.</returns>
        [Obsolete("Deprecated by NVAPI. Prefer GetConfig/SetConfig.")]
        public unsafe bool? SetGamma(NVAPIVioGammaDto gamma)
        {
            ThrowIfDisposed();

            var setGamma = GetDelegate<NvApiVioSetGammaDelegate>(NVAPIVideoHelper.NvApiIdVioSetGamma, "NvAPI_VIO_SetGamma");
            var native = gamma.ToNative();

            var status = setGamma((NvVioHandle__*)_handle, &native);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get VIO sync delay (deprecated).
        /// </summary>
        /// <returns>Sync delay DTO, or null if unavailable.</returns>
        [Obsolete("Deprecated by NVAPI. Prefer GetConfig/SetConfig.")]
        public unsafe NVAPIVioSyncDelayDto? GetSyncDelay()
        {
            ThrowIfDisposed();

            var getDelay = GetDelegate<NvApiVioGetSyncDelayDelegate>(NVAPIVideoHelper.NvApiIdVioGetSyncDelay, "NvAPI_VIO_GetSyncDelay");
            var delay = new _NVVIOSYNCDELAY { version = NVAPI.NVVIOSYNCDELAY_VER };

            var status = getDelay((NvVioHandle__*)_handle, &delay);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIVioSyncDelayDto.FromNative(delay);

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Set VIO sync delay (deprecated).
        /// </summary>
        /// <param name="delay">Sync delay DTO.</param>
        /// <returns>True if applied, null if unsupported.</returns>
        [Obsolete("Deprecated by NVAPI. Prefer GetConfig/SetConfig.")]
        public unsafe bool? SetSyncDelay(NVAPIVioSyncDelayDto delay)
        {
            ThrowIfDisposed();

            var setDelay = GetDelegate<NvApiVioSetSyncDelayDelegate>(NVAPIVideoHelper.NvApiIdVioSetSyncDelay, "NvAPI_VIO_SetSyncDelay");
            var native = delay.ToNative();

            var status = setDelay((NvVioHandle__*)_handle, &native);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get PCI information for the VIO device.
        /// </summary>
        /// <returns>PCI info DTO, or null if unavailable.</returns>
        public unsafe NVAPIVioPciInfoDto? GetPciInfo()
        {
            ThrowIfDisposed();

            var getPciInfo = GetDelegate<NvApiVioGetPciInfoDelegate>(NVAPIVideoHelper.NvApiIdVioGetPciInfo, "NvAPI_VIO_GetPCIInfo");
            var info = new _NVVIOPCIINFO { version = NVAPI.NVVIOPCIINFO_VER };

            var status = getPciInfo((NvVioHandle__*)_handle, &info);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIVioPciInfoDto.FromNative(info);

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Check whether the VIO device is running.
        /// </summary>
        /// <returns>True if running, false if not, or null if unsupported.</returns>
        public unsafe bool? IsRunning()
        {
            ThrowIfDisposed();

            var isRunning = GetDelegate<NvApiVioIsRunningDelegate>(NVAPIVideoHelper.NvApiIdVioIsRunning, "NvAPI_VIO_IsRunning");
            var status = isRunning((NvVioHandle__*)_handle);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_ERROR)
                return false;

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Start the VIO device.
        /// </summary>
        /// <returns>True if started, null if unsupported.</returns>
        public unsafe bool? Start()
        {
            ThrowIfDisposed();

            var start = GetDelegate<NvApiVioStartDelegate>(NVAPIVideoHelper.NvApiIdVioStart, "NvAPI_VIO_Start");
            var status = start((NvVioHandle__*)_handle);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Stop the VIO device.
        /// </summary>
        /// <returns>True if stopped, null if unsupported.</returns>
        public unsafe bool? Stop()
        {
            ThrowIfDisposed();

            var stop = GetDelegate<NvApiVioStopDelegate>(NVAPIVideoHelper.NvApiIdVioStop, "NvAPI_VIO_Stop");
            var status = stop((NvVioHandle__*)_handle);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Check frame lock mode compatibility.
        /// </summary>
        /// <param name="sourceIndex">Source enum index.</param>
        /// <param name="destIndex">Destination enum index.</param>
        /// <returns>True if compatible, false if not, or null if unsupported.</returns>
        public unsafe bool? IsFrameLockModeCompatible(uint sourceIndex, uint destIndex)
        {
            ThrowIfDisposed();

            var check = GetDelegate<NvApiVioIsFrameLockModeCompatibleDelegate>(
                NVAPIVideoHelper.NvApiIdVioIsFrameLockModeCompatible,
                "NvAPI_VIO_IsFrameLockModeCompatible");

            uint compatible = 0;
            var status = check((NvVioHandle__*)_handle, sourceIndex, destIndex, &compatible);
            if (status == _NvAPI_Status.NVAPI_OK)
                return compatible != 0;

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Enumerate signal formats.
        /// </summary>
        /// <returns>Array of signal formats, or null if unavailable.</returns>
        public unsafe NVAPIVioSignalFormatDetailDto[]? EnumSignalFormats()
        {
            ThrowIfDisposed();

            var enumerate = GetDelegate<NvApiVioEnumSignalFormatsDelegate>(NVAPIVideoHelper.NvApiIdVioEnumSignalFormats, "NvAPI_VIO_EnumSignalFormats");
            var list = new List<NVAPIVioSignalFormatDetailDto>();

            for (uint i = 0; i < uint.MaxValue; i++)
            {
                var detail = new _NVVIOSIGNALFORMATDETAIL();
                var status = enumerate((NvVioHandle__*)_handle, i, &detail);
                if (status == _NvAPI_Status.NVAPI_END_ENUMERATION)
                    break;

                if (IsUnsupported(status))
                    return null;

                if (status != _NvAPI_Status.NVAPI_OK)
                    throw new NVAPIException(status);

                list.Add(NVAPIVioSignalFormatDetailDto.FromNative(detail));
            }

            return list.ToArray();
        }

        /// <summary>
        /// Enumerate data formats.
        /// </summary>
        /// <returns>Array of data formats, or null if unavailable.</returns>
        public unsafe NVAPIVioDataFormatDetailDto[]? EnumDataFormats()
        {
            ThrowIfDisposed();

            var enumerate = GetDelegate<NvApiVioEnumDataFormatsDelegate>(NVAPIVideoHelper.NvApiIdVioEnumDataFormats, "NvAPI_VIO_EnumDataFormats");
            var list = new List<NVAPIVioDataFormatDetailDto>();

            for (uint i = 0; i < uint.MaxValue; i++)
            {
                var detail = new _NVVIODATAFORMATDETAIL();
                var status = enumerate((NvVioHandle__*)_handle, i, &detail);
                if (status == _NvAPI_Status.NVAPI_END_ENUMERATION)
                    break;

                if (IsUnsupported(status))
                    return null;

                if (status != _NvAPI_Status.NVAPI_OK)
                    throw new NVAPIException(status);

                list.Add(NVAPIVioDataFormatDetailDto.FromNative(detail));
            }

            return list.ToArray();
        }

        private T GetDelegate<T>(uint id, string name) where T : Delegate
        {
            var functionPtr = _apiHelper.Api.TryGetFunctionPointer(id);
            if (functionPtr == IntPtr.Zero)
            {
                throw new NVAPIException(_NvAPI_Status.NVAPI_NO_IMPLEMENTATION, $"NVAPI function '{name}' (0x{id:X8}) not available.");
            }

            return Marshal.GetDelegateForFunctionPointer<T>(functionPtr);
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(NVAPIVioDeviceHelper));

            _apiHelper.ThrowIfDisposed();
        }

        /// <summary>
        /// Dispose the helper and prevent further use.
        /// </summary>
        public void Dispose()
        {
            _disposed = true;
        }

        private static bool IsUnsupported(_NvAPI_Status status)
        {
            return status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiVioGetCapabilitiesDelegate(NvVioHandle__* hVioHandle, _NVVIOCAPS* pCaps);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiVioOpenDelegate(NvVioHandle__* hVioHandle, uint vioClass, _NVVIOOWNERTYPE ownerType);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiVioCloseDelegate(NvVioHandle__* hVioHandle, uint release);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiVioStatusDelegate(NvVioHandle__* hVioHandle, _NVVIOSTATUS* pStatus);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiVioSyncFormatDetectDelegate(NvVioHandle__* hVioHandle, uint* pWait);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiVioGetConfigDelegate(NvVioHandle__* hVioHandle, _NVVIOCONFIG_V3* pConfig);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiVioSetConfigDelegate(NvVioHandle__* hVioHandle, _NVVIOCONFIG_V3* pConfig);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiVioSetCscDelegate(NvVioHandle__* hVioHandle, _NVVIOCOLORCONVERSION* pCsc);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiVioGetCscDelegate(NvVioHandle__* hVioHandle, _NVVIOCOLORCONVERSION* pCsc);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiVioSetGammaDelegate(NvVioHandle__* hVioHandle, _NVVIOGAMMACORRECTION* pGamma);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiVioGetGammaDelegate(NvVioHandle__* hVioHandle, _NVVIOGAMMACORRECTION* pGamma);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiVioSetSyncDelayDelegate(NvVioHandle__* hVioHandle, _NVVIOSYNCDELAY* pDelay);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiVioGetSyncDelayDelegate(NvVioHandle__* hVioHandle, _NVVIOSYNCDELAY* pDelay);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiVioGetPciInfoDelegate(NvVioHandle__* hVioHandle, _NVVIOPCIINFO* pInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiVioIsRunningDelegate(NvVioHandle__* hVioHandle);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiVioStartDelegate(NvVioHandle__* hVioHandle);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiVioStopDelegate(NvVioHandle__* hVioHandle);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiVioIsFrameLockModeCompatibleDelegate(NvVioHandle__* hVioHandle, uint srcIndex, uint destIndex, uint* pbCompatible);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiVioEnumSignalFormatsDelegate(NvVioHandle__* hVioHandle, uint enumIndex, _NVVIOSIGNALFORMATDETAIL* pDetail);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiVioEnumDataFormatsDelegate(NvVioHandle__* hVioHandle, uint enumIndex, _NVVIODATAFORMATDETAIL* pDetail);
    }

    /// <summary>
    /// VIO capabilities DTO.
    /// </summary>
    public readonly struct NVAPIVioCapsDto : IEquatable<NVAPIVioCapsDto>
    {
        public string AdapterName { get; }
        public uint AdapterClass { get; }
        public uint AdapterCaps { get; }
        public uint DipSwitch { get; }
        public uint DipSwitchReserved { get; }
        public uint BoardId { get; }
        public uint DriverMajorVersion { get; }
        public uint DriverMinorVersion { get; }
        public uint FirmwareMajorVersion { get; }
        public uint FirmwareMinorVersion { get; }
        public uint OwnerId { get; }
        public _NVVIOOWNERTYPE OwnerType { get; }

        /// <summary>
        /// Create a VIO capabilities DTO.
        /// </summary>
        /// <param name="adapterName">Adapter name.</param>
        /// <param name="adapterClass">Adapter class.</param>
        /// <param name="adapterCaps">Adapter capability flags.</param>
        /// <param name="dipSwitch">DIP switch value.</param>
        /// <param name="dipSwitchReserved">Reserved DIP switch value.</param>
        /// <param name="boardId">Board identifier.</param>
        /// <param name="driverMajorVersion">Driver major version.</param>
        /// <param name="driverMinorVersion">Driver minor version.</param>
        /// <param name="firmwareMajorVersion">Firmware major version.</param>
        /// <param name="firmwareMinorVersion">Firmware minor version.</param>
        /// <param name="ownerId">Owner identifier.</param>
        /// <param name="ownerType">Owner type.</param>
        public NVAPIVioCapsDto(
            string adapterName,
            uint adapterClass,
            uint adapterCaps,
            uint dipSwitch,
            uint dipSwitchReserved,
            uint boardId,
            uint driverMajorVersion,
            uint driverMinorVersion,
            uint firmwareMajorVersion,
            uint firmwareMinorVersion,
            uint ownerId,
            _NVVIOOWNERTYPE ownerType)
        {
            AdapterName = adapterName ?? string.Empty;
            AdapterClass = adapterClass;
            AdapterCaps = adapterCaps;
            DipSwitch = dipSwitch;
            DipSwitchReserved = dipSwitchReserved;
            BoardId = boardId;
            DriverMajorVersion = driverMajorVersion;
            DriverMinorVersion = driverMinorVersion;
            FirmwareMajorVersion = firmwareMajorVersion;
            FirmwareMinorVersion = firmwareMinorVersion;
            OwnerId = ownerId;
            OwnerType = ownerType;
        }

        /// <summary>
        /// Create a VIO capabilities DTO from native data.
        /// </summary>
        /// <param name="native">Native capabilities data.</param>
        /// <returns>VIO capabilities DTO.</returns>
        public static unsafe NVAPIVioCapsDto FromNative(_NVVIOCAPS native)
        {
            var name = NVAPIApiHelperString.ReadShortString(ref native.adapterName.e0);
            return new NVAPIVioCapsDto(
                name,
                native.adapterClass,
                native.adapterCaps,
                native.dipSwitch,
                native.dipSwitchReserved,
                native.boardID,
                native.driver.majorVersion,
                native.driver.minorVersion,
                native.firmWare.majorVersion,
                native.firmWare.minorVersion,
                native.ownerId,
                native.ownerType);
        }

        /// <summary>
        /// Convert this DTO to native capabilities data.
        /// </summary>
        /// <returns>Native capabilities data.</returns>
        public unsafe _NVVIOCAPS ToNative()
        {
            var native = new _NVVIOCAPS
            {
                version = NVAPI.NVVIOCAPS_VER,
                adapterClass = AdapterClass,
                adapterCaps = AdapterCaps,
                dipSwitch = DipSwitch,
                dipSwitchReserved = DipSwitchReserved,
                boardID = BoardId,
                ownerId = OwnerId,
                ownerType = OwnerType
            };

            native.driver.majorVersion = DriverMajorVersion;
            native.driver.minorVersion = DriverMinorVersion;
            native.firmWare.majorVersion = FirmwareMajorVersion;
            native.firmWare.minorVersion = FirmwareMinorVersion;

            var nameSpan = MemoryMarshal.CreateSpan(ref native.adapterName.e0, NVAPIVideoHelper.VioAdapterNameMax);
            NVAPIVideoHelperString.WriteAnsiString(nameSpan, AdapterName);
            return native;
        }

        /// <summary>
        /// Determine whether this instance equals another VIO capabilities DTO.
        /// </summary>
        /// <param name="other">The other DTO to compare.</param>
        /// <returns>True if the DTOs are equal; otherwise false.</returns>
        public bool Equals(NVAPIVioCapsDto other)
        {
            return string.Equals(AdapterName, other.AdapterName, StringComparison.Ordinal)
                && AdapterClass == other.AdapterClass
                && AdapterCaps == other.AdapterCaps
                && DipSwitch == other.DipSwitch
                && DipSwitchReserved == other.DipSwitchReserved
                && BoardId == other.BoardId
                && DriverMajorVersion == other.DriverMajorVersion
                && DriverMinorVersion == other.DriverMinorVersion
                && FirmwareMajorVersion == other.FirmwareMajorVersion
                && FirmwareMinorVersion == other.FirmwareMinorVersion
                && OwnerId == other.OwnerId
                && OwnerType == other.OwnerType;
        }

        /// <summary>
        /// Determine whether this instance equals another object.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>True if the object is an equivalent DTO; otherwise false.</returns>
        public override bool Equals(object? obj) => obj is NVAPIVioCapsDto other && Equals(other);

        /// <summary>
        /// Get a hash code for this instance.
        /// </summary>
        /// <returns>Hash code for this instance.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = StringComparer.Ordinal.GetHashCode(AdapterName);
                hash = (hash * 31) + AdapterClass.GetHashCode();
                hash = (hash * 31) + AdapterCaps.GetHashCode();
                hash = (hash * 31) + DipSwitch.GetHashCode();
                hash = (hash * 31) + DipSwitchReserved.GetHashCode();
                hash = (hash * 31) + BoardId.GetHashCode();
                hash = (hash * 31) + DriverMajorVersion.GetHashCode();
                hash = (hash * 31) + DriverMinorVersion.GetHashCode();
                hash = (hash * 31) + FirmwareMajorVersion.GetHashCode();
                hash = (hash * 31) + FirmwareMinorVersion.GetHashCode();
                hash = (hash * 31) + OwnerId.GetHashCode();
                hash = (hash * 31) + OwnerType.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Determine whether two VIO capabilities DTOs are equal.
        /// </summary>
        /// <param name="left">Left DTO.</param>
        /// <param name="right">Right DTO.</param>
        /// <returns>True if the DTOs are equal; otherwise false.</returns>
        public static bool operator ==(NVAPIVioCapsDto left, NVAPIVioCapsDto right) => left.Equals(right);

        /// <summary>
        /// Determine whether two VIO capabilities DTOs are not equal.
        /// </summary>
        /// <param name="left">Left DTO.</param>
        /// <param name="right">Right DTO.</param>
        /// <returns>True if the DTOs are not equal; otherwise false.</returns>
        public static bool operator !=(NVAPIVioCapsDto left, NVAPIVioCapsDto right) => !left.Equals(right);
    }

    /// <summary>
    /// VIO PCI info DTO.
    /// </summary>
    public readonly struct NVAPIVioPciInfoDto : IEquatable<NVAPIVioPciInfoDto>
    {
        public uint PciDeviceId { get; }
        public uint PciSubSystemId { get; }
        public uint PciRevisionId { get; }
        public uint PciDomain { get; }
        public uint PciBus { get; }
        public uint PciSlot { get; }
        public _NVVIOPCILINKWIDTH PciLinkWidth { get; }
        public _NVVIOPCILINKRATE PciLinkRate { get; }

        public NVAPIVioPciInfoDto(
            uint pciDeviceId,
            uint pciSubSystemId,
            uint pciRevisionId,
            uint pciDomain,
            uint pciBus,
            uint pciSlot,
            _NVVIOPCILINKWIDTH pciLinkWidth,
            _NVVIOPCILINKRATE pciLinkRate)
        {
            PciDeviceId = pciDeviceId;
            PciSubSystemId = pciSubSystemId;
            PciRevisionId = pciRevisionId;
            PciDomain = pciDomain;
            PciBus = pciBus;
            PciSlot = pciSlot;
            PciLinkWidth = pciLinkWidth;
            PciLinkRate = pciLinkRate;
        }

        public static NVAPIVioPciInfoDto FromNative(_NVVIOPCIINFO native)
        {
            return new NVAPIVioPciInfoDto(
                native.pciDeviceId,
                native.pciSubSystemId,
                native.pciRevisionId,
                native.pciDomain,
                native.pciBus,
                native.pciSlot,
                native.pciLinkWidth,
                native.pciLinkRate);
        }

        public _NVVIOPCIINFO ToNative()
        {
            return new _NVVIOPCIINFO
            {
                version = NVAPI.NVVIOPCIINFO_VER,
                pciDeviceId = PciDeviceId,
                pciSubSystemId = PciSubSystemId,
                pciRevisionId = PciRevisionId,
                pciDomain = PciDomain,
                pciBus = PciBus,
                pciSlot = PciSlot,
                pciLinkWidth = PciLinkWidth,
                pciLinkRate = PciLinkRate
            };
        }

        public bool Equals(NVAPIVioPciInfoDto other)
        {
            return PciDeviceId == other.PciDeviceId
                && PciSubSystemId == other.PciSubSystemId
                && PciRevisionId == other.PciRevisionId
                && PciDomain == other.PciDomain
                && PciBus == other.PciBus
                && PciSlot == other.PciSlot
                && PciLinkWidth == other.PciLinkWidth
                && PciLinkRate == other.PciLinkRate;
        }

        public override bool Equals(object? obj) => obj is NVAPIVioPciInfoDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = PciDeviceId.GetHashCode();
                hash = (hash * 31) + PciSubSystemId.GetHashCode();
                hash = (hash * 31) + PciRevisionId.GetHashCode();
                hash = (hash * 31) + PciDomain.GetHashCode();
                hash = (hash * 31) + PciBus.GetHashCode();
                hash = (hash * 31) + PciSlot.GetHashCode();
                hash = (hash * 31) + PciLinkWidth.GetHashCode();
                hash = (hash * 31) + PciLinkRate.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIVioPciInfoDto left, NVAPIVioPciInfoDto right) => left.Equals(right);
        public static bool operator !=(NVAPIVioPciInfoDto left, NVAPIVioPciInfoDto right) => !left.Equals(right);
    }

    /// <summary>
    /// VIO signal format detail DTO.
    /// </summary>
    public readonly struct NVAPIVioSignalFormatDetailDto : IEquatable<NVAPIVioSignalFormatDetailDto>
    {
        public _NVVIOSIGNALFORMAT SignalFormat { get; }
        public _NVVIOVIDEOMODE VideoMode { get; }

        public NVAPIVioSignalFormatDetailDto(_NVVIOSIGNALFORMAT signalFormat, _NVVIOVIDEOMODE videoMode)
        {
            SignalFormat = signalFormat;
            VideoMode = videoMode;
        }

        public static NVAPIVioSignalFormatDetailDto FromNative(_NVVIOSIGNALFORMATDETAIL native)
        {
            return new NVAPIVioSignalFormatDetailDto(native.signalFormat, native.videoMode);
        }

        public _NVVIOSIGNALFORMATDETAIL ToNative()
        {
            return new _NVVIOSIGNALFORMATDETAIL
            {
                signalFormat = SignalFormat,
                videoMode = VideoMode
            };
        }

        public bool Equals(NVAPIVioSignalFormatDetailDto other)
        {
            return SignalFormat == other.SignalFormat && VideoMode.Equals(other.VideoMode);
        }

        public override bool Equals(object? obj) => obj is NVAPIVioSignalFormatDetailDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = SignalFormat.GetHashCode();
                hash = (hash * 31) + VideoMode.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIVioSignalFormatDetailDto left, NVAPIVioSignalFormatDetailDto right) => left.Equals(right);
        public static bool operator !=(NVAPIVioSignalFormatDetailDto left, NVAPIVioSignalFormatDetailDto right) => !left.Equals(right);
    }

    /// <summary>
    /// VIO data format detail DTO.
    /// </summary>
    public readonly struct NVAPIVioDataFormatDetailDto : IEquatable<NVAPIVioDataFormatDetailDto>
    {
        public _NVVIODATAFORMAT DataFormat { get; }
        public uint VioCaps { get; }

        public NVAPIVioDataFormatDetailDto(_NVVIODATAFORMAT dataFormat, uint vioCaps)
        {
            DataFormat = dataFormat;
            VioCaps = vioCaps;
        }

        public static NVAPIVioDataFormatDetailDto FromNative(_NVVIODATAFORMATDETAIL native)
        {
            return new NVAPIVioDataFormatDetailDto(native.dataFormat, native.vioCaps);
        }

        public _NVVIODATAFORMATDETAIL ToNative()
        {
            return new _NVVIODATAFORMATDETAIL
            {
                dataFormat = DataFormat,
                vioCaps = VioCaps
            };
        }

        public bool Equals(NVAPIVioDataFormatDetailDto other)
        {
            return DataFormat == other.DataFormat && VioCaps == other.VioCaps;
        }

        public override bool Equals(object? obj) => obj is NVAPIVioDataFormatDetailDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = DataFormat.GetHashCode();
                hash = (hash * 31) + VioCaps.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIVioDataFormatDetailDto left, NVAPIVioDataFormatDetailDto right) => left.Equals(right);
        public static bool operator !=(NVAPIVioDataFormatDetailDto left, NVAPIVioDataFormatDetailDto right) => !left.Equals(right);
    }

    /// <summary>
    /// VIO sync delay DTO.
    /// </summary>
    public readonly struct NVAPIVioSyncDelayDto : IEquatable<NVAPIVioSyncDelayDto>
    {
        public uint HorizontalDelay { get; }
        public uint VerticalDelay { get; }

        public NVAPIVioSyncDelayDto(uint horizontalDelay, uint verticalDelay)
        {
            HorizontalDelay = horizontalDelay;
            VerticalDelay = verticalDelay;
        }

        public static NVAPIVioSyncDelayDto FromNative(_NVVIOSYNCDELAY native)
        {
            return new NVAPIVioSyncDelayDto(native.horizontalDelay, native.verticalDelay);
        }

        public _NVVIOSYNCDELAY ToNative()
        {
            return new _NVVIOSYNCDELAY
            {
                version = NVAPI.NVVIOSYNCDELAY_VER,
                horizontalDelay = HorizontalDelay,
                verticalDelay = VerticalDelay
            };
        }

        public bool Equals(NVAPIVioSyncDelayDto other)
        {
            return HorizontalDelay == other.HorizontalDelay && VerticalDelay == other.VerticalDelay;
        }

        public override bool Equals(object? obj) => obj is NVAPIVioSyncDelayDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = HorizontalDelay.GetHashCode();
                hash = (hash * 31) + VerticalDelay.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIVioSyncDelayDto left, NVAPIVioSyncDelayDto right) => left.Equals(right);
        public static bool operator !=(NVAPIVioSyncDelayDto left, NVAPIVioSyncDelayDto right) => !left.Equals(right);
    }

    /// <summary>
    /// VIO color conversion DTO.
    /// </summary>
    public readonly struct NVAPIVioColorConversionDto : IEquatable<NVAPIVioColorConversionDto>
    {
        public float[] ColorMatrix { get; }
        public float[] ColorOffset { get; }
        public float[] ColorScale { get; }
        public bool CompositeSafe { get; }

        public NVAPIVioColorConversionDto(float[] colorMatrix, float[] colorOffset, float[] colorScale, bool compositeSafe)
        {
            ColorMatrix = colorMatrix ?? Array.Empty<float>();
            ColorOffset = colorOffset ?? Array.Empty<float>();
            ColorScale = colorScale ?? Array.Empty<float>();
            CompositeSafe = compositeSafe;
        }

        public static NVAPIVioColorConversionDto FromNative(_NVVIOCOLORCONVERSION native)
        {
            var matrix = new float[9];
            var offset = new float[3];
            var scale = new float[3];

            var matrixSpan = MemoryMarshal.CreateSpan(ref native.colorMatrix.e0_0, 9);
            matrixSpan.CopyTo(matrix);
            var offsetSpan = MemoryMarshal.CreateSpan(ref native.colorOffset.e0, 3);
            offsetSpan.CopyTo(offset);
            var scaleSpan = MemoryMarshal.CreateSpan(ref native.colorScale.e0, 3);
            scaleSpan.CopyTo(scale);

            return new NVAPIVioColorConversionDto(matrix, offset, scale, native.compositeSafe != 0);
        }

        public unsafe _NVVIOCOLORCONVERSION ToNative()
        {
            var native = new _NVVIOCOLORCONVERSION
            {
                version = NVAPI.NVVIOCOLORCONVERSION_VER,
                compositeSafe = CompositeSafe ? 1u : 0u
            };

            var matrixSpan = MemoryMarshal.CreateSpan(ref native.colorMatrix.e0_0, 9);
            var offsetSpan = MemoryMarshal.CreateSpan(ref native.colorOffset.e0, 3);
            var scaleSpan = MemoryMarshal.CreateSpan(ref native.colorScale.e0, 3);

            matrixSpan.Clear();
            offsetSpan.Clear();
            scaleSpan.Clear();

            if (ColorMatrix != null)
                ColorMatrix.AsSpan(0, Math.Min(ColorMatrix.Length, matrixSpan.Length)).CopyTo(matrixSpan);
            if (ColorOffset != null)
                ColorOffset.AsSpan(0, Math.Min(ColorOffset.Length, offsetSpan.Length)).CopyTo(offsetSpan);
            if (ColorScale != null)
                ColorScale.AsSpan(0, Math.Min(ColorScale.Length, scaleSpan.Length)).CopyTo(scaleSpan);

            return native;
        }

        public bool Equals(NVAPIVioColorConversionDto other)
        {
            return CompositeSafe == other.CompositeSafe
                && DtoHelpers.SequenceEquals(ColorMatrix, other.ColorMatrix)
                && DtoHelpers.SequenceEquals(ColorOffset, other.ColorOffset)
                && DtoHelpers.SequenceEquals(ColorScale, other.ColorScale);
        }

        public override bool Equals(object? obj) => obj is NVAPIVioColorConversionDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = CompositeSafe.GetHashCode();
                hash = (hash * 31) + DtoHelpers.SequenceHashCode(ColorMatrix);
                hash = (hash * 31) + DtoHelpers.SequenceHashCode(ColorOffset);
                hash = (hash * 31) + DtoHelpers.SequenceHashCode(ColorScale);
                return hash;
            }
        }

        public static bool operator ==(NVAPIVioColorConversionDto left, NVAPIVioColorConversionDto right) => left.Equals(right);
        public static bool operator !=(NVAPIVioColorConversionDto left, NVAPIVioColorConversionDto right) => !left.Equals(right);
    }

    /// <summary>
    /// VIO configuration DTO (raw bytes due to union layout).
    /// </summary>
    public readonly struct NVAPIVioConfigDto : IEquatable<NVAPIVioConfigDto>
    {
        public byte[] RawBytes { get; }

        public NVAPIVioConfigDto(byte[] rawBytes)
        {
            RawBytes = rawBytes ?? Array.Empty<byte>();
        }

        public static NVAPIVioConfigDto CreateDefault()
        {
            var native = new _NVVIOCONFIG_V3 { version = NVAPI.NVVIOCONFIG_VER };
            return FromNative(native);
        }

        public static NVAPIVioConfigDto FromNative(_NVVIOCONFIG_V3 native)
        {
            var size = Marshal.SizeOf<_NVVIOCONFIG_V3>();
            var bytes = new byte[size];
            MemoryMarshal.Write(bytes.AsSpan(), in native);
            return new NVAPIVioConfigDto(bytes);
        }

        public _NVVIOCONFIG_V3 ToNative()
        {
            var native = new _NVVIOCONFIG_V3 { version = NVAPI.NVVIOCONFIG_VER };
            var size = Marshal.SizeOf<_NVVIOCONFIG_V3>();
            if (RawBytes != null && RawBytes.Length >= size)
                native = MemoryMarshal.Read<_NVVIOCONFIG_V3>(RawBytes);

            native.version = NVAPI.NVVIOCONFIG_VER;
            return native;
        }

        public bool Equals(NVAPIVioConfigDto other) => DtoHelpers.SequenceEquals(RawBytes, other.RawBytes);

        public override bool Equals(object? obj) => obj is NVAPIVioConfigDto other && Equals(other);

        public override int GetHashCode() => DtoHelpers.SequenceHashCode(RawBytes);

        public static bool operator ==(NVAPIVioConfigDto left, NVAPIVioConfigDto right) => left.Equals(right);
        public static bool operator !=(NVAPIVioConfigDto left, NVAPIVioConfigDto right) => !left.Equals(right);
    }

    /// <summary>
    /// VIO status DTO (raw bytes due to union layout).
    /// </summary>
    public readonly struct NVAPIVioStatusDto : IEquatable<NVAPIVioStatusDto>
    {
        public byte[] RawBytes { get; }

        public NVAPIVioStatusDto(byte[] rawBytes)
        {
            RawBytes = rawBytes ?? Array.Empty<byte>();
        }

        public static NVAPIVioStatusDto CreateDefault()
        {
            var native = new _NVVIOSTATUS { version = NVAPI.NVVIOSTATUS_VER };
            return FromNative(native);
        }

        public static NVAPIVioStatusDto FromNative(_NVVIOSTATUS native)
        {
            var size = Marshal.SizeOf<_NVVIOSTATUS>();
            var bytes = new byte[size];
            MemoryMarshal.Write(bytes.AsSpan(), in native);
            return new NVAPIVioStatusDto(bytes);
        }

        public _NVVIOSTATUS ToNative()
        {
            var native = new _NVVIOSTATUS { version = NVAPI.NVVIOSTATUS_VER };
            var size = Marshal.SizeOf<_NVVIOSTATUS>();
            if (RawBytes != null && RawBytes.Length >= size)
                native = MemoryMarshal.Read<_NVVIOSTATUS>(RawBytes);

            native.version = NVAPI.NVVIOSTATUS_VER;
            return native;
        }

        public bool Equals(NVAPIVioStatusDto other) => DtoHelpers.SequenceEquals(RawBytes, other.RawBytes);

        public override bool Equals(object? obj) => obj is NVAPIVioStatusDto other && Equals(other);

        public override int GetHashCode() => DtoHelpers.SequenceHashCode(RawBytes);

        public static bool operator ==(NVAPIVioStatusDto left, NVAPIVioStatusDto right) => left.Equals(right);
        public static bool operator !=(NVAPIVioStatusDto left, NVAPIVioStatusDto right) => !left.Equals(right);
    }

    /// <summary>
    /// VIO gamma correction DTO (raw bytes due to union layout).
    /// </summary>
    public readonly struct NVAPIVioGammaDto : IEquatable<NVAPIVioGammaDto>
    {
        public byte[] RawBytes { get; }

        public NVAPIVioGammaDto(byte[] rawBytes)
        {
            RawBytes = rawBytes ?? Array.Empty<byte>();
        }

        public static NVAPIVioGammaDto CreateDefault()
        {
            var native = new _NVVIOGAMMACORRECTION { version = NVAPI.NVVIOGAMMACORRECTION_VER };
            return FromNative(native);
        }

        public static NVAPIVioGammaDto FromNative(_NVVIOGAMMACORRECTION native)
        {
            var size = Marshal.SizeOf<_NVVIOGAMMACORRECTION>();
            var bytes = new byte[size];
            MemoryMarshal.Write(bytes.AsSpan(), in native);
            return new NVAPIVioGammaDto(bytes);
        }

        public _NVVIOGAMMACORRECTION ToNative()
        {
            var native = new _NVVIOGAMMACORRECTION { version = NVAPI.NVVIOGAMMACORRECTION_VER };
            var size = Marshal.SizeOf<_NVVIOGAMMACORRECTION>();
            if (RawBytes != null && RawBytes.Length >= size)
                native = MemoryMarshal.Read<_NVVIOGAMMACORRECTION>(RawBytes);

            native.version = NVAPI.NVVIOGAMMACORRECTION_VER;
            return native;
        }

        public bool Equals(NVAPIVioGammaDto other) => DtoHelpers.SequenceEquals(RawBytes, other.RawBytes);

        public override bool Equals(object? obj) => obj is NVAPIVioGammaDto other && Equals(other);

        public override int GetHashCode() => DtoHelpers.SequenceHashCode(RawBytes);

        public static bool operator ==(NVAPIVioGammaDto left, NVAPIVioGammaDto right) => left.Equals(right);
        public static bool operator !=(NVAPIVioGammaDto left, NVAPIVioGammaDto right) => !left.Equals(right);
    }

    /// <summary>
    /// VIO topology DTO.
    /// </summary>
    public readonly struct NVAPIVioTopologyDto : IEquatable<NVAPIVioTopologyDto>
    {
        public uint TotalDeviceCount { get; }
        public NVAPIVioTopologyTargetDto[] Targets { get; }

        public NVAPIVioTopologyDto(uint totalDeviceCount, NVAPIVioTopologyTargetDto[] targets)
        {
            TotalDeviceCount = totalDeviceCount;
            Targets = targets ?? Array.Empty<NVAPIVioTopologyTargetDto>();
        }

        public static NVAPIVioTopologyDto FromNative(_NV_VIO_TOPOLOGY native)
        {
            var count = (int)Math.Min(native.vioTotalDeviceCount, NVAPI.NVAPI_MAX_VIO_DEVICES);
            var span = MemoryMarshal.CreateSpan(ref native.vioTarget.e0, NVAPI.NVAPI_MAX_VIO_DEVICES);
            var targets = new NVAPIVioTopologyTargetDto[count];
            for (var i = 0; i < count; i++)
            {
                targets[i] = NVAPIVioTopologyTargetDto.FromNative(span[i]);
            }

            return new NVAPIVioTopologyDto(native.vioTotalDeviceCount, targets);
        }

        public _NV_VIO_TOPOLOGY ToNative()
        {
            var native = new _NV_VIO_TOPOLOGY
            {
                version = NVAPI.NV_VIO_TOPOLOGY_VER,
                vioTotalDeviceCount = TotalDeviceCount
            };

            var span = MemoryMarshal.CreateSpan(ref native.vioTarget.e0, NVAPI.NVAPI_MAX_VIO_DEVICES);
            span.Clear();
            var count = Math.Min(Targets.Length, span.Length);
            for (var i = 0; i < count; i++)
            {
                span[i] = Targets[i].ToNative();
            }

            return native;
        }

        public bool Equals(NVAPIVioTopologyDto other)
        {
            return TotalDeviceCount == other.TotalDeviceCount
                && DtoHelpers.SequenceEquals(Targets, other.Targets);
        }

        public override bool Equals(object? obj) => obj is NVAPIVioTopologyDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = TotalDeviceCount.GetHashCode();
                hash = (hash * 31) + DtoHelpers.SequenceHashCode(Targets);
                return hash;
            }
        }

        public static bool operator ==(NVAPIVioTopologyDto left, NVAPIVioTopologyDto right) => left.Equals(right);
        public static bool operator !=(NVAPIVioTopologyDto left, NVAPIVioTopologyDto right) => !left.Equals(right);
    }

    /// <summary>
    /// VIO topology target DTO.
    /// </summary>
    public readonly struct NVAPIVioTopologyTargetDto : IEquatable<NVAPIVioTopologyTargetDto>
    {
        public IntPtr PhysicalGpuHandle { get; }
        public IntPtr VioHandle { get; }
        public uint VioId { get; }
        public uint OutputId { get; }

        public NVAPIVioTopologyTargetDto(IntPtr physicalGpuHandle, IntPtr vioHandle, uint vioId, uint outputId)
        {
            PhysicalGpuHandle = physicalGpuHandle;
            VioHandle = vioHandle;
            VioId = vioId;
            OutputId = outputId;
        }

        public static unsafe NVAPIVioTopologyTargetDto FromNative(NVVIOTOPOLOGYTARGET native)
        {
            return new NVAPIVioTopologyTargetDto(
                (IntPtr)native.hPhysicalGpu,
                (IntPtr)native.hVioHandle,
                native.vioId,
                native.outputId);
        }

        public unsafe NVVIOTOPOLOGYTARGET ToNative()
        {
            return new NVVIOTOPOLOGYTARGET
            {
                hPhysicalGpu = null,
                hVioHandle = null,
                vioId = VioId,
                outputId = OutputId
            };
        }

        public bool Equals(NVAPIVioTopologyTargetDto other)
        {
            return PhysicalGpuHandle == other.PhysicalGpuHandle
                && VioHandle == other.VioHandle
                && VioId == other.VioId
                && OutputId == other.OutputId;
        }

        public override bool Equals(object? obj) => obj is NVAPIVioTopologyTargetDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = PhysicalGpuHandle.GetHashCode();
                hash = (hash * 31) + VioHandle.GetHashCode();
                hash = (hash * 31) + VioId.GetHashCode();
                hash = (hash * 31) + OutputId.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIVioTopologyTargetDto left, NVAPIVioTopologyTargetDto right) => left.Equals(right);
        public static bool operator !=(NVAPIVioTopologyTargetDto left, NVAPIVioTopologyTargetDto right) => !left.Equals(right);
    }

    internal static class NVAPIVideoHelperString
    {
        public static void WriteAnsiString(Span<sbyte> destination, string value)
        {
            destination.Clear();
            if (string.IsNullOrEmpty(value) || destination.Length == 0)
                return;

            var max = destination.Length - 1;
            var bytes = Encoding.ASCII.GetBytes(value);
            var length = Math.Min(bytes.Length, max);
            for (var i = 0; i < length; i++)
            {
                destination[i] = (sbyte)bytes[i];
            }

            destination[length] = 0;
        }
    }
}
