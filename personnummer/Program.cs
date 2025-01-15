using System;

namespace PersonnummerKontroll
{
    class Program
    {
        static void Main(string[] args)
        {
            // Använd standardvärde om inget personnummer tillhandahålls
            string personalNumber = args.Length > 0 ? args[0] : "1234567850";

            // Kontrollera om programmet körs i interaktivt läge (t.ex., i en terminal)
            if (!Console.IsInputRedirected) // Interaktivt läge
            {
                personalNumber = GetPersonalNumber();
            }

            // Validera personnummer
            if (IsValidPersonalNumber(personalNumber))
            {
                Console.WriteLine($"Inmatat personnummer är giltigt: {personalNumber}");
            }
            else
            {
                Console.WriteLine($"Ogiltigt personnummer: {personalNumber}");
            }

            // Pausa programmet endast om det är en interaktiv terminal
            if (!Console.IsInputRedirected)
            {
                Console.WriteLine("Tryck på valfri tangent för att avsluta...");
                Console.ReadKey();
            }
        }

        static string GetPersonalNumber()
        {
            while (true)
            {
                Console.Write("Ange personnummer (format: ÅÅMMDD-XXXX eller ÅÅMMDDXXXX): ");
                string input = Console.ReadLine();

                if (IsValidFormat(input))
                {
                    return input.Replace("-", "");
                }

                Console.WriteLine("Fel: Personnumret måste anges i rätt format.");
            }
        }

        static bool IsValidFormat(string personalNumber)
        {
            personalNumber = personalNumber.Replace("-", "");

            // Kontrollera längd (10 siffror för personnummer)
            if (personalNumber.Length != 10)
            {
                return false;
            }

            // Kontrollera att alla tecken är siffror
            foreach (char c in personalNumber)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsValidPersonalNumber(string personalNumber)
        {
            personalNumber = personalNumber.Replace("-", "");

            // Luhn-algoritmen
            int sum = 0;
            bool isSecond = false;

            for (int i = personalNumber.Length - 1; i >= 0; i--)
            {
                int digit = personalNumber[i] - '0';

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
