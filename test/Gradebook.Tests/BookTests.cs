using System;
using Xunit;

namespace Gradebook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // arrange
            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);
        }

        [Fact]
        public void BookAddsGradesInRange()
        {
            //Given
            var book = new InMemoryBook("");

            //When
            book.AddGrade(90.87);

            //Then
            Assert.Contains(90.87, book.Grades);
            Assert.DoesNotContain(100.99, book.Grades);
            Assert.Throws<ArgumentException>(() => book.AddGrade(-5));
            Assert.DoesNotContain(-5, book.Grades);
        }
    }
}
