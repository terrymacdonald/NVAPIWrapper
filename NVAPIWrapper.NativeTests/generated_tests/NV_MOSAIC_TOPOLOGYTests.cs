using System;
using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_MOSAIC_TOPOLOGY" /> struct.</summary>
    public static unsafe partial class NV_MOSAIC_TOPOLOGYTests
    {
        /// <summary>Validates that the <see cref="NV_MOSAIC_TOPOLOGY" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_MOSAIC_TOPOLOGY), Marshal.SizeOf<NV_MOSAIC_TOPOLOGY>());
        }

        /// <summary>Validates that the <see cref="NV_MOSAIC_TOPOLOGY" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_MOSAIC_TOPOLOGY).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_MOSAIC_TOPOLOGY" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(1552, sizeof(NV_MOSAIC_TOPOLOGY));
            }
            else
            {
                Assert.Equal(1036, sizeof(NV_MOSAIC_TOPOLOGY));
            }
        }
    }
}
