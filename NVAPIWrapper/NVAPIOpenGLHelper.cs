using System;
using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <summary>
    /// Facade helper for OpenGL-related NVAPI functions.
    /// </summary>
    public sealed class NVAPIOpenGLHelper : IDisposable
    {
        private const uint NvApiIdOglExpertModeSet = 0x3805EF7A;
        private const uint NvApiIdOglExpertModeGet = 0x22ED9516;
        private const uint NvApiIdOglExpertModeDefaultsSet = 0xB47A657E;
        private const uint NvApiIdOglExpertModeDefaultsGet = 0xAE921F12;

        private readonly NVAPIApiHelper _apiHelper;
        private bool _disposed;

        private NvApiOglExpertCallbackDelegate? _callbackWrapper;
        private NVAPIOglExpertCallback? _callbackManaged;

        internal NVAPIOpenGLHelper(NVAPIApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        /// <summary>
        /// Configure OpenGL expert mode for the current context.
        /// </summary>
        /// <param name="detailMask">Detail mask (NVAPI_OGLEXPERT_DETAIL_*).</param>
        /// <param name="reportMask">Report mask (NVAPI_OGLEXPERT_REPORT_*).</param>
        /// <param name="outputMask">Output mask (NVAPI_OGLEXPERT_OUTPUT_*).</param>
        /// <param name="callback">Optional callback for output-to-callback.</param>
        /// <returns>True if applied, null if unsupported.</returns>
        public unsafe bool? ExpertModeSet(uint detailMask, uint reportMask, uint outputMask, NVAPIOglExpertCallback? callback = null)
        {
            ThrowIfDisposed();

            var set = GetDelegate<NvApiOglExpertModeSetDelegate>(NvApiIdOglExpertModeSet, "NvAPI_OGL_ExpertModeSet");

            _callbackManaged = callback;
            _callbackWrapper = callback == null ? null : new NvApiOglExpertCallbackDelegate(HandleExpertCallback);

            var status = set(detailMask, reportMask, outputMask, _callbackWrapper);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get OpenGL expert mode settings for the current context.
        /// </summary>
        /// <returns>DTO with current settings, or null if unsupported.</returns>
        public unsafe NVAPIOglExpertModeDto? ExpertModeGet()
        {
            ThrowIfDisposed();

            var get = GetDelegate<NvApiOglExpertModeGetDelegate>(NvApiIdOglExpertModeGet, "NvAPI_OGL_ExpertModeGet");
            uint detail = 0;
            uint report = 0;
            uint output = 0;
            IntPtr callback = IntPtr.Zero;

            var status = get(&detail, &report, &output, &callback);
            if (status == _NvAPI_Status.NVAPI_OK)
                return new NVAPIOglExpertModeDto(detail, report, output, callback);

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Set OpenGL expert mode defaults for new contexts.
        /// </summary>
        /// <param name="detailMask">Detail mask (NVAPI_OGLEXPERT_DETAIL_*).</param>
        /// <param name="reportMask">Report mask (NVAPI_OGLEXPERT_REPORT_*).</param>
        /// <param name="outputMask">Output mask (NVAPI_OGLEXPERT_OUTPUT_*).</param>
        /// <returns>True if applied, null if unsupported.</returns>
        public unsafe bool? ExpertModeDefaultsSet(uint detailMask, uint reportMask, uint outputMask)
        {
            ThrowIfDisposed();

            var set = GetDelegate<NvApiOglExpertModeDefaultsSetDelegate>(
                NvApiIdOglExpertModeDefaultsSet,
                "NvAPI_OGL_ExpertModeDefaultsSet");

            var status = set(detailMask, reportMask, outputMask);
            if (status == _NvAPI_Status.NVAPI_OK)
                return true;

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        /// <summary>
        /// Get OpenGL expert mode default settings.
        /// </summary>
        /// <returns>DTO with defaults, or null if unsupported.</returns>
        public unsafe NVAPIOglExpertDefaultsDto? ExpertModeDefaultsGet()
        {
            ThrowIfDisposed();

            var get = GetDelegate<NvApiOglExpertModeDefaultsGetDelegate>(
                NvApiIdOglExpertModeDefaultsGet,
                "NvAPI_OGL_ExpertModeDefaultsGet");

            uint detail = 0;
            uint report = 0;
            uint output = 0;
            var status = get(&detail, &report, &output);
            if (status == _NvAPI_Status.NVAPI_OK)
                return new NVAPIOglExpertDefaultsDto(detail, report, output);

            if (IsUnsupported(status))
                return null;

            throw new NVAPIException(status);
        }

        private unsafe void HandleExpertCallback(uint categoryId, uint messageId, uint detailLevel, int objectId, sbyte* messageStr)
        {
            var message = Marshal.PtrToStringAnsi((IntPtr)messageStr) ?? string.Empty;
            _callbackManaged?.Invoke(categoryId, messageId, detailLevel, objectId, message);
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
                throw new ObjectDisposedException(nameof(NVAPIOpenGLHelper));

            _apiHelper.ThrowIfDisposed();
        }

        /// <summary>
        /// Dispose the helper and prevent further use.
        /// </summary>
        public void Dispose()
        {
            _disposed = true;
            _callbackManaged = null;
            _callbackWrapper = null;
        }

        private static bool IsUnsupported(_NvAPI_Status status)
        {
            return status == _NvAPI_Status.NVAPI_NOT_SUPPORTED
                || status == _NvAPI_Status.NVAPI_NO_IMPLEMENTATION
                || status == _NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND
                || status == _NvAPI_Status.NVAPI_OPENGL_CONTEXT_NOT_CURRENT;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiOglExpertModeSetDelegate(
            uint expertDetailLevel,
            uint expertReportMask,
            uint expertOutputMask,
            NvApiOglExpertCallbackDelegate? expertCallback);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiOglExpertModeGetDelegate(
            uint* pExpertDetailLevel,
            uint* pExpertReportMask,
            uint* pExpertOutputMask,
            IntPtr* pExpertCallback);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate _NvAPI_Status NvApiOglExpertModeDefaultsSetDelegate(
            uint expertDetailLevel,
            uint expertReportMask,
            uint expertOutputMask);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate _NvAPI_Status NvApiOglExpertModeDefaultsGetDelegate(
            uint* pExpertDetailLevel,
            uint* pExpertReportMask,
            uint* pExpertOutputMask);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void NvApiOglExpertCallbackDelegate(
            uint categoryId,
            uint messageId,
            uint detailLevel,
            int objectId,
            sbyte* messageStr);
    }

    /// <summary>
    /// Managed callback for OpenGL expert mode output.
    /// </summary>
    public delegate void NVAPIOglExpertCallback(uint categoryId, uint messageId, uint detailLevel, int objectId, string message);

    /// <summary>
    /// OpenGL expert mode state DTO.
    /// </summary>
    public readonly struct NVAPIOglExpertModeDto : IEquatable<NVAPIOglExpertModeDto>
    {
        public uint DetailMask { get; }
        public uint ReportMask { get; }
        public uint OutputMask { get; }
        public IntPtr Callback { get; }

        public NVAPIOglExpertModeDto(uint detailMask, uint reportMask, uint outputMask, IntPtr callback)
        {
            DetailMask = detailMask;
            ReportMask = reportMask;
            OutputMask = outputMask;
            Callback = callback;
        }

        public static NVAPIOglExpertModeDto FromNative(uint detailMask, uint reportMask, uint outputMask, IntPtr callback)
        {
            return new NVAPIOglExpertModeDto(detailMask, reportMask, outputMask, callback);
        }

        public NVAPIOglExpertModeNative ToNative()
        {
            return new NVAPIOglExpertModeNative
            {
                DetailMask = DetailMask,
                ReportMask = ReportMask,
                OutputMask = OutputMask,
                Callback = Callback
            };
        }

        public bool Equals(NVAPIOglExpertModeDto other)
        {
            return DetailMask == other.DetailMask
                && ReportMask == other.ReportMask
                && OutputMask == other.OutputMask
                && Callback == other.Callback;
        }

        public override bool Equals(object? obj) => obj is NVAPIOglExpertModeDto other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(DetailMask, ReportMask, OutputMask, Callback);

        public static bool operator ==(NVAPIOglExpertModeDto left, NVAPIOglExpertModeDto right) => left.Equals(right);
        public static bool operator !=(NVAPIOglExpertModeDto left, NVAPIOglExpertModeDto right) => !left.Equals(right);
    }

    /// <summary>
    /// OpenGL expert mode defaults DTO.
    /// </summary>
    public readonly struct NVAPIOglExpertDefaultsDto : IEquatable<NVAPIOglExpertDefaultsDto>
    {
        public uint DetailMask { get; }
        public uint ReportMask { get; }
        public uint OutputMask { get; }

        public NVAPIOglExpertDefaultsDto(uint detailMask, uint reportMask, uint outputMask)
        {
            DetailMask = detailMask;
            ReportMask = reportMask;
            OutputMask = outputMask;
        }

        public static NVAPIOglExpertDefaultsDto FromNative(uint detailMask, uint reportMask, uint outputMask)
        {
            return new NVAPIOglExpertDefaultsDto(detailMask, reportMask, outputMask);
        }

        public NVAPIOglExpertDefaultsNative ToNative()
        {
            return new NVAPIOglExpertDefaultsNative
            {
                DetailMask = DetailMask,
                ReportMask = ReportMask,
                OutputMask = OutputMask
            };
        }

        public bool Equals(NVAPIOglExpertDefaultsDto other)
        {
            return DetailMask == other.DetailMask
                && ReportMask == other.ReportMask
                && OutputMask == other.OutputMask;
        }

        public override bool Equals(object? obj) => obj is NVAPIOglExpertDefaultsDto other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(DetailMask, ReportMask, OutputMask);

        public static bool operator ==(NVAPIOglExpertDefaultsDto left, NVAPIOglExpertDefaultsDto right) => left.Equals(right);
        public static bool operator !=(NVAPIOglExpertDefaultsDto left, NVAPIOglExpertDefaultsDto right) => !left.Equals(right);
    }

    /// <summary>
    /// Native-shaped OpenGL expert mode data.
    /// </summary>
    public struct NVAPIOglExpertModeNative
    {
        public uint DetailMask;
        public uint ReportMask;
        public uint OutputMask;
        public IntPtr Callback;
    }

    /// <summary>
    /// Native-shaped OpenGL expert defaults data.
    /// </summary>
    public struct NVAPIOglExpertDefaultsNative
    {
        public uint DetailMask;
        public uint ReportMask;
        public uint OutputMask;
    }
}
