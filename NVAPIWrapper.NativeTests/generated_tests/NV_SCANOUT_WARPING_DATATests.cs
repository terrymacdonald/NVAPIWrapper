using System;
using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_SCANOUT_WARPING_DATA" /> struct.</summary>
    public static unsafe partial class NV_SCANOUT_WARPING_DATATests
    {
        /// <summary>Validates that the <see cref="NV_SCANOUT_WARPING_DATA" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_SCANOUT_WARPING_DATA), Marshal.SizeOf<NV_SCANOUT_WARPING_DATA>());
        }

        /// <summary>Validates that the <see cref="NV_SCANOUT_WARPING_DATA" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_SCANOUT_WARPING_DATA).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_SCANOUT_WARPING_DATA" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(32, sizeof(NV_SCANOUT_WARPING_DATA));
            }
            else
            {
                Assert.Equal(20, sizeof(NV_SCANOUT_WARPING_DATA));
            }
        }
    }
}
