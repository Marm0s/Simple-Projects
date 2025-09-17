// See https://aka.ms/new-console-template for more information
namespace Taschenrechner
{
    internal class Program
    {
        private static List<string> Notebook = ["Hello World","Name of something", "Bless you!"];

        public static void Main(string[] args)
        {
            var app = new Program();
            Console.WriteLine("Exercise 1.1: Notebook");

            Console.WriteLine("Please choose between: 'read', 'write', 'delete'");

            string feature = Console.ReadLine();

            Console.WriteLine($"You selected: {feature} as your current {nameof(feature)}");
            switch (feature)
            {
                case "read":
                    app.ReadFeature();
                    break;
                case "write":
                    app.WriteFeature();
                    Console.WriteLine("Current notes: ");
                    foreach (var item in Notebook)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("===========");
                    break;
                case "delete":
                    Console.WriteLine("Which Note should be deleted?");
                    Console.WriteLine("Current notes: ");
                    foreach (var item in Notebook)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("===========");
                    app.DeleteFeature(Console.ReadLine());
                    foreach (var item in Notebook)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("===========");
                    break;
                default:
                    break;
            }
        }

        public void ReadFeature()
        {
            
            foreach (var item in Notebook)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("===========");
        }

        public void WriteFeature()
        {

            string input = Console.ReadLine();
            Notebook.Add(input);
            Console.WriteLine("===========");
        }

        public void DeleteFeature(string name)
        {
            Notebook.Remove(name);
            Console.WriteLine("===========");
        }
    }
}