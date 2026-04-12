using System;
using System.Management;
using System.Runtime.Versioning;

namespace NVAPIWrapper
{
    /// <summary>
    /// Hardware detection utilities for NVIDIA GPU presence.
    /// </summary>
    [SupportedOSPlatform("windows")]
    public static class NVAPIHardwareDetection
    {
        private const string NVIDIA_PCI_VENDOR_ID = "10DE";

        /// <summary>
        /// Checks if an NVIDIA GPU is present in the system via PCI Vendor ID detection.
        /// </summary>
        /// <param name="errorMessage">Details about why NVIDIA GPU was not detected.</param>
        /// <returns>True if NVIDIA GPU hardware is detected, false otherwise.</returns>
        [SupportedOSPlatform("windows")]
        public static bool HasNVIDIAGPU(out string errorMessage)
        {
            try
            {
                using var searcher = new ManagementObjectSearcher(
                    $@"SELECT * FROM Win32_VideoController WHERE PNPDeviceID LIKE 'PCI\\VEN_{NVIDIA_PCI_VENDOR_ID}%'");

                var devices = searcher.Get();
                if (devices.Count > 0)
                {
                    errorMessage = string.Empty;
                    return true;
                }

                errorMessage = $"No NVIDIA GPU hardware detected (PCI Vendor ID {NVIDIA_PCI_VENDOR_ID} not found)";
                return false;
            }
            catch (Exception ex)
            {
                errorMessage = $"Failed to query PCI devices: {ex.Message}";
                return false;
            }
        }

        /// <summary>
        /// Gets the names of detected NVIDIA GPUs.
        /// </summary>
        /// <returns>Array of GPU names, or empty array if none found.</returns>
        [SupportedOSPlatform("windows")]
        public static string[] GetNVIDIAGPUNames()
        {
            try
            {
                using var searcher = new ManagementObjectSearcher(
                    $@"SELECT Name FROM Win32_VideoController WHERE PNPDeviceID LIKE 'PCI\\VEN_{NVIDIA_PCI_VENDOR_ID}%'");

                var devices = searcher.Get();
                var names = new string[devices.Count];
                int index = 0;

                foreach (ManagementObject device in devices)
                {
                    names[index++] = device["Name"]?.ToString() ?? "Unknown NVIDIA GPU";
                }

                return names;
            }
            catch
            {
                return Array.Empty<string>();
            }
        }
    }
}
