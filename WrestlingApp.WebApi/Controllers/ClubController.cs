using Microsoft.AspNetCore.Mvc;
using WrestlingApp.Application.Interfaces;
using WrestlingApp.Domain.Entities;

namespace WrestlingApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IGenericRepository<Club> _repository;

        public ClubController(IGenericRepository<Club> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clubs = await _repository.GetAllAsync();
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
