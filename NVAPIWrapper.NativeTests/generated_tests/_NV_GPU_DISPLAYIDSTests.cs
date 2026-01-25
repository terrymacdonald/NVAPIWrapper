using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_GPU_DISPLAYIDS" /> struct.</summary>
    public static unsafe partial class _NV_GPU_DISPLAYIDSTests
    {
        /// <summary>Validates that the <see cref="_NV_GPU_DISPLAYIDS" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_GPU_DISPLAYIDS), Marshal.SizeOf<_NV_GPU_DISPLAYIDS>());
        }

        /// <summary>Validates that the <see cref="_NV_GPU_DISPLAYIDS" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_GPU_DISPLAYIDS).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_GPU_DISPLAYIDS" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(16, sizeof(_NV_GPU_DISPLAYIDS));
        }
    }
}
