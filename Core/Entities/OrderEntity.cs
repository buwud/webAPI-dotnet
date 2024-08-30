namespace Core.Entities
{
    public class OrderEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        //orderın müşterisi
        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; }

    }
}
