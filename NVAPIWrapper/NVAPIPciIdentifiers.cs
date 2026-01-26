namespace NVAPIWrapper
{
    /// <summary>
    /// PCI identifiers reported by NVAPI.
    /// </summary>
    public readonly struct NVAPIPciIdentifiers
    {
        /// <summary>PCI device ID.</summary>
        public uint DeviceId { get; }

        /// <summary>PCI subsystem ID.</summary>
        public uint SubSystemId { get; }

        /// <summary>PCI revision ID.</summary>
        public uint RevisionId { get; }

        /// <summary>PCI extended device ID.</summary>
        public uint ExtDeviceId { get; }

        /// <summary>Create a PCI identifier set.</summary>
        public NVAPIPciIdentifiers(uint deviceId, uint subSystemId, uint revisionId, uint extDeviceId)
        {
            DeviceId = deviceId;
            SubSystemId = subSystemId;
            RevisionId = revisionId;
            ExtDeviceId = extDeviceId;
        }
    }
}
