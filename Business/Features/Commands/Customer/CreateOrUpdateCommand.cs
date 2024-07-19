using MediatR;

namespace Application.Features.Commands.CustomerCommands
{
    public class CreateOrUpdateCommand : IRequest<int>
    {
        public Domain.CustomerEntity Customer { get; }

        public CreateOrUpdateCommand( Domain.CustomerEntity customer )
        {
            Customer = customer;
        }
    }
}
