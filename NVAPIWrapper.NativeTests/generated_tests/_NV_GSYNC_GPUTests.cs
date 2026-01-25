using System;
using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_GSYNC_GPU" /> struct.</summary>
    public static unsafe partial class _NV_GSYNC_GPUTests
    {
        /// <summary>Validates that the <see cref="_NV_GSYNC_GPU" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_GSYNC_GPU), Marshal.SizeOf<_NV_GSYNC_GPU>());
        }

        /// <summary>Validates that the <see cref="_NV_GSYNC_GPU" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_GSYNC_GPU).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_GSYNC_GPU" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(40, sizeof(_NV_GSYNC_GPU));
            }
            else
            {
                Assert.Equal(20, sizeof(_NV_GSYNC_GPU));
            }
        }
    }
}
