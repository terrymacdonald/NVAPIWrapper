using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_EDID_V3" /> struct.</summary>
    public static unsafe partial class NV_EDID_V3Tests
    {
        /// <summary>Validates that the <see cref="NV_EDID_V3" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_EDID_V3), Marshal.SizeOf<NV_EDID_V3>());
        }

        /// <summary>Validates that the <see cref="NV_EDID_V3" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_EDID_V3).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_EDID_V3" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(272, sizeof(NV_EDID_V3));
        }
    }
}
