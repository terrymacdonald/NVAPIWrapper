using System;
using System.Runtime.InteropServices;
using System.Text;

namespace NVAPIWrapper
{
    /// <summary>
    /// Facade helper for an NVIDIA unattached display handle.
    /// </summary>
    public sealed class NVAPIUnAttachedDisplayHelper : IDisposable
    {
        private const uint NvApiIdGetPhysicalGpuFromUnAttachedDisplay = 0x5018ED61;
        private const uint NvApiIdCreateDisplayFromUnAttachedDisplay = 0x63F9799E;
        private const uint NvApiIdGetUnAttachedAssociatedDisplayName = 0x4888D790;
        private const uint NvApiIdDispGetAssociatedUnAttachedNvidiaDisplayHandle = 0xA70503B2;

        private readonly NVAPIApiHelper _apiHelper;
        private readonly IntPtr _handle;
        private bool _disposed;

        internal NVAPIUnAttachedDisplayHelper(NVAPIApiHelper apiHelper, IntPtr handle)
        {
            _apiHelper = apiHelper;
            _handle = handle;
        }

        /// <summary>
        /// Get the associated display name for this unattached display.
        /// </summary>
        /// <returns>Display name, or null if unavailable.</returns>
        public unsafe string? GetUnAttachedAssociatedDisplayName()
        {
            ThrowIfDisposed();

            var getName = GetDelegate<NvApiGetUnAttachedAssociatedDisplayNameDelegate>(
                NvApiIdGetUnAttachedAssociatedDisplayName,
                "NvAPI_GetUnAttachedAssociatedDisplayName");

            Span<sbyte> buffer = stackalloc sbyte[NVAPI.NVAPI_SHORT_STRING_MAX];
            buffer[0] = 0;

            fixed (sbyte* pBuffer = buffer)
            {
                var status = getName(GetHandle(), pBuffer);
                if (status == _NvAPI_Status.NVAPI_OK)
                    return Marshal.PtrToStringAnsi((IntPtr)pBuffer);

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                    return null;

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Get the unattached display helper associated with a display name (e.g., "\\.\DISPLAY1").
        /// </summary>
        /// <param name="displayName">Display name to resolve. If null, uses this unattached display's name.</param>
        /// <returns>Unattached display helper, or null if unavailable.</returns>
        public unsafe NVAPIUnAttachedDisplayHelper? GetAssociatedUnAttachedNvidiaDisplayHandle(string? displayName = null)
        {
            ThrowIfDisposed();

            if (string.IsNullOrWhiteSpace(displayName))
            {
                displayName = GetUnAttachedAssociatedDisplayName();
                if (string.IsNullOrWhiteSpace(displayName))
                    return null;
            }

            var getHandle = GetDelegate<NvApiDispGetAssociatedUnAttachedNvidiaDisplayHandleDelegate>(
                NvApiIdDispGetAssociatedUnAttachedNvidiaDisplayHandle,
                "NvAPI_DISP_GetAssociatedUnAttachedNvidiaDisplayHandle");

            var bytes = Encoding.ASCII.GetBytes(displayName + "\0");
            fixed (byte* pBytes = bytes)
            {
                NvUnAttachedDisplayHandle__* handle = null;
                var status = getHandle((sbyte*)pBytes, &handle);
                if (status == _NvAPI_Status.NVAPI_OK)
                    return new NVAPIUnAttachedDisplayHelper(_apiHelper, (IntPtr)handle);

                if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED ||
                    status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND ||
                    status == _NvAPI_Status.NVAPI_INVALID_ARGUMENT)
                {
                    return null;
                }

                throw new NVAPIException(status);
            }
        }

        /// <summary>
        /// Get the physical GPU associated with this unattached display.
        /// </summary>
        /// <returns>Physical GPU helper, or null if unavailable.</returns>
        public unsafe NVAPIPhysicalGpuHelper? GetPhysicalGpuFromUnAttachedDisplay()
        {
            ThrowIfDisposed();

            var getGpu = GetDelegate<NvApiGetPhysicalGpuFromUnAttachedDisplayDelegate>(
                NvApiIdGetPhysicalGpuFromUnAttachedDisplay,
                "NvAPI_GetPhysicalGPUFromUnAttachedDisplay");

            NvPhysicalGpuHandle__* physicalGpu = null;
            var status = getGpu(GetHandle(), &physicalGpu);
            if (status == _NvAPI_Status.NVAPI_OK)
                return new NVAPIPhysicalGpuHelper(_apiHelper, (IntPtr)physicalGpu);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Create a display handle from this unattached display.
        /// </summary>
        /// <returns>Display helper, or null if unavailable.</returns>
        public unsafe NVAPIDisplayHelper? CreateDisplayFromUnAttachedDisplay()
        {
            ThrowIfDisposed();

            var create = GetDelegate<NvApiCreateDisplayFromUnAttachedDisplayDelegate>(
                NvApiIdCreateDisplayFromUnAttachedDisplay,
                "NvAPI_CreateDisplayFromUnAttachedDisplay");

            NvDisplayHandle__* displayHandle = null;
            var status = create(GetHandle(), &displayHandle);
            if (status == _NvAPI_Status.NVAPI_OK)
                return new NVAPIDisplayHelper(_apiHelper, (IntPtr)displayHandle);

            if (status == _NvAPI_Status.NVAPI_NOT_SUPPORTED || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND)
                return null;

            throw new NVAPIException(status);
        }

        private unsafe NvUnAttachedDisplayHandle__* GetHandle()
        {
            return (NvUnAttachedDisplayHandle__*)_handle;
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
                throw new ObjectDisposedException(nameof(NVAPIUnAttachedDisplayHelper));

            _apiHelper.ThrowIfDisposed();
        }

        /// <summary>
        /// Dispose the helper and prevent further use.
        /// </summary>
        public void Dispose()
        {
            if (_disposed)
                return;

            _disposed = true;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGetUnAttachedAssociatedDisplayNameDelegate(NvUnAttachedDisplayHandle__* hNvUnAttachedDisp, sbyte* szDisplayName);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiGetPhysicalGpuFromUnAttachedDisplayDelegate(NvUnAttachedDisplayHandle__* hNvUnAttachedDisp, NvPhysicalGpuHandle__** pPhysicalGpu);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiCreateDisplayFromUnAttachedDisplayDelegate(NvUnAttachedDisplayHandle__* hNvUnAttachedDisp, NvDisplayHandle__** pNvDisplay);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiDispGetAssociatedUnAttachedNvidiaDisplayHandleDelegate(sbyte* szDisplayName, NvUnAttachedDisplayHandle__** pNvUnAttachedDispHandle);
    }
}
