using System;
using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_MOSAIC_TOPO_DETAILS" /> struct.</summary>
    public static unsafe partial class NV_MOSAIC_TOPO_DETAILSTests
    {
        /// <summary>Validates that the <see cref="NV_MOSAIC_TOPO_DETAILS" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_MOSAIC_TOPO_DETAILS), Marshal.SizeOf<NV_MOSAIC_TOPO_DETAILS>());
        }

        /// <summary>Validates that the <see cref="NV_MOSAIC_TOPO_DETAILS" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_MOSAIC_TOPO_DETAILS).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_MOSAIC_TOPO_DETAILS" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(1568, sizeof(NV_MOSAIC_TOPO_DETAILS));
            }
            else
            {
                Assert.Equal(1044, sizeof(NV_MOSAIC_TOPO_DETAILS));
            }
        }
    }
}
