using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Dtos;
using WebApplication5.Modelos;
using WebApplication5.Repositories;
using WebApplication5.Repositories.Implementacion;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibrosRepository _librosRepository;

        public LibroController(ILibrosRepository librosRepository)
        {
            _librosRepository = librosRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var libros = await _librosRepository.GetLibrosAsync();

            return Ok(libros);
        }

        [HttpGet("/{ISBN}")]
        public async Task<IActionResult> GetLibroByISBN(Guid ISBN)
        {
            var libro = await _librosRepository.GetLibroByISBNAsync(ISBN);
            return Ok(libro);
        }

        [HttpPost]
        public async Task<IActionResult> PostLibroAsync([FromBody]LibroDto libroDto)
        {
            Libro libro = new Libro()
            {
                Isbn = libroDto.Isbn,
                Titulo = libroDto.Titulo,
                FechaPublicacion = libroDto.FechaPublicacion,
                AutorId = libroDto.AutorId,
                GeneroId = libroDto.GeneroId,
            };
            await _librosRepository.PostLibroAsync(libro);
            return Ok(libro);
        }

        [HttpPut("/{ISBN}")]
        public async Task<IActionResult> PutLibroAsync([FromRoute] Guid ISBN, [FromBody] LibroDto libroDto)
        {
            Libro libro = new Libro()
            {
                Isbn = libroDto.Isbn,
                Titulo = libroDto.Titulo,
                FechaPublicacion = libroDto.FechaPublicacion,
                AutorId = libroDto.AutorId,
                GeneroId = libroDto.GeneroId,
            };

            var libroActualizado = await _librosRepository.PutLibroAsync(ISBN, libro);

            return Ok(libroActualizado);
        }

        [HttpDelete("/{ISBN}")]
        public async Task<IActionResult> DeleteLibroAsync([FromRoute] Guid ISBN) 
        {
            await _librosRepository.DeleteLibroAsync(ISBN);
            return Ok();
        }
    }
}
