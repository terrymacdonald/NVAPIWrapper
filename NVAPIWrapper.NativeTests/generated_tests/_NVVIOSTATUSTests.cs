using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NVVIOSTATUS" /> struct.</summary>
    public static unsafe partial class _NVVIOSTATUSTests
    {
        /// <summary>Validates that the <see cref="_NVVIOSTATUS" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NVVIOSTATUS), Marshal.SizeOf<_NVVIOSTATUS>());
        }

        /// <summary>Validates that the <see cref="_NVVIOSTATUS" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NVVIOSTATUS).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NVVIOSTATUS" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(204, sizeof(_NVVIOSTATUS));
        }
    }
}
