namespace Pizza.NET.Models.DTO
{
    public static class Mapper
    {
        public static AuthReturnDto ToLoginReturnDto(this User user, string token)
        {
            return new AuthReturnDto
            {
                Id = user.Id,
                Token = token
            };
        }

        public static OrderDTO ToOrderDTO(this Order order)
        {
            return new OrderDTO
            {
                Id = order.Id,
                UserId = order.UserId,
                OrderDate = order.OrderedDate,
                PizzaId = order.PizzaId,
                TotalPrice = order.Quantity * order.Pizza.Price,
                UserAddress = order.DeliveryAddress,
            };
        }

        public static PizzaDto ToPizzaDTO(this Pizza pizza)
        {
            return new PizzaDto
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Price = pizza.Price,
                Description = pizza.Description,
                ImageUrl = pizza.ImageUrl
            };
        }


        public static PizzaStockDto ToPizzaStockDTO(this PizzaStock pizzaStock)
        {
            return new PizzaStockDto
            {
                Id = pizzaStock.Id,
                PizzaId = pizzaStock.PizzaId,
                Quantity = pizzaStock.Stock
            };
        }
    }
}
