using System;
using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_I2C_INFO_V3" /> struct.</summary>
    public static unsafe partial class NV_I2C_INFO_V3Tests
    {
        /// <summary>Validates that the <see cref="NV_I2C_INFO_V3" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_I2C_INFO_V3), Marshal.SizeOf<NV_I2C_INFO_V3>());
        }

        /// <summary>Validates that the <see cref="NV_I2C_INFO_V3" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_I2C_INFO_V3).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_I2C_INFO_V3" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(64, sizeof(NV_I2C_INFO_V3));
            }
            else
            {
                Assert.Equal(44, sizeof(NV_I2C_INFO_V3));
            }
        }
    }
}
