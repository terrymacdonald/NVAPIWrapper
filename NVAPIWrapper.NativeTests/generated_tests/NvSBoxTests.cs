using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NvSBox" /> struct.</summary>
    public static unsafe partial class NvSBoxTests
    {
        /// <summary>Validates that the <see cref="NvSBox" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NvSBox), Marshal.SizeOf<NvSBox>());
        }

        /// <summary>Validates that the <see cref="NvSBox" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NvSBox).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NvSBox" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(16, sizeof(NvSBox));
        }
    }
}
