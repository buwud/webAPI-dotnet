using MediatR;

namespace Application.Features.Customers.Commands.Update;

public record UpdateCustomerCommand( int Id, string Name, string Surname, string Email, string Phone ) : IRequest;
