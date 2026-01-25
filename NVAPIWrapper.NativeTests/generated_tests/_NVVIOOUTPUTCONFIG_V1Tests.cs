using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NVVIOOUTPUTCONFIG_V1" /> struct.</summary>
    public static unsafe partial class _NVVIOOUTPUTCONFIG_V1Tests
    {
        /// <summary>Validates that the <see cref="_NVVIOOUTPUTCONFIG_V1" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NVVIOOUTPUTCONFIG_V1), Marshal.SizeOf<_NVVIOOUTPUTCONFIG_V1>());
        }

        /// <summary>Validates that the <see cref="_NVVIOOUTPUTCONFIG_V1" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NVVIOOUTPUTCONFIG_V1).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NVVIOOUTPUTCONFIG_V1" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(6604, sizeof(_NVVIOOUTPUTCONFIG_V1));
        }
    }
}
