using System;
using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_DISPLAYCONFIG_PATH_INFO" /> struct.</summary>
    public static unsafe partial class _NV_DISPLAYCONFIG_PATH_INFOTests
    {
        /// <summary>Validates that the <see cref="_NV_DISPLAYCONFIG_PATH_INFO" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_DISPLAYCONFIG_PATH_INFO), Marshal.SizeOf<_NV_DISPLAYCONFIG_PATH_INFO>());
        }

        /// <summary>Validates that the <see cref="_NV_DISPLAYCONFIG_PATH_INFO" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_DISPLAYCONFIG_PATH_INFO).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_DISPLAYCONFIG_PATH_INFO" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(48, sizeof(_NV_DISPLAYCONFIG_PATH_INFO));
            }
            else
            {
                Assert.Equal(28, sizeof(_NV_DISPLAYCONFIG_PATH_INFO));
            }
        }
    }
}
