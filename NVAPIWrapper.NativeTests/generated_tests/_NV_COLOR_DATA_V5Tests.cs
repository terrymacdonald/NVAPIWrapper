using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_COLOR_DATA_V5" /> struct.</summary>
    public static unsafe partial class _NV_COLOR_DATA_V5Tests
    {
        /// <summary>Validates that the <see cref="_NV_COLOR_DATA_V5" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_COLOR_DATA_V5), Marshal.SizeOf<_NV_COLOR_DATA_V5>());
        }

        /// <summary>Validates that the <see cref="_NV_COLOR_DATA_V5" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_COLOR_DATA_V5).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_COLOR_DATA_V5" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(24, sizeof(_NV_COLOR_DATA_V5));
        }
    }
}
