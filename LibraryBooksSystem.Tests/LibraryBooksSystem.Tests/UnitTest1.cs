using Xunit;
using LibraryBooksSystem.Services;
using LibraryBooksSystem.Models;
using System.Collections.Generic;

namespace LibraryBooksSystem.Tests
{
    public class UnitTest1
    {
        // Test 1: IsValidId
        [Theory]
        [InlineData(1, true)]
        [InlineData(10, true)]
        [InlineData(0, false)]
        [InlineData(-5, false)]
        public void IsValidId_ReturnsExpectedResult(
            int id, bool expected)
        {
            var service = new ValidationService();

            bool result = service.IsValidId(id);

            Assert.Equal(expected, result);
        }

        // Test 2: IsValidText
        [Theory]
        [InlineData("Hello", true)]
        [InlineData("Book Title", true)]
        [InlineData("", false)]
        [InlineData("   ", false)]
        [InlineData(null, false)]
        public void IsValidText_ReturnsExpectedResult(
            string? text, bool expected)
        {
            var service = new ValidationService();

            bool result = service.IsValidText(text);

            Assert.Equal(expected, result);
        }

        // Test 3: TryReadInt
        [Theory]
        [InlineData("123", true, 123)]
        [InlineData("0", true, 0)]
        [InlineData("-5", true, -5)]
        [InlineData("abc", false, 0)]
        [InlineData("", false, 0)]
        [InlineData(null, false, 0)]
        public void TryReadInt_ReturnsExpectedResult(
            string? input, bool expectedSuccess, int expectedValue)
        {
            var service = new ValidationService();

            bool result = service.TryReadInt(input, out int value);

            Assert.Equal(expectedSuccess, result);
            Assert.Equal(expectedValue, value);
        }

        // Test 4: IsDuplicateId
        [Fact]
        public void IsDuplicateId_ReturnsTrue_WhenIdExists()
        {
            var service = new ValidationService();

            var books = new List<Book>
            {
                new Book { Id = 1 },
                new Book { Id = 2 }
            };

            bool result = service.IsDuplicateId(books, 1);

            Assert.True(result);
        }

        [Fact]
        public void IsDuplicateId_ReturnsFalse_WhenIdDoesNotExist()
        {
            var service = new ValidationService();

            var books = new List<Book>
            {
                new Book { Id = 1 },
                new Book { Id = 2 }
            };

            bool result = service.IsDuplicateId(books, 3);

            Assert.False(result);
        }
    }
}