using Microsoft.AspNetCore.Mvc;
using WebApplication5.Repositories;
using WebApplication5.Repositories.Implementacion;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;

        public AutorController(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var autores = await _autorRepository.GetAutoressAsync();

            return Ok(autores);
        }
    }
}
