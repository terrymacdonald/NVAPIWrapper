using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NVVIOCHANNELSTATUS" /> struct.</summary>
    public static unsafe partial class _NVVIOCHANNELSTATUSTests
    {
        /// <summary>Validates that the <see cref="_NVVIOCHANNELSTATUS" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NVVIOCHANNELSTATUS), Marshal.SizeOf<_NVVIOCHANNELSTATUS>());
        }

        /// <summary>Validates that the <see cref="_NVVIOCHANNELSTATUS" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NVVIOCHANNELSTATUS).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NVVIOCHANNELSTATUS" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(24, sizeof(_NVVIOCHANNELSTATUS));
        }
    }
}
