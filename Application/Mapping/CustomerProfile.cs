using Application.Features.Customers.Dtos;
using AutoMapper;
using Core.Entities;

namespace Application.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerEntity, CustomerDto>();
            CreateMap<CustomerDto, CustomerEntity>();

            CreateMap<CreateCustomerRequest, CustomerEntity>()
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.Ignore()
                ).ForMember(dest =>
                    dest.CreatedAt,
                    opt => opt.Ignore()
                ).ForMember(dest =>
                    dest.UpdatedAt,
                    opt => opt.Ignore()
                );
            CreateMap<CustomerEntity, CustomerResponse>();
        }
    }
}
