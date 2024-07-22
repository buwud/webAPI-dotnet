using Application.Features.Customers.Dtos;
using MediatR;

namespace Application.Features.Customers.Queries.GetAll;

public record GetAllQuery : IRequest<IEnumerable<CustomerDto>>;

