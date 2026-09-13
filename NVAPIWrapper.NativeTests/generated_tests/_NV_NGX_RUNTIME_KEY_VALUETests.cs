using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_NGX_RUNTIME_KEY_VALUE" /> struct.</summary>
    public static unsafe partial class _NV_NGX_RUNTIME_KEY_VALUETests
    {
        /// <summary>Validates that the <see cref="_NV_NGX_RUNTIME_KEY_VALUE" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_NGX_RUNTIME_KEY_VALUE), Marshal.SizeOf<_NV_NGX_RUNTIME_KEY_VALUE>());
        }

        /// <summary>Validates that the <see cref="_NV_NGX_RUNTIME_KEY_VALUE" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_NGX_RUNTIME_KEY_VALUE).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_NGX_RUNTIME_KEY_VALUE" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(16, sizeof(_NV_NGX_RUNTIME_KEY_VALUE));
        }
    }
}
