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
            if (IsValidPersonalNumber(personalNumber, out string validationMessage))
            {
                Console.WriteLine($"Inmatat personnummer är giltigt: {personalNumber}");
            }
            else
            {
                // Visa detaljerad feedback om varför personnumret är ogiltigt
                Console.WriteLine($"Ogiltigt personnummer: {validationMessage}");
            }

            // Pausa programmet endast om det är en interaktiv terminal
            if (!Console.IsInputRedirected)
            {
                Console.WriteLine("Tryck på valfri tangent för att avsluta...");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Frågar användaren att ange ett personnummer, tills ett giltigt format anges.
        /// </summary>
        static string GetPersonalNumber()
        {
            while (true)
            {
                Console.Write("Ange personnummer (format: ÅÅMMDD-XXXX eller ÅÅMMDDXXXX): ");
                string input = Console.ReadLine();

                // Om formatet är korrekt, returnera det utan bindestreck
                if (IsValidFormat(input))
                {
                    return input.Replace("-", "");
                }

                // Om formatet inte är korrekt, ge feedback
                Console.WriteLine("Fel: Personnumret måste anges i rätt format.");
            }
        }

        /// <summary>
        /// Kontrollera om personnumret har rätt format (10 siffror, med eller utan bindestreck).
        /// </summary>
        static bool IsValidFormat(string personalNumber)
        {
            // Ta bort eventuella bindestreck
            personalNumber = personalNumber.Replace("-", "");

            // Kontrollera om längden är exakt 10 siffror
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

        /// <summary>
        /// Validera personnumret med Luhn-algoritmen och ge mer detaljerad feedback om varför det är ogiltigt.
        /// </summary>
        static bool IsValidPersonalNumber(string personalNumber, out string validationMessage)
        {
            personalNumber = personalNumber.Replace("-", "");

            // Kontrollera om personnumret har rätt längd
            if (personalNumber.Length != 10)
            {
                validationMessage = "Personnumret måste vara exakt 10 siffror långt.";
                return false;
            }

            // Luhn-algoritmen för att kontrollera om personnumret är korrekt
            int sum = 0;
            bool isSecond = false;

            for (int i = personalNumber.Length - 1; i >= 0; i--)
            {
                int digit = personalNumber[i] - '0';

                // Dubblar vartannat tal och subtraherar 9 om resultatet är större än 9
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

            // Om summan är delbar med 10 är personnumret giltigt
            if (sum % 10 != 0)
            {
                validationMessage = "Personnumret följer inte Luhn-algoritmen och är ogiltigt.";
                return false;
            }

            // Om alla kontroller passerade, är personnumret giltigt
            validationMessage = "";
            return true;
        }
    }
}
