using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NVDX_SwapChainHandle__" /> struct.</summary>
    public static unsafe partial class NVDX_SwapChainHandle__Tests
    {
        /// <summary>Validates that the <see cref="NVDX_SwapChainHandle__" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NVDX_SwapChainHandle__), Marshal.SizeOf<NVDX_SwapChainHandle__>());
        }

        /// <summary>Validates that the <see cref="NVDX_SwapChainHandle__" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NVDX_SwapChainHandle__).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NVDX_SwapChainHandle__" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(4, sizeof(NVDX_SwapChainHandle__));
        }
    }
}
