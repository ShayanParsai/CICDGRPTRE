using System;

namespace PersonnummerKontroll
{
    class Program
    {
        static void Main(string[] args)
        {
            // Använd standardvärde om inget personnummer tillhandahålls
            string personnummer = args.Length > 0 ? args[0] : "1234567850";

            // Interaktiv sektion för validering av personnummer
            while (true)
            {
                Console.Write("Ange ett svenskt personnummer (ÅÅMMDD-XXXX): ");
                string input = Console.ReadLine();

                // Validera format
                if (!IsValidFormat(input))
                {
                    Console.WriteLine("Fel: Personnumret måste anges i formatet ÅÅMMDD-XXXX eller ÅÅMMDDXXXX.");
                    continue;
                }

                // Kontrollera om giltigt personnummer
                if (!IsValidPersonnummer(input))
                {
                    Console.WriteLine("Fel: Det angivna personnumret är ogiltigt.");
                    Console.Write("Vill du försöka igen? (ja/nej): ");
                    string retry = Console.ReadLine().ToLower();
                    if (retry != "ja") break;
                    continue;
                }

                Console.WriteLine("Personnumret är giltigt! Tack för att du använde vår tjänst.");
                break;
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

        static bool IsValidFormat(string personnummer)
        {
            // Ta bort bindestreck för att göra kontrollen flexibel
            personnummer = personnummer.Replace("-", "");

            // Kontrollera längd (10 siffror för personnummer)
            if (personnummer.Length != 10)
            {
                return false;
            }

            // Kontrollera att alla tecken är siffror
            foreach (char c in personnummer)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsValidPersonnummer(string personnummer)
        {
            personnummer = personnummer.Replace("-", "");

            // Luhn-algoritmen
            int sum = 0;
            bool isSecond = false;

            for (int i = personnummer.Length - 1; i >= 0; i--)
            {
                int digit = personnummer[i] - '0';

                if (isSecond)
                {
                    digit *= 2;
                    if (digit > 9)
                    {
                        digit -= 9;
                    }
                }

                sum += digit;
                isSecond = !isSecond;
            }

            return (sum % 10 == 0);
        }
    }
}
d