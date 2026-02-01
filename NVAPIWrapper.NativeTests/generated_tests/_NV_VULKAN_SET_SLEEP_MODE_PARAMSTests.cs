using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_VULKAN_SET_SLEEP_MODE_PARAMS" /> struct.</summary>
    public static unsafe partial class _NV_VULKAN_SET_SLEEP_MODE_PARAMSTests
    {
        /// <summary>Validates that the <see cref="_NV_VULKAN_SET_SLEEP_MODE_PARAMS" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_VULKAN_SET_SLEEP_MODE_PARAMS), Marshal.SizeOf<_NV_VULKAN_SET_SLEEP_MODE_PARAMS>());
        }

        /// <summary>Validates that the <see cref="_NV_VULKAN_SET_SLEEP_MODE_PARAMS" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_VULKAN_SET_SLEEP_MODE_PARAMS).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_VULKAN_SET_SLEEP_MODE_PARAMS" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(44, sizeof(_NV_VULKAN_SET_SLEEP_MODE_PARAMS));
        }
    }
}
