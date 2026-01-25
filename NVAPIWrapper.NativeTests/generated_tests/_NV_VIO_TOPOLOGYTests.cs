using System;
using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_VIO_TOPOLOGY" /> struct.</summary>
    public static unsafe partial class _NV_VIO_TOPOLOGYTests
    {
        /// <summary>Validates that the <see cref="_NV_VIO_TOPOLOGY" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_VIO_TOPOLOGY), Marshal.SizeOf<_NV_VIO_TOPOLOGY>());
        }

        /// <summary>Validates that the <see cref="_NV_VIO_TOPOLOGY" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_VIO_TOPOLOGY).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_VIO_TOPOLOGY" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(200, sizeof(_NV_VIO_TOPOLOGY));
            }
            else
            {
                Assert.Equal(136, sizeof(_NV_VIO_TOPOLOGY));
            }
        }
    }
}
