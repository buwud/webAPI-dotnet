using Application.Interfaces;
using Application.Mapping;
using AutoMapper;
using Infrastructure.Contexts;
using Infrastructure.Repository;

namespace CustomerIntegrationTests.Repositories
{
    public class CustomerRepoTests : IClassFixture<SharedDatabaseFixture>
    {
        private readonly IMapper _mapper;
        private readonly DapperContext _context;
        private readonly ICustomerRepository _customerRepository;
        private SharedDatabaseFixture Fixture { get; }

        public CustomerRepoTests( IMapper mapper, DapperContext dapperContext, ICustomerRepository customerRepository, SharedDatabaseFixture fixture )
        {
            Fixture = fixture;

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CustomerProfile());
            });

            _mapper = configuration.CreateMapper();
            _context = dapperContext;
            _customerRepository = customerRepository;
        }
        // Tests go here
        [Fact]
        public async Task GetCustomers_ReturnsAllCustomers()
        {
            // Arrange
            var expected = Fixture.Customers.Count;

            // Act
            var result = ( await _customerRepository.GetAllAsync() ).Count();

            // Assert
            Assert.Equal(expected, result);
        }



    }
}
