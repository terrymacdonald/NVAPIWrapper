namespace NVAPIWrapper
{
    /// <summary>
    /// Describes an NVAPI function ID and whether it is available in the loaded DLL.
    /// </summary>
    public readonly struct NVAPIFunctionInfo
    {
        /// <summary>
        /// NVAPI function name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// NVAPI function ID for NvAPI_QueryInterface.
        /// </summary>
        public uint Id { get; }

        /// <summary>
        /// True if the function pointer resolves in the current driver.
        /// </summary>
        public bool IsAvailable { get; }

        /// <summary>
        /// Create a new function info instance.
        /// </summary>
        /// <param name="name">Function name.</param>
        /// <param name="id">Function ID.</param>
        /// <param name="isAvailable">Availability flag.</param>
        public NVAPIFunctionInfo(string name, uint id, bool isAvailable)
        {
            Name = name;
            Id = id;
            IsAvailable = isAvailable;
        }
    }
}
