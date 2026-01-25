using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NVVIOOUTPUTSTATUS" /> struct.</summary>
    public static unsafe partial class _NVVIOOUTPUTSTATUSTests
    {
        /// <summary>Validates that the <see cref="_NVVIOOUTPUTSTATUS" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NVVIOOUTPUTSTATUS), Marshal.SizeOf<_NVVIOOUTPUTSTATUS>());
        }

        /// <summary>Validates that the <see cref="_NVVIOOUTPUTSTATUS" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NVVIOOUTPUTSTATUS).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NVVIOOUTPUTSTATUS" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(56, sizeof(_NVVIOOUTPUTSTATUS));
        }
    }
}
