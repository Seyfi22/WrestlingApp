using Moq;
using WrestlingApp.Domain.Entities;
using WrestlingApp.Application.Interfaces;

namespace WrestlingApp.Tests
{
    public class ClubRepositoryTests
    {
        [Fact]
        public async Task GenericRepository_GetById_ShouldReturnCorrectClub()
        {
            // --- 1. ARRANGE ---

            // Generic interfeysi "Club" tipi üçün Mock edirik
            var mockRepo = new Mock<IGenericRepository<Club>>();

            var fakeClub = new Club { Id = 1, Name = "Ganja Wrestling Club" };

            // MOQ-a deyirik: "Kimsə hər hansı bir ID ilə (It.IsAny<int>()) çağırdsa, bu klubu qaytar"
            // Əgər metodun asinxrondursa, .ReturnsAsync() istifadə edirik
            mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                    .ReturnsAsync(fakeClub);

            // --- 2. ACT ---

            // İndi o yalançı repo-dan 1 nömrəli klubu istəyirik
            var result = await mockRepo.Object.GetByIdAsync(1);

            // --- 3. ASSERT ---

            Assert.NotNull(result);
            Assert.Equal("Ganja Wrestling Club", result.Name);
            Assert.Equal(1, result.Id);
        }
    }
}