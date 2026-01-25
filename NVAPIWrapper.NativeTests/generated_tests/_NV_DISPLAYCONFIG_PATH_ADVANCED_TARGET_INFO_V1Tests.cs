using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1" /> struct.</summary>
    public static unsafe partial class _NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1Tests
    {
        /// <summary>Validates that the <see cref="_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1), Marshal.SizeOf<_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1>());
        }

        /// <summary>Validates that the <see cref="_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(128, sizeof(_NV_DISPLAYCONFIG_PATH_ADVANCED_TARGET_INFO_V1));
        }
    }
}
