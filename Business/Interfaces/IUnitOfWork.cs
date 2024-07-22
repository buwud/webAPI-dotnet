namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
    }
}
