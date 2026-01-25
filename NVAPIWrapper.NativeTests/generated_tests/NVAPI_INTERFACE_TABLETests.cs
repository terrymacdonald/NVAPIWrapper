using System;
using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NVAPI_INTERFACE_TABLE" /> struct.</summary>
    public static unsafe partial class NVAPI_INTERFACE_TABLETests
    {
        /// <summary>Validates that the <see cref="NVAPI_INTERFACE_TABLE" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NVAPI_INTERFACE_TABLE), Marshal.SizeOf<NVAPI_INTERFACE_TABLE>());
        }

        /// <summary>Validates that the <see cref="NVAPI_INTERFACE_TABLE" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NVAPI_INTERFACE_TABLE).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NVAPI_INTERFACE_TABLE" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(16, sizeof(NVAPI_INTERFACE_TABLE));
            }
            else
            {
                Assert.Equal(8, sizeof(NVAPI_INTERFACE_TABLE));
            }
        }
    }
}
