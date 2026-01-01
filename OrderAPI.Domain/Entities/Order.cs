namespace OrderAPI.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; } // Lien avec Product microservice
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
