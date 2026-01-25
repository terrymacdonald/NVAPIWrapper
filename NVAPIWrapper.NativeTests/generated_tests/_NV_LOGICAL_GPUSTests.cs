using System;
using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_LOGICAL_GPUS" /> struct.</summary>
    public static unsafe partial class _NV_LOGICAL_GPUSTests
    {
        /// <summary>Validates that the <see cref="_NV_LOGICAL_GPUS" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_LOGICAL_GPUS), Marshal.SizeOf<_NV_LOGICAL_GPUS>());
        }

        /// <summary>Validates that the <see cref="_NV_LOGICAL_GPUS" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_LOGICAL_GPUS).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_LOGICAL_GPUS" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(2080, sizeof(_NV_LOGICAL_GPUS));
            }
            else
            {
                Assert.Equal(1560, sizeof(_NV_LOGICAL_GPUS));
            }
        }
    }
}
