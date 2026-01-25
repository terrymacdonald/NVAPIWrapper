using System;
using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_MOSAIC_SUPPORTED_TOPOLOGIES" /> struct.</summary>
    public static unsafe partial class NV_MOSAIC_SUPPORTED_TOPOLOGIESTests
    {
        /// <summary>Validates that the <see cref="NV_MOSAIC_SUPPORTED_TOPOLOGIES" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_MOSAIC_SUPPORTED_TOPOLOGIES), Marshal.SizeOf<NV_MOSAIC_SUPPORTED_TOPOLOGIES>());
        }

        /// <summary>Validates that the <see cref="NV_MOSAIC_SUPPORTED_TOPOLOGIES" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_MOSAIC_SUPPORTED_TOPOLOGIES).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_MOSAIC_SUPPORTED_TOPOLOGIES" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(24840, sizeof(NV_MOSAIC_SUPPORTED_TOPOLOGIES));
            }
            else
            {
                Assert.Equal(16584, sizeof(NV_MOSAIC_SUPPORTED_TOPOLOGIES));
            }
        }
    }
}
