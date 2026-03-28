using Moq;
using WrestlingApp.Domain.Entities;
using WrestlingApp.Application.Interfaces;
using Xunit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WrestlingApp.WebApi.Controllers;

namespace WrestlingApp.Tests
{
    public class ClubsControllerTests
    {
        [Fact]
        public async Task GetById_ReturnsOkResult_WhenClubExists()
        {
            // --- 1. ARRANGE ---
            var mockRepo = new Mock<IGenericRepository<Club>>();
            var fakeClub = new Club { Id = 1, Name = "Sumgayit Wrestling Club" };

            // Reponu aldadırıq: "1 nömrəli ID istənsə, bu klubu qaytar"
            mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(fakeClub);

            // Controller-i yaradırıq və ona saxta repo-nu veririk (Dependency Injection)
            var controller = new ClubController(mockRepo.Object);

            // --- 2. ACT ---
            var result = await controller.GetById(1); // Sənin metodunun adı fərqli ola bilər

            // --- 3. ASSERT ---
            // Yoxlayırıq ki, nəticə "OkObjectResult" (Status 200) tipindədirmi?
            var okResult = Assert.IsType<OkObjectResult>(result);

            // İçindəki datanın bizim gözlədiyimiz klub olub-olmadığını yoxlayırıq
            var returnedClub = Assert.IsType<Club>(okResult.Value);
            Assert.Equal("Sumgayit Wrestling Club", returnedClub.Name);
        }
    }
}