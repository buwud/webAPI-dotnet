using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using MediatR;

namespace Application.Features.Customers.Commands.Delete
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public DeleteCustomerCommandHandler( ICustomerRepository customerRepository, IMapper mapper )
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle( DeleteCustomerCommand request, CancellationToken cancellationToken )
        {
            var customer = _mapper.Map<CustomerEntity>(request);
            _ = await _customerRepository.DeleteAsync(customer.Id);
            return Unit.Value;
        }
    }
}
