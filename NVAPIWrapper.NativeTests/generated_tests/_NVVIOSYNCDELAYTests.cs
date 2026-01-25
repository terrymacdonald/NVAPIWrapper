using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NVVIOSYNCDELAY" /> struct.</summary>
    public static unsafe partial class _NVVIOSYNCDELAYTests
    {
        /// <summary>Validates that the <see cref="_NVVIOSYNCDELAY" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NVVIOSYNCDELAY), Marshal.SizeOf<_NVVIOSYNCDELAY>());
        }

        /// <summary>Validates that the <see cref="_NVVIOSYNCDELAY" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NVVIOSYNCDELAY).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NVVIOSYNCDELAY" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(12, sizeof(_NVVIOSYNCDELAY));
        }
    }
}
