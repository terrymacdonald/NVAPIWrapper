using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_GPU_GET_HDCP_SUPPORT_STATUS" /> struct.</summary>
    public static unsafe partial class NV_GPU_GET_HDCP_SUPPORT_STATUSTests
    {
        /// <summary>Validates that the <see cref="NV_GPU_GET_HDCP_SUPPORT_STATUS" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_GPU_GET_HDCP_SUPPORT_STATUS), Marshal.SizeOf<NV_GPU_GET_HDCP_SUPPORT_STATUS>());
        }

        /// <summary>Validates that the <see cref="NV_GPU_GET_HDCP_SUPPORT_STATUS" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_GPU_GET_HDCP_SUPPORT_STATUS).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_GPU_GET_HDCP_SUPPORT_STATUS" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(16, sizeof(NV_GPU_GET_HDCP_SUPPORT_STATUS));
        }
    }
}
