using System.Runtime.InteropServices;
using Xunit;

namespace NVAPIWrapper.UnitTests
{
    /// <summary>Provides validation of the <see cref="Nv3DVPTransceiverHandle__" /> struct.</summary>
    public static unsafe partial class Nv3DVPTransceiverHandle__Tests
    {
        /// <summary>Validates that the <see cref="Nv3DVPTransceiverHandle__" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(Nv3DVPTransceiverHandle__), Marshal.SizeOf<Nv3DVPTransceiverHandle__>());
        }

        /// <summary>Validates that the <see cref="Nv3DVPTransceiverHandle__" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(Nv3DVPTransceiverHandle__).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="Nv3DVPTransceiverHandle__" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(4, sizeof(Nv3DVPTransceiverHandle__));
        }
    }
}
