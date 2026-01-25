using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_GSYNC_DISPLAY" /> struct.</summary>
    public static unsafe partial class _NV_GSYNC_DISPLAYTests
    {
        /// <summary>Validates that the <see cref="_NV_GSYNC_DISPLAY" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_GSYNC_DISPLAY), Marshal.SizeOf<_NV_GSYNC_DISPLAY>());
        }

        /// <summary>Validates that the <see cref="_NV_GSYNC_DISPLAY" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_GSYNC_DISPLAY).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_GSYNC_DISPLAY" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(16, sizeof(_NV_GSYNC_DISPLAY));
        }
    }
}
