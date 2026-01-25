using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_MOSAIC_TOPO_BRIEF" /> struct.</summary>
    public static unsafe partial class NV_MOSAIC_TOPO_BRIEFTests
    {
        /// <summary>Validates that the <see cref="NV_MOSAIC_TOPO_BRIEF" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_MOSAIC_TOPO_BRIEF), Marshal.SizeOf<NV_MOSAIC_TOPO_BRIEF>());
        }

        /// <summary>Validates that the <see cref="NV_MOSAIC_TOPO_BRIEF" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_MOSAIC_TOPO_BRIEF).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_MOSAIC_TOPO_BRIEF" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(16, sizeof(NV_MOSAIC_TOPO_BRIEF));
        }
    }
}
