using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="_NV_D3D12_WORKSTATION_FEATURE_PROPERTIES" /> struct.</summary>
    public static unsafe partial class _NV_D3D12_WORKSTATION_FEATURE_PROPERTIESTests
    {
        /// <summary>Validates that the <see cref="_NV_D3D12_WORKSTATION_FEATURE_PROPERTIES" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(_NV_D3D12_WORKSTATION_FEATURE_PROPERTIES), Marshal.SizeOf<_NV_D3D12_WORKSTATION_FEATURE_PROPERTIES>());
        }

        /// <summary>Validates that the <see cref="_NV_D3D12_WORKSTATION_FEATURE_PROPERTIES" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(_NV_D3D12_WORKSTATION_FEATURE_PROPERTIES).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="_NV_D3D12_WORKSTATION_FEATURE_PROPERTIES" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(24, sizeof(_NV_D3D12_WORKSTATION_FEATURE_PROPERTIES));
        }
    }
}
