using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_MANAGED_DEDICATED_DISPLAY_METADATA" /> struct.</summary>
    public static unsafe partial class _NV_MANAGED_DEDICATED_DISPLAY_METADATATests
    {
        /// <summary>Validates that the <see cref="_NV_MANAGED_DEDICATED_DISPLAY_METADATA" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_MANAGED_DEDICATED_DISPLAY_METADATA), Marshal.SizeOf<_NV_MANAGED_DEDICATED_DISPLAY_METADATA>());
        }

        /// <summary>Validates that the <see cref="_NV_MANAGED_DEDICATED_DISPLAY_METADATA" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_MANAGED_DEDICATED_DISPLAY_METADATA).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_MANAGED_DEDICATED_DISPLAY_METADATA" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(84, sizeof(_NV_MANAGED_DEDICATED_DISPLAY_METADATA));
        }
    }
}
