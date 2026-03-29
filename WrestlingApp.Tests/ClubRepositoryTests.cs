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
            var mockRepo = new Mock<IGenericRepository<Club>>();

            var fakeClub = new Club { Id = 1, Name = "Ganja Wrestling Club" };

            mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                    .ReturnsAsync(fakeClub);

            var result = await mockRepo.Object.GetByIdAsync(1);


            Assert.NotNull(result);
            Assert.Equal("Ganja Wrestling Club", result.Name);
            Assert.Equal(1, result.Id);
        }
    }
}