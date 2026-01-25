using System;
using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NVVIOTOPOLOGYTARGET" /> struct.</summary>
    public static unsafe partial class NVVIOTOPOLOGYTARGETTests
    {
        /// <summary>Validates that the <see cref="NVVIOTOPOLOGYTARGET" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NVVIOTOPOLOGYTARGET), Marshal.SizeOf<NVVIOTOPOLOGYTARGET>());
        }

        /// <summary>Validates that the <see cref="NVVIOTOPOLOGYTARGET" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NVVIOTOPOLOGYTARGET).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NVVIOTOPOLOGYTARGET" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(24, sizeof(NVVIOTOPOLOGYTARGET));
            }
            else
            {
                Assert.Equal(16, sizeof(NVVIOTOPOLOGYTARGET));
            }
        }
    }
}
