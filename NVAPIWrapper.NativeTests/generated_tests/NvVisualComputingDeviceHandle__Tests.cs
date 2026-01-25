using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NvVisualComputingDeviceHandle__" /> struct.</summary>
    public static unsafe partial class NvVisualComputingDeviceHandle__Tests
    {
        /// <summary>Validates that the <see cref="NvVisualComputingDeviceHandle__" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NvVisualComputingDeviceHandle__), Marshal.SizeOf<NvVisualComputingDeviceHandle__>());
        }

        /// <summary>Validates that the <see cref="NvVisualComputingDeviceHandle__" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NvVisualComputingDeviceHandle__).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NvVisualComputingDeviceHandle__" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(4, sizeof(NvVisualComputingDeviceHandle__));
        }
    }
}
