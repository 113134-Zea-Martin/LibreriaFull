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
        private readonly IAutorRepository _autorRepository;
        private readonly IGeneroRepository _generoRepository;

        public LibroController(ILibrosRepository librosRepository, IAutorRepository autorRepository, IGeneroRepository generoRepository)
        {
            _librosRepository = librosRepository;
            _autorRepository = autorRepository;
            _generoRepository = generoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var libros = await _librosRepository.GetLibrosAsync();

            List<LibrosMostrarDto> librosMostrarDtos = new List<LibrosMostrarDto>();

            List<Autor> lAUtores = await _autorRepository.GetAutoressAsync();
            List<Genero> lGeneros = await _generoRepository.GetGenerosAsync();

            foreach (Libro l in libros){

                var mostrarlibroDto = new LibrosMostrarDto();
                mostrarlibroDto.Isbn = l.Isbn;
                mostrarlibroDto.Titulo = l.Titulo;
                mostrarlibroDto.FechaPublicacion = l.FechaPublicacion;

                foreach (Autor o in lAUtores)
                {
                    if ((o.IdAutor == l.AutorId))
                    { 
                        {
                            mostrarlibroDto.nombreAutor = o.Nombre;
                        };                        
                    }
                }

                foreach (Genero g in lGeneros)
                {
                    if ((g.IdGenero == l.GeneroId))
                    {
                        {
                            mostrarlibroDto.nombreGenero = g.Nombre;
                        };
                    }
                }
                librosMostrarDtos.Add(mostrarlibroDto);
            }


            return Ok(librosMostrarDtos);
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
