// See https://aka.ms/new-console-template for more information
namespace Mini_Bibliothek
{
    internal class Program
    {
        private static List<Bibliothek> Bibliothek = [
            new Bibliothek{
                Title = "Noah",
                Description = "A Book from Noah"
            },
            new Bibliothek{
                Title = "New Adventure",
                Description = "A Book of Stories"
            }
            ];
        public static void Main(string[] args)
        {
            var app = new Program();

            Console.WriteLine("Exercise 3.1: Mini-BiblioThek");
            app.ShowBibliothek();
            Console.WriteLine("=============");

            Console.WriteLine("Choose between add, search, delete");
            string feature = Console.ReadLine();

            switch (feature)
            {
                case "add":
                    Console.WriteLine("Write the book you want to add.");
                    app.Add();
                    Console.WriteLine("=============");
                    break;
                case "search":
                    Console.WriteLine("Please type the title you want to find.");
                    app.Search(Console.ReadLine());
                    Console.WriteLine("=============");
                    break;
                case "delete":
                    Console.WriteLine("Which title should be removed?");
                    app.Delete(Console.ReadLine());
                    Console.WriteLine("=============");
                    break;
                default:
                    break;
            }
            app.ShowBibliothek();
        }

        public void ShowBibliothek()
        {
            int i = 0;
            foreach (var item in Bibliothek)
            {
                Console.WriteLine($"[{i}]Book: {item.Title}; {item.Description} ");
                i++;
            }
        }

        public void Add()
        {
            bool cycle = true;

            while (cycle)
            {
                string value = Console.ReadLine();
                if ("stop" == value)
                {
                    cycle = false;
                }
                else
                {
                    try
                    {
                        string[] input = value.Split(": ");
                        Bibliothek.Add(
                            new Bibliothek
                            {
                                Title = input[0],
                                Description = input[1],
                            });
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error");
                        throw;
                    }
                }
            }
        }

        public void Search(string searchString)
        {
            IEnumerable<Bibliothek> bibliothekQuery =
                from book in Bibliothek
                where book.Title == searchString
                select book;

            try
            {
                foreach (var item in bibliothekQuery)
                {
                    Console.WriteLine($"Found Book: {item.Title}; {item.Description} ");
                }

                if (bibliothekQuery.GetEnumerator().Current == null)
                    throw new ArgumentNullException();
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Book was not found!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(string searchString)
        {
            IEnumerable<Bibliothek> bibliothekQuery =
                from book in Bibliothek
                where book.Title == searchString
                select book;

            int count = (
                 from book in Bibliothek
                 where book.Title == searchString
                 select book).Count();

            try
            {
                if (count == 0)
                    throw new ArgumentNullException();

                Bibliothek.RemoveAll(b => b.Title == searchString);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Book was not found!");
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

    public class Bibliothek
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}

