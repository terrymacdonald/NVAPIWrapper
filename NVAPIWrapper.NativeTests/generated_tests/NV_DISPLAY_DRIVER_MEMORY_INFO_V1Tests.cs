using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_DISPLAY_DRIVER_MEMORY_INFO_V1" /> struct.</summary>
    public static unsafe partial class NV_DISPLAY_DRIVER_MEMORY_INFO_V1Tests
    {
        /// <summary>Validates that the <see cref="NV_DISPLAY_DRIVER_MEMORY_INFO_V1" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_DISPLAY_DRIVER_MEMORY_INFO_V1), Marshal.SizeOf<NV_DISPLAY_DRIVER_MEMORY_INFO_V1>());
        }

        /// <summary>Validates that the <see cref="NV_DISPLAY_DRIVER_MEMORY_INFO_V1" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_DISPLAY_DRIVER_MEMORY_INFO_V1).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_DISPLAY_DRIVER_MEMORY_INFO_V1" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(20, sizeof(NV_DISPLAY_DRIVER_MEMORY_INFO_V1));
        }
    }
}
