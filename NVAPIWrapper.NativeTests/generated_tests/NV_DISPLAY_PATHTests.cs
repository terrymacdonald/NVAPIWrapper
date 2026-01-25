using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_DISPLAY_PATH" /> struct.</summary>
    public static unsafe partial class NV_DISPLAY_PATHTests
    {
        /// <summary>Validates that the <see cref="NV_DISPLAY_PATH" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_DISPLAY_PATH), Marshal.SizeOf<NV_DISPLAY_PATH>());
        }

        /// <summary>Validates that the <see cref="NV_DISPLAY_PATH" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_DISPLAY_PATH).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_DISPLAY_PATH" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(56, sizeof(NV_DISPLAY_PATH));
        }
    }
}
