# Day 28 - Logging & GroupBy

## Morning Session
- Covered LINQ's Group Query on Pubs Database
- Explored Microsoft's inbuilt Logging interface & File based logging (log4net asp.net) with the Request tracker application, [commit](https://github.com/aslamcodes/Intern100/commit/16c654259e51e39cf9fdaa1766630cf57d1e441f?diff=unified&w=0)

# Tasks
## In Session Tasks
- Print the TitleId and the same Quantity and order id for every title from pubs database
```csharp
 static void SalesDetailsForTitle()
{

    PubsContext context = new PubsContext();

    var books = context.Sales
        .GroupBy(s => s.TitleId, s => s, (titleId, sales) => new
        {
            TitleId = titleId,
            Sales = sales.Select(s => new
            {
                s.Qty,
                s.OrdNum
            })
        });

    foreach (var book in books)
    {
        Console.WriteLine(book.TitleId);

        foreach (var sale in book.Sales)
        {
            Console.WriteLine("\t" + sale.Qty + " " + sale.OrdNum);
        }
    }
}
```

## Afternoon Session
- Hackerrank C# basic skill test [Cert](https://www.hackerrank.com/certificates/9cf6e94745a2)
- Implemented logging with [PizzaChain Applicaiton](https://github.com/aslamcodes/Intern100/tree/main/day%2025%20Regions%2C%20Auth%2C%20DTOs%2C%20Error%20Models%2C%20API%20documentations/Pizza.NETSLN)