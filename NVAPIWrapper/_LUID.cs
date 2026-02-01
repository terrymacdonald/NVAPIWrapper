using System.Runtime.InteropServices;

namespace NVAPIWrapper
{
    /// <summary>Win32 LUID (locally unique identifier).</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct _LUID
    {
        /// <summary>Low 32 bits.</summary>
        public uint LowPart;

        /// <summary>High 32 bits.</summary>
        public int HighPart;
    }
}
