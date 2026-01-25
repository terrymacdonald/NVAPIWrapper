using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="NV_LID_DOCK_PARAMS" /> struct.</summary>
    public static unsafe partial class NV_LID_DOCK_PARAMSTests
    {
        /// <summary>Validates that the <see cref="NV_LID_DOCK_PARAMS" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(NV_LID_DOCK_PARAMS), Marshal.SizeOf<NV_LID_DOCK_PARAMS>());
        }

        /// <summary>Validates that the <see cref="NV_LID_DOCK_PARAMS" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(NV_LID_DOCK_PARAMS).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="NV_LID_DOCK_PARAMS" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(28, sizeof(NV_LID_DOCK_PARAMS));
        }
    }
}
