using Microsoft.VisualBasic;
using System.Net.NetworkInformation;
using System.Text;

namespace GalaxyExpressJacobHaytam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;//valuta

            decimal basePrice = 89.95M;
            decimal baggageKilo = 1.75M;

            Console.Write("Geef je naam: ");
            string namePassenger = Console.ReadLine()!;

            Console.Write("Geef je bestemming: ");
            string destination = Console.ReadLine()!;

            Console.Write("Geef je vertrekdatum (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime departureDate))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ongeldige datum, probeer opnieuw!");
                Console.ResetColor();

                return;
            }

            TimeSpan daysToTravel = departureDate - DateTime.Today;// Aantal dagen voor vertrek
            double daysToTravelDbl = daysToTravel.TotalDays;
            if (daysToTravelDbl < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Datum ligt in het verleden. Probeer opnieuw.");
                Console.ResetColor();
            }

            Console.Write("Geef het gewicht van de bagage in kg: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal weightInKg))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ongeldig gewicht, probeer opnieuw!");
                Console.ResetColor();

                return;
            }

            DayOfWeek dayOfWeek = departureDate.DayOfWeek;// Dag van de week 

            //Console.WriteLine(daysToTravel.TotalDays + " days left to departure on " + dayOfWeek);//Dagen printen

            if (daysToTravelDbl < 7)
            {
                basePrice += 12.5m;
            }

            decimal baggageCost = weightInKg * baggageKilo;// Kost van  de bagage
            decimal finalCost = baggageCost + basePrice; // Totale kost van de ticket

            Random random = new Random();

            int gateNumber = random.Next(1, 13);
            int rowNumber = random.Next(1, 31);
            int chairNumber = random.Next(1, 7);
            int controleCode = random.Next(1000, 10000);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Reiziger       : {namePassenger}");
            sb.AppendLine($"Bestemming     : {destination}");
            sb.AppendLine($"Code:          : {namePassenger.Substring(0,3).ToUpper()}");
            sb.AppendLine($"Vertrekdatum   : {departureDate:d}");
            sb.AppendLine($"Vertrekdag     : {daysToTravel.TotalDays}");
            sb.AppendLine();
            sb.AppendLine($"Gate           : {gateNumber}");
            sb.AppendLine($"Stoel          : Rij {rowNumber} - Stoel {chairNumber}");
            sb.AppendLine($"Controlecode   : {controleCode}");
            sb.AppendLine();
            sb.AppendLine($"Bagage         : {weightInKg} kg");
            sb.AppendLine($"Totale Prijs   : {finalCost:c}");
            sb.AppendLine($"Boekingscode   : {namePassenger.Replace(" ", "-")}");
            sb.AppendLine();
            sb.AppendLine($"Retourdatum    : {departureDate.AddDays(7):d}");

            string output = sb.ToString();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("================================");
            Console.WriteLine("        GALACTIC EXPRESS        ");
            Console.WriteLine("          BOARDING PASS         ");
            Console.WriteLine("================================");
            Console.WriteLine(output);
            Console.WriteLine("================================");
            Console.ResetColor();


        }
    }
}
