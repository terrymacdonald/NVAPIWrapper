using System;
using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_PHYSICAL_GPU_HANDLE_DATA" /> struct.</summary>
    public static unsafe partial class _NV_PHYSICAL_GPU_HANDLE_DATATests
    {
        /// <summary>Validates that the <see cref="_NV_PHYSICAL_GPU_HANDLE_DATA" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_PHYSICAL_GPU_HANDLE_DATA), Marshal.SizeOf<_NV_PHYSICAL_GPU_HANDLE_DATA>());
        }

        /// <summary>Validates that the <see cref="_NV_PHYSICAL_GPU_HANDLE_DATA" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_PHYSICAL_GPU_HANDLE_DATA).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_PHYSICAL_GPU_HANDLE_DATA" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(32, sizeof(_NV_PHYSICAL_GPU_HANDLE_DATA));
            }
            else
            {
                Assert.Equal(24, sizeof(_NV_PHYSICAL_GPU_HANDLE_DATA));
            }
        }
    }
}
