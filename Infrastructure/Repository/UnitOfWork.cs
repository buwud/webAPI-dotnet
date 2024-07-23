using Application.Interfaces;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork( ICustomerRepository customerRepository )
        {
            Customers = customerRepository;
        }

        public ICustomerRepository Customers { get; }
    }
}
