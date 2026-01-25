using System;
using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_SettingDWORDNameString" /> struct.</summary>
    public static unsafe partial class _SettingDWORDNameStringTests
    {
        /// <summary>Validates that the <see cref="_SettingDWORDNameString" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_SettingDWORDNameString), Marshal.SizeOf<_SettingDWORDNameString>());
        }

        /// <summary>Validates that the <see cref="_SettingDWORDNameString" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_SettingDWORDNameString).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_SettingDWORDNameString" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(40, sizeof(_SettingDWORDNameString));
            }
            else
            {
                Assert.Equal(20, sizeof(_SettingDWORDNameString));
            }
        }
    }
}
