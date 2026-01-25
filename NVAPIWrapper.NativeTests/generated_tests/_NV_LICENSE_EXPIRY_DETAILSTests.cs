using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_LICENSE_EXPIRY_DETAILS" /> struct.</summary>
    public static unsafe partial class _NV_LICENSE_EXPIRY_DETAILSTests
    {
        /// <summary>Validates that the <see cref="_NV_LICENSE_EXPIRY_DETAILS" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_LICENSE_EXPIRY_DETAILS), Marshal.SizeOf<_NV_LICENSE_EXPIRY_DETAILS>());
        }

        /// <summary>Validates that the <see cref="_NV_LICENSE_EXPIRY_DETAILS" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_LICENSE_EXPIRY_DETAILS).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_LICENSE_EXPIRY_DETAILS" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(16, sizeof(_NV_LICENSE_EXPIRY_DETAILS));
        }
    }
}
