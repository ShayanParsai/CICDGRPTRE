using System;
using System.Text.RegularExpressions;

namespace PersonnummerKontroll
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ta emot och validera personnummer från användaren
            string personnummer = TaEmotPersonnummer();

            // Visa det validerade personnumret
            Console.WriteLine($"Inmatat personnummer: {personnummer}");
        }

        static string TaEmotPersonnummer()
        {
            string personnummer = ""; // Deklarera personnummer här
            bool ärGiltigt = false;

            while (!ärGiltigt)
            {
                Console.Write("Ange personnummer (format: xxxxxxxxxx eller xxxxxxx-xxxx): ");
                personnummer = Console.ReadLine(); // Tilldela värdet inuti loopen

                // Kontrollera om personnumret är giltigt
                ärGiltigt = ValideraPersonnummer(personnummer);

                if (!ärGiltigt)
                {
                    Console.WriteLine("Felaktig inmatning. Försök igen.");
                }
            }

            // Returnera det validerade personnumret utan bindestreck
            return personnummer.Replace("-", ""); // Nu är personnummer tillgänglig här
        }


        static bool ValideraPersonnummer(string personnummer)
        {
            // Ta bort bindestreck om det finns
            personnummer = personnummer.Replace("-", "");

            // Kontrollera om personnumret har exakt 10 eller 12 siffror
            if (personnummer.Length != 10 && personnummer.Length != 12)
            {
                return false;
            }

            // Kontrollera att alla tecken är siffror
            if (!Regex.IsMatch(personnummer, @"^\d+$"))
            {
                return false;
            }

            return true;
        }
    }
}