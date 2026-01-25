using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NvMonitorHandle__" /> struct.</summary>
    public static unsafe partial class NvMonitorHandle__Tests
    {
        /// <summary>Validates that the <see cref="NvMonitorHandle__" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NvMonitorHandle__), Marshal.SizeOf<NvMonitorHandle__>());
        }

        /// <summary>Validates that the <see cref="NvMonitorHandle__" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NvMonitorHandle__).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NvMonitorHandle__" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(4, sizeof(NvMonitorHandle__));
        }
    }
}
