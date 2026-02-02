using System;

namespace NVAPIWrapper
{
    /// <summary>
    /// Facade helper for an NVAPI event registration handle.
    /// </summary>
    public sealed class NVAPIEventHandleHelper : IDisposable
    {
        private readonly NVAPIApiHelper _apiHelper;
        private IntPtr _handle;
        private bool _disposed;

        internal NVAPIEventHandleHelper(NVAPIApiHelper apiHelper, IntPtr handle)
        {
            _apiHelper = apiHelper;
            _handle = handle;
        }

        ~NVAPIEventHandleHelper()
        {
            Dispose(false);
        }

        /// <summary>
        /// Dispose the event handle and unregister the callback.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private unsafe void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (_handle != IntPtr.Zero && !_apiHelper.IsDisposed)
            {
                try
                {
                    _apiHelper.UnregisterEventHandle(_handle);
                }
                catch
                {
                    // Avoid throwing during dispose/finalize.
                }
            }

            _handle = IntPtr.Zero;
            _disposed = true;
        }
    }
}
