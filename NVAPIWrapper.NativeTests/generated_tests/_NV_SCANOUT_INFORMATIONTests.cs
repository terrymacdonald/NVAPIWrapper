using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_SCANOUT_INFORMATION" /> struct.</summary>
    public static unsafe partial class _NV_SCANOUT_INFORMATIONTests
    {
        /// <summary>Validates that the <see cref="_NV_SCANOUT_INFORMATION" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_SCANOUT_INFORMATION), Marshal.SizeOf<_NV_SCANOUT_INFORMATION>());
        }

        /// <summary>Validates that the <see cref="_NV_SCANOUT_INFORMATION" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_SCANOUT_INFORMATION).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_SCANOUT_INFORMATION" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(68, sizeof(_NV_SCANOUT_INFORMATION));
        }
    }
}
