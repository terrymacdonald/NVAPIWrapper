using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NVVIOSIGNALFORMATDETAIL" /> struct.</summary>
    public static unsafe partial class _NVVIOSIGNALFORMATDETAILTests
    {
        /// <summary>Validates that the <see cref="_NVVIOSIGNALFORMATDETAIL" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NVVIOSIGNALFORMATDETAIL), Marshal.SizeOf<_NVVIOSIGNALFORMATDETAIL>());
        }

        /// <summary>Validates that the <see cref="_NVVIOSIGNALFORMATDETAIL" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NVVIOSIGNALFORMATDETAIL).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NVVIOSIGNALFORMATDETAIL" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(28, sizeof(_NVVIOSIGNALFORMATDETAIL));
        }
    }
}
