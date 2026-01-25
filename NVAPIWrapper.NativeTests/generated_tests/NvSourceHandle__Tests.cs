using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NvSourceHandle__" /> struct.</summary>
    public static unsafe partial class NvSourceHandle__Tests
    {
        /// <summary>Validates that the <see cref="NvSourceHandle__" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NvSourceHandle__), Marshal.SizeOf<NvSourceHandle__>());
        }

        /// <summary>Validates that the <see cref="NvSourceHandle__" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NvSourceHandle__).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NvSourceHandle__" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(4, sizeof(NvSourceHandle__));
        }
    }
}
