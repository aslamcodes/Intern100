using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza.NET.Models
{
    public class PizzaStock
    {
        public int Id { get; set; }

        // Make this index with annotations
        public int PizzaId { get; set; }

        public int Stock { get; set; }

        [ForeignKey("PizzaId")]
        public Pizza Pizza { get; set; }
    }
}
