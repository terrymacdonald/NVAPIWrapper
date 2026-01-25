using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NVVIOCOLORCONVERSION" /> struct.</summary>
    public static unsafe partial class _NVVIOCOLORCONVERSIONTests
    {
        /// <summary>Validates that the <see cref="_NVVIOCOLORCONVERSION" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NVVIOCOLORCONVERSION), Marshal.SizeOf<_NVVIOCOLORCONVERSION>());
        }

        /// <summary>Validates that the <see cref="_NVVIOCOLORCONVERSION" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NVVIOCOLORCONVERSION).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NVVIOCOLORCONVERSION" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(68, sizeof(_NVVIOCOLORCONVERSION));
        }
    }
}
