using System;

namespace PersonnummerKontroll
{
    class Program
    {
        static void Main(string[] args)
        {
            // Använd standardvärde om inget personnummer tillhandahålls
            string personalIdentityNumber = args.Length > 0 ? args[0] : "1234567890";

            // Kontrollera om programmet körs i interaktivt läge (t.ex., i en terminal)
            if (Console.IsInputRedirected == false) // Interaktivt läge
            {
                // Be användaren ange ett personnummer
                personalIdentityNumber = ReceivePersonalIdentityNumber();
            }

            // Visa det validerade personnumret
            if (ValidatePersonalIdentityNumber(personalIdentityNumber))
            {
                Console.WriteLine($"The entered personal identity number is valid: {personalIdentityNumber}");
            }
            else
            {
                Console.WriteLine($"Invalid personal identity number: {personalIdentityNumber}");
            }

            // Pausa programmet endast om det är en interaktiv terminal
            if (Console.IsInputRedirected == false)
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        static string ReceivePersonalIdentityNumber()
        {
            string personalIdentityNumber = "";
            bool isValid = false;

            while (!isValid)
            {
                Console.Write("Enter personal identity number (format: xxxxxxxxxx or xxxxxxx-xxxx): ");
                personalIdentityNumber = Console.ReadLine(); // Tilldela värdet inuti loopen

                // Kontrollera om personnumret är giltigt
                isValid = ValidatePersonalIdentityNumber(personalIdentityNumber);

                if (!isValid)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }

            // Returnera det validerade personnumret utan bindestreck
            return personalIdentityNumber.Replace("-", "");
        }

        static bool ValidatePersonalIdentityNumber(string personalIdentityNumber)
        {
            // Ta bort bindestreck om det finns
            personalIdentityNumber = personalIdentityNumber.Replace("-", "");

            // Kontrollera om personnumret har exakt 10 eller 12 siffror
            if (personalIdentityNumber.Length != 10 && personalIdentityNumber.Length != 12)
            {
                return false;
            }

            // Kontrollera att alla tecken är siffror
            foreach (char c in personalIdentityNumber)
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
