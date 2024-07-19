using Domain;
using MediatR;

namespace Application.Features.Queries.Customer
{
    public class GetByIdQuery : IRequest<CustomerEntity>
    {
        public int Id { get; set; }
        public GetByIdQuery( int id )
        {
            Id = id;
        }
    }
}
