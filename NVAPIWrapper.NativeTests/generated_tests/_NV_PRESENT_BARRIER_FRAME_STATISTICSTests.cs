using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_PRESENT_BARRIER_FRAME_STATISTICS" /> struct.</summary>
    public static unsafe partial class _NV_PRESENT_BARRIER_FRAME_STATISTICSTests
    {
        /// <summary>Validates that the <see cref="_NV_PRESENT_BARRIER_FRAME_STATISTICS" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_PRESENT_BARRIER_FRAME_STATISTICS), Marshal.SizeOf<_NV_PRESENT_BARRIER_FRAME_STATISTICS>());
        }

        /// <summary>Validates that the <see cref="_NV_PRESENT_BARRIER_FRAME_STATISTICS" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_PRESENT_BARRIER_FRAME_STATISTICS).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_PRESENT_BARRIER_FRAME_STATISTICS" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(24, sizeof(_NV_PRESENT_BARRIER_FRAME_STATISTICS));
        }
    }
}
