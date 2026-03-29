using Bogus;
using Microsoft.EntityFrameworkCore;
using WrestlingApp.Domain.Entities;
using WrestlingApp.Infrastructure.Data;
using WrestlingApp.Infrastructure.Repositories;
using Xunit.Abstractions;

namespace WrestlingApp.Tests.Infrastructure.Repositories
{
    public class GenericRepositoryTests
    {
        private readonly ITestOutputHelper _output;

        public GenericRepositoryTests(ITestOutputHelper output)
        {
            _output = output;
        }

        private WrestlingAppDbContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<WrestlingAppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new WrestlingAppDbContext(options);
            databaseContext.Database.EnsureCreated();
            return databaseContext;
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnEntity_WhenIdExists()
        {
            var context = GetDatabaseContext();
            var repository = new GenericRepository<Club>(context);

            var testClub = new Club { Id = 10, Name = "Sumqayıt Klubu", Address = "Sumqayıt, Pasyolka" };
            context.Set<Club>().Add(testClub);
            await context.SaveChangesAsync();

            var result = await repository.GetByIdAsync(10);

            Assert.NotNull(result);
            Assert.Equal("Sumqayıt Klubu", result.Name);
            Assert.Equal("Sumqayıt, Pasyolka", result.Address);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllEntities()
        {
            var context = GetDatabaseContext();
            var repository = new GenericRepository<Club>(context);

            context.Set<Club>().AddRange(new List<Club>
            {
                new Club { Id = 1, Name = "Klub A", Address = "Ünvan A" },
                new Club { Id = 2, Name = "Klub B", Address = "Ünvan B" }
            });
            await context.SaveChangesAsync();

            var result = await repository.GetAllAsync();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetAllAsync_WithBogus_ShouldReturnAll()
        {
            var context = GetDatabaseContext();
            var repository = new GenericRepository<Club>(context);

            var clubFaker = new Faker<Club>()
                .RuleFor(c => c.Id, f => f.IndexFaker + 1)
                .RuleFor(c => c.Name, f => f.Company.CompanyName() + " Wrestling Club")
                .RuleFor(c => c.Address, f => f.Address.FullAddress());

            var fakeClubs = clubFaker.Generate(5);

            context.Set<Club>().AddRange(fakeClubs);
            await context.SaveChangesAsync();

            var result = await repository.GetAllAsync();

            Assert.Equal(5, result.Count());

            _output.WriteLine("--- Bogus tərəfindən yaradılan klublar ---");
            foreach (var club in result)
            {
                _output.WriteLine($"Ad: {club.Name} | Ünvan: {club.Address}");
            }
        }
    }
}