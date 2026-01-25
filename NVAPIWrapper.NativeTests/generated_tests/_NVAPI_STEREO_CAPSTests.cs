using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NVAPI_STEREO_CAPS" /> struct.</summary>
    public static unsafe partial class _NVAPI_STEREO_CAPSTests
    {
        /// <summary>Validates that the <see cref="_NVAPI_STEREO_CAPS" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NVAPI_STEREO_CAPS), Marshal.SizeOf<_NVAPI_STEREO_CAPS>());
        }

        /// <summary>Validates that the <see cref="_NVAPI_STEREO_CAPS" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NVAPI_STEREO_CAPS).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NVAPI_STEREO_CAPS" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(20, sizeof(_NVAPI_STEREO_CAPS));
        }
    }
}
