namespace GalaxyExpressJacobHaytam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef je naam: ");
            string namePassenger = Console.ReadLine()!;

            Console.Write("Geef je bestemming: ");
            string destination = Console.ReadLine()!;

            Console.Write("Geef je vertrekdatum (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime parsedDate))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ongeldige datum, probeer opnieuw!");
                Console.ResetColor();

                return;
            }

            Console.Write("Geef het gewicht van de bagage in kg: ");
            if (!int.TryParse(Console.ReadLine(), out int weightInKg))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ongeldig gewicht, probeer opnieuw!");
                Console.ResetColor();

                return;
            }

            Console.WriteLine("================================");
            Console.WriteLine("        GALACTIC EXPRESS        ");
            Console.WriteLine("          BOARDING PASS         ");
            Console.WriteLine("================================");
        }
    }
}
