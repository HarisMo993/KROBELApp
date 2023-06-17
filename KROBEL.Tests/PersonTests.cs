using KROBEL.Domain.Models;

namespace KROBEL.Tests
{
    public class PersonTests
    {
        [Fact]
        public void CreatePerson_ValidData_PersonCreated()
        {
            // Arrange
            var personData = new Person
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(1990, 1, 1),
                PhoneNumber = "123456789",
                Email = "john.doe@example.com",
                Gender = "Male"
            };

            // Act
            var person = new Person
            {
                FirstName = personData.FirstName,
                LastName = personData.LastName,
                BirthDate = personData.BirthDate,
                PhoneNumber = personData.PhoneNumber,
                Email = personData.Email,
                Gender = personData.Gender
            };

            // Assert
            Assert.Equal(personData.FirstName, person.FirstName);
            Assert.Equal(personData.LastName, person.LastName);
            Assert.Equal(personData.BirthDate, person.BirthDate);
            Assert.Equal(personData.PhoneNumber, person.PhoneNumber);
            Assert.Equal(personData.Email, person.Email);
            Assert.Equal(personData.Gender, person.Gender);
        }

        [Fact]
        public void UpdatePerson_ValidData_PersonUpdated()
        {
            // Arrange
            var person = new Person
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(1990, 1, 1),
                PhoneNumber = "123456789",
                Email = "john.doe@example.com",
                Gender = "Male"
            };

            // Act
            person.FirstName = "Jane";
            person.LastName = "Smith";

            // Assert
            Assert.Equal("Jane", person.FirstName);
            Assert.Equal("Smith", person.LastName);
        }

        [Fact]
        public void DeletePerson_PersonDeleted()
        {
            // Arrange
            var person = new Person
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(1990, 1, 1),
                PhoneNumber = "123456789",
                Email = "john.doe@example.com",
                Gender = "Male"
            };

            // Act
            person.IsActive = false;

            // Assert
            Assert.False(person.IsActive);
        }
    }
}