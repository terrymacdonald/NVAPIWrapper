using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NvPhysicalGpuHandle__" /> struct.</summary>
    public static unsafe partial class NvPhysicalGpuHandle__Tests
    {
        /// <summary>Validates that the <see cref="NvPhysicalGpuHandle__" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NvPhysicalGpuHandle__), Marshal.SizeOf<NvPhysicalGpuHandle__>());
        }

        /// <summary>Validates that the <see cref="NvPhysicalGpuHandle__" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NvPhysicalGpuHandle__).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NvPhysicalGpuHandle__" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(4, sizeof(NvPhysicalGpuHandle__));
        }
    }
}
