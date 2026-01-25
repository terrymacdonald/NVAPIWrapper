using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_VIEW_TARGET_INFO" /> struct.</summary>
    public static unsafe partial class NV_VIEW_TARGET_INFOTests
    {
        /// <summary>Validates that the <see cref="NV_VIEW_TARGET_INFO" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_VIEW_TARGET_INFO), Marshal.SizeOf<NV_VIEW_TARGET_INFO>());
        }

        /// <summary>Validates that the <see cref="NV_VIEW_TARGET_INFO" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_VIEW_TARGET_INFO).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_VIEW_TARGET_INFO" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(32, sizeof(NV_VIEW_TARGET_INFO));
        }
    }
}
