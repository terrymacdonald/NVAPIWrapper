using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NvTransitionHandle__" /> struct.</summary>
    public static unsafe partial class NvTransitionHandle__Tests
    {
        /// <summary>Validates that the <see cref="NvTransitionHandle__" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NvTransitionHandle__), Marshal.SizeOf<NvTransitionHandle__>());
        }

        /// <summary>Validates that the <see cref="NvTransitionHandle__" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NvTransitionHandle__).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NvTransitionHandle__" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(4, sizeof(NvTransitionHandle__));
        }
    }
}
