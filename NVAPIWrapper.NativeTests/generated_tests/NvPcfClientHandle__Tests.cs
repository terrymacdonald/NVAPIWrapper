using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NvPcfClientHandle__" /> struct.</summary>
    public static unsafe partial class NvPcfClientHandle__Tests
    {
        /// <summary>Validates that the <see cref="NvPcfClientHandle__" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NvPcfClientHandle__), Marshal.SizeOf<NvPcfClientHandle__>());
        }

        /// <summary>Validates that the <see cref="NvPcfClientHandle__" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NvPcfClientHandle__).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NvPcfClientHandle__" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(4, sizeof(NvPcfClientHandle__));
        }
    }
}
