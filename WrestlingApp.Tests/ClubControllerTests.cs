using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using WrestlingApp.Application.Interfaces;
using WrestlingApp.Domain.Entities;
using WrestlingApp.WebApi.Controllers;
using Xunit;

namespace WrestlingApp.Tests
{
    public class ClubsControllerTests
    {
        [Fact]
        public async Task GetById_ReturnsOkResult_WhenClubExists()
        {
            var mockRepo = new Mock<IGenericRepository<Club>>();

            var mockCache = new Mock<IMemoryCache>();

            var fakeClub = new Club { Id = 1, Name = "Sumgayit Wrestling Club" };

            mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(fakeClub);

            var controller = new ClubController(mockRepo.Object, mockCache.Object);

            var result = await controller.GetById(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(fakeClub, okResult.Value);
        }
    }
}