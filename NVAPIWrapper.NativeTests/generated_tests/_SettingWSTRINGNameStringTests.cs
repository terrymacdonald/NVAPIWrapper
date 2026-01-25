using System;
using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_SettingWSTRINGNameString" /> struct.</summary>
    public static unsafe partial class _SettingWSTRINGNameStringTests
    {
        /// <summary>Validates that the <see cref="_SettingWSTRINGNameString" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_SettingWSTRINGNameString), Marshal.SizeOf<_SettingWSTRINGNameString>());
        }

        /// <summary>Validates that the <see cref="_SettingWSTRINGNameString" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_SettingWSTRINGNameString).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_SettingWSTRINGNameString" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(40, sizeof(_SettingWSTRINGNameString));
            }
            else
            {
                Assert.Equal(20, sizeof(_SettingWSTRINGNameString));
            }
        }
    }
}
