using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NVVIOINPUTCONFIG" /> struct.</summary>
    public static unsafe partial class _NVVIOINPUTCONFIGTests
    {
        /// <summary>Validates that the <see cref="_NVVIOINPUTCONFIG" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NVVIOINPUTCONFIG), Marshal.SizeOf<_NVVIOINPUTCONFIG>());
        }

        /// <summary>Validates that the <see cref="_NVVIOINPUTCONFIG" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NVVIOINPUTCONFIG).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NVVIOINPUTCONFIG" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(144, sizeof(_NVVIOINPUTCONFIG));
        }
    }
}
