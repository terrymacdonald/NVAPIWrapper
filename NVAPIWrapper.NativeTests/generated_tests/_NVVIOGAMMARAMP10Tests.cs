using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NVVIOGAMMARAMP10" /> struct.</summary>
    public static unsafe partial class _NVVIOGAMMARAMP10Tests
    {
        /// <summary>Validates that the <see cref="_NVVIOGAMMARAMP10" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NVVIOGAMMARAMP10), Marshal.SizeOf<_NVVIOGAMMARAMP10>());
        }

        /// <summary>Validates that the <see cref="_NVVIOGAMMARAMP10" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NVVIOGAMMARAMP10).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NVVIOGAMMARAMP10" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(6144, sizeof(_NVVIOGAMMARAMP10));
        }
    }
}
