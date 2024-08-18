using Application.Mapping;
using AutoMapper;

namespace CustomerIntegrationTests.Repositories
{
    public class CustomerRepoTests : IClassFixture<SharedDatabaseFixture>
    {
        private readonly IMapper _mapper;
        private SharedDatabaseFixture Fixture { get; }

        public CustomerRepoTests( IMapper mapper, SharedDatabaseFixture fixture )
        {
            Fixture = fixture;

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CustomerProfile());
            });

            _mapper = configuration.CreateMapper();
        }
        // Tests go here
    }
}
