using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Modelos;

namespace WebApplication5.Repositories.Implementacion
{
    public class LibroRepository : ILibrosRepository
    {
        private readonly LibreriaConext _libreriaConext;

        public LibroRepository(LibreriaConext libreriaConext)
        {
            _libreriaConext = libreriaConext;
        }

        public async Task DeleteLibroAsync(Guid ISBN)
        {

            var libro = await _libreriaConext.Libros.FirstOrDefaultAsync(l => l.Isbn == ISBN);

            if (libro != null)
            {
                _libreriaConext.Libros.Remove(libro);
                await _libreriaConext.SaveChangesAsync();
            }
        }

        public async Task<Libro> GetLibroByISBNAsync(Guid ISBN)
        {
            return await _libreriaConext.Libros.FirstOrDefaultAsync(l => l.Isbn == ISBN);
        }

        public async Task<List<Libro>> GetLibrosAsync()
        {
           return await _libreriaConext.Libros.ToListAsync();
        }

        public async Task<Libro> PostLibroAsync(Libro libro)
        {
           await _libreriaConext.Libros.AddAsync(libro);
            await _libreriaConext.SaveChangesAsync();

            return libro;
        }

        public async Task<Libro> PutLibroAsync(Guid ISBN, Libro libro)
        {
              var libroAEditar =  await _libreriaConext.Libros.FirstOrDefaultAsync(l => l.Isbn == ISBN);
            if (libroAEditar != null)
            {
                libroAEditar.Titulo = libro.Titulo;
                libroAEditar.Autor = libro.Autor;
                libroAEditar.AutorId = libro.AutorId;
                libroAEditar.FechaPublicacion = libro.FechaPublicacion;
                libroAEditar.Genero = libro.Genero;
                libroAEditar.GeneroId = libro.GeneroId;
                await _libreriaConext.SaveChangesAsync();
            }

            return libro;

        }
    }
}
