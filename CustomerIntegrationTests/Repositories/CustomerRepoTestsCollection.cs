using Xunit;

namespace CustomerIntegrationTests.Repositories
{
    [CollectionDefinition("CustomerRepoTests Collection")]
    public class CustomerRepoTestsCollection : ICollectionFixture<SharedDatabaseFixture>
    {
        // This class has no code and is never created. Its purpose is to apply [CollectionDefinition] and ICollectionFixture<> interfaces.
    }
}
