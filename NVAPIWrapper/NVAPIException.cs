using System;

namespace NVAPIWrapper
{
    /// <summary>
    /// Exception thrown when an NVAPI call fails.
    /// </summary>
    public class NVAPIException : Exception
    {
        /// <summary>
        /// Result code from the failed NVAPI call.
        /// </summary>
        public _NvAPI_Status Status { get; }

        /// <summary>
        /// Create a new NVAPI exception for a result code.
        /// </summary>
        /// <param name="status">NVAPI status code.</param>
        /// <param name="message">Optional error message.</param>
        public NVAPIException(_NvAPI_Status status, string? message = null)
            : base(message ?? $"NVAPI error: {status}")
        {
            Status = status;
        }
    }
}
