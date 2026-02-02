using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <summary>
    /// Facade helper for NVAPI Driver Settings (DRS).
    /// </summary>
    public sealed class NVAPIDrsHelper : IDisposable
    {
        private const uint NvApiIdDrsCreateSession = 0x0694D52E;
        private const uint NvApiIdDrsDestroySession = 0xDAD9CFF8;
        private const uint NvApiIdDrsLoadSettings = 0x375DBD6B;
        private const uint NvApiIdDrsSaveSettings = 0xFCBC7E14;
        private const uint NvApiIdDrsLoadSettingsFromFile = 0xD3EDE889;
        private const uint NvApiIdDrsSaveSettingsToFile = 0x2BE25DF8;
        private const uint NvApiIdDrsCreateProfile = 0xCC176068;
        private const uint NvApiIdDrsDeleteProfile = 0x17093206;
        private const uint NvApiIdDrsSetCurrentGlobalProfile = 0x1C89C5DF;
        private const uint NvApiIdDrsGetCurrentGlobalProfile = 0x617BFF9F;
        private const uint NvApiIdDrsGetProfileInfo = 0x61CD6FD6;
        private const uint NvApiIdDrsSetProfileInfo = 0x16ABD3A9;
        private const uint NvApiIdDrsFindProfileByName = 0x7E4A9A0B;
        private const uint NvApiIdDrsEnumProfiles = 0xBC371EE0;
        private const uint NvApiIdDrsGetNumProfiles = 0x1DAE4FBC;
        private const uint NvApiIdDrsCreateApplication = 0x4347A9DE;
        private const uint NvApiIdDrsDeleteApplicationEx = 0xC5EA85A1;
        private const uint NvApiIdDrsDeleteApplication = 0x2C694BC6;
        private const uint NvApiIdDrsGetApplicationInfo = 0xED1F8C69;
        private const uint NvApiIdDrsEnumApplications = 0x7FA2173A;
        private const uint NvApiIdDrsFindApplicationByName = 0xEEE566B2;
        private const uint NvApiIdDrsSetSetting = 0x577DD202;
        private const uint NvApiIdDrsGetSetting = 0x73BF8338;
        private const uint NvApiIdDrsEnumSettings = 0xAE3039DA;
        private const uint NvApiIdDrsEnumAvailableSettingIds = 0xF020614A;
        private const uint NvApiIdDrsEnumAvailableSettingValues = 0x2EC39F90;
        private const uint NvApiIdDrsGetSettingIdFromName = 0xCB7309CD;
        private const uint NvApiIdDrsGetSettingNameFromId = 0xD61CBE6E;
        private const uint NvApiIdDrsDeleteProfileSetting = 0xE4A26362;
        private const uint NvApiIdDrsRestoreAllDefaults = 0x5927B094;
        private const uint NvApiIdDrsRestoreProfileDefault = 0xFA5F6134;
        private const uint NvApiIdDrsRestoreProfileDefaultSetting = 0x53F0381E;
        private const uint NvApiIdDrsGetBaseProfile = 0xDA8466A0;

        private readonly NVAPIApiHelper _apiHelper;
        private IntPtr _session;
        private bool _disposed;

        internal NVAPIDrsHelper(NVAPIApiHelper apiHelper, IntPtr session)
        {
            _apiHelper = apiHelper;
            _session = session;
        }

        ~NVAPIDrsHelper()
        {
            Dispose(false);
        }

        /// <summary>
        /// Create a DRS profile info struct with the version initialized.
        /// </summary>
        public static _NVDRS_PROFILE_V1 CreateProfileInfo()
        {
            return new _NVDRS_PROFILE_V1 { version = NVAPI.NVDRS_PROFILE_VER };
        }

        /// <summary>
        /// Create a DRS application info struct with the version initialized.
        /// </summary>
        public static _NVDRS_APPLICATION_V4 CreateApplicationInfo()
        {
            return new _NVDRS_APPLICATION_V4 { version = NVAPI.NVDRS_APPLICATION_VER };
        }

        /// <summary>
        /// Create a DRS setting info struct with the version initialized.
        /// </summary>
        public static _NVDRS_SETTING_V1 CreateSetting()
        {
            return new _NVDRS_SETTING_V1 { version = NVAPI.NVDRS_SETTING_VER };
        }

        /// <summary>
        /// Create a DRS setting values struct with the version initialized.
        /// </summary>
        public static _NVDRS_SETTING_VALUES CreateSettingValues()
        {
            return new _NVDRS_SETTING_VALUES { version = NVAPI.NVDRS_SETTING_VALUES_VER };
        }

        /// <summary>
        /// Load the DRS settings database into this session.
        /// </summary>
        /// <returns>True if loaded; false if unsupported.</returns>
        public unsafe bool LoadSettings()
        {
            ThrowIfDisposed();

            var load = GetDelegate<NvApiDrsLoadSettingsDelegate>(NvApiIdDrsLoadSettings, "NvAPI_DRS_LoadSettings");
            var status = load(GetSession());
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Save the DRS settings database from this session.
        /// </summary>
        /// <returns>True if saved; false if unsupported.</returns>
        public unsafe bool SaveSettings()
        {
            ThrowIfDisposed();

            var save = GetDelegate<NvApiDrsSaveSettingsDelegate>(NvApiIdDrsSaveSettings, "NvAPI_DRS_SaveSettings");
            var status = save(GetSession());
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Load DRS settings from a file.
        /// </summary>
        /// <param name="filePath">Path to the settings file.</param>
        /// <returns>True if loaded; false if unsupported.</returns>
        public unsafe bool LoadSettingsFromFile(string filePath)
        {
            ThrowIfDisposed();

            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path must be provided.", nameof(filePath));

            var load = GetDelegate<NvApiDrsLoadSettingsFromFileDelegate>(
                NvApiIdDrsLoadSettingsFromFile,
                "NvAPI_DRS_LoadSettingsFromFile");

            Span<ushort> buffer = stackalloc ushort[NVAPI.NVAPI_UNICODE_STRING_MAX];
            WriteUnicodeString(buffer, filePath);

            fixed (ushort* pBuffer = buffer)
            {
                var status = load(GetSession(), pBuffer);
                if (status == _NvAPI_Status.NVAPI_OK)
                    return true;

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                    || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                    || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return false;

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Save DRS settings to a file.
        /// </summary>
        /// <param name="filePath">Path to the settings file.</param>
        /// <returns>True if saved; false if unsupported.</returns>
        public unsafe bool SaveSettingsToFile(string filePath)
        {
            ThrowIfDisposed();

            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path must be provided.", nameof(filePath));

            var save = GetDelegate<NvApiDrsSaveSettingsToFileDelegate>(
                NvApiIdDrsSaveSettingsToFile,
                "NvAPI_DRS_SaveSettingsToFile");

            Span<ushort> buffer = stackalloc ushort[NVAPI.NVAPI_UNICODE_STRING_MAX];
            WriteUnicodeString(buffer, filePath);

            fixed (ushort* pBuffer = buffer)
            {
                var status = save(GetSession(), pBuffer);
                if (status == _NvAPI_Status.NVAPI_OK)
                    return true;

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                    || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                    || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return false;

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Get the number of DRS profiles.
        /// </summary>
        /// <returns>Profile count, or null if unsupported.</returns>
        public unsafe uint? GetNumProfiles()
        {
            ThrowIfDisposed();

            var getCount = GetDelegate<NvApiDrsGetNumProfilesDelegate>(NvApiIdDrsGetNumProfiles, "NvAPI_DRS_GetNumProfiles");
            uint count = 0;
            var status = getCount(GetSession(), &count);
            if (status == _NvAPI_Status.NVAPI_OK)
                return count;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Enumerate all DRS profiles.
        /// </summary>
        /// <returns>Profiles, or empty if unsupported.</returns>
        public unsafe NVAPIDrsProfileDto[] EnumProfiles()
        {
            ThrowIfDisposed();

            var enumProfiles = GetDelegate<NvApiDrsEnumProfilesDelegate>(NvApiIdDrsEnumProfiles, "NvAPI_DRS_EnumProfiles");
            var results = new List<NVAPIDrsProfileDto>();

            for (uint index = 0; ; index++)
            {
                NvDRSProfileHandle__* handle;
                var status = enumProfiles(GetSession(), index, &handle);

                if (status == _NvAPI_Status.NVAPI_END_ENUMERATION)
                    break;

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                    || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                    || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return Array.Empty<NVAPIDrsProfileDto>();

                if (status != _NvAPI_Status.NVAPI_OK)
                    throw new NVAPIException(status);

                var info = GetProfileInfoInternal(handle);
                if (info.HasValue)
                    results.Add(info.Value);
            }

            return results.Count == 0 ? Array.Empty<NVAPIDrsProfileDto>() : results.ToArray();
        }

        /// <summary>
        /// Find a profile by name.
        /// </summary>
        /// <param name="profileName">Profile name.</param>
        /// <returns>Profile info, or null if not found/unsupported.</returns>
        public unsafe NVAPIDrsProfileDto? FindProfileByName(string profileName)
        {
            ThrowIfDisposed();

            if (string.IsNullOrWhiteSpace(profileName))
                throw new ArgumentException("Profile name must be provided.", nameof(profileName));

            var find = GetDelegate<NvApiDrsFindProfileByNameDelegate>(NvApiIdDrsFindProfileByName, "NvAPI_DRS_FindProfileByName");
            Span<ushort> buffer = stackalloc ushort[NVAPI.NVAPI_UNICODE_STRING_MAX];
            WriteUnicodeString(buffer, profileName);

            fixed (ushort* pBuffer = buffer)
            {
                NvDRSProfileHandle__* handle;
                var status = find(GetSession(), pBuffer, &handle);
                if (status == _NvAPI_Status.NVAPI_OK)
                    return GetProfileInfoInternal(handle);

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                    || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                    || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return null;

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Get the current global profile.
        /// </summary>
        /// <returns>Profile info, or null if unavailable.</returns>
        public unsafe NVAPIDrsProfileDto? GetCurrentGlobalProfile()
        {
            ThrowIfDisposed();

            var getCurrent = GetDelegate<NvApiDrsGetCurrentGlobalProfileDelegate>(
                NvApiIdDrsGetCurrentGlobalProfile,
                "NvAPI_DRS_GetCurrentGlobalProfile");
            NvDRSProfileHandle__* handle;
            var status = getCurrent(GetSession(), &handle);

            if (status == _NvAPI_Status.NVAPI_OK)
                return GetProfileInfoInternal(handle);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Set the current global profile by name.
        /// </summary>
        /// <param name="profileName">Profile name.</param>
        /// <returns>True if set; false if unsupported.</returns>
        public unsafe bool SetCurrentGlobalProfile(string profileName)
        {
            ThrowIfDisposed();

            if (string.IsNullOrWhiteSpace(profileName))
                throw new ArgumentException("Profile name must be provided.", nameof(profileName));

            var setCurrent = GetDelegate<NvApiDrsSetCurrentGlobalProfileDelegate>(
                NvApiIdDrsSetCurrentGlobalProfile,
                "NvAPI_DRS_SetCurrentGlobalProfile");
            Span<ushort> buffer = stackalloc ushort[NVAPI.NVAPI_UNICODE_STRING_MAX];
            WriteUnicodeString(buffer, profileName);

            fixed (ushort* pBuffer = buffer)
            {
                var status = setCurrent(GetSession(), pBuffer);
                if (status == _NvAPI_Status.NVAPI_OK)
                    return true;

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                    || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                    || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return false;

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Get the base profile.
        /// </summary>
        /// <returns>Profile info, or null if unavailable.</returns>
        public unsafe NVAPIDrsProfileDto? GetBaseProfile()
        {
            ThrowIfDisposed();

            var getBase = GetDelegate<NvApiDrsGetBaseProfileDelegate>(NvApiIdDrsGetBaseProfile, "NvAPI_DRS_GetBaseProfile");
            NvDRSProfileHandle__* handle;
            var status = getBase(GetSession(), &handle);

            if (status == _NvAPI_Status.NVAPI_OK)
                return GetProfileInfoInternal(handle);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get profile info for an existing profile handle.
        /// </summary>
        /// <param name="profile">Profile DTO.</param>
        /// <returns>Profile info, or null if unavailable.</returns>
        public unsafe NVAPIDrsProfileDto? GetProfileInfo(NVAPIDrsProfileDto profile)
        {
            ThrowIfDisposed();

            if (profile.Handle == IntPtr.Zero)
                return null;

            return GetProfileInfoInternal((NvDRSProfileHandle__*)profile.Handle);
        }

        /// <summary>
        /// Update profile info.
        /// </summary>
        /// <param name="profile">Profile DTO with desired values.</param>
        /// <returns>True if updated; false if unsupported.</returns>
        public unsafe bool SetProfileInfo(NVAPIDrsProfileDto profile)
        {
            ThrowIfDisposed();

            if (profile.Handle == IntPtr.Zero)
                return false;

            var current = GetProfileInfo(profile);
            if (current.HasValue && current.Value.Equals(profile))
                return true;

            var setInfo = GetDelegate<NvApiDrsSetProfileInfoDelegate>(NvApiIdDrsSetProfileInfo, "NvAPI_DRS_SetProfileInfo");
            var native = profile.ToNative();
            var status = setInfo(GetSession(), (NvDRSProfileHandle__*)profile.Handle, &native);

            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Create a new DRS profile.
        /// </summary>
        /// <param name="profileInfo">Profile info.</param>
        /// <returns>Created profile, or null if unsupported.</returns>
        public unsafe NVAPIDrsProfileDto? CreateProfile(NVAPIDrsProfileDto profileInfo)
        {
            ThrowIfDisposed();

            var create = GetDelegate<NvApiDrsCreateProfileDelegate>(NvApiIdDrsCreateProfile, "NvAPI_DRS_CreateProfile");
            var native = profileInfo.ToNative();
            NvDRSProfileHandle__* handle;
            var status = create(GetSession(), &native, &handle);

            if (status == _NvAPI_Status.NVAPI_OK)
            {
                var info = GetProfileInfoInternal(handle);
                if (info.HasValue)
                    return info.Value;

                return NVAPIDrsProfileDto.FromNative(handle, native);
            }

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Delete a profile.
        /// </summary>
        /// <param name="profile">Profile to delete.</param>
        /// <returns>True if deleted; false if unsupported.</returns>
        public unsafe bool DeleteProfile(NVAPIDrsProfileDto profile)
        {
            ThrowIfDisposed();

            if (profile.Handle == IntPtr.Zero)
                return false;

            var delete = GetDelegate<NvApiDrsDeleteProfileDelegate>(NvApiIdDrsDeleteProfile, "NvAPI_DRS_DeleteProfile");
            var status = delete(GetSession(), (NvDRSProfileHandle__*)profile.Handle);

            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Enumerate applications associated with a profile.
        /// </summary>
        /// <param name="profile">Profile to enumerate.</param>
        /// <returns>Applications, or empty if unsupported.</returns>
        public unsafe NVAPIDrsApplicationDto[] EnumApplications(NVAPIDrsProfileDto profile)
        {
            ThrowIfDisposed();

            if (profile.Handle == IntPtr.Zero)
                return Array.Empty<NVAPIDrsApplicationDto>();

            var enumApps = GetDelegate<NvApiDrsEnumApplicationsDelegate>(NvApiIdDrsEnumApplications, "NvAPI_DRS_EnumApplications");
            var results = new List<NVAPIDrsApplicationDto>();
            uint index = 0;

            while (true)
            {
                uint count = 1;
                var native = CreateApplicationInfo();
                var status = enumApps(GetSession(), (NvDRSProfileHandle__*)profile.Handle, index, &count, &native);

                if (status == _NvAPI_Status.NVAPI_END_ENUMERATION)
                    break;

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                    || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                    || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return Array.Empty<NVAPIDrsApplicationDto>();

                if (status != _NvAPI_Status.NVAPI_OK)
                    throw new NVAPIException(status);

                if (count == 0)
                    break;

                results.Add(NVAPIDrsApplicationDto.FromNative(native));
                index += count;
            }

            return results.Count == 0 ? Array.Empty<NVAPIDrsApplicationDto>() : results.ToArray();
        }

        /// <summary>
        /// Get application info by name within a profile.
        /// </summary>
        /// <param name="profile">Profile to search.</param>
        /// <param name="appName">Application name.</param>
        /// <returns>Application info, or null if unavailable.</returns>
        public unsafe NVAPIDrsApplicationDto? GetApplicationInfo(NVAPIDrsProfileDto profile, string appName)
        {
            ThrowIfDisposed();

            if (profile.Handle == IntPtr.Zero)
                return null;

            if (string.IsNullOrWhiteSpace(appName))
                throw new ArgumentException("Application name must be provided.", nameof(appName));

            var getInfo = GetDelegate<NvApiDrsGetApplicationInfoDelegate>(NvApiIdDrsGetApplicationInfo, "NvAPI_DRS_GetApplicationInfo");
            var native = CreateApplicationInfo();
            Span<ushort> buffer = stackalloc ushort[NVAPI.NVAPI_UNICODE_STRING_MAX];
            WriteUnicodeString(buffer, appName);

            fixed (ushort* pBuffer = buffer)
            {
                var status = getInfo(GetSession(), (NvDRSProfileHandle__*)profile.Handle, pBuffer, &native);
                if (status == _NvAPI_Status.NVAPI_OK)
                    return NVAPIDrsApplicationDto.FromNative(native);

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                    || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                    || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return null;

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Find an application by name across profiles.
        /// </summary>
        /// <param name="appName">Application name.</param>
        /// <returns>Search result, or null if not found/unsupported.</returns>
        public unsafe NVAPIDrsApplicationSearchDto? FindApplicationByName(string appName)
        {
            ThrowIfDisposed();

            if (string.IsNullOrWhiteSpace(appName))
                throw new ArgumentException("Application name must be provided.", nameof(appName));

            var find = GetDelegate<NvApiDrsFindApplicationByNameDelegate>(
                NvApiIdDrsFindApplicationByName,
                "NvAPI_DRS_FindApplicationByName");
            Span<ushort> buffer = stackalloc ushort[NVAPI.NVAPI_UNICODE_STRING_MAX];
            WriteUnicodeString(buffer, appName);
            var native = CreateApplicationInfo();

            fixed (ushort* pBuffer = buffer)
            {
                NvDRSProfileHandle__* handle;
                var status = find(GetSession(), pBuffer, &handle, &native);
                if (status == _NvAPI_Status.NVAPI_OK)
                {
                    var profile = GetProfileInfoInternal(handle);
                    if (profile.HasValue)
                        return new NVAPIDrsApplicationSearchDto(profile.Value, NVAPIDrsApplicationDto.FromNative(native));

                    return null;
                }

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                    || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                    || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return null;

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Create an application entry in a profile.
        /// </summary>
        /// <param name="profile">Profile to update.</param>
        /// <param name="application">Application info.</param>
        /// <returns>True if created; false if unsupported.</returns>
        public unsafe bool CreateApplication(NVAPIDrsProfileDto profile, NVAPIDrsApplicationDto application)
        {
            ThrowIfDisposed();

            if (profile.Handle == IntPtr.Zero)
                return false;

            var create = GetDelegate<NvApiDrsCreateApplicationDelegate>(NvApiIdDrsCreateApplication, "NvAPI_DRS_CreateApplication");
            var native = application.ToNative();
            var status = create(GetSession(), (NvDRSProfileHandle__*)profile.Handle, &native);

            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Delete an application entry by name.
        /// </summary>
        /// <param name="profile">Profile to update.</param>
        /// <param name="appName">Application name.</param>
        /// <returns>True if deleted; false if unsupported.</returns>
        public unsafe bool DeleteApplication(NVAPIDrsProfileDto profile, string appName)
        {
            ThrowIfDisposed();

            if (profile.Handle == IntPtr.Zero)
                return false;

            if (string.IsNullOrWhiteSpace(appName))
                throw new ArgumentException("Application name must be provided.", nameof(appName));

            var delete = GetDelegate<NvApiDrsDeleteApplicationDelegate>(NvApiIdDrsDeleteApplication, "NvAPI_DRS_DeleteApplication");
            Span<ushort> buffer = stackalloc ushort[NVAPI.NVAPI_UNICODE_STRING_MAX];
            WriteUnicodeString(buffer, appName);

            fixed (ushort* pBuffer = buffer)
            {
                var status = delete(GetSession(), (NvDRSProfileHandle__*)profile.Handle, pBuffer);
                if (status == _NvAPI_Status.NVAPI_OK)
                    return true;

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                    || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                    || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return false;

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Delete an application entry using a full application descriptor.
        /// </summary>
        /// <param name="profile">Profile to update.</param>
        /// <param name="application">Application info.</param>
        /// <returns>True if deleted; false if unsupported.</returns>
        public unsafe bool DeleteApplicationEx(NVAPIDrsProfileDto profile, NVAPIDrsApplicationDto application)
        {
            ThrowIfDisposed();

            if (profile.Handle == IntPtr.Zero)
                return false;

            var delete = GetDelegate<NvApiDrsDeleteApplicationExDelegate>(NvApiIdDrsDeleteApplicationEx, "NvAPI_DRS_DeleteApplicationEx");
            var native = application.ToNative();
            var status = delete(GetSession(), (NvDRSProfileHandle__*)profile.Handle, &native);

            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get a setting from a profile by ID.
        /// </summary>
        /// <param name="profile">Profile to query.</param>
        /// <param name="settingId">Setting ID.</param>
        /// <returns>Setting info, or null if unavailable.</returns>
        public unsafe NVAPIDrsSettingDto? GetSetting(NVAPIDrsProfileDto profile, uint settingId)
        {
            ThrowIfDisposed();

            if (profile.Handle == IntPtr.Zero)
                return null;

            var getSetting = GetDelegate<NvApiDrsGetSettingDelegate>(NvApiIdDrsGetSetting, "NvAPI_DRS_GetSetting");
            var native = CreateSetting();
            var status = getSetting(GetSession(), (NvDRSProfileHandle__*)profile.Handle, settingId, &native);

            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIDrsSettingDto.FromNative(native);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Set a setting on a profile.
        /// </summary>
        /// <param name="profile">Profile to update.</param>
        /// <param name="setting">Desired setting values.</param>
        /// <returns>True if set; false if unsupported.</returns>
        public unsafe bool SetSetting(NVAPIDrsProfileDto profile, NVAPIDrsSettingDto setting)
        {
            ThrowIfDisposed();

            if (profile.Handle == IntPtr.Zero)
                return false;

            var current = GetSetting(profile, setting.SettingId);
            if (current.HasValue && current.Value.Equals(setting))
                return true;

            var setSetting = GetDelegate<NvApiDrsSetSettingDelegate>(NvApiIdDrsSetSetting, "NvAPI_DRS_SetSetting");
            var native = setting.ToNative();
            var status = setSetting(GetSession(), (NvDRSProfileHandle__*)profile.Handle, &native);

            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Enumerate settings in a profile.
        /// </summary>
        /// <param name="profile">Profile to enumerate.</param>
        /// <returns>Settings, or empty if unsupported.</returns>
        public unsafe NVAPIDrsSettingDto[] EnumSettings(NVAPIDrsProfileDto profile)
        {
            ThrowIfDisposed();

            if (profile.Handle == IntPtr.Zero)
                return Array.Empty<NVAPIDrsSettingDto>();

            var enumSettings = GetDelegate<NvApiDrsEnumSettingsDelegate>(NvApiIdDrsEnumSettings, "NvAPI_DRS_EnumSettings");
            var results = new List<NVAPIDrsSettingDto>();
            uint index = 0;

            while (true)
            {
                uint count = 1;
                var native = CreateSetting();
                var status = enumSettings(GetSession(), (NvDRSProfileHandle__*)profile.Handle, index, &count, &native);

                if (status == _NvAPI_Status.NVAPI_END_ENUMERATION)
                    break;

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                    || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                    || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return Array.Empty<NVAPIDrsSettingDto>();

                if (status != _NvAPI_Status.NVAPI_OK)
                    throw new NVAPIException(status);

                if (count == 0)
                    break;

                results.Add(NVAPIDrsSettingDto.FromNative(native));
                index += count;
            }

            return results.Count == 0 ? Array.Empty<NVAPIDrsSettingDto>() : results.ToArray();
        }

        /// <summary>
        /// Enumerate all available setting IDs recognized by NVAPI.
        /// </summary>
        /// <returns>Setting IDs, or empty if unsupported.</returns>
        public unsafe uint[] EnumAvailableSettingIds()
        {
            ThrowIfDisposed();

            var enumIds = GetDelegate<NvApiDrsEnumAvailableSettingIdsDelegate>(
                NvApiIdDrsEnumAvailableSettingIds,
                "NvAPI_DRS_EnumAvailableSettingIds");

            var capacity = 256u;
            while (true)
            {
                var ids = new uint[capacity];
                var count = capacity;

                fixed (uint* pIds = ids)
                {
                    var status = enumIds(pIds, &count);
                    if (status == _NvAPI_Status.NVAPI_OK)
                    {
                        if (count == 0)
                            return Array.Empty<uint>();

                        var result = new uint[count];
                        Array.Copy(ids, result, count);
                        return result;
                    }

                    if (status == _NvAPI_Status.NVAPI_END_ENUMERATION && count > capacity)
                    {
                        capacity = count;
                        continue;
                    }

                    if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                        || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                        || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                        return Array.Empty<uint>();

                    throw new NVAPIException(status);
                }
            }
        }

        /// <summary>
        /// Enumerate all available values for a given setting.
        /// </summary>
        /// <param name="settingId">Setting ID.</param>
        /// <returns>Setting values, or null if unsupported.</returns>
        public unsafe NVAPIDrsSettingValuesDto? EnumAvailableSettingValues(uint settingId)
        {
            ThrowIfDisposed();

            var enumValues = GetDelegate<NvApiDrsEnumAvailableSettingValuesDelegate>(
                NvApiIdDrsEnumAvailableSettingValues,
                "NvAPI_DRS_EnumAvailableSettingValues");

            var native = CreateSettingValues();
            uint maxValues = 100;
            var status = enumValues(settingId, &maxValues, &native);

            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIDrsSettingValuesDto.FromNative(native);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Resolve a setting ID from a name.
        /// </summary>
        /// <param name="settingName">Setting name.</param>
        /// <returns>Setting ID, or null if unavailable.</returns>
        public unsafe uint? GetSettingIdFromName(string settingName)
        {
            ThrowIfDisposed();

            if (string.IsNullOrWhiteSpace(settingName))
                throw new ArgumentException("Setting name must be provided.", nameof(settingName));

            var getId = GetDelegate<NvApiDrsGetSettingIdFromNameDelegate>(
                NvApiIdDrsGetSettingIdFromName,
                "NvAPI_DRS_GetSettingIdFromName");
            Span<ushort> buffer = stackalloc ushort[NVAPI.NVAPI_UNICODE_STRING_MAX];
            WriteUnicodeString(buffer, settingName);

            fixed (ushort* pBuffer = buffer)
            {
                uint id = 0;
                var status = getId(pBuffer, &id);
                if (status == _NvAPI_Status.NVAPI_OK)
                    return id;

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                    || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                    || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return null;

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Resolve a setting name from its ID.
        /// </summary>
        /// <param name="settingId">Setting ID.</param>
        /// <returns>Setting name, or null if unavailable.</returns>
        public unsafe string? GetSettingNameFromId(uint settingId)
        {
            ThrowIfDisposed();

            var getName = GetDelegate<NvApiDrsGetSettingNameFromIdDelegate>(
                NvApiIdDrsGetSettingNameFromId,
                "NvAPI_DRS_GetSettingNameFromId");
            ushort* namePtr = null;
            var status = getName(settingId, &namePtr);

            if (status == _NvAPI_Status.NVAPI_OK)
            {
                if (namePtr == null)
                    return null;

                return Marshal.PtrToStringUni((IntPtr)namePtr);
            }

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Delete a profile setting by ID.
        /// </summary>
        /// <param name="profile">Profile to update.</param>
        /// <param name="settingId">Setting ID.</param>
        /// <returns>True if deleted; false if unsupported.</returns>
        public unsafe bool DeleteProfileSetting(NVAPIDrsProfileDto profile, uint settingId)
        {
            ThrowIfDisposed();

            if (profile.Handle == IntPtr.Zero)
                return false;

            var delete = GetDelegate<NvApiDrsDeleteProfileSettingDelegate>(
                NvApiIdDrsDeleteProfileSetting,
                "NvAPI_DRS_DeleteProfileSetting");
            var status = delete(GetSession(), (NvDRSProfileHandle__*)profile.Handle, settingId);

            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Restore all defaults in the DRS database.
        /// </summary>
        /// <returns>True if restored; false if unsupported.</returns>
        public unsafe bool RestoreAllDefaults()
        {
            ThrowIfDisposed();

            var restore = GetDelegate<NvApiDrsRestoreAllDefaultsDelegate>(
                NvApiIdDrsRestoreAllDefaults,
                "NvAPI_DRS_RestoreAllDefaults");
            var status = restore(GetSession());

            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Restore a profile to its defaults.
        /// </summary>
        /// <param name="profile">Profile to restore.</param>
        /// <returns>True if restored; false if unsupported.</returns>
        public unsafe bool RestoreProfileDefault(NVAPIDrsProfileDto profile)
        {
            ThrowIfDisposed();

            if (profile.Handle == IntPtr.Zero)
                return false;

            var restore = GetDelegate<NvApiDrsRestoreProfileDefaultDelegate>(
                NvApiIdDrsRestoreProfileDefault,
                "NvAPI_DRS_RestoreProfileDefault");
            var status = restore(GetSession(), (NvDRSProfileHandle__*)profile.Handle);

            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Restore a profile setting to its default value.
        /// </summary>
        /// <param name="profile">Profile to update.</param>
        /// <param name="settingId">Setting ID.</param>
        /// <returns>True if restored; false if unsupported.</returns>
        public unsafe bool RestoreProfileDefaultSetting(NVAPIDrsProfileDto profile, uint settingId)
        {
            ThrowIfDisposed();

            if (profile.Handle == IntPtr.Zero)
                return false;

            var restore = GetDelegate<NvApiDrsRestoreProfileDefaultSettingDelegate>(
                NvApiIdDrsRestoreProfileDefaultSetting,
                "NvAPI_DRS_RestoreProfileDefaultSetting");
            var status = restore(GetSession(), (NvDRSProfileHandle__*)profile.Handle, settingId);

            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return false;

            throw new NVAPIException(status);
        }

        private unsafe NVAPIDrsProfileDto? GetProfileInfoInternal(NvDRSProfileHandle__* handle)
        {
            var getInfo = GetDelegate<NvApiDrsGetProfileInfoDelegate>(NvApiIdDrsGetProfileInfo, "NvAPI_DRS_GetProfileInfo");
            var native = CreateProfileInfo();
            var status = getInfo(GetSession(), handle, &native);

            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIDrsProfileDto.FromNative(handle, native);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        internal static void WriteUnicodeString(Span<ushort> destination, string value)
        {
            destination.Clear();
            if (string.IsNullOrEmpty(value))
                return;

            var length = Math.Min(value.Length, destination.Length - 1);
            for (var i = 0; i < length; i++)
            {
                destination[i] = value[i];
            }
            destination[length] = 0;
        }

        internal static string ReadUnicodeString(ReadOnlySpan<ushort> source)
        {
            var length = source.IndexOf((ushort)0);
            if (length < 0)
                length = source.Length;

            return new string(MemoryMarshal.Cast<ushort, char>(source.Slice(0, length)));
        }

        internal static byte[] ReadBinaryValue(ref _NVDRS_BINARY_SETTING setting)
        {
            var length = (int)Math.Min(setting.valueLength, 4096u);
            if (length <= 0)
                return Array.Empty<byte>();

            var span = MemoryMarshal.CreateSpan(ref setting.valueData.e0, 4096);
            var result = new byte[length];
            span.Slice(0, length).CopyTo(result);
            return result;
        }

        internal static void WriteBinaryValue(ref _NVDRS_BINARY_SETTING setting, byte[]? data)
        {
            setting.valueLength = 0;
            var span = MemoryMarshal.CreateSpan(ref setting.valueData.e0, 4096);
            span.Clear();

            if (data == null || data.Length == 0)
                return;

            var length = Math.Min(data.Length, 4096);
            data.AsSpan(0, length).CopyTo(span);
            setting.valueLength = (uint)length;
        }

        private unsafe NvDRSSessionHandle__* GetSession()
        {
            return (NvDRSSessionHandle__*)_session;
        }

        private T GetDelegate<T>(uint id, string name) where T : Delegate
        {
            var functionPtr = _apiHelper.Api.TryGetFunctionPointer(id);
            if (functionPtr == IntPtr.Zero)
                throw new NVAPIException(_NvAPI_Status.NVAPI_NO_IMPLEMENTATION, $"NVAPI function '{name}' (0x{id:X8}) not available.");

            return Marshal.GetDelegateForFunctionPointer<T>(functionPtr);
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(NVAPIDrsHelper));

            _apiHelper.ThrowIfDisposed();
        }

        /// <summary>
        /// Dispose the DRS session.
        /// </summary>
        public unsafe void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private unsafe void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (_session != IntPtr.Zero && !_apiHelper.IsDisposed)
            {
                try
                {
                    var destroy = GetDelegate<NvApiDrsDestroySessionDelegate>(NvApiIdDrsDestroySession, "NvAPI_DRS_DestroySession");
                    destroy((NvDRSSessionHandle__*)_session);
                }
                catch
                {
                    // Avoid throwing during dispose/finalize.
                }
            }

            _session = IntPtr.Zero;
            _disposed = true;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsDestroySessionDelegate(NvDRSSessionHandle__* hSession);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsLoadSettingsDelegate(NvDRSSessionHandle__* hSession);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsSaveSettingsDelegate(NvDRSSessionHandle__* hSession);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsLoadSettingsFromFileDelegate(NvDRSSessionHandle__* hSession, ushort* fileName);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsSaveSettingsToFileDelegate(NvDRSSessionHandle__* hSession, ushort* fileName);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsCreateProfileDelegate(NvDRSSessionHandle__* hSession, _NVDRS_PROFILE_V1* pProfileInfo, NvDRSProfileHandle__** phProfile);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsDeleteProfileDelegate(NvDRSSessionHandle__* hSession, NvDRSProfileHandle__* hProfile);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsSetCurrentGlobalProfileDelegate(NvDRSSessionHandle__* hSession, ushort* wszGlobalProfileName);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsGetCurrentGlobalProfileDelegate(NvDRSSessionHandle__* hSession, NvDRSProfileHandle__** phProfile);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsGetProfileInfoDelegate(NvDRSSessionHandle__* hSession, NvDRSProfileHandle__* hProfile, _NVDRS_PROFILE_V1* pProfileInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsSetProfileInfoDelegate(NvDRSSessionHandle__* hSession, NvDRSProfileHandle__* hProfile, _NVDRS_PROFILE_V1* pProfileInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsFindProfileByNameDelegate(NvDRSSessionHandle__* hSession, ushort* profileName, NvDRSProfileHandle__** phProfile);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsEnumProfilesDelegate(NvDRSSessionHandle__* hSession, uint index, NvDRSProfileHandle__** phProfile);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsGetNumProfilesDelegate(NvDRSSessionHandle__* hSession, uint* numProfiles);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsCreateApplicationDelegate(NvDRSSessionHandle__* hSession, NvDRSProfileHandle__* hProfile, _NVDRS_APPLICATION_V4* pApplication);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsDeleteApplicationExDelegate(NvDRSSessionHandle__* hSession, NvDRSProfileHandle__* hProfile, _NVDRS_APPLICATION_V4* pApplication);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsDeleteApplicationDelegate(NvDRSSessionHandle__* hSession, NvDRSProfileHandle__* hProfile, ushort* appName);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsGetApplicationInfoDelegate(NvDRSSessionHandle__* hSession, NvDRSProfileHandle__* hProfile, ushort* appName, _NVDRS_APPLICATION_V4* pApplication);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsEnumApplicationsDelegate(NvDRSSessionHandle__* hSession, NvDRSProfileHandle__* hProfile, uint startIndex, uint* appCount, _NVDRS_APPLICATION_V4* pApplication);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsFindApplicationByNameDelegate(NvDRSSessionHandle__* hSession, ushort* appName, NvDRSProfileHandle__** phProfile, _NVDRS_APPLICATION_V4* pApplication);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsSetSettingDelegate(NvDRSSessionHandle__* hSession, NvDRSProfileHandle__* hProfile, _NVDRS_SETTING_V1* pSetting);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsGetSettingDelegate(NvDRSSessionHandle__* hSession, NvDRSProfileHandle__* hProfile, uint settingId, _NVDRS_SETTING_V1* pSetting);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsEnumSettingsDelegate(NvDRSSessionHandle__* hSession, NvDRSProfileHandle__* hProfile, uint startIndex, uint* settingsCount, _NVDRS_SETTING_V1* pSetting);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsEnumAvailableSettingIdsDelegate(uint* pSettingIds, uint* pMaxCount);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsEnumAvailableSettingValuesDelegate(uint settingId, uint* pMaxNumValues, _NVDRS_SETTING_VALUES* pSettingValues);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsGetSettingIdFromNameDelegate(ushort* settingName, uint* settingId);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsGetSettingNameFromIdDelegate(uint settingId, ushort** settingName);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsDeleteProfileSettingDelegate(NvDRSSessionHandle__* hSession, NvDRSProfileHandle__* hProfile, uint settingId);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsRestoreAllDefaultsDelegate(NvDRSSessionHandle__* hSession);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsRestoreProfileDefaultDelegate(NvDRSSessionHandle__* hSession, NvDRSProfileHandle__* hProfile);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsRestoreProfileDefaultSettingDelegate(NvDRSSessionHandle__* hSession, NvDRSProfileHandle__* hProfile, uint settingId);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsGetBaseProfileDelegate(NvDRSSessionHandle__* hSession, NvDRSProfileHandle__** phProfile);
    }

    /// <summary>
    /// DRS profile info DTO.
    /// </summary>
    public readonly struct NVAPIDrsProfileDto : IEquatable<NVAPIDrsProfileDto>
    {
        internal IntPtr Handle { get; }
        public string ProfileName { get; }
        public _NVDRS_GPU_SUPPORT GpuSupport { get; }
        public bool IsPredefined { get; }
        public uint NumOfApps { get; }
        public uint NumOfSettings { get; }

        /// <summary>
        /// Create a DRS profile DTO.
        /// </summary>
        /// <param name="profileName">Profile name.</param>
        /// <param name="gpuSupport">GPU support flags.</param>
        /// <param name="isPredefined">Whether the profile is predefined.</param>
        /// <param name="numOfApps">Number of applications in the profile.</param>
        /// <param name="numOfSettings">Number of settings in the profile.</param>
        public NVAPIDrsProfileDto(
            string profileName,
            _NVDRS_GPU_SUPPORT gpuSupport,
            bool isPredefined,
            uint numOfApps,
            uint numOfSettings)
            : this(IntPtr.Zero, profileName, gpuSupport, isPredefined, numOfApps, numOfSettings)
        {
        }

        private NVAPIDrsProfileDto(
            IntPtr handle,
            string profileName,
            _NVDRS_GPU_SUPPORT gpuSupport,
            bool isPredefined,
            uint numOfApps,
            uint numOfSettings)
        {
            Handle = handle;
            ProfileName = profileName ?? string.Empty;
            GpuSupport = gpuSupport;
            IsPredefined = isPredefined;
            NumOfApps = numOfApps;
            NumOfSettings = numOfSettings;
        }

        /// <summary>
        /// Create a DRS profile DTO for a new profile name.
        /// </summary>
        /// <param name="profileName">Profile name.</param>
        /// <returns>DRS profile DTO.</returns>
        public static NVAPIDrsProfileDto Create(string profileName)
        {
            return new NVAPIDrsProfileDto(profileName ?? string.Empty, default, false, 0, 0);
        }

        /// <summary>
        /// Create a DRS profile DTO from native profile data.
        /// </summary>
        /// <param name="handle">Native profile handle.</param>
        /// <param name="native">Native profile data.</param>
        /// <returns>DRS profile DTO.</returns>
        public static unsafe NVAPIDrsProfileDto FromNative(NvDRSProfileHandle__* handle, _NVDRS_PROFILE_V1 native)
        {
            var name = NVAPIDrsHelper.ReadUnicodeString(
                MemoryMarshal.CreateReadOnlySpan(ref native.profileName.e0, NVAPI.NVAPI_UNICODE_STRING_MAX));

            return new NVAPIDrsProfileDto(
                (IntPtr)handle,
                name,
                native.gpuSupport,
                native.isPredefined != 0,
                native.numOfApps,
                native.numOfSettings);
        }

        /// <summary>
        /// Convert this DTO to native profile data.
        /// </summary>
        /// <returns>Native profile data.</returns>
        public _NVDRS_PROFILE_V1 ToNative()
        {
            var native = NVAPIDrsHelper.CreateProfileInfo();
            NVAPIDrsHelper.WriteUnicodeString(
                MemoryMarshal.CreateSpan(ref native.profileName.e0, NVAPI.NVAPI_UNICODE_STRING_MAX),
                ProfileName);
            native.gpuSupport = GpuSupport;
            native.isPredefined = IsPredefined ? 1u : 0u;
            native.numOfApps = NumOfApps;
            native.numOfSettings = NumOfSettings;
            return native;
        }

        /// <summary>
        /// Determine whether this instance equals another DRS profile DTO.
        /// </summary>
        /// <param name="other">The other DTO to compare.</param>
        /// <returns>True if the DTOs are equal; otherwise false.</returns>
        public bool Equals(NVAPIDrsProfileDto other)
        {
            return string.Equals(ProfileName, other.ProfileName, StringComparison.Ordinal)
                && GpuSupportEquals(GpuSupport, other.GpuSupport)
                && IsPredefined == other.IsPredefined
                && NumOfApps == other.NumOfApps
                && NumOfSettings == other.NumOfSettings;
        }

        /// <summary>
        /// Determine whether this instance equals another object.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>True if the object is an equivalent DTO; otherwise false.</returns>
        public override bool Equals(object? obj) => obj is NVAPIDrsProfileDto other && Equals(other);

        /// <summary>
        /// Get a hash code for this instance.
        /// </summary>
        /// <returns>Hash code for this instance.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = StringComparer.Ordinal.GetHashCode(ProfileName);
                hash = (hash * 31) + GpuSupportHashCode(GpuSupport);
                hash = (hash * 31) + IsPredefined.GetHashCode();
                hash = (hash * 31) + NumOfApps.GetHashCode();
                hash = (hash * 31) + NumOfSettings.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Determine whether two DRS profile DTOs are equal.
        /// </summary>
        /// <param name="left">Left DTO.</param>
        /// <param name="right">Right DTO.</param>
        /// <returns>True if the DTOs are equal; otherwise false.</returns>
        public static bool operator ==(NVAPIDrsProfileDto left, NVAPIDrsProfileDto right) => left.Equals(right);

        /// <summary>
        /// Determine whether two DRS profile DTOs are not equal.
        /// </summary>
        /// <param name="left">Left DTO.</param>
        /// <param name="right">Right DTO.</param>
        /// <returns>True if the DTOs are not equal; otherwise false.</returns>
        public static bool operator !=(NVAPIDrsProfileDto left, NVAPIDrsProfileDto right) => !left.Equals(right);

        private static bool GpuSupportEquals(_NVDRS_GPU_SUPPORT left, _NVDRS_GPU_SUPPORT right)
        {
            var leftBytes = MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(ref left, 1));
            var rightBytes = MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(ref right, 1));
            return leftBytes.SequenceEqual(rightBytes);
        }

        private static int GpuSupportHashCode(_NVDRS_GPU_SUPPORT value)
        {
            var bytes = MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(ref value, 1));
            unchecked
            {
                var hash = 17;
                for (var i = 0; i < bytes.Length; i++)
                {
                    hash = (hash * 31) + bytes[i];
                }
                return hash;
            }
        }
    }

    /// <summary>
    /// DRS application info DTO.
    /// </summary>
    public readonly struct NVAPIDrsApplicationDto : IEquatable<NVAPIDrsApplicationDto>
    {
        public string AppName { get; }
        public string UserFriendlyName { get; }
        public string Launcher { get; }
        public string FileInFolder { get; }
        public string CommandLine { get; }
        public bool IsMetro { get; }
        public bool IsCommandLine { get; }
        public bool IsPredefined { get; }

        /// <summary>
        /// Create a DRS application DTO.
        /// </summary>
        /// <param name="appName">Application name.</param>
        /// <param name="userFriendlyName">User-friendly application name.</param>
        /// <param name="launcher">Launcher name.</param>
        /// <param name="fileInFolder">File-in-folder value.</param>
        /// <param name="commandLine">Command line value.</param>
        /// <param name="isMetro">Whether the application is a Metro app.</param>
        /// <param name="isCommandLine">Whether the application uses a command line.</param>
        /// <param name="isPredefined">Whether the application is predefined.</param>
        public NVAPIDrsApplicationDto(
            string appName,
            string userFriendlyName,
            string launcher,
            string fileInFolder,
            string commandLine,
            bool isMetro,
            bool isCommandLine,
            bool isPredefined)
        {
            AppName = appName ?? string.Empty;
            UserFriendlyName = userFriendlyName ?? string.Empty;
            Launcher = launcher ?? string.Empty;
            FileInFolder = fileInFolder ?? string.Empty;
            CommandLine = commandLine ?? string.Empty;
            IsMetro = isMetro;
            IsCommandLine = isCommandLine;
            IsPredefined = isPredefined;
        }

        /// <summary>
        /// Create a DRS application DTO with the supplied names.
        /// </summary>
        /// <param name="appName">Application name.</param>
        /// <param name="userFriendlyName">User-friendly application name.</param>
        /// <returns>DRS application DTO.</returns>
        public static NVAPIDrsApplicationDto Create(string appName, string userFriendlyName = "")
        {
            return new NVAPIDrsApplicationDto(appName, userFriendlyName, string.Empty, string.Empty, string.Empty, false, false, false);
        }

        /// <summary>
        /// Create a DRS application DTO from native data.
        /// </summary>
        /// <param name="native">Native application data.</param>
        /// <returns>DRS application DTO.</returns>
        public static unsafe NVAPIDrsApplicationDto FromNative(_NVDRS_APPLICATION_V4 native)
        {
            var appName = NVAPIDrsHelper.ReadUnicodeString(
                MemoryMarshal.CreateReadOnlySpan(ref native.appName.e0, NVAPI.NVAPI_UNICODE_STRING_MAX));
            var userFriendly = NVAPIDrsHelper.ReadUnicodeString(
                MemoryMarshal.CreateReadOnlySpan(ref native.userFriendlyName.e0, NVAPI.NVAPI_UNICODE_STRING_MAX));
            var launcher = NVAPIDrsHelper.ReadUnicodeString(
                MemoryMarshal.CreateReadOnlySpan(ref native.launcher.e0, NVAPI.NVAPI_UNICODE_STRING_MAX));
            var fileInFolder = NVAPIDrsHelper.ReadUnicodeString(
                MemoryMarshal.CreateReadOnlySpan(ref native.fileInFolder.e0, NVAPI.NVAPI_UNICODE_STRING_MAX));
            var commandLine = NVAPIDrsHelper.ReadUnicodeString(
                MemoryMarshal.CreateReadOnlySpan(ref native.commandLine.e0, NVAPI.NVAPI_UNICODE_STRING_MAX));

            return new NVAPIDrsApplicationDto(
                appName,
                userFriendly,
                launcher,
                fileInFolder,
                commandLine,
                native.isMetro != 0,
                native.isCommandLine != 0,
                native.isPredefined != 0);
        }

        /// <summary>
        /// Convert this DTO to native application data.
        /// </summary>
        /// <returns>Native application data.</returns>
        public _NVDRS_APPLICATION_V4 ToNative()
        {
            var native = NVAPIDrsHelper.CreateApplicationInfo();
            NVAPIDrsHelper.WriteUnicodeString(
                MemoryMarshal.CreateSpan(ref native.appName.e0, NVAPI.NVAPI_UNICODE_STRING_MAX),
                AppName);
            NVAPIDrsHelper.WriteUnicodeString(
                MemoryMarshal.CreateSpan(ref native.userFriendlyName.e0, NVAPI.NVAPI_UNICODE_STRING_MAX),
                UserFriendlyName);
            NVAPIDrsHelper.WriteUnicodeString(
                MemoryMarshal.CreateSpan(ref native.launcher.e0, NVAPI.NVAPI_UNICODE_STRING_MAX),
                Launcher);
            NVAPIDrsHelper.WriteUnicodeString(
                MemoryMarshal.CreateSpan(ref native.fileInFolder.e0, NVAPI.NVAPI_UNICODE_STRING_MAX),
                FileInFolder);
            NVAPIDrsHelper.WriteUnicodeString(
                MemoryMarshal.CreateSpan(ref native.commandLine.e0, NVAPI.NVAPI_UNICODE_STRING_MAX),
                CommandLine);
            native.isMetro = IsMetro ? 1u : 0u;
            native.isCommandLine = IsCommandLine ? 1u : 0u;
            native.isPredefined = IsPredefined ? 1u : 0u;
            return native;
        }

        /// <summary>
        /// Determine whether this instance equals another DRS application DTO.
        /// </summary>
        /// <param name="other">The other DTO to compare.</param>
        /// <returns>True if the DTOs are equal; otherwise false.</returns>
        public bool Equals(NVAPIDrsApplicationDto other)
        {
            return string.Equals(AppName, other.AppName, StringComparison.Ordinal)
                && string.Equals(UserFriendlyName, other.UserFriendlyName, StringComparison.Ordinal)
                && string.Equals(Launcher, other.Launcher, StringComparison.Ordinal)
                && string.Equals(FileInFolder, other.FileInFolder, StringComparison.Ordinal)
                && string.Equals(CommandLine, other.CommandLine, StringComparison.Ordinal)
                && IsMetro == other.IsMetro
                && IsCommandLine == other.IsCommandLine
                && IsPredefined == other.IsPredefined;
        }

        /// <summary>
        /// Determine whether this instance equals another object.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>True if the object is an equivalent DTO; otherwise false.</returns>
        public override bool Equals(object? obj) => obj is NVAPIDrsApplicationDto other && Equals(other);

        /// <summary>
        /// Get a hash code for this instance.
        /// </summary>
        /// <returns>Hash code for this instance.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = StringComparer.Ordinal.GetHashCode(AppName);
                hash = (hash * 31) + StringComparer.Ordinal.GetHashCode(UserFriendlyName);
                hash = (hash * 31) + StringComparer.Ordinal.GetHashCode(Launcher);
                hash = (hash * 31) + StringComparer.Ordinal.GetHashCode(FileInFolder);
                hash = (hash * 31) + StringComparer.Ordinal.GetHashCode(CommandLine);
                hash = (hash * 31) + IsMetro.GetHashCode();
                hash = (hash * 31) + IsCommandLine.GetHashCode();
                hash = (hash * 31) + IsPredefined.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Determine whether two DRS application DTOs are equal.
        /// </summary>
        /// <param name="left">Left DTO.</param>
        /// <param name="right">Right DTO.</param>
        /// <returns>True if the DTOs are equal; otherwise false.</returns>
        public static bool operator ==(NVAPIDrsApplicationDto left, NVAPIDrsApplicationDto right) => left.Equals(right);

        /// <summary>
        /// Determine whether two DRS application DTOs are not equal.
        /// </summary>
        /// <param name="left">Left DTO.</param>
        /// <param name="right">Right DTO.</param>
        /// <returns>True if the DTOs are not equal; otherwise false.</returns>
        public static bool operator !=(NVAPIDrsApplicationDto left, NVAPIDrsApplicationDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Result of an application search.
    /// </summary>
    public readonly struct NVAPIDrsApplicationSearchDto : IEquatable<NVAPIDrsApplicationSearchDto>
    {
        public NVAPIDrsProfileDto Profile { get; }
        public NVAPIDrsApplicationDto Application { get; }

        /// <summary>
        /// Create a DRS application search result DTO.
        /// </summary>
        /// <param name="profile">Profile DTO.</param>
        /// <param name="application">Application DTO.</param>
        public NVAPIDrsApplicationSearchDto(NVAPIDrsProfileDto profile, NVAPIDrsApplicationDto application)
        {
            Profile = profile;
            Application = application;
        }

        /// <summary>
        /// Determine whether this instance equals another DRS application search result DTO.
        /// </summary>
        /// <param name="other">The other DTO to compare.</param>
        /// <returns>True if the DTOs are equal; otherwise false.</returns>
        public bool Equals(NVAPIDrsApplicationSearchDto other)
        {
            return Profile.Equals(other.Profile) && Application.Equals(other.Application);
        }

        /// <summary>
        /// Determine whether this instance equals another object.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>True if the object is an equivalent DTO; otherwise false.</returns>
        public override bool Equals(object? obj) => obj is NVAPIDrsApplicationSearchDto other && Equals(other);

        /// <summary>
        /// Get a hash code for this instance.
        /// </summary>
        /// <returns>Hash code for this instance.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = Profile.GetHashCode();
                hash = (hash * 31) + Application.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Determine whether two DRS application search result DTOs are equal.
        /// </summary>
        /// <param name="left">Left DTO.</param>
        /// <param name="right">Right DTO.</param>
        /// <returns>True if the DTOs are equal; otherwise false.</returns>
        public static bool operator ==(NVAPIDrsApplicationSearchDto left, NVAPIDrsApplicationSearchDto right) => left.Equals(right);

        /// <summary>
        /// Determine whether two DRS application search result DTOs are not equal.
        /// </summary>
        /// <param name="left">Left DTO.</param>
        /// <param name="right">Right DTO.</param>
        /// <returns>True if the DTOs are not equal; otherwise false.</returns>
        public static bool operator !=(NVAPIDrsApplicationSearchDto left, NVAPIDrsApplicationSearchDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DRS setting DTO.
    /// </summary>
    public readonly struct NVAPIDrsSettingDto : IEquatable<NVAPIDrsSettingDto>
    {
        public string SettingName { get; }
        public uint SettingId { get; }
        public _NVDRS_SETTING_TYPE SettingType { get; }
        public _NVDRS_SETTING_LOCATION SettingLocation { get; }
        public bool IsCurrentPredefined { get; }
        public bool IsPredefinedValid { get; }

        public uint? PredefinedDwordValue { get; }
        public uint? CurrentDwordValue { get; }
        public string? PredefinedStringValue { get; }
        public string? CurrentStringValue { get; }
        public byte[]? PredefinedBinaryValue { get; }
        public byte[]? CurrentBinaryValue { get; }

        /// <summary>
        /// Create a DRS setting DTO.
        /// </summary>
        /// <param name="settingName">Setting name.</param>
        /// <param name="settingId">Setting identifier.</param>
        /// <param name="settingType">Setting type.</param>
        /// <param name="settingLocation">Setting location.</param>
        /// <param name="isCurrentPredefined">Whether the current value is predefined.</param>
        /// <param name="isPredefinedValid">Whether the predefined value is valid.</param>
        /// <param name="predefinedDwordValue">Predefined DWORD value.</param>
        /// <param name="currentDwordValue">Current DWORD value.</param>
        /// <param name="predefinedStringValue">Predefined string value.</param>
        /// <param name="currentStringValue">Current string value.</param>
        /// <param name="predefinedBinaryValue">Predefined binary value.</param>
        /// <param name="currentBinaryValue">Current binary value.</param>
        public NVAPIDrsSettingDto(
            string settingName,
            uint settingId,
            _NVDRS_SETTING_TYPE settingType,
            _NVDRS_SETTING_LOCATION settingLocation,
            bool isCurrentPredefined,
            bool isPredefinedValid,
            uint? predefinedDwordValue,
            uint? currentDwordValue,
            string? predefinedStringValue,
            string? currentStringValue,
            byte[]? predefinedBinaryValue,
            byte[]? currentBinaryValue)
        {
            SettingName = settingName ?? string.Empty;
            SettingId = settingId;
            SettingType = settingType;
            SettingLocation = settingLocation;
            IsCurrentPredefined = isCurrentPredefined;
            IsPredefinedValid = isPredefinedValid;
            PredefinedDwordValue = predefinedDwordValue;
            CurrentDwordValue = currentDwordValue;
            PredefinedStringValue = predefinedStringValue;
            CurrentStringValue = currentStringValue;
            PredefinedBinaryValue = predefinedBinaryValue;
            CurrentBinaryValue = currentBinaryValue;
        }

        /// <summary>
        /// Create a DWORD DRS setting DTO.
        /// </summary>
        /// <param name="settingId">Setting identifier.</param>
        /// <param name="currentValue">Current DWORD value.</param>
        /// <param name="predefinedValue">Predefined DWORD value.</param>
        /// <param name="settingName">Setting name.</param>
        /// <param name="location">Setting location.</param>
        /// <param name="isCurrentPredefined">Whether the current value is predefined.</param>
        /// <param name="isPredefinedValid">Whether the predefined value is valid.</param>
        /// <returns>DRS setting DTO.</returns>
        public static NVAPIDrsSettingDto CreateDword(
            uint settingId,
            uint currentValue,
            uint? predefinedValue = null,
            string? settingName = null,
            _NVDRS_SETTING_LOCATION location = default,
            bool isCurrentPredefined = false,
            bool isPredefinedValid = false)
        {
            return new NVAPIDrsSettingDto(
                settingName ?? string.Empty,
                settingId,
                _NVDRS_SETTING_TYPE.NVDRS_DWORD_TYPE,
                location,
                isCurrentPredefined,
                isPredefinedValid,
                predefinedValue,
                currentValue,
                null,
                null,
                null,
                null);
        }

        /// <summary>
        /// Create a string DRS setting DTO.
        /// </summary>
        /// <param name="settingId">Setting identifier.</param>
        /// <param name="currentValue">Current string value.</param>
        /// <param name="predefinedValue">Predefined string value.</param>
        /// <param name="settingName">Setting name.</param>
        /// <param name="location">Setting location.</param>
        /// <param name="isCurrentPredefined">Whether the current value is predefined.</param>
        /// <param name="isPredefinedValid">Whether the predefined value is valid.</param>
        /// <returns>DRS setting DTO.</returns>
        public static NVAPIDrsSettingDto CreateString(
            uint settingId,
            string currentValue,
            string? predefinedValue = null,
            string? settingName = null,
            _NVDRS_SETTING_LOCATION location = default,
            bool isCurrentPredefined = false,
            bool isPredefinedValid = false)
        {
            return new NVAPIDrsSettingDto(
                settingName ?? string.Empty,
                settingId,
                _NVDRS_SETTING_TYPE.NVDRS_STRING_TYPE,
                location,
                isCurrentPredefined,
                isPredefinedValid,
                null,
                null,
                predefinedValue ?? string.Empty,
                currentValue ?? string.Empty,
                null,
                null);
        }

        /// <summary>
        /// Create a wide-string DRS setting DTO.
        /// </summary>
        /// <param name="settingId">Setting identifier.</param>
        /// <param name="currentValue">Current string value.</param>
        /// <param name="predefinedValue">Predefined string value.</param>
        /// <param name="settingName">Setting name.</param>
        /// <param name="location">Setting location.</param>
        /// <param name="isCurrentPredefined">Whether the current value is predefined.</param>
        /// <param name="isPredefinedValid">Whether the predefined value is valid.</param>
        /// <returns>DRS setting DTO.</returns>
        public static NVAPIDrsSettingDto CreateWString(
            uint settingId,
            string currentValue,
            string? predefinedValue = null,
            string? settingName = null,
            _NVDRS_SETTING_LOCATION location = default,
            bool isCurrentPredefined = false,
            bool isPredefinedValid = false)
        {
            return new NVAPIDrsSettingDto(
                settingName ?? string.Empty,
                settingId,
                _NVDRS_SETTING_TYPE.NVDRS_WSTRING_TYPE,
                location,
                isCurrentPredefined,
                isPredefinedValid,
                null,
                null,
                predefinedValue ?? string.Empty,
                currentValue ?? string.Empty,
                null,
                null);
        }

        /// <summary>
        /// Create a binary DRS setting DTO.
        /// </summary>
        /// <param name="settingId">Setting identifier.</param>
        /// <param name="currentValue">Current binary value.</param>
        /// <param name="predefinedValue">Predefined binary value.</param>
        /// <param name="settingName">Setting name.</param>
        /// <param name="location">Setting location.</param>
        /// <param name="isCurrentPredefined">Whether the current value is predefined.</param>
        /// <param name="isPredefinedValid">Whether the predefined value is valid.</param>
        /// <returns>DRS setting DTO.</returns>
        public static NVAPIDrsSettingDto CreateBinary(
            uint settingId,
            byte[] currentValue,
            byte[]? predefinedValue = null,
            string? settingName = null,
            _NVDRS_SETTING_LOCATION location = default,
            bool isCurrentPredefined = false,
            bool isPredefinedValid = false)
        {
            return new NVAPIDrsSettingDto(
                settingName ?? string.Empty,
                settingId,
                _NVDRS_SETTING_TYPE.NVDRS_BINARY_TYPE,
                location,
                isCurrentPredefined,
                isPredefinedValid,
                null,
                null,
                null,
                null,
                predefinedValue,
                currentValue);
        }

        /// <summary>
        /// Create a DRS setting DTO from native setting data.
        /// </summary>
        /// <param name="native">Native setting data.</param>
        /// <returns>DRS setting DTO.</returns>
        public static unsafe NVAPIDrsSettingDto FromNative(_NVDRS_SETTING_V1 native)
        {
            var name = NVAPIDrsHelper.ReadUnicodeString(
                MemoryMarshal.CreateReadOnlySpan(ref native.settingName.e0, NVAPI.NVAPI_UNICODE_STRING_MAX));

            uint? predefinedDword = null;
            uint? currentDword = null;
            string? predefinedString = null;
            string? currentString = null;
            byte[]? predefinedBinary = null;
            byte[]? currentBinary = null;

            switch (native.settingType)
            {
                case _NVDRS_SETTING_TYPE.NVDRS_DWORD_TYPE:
                    predefinedDword = native.u32PredefinedValue;
                    currentDword = native.u32CurrentValue;
                    break;
                case _NVDRS_SETTING_TYPE.NVDRS_STRING_TYPE:
                case _NVDRS_SETTING_TYPE.NVDRS_WSTRING_TYPE:
                    predefinedString = NVAPIDrsHelper.ReadUnicodeString(native.wszPredefinedValue);
                    currentString = NVAPIDrsHelper.ReadUnicodeString(native.wszCurrentValue);
                    break;
                case _NVDRS_SETTING_TYPE.NVDRS_BINARY_TYPE:
                    predefinedBinary = NVAPIDrsHelper.ReadBinaryValue(ref native.binaryPredefinedValue);
                    currentBinary = NVAPIDrsHelper.ReadBinaryValue(ref native.binaryCurrentValue);
                    break;
            }

            return new NVAPIDrsSettingDto(
                name,
                native.settingId,
                native.settingType,
                native.settingLocation,
                native.isCurrentPredefined != 0,
                native.isPredefinedValid != 0,
                predefinedDword,
                currentDword,
                predefinedString,
                currentString,
                predefinedBinary,
                currentBinary);
        }

        /// <summary>
        /// Convert this DTO to native setting data.
        /// </summary>
        /// <returns>Native setting data.</returns>
        public _NVDRS_SETTING_V1 ToNative()
        {
            var native = NVAPIDrsHelper.CreateSetting();
            NVAPIDrsHelper.WriteUnicodeString(
                MemoryMarshal.CreateSpan(ref native.settingName.e0, NVAPI.NVAPI_UNICODE_STRING_MAX),
                SettingName);
            native.settingId = SettingId;
            native.settingType = SettingType;
            native.settingLocation = SettingLocation;
            native.isCurrentPredefined = IsCurrentPredefined ? 1u : 0u;
            native.isPredefinedValid = IsPredefinedValid ? 1u : 0u;

            switch (SettingType)
            {
                case _NVDRS_SETTING_TYPE.NVDRS_DWORD_TYPE:
                    native.u32PredefinedValue = PredefinedDwordValue ?? 0;
                    native.u32CurrentValue = CurrentDwordValue ?? 0;
                    break;
                case _NVDRS_SETTING_TYPE.NVDRS_STRING_TYPE:
                case _NVDRS_SETTING_TYPE.NVDRS_WSTRING_TYPE:
                    NVAPIDrsHelper.WriteUnicodeString(native.wszPredefinedValue, PredefinedStringValue ?? string.Empty);
                    NVAPIDrsHelper.WriteUnicodeString(native.wszCurrentValue, CurrentStringValue ?? string.Empty);
                    break;
                case _NVDRS_SETTING_TYPE.NVDRS_BINARY_TYPE:
                    NVAPIDrsHelper.WriteBinaryValue(ref native.binaryPredefinedValue, PredefinedBinaryValue);
                    NVAPIDrsHelper.WriteBinaryValue(ref native.binaryCurrentValue, CurrentBinaryValue);
                    break;
            }

            return native;
        }

        /// <summary>
        /// Determine whether this instance equals another DRS setting DTO.
        /// </summary>
        /// <param name="other">The other DTO to compare.</param>
        /// <returns>True if the DTOs are equal; otherwise false.</returns>
        public bool Equals(NVAPIDrsSettingDto other)
        {
            return string.Equals(SettingName, other.SettingName, StringComparison.Ordinal)
                && SettingId == other.SettingId
                && SettingType == other.SettingType
                && SettingLocation == other.SettingLocation
                && IsCurrentPredefined == other.IsCurrentPredefined
                && IsPredefinedValid == other.IsPredefinedValid
                && PredefinedDwordValue == other.PredefinedDwordValue
                && CurrentDwordValue == other.CurrentDwordValue
                && string.Equals(PredefinedStringValue, other.PredefinedStringValue, StringComparison.Ordinal)
                && string.Equals(CurrentStringValue, other.CurrentStringValue, StringComparison.Ordinal)
                && NVAPIDrsDtoHelpers.SequenceEquals(PredefinedBinaryValue, other.PredefinedBinaryValue)
                && NVAPIDrsDtoHelpers.SequenceEquals(CurrentBinaryValue, other.CurrentBinaryValue);
        }

        /// <summary>
        /// Determine whether this instance equals another object.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>True if the object is an equivalent DTO; otherwise false.</returns>
        public override bool Equals(object? obj) => obj is NVAPIDrsSettingDto other && Equals(other);

        /// <summary>
        /// Get a hash code for this instance.
        /// </summary>
        /// <returns>Hash code for this instance.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = StringComparer.Ordinal.GetHashCode(SettingName);
                hash = (hash * 31) + SettingId.GetHashCode();
                hash = (hash * 31) + SettingType.GetHashCode();
                hash = (hash * 31) + SettingLocation.GetHashCode();
                hash = (hash * 31) + IsCurrentPredefined.GetHashCode();
                hash = (hash * 31) + IsPredefinedValid.GetHashCode();
                hash = (hash * 31) + (PredefinedDwordValue?.GetHashCode() ?? 0);
                hash = (hash * 31) + (CurrentDwordValue?.GetHashCode() ?? 0);
                hash = (hash * 31) + (PredefinedStringValue == null ? 0 : StringComparer.Ordinal.GetHashCode(PredefinedStringValue));
                hash = (hash * 31) + (CurrentStringValue == null ? 0 : StringComparer.Ordinal.GetHashCode(CurrentStringValue));
                hash = (hash * 31) + NVAPIDrsDtoHelpers.SequenceHashCode(PredefinedBinaryValue);
                hash = (hash * 31) + NVAPIDrsDtoHelpers.SequenceHashCode(CurrentBinaryValue);
                return hash;
            }
        }

        /// <summary>
        /// Determine whether two DRS setting DTOs are equal.
        /// </summary>
        /// <param name="left">Left DTO.</param>
        /// <param name="right">Right DTO.</param>
        /// <returns>True if the DTOs are equal; otherwise false.</returns>
        public static bool operator ==(NVAPIDrsSettingDto left, NVAPIDrsSettingDto right) => left.Equals(right);

        /// <summary>
        /// Determine whether two DRS setting DTOs are not equal.
        /// </summary>
        /// <param name="left">Left DTO.</param>
        /// <param name="right">Right DTO.</param>
        /// <returns>True if the DTOs are not equal; otherwise false.</returns>
        public static bool operator !=(NVAPIDrsSettingDto left, NVAPIDrsSettingDto right) => !left.Equals(right);
    }

    /// <summary>
    /// DRS setting values DTO.
    /// </summary>
    public readonly struct NVAPIDrsSettingValuesDto : IEquatable<NVAPIDrsSettingValuesDto>
    {
        public _NVDRS_SETTING_TYPE SettingType { get; }
        public uint? DefaultDwordValue { get; }
        public string? DefaultStringValue { get; }
        public byte[]? DefaultBinaryValue { get; }
        public uint[]? DwordValues { get; }
        public string[]? StringValues { get; }
        public byte[][]? BinaryValues { get; }

        /// <summary>
        /// Create a DRS setting values DTO.
        /// </summary>
        /// <param name="settingType">Setting type.</param>
        /// <param name="defaultDwordValue">Default DWORD value.</param>
        /// <param name="defaultStringValue">Default string value.</param>
        /// <param name="defaultBinaryValue">Default binary value.</param>
        /// <param name="dwordValues">Allowed DWORD values.</param>
        /// <param name="stringValues">Allowed string values.</param>
        /// <param name="binaryValues">Allowed binary values.</param>
        public NVAPIDrsSettingValuesDto(
            _NVDRS_SETTING_TYPE settingType,
            uint? defaultDwordValue,
            string? defaultStringValue,
            byte[]? defaultBinaryValue,
            uint[]? dwordValues,
            string[]? stringValues,
            byte[][]? binaryValues)
        {
            SettingType = settingType;
            DefaultDwordValue = defaultDwordValue;
            DefaultStringValue = defaultStringValue;
            DefaultBinaryValue = defaultBinaryValue;
            DwordValues = dwordValues;
            StringValues = stringValues;
            BinaryValues = binaryValues;
        }

        /// <summary>
        /// Create a DRS setting values DTO from native values data.
        /// </summary>
        /// <param name="native">Native setting values data.</param>
        /// <returns>DRS setting values DTO.</returns>
        public static unsafe NVAPIDrsSettingValuesDto FromNative(_NVDRS_SETTING_VALUES native)
        {
            var count = (int)Math.Min(native.numSettingValues, 100u);
            var values = MemoryMarshal.CreateReadOnlySpan(ref native.settingValues.e0, 100);

            switch (native.settingType)
            {
                case _NVDRS_SETTING_TYPE.NVDRS_DWORD_TYPE:
                    var dwords = new uint[count];
                    for (var i = 0; i < count; i++)
                        dwords[i] = values[i].u32Value;
                    return new NVAPIDrsSettingValuesDto(
                        native.settingType,
                        native.u32DefaultValue,
                        null,
                        null,
                        dwords,
                        null,
                        null);

                case _NVDRS_SETTING_TYPE.NVDRS_STRING_TYPE:
                case _NVDRS_SETTING_TYPE.NVDRS_WSTRING_TYPE:
                    var strings = new string[count];
                    for (var i = 0; i < count; i++)
                    {
                        var entry = values[i];
                        strings[i] = NVAPIDrsHelper.ReadUnicodeString(
                            MemoryMarshal.CreateReadOnlySpan(ref entry.wszValue.e0, NVAPI.NVAPI_UNICODE_STRING_MAX));
                    }
                    return new NVAPIDrsSettingValuesDto(
                        native.settingType,
                        null,
                        NVAPIDrsHelper.ReadUnicodeString(native.wszDefaultValue),
                        null,
                        null,
                        strings,
                        null);

                case _NVDRS_SETTING_TYPE.NVDRS_BINARY_TYPE:
                    var binaries = new byte[count][];
                    for (var i = 0; i < count; i++)
                    {
                        var entry = values[i].binaryValue;
                        binaries[i] = NVAPIDrsHelper.ReadBinaryValue(ref entry);
                    }
                    return new NVAPIDrsSettingValuesDto(
                        native.settingType,
                        null,
                        null,
                        NVAPIDrsHelper.ReadBinaryValue(ref native.binaryDefaultValue),
                        null,
                        null,
                        binaries);
            }

            return new NVAPIDrsSettingValuesDto(native.settingType, null, null, null, null, null, null);
        }

        /// <summary>
        /// Determine whether this instance equals another DRS setting values DTO.
        /// </summary>
        /// <param name="other">The other DTO to compare.</param>
        /// <returns>True if the DTOs are equal; otherwise false.</returns>
        public bool Equals(NVAPIDrsSettingValuesDto other)
        {
            return SettingType == other.SettingType
                && DefaultDwordValue == other.DefaultDwordValue
                && string.Equals(DefaultStringValue, other.DefaultStringValue, StringComparison.Ordinal)
                && NVAPIDrsDtoHelpers.SequenceEquals(DefaultBinaryValue, other.DefaultBinaryValue)
                && NVAPIDrsDtoHelpers.SequenceEquals(DwordValues, other.DwordValues)
                && NVAPIDrsDtoHelpers.SequenceEquals(StringValues, other.StringValues)
                && SequenceEquals(BinaryValues, other.BinaryValues);
        }

        /// <summary>
        /// Determine whether this instance equals another object.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>True if the object is an equivalent DTO; otherwise false.</returns>
        public override bool Equals(object? obj) => obj is NVAPIDrsSettingValuesDto other && Equals(other);

        /// <summary>
        /// Get a hash code for this instance.
        /// </summary>
        /// <returns>Hash code for this instance.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = SettingType.GetHashCode();
                hash = (hash * 31) + (DefaultDwordValue?.GetHashCode() ?? 0);
                hash = (hash * 31) + (DefaultStringValue == null ? 0 : StringComparer.Ordinal.GetHashCode(DefaultStringValue));
                hash = (hash * 31) + NVAPIDrsDtoHelpers.SequenceHashCode(DefaultBinaryValue);
                hash = (hash * 31) + NVAPIDrsDtoHelpers.SequenceHashCode(DwordValues);
                hash = (hash * 31) + NVAPIDrsDtoHelpers.SequenceHashCode(StringValues);
                hash = (hash * 31) + SequenceHashCode(BinaryValues);
                return hash;
            }
        }

        /// <summary>
        /// Determine whether two DRS setting values DTOs are equal.
        /// </summary>
        /// <param name="left">Left DTO.</param>
        /// <param name="right">Right DTO.</param>
        /// <returns>True if the DTOs are equal; otherwise false.</returns>
        public static bool operator ==(NVAPIDrsSettingValuesDto left, NVAPIDrsSettingValuesDto right) => left.Equals(right);

        /// <summary>
        /// Determine whether two DRS setting values DTOs are not equal.
        /// </summary>
        /// <param name="left">Left DTO.</param>
        /// <param name="right">Right DTO.</param>
        /// <returns>True if the DTOs are not equal; otherwise false.</returns>
        public static bool operator !=(NVAPIDrsSettingValuesDto left, NVAPIDrsSettingValuesDto right) => !left.Equals(right);

        private static bool SequenceEquals(byte[][]? left, byte[][]? right)
        {
            if (ReferenceEquals(left, right))
                return true;

            if (left == null || right == null)
                return false;

            if (left.Length != right.Length)
                return false;

            for (var i = 0; i < left.Length; i++)
            {
                if (!NVAPIDrsDtoHelpers.SequenceEquals(left[i], right[i]))
                    return false;
            }

            return true;
        }

        private static int SequenceHashCode(byte[][]? values)
        {
            if (values == null || values.Length == 0)
                return 0;

            unchecked
            {
                var hash = 17;
                for (var i = 0; i < values.Length; i++)
                {
                    hash = (hash * 31) + NVAPIDrsDtoHelpers.SequenceHashCode(values[i]);
                }
                return hash;
            }
        }
    }

    internal static class NVAPIDrsDtoHelpers
    {
        /// <summary>
        /// Compare two arrays for equality using the default comparer.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="left">Left array.</param>
        /// <param name="right">Right array.</param>
        /// <returns>True if both arrays are equal; otherwise false.</returns>
        public static bool SequenceEquals<T>(T[]? left, T[]? right)
        {
            if (ReferenceEquals(left, right))
                return true;

            if (left == null || right == null)
                return false;

            if (left.Length != right.Length)
                return false;

            var comparer = EqualityComparer<T>.Default;
            for (var i = 0; i < left.Length; i++)
            {
                if (!comparer.Equals(left[i], right[i]))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Compute a hash code for an array using the default comparer.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="values">Array values.</param>
        /// <returns>Hash code for the array contents.</returns>
        public static int SequenceHashCode<T>(T[]? values)
        {
            if (values == null || values.Length == 0)
                return 0;

            unchecked
            {
                var hash = 17;
                var comparer = EqualityComparer<T>.Default;
                for (var i = 0; i < values.Length; i++)
                {
                    var value = values[i];
                    hash = (hash * 31) + (value == null ? 0 : comparer.GetHashCode(value));
                }

                return hash;
            }
        }
    }
}
