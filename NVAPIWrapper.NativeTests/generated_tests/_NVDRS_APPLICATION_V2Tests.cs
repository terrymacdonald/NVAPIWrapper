using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NVDRS_APPLICATION_V2" /> struct.</summary>
    public static unsafe partial class _NVDRS_APPLICATION_V2Tests
    {
        /// <summary>Validates that the <see cref="_NVDRS_APPLICATION_V2" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NVDRS_APPLICATION_V2), Marshal.SizeOf<_NVDRS_APPLICATION_V2>());
        }

        /// <summary>Validates that the <see cref="_NVDRS_APPLICATION_V2" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NVDRS_APPLICATION_V2).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NVDRS_APPLICATION_V2" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(16392, sizeof(_NVDRS_APPLICATION_V2));
        }
    }
}
