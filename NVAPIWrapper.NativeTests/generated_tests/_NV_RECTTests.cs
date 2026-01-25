using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_RECT" /> struct.</summary>
    public static unsafe partial class _NV_RECTTests
    {
        /// <summary>Validates that the <see cref="_NV_RECT" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_RECT), Marshal.SizeOf<_NV_RECT>());
        }

        /// <summary>Validates that the <see cref="_NV_RECT" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_RECT).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_RECT" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(16, sizeof(_NV_RECT));
        }
    }
}
