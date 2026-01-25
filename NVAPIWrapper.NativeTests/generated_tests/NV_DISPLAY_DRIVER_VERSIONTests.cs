using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_DISPLAY_DRIVER_VERSION" /> struct.</summary>
    public static unsafe partial class NV_DISPLAY_DRIVER_VERSIONTests
    {
        /// <summary>Validates that the <see cref="NV_DISPLAY_DRIVER_VERSION" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_DISPLAY_DRIVER_VERSION), Marshal.SizeOf<NV_DISPLAY_DRIVER_VERSION>());
        }

        /// <summary>Validates that the <see cref="NV_DISPLAY_DRIVER_VERSION" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_DISPLAY_DRIVER_VERSION).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_DISPLAY_DRIVER_VERSION" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(140, sizeof(NV_DISPLAY_DRIVER_VERSION));
        }
    }
}
