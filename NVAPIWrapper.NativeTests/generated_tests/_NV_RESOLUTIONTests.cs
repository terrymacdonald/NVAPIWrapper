using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_RESOLUTION" /> struct.</summary>
    public static unsafe partial class _NV_RESOLUTIONTests
    {
        /// <summary>Validates that the <see cref="_NV_RESOLUTION" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_RESOLUTION), Marshal.SizeOf<_NV_RESOLUTION>());
        }

        /// <summary>Validates that the <see cref="_NV_RESOLUTION" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_RESOLUTION).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_RESOLUTION" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(12, sizeof(_NV_RESOLUTION));
        }
    }
}
