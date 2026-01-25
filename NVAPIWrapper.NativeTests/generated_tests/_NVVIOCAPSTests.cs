using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NVVIOCAPS" /> struct.</summary>
    public static unsafe partial class _NVVIOCAPSTests
    {
        /// <summary>Validates that the <see cref="_NVVIOCAPS" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NVVIOCAPS), Marshal.SizeOf<_NVVIOCAPS>());
        }

        /// <summary>Validates that the <see cref="_NVVIOCAPS" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NVVIOCAPS).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NVVIOCAPS" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(4144, sizeof(_NVVIOCAPS));
        }
    }
}
