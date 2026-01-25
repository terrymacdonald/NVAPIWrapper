using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NVVIOOUTPUTCONFIG_V3" /> struct.</summary>
    public static unsafe partial class _NVVIOOUTPUTCONFIG_V3Tests
    {
        /// <summary>Validates that the <see cref="_NVVIOOUTPUTCONFIG_V3" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NVVIOOUTPUTCONFIG_V3), Marshal.SizeOf<_NVVIOOUTPUTCONFIG_V3>());
        }

        /// <summary>Validates that the <see cref="_NVVIOOUTPUTCONFIG_V3" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NVVIOOUTPUTCONFIG_V3).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NVVIOOUTPUTCONFIG_V3" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(6612, sizeof(_NVVIOOUTPUTCONFIG_V3));
        }
    }
}
