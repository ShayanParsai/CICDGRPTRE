using System;
using Xunit;
using PersonnummerKontroll;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace PersonnummerKontroll.Tests
{
    public class PersonnummerTests
    {
        [Fact]
        public void IsValidFormat_CorrectFormat_ReturnsTrue()
        {
            
            string validPersonalNumber = "199001011234";

            
            bool result = Program.IsValidFormat(validPersonalNumber);

            Assert.True(result);
        }

        [Fact]
        public void IsValidFormat_IncorrectFormat_ReturnsFalse()
        {
            string invalidPersonalNumber = "19990802-82I5";

            bool result = Program.IsValidFormat(invalidPersonalNumber);

            Assert.False(result);
        }

        [Fact]
        public void IsValidPersonalNumber_ValidNumber_ReturnsTrue()
        {
            
            string validPersonalNumber = "199505058978";
            string validationMessage;

            
            bool result = Program.IsValidPersonalNumber(validPersonalNumber, out validationMessage);

            
            Assert.True(result);
            Assert.Equal(string.Empty, validationMessage);
        }

        [Fact]
        public void IsValidPersonalNumber_InvalidNumber_ReturnsFalse()
        {
            
            string invalidPersonalNumber = "200202014737";
            string validationMessage;

            
            bool result = Program.IsValidPersonalNumber(invalidPersonalNumber, out validationMessage);

            
            Assert.False(result);
            Assert.Equal("Personnumret följer inte Luhn-algoritmen och är ogiltigt.", validationMessage);
        }

        [Theory]
        [InlineData("198701011234", true)] // Giltigt personnummer
        [InlineData("200002299876", true)] // Giltigt skottårsdatum
        [InlineData("19870101-1234", true)] // Giltigt med bindestreck
        [InlineData("199912319876", true)] // Sista dagen på året
        [InlineData("190001011234", false)] // För gammalt för att vara giltigt
        [InlineData("1234567890", false)]   // Ogiltigt format
        public void IsValidPersonalNumber_MultipleCases_ReturnsExpected(string personalNumber, bool expectedResult)
        {
            string validationMessage;

            bool result = Program.IsValidPersonalNumber(personalNumber, out validationMessage);

            Assert.Equal(expectedResult, result);
        }
    }
}
