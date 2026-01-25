using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NvAudioHandle__" /> struct.</summary>
    public static unsafe partial class NvAudioHandle__Tests
    {
        /// <summary>Validates that the <see cref="NvAudioHandle__" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NvAudioHandle__), Marshal.SizeOf<NvAudioHandle__>());
        }

        /// <summary>Validates that the <see cref="NvAudioHandle__" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NvAudioHandle__).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NvAudioHandle__" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(4, sizeof(NvAudioHandle__));
        }
    }
}
