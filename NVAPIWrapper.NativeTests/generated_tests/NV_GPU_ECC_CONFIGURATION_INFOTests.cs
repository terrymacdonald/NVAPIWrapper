using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_GPU_ECC_CONFIGURATION_INFO" /> struct.</summary>
    public static unsafe partial class NV_GPU_ECC_CONFIGURATION_INFOTests
    {
        /// <summary>Validates that the <see cref="NV_GPU_ECC_CONFIGURATION_INFO" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_GPU_ECC_CONFIGURATION_INFO), Marshal.SizeOf<NV_GPU_ECC_CONFIGURATION_INFO>());
        }

        /// <summary>Validates that the <see cref="NV_GPU_ECC_CONFIGURATION_INFO" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_GPU_ECC_CONFIGURATION_INFO).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_GPU_ECC_CONFIGURATION_INFO" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(8, sizeof(NV_GPU_ECC_CONFIGURATION_INFO));
        }
    }
}
