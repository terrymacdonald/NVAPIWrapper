using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_DISPLAY_PORT_CONFIG" /> struct.</summary>
    public static unsafe partial class NV_DISPLAY_PORT_CONFIGTests
    {
        /// <summary>Validates that the <see cref="NV_DISPLAY_PORT_CONFIG" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_DISPLAY_PORT_CONFIG), Marshal.SizeOf<NV_DISPLAY_PORT_CONFIG>());
        }

        /// <summary>Validates that the <see cref="NV_DISPLAY_PORT_CONFIG" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_DISPLAY_PORT_CONFIG).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_DISPLAY_PORT_CONFIG" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(32, sizeof(NV_DISPLAY_PORT_CONFIG));
        }
    }
}
