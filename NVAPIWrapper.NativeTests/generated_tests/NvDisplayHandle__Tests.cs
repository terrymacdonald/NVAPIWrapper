using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NvDisplayHandle__" /> struct.</summary>
    public static unsafe partial class NvDisplayHandle__Tests
    {
        /// <summary>Validates that the <see cref="NvDisplayHandle__" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NvDisplayHandle__), Marshal.SizeOf<NvDisplayHandle__>());
        }

        /// <summary>Validates that the <see cref="NvDisplayHandle__" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NvDisplayHandle__).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NvDisplayHandle__" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(4, sizeof(NvDisplayHandle__));
        }
    }
}
