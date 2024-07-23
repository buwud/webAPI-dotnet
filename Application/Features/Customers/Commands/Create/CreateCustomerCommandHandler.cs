using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using MediatR;

namespace Application.Features.Customers.Commands.Create
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler( ICustomerRepository customerRepository, IMapper mapper )
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle( CreateCustomerCommand request, CancellationToken cancellationToken )
        {
            var customer = _mapper.Map<CustomerEntity>(request);
            _ = await _customerRepository.AddAsync(customer);
            return customer.Id;
        }
    }
}
