using Xunit;

// Disable parallel test execution. Each test class creates/disposes an NVAPIApi
// instance which writes to shared static delegate* fields on the NVAPI class.
// Running classes concurrently causes races that crash the test host.
[assembly: CollectionBehavior(DisableTestParallelization = true)]
