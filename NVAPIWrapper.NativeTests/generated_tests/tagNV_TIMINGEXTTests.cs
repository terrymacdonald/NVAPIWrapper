using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="tagNV_TIMINGEXT" /> struct.</summary>
    public static unsafe partial class tagNV_TIMINGEXTTests
    {
        /// <summary>Validates that the <see cref="tagNV_TIMINGEXT" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(tagNV_TIMINGEXT), Marshal.SizeOf<tagNV_TIMINGEXT>());
        }

        /// <summary>Validates that the <see cref="tagNV_TIMINGEXT" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(tagNV_TIMINGEXT).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="tagNV_TIMINGEXT" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(64, sizeof(tagNV_TIMINGEXT));
        }
    }
}
