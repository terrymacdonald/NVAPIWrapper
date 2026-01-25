using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_INFOFRAME_AUDIO" /> struct.</summary>
    public static unsafe partial class NV_INFOFRAME_AUDIOTests
    {
        /// <summary>Validates that the <see cref="NV_INFOFRAME_AUDIO" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_INFOFRAME_AUDIO), Marshal.SizeOf<NV_INFOFRAME_AUDIO>());
        }

        /// <summary>Validates that the <see cref="NV_INFOFRAME_AUDIO" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_INFOFRAME_AUDIO).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_INFOFRAME_AUDIO" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(16, sizeof(NV_INFOFRAME_AUDIO));
        }
    }
}
