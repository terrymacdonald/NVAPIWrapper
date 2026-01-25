using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NvLogicalGpuHandle__" /> struct.</summary>
    public static unsafe partial class NvLogicalGpuHandle__Tests
    {
        /// <summary>Validates that the <see cref="NvLogicalGpuHandle__" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NvLogicalGpuHandle__), Marshal.SizeOf<NvLogicalGpuHandle__>());
        }

        /// <summary>Validates that the <see cref="NvLogicalGpuHandle__" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NvLogicalGpuHandle__).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NvLogicalGpuHandle__" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(4, sizeof(NvLogicalGpuHandle__));
        }
    }
}
