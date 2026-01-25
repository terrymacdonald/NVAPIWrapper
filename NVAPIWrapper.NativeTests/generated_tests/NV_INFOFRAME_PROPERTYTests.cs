using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_INFOFRAME_PROPERTY" /> struct.</summary>
    public static unsafe partial class NV_INFOFRAME_PROPERTYTests
    {
        /// <summary>Validates that the <see cref="NV_INFOFRAME_PROPERTY" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_INFOFRAME_PROPERTY), Marshal.SizeOf<NV_INFOFRAME_PROPERTY>());
        }

        /// <summary>Validates that the <see cref="NV_INFOFRAME_PROPERTY" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_INFOFRAME_PROPERTY).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_INFOFRAME_PROPERTY" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(4, sizeof(NV_INFOFRAME_PROPERTY));
        }
    }
}
