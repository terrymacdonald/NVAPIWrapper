using System;
using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_I2C_INFO_V1" /> struct.</summary>
    public static unsafe partial class NV_I2C_INFO_V1Tests
    {
        /// <summary>Validates that the <see cref="NV_I2C_INFO_V1" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_I2C_INFO_V1), Marshal.SizeOf<NV_I2C_INFO_V1>());
        }

        /// <summary>Validates that the <see cref="NV_I2C_INFO_V1" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_I2C_INFO_V1).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_I2C_INFO_V1" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(48, sizeof(NV_I2C_INFO_V1));
            }
            else
            {
                Assert.Equal(32, sizeof(NV_I2C_INFO_V1));
            }
        }
    }
}
