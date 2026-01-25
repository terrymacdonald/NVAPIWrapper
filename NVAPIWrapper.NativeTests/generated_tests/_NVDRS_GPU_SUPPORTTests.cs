using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NVDRS_GPU_SUPPORT" /> struct.</summary>
    public static unsafe partial class _NVDRS_GPU_SUPPORTTests
    {
        /// <summary>Validates that the <see cref="_NVDRS_GPU_SUPPORT" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NVDRS_GPU_SUPPORT), Marshal.SizeOf<_NVDRS_GPU_SUPPORT>());
        }

        /// <summary>Validates that the <see cref="_NVDRS_GPU_SUPPORT" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NVDRS_GPU_SUPPORT).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NVDRS_GPU_SUPPORT" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(4, sizeof(_NVDRS_GPU_SUPPORT));
        }
    }
}
