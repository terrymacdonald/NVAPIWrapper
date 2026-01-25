using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="Nv3DVPGlassesHandle__" /> struct.</summary>
    public static unsafe partial class Nv3DVPGlassesHandle__Tests
    {
        /// <summary>Validates that the <see cref="Nv3DVPGlassesHandle__" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(Nv3DVPGlassesHandle__), Marshal.SizeOf<Nv3DVPGlassesHandle__>());
        }

        /// <summary>Validates that the <see cref="Nv3DVPGlassesHandle__" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(Nv3DVPGlassesHandle__).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="Nv3DVPGlassesHandle__" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(4, sizeof(Nv3DVPGlassesHandle__));
        }
    }
}
