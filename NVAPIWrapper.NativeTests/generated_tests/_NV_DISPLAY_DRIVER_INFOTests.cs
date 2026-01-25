using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_DISPLAY_DRIVER_INFO" /> struct.</summary>
    public static unsafe partial class _NV_DISPLAY_DRIVER_INFOTests
    {
        /// <summary>Validates that the <see cref="_NV_DISPLAY_DRIVER_INFO" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_DISPLAY_DRIVER_INFO), Marshal.SizeOf<_NV_DISPLAY_DRIVER_INFO>());
        }

        /// <summary>Validates that the <see cref="_NV_DISPLAY_DRIVER_INFO" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_DISPLAY_DRIVER_INFO).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_DISPLAY_DRIVER_INFO" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(76, sizeof(_NV_DISPLAY_DRIVER_INFO));
        }
    }
}
