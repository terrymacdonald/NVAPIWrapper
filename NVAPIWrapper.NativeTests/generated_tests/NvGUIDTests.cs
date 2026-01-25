using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NvGUID" /> struct.</summary>
    public static unsafe partial class NvGUIDTests
    {
        /// <summary>Validates that the <see cref="NvGUID" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NvGUID), Marshal.SizeOf<NvGUID>());
        }

        /// <summary>Validates that the <see cref="NvGUID" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NvGUID).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NvGUID" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(16, sizeof(NvGUID));
        }
    }
}
