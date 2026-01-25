using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_POSITION" /> struct.</summary>
    public static unsafe partial class _NV_POSITIONTests
    {
        /// <summary>Validates that the <see cref="_NV_POSITION" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_POSITION), Marshal.SizeOf<_NV_POSITION>());
        }

        /// <summary>Validates that the <see cref="_NV_POSITION" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_POSITION).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_POSITION" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(8, sizeof(_NV_POSITION));
        }
    }
}
