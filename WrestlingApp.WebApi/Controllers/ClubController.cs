using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory; // Bu lazımdır
using WrestlingApp.Application.Interfaces;
using WrestlingApp.Domain.Entities;

namespace WrestlingApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IGenericRepository<Club> _repository;
        private readonly IMemoryCache _cache; // Cache-i bura daxil edirik
        private const string ClubsCacheKey = "all_clubs_cache"; // Cache-in adı (açar sözü)

        public ClubController(IGenericRepository<Club> repository, IMemoryCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!_cache.TryGetValue(ClubsCacheKey, out IEnumerable<Club> clubs))
            {
                clubs = await _repository.GetAllAsync();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5)) 
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));

                _cache.Set(ClubsCacheKey, clubs, cacheOptions);

                System.Diagnostics.Debug.WriteLine("--- MƏLUMAT BAZADAN GƏLDİ ---");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("--- MƏLUMAT CACHE-DƏN (RAM) GƏLDİ ---");
            }

            return Ok(clubs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var club = await _repository.GetByIdAsync(id);

            if (club == null)
                return NotFound("Club not found.");

            return Ok(club);
        }
    }
}