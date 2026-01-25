using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NvTargetHandle__" /> struct.</summary>
    public static unsafe partial class NvTargetHandle__Tests
    {
        /// <summary>Validates that the <see cref="NvTargetHandle__" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NvTargetHandle__), Marshal.SizeOf<NvTargetHandle__>());
        }

        /// <summary>Validates that the <see cref="NvTargetHandle__" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NvTargetHandle__).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NvTargetHandle__" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(4, sizeof(NvTargetHandle__));
        }
    }
}
