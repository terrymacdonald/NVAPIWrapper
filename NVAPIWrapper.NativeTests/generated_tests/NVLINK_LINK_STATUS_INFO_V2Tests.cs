using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NVLINK_LINK_STATUS_INFO_V2" /> struct.</summary>
    public static unsafe partial class NVLINK_LINK_STATUS_INFO_V2Tests
    {
        /// <summary>Validates that the <see cref="NVLINK_LINK_STATUS_INFO_V2" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NVLINK_LINK_STATUS_INFO_V2), Marshal.SizeOf<NVLINK_LINK_STATUS_INFO_V2>());
        }

        /// <summary>Validates that the <see cref="NVLINK_LINK_STATUS_INFO_V2" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NVLINK_LINK_STATUS_INFO_V2).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NVLINK_LINK_STATUS_INFO_V2" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(176, sizeof(NVLINK_LINK_STATUS_INFO_V2));
        }
    }
}
