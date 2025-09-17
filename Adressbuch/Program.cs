// See https://aka.ms/new-console-template for more information
using Adressbuch;
using System.Text.Json;

namespace AdressBuch
{
    internal class Program
    {
        private static List<Person>? PersonaList { get; set; }
        public static void Main(string[] args)
        {
            var app = new Program();
            Console.WriteLine("Exercise 2.0: Adressbuch");

            PersonaList = app.CreateNewPersona();
            string jsonString = JsonSerializer.Serialize(PersonaList);
            Console.WriteLine(jsonString);
            List<Person> obj = JsonSerializer.Deserialize<List<Person>>(jsonString);

            //{"Name":"Max Mustermann","Telefon":"\u002B49 170 1234567","EMail":"max.mustermann@example.com"}
            foreach (var item in obj)
            {
                Console.WriteLine($"Name: {item.Name}; Telefon: {item.Telefon}; E-Mail: {item.EMail}");
            }
        }

        private List<Person> CreateNewPersona()
        {
            List<Person> list =
            [
                    new Person
                    {
                        Name = "Max Mustermann",
                        Telefon = "+49 170 1234567",
                        EMail = "max.mustermann@example.com"
                    },
                    new Person
                    {
                        Name = "Anna Müller",
                        Telefon = "+49 170 9876543",
                        EMail = "anna.mueller@example.com"
                    },
                    new Person
                    {
                        Name = "John Doe",
                        Telefon = "+1 555 123 4567",
                        EMail = "john.doe@example.com"
                    }
            ];
            return list;
        }
    }
}
