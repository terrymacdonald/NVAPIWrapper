using Xunit;

namespace NVAPIWrapper.FacadeTests
{
    /// <summary>
    /// NVAPI facade test collection to share initialization.
    /// </summary>
    [CollectionDefinition("NVAPI", DisableParallelization = true)]
    public sealed class NVAPITestCollection : ICollectionFixture<NVAPITestFixture>
    {
    }
}
