using MediatR;

namespace Application.Features.Customers.Commands.Delete;

public record DeleteCustomerCommand( int Id ) : IRequest;


