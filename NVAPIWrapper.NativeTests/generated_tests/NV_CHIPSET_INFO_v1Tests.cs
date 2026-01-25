using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_CHIPSET_INFO_v1" /> struct.</summary>
    public static unsafe partial class NV_CHIPSET_INFO_v1Tests
    {
        /// <summary>Validates that the <see cref="NV_CHIPSET_INFO_v1" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_CHIPSET_INFO_v1), Marshal.SizeOf<NV_CHIPSET_INFO_v1>());
        }

        /// <summary>Validates that the <see cref="NV_CHIPSET_INFO_v1" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_CHIPSET_INFO_v1).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_CHIPSET_INFO_v1" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(140, sizeof(NV_CHIPSET_INFO_v1));
        }
    }
}
