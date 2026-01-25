using System;
using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_COMPUTE_GPU" /> struct.</summary>
    public static unsafe partial class _NV_COMPUTE_GPUTests
    {
        /// <summary>Validates that the <see cref="_NV_COMPUTE_GPU" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_COMPUTE_GPU), Marshal.SizeOf<_NV_COMPUTE_GPU>());
        }

        /// <summary>Validates that the <see cref="_NV_COMPUTE_GPU" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_COMPUTE_GPU).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_COMPUTE_GPU" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(16, sizeof(_NV_COMPUTE_GPU));
            }
            else
            {
                Assert.Equal(8, sizeof(_NV_COMPUTE_GPU));
            }
        }
    }
}
