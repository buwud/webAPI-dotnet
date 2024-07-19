using MediatR;

namespace Application.Features.Commands.Customer
{
    public class DeleteCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeleteCommand( int id )
        {
            Id = id;
        }
    }
}
