namespace CustomerIntegrationTests.Fixtures
{
    [Trait("Catogory", "Integration")]
    public abstract class IntegrationTest : IClassFixture<ApiWebApplicationFactory>
    {
        protected readonly ApiWebApplicationFactory _factory;
        protected readonly HttpClient _httpClient;

        public IntegrationTest( ApiWebApplicationFactory factory )
        {
            _factory = factory;
            _httpClient = factory.CreateClient();
        }
    }
}
