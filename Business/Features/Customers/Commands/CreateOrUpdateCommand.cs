using MediatR;

namespace Application.Features.Customers.Commands
{
    public class CreateOrUpdateCommand : IRequest<int>
    {
        public Domain.CustomerEntity Customer { get; }

        public CreateOrUpdateCommand(Domain.CustomerEntity customer)
        {
            Customer = customer;
        }
    }
}
