using Application.Features.Customers.Dtos;
using Application.Mapping;
using AutoMapper;
using Core.Entities;
using System.Runtime.Serialization;

namespace CustomerUnitTest.Mappings
{
    public class MappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomerProfile>();
            });
            _mapper = _configuration.CreateMapper();
        }
        [Fact]
        public void ShouldBeValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }
        [Theory]
        [InlineData(typeof(CreateCustomerRequest), typeof(CustomerEntity))]
        [InlineData(typeof(CustomerEntity), typeof(CustomerResponse))]
        public void Map_SourceToDestination_ExistConfiguration( Type origin, Type destination )
        {
            var instance = FormatterServices.GetUninitializedObject(origin);

            _mapper.Map(instance, origin, destination);
        }
    }
}
