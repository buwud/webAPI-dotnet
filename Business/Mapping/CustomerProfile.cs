using Application.Features.Customers.Dtos;
using AutoMapper;
using Core.Entities;

namespace Application.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerEntity,CustomerDto>();
            CreateMap<CreateOrUpdateCustomerDto,CustomerEntity>();
        }
    }
}
