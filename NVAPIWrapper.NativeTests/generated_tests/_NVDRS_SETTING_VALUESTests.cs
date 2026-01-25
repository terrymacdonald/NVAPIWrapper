using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NVDRS_SETTING_VALUES" /> struct.</summary>
    public static unsafe partial class _NVDRS_SETTING_VALUESTests
    {
        /// <summary>Validates that the <see cref="_NVDRS_SETTING_VALUES" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NVDRS_SETTING_VALUES), Marshal.SizeOf<_NVDRS_SETTING_VALUES>());
        }

        /// <summary>Validates that the <see cref="_NVDRS_SETTING_VALUES" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NVDRS_SETTING_VALUES).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NVDRS_SETTING_VALUES" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(414112, sizeof(_NVDRS_SETTING_VALUES));
        }
    }
}
