using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NVVIOCOMPOSITERANGE" /> struct.</summary>
    public static unsafe partial class _NVVIOCOMPOSITERANGETests
    {
        /// <summary>Validates that the <see cref="_NVVIOCOMPOSITERANGE" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NVVIOCOMPOSITERANGE), Marshal.SizeOf<_NVVIOCOMPOSITERANGE>());
        }

        /// <summary>Validates that the <see cref="_NVVIOCOMPOSITERANGE" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NVVIOCOMPOSITERANGE).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NVVIOCOMPOSITERANGE" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(16, sizeof(_NVVIOCOMPOSITERANGE));
        }
    }
}
