using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NvGSyncDeviceHandle__" /> struct.</summary>
    public static unsafe partial class NvGSyncDeviceHandle__Tests
    {
        /// <summary>Validates that the <see cref="NvGSyncDeviceHandle__" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NvGSyncDeviceHandle__), Marshal.SizeOf<NvGSyncDeviceHandle__>());
        }

        /// <summary>Validates that the <see cref="NvGSyncDeviceHandle__" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NvGSyncDeviceHandle__).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NvGSyncDeviceHandle__" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(4, sizeof(NvGSyncDeviceHandle__));
        }
    }
}
