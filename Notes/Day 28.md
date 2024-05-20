---
Date: 2024-05-20
---
# Notes
## Linq Again but...
- We can use Linq 
### Transcribe
- Writes a function `PrintAuthorNames`
- in it initialises the pub db context
- gets the authors
- and foreach consoles it.
- Uses a breakpoint
- In foreach loop its going in again 
### GroupBy - Conventional Way
```c#
    //    var books = context.Titles
        //                .GroupBy(t => t.PubId)
        //                .Select(t => new {
        //                    PublisherId = t.Key,
        //                    TitleCount = t.Count(),
        //                    Titles = t.Select(t => new
        //                    {
        //                        BookName = t.Title1,
        //                        BookPrice = t.Price
        //                    })
        //                });
```
### GroupBy - New Way
```c#
     var orders = pubsContext.Sales
                            .GroupBy(s => s.TitleId, s => s, (tid, sale) => new { Id=tid,OrderDetails=sale.ToList()});
```
## Logging
- ILogger is automatically injected by itself
- Log4Net
	- For log4net we need `log4net.config` file
	- And also we need a `NuGet` package 
	
