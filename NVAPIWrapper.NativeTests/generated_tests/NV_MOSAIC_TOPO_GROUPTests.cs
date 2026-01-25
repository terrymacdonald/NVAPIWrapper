using System;
using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_MOSAIC_TOPO_GROUP" /> struct.</summary>
    public static unsafe partial class NV_MOSAIC_TOPO_GROUPTests
    {
        /// <summary>Validates that the <see cref="NV_MOSAIC_TOPO_GROUP" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_MOSAIC_TOPO_GROUP), Marshal.SizeOf<NV_MOSAIC_TOPO_GROUP>());
        }

        /// <summary>Validates that the <see cref="NV_MOSAIC_TOPO_GROUP" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_MOSAIC_TOPO_GROUP).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_MOSAIC_TOPO_GROUP" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(3160, sizeof(NV_MOSAIC_TOPO_GROUP));
            }
            else
            {
                Assert.Equal(2112, sizeof(NV_MOSAIC_TOPO_GROUP));
            }
        }
    }
}
