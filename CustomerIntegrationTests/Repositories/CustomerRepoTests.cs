using Application.Interfaces;
using AutoMapper;

[Collection("CustomerRepoTests Collection")]
public class CustomerRepoTests
{
    private readonly ICustomerRepository _customerRepository;
    private readonly SharedDatabaseFixture _fixture;

    public CustomerRepoTests( ICustomerRepository customerRepository, SharedDatabaseFixture fixture )
    {
        _customerRepository = customerRepository;
        _fixture = fixture;
    }

    [Fact]
    public async Task GetCustomers_ReturnsAllCustomers()
    {
        // Arrange
        var expected = _fixture.Customers.Count;

        // Act
        var result = ( await _customerRepository.GetAllAsync() ).Count();

        // Assert
        Assert.Equal(expected, result);
    }
}
