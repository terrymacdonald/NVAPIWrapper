using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NVVIOGAMMACORRECTION" /> struct.</summary>
    public static unsafe partial class _NVVIOGAMMACORRECTIONTests
    {
        /// <summary>Validates that the <see cref="_NVVIOGAMMACORRECTION" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NVVIOGAMMACORRECTION), Marshal.SizeOf<_NVVIOGAMMACORRECTION>());
        }

        /// <summary>Validates that the <see cref="_NVVIOGAMMACORRECTION" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NVVIOGAMMACORRECTION).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NVVIOGAMMACORRECTION" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(6164, sizeof(_NVVIOGAMMACORRECTION));
        }
    }
}
