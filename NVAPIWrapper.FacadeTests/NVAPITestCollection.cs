using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using Xunit;
using Xunit.Abstractions;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
[assembly: TestCollectionOrderer("NVAPIWrapper.FacadeTests.ActiveTestCollectionOrderer", "NVAPIWrapper.FacadeTests")]

namespace NVAPIWrapper.FacadeTests
{
    [SupportedOSPlatform("windows")]
    [CollectionDefinition("Passive", DisableParallelization = true)]
    public sealed class PassiveCollection : ICollectionFixture<NVAPITestFixture>
    {
    }

    [SupportedOSPlatform("windows")]
    [CollectionDefinition("ActiveDisplay", DisableParallelization = true)]
    public sealed class ActiveDisplayCollection : ICollectionFixture<NVAPITestFixture>
    {
    }

    [SupportedOSPlatform("windows")]
    [CollectionDefinition("ActiveCombined", DisableParallelization = true)]
    public sealed class ActiveCombinedCollection : ICollectionFixture<NVAPITestFixture>
    {
    }

    public sealed class ActiveTestCollectionOrderer : ITestCollectionOrderer
    {
        private static readonly Dictionary<string, int> CollectionOrder = new(StringComparer.Ordinal)
        {
            ["Passive"] = 0,
            ["ActiveDisplay"] = 1,
            ["ActiveCombined"] = 2
        };

        public IEnumerable<ITestCollection> OrderTestCollections(IEnumerable<ITestCollection> testCollections)
        {
            return testCollections
                .OrderBy(collection => GetOrder(collection.DisplayName))
                .ThenBy(collection => collection.DisplayName, StringComparer.Ordinal);
        }

        private static int GetOrder(string displayName)
        {
            foreach (var entry in CollectionOrder)
            {
                if (displayName.Contains(entry.Key, StringComparison.Ordinal))
                    return entry.Value;
            }

            return int.MaxValue;
        }
    }
}
