using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_VIEWPORTF" /> struct.</summary>
    public static unsafe partial class NV_VIEWPORTFTests
    {
        /// <summary>Validates that the <see cref="NV_VIEWPORTF" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_VIEWPORTF), Marshal.SizeOf<NV_VIEWPORTF>());
        }

        /// <summary>Validates that the <see cref="NV_VIEWPORTF" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_VIEWPORTF).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_VIEWPORTF" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(16, sizeof(NV_VIEWPORTF));
        }
    }
}
