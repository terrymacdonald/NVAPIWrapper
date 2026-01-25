using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_TIMING_FLAG" /> struct.</summary>
    public static unsafe partial class NV_TIMING_FLAGTests
    {
        /// <summary>Validates that the <see cref="NV_TIMING_FLAG" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_TIMING_FLAG), Marshal.SizeOf<NV_TIMING_FLAG>());
        }

        /// <summary>Validates that the <see cref="NV_TIMING_FLAG" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_TIMING_FLAG).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_TIMING_FLAG" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(8, sizeof(NV_TIMING_FLAG));
        }
    }
}
