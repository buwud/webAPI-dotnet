using Application.Features.Customers.Dtos;
using MediatR;

namespace Application.Features.Customers.Queries.GetById;
public record GetCustomerByIdQuery( int Id ) : IRequest<CustomerDto>;

