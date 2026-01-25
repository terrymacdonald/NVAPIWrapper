using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_GPU_DYNAMIC_PSTATES_INFO_EX" /> struct.</summary>
    public static unsafe partial class NV_GPU_DYNAMIC_PSTATES_INFO_EXTests
    {
        /// <summary>Validates that the <see cref="NV_GPU_DYNAMIC_PSTATES_INFO_EX" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_GPU_DYNAMIC_PSTATES_INFO_EX), Marshal.SizeOf<NV_GPU_DYNAMIC_PSTATES_INFO_EX>());
        }

        /// <summary>Validates that the <see cref="NV_GPU_DYNAMIC_PSTATES_INFO_EX" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_GPU_DYNAMIC_PSTATES_INFO_EX).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_GPU_DYNAMIC_PSTATES_INFO_EX" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(72, sizeof(NV_GPU_DYNAMIC_PSTATES_INFO_EX));
        }
    }
}
