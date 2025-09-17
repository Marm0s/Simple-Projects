// See https://aka.ms/new-console-template for more information
/*
* Key lesen und mit einem switch die function auswählen, werte vermitteln und berechnnen
* Vordefiniertes Stringformat (A, Operatoren, B), den input mit regex aufteilen und dann einordnen als: A, Operatoren, B
* Einfachste (Simpleste) Methode: Operator abfragen und die Werte abfragen und dann berechnen
* 
*/
namespace Taschenrechner
{
    internal class Program
    {


        public static void Main(string[] args)
        {
            var app = new Program();
            
            Console.WriteLine("Exercise 1.0: Calculator");

            Console.WriteLine("Output: " + app.EinfachsteMethode1());
            Console.WriteLine("Output: " + app.Methode2());
            //Console.WriteLine("Output: " + app.Methode3()); -- unnötig für den Wiedereinstieg


        }

        public string EinfachsteMethode1()
        {
            Console.WriteLine("  - Einfachste Methode 1");

            Console.WriteLine("Choose your Operator: ");
            string choose = Console.ReadLine();

            Console.WriteLine("Choose your Num1: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Choose your Num2: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            double result;

            try
            {
                result = choose switch
                {
                    "+" => num1 + num2,
                    "-" => num1 - num2,
                    "*" => num1 * num2,
                    "/" => num2 != 0 ? num1 / num2 : throw new DivideByZeroException(),

                    _ => throw new InvalidOperationException("Invalid operation")
                };
            }
            catch (DivideByZeroException)
            {
                return "0";
            }
            catch (Exception)
            {
                throw;
            }

            return result.ToString();
        }

        public string Methode2()
        {
            Console.WriteLine("  - Methode 2");

            Console.WriteLine("Calculate: ");
            string choose = Console.ReadLine();

            string[] values = choose.Split(" ");

            double num1 = Convert.ToDouble(values[0]), num2 = Convert.ToDouble(values[2]);
            double result;

            try
            {
                result = values[1] switch
                {
                    "+" => num1 + num2,
                    "-" => num1 - num2,
                    "*" => num1 * num2,
                    "/" => num2 != 0 ? num1 / num2 : throw new DivideByZeroException(),

                    _ => throw new InvalidOperationException("Invalid operation")
                };
            }
            catch (DivideByZeroException)
            {
                return "0";
            }
            catch (Exception)
            {
                throw;
            }
            return result.ToString();
        }

        public string Methode3()
        {
            Console.WriteLine("  - Methode 3");

            Console.WriteLine("Choose your Operator: ");
            string choose = Console.ReadLine();

            double result = 2;




            return result.ToString();
        }
    }
}





