using System;
using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <summary>
    /// Facade entry point for NVAPI helper objects.
    /// </summary>
    public sealed class NVAPIApiHelper : IDisposable
    {
        private const uint NvApiIdSysGetDriverAndBranchVersion = 0x2926AAAD;
        private const uint NvApiIdSysGetChipSetInfo = 0x53DABBCA;
        private const uint NvApiIdSysGetLidAndDockInfo = 0xCDA14D8A;
        private const uint NvApiIdSysGetDisplayDriverInfo = 0x721FACEB;
        private const uint NvApiIdSysGetPhysicalGPUs = 0xD3B24D2D;
        private const uint NvApiIdSysGetLogicalGPUs = 0xCCFFFC10;
        private const uint NvApiIdDrsCreateSession = 0x0694D52E;

        private readonly NVAPIApi _api;
        private bool _disposed;

        private NVAPIApiHelper(NVAPIApi api)
        {
            _api = api;
        }

        ~NVAPIApiHelper()
        {
            Dispose(false);
        }

        /// <summary>
        /// Initialize NVAPI and return a facade helper that owns the library lifetime.
        /// </summary>
        /// <returns>Initialized NVAPI helper.</returns>
        public static NVAPIApiHelper Initialize()
        {
            return new NVAPIApiHelper(NVAPIApi.Initialize());
        }

        /// <summary>
        /// Create a DRS session helper.
        /// </summary>
        /// <returns>DRS helper instance, or null if unsupported.</returns>
        public unsafe NVAPIDrsHelper? CreateDrsSession()
        {
            ThrowIfDisposed();

            var functionPtr = _api.TryGetFunctionPointer(NvApiIdDrsCreateSession);
            if (functionPtr == IntPtr.Zero)
                return null;

            var create = Marshal.GetDelegateForFunctionPointer<NvApiDrsCreateSessionDelegate>(functionPtr);
            NvDRSSessionHandle__* session;
            var status = create(&session);

            if (status == _NvAPI_Status.NVAPI_OK)
                return new NVAPIDrsHelper(this, (IntPtr)session);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Enumerate physical GPU helpers.
        /// </summary>
        /// <returns>Array of physical GPU helpers, or empty if none are found.</returns>
        public unsafe NVAPIPhysicalGpuHelper[] EnumeratePhysicalGpus()
        {
            ThrowIfDisposed();

            var handles = _api.EnumeratePhysicalGpus();
            if (handles.Length == 0)
                return Array.Empty<NVAPIPhysicalGpuHelper>();

            var helpers = new NVAPIPhysicalGpuHelper[handles.Length];
            for (var i = 0; i < handles.Length; i++)
            {
                helpers[i] = new NVAPIPhysicalGpuHelper(this, (IntPtr)handles[i]);
            }

            return helpers;
        }

        /// <summary>
        /// Get the NVAPI driver version and branch string.
        /// </summary>
        /// <returns>Driver version info, or null if unavailable.</returns>
        public unsafe NVAPIDriverAndBranchVersionDto? GetDriverAndBranchVersion()
        {
            ThrowIfDisposed();

            var getVersion = GetDelegate<NvApiSysGetDriverAndBranchVersionDelegate>(
                NvApiIdSysGetDriverAndBranchVersion,
                "NvAPI_SYS_GetDriverAndBranchVersion");

            uint driverVersion = 0;
            Span<sbyte> buffer = stackalloc sbyte[NVAPI.NVAPI_SHORT_STRING_MAX];
            buffer[0] = 0;

            fixed (sbyte* pBuffer = buffer)
            {
                var status = getVersion(&driverVersion, pBuffer);
                if (status == _NvAPI_Status.NVAPI_OK)
                {
                    var branch = Marshal.PtrToStringAnsi((IntPtr)pBuffer) ?? string.Empty;
                    return new NVAPIDriverAndBranchVersionDto(driverVersion, branch);
                }

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return null;

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Get the Mosaic helper.
        /// </summary>
        /// <returns>Mosaic helper instance.</returns>
        public NVAPIMosaicHelper GetMosaicHelper()
        {
            ThrowIfDisposed();
            return new NVAPIMosaicHelper(this);
        }

        /// <summary>
        /// Get the Video helper.
        /// </summary>
        /// <returns>Video helper instance.</returns>
        public NVAPIVideoHelper GetVideoHelper()
        {
            ThrowIfDisposed();
            return new NVAPIVideoHelper(this);
        }

        /// <summary>
        /// Get the OpenGL helper.
        /// </summary>
        /// <returns>OpenGL helper instance.</returns>
        public NVAPIOpenGLHelper GetOpenGLHelper()
        {
            ThrowIfDisposed();
            return new NVAPIOpenGLHelper(this);
        }

        /// <summary>
        /// Get the system chipset info.
        /// </summary>
        /// <returns>Chipset info, or null if unavailable.</returns>
        public unsafe NVAPIChipSetInfoDto? GetChipSetInfo()
        {
            ThrowIfDisposed();

            var getChipset = GetDelegate<NvApiSysGetChipSetInfoDelegate>(NvApiIdSysGetChipSetInfo, "NvAPI_SYS_GetChipSetInfo");
            var info = CreateChipSetInfo();
            var status = getChipset(&info);

            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIChipSetInfoDto.FromNative(info);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get lid and dock information.
        /// </summary>
        /// <returns>Lid and dock info, or null if unavailable.</returns>
        public unsafe NVAPILidAndDockInfoDto? GetLidAndDockInfo()
        {
            ThrowIfDisposed();

            var getInfo = GetDelegate<NvApiSysGetLidAndDockInfoDelegate>(NvApiIdSysGetLidAndDockInfo, "NvAPI_SYS_GetLidAndDockInfo");
            var info = CreateLidAndDockInfo();
            var status = getInfo(&info);

            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPILidAndDockInfoDto.FromNative(info);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get display driver info.
        /// </summary>
        /// <returns>Display driver info, or null if unavailable.</returns>
        public unsafe NVAPIDisplayDriverInfoDto? GetDisplayDriverInfo()
        {
            ThrowIfDisposed();

            var getInfo = GetDelegate<NvApiSysGetDisplayDriverInfoDelegate>(NvApiIdSysGetDisplayDriverInfo, "NvAPI_SYS_GetDisplayDriverInfo");
            var info = CreateDisplayDriverInfo();
            var status = getInfo(&info);

            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIDisplayDriverInfoDto.FromNative(info);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get physical GPU handles with adapter type metadata.
        /// </summary>
        /// <returns>Array of physical GPU handle data, or empty if none are found.</returns>
        public unsafe NVAPISystemPhysicalGpuHandleDto[] GetPhysicalGpus()
        {
            ThrowIfDisposed();

            var getGpus = GetDelegate<NvApiSysGetPhysicalGpusDelegate>(NvApiIdSysGetPhysicalGPUs, "NvAPI_SYS_GetPhysicalGPUs");
            var gpus = CreatePhysicalGpus();
            var status = getGpus(&gpus);

            if (status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND || status == _NvAPI_Status.NVAPI_NOT_SUPPORTED)
                return Array.Empty<NVAPISystemPhysicalGpuHandleDto>();

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            var count = (int)Math.Min(gpus.gpuHandleCount, NVAPI.NVAPI_MAX_PHYSICAL_GPUS);
            if (count == 0)
                return Array.Empty<NVAPISystemPhysicalGpuHandleDto>();

            var result = new NVAPISystemPhysicalGpuHandleDto[count];
            var span = MemoryMarshal.CreateSpan(ref gpus.gpuHandleData.e0, NVAPI.NVAPI_MAX_PHYSICAL_GPUS);
            for (var i = 0; i < count; i++)
            {
                result[i] = NVAPISystemPhysicalGpuHandleDto.FromNative(this, span[i]);
            }

            return result;
        }

        /// <summary>
        /// Get logical GPU handles with adapter type metadata.
        /// </summary>
        /// <returns>Array of logical GPU handle data, or empty if none are found.</returns>
        public unsafe NVAPISystemLogicalGpuHandleDto[] GetLogicalGpus()
        {
            ThrowIfDisposed();

            var getGpus = GetDelegate<NvApiSysGetLogicalGpusDelegate>(NvApiIdSysGetLogicalGPUs, "NvAPI_SYS_GetLogicalGPUs");
            var gpus = CreateLogicalGpus();
            var status = getGpus(&gpus);

            if (status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND || status == _NvAPI_Status.NVAPI_NOT_SUPPORTED)
                return Array.Empty<NVAPISystemLogicalGpuHandleDto>();

            if (status != _NvAPI_Status.NVAPI_OK)
                throw new NVAPIException(status);

            var count = (int)Math.Min(gpus.gpuHandleCount, NVAPI.NVAPI_MAX_LOGICAL_GPUS);
            if (count == 0)
                return Array.Empty<NVAPISystemLogicalGpuHandleDto>();

            var result = new NVAPISystemLogicalGpuHandleDto[count];
            var span = MemoryMarshal.CreateSpan(ref gpus.gpuHandleData.e0, NVAPI.NVAPI_MAX_LOGICAL_GPUS);
            for (var i = 0; i < count; i++)
            {
                result[i] = NVAPISystemLogicalGpuHandleDto.FromNative(this, span[i]);
            }

            return result;
        }

        /// <summary>
        /// Enumerate logical GPU helpers.
        /// </summary>
        /// <returns>Array of logical GPU helpers, or empty if none are found.</returns>
        public unsafe NVAPILogicalGpuHelper[] EnumerateLogicalGpus()
        {
            ThrowIfDisposed();

            var handles = _api.EnumerateLogicalGpus();
            if (handles.Length == 0)
                return Array.Empty<NVAPILogicalGpuHelper>();

            var helpers = new NVAPILogicalGpuHelper[handles.Length];
            for (var i = 0; i < handles.Length; i++)
            {
                helpers[i] = new NVAPILogicalGpuHelper(this, (IntPtr)handles[i]);
            }

            return helpers;
        }

        private static NV_CHIPSET_INFO_v4 CreateChipSetInfo()
        {
            return new NV_CHIPSET_INFO_v4 { version = NVAPI.NV_CHIPSET_INFO_VER };
        }

        private static NV_LID_DOCK_PARAMS CreateLidAndDockInfo()
        {
            return new NV_LID_DOCK_PARAMS { version = NVAPI.NV_LID_DOCK_PARAMS_VER };
        }

        private static _NV_DISPLAY_DRIVER_INFO_V2 CreateDisplayDriverInfo()
        {
            return new _NV_DISPLAY_DRIVER_INFO_V2 { version = NVAPI.NV_DISPLAY_DRIVER_INFO_VER };
        }

        private static _NV_PHYSICAL_GPUS CreatePhysicalGpus()
        {
            return new _NV_PHYSICAL_GPUS { version = NVAPI.NV_PHYSICAL_GPUS_VER };
        }

        private static _NV_LOGICAL_GPUS CreateLogicalGpus()
        {
            return new _NV_LOGICAL_GPUS { version = NVAPI.NV_LOGICAL_GPUS_VER };
        }

        internal NVAPIApi Api
        {
            get
            {
                ThrowIfDisposed();
                return _api;
            }
        }

        internal bool IsDisposed => _disposed;

        private T GetDelegate<T>(uint id, string name) where T : Delegate
        {
            var functionPtr = _api.TryGetFunctionPointer(id);
            if (functionPtr == IntPtr.Zero)
            {
                throw new NVAPIException(_NvAPI_Status.NVAPI_NO_IMPLEMENTATION, $"NVAPI function '{name}' (0x{id:X8}) not available.");
            }

            return Marshal.GetDelegateForFunctionPointer<T>(functionPtr);
        }

        internal void ThrowIfDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(NVAPIApiHelper));
        }

        /// <summary>
        /// Dispose the NVAPI helper and release native resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            _api.Dispose();
            _disposed = true;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiSysGetDriverAndBranchVersionDelegate(uint* pDriverVersion, sbyte* szBuildBranchString);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiSysGetChipSetInfoDelegate(NV_CHIPSET_INFO_v4* pChipSetInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiSysGetLidAndDockInfoDelegate(NV_LID_DOCK_PARAMS* pLidAndDock);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiSysGetDisplayDriverInfoDelegate(_NV_DISPLAY_DRIVER_INFO_V2* pDriverInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiSysGetPhysicalGpusDelegate(_NV_PHYSICAL_GPUS* pPhysicalGpus);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiSysGetLogicalGpusDelegate(_NV_LOGICAL_GPUS* pLogicalGpus);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDrsCreateSessionDelegate(NvDRSSessionHandle__** phSession);
    }

    /// <summary>
    /// Driver version and branch string.
    /// </summary>
    public readonly struct NVAPIDriverAndBranchVersionDto : IEquatable<NVAPIDriverAndBranchVersionDto>
    {
        /// <summary>Driver version.</summary>
        public uint DriverVersion { get; }

        /// <summary>Driver branch string.</summary>
        public string Branch { get; }

        public NVAPIDriverAndBranchVersionDto(uint driverVersion, string branch)
        {
            DriverVersion = driverVersion;
            Branch = branch ?? string.Empty;
        }

        public bool Equals(NVAPIDriverAndBranchVersionDto other)
        {
            return DriverVersion == other.DriverVersion && string.Equals(Branch, other.Branch, StringComparison.Ordinal);
        }

        public override bool Equals(object? obj)
        {
            return obj is NVAPIDriverAndBranchVersionDto other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = DriverVersion.GetHashCode();
                hash = (hash * 31) + StringComparer.Ordinal.GetHashCode(Branch);
                return hash;
            }
        }

        public static bool operator ==(NVAPIDriverAndBranchVersionDto left, NVAPIDriverAndBranchVersionDto right) => left.Equals(right);
        public static bool operator !=(NVAPIDriverAndBranchVersionDto left, NVAPIDriverAndBranchVersionDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Chipset information DTO.
    /// </summary>
    public readonly struct NVAPIChipSetInfoDto : IEquatable<NVAPIChipSetInfoDto>
    {
        public uint VendorId { get; }
        public uint DeviceId { get; }
        public string VendorName { get; }
        public string ChipsetName { get; }
        public uint Flags { get; }
        public uint SubSystemVendorId { get; }
        public uint SubSystemDeviceId { get; }
        public string SubSystemVendorName { get; }
        public uint HbVendorId { get; }
        public uint HbDeviceId { get; }
        public uint HbSubSystemVendorId { get; }
        public uint HbSubSystemDeviceId { get; }

        public NVAPIChipSetInfoDto(
            uint vendorId,
            uint deviceId,
            string vendorName,
            string chipsetName,
            uint flags,
            uint subSystemVendorId,
            uint subSystemDeviceId,
            string subSystemVendorName,
            uint hbVendorId,
            uint hbDeviceId,
            uint hbSubSystemVendorId,
            uint hbSubSystemDeviceId)
        {
            VendorId = vendorId;
            DeviceId = deviceId;
            VendorName = vendorName ?? string.Empty;
            ChipsetName = chipsetName ?? string.Empty;
            Flags = flags;
            SubSystemVendorId = subSystemVendorId;
            SubSystemDeviceId = subSystemDeviceId;
            SubSystemVendorName = subSystemVendorName ?? string.Empty;
            HbVendorId = hbVendorId;
            HbDeviceId = hbDeviceId;
            HbSubSystemVendorId = hbSubSystemVendorId;
            HbSubSystemDeviceId = hbSubSystemDeviceId;
        }

        public static unsafe NVAPIChipSetInfoDto FromNative(NV_CHIPSET_INFO_v4 native)
        {
            var vendorName = NVAPIApiHelperString.ReadShortString(ref native.szVendorName.e0);
            var chipsetName = NVAPIApiHelperString.ReadShortString(ref native.szChipsetName.e0);
            var subSysVendorName = NVAPIApiHelperString.ReadShortString(ref native.szSubSysVendorName.e0);

            return new NVAPIChipSetInfoDto(
                native.vendorId,
                native.deviceId,
                vendorName,
                chipsetName,
                native.flags,
                native.subSysVendorId,
                native.subSysDeviceId,
                subSysVendorName,
                native.HBvendorId,
                native.HBdeviceId,
                native.HBsubSysVendorId,
                native.HBsubSysDeviceId);
        }

        public bool Equals(NVAPIChipSetInfoDto other)
        {
            return VendorId == other.VendorId
                && DeviceId == other.DeviceId
                && string.Equals(VendorName, other.VendorName, StringComparison.Ordinal)
                && string.Equals(ChipsetName, other.ChipsetName, StringComparison.Ordinal)
                && Flags == other.Flags
                && SubSystemVendorId == other.SubSystemVendorId
                && SubSystemDeviceId == other.SubSystemDeviceId
                && string.Equals(SubSystemVendorName, other.SubSystemVendorName, StringComparison.Ordinal)
                && HbVendorId == other.HbVendorId
                && HbDeviceId == other.HbDeviceId
                && HbSubSystemVendorId == other.HbSubSystemVendorId
                && HbSubSystemDeviceId == other.HbSubSystemDeviceId;
        }

        public override bool Equals(object? obj) => obj is NVAPIChipSetInfoDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = VendorId.GetHashCode();
                hash = (hash * 31) + DeviceId.GetHashCode();
                hash = (hash * 31) + StringComparer.Ordinal.GetHashCode(VendorName);
                hash = (hash * 31) + StringComparer.Ordinal.GetHashCode(ChipsetName);
                hash = (hash * 31) + Flags.GetHashCode();
                hash = (hash * 31) + SubSystemVendorId.GetHashCode();
                hash = (hash * 31) + SubSystemDeviceId.GetHashCode();
                hash = (hash * 31) + StringComparer.Ordinal.GetHashCode(SubSystemVendorName);
                hash = (hash * 31) + HbVendorId.GetHashCode();
                hash = (hash * 31) + HbDeviceId.GetHashCode();
                hash = (hash * 31) + HbSubSystemVendorId.GetHashCode();
                hash = (hash * 31) + HbSubSystemDeviceId.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIChipSetInfoDto left, NVAPIChipSetInfoDto right) => left.Equals(right);
        public static bool operator !=(NVAPIChipSetInfoDto left, NVAPIChipSetInfoDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Lid and dock information DTO.
    /// </summary>
    public readonly struct NVAPILidAndDockInfoDto : IEquatable<NVAPILidAndDockInfoDto>
    {
        public uint CurrentLidState { get; }
        public uint CurrentDockState { get; }
        public uint CurrentLidPolicy { get; }
        public uint CurrentDockPolicy { get; }
        public uint ForcedLidMechanismPresent { get; }
        public uint ForcedDockMechanismPresent { get; }

        public NVAPILidAndDockInfoDto(
            uint currentLidState,
            uint currentDockState,
            uint currentLidPolicy,
            uint currentDockPolicy,
            uint forcedLidMechanismPresent,
            uint forcedDockMechanismPresent)
        {
            CurrentLidState = currentLidState;
            CurrentDockState = currentDockState;
            CurrentLidPolicy = currentLidPolicy;
            CurrentDockPolicy = currentDockPolicy;
            ForcedLidMechanismPresent = forcedLidMechanismPresent;
            ForcedDockMechanismPresent = forcedDockMechanismPresent;
        }

        public static NVAPILidAndDockInfoDto FromNative(NV_LID_DOCK_PARAMS native)
        {
            return new NVAPILidAndDockInfoDto(
                native.currentLidState,
                native.currentDockState,
                native.currentLidPolicy,
                native.currentDockPolicy,
                native.forcedLidMechanismPresent,
                native.forcedDockMechanismPresent);
        }

        public bool Equals(NVAPILidAndDockInfoDto other)
        {
            return CurrentLidState == other.CurrentLidState
                && CurrentDockState == other.CurrentDockState
                && CurrentLidPolicy == other.CurrentLidPolicy
                && CurrentDockPolicy == other.CurrentDockPolicy
                && ForcedLidMechanismPresent == other.ForcedLidMechanismPresent
                && ForcedDockMechanismPresent == other.ForcedDockMechanismPresent;
        }

        public override bool Equals(object? obj) => obj is NVAPILidAndDockInfoDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = CurrentLidState.GetHashCode();
                hash = (hash * 31) + CurrentDockState.GetHashCode();
                hash = (hash * 31) + CurrentLidPolicy.GetHashCode();
                hash = (hash * 31) + CurrentDockPolicy.GetHashCode();
                hash = (hash * 31) + ForcedLidMechanismPresent.GetHashCode();
                hash = (hash * 31) + ForcedDockMechanismPresent.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPILidAndDockInfoDto left, NVAPILidAndDockInfoDto right) => left.Equals(right);
        public static bool operator !=(NVAPILidAndDockInfoDto left, NVAPILidAndDockInfoDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Display driver information DTO.
    /// </summary>
    public readonly struct NVAPIDisplayDriverInfoDto : IEquatable<NVAPIDisplayDriverInfoDto>
    {
        public uint DriverVersion { get; }
        public string BuildBranch { get; }
        public bool IsDchDriver { get; }
        public bool IsNvidiaStudioPackage { get; }
        public bool IsNvidiaGameReadyPackage { get; }
        public bool IsNvidiaRtxProductionBranchPackage { get; }
        public bool IsNvidiaRtxNewFeatureBranchPackage { get; }
        public string BuildBaseBranch { get; }
        public uint ReservedEx { get; }

        public NVAPIDisplayDriverInfoDto(
            uint driverVersion,
            string buildBranch,
            bool isDchDriver,
            bool isNvidiaStudioPackage,
            bool isNvidiaGameReadyPackage,
            bool isNvidiaRtxProductionBranchPackage,
            bool isNvidiaRtxNewFeatureBranchPackage,
            string buildBaseBranch,
            uint reservedEx)
        {
            DriverVersion = driverVersion;
            BuildBranch = buildBranch ?? string.Empty;
            IsDchDriver = isDchDriver;
            IsNvidiaStudioPackage = isNvidiaStudioPackage;
            IsNvidiaGameReadyPackage = isNvidiaGameReadyPackage;
            IsNvidiaRtxProductionBranchPackage = isNvidiaRtxProductionBranchPackage;
            IsNvidiaRtxNewFeatureBranchPackage = isNvidiaRtxNewFeatureBranchPackage;
            BuildBaseBranch = buildBaseBranch ?? string.Empty;
            ReservedEx = reservedEx;
        }

        public static unsafe NVAPIDisplayDriverInfoDto FromNative(_NV_DISPLAY_DRIVER_INFO_V2 native)
        {
            var buildBranch = NVAPIApiHelperString.ReadShortString(ref native.szBuildBranch.e0);
            var buildBaseBranch = NVAPIApiHelperString.ReadShortString(ref native.szBuildBaseBranch.e0);

            return new NVAPIDisplayDriverInfoDto(
                native.driverVersion,
                buildBranch,
                native.bIsDCHDriver != 0,
                native.bIsNVIDIAStudioPackage != 0,
                native.bIsNVIDIAGameReadyPackage != 0,
                native.bIsNVIDIARTXProductionBranchPackage != 0,
                native.bIsNVIDIARTXNewFeatureBranchPackage != 0,
                buildBaseBranch,
                native.reservedEx);
        }

        public bool Equals(NVAPIDisplayDriverInfoDto other)
        {
            return DriverVersion == other.DriverVersion
                && string.Equals(BuildBranch, other.BuildBranch, StringComparison.Ordinal)
                && IsDchDriver == other.IsDchDriver
                && IsNvidiaStudioPackage == other.IsNvidiaStudioPackage
                && IsNvidiaGameReadyPackage == other.IsNvidiaGameReadyPackage
                && IsNvidiaRtxProductionBranchPackage == other.IsNvidiaRtxProductionBranchPackage
                && IsNvidiaRtxNewFeatureBranchPackage == other.IsNvidiaRtxNewFeatureBranchPackage
                && string.Equals(BuildBaseBranch, other.BuildBaseBranch, StringComparison.Ordinal)
                && ReservedEx == other.ReservedEx;
        }

        public override bool Equals(object? obj) => obj is NVAPIDisplayDriverInfoDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = DriverVersion.GetHashCode();
                hash = (hash * 31) + StringComparer.Ordinal.GetHashCode(BuildBranch);
                hash = (hash * 31) + IsDchDriver.GetHashCode();
                hash = (hash * 31) + IsNvidiaStudioPackage.GetHashCode();
                hash = (hash * 31) + IsNvidiaGameReadyPackage.GetHashCode();
                hash = (hash * 31) + IsNvidiaRtxProductionBranchPackage.GetHashCode();
                hash = (hash * 31) + IsNvidiaRtxNewFeatureBranchPackage.GetHashCode();
                hash = (hash * 31) + StringComparer.Ordinal.GetHashCode(BuildBaseBranch);
                hash = (hash * 31) + ReservedEx.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPIDisplayDriverInfoDto left, NVAPIDisplayDriverInfoDto right) => left.Equals(right);
        public static bool operator !=(NVAPIDisplayDriverInfoDto left, NVAPIDisplayDriverInfoDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Physical GPU handle data from NvAPI_SYS_GetPhysicalGPUs.
    /// </summary>
    public readonly struct NVAPISystemPhysicalGpuHandleDto : IEquatable<NVAPISystemPhysicalGpuHandleDto>
    {
        internal IntPtr Handle { get; }
        public NVAPIPhysicalGpuHelper PhysicalGpu { get; }
        public _NV_ADAPTER_TYPE AdapterType { get; }

        internal NVAPISystemPhysicalGpuHandleDto(IntPtr handle, _NV_ADAPTER_TYPE adapterType, NVAPIApiHelper helper)
        {
            Handle = handle;
            AdapterType = adapterType;
            PhysicalGpu = new NVAPIPhysicalGpuHelper(helper, handle);
        }

        public static unsafe NVAPISystemPhysicalGpuHandleDto FromNative(NVAPIApiHelper helper, _NV_PHYSICAL_GPU_HANDLE_DATA native)
        {
            return new NVAPISystemPhysicalGpuHandleDto((IntPtr)native.hPhysicalGpu, native.adapterType, helper);
        }

        public bool Equals(NVAPISystemPhysicalGpuHandleDto other)
        {
            return Handle == other.Handle && AdapterType == other.AdapterType;
        }

        public override bool Equals(object? obj) => obj is NVAPISystemPhysicalGpuHandleDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = Handle.GetHashCode();
                hash = (hash * 31) + AdapterType.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPISystemPhysicalGpuHandleDto left, NVAPISystemPhysicalGpuHandleDto right) => left.Equals(right);
        public static bool operator !=(NVAPISystemPhysicalGpuHandleDto left, NVAPISystemPhysicalGpuHandleDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Logical GPU handle data from NvAPI_SYS_GetLogicalGPUs.
    /// </summary>
    public readonly struct NVAPISystemLogicalGpuHandleDto : IEquatable<NVAPISystemLogicalGpuHandleDto>
    {
        internal IntPtr Handle { get; }
        public NVAPILogicalGpuHelper LogicalGpu { get; }
        public _NV_ADAPTER_TYPE AdapterType { get; }

        internal NVAPISystemLogicalGpuHandleDto(IntPtr handle, _NV_ADAPTER_TYPE adapterType, NVAPIApiHelper helper)
        {
            Handle = handle;
            AdapterType = adapterType;
            LogicalGpu = new NVAPILogicalGpuHelper(helper, handle);
        }

        public static unsafe NVAPISystemLogicalGpuHandleDto FromNative(NVAPIApiHelper helper, _NV_LOGICAL_GPU_HANDLE_DATA native)
        {
            return new NVAPISystemLogicalGpuHandleDto((IntPtr)native.hLogicalGpu, native.adapterType, helper);
        }

        public bool Equals(NVAPISystemLogicalGpuHandleDto other)
        {
            return Handle == other.Handle && AdapterType == other.AdapterType;
        }

        public override bool Equals(object? obj) => obj is NVAPISystemLogicalGpuHandleDto other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = Handle.GetHashCode();
                hash = (hash * 31) + AdapterType.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(NVAPISystemLogicalGpuHandleDto left, NVAPISystemLogicalGpuHandleDto right) => left.Equals(right);
        public static bool operator !=(NVAPISystemLogicalGpuHandleDto left, NVAPISystemLogicalGpuHandleDto right) => !left.Equals(right);
    }

    internal static class NVAPIApiHelperString
    {
        public static unsafe string ReadShortString(ref sbyte first)
        {
            fixed (sbyte* p = &first)
            {
                return Marshal.PtrToStringAnsi((IntPtr)p) ?? string.Empty;
            }
        }
    }

}
