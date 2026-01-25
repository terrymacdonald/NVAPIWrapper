using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_V1" /> struct.</summary>
    public static unsafe partial class NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_V1Tests
    {
        /// <summary>Validates that the <see cref="NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_V1" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_V1), Marshal.SizeOf<NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_V1>());
        }

        /// <summary>Validates that the <see cref="NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_V1" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_V1).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_V1" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(4936, sizeof(NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_V1));
        }
    }
}
