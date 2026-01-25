using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NVVIOPCIINFO" /> struct.</summary>
    public static unsafe partial class _NVVIOPCIINFOTests
    {
        /// <summary>Validates that the <see cref="_NVVIOPCIINFO" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NVVIOPCIINFO), Marshal.SizeOf<_NVVIOPCIINFO>());
        }

        /// <summary>Validates that the <see cref="_NVVIOPCIINFO" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NVVIOPCIINFO).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NVVIOPCIINFO" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(36, sizeof(_NVVIOPCIINFO));
        }
    }
}
