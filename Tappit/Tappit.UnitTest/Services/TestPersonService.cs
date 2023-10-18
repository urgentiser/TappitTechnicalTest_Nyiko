using Moq;
using Tappit.Domain;
using Tappit.Infrastructure.Repositories;
using Tappit.Application.Repositories;
using Tappit.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Tappit.Infrastructure.UnitTests
{
    public class TestPersonService
    {
        private readonly Mock<ApplicationDbContext> _mockContext;
        private readonly IPersonRepository _personRepository;

        public TestPersonService()
        {
            _mockContext = new Mock<ApplicationDbContext>();
            _personRepository = new PersonRepository(_mockContext.Object);
        }

        [Fact]
        public async Task CreatePersonAsync_ShouldCreateAPerson()
        {
            // Arrange
            var person = new Person
            {
                PersonId = 1,
                FirstName = "Nyiko",
                LastName = "Ngobeni",
                IsValid = true,
                IsEnabled = true,
                IsAuthorised = true,
                FavouriteSports = new List<FavouriteSport>
            {
            new FavouriteSport { SportId = 1, PersonId = 1 },
            new FavouriteSport { SportId = 2, PersonId = 2 }
        }
        };

            // Act
            var result = await _personRepository.CreatePersonAsync(person);

            // Assert
            Assert.True(result);

            // Verify that Add and SaveChanges were called on the context
            _mockContext.Verify(c => c.People.Add(person), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Fact]
        public async Task DeletePersonAsync_ShouldDeleteAPerson()
        {
            // Arrange
            var person = new Person
            {
                PersonId = 1,
                FirstName = "Nyiko",
                LastName = "Ngobeni",
                IsValid = true,
                IsEnabled = true,
                IsAuthorised = true,
                FavouriteSports = new List<FavouriteSport>
            {
            new FavouriteSport { SportId = 1, PersonId = 1 },
            new FavouriteSport { SportId = 2, PersonId = 2 }
        }
            };
            _mockContext.Setup(c => c.People.FindAsync(1)).ReturnsAsync(person);

            // Act
            var result = await _personRepository.DeletePersonAsync(person);

            // Assert
            Assert.True(result);

            _mockContext.Verify(c => c.People.Remove(person), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Fact]
        public async Task GetAllPersonAsync_ShouldReturnAllPersons()
        {
            // Arrange
            var people = new List<Person>
            {
                new Person {PersonId = 1, FirstName = "Urgent", LastName = "Ngobeni", IsValid = true, IsEnabled = true, IsAuthorised = true, FavouriteSports = new List < FavouriteSport > { new FavouriteSport { SportId = 1, PersonId = 1 }, new FavouriteSport { SportId = 2, PersonId = 2 } }},
                new Person { PersonId = 1, FirstName = "Nyiko", LastName = "Ngobeni", IsValid = true, IsEnabled = true, IsAuthorised = true, FavouriteSports = new List < FavouriteSport > { new FavouriteSport { SportId = 2, PersonId = 2 }, new FavouriteSport { SportId = 3, PersonId = 3 } }}
            };
            _mockContext.Setup(c => c.People.Include(c => c.FavouriteSports).ToList()).Returns(people);

            // Act
            var result = await _personRepository.GetAllPersonAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetPersonByIdAsync_ShouldReturnAPerson()
        {
            var person = new Person
            {
                PersonId = 1,
                FirstName = "Nyiko",
                LastName = "Ngobeni",
                IsValid = true,
                IsEnabled = true,
                IsAuthorised = true,
                FavouriteSports = new List<FavouriteSport>
            {
            new FavouriteSport { SportId = 1, PersonId = 1 },
            new FavouriteSport { SportId = 2, PersonId = 2 }
        }
            };
            _mockContext.Setup(c => c.People.Where(c => c.PersonId == 1).Include(c => c.FavouriteSports).FirstOrDefault()).Returns(person);

            // Act
            var result = await _personRepository.GetPersonByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.PersonId);
            Assert.Equal("Ngobeni", result.FirstName);
        }

        [Fact]
        public async Task UpdatePersonAsync_ShouldUpdateAPerson()
        {
            // Arrange
            var person = new Person
            {
                PersonId = 1,
                FirstName = "Nyiko",
                LastName = "Ngobeni",
                IsValid = true,
                IsEnabled = true,
                IsAuthorised = true,
                FavouriteSports = new List<FavouriteSport>
            {
            new FavouriteSport { SportId = 1, PersonId = 1 },
            new FavouriteSport { SportId = 2, PersonId = 2 }
        }
            };
            _mockContext.Setup(c => c.People.FindAsync(1)).ReturnsAsync(person);

            // Act
            person.FirstName = "Jane";
            var result = await _personRepository.UpdatePersonAsync(person);

            // Assert
            Assert.True(result);

            _mockContext.Verify(c => c.People.Update(person), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }
    }
}