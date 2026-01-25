using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NvVioHandle__" /> struct.</summary>
    public static unsafe partial class NvVioHandle__Tests
    {
        /// <summary>Validates that the <see cref="NvVioHandle__" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NvVioHandle__), Marshal.SizeOf<NvVioHandle__>());
        }

        /// <summary>Validates that the <see cref="NvVioHandle__" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NvVioHandle__).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NvVioHandle__" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(4, sizeof(NvVioHandle__));
        }
    }
}
