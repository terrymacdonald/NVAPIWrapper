using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_MOSAIC_DISPLAY_TOPO_STATUS" /> struct.</summary>
    public static unsafe partial class NV_MOSAIC_DISPLAY_TOPO_STATUSTests
    {
        /// <summary>Validates that the <see cref="NV_MOSAIC_DISPLAY_TOPO_STATUS" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_MOSAIC_DISPLAY_TOPO_STATUS), Marshal.SizeOf<NV_MOSAIC_DISPLAY_TOPO_STATUS>());
        }

        /// <summary>Validates that the <see cref="NV_MOSAIC_DISPLAY_TOPO_STATUS" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_MOSAIC_DISPLAY_TOPO_STATUS).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_MOSAIC_DISPLAY_TOPO_STATUS" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(2064, sizeof(NV_MOSAIC_DISPLAY_TOPO_STATUS));
        }
    }
}
