using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_MODIFIED_W_PARAMS" /> struct.</summary>
    public static unsafe partial class _NV_MODIFIED_W_PARAMSTests
    {
        /// <summary>Validates that the <see cref="_NV_MODIFIED_W_PARAMS" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_MODIFIED_W_PARAMS), Marshal.SizeOf<_NV_MODIFIED_W_PARAMS>());
        }

        /// <summary>Validates that the <see cref="_NV_MODIFIED_W_PARAMS" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_MODIFIED_W_PARAMS).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_MODIFIED_W_PARAMS" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(460, sizeof(_NV_MODIFIED_W_PARAMS));
        }
    }
}
