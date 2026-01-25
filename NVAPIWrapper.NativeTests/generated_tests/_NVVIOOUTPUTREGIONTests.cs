using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NVVIOOUTPUTREGION" /> struct.</summary>
    public static unsafe partial class _NVVIOOUTPUTREGIONTests
    {
        /// <summary>Validates that the <see cref="_NVVIOOUTPUTREGION" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NVVIOOUTPUTREGION), Marshal.SizeOf<_NVVIOOUTPUTREGION>());
        }

        /// <summary>Validates that the <see cref="_NVVIOOUTPUTREGION" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NVVIOOUTPUTREGION).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NVVIOOUTPUTREGION" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(16, sizeof(_NVVIOOUTPUTREGION));
        }
    }
}
