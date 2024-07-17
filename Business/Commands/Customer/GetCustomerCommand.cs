using MediatR;

namespace Business.Commands.Customer
{
    public class GetCustomerCommand:IRequest<int>
    {
    }
}
