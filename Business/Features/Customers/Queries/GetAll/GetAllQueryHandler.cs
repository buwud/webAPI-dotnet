using Application.Features.Customers.Dtos;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.Customers.Queries.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public async Task<IEnumerable<CustomerDto>> Handle( GetAllQuery request, CancellationToken cancellationToken )
        {
            var customers = await _customerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }
    }
}
