namespace Linq
{
    internal class Program
    {
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
        static void PrintTheBooksPulisherwise()
        {
            PubsContext context = new PubsContext();
            //var books = context.Titles
            //            .GroupBy(title => title.PubId, title => title.Pub, (publisherId, publisherTitles) => new { Key = publisherId, TitleCount = publisherTitles.Count() });
            var books = context.Titles
                   .GroupBy(t => t.PubId)
                   .Select(t => new
                   {
                       PublisherId = t.Key,
                       TitleCount = t.Count(),
                       Titles = t.Select(t => new
                       {
                           BookName = t.Title1,
                           BookPrice = t.Price
                       })
                   });
            // SELECT t.PubId AS PublisherId, COUNT(*) AS TitleCount, t.Title1 AS BookName, t.Price AS BookPrice
            // FROM Titles t
            // GROUP BY t.PubId, t.Title1, t.Price
            foreach (var book in books)
            {
                Console.WriteLine(book.PublisherId + " - " + book.TitleCount);

                foreach (var title in book.Titles)
                {
                    Console.WriteLine("\t" + title.BookName + " " + title.BookPrice);
                }
            }
        }
        static void PrintNumberOfBooksFromType(string type)
        {
            PubsContext context = new PubsContext();

            var bookCount = context.Titles.Where(t => t.Type == type).Count();

            Console.WriteLine($"There are {bookCount} in the type {type}");
        }
        static void PrintAuthorNames()
        {
            PubsContext context = new PubsContext();

            var authors = context.Authors.ToList();

            foreach (var author in authors)
            {
                Console.WriteLine(author.AuFname + " " + author.AuLname);
            }
        }
        static void Main(string[] args)
        {

            SalesDetailsForTitle();
            Console.WriteLine("Hello, World!");
            Console.ReadKey();
        }
    }
}
