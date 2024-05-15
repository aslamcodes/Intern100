using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza.NET.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int PizzaId { get; set; }

        public int Quantity { get; set; }

        public OrderStatusEnum Status { get; set; }

        public string? DeliveryAddress { get; set; }

        public DateTime OrderedDate { get; set; } = DateTime.Now;

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("PizzaId")]
        public Pizza Pizza { get; set; }
    }

    public enum OrderStatusEnum
    {
        Preparing,
        Completed,
        Cancelled,
        OutForDelivery,
        Delivered
    }

}
