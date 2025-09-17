// See https://aka.ms/new-console-template for more information
using System.Text.Json;

namespace ToDoApp
{
    internal class Program
    {
        public List<Table> table = [];
        public static bool cycle = true;
        public static string filepath = "C:\\Projects\\C#\\Übungen\\ToDoApp\\table.json";
        public static void Main(string[] args)
        {
            var app = new Program();
            string winDir = System.Environment.CurrentDirectory;
            string filename = "\\table.json";
            
            Console.WriteLine("Exercise 2.1: To-Do App");

            //app.ReadTable();
            app.ReadTableFile(filepath);

            while (cycle)
            {
                cycle = app.AddTasks();
            }
            app.ReadTableFile(filepath);
        }

        public void ReadTable()
        {
            Console.WriteLine("TODO Table");
            try
            {
                if (table.Count == 0) { throw new ArgumentNullException(); }
                foreach (var item in table)
                {
                    Console.WriteLine($"Task: {item.Description} | {item.State}");
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("-");
            }
            catch (Exception)
            {
                throw;
            }
            Console.WriteLine("==========");
        }

        public void ReadTableFile(string path)
        {
            Console.WriteLine("TODO Table");
            try
            {
                List<Table> table = JsonSerializer.Deserialize<List<Table>>(File.ReadAllText(path));
                if (table.Count == 0) { throw new ArgumentNullException(); }
                foreach (var item in table)
                {
                    Console.WriteLine($"Task: {item.Description} | {item.State}");
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("-");
            }
            catch (JsonException)
            {
                Console.WriteLine("-");
            }
            catch (Exception)
            {
                throw;
            }
            Console.WriteLine("==========");
        }

        public bool AddTasks()
        {
            string jsonString;
            string value = Console.ReadLine();
            if ("stop" == value)
                return false;

            try
            {
                string[] input = value.Split('-');
                table.Add(
                    new Table
                    {
                        Description = input[0],
                        State = input[1]
                    }
                );
                jsonString = JsonSerializer.Serialize(table);
                File.WriteAllText(filepath, jsonString);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public class Table
    {
        public string Description { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
    }
}
