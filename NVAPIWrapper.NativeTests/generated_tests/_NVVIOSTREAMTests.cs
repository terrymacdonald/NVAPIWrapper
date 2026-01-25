using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NVVIOSTREAM" /> struct.</summary>
    public static unsafe partial class _NVVIOSTREAMTests
    {
        /// <summary>Validates that the <see cref="_NVVIOSTREAM" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NVVIOSTREAM), Marshal.SizeOf<_NVVIOSTREAM>());
        }

        /// <summary>Validates that the <see cref="_NVVIOSTREAM" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NVVIOSTREAM).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NVVIOSTREAM" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(32, sizeof(_NVVIOSTREAM));
        }
    }
}
