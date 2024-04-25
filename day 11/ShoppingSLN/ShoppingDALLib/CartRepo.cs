using SolutionModelLib;
using SolutionModelLib.Enums;
using SolutionModelLib.Exceptions;

namespace ShoppingDALLib;

public class CartRepo : AbstractRepository<int, Cart>
{
    public override Cart Delete(int key)
    {
        Cart customer = GetByKey(key);

        if (customer != null)
        {
            items.Remove(customer);
            return customer;

        }

        throw new EntityNotFoundException(Entity.Cart);
    }

    public override Cart Add(Cart item)
    {
        foreach (var cart in items)
        {
            if (cart.Id == item.Id)
            {
                throw new DuplicateEntityException(Entity.Cart);
            }
        }
        return base.Add(item);
    }

    public override Cart GetByKey(int key)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Id == key)
                return items[i];
        }
        throw new EntityNotFoundException(Entity.Cart);
    }

    public override Cart Update(Cart item)
    {
        Cart customer = GetByKey(item.Id);
        if (customer != null)
        {
            customer = item;
            return customer;
        }
        throw new EntityNotFoundException(Entity.Cart);
    }

}
