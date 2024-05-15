namespace Pizza.NET.Models.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string UserEmail { get; set; }

        public string UserAddress { get; set; }

        public string UserPhone { get; set; }

        public List<PizzaDto> Pizzas { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
