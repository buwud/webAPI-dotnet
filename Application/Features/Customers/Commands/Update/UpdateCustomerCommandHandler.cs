using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using MediatR;

namespace Application.Features.Customers.Commands.Update
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        public ICustomerRepository _customerRepository;
        public IMapper _mapper;

        public UpdateCustomerCommandHandler( ICustomerRepository customerRepository, IMapper mapper )
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle( UpdateCustomerCommand request, CancellationToken cancellationToken )
        {
            var customer = _mapper.Map<CustomerEntity>(request);
            _ = await _customerRepository.UpdateAsync(customer);
            return Unit.Value;
        }
    }
}
