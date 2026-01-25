using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_TIMING_INPUT" /> struct.</summary>
    public static unsafe partial class _NV_TIMING_INPUTTests
    {
        /// <summary>Validates that the <see cref="_NV_TIMING_INPUT" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_TIMING_INPUT), Marshal.SizeOf<_NV_TIMING_INPUT>());
        }

        /// <summary>Validates that the <see cref="_NV_TIMING_INPUT" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_TIMING_INPUT).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_TIMING_INPUT" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(28, sizeof(_NV_TIMING_INPUT));
        }
    }
}
