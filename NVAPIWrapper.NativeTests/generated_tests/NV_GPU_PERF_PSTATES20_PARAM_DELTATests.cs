using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_GPU_PERF_PSTATES20_PARAM_DELTA" /> struct.</summary>
    public static unsafe partial class NV_GPU_PERF_PSTATES20_PARAM_DELTATests
    {
        /// <summary>Validates that the <see cref="NV_GPU_PERF_PSTATES20_PARAM_DELTA" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_GPU_PERF_PSTATES20_PARAM_DELTA), Marshal.SizeOf<NV_GPU_PERF_PSTATES20_PARAM_DELTA>());
        }

        /// <summary>Validates that the <see cref="NV_GPU_PERF_PSTATES20_PARAM_DELTA" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_GPU_PERF_PSTATES20_PARAM_DELTA).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_GPU_PERF_PSTATES20_PARAM_DELTA" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(12, sizeof(NV_GPU_PERF_PSTATES20_PARAM_DELTA));
        }
    }
}
