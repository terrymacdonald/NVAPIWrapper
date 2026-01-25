using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NVVIOINPUTSTATUS" /> struct.</summary>
    public static unsafe partial class _NVVIOINPUTSTATUSTests
    {
        /// <summary>Validates that the <see cref="_NVVIOINPUTSTATUS" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NVVIOINPUTSTATUS), Marshal.SizeOf<_NVVIOINPUTSTATUS>());
        }

        /// <summary>Validates that the <see cref="_NVVIOINPUTSTATUS" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NVVIOINPUTSTATUS).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NVVIOINPUTSTATUS" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(196, sizeof(_NVVIOINPUTSTATUS));
        }
    }
}
