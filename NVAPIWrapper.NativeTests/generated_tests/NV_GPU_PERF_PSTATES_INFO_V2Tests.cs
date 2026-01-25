using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_GPU_PERF_PSTATES_INFO_V2" /> struct.</summary>
    public static unsafe partial class NV_GPU_PERF_PSTATES_INFO_V2Tests
    {
        /// <summary>Validates that the <see cref="NV_GPU_PERF_PSTATES_INFO_V2" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_GPU_PERF_PSTATES_INFO_V2), Marshal.SizeOf<NV_GPU_PERF_PSTATES_INFO_V2>());
        }

        /// <summary>Validates that the <see cref="NV_GPU_PERF_PSTATES_INFO_V2" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_GPU_PERF_PSTATES_INFO_V2).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_GPU_PERF_PSTATES_INFO_V2" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(9364, sizeof(NV_GPU_PERF_PSTATES_INFO_V2));
        }
    }
}
