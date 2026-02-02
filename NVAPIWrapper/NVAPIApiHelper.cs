using System;
using System.Runtime.InteropServices;
using System.Text;

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
        private const uint NvApiIdGetPhysicalGpuFromGpuId = 0x5380AD1A;
        private const uint NvApiIdGetLogicalGpuFromPhysicalGpu = 0xADD604D1;
        private const uint NvApiIdGetGpuIdFromPhysicalGpu = 0x6533EA3E;
        private const uint NvApiIdGetErrorMessage = 0x6C2D048C;
        private const uint NvApiIdGetInterfaceVersionString = 0x01053FA5;
        private const uint NvApiIdEnumTccPhysicalGpus = 0xD9930B07;
        private const uint NvApiIdEventRegisterCallback = 0xE6DBEA69;
        private const uint NvApiIdEventUnregisterCallback = 0xDE1F9B45;
        private const uint NvApiIdNgxGetOverrideState = 0x3FD96FBA;
        private const uint NvApiIdNgxSetOverrideState = 0xB60FCB4E;
        private const uint NvApiIdRegisterRiseCallback = 0x9CFE8F94;
        private const uint NvApiIdRequestRise = 0x5047DE98;
        private const uint NvApiIdUninstallRise = 0xAB8D09F6;
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
        /// Get a physical GPU helper from a GPU ID.
        /// </summary>
        /// <param name="gpuId">GPU ID.</param>
        /// <returns>Physical GPU helper, or null if unavailable.</returns>
        public unsafe NVAPIPhysicalGpuHelper? GetPhysicalGpuFromGpuId(uint gpuId)
        {
            ThrowIfDisposed();

            var getGpu = GetDelegate<NvApiGetPhysicalGpuFromGpuIdDelegate>(
                NvApiIdGetPhysicalGpuFromGpuId,
                "NvAPI_GetPhysicalGPUFromGPUID");

            NvPhysicalGpuHandle__* handle = null;
            var status = getGpu(gpuId, &handle);
            if (status == _NvAPI_Status.NVAPI_OK)
                return new NVAPIPhysicalGpuHelper(this, (IntPtr)handle);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the logical GPU helper from a physical GPU helper.
        /// </summary>
        /// <param name="physicalGpu">Physical GPU helper.</param>
        /// <returns>Logical GPU helper, or null if unavailable.</returns>
        public unsafe NVAPILogicalGpuHelper? GetLogicalGpuFromPhysicalGpu(NVAPIPhysicalGpuHelper physicalGpu)
        {
            ThrowIfDisposed();

            if (physicalGpu == null)
                throw new ArgumentNullException(nameof(physicalGpu));

            physicalGpu.ThrowIfDisposed();

            var getLogical = GetDelegate<NvApiGetLogicalGpuFromPhysicalGpuDelegate>(
                NvApiIdGetLogicalGpuFromPhysicalGpu,
                "NvAPI_GetLogicalGPUFromPhysicalGPU");

            NvLogicalGpuHandle__* handle = null;
            var status = getLogical(physicalGpu.GetHandle(), &handle);
            if (status == _NvAPI_Status.NVAPI_OK)
                return new NVAPILogicalGpuHelper(this, (IntPtr)handle);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the GPU ID from a physical GPU helper.
        /// </summary>
        /// <param name="physicalGpu">Physical GPU helper.</param>
        /// <returns>GPU ID, or null if unavailable.</returns>
        public unsafe uint? GetGpuIdFromPhysicalGpu(NVAPIPhysicalGpuHelper physicalGpu)
        {
            ThrowIfDisposed();

            if (physicalGpu == null)
                throw new ArgumentNullException(nameof(physicalGpu));

            physicalGpu.ThrowIfDisposed();

            var getId = GetDelegate<NvApiGetGpuIdFromPhysicalGpuDelegate>(
                NvApiIdGetGpuIdFromPhysicalGpu,
                "NvAPI_GetGPUIDfromPhysicalGPU");

            uint gpuId = 0;
            var status = getId(physicalGpu.GetHandle(), &gpuId);
            if (status == _NvAPI_Status.NVAPI_OK)
                return gpuId;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
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

        /// <summary>
        /// Enumerate physical GPU helpers that are in TCC mode.
        /// </summary>
        /// <returns>Array of physical GPU helpers, or empty if none are found.</returns>
        public unsafe NVAPIPhysicalGpuHelper[] EnumerateTccPhysicalGpus()
        {
            ThrowIfDisposed();

            var functionPtr = _api.TryGetFunctionPointer(NvApiIdEnumTccPhysicalGpus);
            if (functionPtr == IntPtr.Zero)
                return Array.Empty<NVAPIPhysicalGpuHelper>();

            var enumerate = Marshal.GetDelegateForFunctionPointer<NvApiEnumTccPhysicalGpusDelegate>(functionPtr);
            var handles = stackalloc NvPhysicalGpuHandle__*[NVAPI.NVAPI_MAX_PHYSICAL_GPUS];
            uint count = 0;
            var status = enumerate(handles, &count);

            if (status == _NvAPI_Status.NVAPI_OK)
            {
                if (count == 0)
                    return Array.Empty<NVAPIPhysicalGpuHelper>();

                var helpers = new NVAPIPhysicalGpuHelper[count];
                for (var i = 0; i < count; i++)
                {
                    helpers[i] = new NVAPIPhysicalGpuHelper(this, (IntPtr)handles[i]);
                }

                return helpers;
            }

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return Array.Empty<NVAPIPhysicalGpuHelper>();

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Enumerate unattached display helpers.
        /// </summary>
        /// <returns>Array of unattached display helpers, or empty if none are found.</returns>
        public unsafe NVAPIUnAttachedDisplayHelper[] EnumerateNvidiaUnAttachedDisplayHandles()
        {
            ThrowIfDisposed();

            var handles = _api.EnumerateNvidiaUnAttachedDisplayHandles();
            if (handles.Length == 0)
                return Array.Empty<NVAPIUnAttachedDisplayHelper>();

            var helpers = new NVAPIUnAttachedDisplayHelper[handles.Length];
            for (var i = 0; i < handles.Length; i++)
            {
                helpers[i] = new NVAPIUnAttachedDisplayHelper(this, (IntPtr)handles[i]);
            }

            return helpers;
        }

        /// <summary>
        /// Enumerate G-Sync device helpers.
        /// </summary>
        /// <returns>Array of G-Sync helpers, or empty if none are found.</returns>
        public unsafe NVAPIQuadroGSyncHelper[] EnumerateGSyncDevices()
        {
            ThrowIfDisposed();

            var handles = _api.EnumerateGSyncDevices();
            if (handles.Length == 0)
                return Array.Empty<NVAPIQuadroGSyncHelper>();

            var helpers = new NVAPIQuadroGSyncHelper[handles.Length];
            for (var i = 0; i < handles.Length; i++)
            {
                helpers[i] = new NVAPIQuadroGSyncHelper(this, (IntPtr)handles[i]);
            }

            return helpers;
        }

        /// <summary>
        /// Convert an NVAPI status to a human-readable message.
        /// </summary>
        /// <param name="status">NVAPI status value.</param>
        /// <returns>Message string, or null if unavailable.</returns>
        public unsafe string? GetErrorMessage(_NvAPI_Status status)
        {
            ThrowIfDisposed();

            var functionPtr = _api.TryGetFunctionPointer(NvApiIdGetErrorMessage);
            if (functionPtr == IntPtr.Zero)
                return null;

            var getErrorMessage = Marshal.GetDelegateForFunctionPointer<NvApiGetErrorMessageDelegate>(functionPtr);
            Span<sbyte> buffer = stackalloc sbyte[NVAPI.NVAPI_SHORT_STRING_MAX];
            buffer[0] = 0;
            fixed (sbyte* pBuffer = buffer)
            {
                var result = getErrorMessage(status, pBuffer);
                if (result != _NvAPI_Status.NVAPI_OK)
                    return null;

                return Marshal.PtrToStringAnsi((IntPtr)pBuffer);
            }
        }

        /// <summary>
        /// Get the NVAPI interface version string.
        /// </summary>
        /// <returns>Version string, or null if unavailable.</returns>
        public string? GetInterfaceVersionString()
        {
            ThrowIfDisposed();
            return _api.GetInterfaceVersionString();
        }

        /// <summary>
        /// Register an NVAPI event callback for the current process.
        /// </summary>
        /// <param name="settings">Callback settings.</param>
        /// <returns>Event handle helper, or null if unsupported.</returns>
        /// <remarks>Caller must keep the callback delegate alive for the lifetime of the registration.</remarks>
        public unsafe NVAPIEventHandleHelper? RegisterEventCallback(NVAPIEventCallbackSettingsDto settings)
        {
            ThrowIfDisposed();

            var functionPtr = _api.TryGetFunctionPointer(NvApiIdEventRegisterCallback);
            if (functionPtr == IntPtr.Zero)
                return null;

            var register = Marshal.GetDelegateForFunctionPointer<NvApiEventRegisterCallbackDelegate>(functionPtr);
            var native = settings.ToNative();
            NvEventHandle__* handle = null;
            var status = register(&native, &handle);

            if (status == _NvAPI_Status.NVAPI_OK)
                return new NVAPIEventHandleHelper(this, (IntPtr)handle);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get the NGX override state for a process ID.
        /// </summary>
        /// <param name="processId">Process identifier.</param>
        /// <returns>NGX override state DTO, or null if unsupported.</returns>
        public unsafe NVAPINGXOverrideStateDto? GetNgxOverrideState(uint processId)
        {
            ThrowIfDisposed();

            var functionPtr = _api.TryGetFunctionPointer(NvApiIdNgxGetOverrideState);
            if (functionPtr == IntPtr.Zero)
                return null;

            var getState = Marshal.GetDelegateForFunctionPointer<NvApiNgxGetOverrideStateDelegate>(functionPtr);
            var native = CreateNgxOverrideGetParams(processId);
            var status = getState(&native);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPINGXOverrideStateDto.FromNative(native);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Set the NGX override state for a process.
        /// </summary>
        /// <param name="settings">NGX override settings.</param>
        /// <returns>True if set, or null if unsupported.</returns>
        public unsafe bool? SetNgxOverrideState(NVAPINGXOverrideSetDto settings)
        {
            ThrowIfDisposed();

            var functionPtr = _api.TryGetFunctionPointer(NvApiIdNgxSetOverrideState);
            if (functionPtr == IntPtr.Zero)
                return null;

            var setState = Marshal.GetDelegateForFunctionPointer<NvApiNgxSetOverrideStateDelegate>(functionPtr);
            var native = settings.ToNative();
            var status = setState(&native);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Register a RISE callback for the current process.
        /// </summary>
        /// <param name="settings">RISE callback settings.</param>
        /// <returns>True if registered, or null if unsupported.</returns>
        /// <remarks>Caller must keep the callback delegate alive for the lifetime of the registration.</remarks>
        public unsafe bool? RegisterRiseCallback(NVAPIRiseCallbackSettingsDto settings)
        {
            ThrowIfDisposed();

            var functionPtr = _api.TryGetFunctionPointer(NvApiIdRegisterRiseCallback);
            if (functionPtr == IntPtr.Zero)
                return null;

            var register = Marshal.GetDelegateForFunctionPointer<NvApiRegisterRiseCallbackDelegate>(functionPtr);
            var native = settings.ToNative();
            var status = register(&native);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Request RISE assistance.
        /// </summary>
        /// <param name="request">RISE request settings.</param>
        /// <returns>Updated request DTO, or null if unsupported.</returns>
        public unsafe NVAPIRiseRequestDto? RequestRise(NVAPIRiseRequestDto request)
        {
            ThrowIfDisposed();

            var functionPtr = _api.TryGetFunctionPointer(NvApiIdRequestRise);
            if (functionPtr == IntPtr.Zero)
                return null;

            var requestRise = Marshal.GetDelegateForFunctionPointer<NvApiRequestRiseDelegate>(functionPtr);
            var native = request.ToNative();
            var status = requestRise(&native);
            if (status == _NvAPI_Status.NVAPI_OK)
                return NVAPIRiseRequestDto.FromNative(request, native);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Uninstall RISE from the system.
        /// </summary>
        /// <returns>True if uninstalled, or null if unsupported.</returns>
        public unsafe bool? UninstallRise()
        {
            ThrowIfDisposed();

            var functionPtr = _api.TryGetFunctionPointer(NvApiIdUninstallRise);
            if (functionPtr == IntPtr.Zero)
                return null;

            var uninstall = Marshal.GetDelegateForFunctionPointer<NvApiUninstallRiseDelegate>(functionPtr);
            var native = CreateRiseUninstallSettings();
            var status = uninstall(&native);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
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

        private static _NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1 CreateNgxOverrideGetParams(uint processId)
        {
            return new _NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1
            {
                version = NVAPI.NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_VER,
                processIdentifier = processId
            };
        }

        internal static _NV_NGX_DLSS_OVERRIDE_SET_STATE_PARAMS_V1 CreateNgxOverrideSetParams(NVAPINGXOverrideSetDto settings)
        {
            return new _NV_NGX_DLSS_OVERRIDE_SET_STATE_PARAMS_V1
            {
                version = NVAPI.NV_NGX_DLSS_OVERRIDE_SET_STATE_PARAMS_VER,
                processIdentifier = settings.ProcessId,
                feature = settings.Feature,
                feedbackMask = settings.FeedbackMask
            };
        }

        internal static unsafe _NV_RISE_CALLBACK_SETTINGS_V1 CreateRiseCallbackSettings(NVAPIRiseCallbackSettingsDto settings)
        {
            var native = new _NV_RISE_CALLBACK_SETTINGS_V1
            {
                version = NVAPI.NV_RISE_CALLBACK_SETTINGS_VER,
                callback = (delegate* unmanaged[Cdecl]<_NV_RISE_CALLBACK_DATA_V1*, void>)settings.Callback
            };
            native.super.pCallbackParam = (void*)settings.CallbackParam;
            return native;
        }

        internal static _NV_REQUEST_RISE_SETTINGS_V1 CreateRiseRequestSettings(NVAPIRiseRequestDto request)
        {
            var native = new _NV_REQUEST_RISE_SETTINGS_V1
            {
                version = NVAPI.NV_REQUEST_RISE_SETTINGS_VER,
                contentType = request.ContentType,
                completed = 0
            };
            WriteRiseContent(request.Content, ref native);
            return native;
        }

        private static _NV_UNINSTALL_RISE_SETTINGS_V1 CreateRiseUninstallSettings()
        {
            return new _NV_UNINSTALL_RISE_SETTINGS_V1
            {
                version = NVAPI.NV_UNINSTALL_RISE_SETTINGS_VER
            };
        }

        private static void WriteRiseContent(string? content, ref _NV_REQUEST_RISE_SETTINGS_V1 native)
        {
            var span = MemoryMarshal.CreateSpan(ref native.content.e0, NVAPIRiseRequestDto.MaxContentLength);
            span.Clear();
            if (string.IsNullOrEmpty(content))
                return;

            var bytes = Encoding.ASCII.GetBytes(content);
            var length = Math.Min(bytes.Length, span.Length - 1);
            for (var i = 0; i < length; i++)
                span[i] = (sbyte)bytes[i];
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

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGetPhysicalGpuFromGpuIdDelegate(uint gpuId, NvPhysicalGpuHandle__** pPhysicalGpu);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGetLogicalGpuFromPhysicalGpuDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, NvLogicalGpuHandle__** pLogicalGpu);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGetGpuIdFromPhysicalGpuDelegate(NvPhysicalGpuHandle__* hPhysicalGpu, uint* pGpuId);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiEnumTccPhysicalGpusDelegate(NvPhysicalGpuHandle__** nvGPUHandle, uint* pGpuCount);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGetErrorMessageDelegate(_NvAPI_Status status, sbyte* description);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiEventRegisterCallbackDelegate(NV_EVENT_REGISTER_CALLBACK* eventCallback, NvEventHandle__** phClient);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiEventUnregisterCallbackDelegate(NvEventHandle__* hClient);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiNgxGetOverrideStateDelegate(_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1* pGetOverrideStateParams);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiNgxSetOverrideStateDelegate(_NV_NGX_DLSS_OVERRIDE_SET_STATE_PARAMS_V1* pSetOverrideStateParams);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiRegisterRiseCallbackDelegate(_NV_RISE_CALLBACK_SETTINGS_V1* pCallbackSettings);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiRequestRiseDelegate(_NV_REQUEST_RISE_SETTINGS_V1* requestContent);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiUninstallRiseDelegate(_NV_UNINSTALL_RISE_SETTINGS_V1* requestContent);

        internal unsafe void UnregisterEventHandle(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
                return;

            var functionPtr = _api.TryGetFunctionPointer(NvApiIdEventUnregisterCallback);
            if (functionPtr == IntPtr.Zero)
                return;

            var unregister = Marshal.GetDelegateForFunctionPointer<NvApiEventUnregisterCallbackDelegate>(functionPtr);
            var status = unregister((NvEventHandle__*)handle);
            if (status == _NvAPI_Status.NVAPI_OK)
                return;

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND
                || status == _NvAPI_Status.NVAPI_INVALID_HANDLE)
                return;

            throw new NVAPIException(status);
        }

    }

    /// <summary>
    /// Event callback registration kind.
    /// </summary>
    public enum NVAPIEventCallbackKind
    {
        /// <summary>
        /// QSYNC event callback.
        /// </summary>
        Qsync,

        /// <summary>
        /// Display output mode change event callback.
        /// </summary>
        DisplayOutputModeChange,

        /// <summary>
        /// Display colorimetry change event callback.
        /// </summary>
        DisplayColorimetryChange
    }

    /// <summary>
    /// Event callback settings DTO.
    /// </summary>
    public readonly struct NVAPIEventCallbackSettingsDto : IEquatable<NVAPIEventCallbackSettingsDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NVAPIEventCallbackSettingsDto"/> struct.
        /// </summary>
        /// <param name="eventId">Event type.</param>
        /// <param name="callbackKind">Callback kind.</param>
        /// <param name="callbackParam">Callback parameter pointer.</param>
        /// <param name="callback">Callback function pointer.</param>
        public NVAPIEventCallbackSettingsDto(
            NV_EVENT_TYPE eventId,
            NVAPIEventCallbackKind callbackKind,
            IntPtr callbackParam,
            IntPtr callback)
        {
            EventId = eventId;
            CallbackKind = callbackKind;
            CallbackParam = callbackParam;
            Callback = callback;
        }

        /// <summary>
        /// Event type.
        /// </summary>
        public NV_EVENT_TYPE EventId { get; }

        /// <summary>
        /// Callback kind to map the union field.
        /// </summary>
        public NVAPIEventCallbackKind CallbackKind { get; }

        /// <summary>
        /// Callback parameter pointer.
        /// </summary>
        public IntPtr CallbackParam { get; }

        /// <summary>
        /// Callback function pointer.
        /// </summary>
        public IntPtr Callback { get; }

        internal unsafe NV_EVENT_REGISTER_CALLBACK ToNative()
        {
            var native = new NV_EVENT_REGISTER_CALLBACK
            {
                version = NVAPI.NV_EVENT_REGISTER_CALLBACK_VERSION,
                eventId = EventId,
                callbackParam = (void*)CallbackParam
            };

            switch (CallbackKind)
            {
                case NVAPIEventCallbackKind.Qsync:
                    native.nvCallBackFunc.nvQSYNCEventCallback = (delegate* unmanaged[Cdecl]<NV_QSYNC_EVENT_DATA, void*, void>)Callback;
                    break;
                case NVAPIEventCallbackKind.DisplayOutputModeChange:
                    native.nvCallBackFunc.nvDisplayOutputModeChangeEventCallback = (delegate* unmanaged[Cdecl]<_NV_DISPLAY_OUTPUT_MODE_CHANGE_EVENT_DATA*, void*, void>)Callback;
                    break;
                case NVAPIEventCallbackKind.DisplayColorimetryChange:
                    native.nvCallBackFunc.nvDisplayColorimetryChangeEventCallback = (delegate* unmanaged[Cdecl]<_NV_DISPLAY_COLORIMETRY_CHANGE_EVENT_DATA*, void*, void>)Callback;
                    break;
            }

            return native;
        }

        public bool Equals(NVAPIEventCallbackSettingsDto other)
        {
            return EventId == other.EventId
                && CallbackKind == other.CallbackKind
                && CallbackParam == other.CallbackParam
                && Callback == other.Callback;
        }

        public override bool Equals(object? obj) => obj is NVAPIEventCallbackSettingsDto other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(EventId, CallbackKind, CallbackParam, Callback);
        public static bool operator ==(NVAPIEventCallbackSettingsDto left, NVAPIEventCallbackSettingsDto right) => left.Equals(right);
        public static bool operator !=(NVAPIEventCallbackSettingsDto left, NVAPIEventCallbackSettingsDto right) => !left.Equals(right);
    }

    /// <summary>
    /// NGX override state DTO.
    /// </summary>
    public readonly struct NVAPINGXOverrideStateDto : IEquatable<NVAPINGXOverrideStateDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NVAPINGXOverrideStateDto"/> struct.
        /// </summary>
        public NVAPINGXOverrideStateDto(
            uint processId,
            ulong feedbackMaskSr,
            ulong feedbackMaskRr,
            ulong feedbackMaskFg,
            float scalingRatio,
            uint performanceMode,
            uint renderPreset,
            uint frameGenerationCount,
            uint frameGenerationPreset)
        {
            ProcessId = processId;
            FeedbackMaskSr = feedbackMaskSr;
            FeedbackMaskRr = feedbackMaskRr;
            FeedbackMaskFg = feedbackMaskFg;
            ScalingRatio = scalingRatio;
            PerformanceMode = performanceMode;
            RenderPreset = renderPreset;
            FrameGenerationCount = frameGenerationCount;
            FrameGenerationPreset = frameGenerationPreset;
        }

        /// <summary>
        /// Process identifier.
        /// </summary>
        public uint ProcessId { get; }

        /// <summary>
        /// DLSS SR feedback mask.
        /// </summary>
        public ulong FeedbackMaskSr { get; }

        /// <summary>
        /// DLSS RR feedback mask.
        /// </summary>
        public ulong FeedbackMaskRr { get; }

        /// <summary>
        /// DLSS FG feedback mask.
        /// </summary>
        public ulong FeedbackMaskFg { get; }

        /// <summary>
        /// DLSS scaling ratio.
        /// </summary>
        public float ScalingRatio { get; }

        /// <summary>
        /// DLSS performance mode.
        /// </summary>
        public uint PerformanceMode { get; }

        /// <summary>
        /// DLSS render preset.
        /// </summary>
        public uint RenderPreset { get; }

        /// <summary>
        /// DLSS frame generation count target.
        /// </summary>
        public uint FrameGenerationCount { get; }

        /// <summary>
        /// DLSS frame generation preset.
        /// </summary>
        public uint FrameGenerationPreset { get; }

        internal static NVAPINGXOverrideStateDto FromNative(_NV_NGX_DLSS_OVERRIDE_GET_STATE_PARAMS_V1 native)
        {
            return new NVAPINGXOverrideStateDto(
                native.processIdentifier,
                native.feedbackMaskSR,
                native.feedbackMaskRR,
                native.feedbackMaskFG,
                native.scalingRatio,
                native.performanceMode,
                native.renderPreset,
                native.frameGenerationCount,
                native.frameGenerationPreset);
        }

        public bool Equals(NVAPINGXOverrideStateDto other)
        {
            return ProcessId == other.ProcessId
                && FeedbackMaskSr == other.FeedbackMaskSr
                && FeedbackMaskRr == other.FeedbackMaskRr
                && FeedbackMaskFg == other.FeedbackMaskFg
                && ScalingRatio.Equals(other.ScalingRatio)
                && PerformanceMode == other.PerformanceMode
                && RenderPreset == other.RenderPreset
                && FrameGenerationCount == other.FrameGenerationCount
                && FrameGenerationPreset == other.FrameGenerationPreset;
        }

        public override bool Equals(object? obj) => obj is NVAPINGXOverrideStateDto other && Equals(other);
        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(ProcessId);
            hash.Add(FeedbackMaskSr);
            hash.Add(FeedbackMaskRr);
            hash.Add(FeedbackMaskFg);
            hash.Add(ScalingRatio);
            hash.Add(PerformanceMode);
            hash.Add(RenderPreset);
            hash.Add(FrameGenerationCount);
            hash.Add(FrameGenerationPreset);
            return hash.ToHashCode();
        }

        public static bool operator ==(NVAPINGXOverrideStateDto left, NVAPINGXOverrideStateDto right) => left.Equals(right);
        public static bool operator !=(NVAPINGXOverrideStateDto left, NVAPINGXOverrideStateDto right) => !left.Equals(right);
    }

    /// <summary>
    /// NGX override set DTO.
    /// </summary>
    public readonly struct NVAPINGXOverrideSetDto : IEquatable<NVAPINGXOverrideSetDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NVAPINGXOverrideSetDto"/> struct.
        /// </summary>
        public NVAPINGXOverrideSetDto(uint processId, uint feature, ulong feedbackMask)
        {
            ProcessId = processId;
            Feature = feature;
            FeedbackMask = feedbackMask;
        }

        /// <summary>
        /// Process identifier.
        /// </summary>
        public uint ProcessId { get; }

        /// <summary>
        /// DLSS feature ID.
        /// </summary>
        public uint Feature { get; }

        /// <summary>
        /// Feedback mask.
        /// </summary>
        public ulong FeedbackMask { get; }

        internal _NV_NGX_DLSS_OVERRIDE_SET_STATE_PARAMS_V1 ToNative()
        {
            return NVAPIApiHelper.CreateNgxOverrideSetParams(this);
        }

        public bool Equals(NVAPINGXOverrideSetDto other)
        {
            return ProcessId == other.ProcessId
                && Feature == other.Feature
                && FeedbackMask == other.FeedbackMask;
        }

        public override bool Equals(object? obj) => obj is NVAPINGXOverrideSetDto other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(ProcessId, Feature, FeedbackMask);
        public static bool operator ==(NVAPINGXOverrideSetDto left, NVAPINGXOverrideSetDto right) => left.Equals(right);
        public static bool operator !=(NVAPINGXOverrideSetDto left, NVAPINGXOverrideSetDto right) => !left.Equals(right);
    }

    /// <summary>
    /// RISE callback settings DTO.
    /// </summary>
    public readonly struct NVAPIRiseCallbackSettingsDto : IEquatable<NVAPIRiseCallbackSettingsDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NVAPIRiseCallbackSettingsDto"/> struct.
        /// </summary>
        /// <param name="callbackParam">Callback parameter pointer.</param>
        /// <param name="callback">Callback function pointer.</param>
        public NVAPIRiseCallbackSettingsDto(IntPtr callbackParam, IntPtr callback)
        {
            CallbackParam = callbackParam;
            Callback = callback;
        }

        /// <summary>
        /// Callback parameter pointer.
        /// </summary>
        public IntPtr CallbackParam { get; }

        /// <summary>
        /// Callback function pointer.
        /// </summary>
        public IntPtr Callback { get; }

        internal unsafe _NV_RISE_CALLBACK_SETTINGS_V1 ToNative()
        {
            return NVAPIApiHelper.CreateRiseCallbackSettings(this);
        }

        public bool Equals(NVAPIRiseCallbackSettingsDto other)
        {
            return CallbackParam == other.CallbackParam && Callback == other.Callback;
        }

        public override bool Equals(object? obj) => obj is NVAPIRiseCallbackSettingsDto other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(CallbackParam, Callback);
        public static bool operator ==(NVAPIRiseCallbackSettingsDto left, NVAPIRiseCallbackSettingsDto right) => left.Equals(right);
        public static bool operator !=(NVAPIRiseCallbackSettingsDto left, NVAPIRiseCallbackSettingsDto right) => !left.Equals(right);
    }

    /// <summary>
    /// RISE request DTO.
    /// </summary>
    public readonly struct NVAPIRiseRequestDto : IEquatable<NVAPIRiseRequestDto>
    {
        /// <summary>
        /// Maximum content length for RISE requests.
        /// </summary>
        public const int MaxContentLength = 4096;

        /// <summary>
        /// Initializes a new instance of the <see cref="NVAPIRiseRequestDto"/> struct.
        /// </summary>
        /// <param name="contentType">Content type.</param>
        /// <param name="content">Content string.</param>
        /// <param name="completed">Completed flag.</param>
        public NVAPIRiseRequestDto(_NV_RISE_CONTENT_TYPE contentType, string content, bool completed)
        {
            ContentType = contentType;
            Content = content ?? string.Empty;
            Completed = completed;
        }

        /// <summary>
        /// Content type.
        /// </summary>
        public _NV_RISE_CONTENT_TYPE ContentType { get; }

        /// <summary>
        /// Content string.
        /// </summary>
        public string Content { get; }

        /// <summary>
        /// True if request is completed.
        /// </summary>
        public bool Completed { get; }

        internal _NV_REQUEST_RISE_SETTINGS_V1 ToNative()
        {
            return NVAPIApiHelper.CreateRiseRequestSettings(this);
        }

        internal static NVAPIRiseRequestDto FromNative(NVAPIRiseRequestDto original, _NV_REQUEST_RISE_SETTINGS_V1 native)
        {
            return new NVAPIRiseRequestDto(original.ContentType, original.Content, native.completed != 0);
        }

        public bool Equals(NVAPIRiseRequestDto other)
        {
            return ContentType == other.ContentType
                && string.Equals(Content, other.Content, StringComparison.Ordinal)
                && Completed == other.Completed;
        }

        public override bool Equals(object? obj) => obj is NVAPIRiseRequestDto other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(ContentType, Content, Completed);
        public static bool operator ==(NVAPIRiseRequestDto left, NVAPIRiseRequestDto right) => left.Equals(right);
        public static bool operator !=(NVAPIRiseRequestDto left, NVAPIRiseRequestDto right) => !left.Equals(right);
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
