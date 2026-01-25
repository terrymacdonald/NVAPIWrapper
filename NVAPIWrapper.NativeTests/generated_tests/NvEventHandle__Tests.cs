using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NvEventHandle__" /> struct.</summary>
    public static unsafe partial class NvEventHandle__Tests
    {
        /// <summary>Validates that the <see cref="NvEventHandle__" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NvEventHandle__), Marshal.SizeOf<NvEventHandle__>());
        }

        /// <summary>Validates that the <see cref="NvEventHandle__" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NvEventHandle__).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NvEventHandle__" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(4, sizeof(NvEventHandle__));
        }
    }
}
