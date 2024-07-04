using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Repositories;
using WebApplication5.Repositories.Implementacion;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly IGeneroRepository _generoRepository;

        public GenerosController(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var generos = await _generoRepository.GetGenerosAsync();

            return Ok(generos);
        }
    }
}
