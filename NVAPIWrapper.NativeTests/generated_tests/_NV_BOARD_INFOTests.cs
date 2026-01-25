using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_BOARD_INFO" /> struct.</summary>
    public static unsafe partial class _NV_BOARD_INFOTests
    {
        /// <summary>Validates that the <see cref="_NV_BOARD_INFO" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_BOARD_INFO), Marshal.SizeOf<_NV_BOARD_INFO>());
        }

        /// <summary>Validates that the <see cref="_NV_BOARD_INFO" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_BOARD_INFO).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_BOARD_INFO" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(20, sizeof(_NV_BOARD_INFO));
        }
    }
}
