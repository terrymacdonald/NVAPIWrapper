using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_CUSTOM_DISPLAY" /> struct.</summary>
    public static unsafe partial class NV_CUSTOM_DISPLAYTests
    {
        /// <summary>Validates that the <see cref="NV_CUSTOM_DISPLAY" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_CUSTOM_DISPLAY), Marshal.SizeOf<NV_CUSTOM_DISPLAY>());
        }

        /// <summary>Validates that the <see cref="NV_CUSTOM_DISPLAY" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_CUSTOM_DISPLAY).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_CUSTOM_DISPLAY" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(144, sizeof(NV_CUSTOM_DISPLAY));
        }
    }
}
