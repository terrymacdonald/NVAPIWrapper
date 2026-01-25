using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NvDRSSessionHandle__" /> struct.</summary>
    public static unsafe partial class NvDRSSessionHandle__Tests
    {
        /// <summary>Validates that the <see cref="NvDRSSessionHandle__" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NvDRSSessionHandle__), Marshal.SizeOf<NvDRSSessionHandle__>());
        }

        /// <summary>Validates that the <see cref="NvDRSSessionHandle__" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NvDRSSessionHandle__).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NvDRSSessionHandle__" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(4, sizeof(NvDRSSessionHandle__));
        }
    }
}
