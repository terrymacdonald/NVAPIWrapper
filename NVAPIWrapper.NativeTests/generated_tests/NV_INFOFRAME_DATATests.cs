using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_INFOFRAME_DATA" /> struct.</summary>
    public static unsafe partial class NV_INFOFRAME_DATATests
    {
        /// <summary>Validates that the <see cref="NV_INFOFRAME_DATA" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_INFOFRAME_DATA), Marshal.SizeOf<NV_INFOFRAME_DATA>());
        }

        /// <summary>Validates that the <see cref="NV_INFOFRAME_DATA" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_INFOFRAME_DATA).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_INFOFRAME_DATA" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(32, sizeof(NV_INFOFRAME_DATA));
        }
    }
}
