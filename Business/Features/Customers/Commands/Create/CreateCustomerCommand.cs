using MediatR;

namespace Application.Features.Customers.Commands.Create;

public record CreateCustomerCommand( string Name, string Surname, string Email, string Phone ) : IRequest<int>;
