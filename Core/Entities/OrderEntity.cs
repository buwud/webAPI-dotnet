namespace Core.Entities
{
    public class OrderEntity : BaseEntity
    {
        public string OrderStatus { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        //orderın müşterisi
        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; }

    }
}
