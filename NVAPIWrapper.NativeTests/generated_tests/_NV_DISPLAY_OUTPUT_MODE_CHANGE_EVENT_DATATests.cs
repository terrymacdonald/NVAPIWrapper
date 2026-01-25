using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_DISPLAY_OUTPUT_MODE_CHANGE_EVENT_DATA" /> struct.</summary>
    public static unsafe partial class _NV_DISPLAY_OUTPUT_MODE_CHANGE_EVENT_DATATests
    {
        /// <summary>Validates that the <see cref="_NV_DISPLAY_OUTPUT_MODE_CHANGE_EVENT_DATA" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_DISPLAY_OUTPUT_MODE_CHANGE_EVENT_DATA), Marshal.SizeOf<_NV_DISPLAY_OUTPUT_MODE_CHANGE_EVENT_DATA>());
        }

        /// <summary>Validates that the <see cref="_NV_DISPLAY_OUTPUT_MODE_CHANGE_EVENT_DATA" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_DISPLAY_OUTPUT_MODE_CHANGE_EVENT_DATA).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_DISPLAY_OUTPUT_MODE_CHANGE_EVENT_DATA" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(8, sizeof(_NV_DISPLAY_OUTPUT_MODE_CHANGE_EVENT_DATA));
        }
    }
}
