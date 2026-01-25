using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_INFOFRAME_VIDEO" /> struct.</summary>
    public static unsafe partial class NV_INFOFRAME_VIDEOTests
    {
        /// <summary>Validates that the <see cref="NV_INFOFRAME_VIDEO" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_INFOFRAME_VIDEO), Marshal.SizeOf<NV_INFOFRAME_VIDEO>());
        }

        /// <summary>Validates that the <see cref="NV_INFOFRAME_VIDEO" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_INFOFRAME_VIDEO).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_INFOFRAME_VIDEO" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(24, sizeof(NV_INFOFRAME_VIDEO));
        }
    }
}
