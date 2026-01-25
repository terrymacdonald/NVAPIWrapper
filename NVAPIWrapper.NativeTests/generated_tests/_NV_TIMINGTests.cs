using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_TIMING" /> struct.</summary>
    public static unsafe partial class _NV_TIMINGTests
    {
        /// <summary>Validates that the <see cref="_NV_TIMING" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_TIMING), Marshal.SizeOf<_NV_TIMING>());
        }

        /// <summary>Validates that the <see cref="_NV_TIMING" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_TIMING).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_TIMING" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(96, sizeof(_NV_TIMING));
        }
    }
}
