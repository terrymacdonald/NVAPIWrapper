using System;

namespace NVAPIWrapper
{
    /// <summary>
    /// Facade entry point for NVAPI helper objects.
    /// </summary>
    public sealed class NVAPIApiHelper : IDisposable
    {
        private readonly NVAPIApi _api;
        private bool _disposed;

        private NVAPIApiHelper(NVAPIApi api)
        {
            _api = api;
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

        internal NVAPIApi Api
        {
            get
            {
                ThrowIfDisposed();
                return _api;
            }
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
            if (_disposed)
                return;

            _api.Dispose();
            _disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
