using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NVDRS_BINARY_SETTING" /> struct.</summary>
    public static unsafe partial class _NVDRS_BINARY_SETTINGTests
    {
        /// <summary>Validates that the <see cref="_NVDRS_BINARY_SETTING" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NVDRS_BINARY_SETTING), Marshal.SizeOf<_NVDRS_BINARY_SETTING>());
        }

        /// <summary>Validates that the <see cref="_NVDRS_BINARY_SETTING" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NVDRS_BINARY_SETTING).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NVDRS_BINARY_SETTING" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(4100, sizeof(_NVDRS_BINARY_SETTING));
        }
    }
}
