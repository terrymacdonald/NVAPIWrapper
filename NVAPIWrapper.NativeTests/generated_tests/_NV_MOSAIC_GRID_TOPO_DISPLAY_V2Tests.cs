using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_MOSAIC_GRID_TOPO_DISPLAY_V2" /> struct.</summary>
    public static unsafe partial class _NV_MOSAIC_GRID_TOPO_DISPLAY_V2Tests
    {
        /// <summary>Validates that the <see cref="_NV_MOSAIC_GRID_TOPO_DISPLAY_V2" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_MOSAIC_GRID_TOPO_DISPLAY_V2), Marshal.SizeOf<_NV_MOSAIC_GRID_TOPO_DISPLAY_V2>());
        }

        /// <summary>Validates that the <see cref="_NV_MOSAIC_GRID_TOPO_DISPLAY_V2" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_MOSAIC_GRID_TOPO_DISPLAY_V2).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_MOSAIC_GRID_TOPO_DISPLAY_V2" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(28, sizeof(_NV_MOSAIC_GRID_TOPO_DISPLAY_V2));
        }
    }
}
