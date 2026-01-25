using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_MONITOR_CAPS_VCDB" /> struct.</summary>
    public static unsafe partial class _NV_MONITOR_CAPS_VCDBTests
    {
        /// <summary>Validates that the <see cref="_NV_MONITOR_CAPS_VCDB" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_MONITOR_CAPS_VCDB), Marshal.SizeOf<_NV_MONITOR_CAPS_VCDB>());
        }

        /// <summary>Validates that the <see cref="_NV_MONITOR_CAPS_VCDB" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_MONITOR_CAPS_VCDB).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_MONITOR_CAPS_VCDB" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(_NV_MONITOR_CAPS_VCDB));
        }
    }
}
