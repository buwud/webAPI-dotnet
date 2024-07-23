using Application.Features.Customers.Dtos;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.Customers.Queries.GetById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto?>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerByIdQueryHandler( ICustomerRepository customerRepository, IMapper mapper )
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDto?> Handle( GetCustomerByIdQuery request, CancellationToken cancellationToken )
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);
            if ( customer == null ) return null;
            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
