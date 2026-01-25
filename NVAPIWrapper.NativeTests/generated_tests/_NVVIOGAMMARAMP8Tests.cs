using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NVVIOGAMMARAMP8" /> struct.</summary>
    public static unsafe partial class _NVVIOGAMMARAMP8Tests
    {
        /// <summary>Validates that the <see cref="_NVVIOGAMMARAMP8" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NVVIOGAMMARAMP8), Marshal.SizeOf<_NVVIOGAMMARAMP8>());
        }

        /// <summary>Validates that the <see cref="_NVVIOGAMMARAMP8" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NVVIOGAMMARAMP8).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NVVIOGAMMARAMP8" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1536, sizeof(_NVVIOGAMMARAMP8));
        }
    }
}
