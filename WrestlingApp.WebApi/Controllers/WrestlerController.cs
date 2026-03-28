using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WrestlingApp.Application.Interfaces;
using WrestlingApp.Domain.Entities;

namespace WrestlingApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WrestlerController : ControllerBase
    {
        private readonly IGenericRepository<Wrestler> _repository;

        public WrestlerController(IGenericRepository<Wrestler> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var wrestlers = await _repository.GetAllAsync();
            return Ok(wrestlers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var wrestler = await _repository.GetByIdAsync(id);

            if (wrestler == null)
                return NotFound("Wrestler not found");

            return Ok(wrestler);
        }
    }
}
