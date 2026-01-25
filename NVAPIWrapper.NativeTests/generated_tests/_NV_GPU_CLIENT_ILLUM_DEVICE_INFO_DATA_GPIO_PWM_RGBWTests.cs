using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_DATA_GPIO_PWM_RGBW" /> struct.</summary>
    public static unsafe partial class _NV_GPU_CLIENT_ILLUM_DEVICE_INFO_DATA_GPIO_PWM_RGBWTests
    {
        /// <summary>Validates that the <see cref="_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_DATA_GPIO_PWM_RGBW" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_DATA_GPIO_PWM_RGBW), Marshal.SizeOf<_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_DATA_GPIO_PWM_RGBW>());
        }

        /// <summary>Validates that the <see cref="_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_DATA_GPIO_PWM_RGBW" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_DATA_GPIO_PWM_RGBW).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_DATA_GPIO_PWM_RGBW" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(4, sizeof(_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_DATA_GPIO_PWM_RGBW));
        }
    }
}
