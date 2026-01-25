using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NvUnAttachedDisplayHandle__" /> struct.</summary>
    public static unsafe partial class NvUnAttachedDisplayHandle__Tests
    {
        /// <summary>Validates that the <see cref="NvUnAttachedDisplayHandle__" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NvUnAttachedDisplayHandle__), Marshal.SizeOf<NvUnAttachedDisplayHandle__>());
        }

        /// <summary>Validates that the <see cref="NvUnAttachedDisplayHandle__" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NvUnAttachedDisplayHandle__).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NvUnAttachedDisplayHandle__" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(4, sizeof(NvUnAttachedDisplayHandle__));
        }
    }
}
