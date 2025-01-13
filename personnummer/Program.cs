using System;

namespace PersonnummerKontroll
{
    class Program
    {
        static void Main(string[] args)
        {
            // Använd standardvärde om inget personnummer tillhandahålls
            string personnummer = args.Length > 0 ? args[0] : "1234567890";

            // Kontrollera om programmet körs i interaktivt läge (t.ex., i en terminal)
            if (Console.IsInputRedirected == false) // Interaktivt läge
            {
                // Be användaren ange ett personnummer
                personnummer = TaEmotPersonnummer();
            }

            // Visa det validerade personnumret
            if (ValideraPersonnummer(personnummer))
            {
                Console.WriteLine($"Inmatat personnummer är giltigt: {personnummer}");
            }
            else
            {
                Console.WriteLine($"Ogiltigt personnummer: {personnummer}");
            }

            // Pausa programmet endast om det är en interaktiv terminal
            if (Console.IsInputRedirected == false)
            {
                Console.WriteLine("Tryck på valfri tangent för att avsluta...");
                Console.ReadKey();
            }
        }

        static string TaEmotPersonnummer()
        {
            string personnummer = "";
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
            return personnummer.Replace("-", "");
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
            foreach (char c in personnummer)
            {
                if (!char.IsDigit(c)) // Kontrollera om tecknet är en siffra
                {
                    return false;
                }
            }

            return true;
        }
    }
}