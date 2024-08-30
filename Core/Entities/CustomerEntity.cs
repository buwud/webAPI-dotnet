namespace Core.Entities
{
    public class CustomerEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        //müşterinin orderları
        public ICollection<OrderEntity> Orders { get; set; }
    }
}
