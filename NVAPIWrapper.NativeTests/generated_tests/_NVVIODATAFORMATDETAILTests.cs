using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NVVIODATAFORMATDETAIL" /> struct.</summary>
    public static unsafe partial class _NVVIODATAFORMATDETAILTests
    {
        /// <summary>Validates that the <see cref="_NVVIODATAFORMATDETAIL" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NVVIODATAFORMATDETAIL), Marshal.SizeOf<_NVVIODATAFORMATDETAIL>());
        }

        /// <summary>Validates that the <see cref="_NVVIODATAFORMATDETAIL" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NVVIODATAFORMATDETAIL).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NVVIODATAFORMATDETAIL" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(8, sizeof(_NVVIODATAFORMATDETAIL));
        }
    }
}
