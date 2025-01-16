using Xunit;
using PersonnummerKontroll;  // Se till att importera rätt namespace

namespace Personnummer.Tests
{
    public class PersonalNumberTests
    {
        [Fact]
        public void TestValidPersonalNumber()
        {
            // Arrange
            var validPersonalNumber = "1234567890"; // Ett giltigt personnummer

            // Act
            var result = Program.IsValidPersonalNumber(validPersonalNumber, out var validationMessage);

            // Assert
            Assert.True(result, "Personnumret ska vara giltigt.");
            Assert.Empty(validationMessage); // Ingen felmeddelande bör returneras
        }

        [Fact]
        public void TestInvalidPersonalNumberTooShort()
        {
            // Arrange
            var invalidPersonalNumber = "12345"; // Ogiltigt personnummer, för kort

            // Act
            var result = Program.IsValidPersonalNumber(invalidPersonalNumber, out var validationMessage);

            // Assert
            Assert.False(result, "Personnumret ska vara ogiltigt om det inte är exakt 10 siffror långt.");
            Assert.Equal("Personnumret måste vara exakt 10 siffror långt.", validationMessage);
        }

        [Fact]
        public void TestInvalidPersonalNumberWrongFormat()
        {
            // Arrange
            var invalidPersonalNumber = "1234ABCD90"; // Ogiltigt personnummer, innehåller bokstäver

            // Act
            var result = Program.IsValidPersonalNumber(invalidPersonalNumber, out var validationMessage);

            // Assert
            Assert.False(result, "Personnumret ska vara ogiltigt om det innehåller icke-siffriga tecken.");
            Assert.Equal("Personnumret måste vara exakt 10 siffror långt.", validationMessage); // Eller liknande felmeddelande
        }

        [Fact]
        public void TestValidPersonalNumberWithLuhnAlgorithm()
        {
            // Arrange
            var validPersonalNumber = "4405147890"; // Ett personnummer som är korrekt enligt Luhn-algoritmen

            // Act
            var result = Program.IsValidPersonalNumber(validPersonalNumber, out var validationMessage);

            // Assert
            Assert.True(result, "Personnumret ska vara giltigt om det uppfyller Luhn-algoritmen.");
            Assert.Empty(validationMessage);
        }

        [Fact]
        public void TestInvalidPersonalNumberWithLuhnAlgorithm()
        {
            // Arrange
            var invalidPersonalNumber = "4405147891"; // Ett personnummer som inte är korrekt enligt Luhn-algoritmen

            // Act
            var result = Program.IsValidPersonalNumber(invalidPersonalNumber, out var validationMessage);

            // Assert
            Assert.False(result, "Personnumret ska vara ogiltigt om det inte följer Luhn-algoritmen.");
            Assert.Equal("Personnumret följer inte Luhn-algoritmen och är ogiltigt.", validationMessage);
        }
    }
}
