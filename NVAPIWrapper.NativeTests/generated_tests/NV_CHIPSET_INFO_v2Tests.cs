using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_CHIPSET_INFO_v2" /> struct.</summary>
    public static unsafe partial class NV_CHIPSET_INFO_v2Tests
    {
        /// <summary>Validates that the <see cref="NV_CHIPSET_INFO_v2" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_CHIPSET_INFO_v2), Marshal.SizeOf<NV_CHIPSET_INFO_v2>());
        }

        /// <summary>Validates that the <see cref="NV_CHIPSET_INFO_v2" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_CHIPSET_INFO_v2).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_CHIPSET_INFO_v2" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(144, sizeof(NV_CHIPSET_INFO_v2));
        }
    }
}
