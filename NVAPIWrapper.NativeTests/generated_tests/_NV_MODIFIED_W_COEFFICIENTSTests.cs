using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_MODIFIED_W_COEFFICIENTS" /> struct.</summary>
    public static unsafe partial class _NV_MODIFIED_W_COEFFICIENTSTests
    {
        /// <summary>Validates that the <see cref="_NV_MODIFIED_W_COEFFICIENTS" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_MODIFIED_W_COEFFICIENTS), Marshal.SizeOf<_NV_MODIFIED_W_COEFFICIENTS>());
        }

        /// <summary>Validates that the <see cref="_NV_MODIFIED_W_COEFFICIENTS" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_MODIFIED_W_COEFFICIENTS).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_MODIFIED_W_COEFFICIENTS" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(24, sizeof(_NV_MODIFIED_W_COEFFICIENTS));
        }
    }
}
