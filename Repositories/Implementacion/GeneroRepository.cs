using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Modelos;

namespace WebApplication5.Repositories.Implementacion
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly LibreriaConext _libreriaConext;

        public GeneroRepository(LibreriaConext libreriaConext)
        {
            _libreriaConext = libreriaConext;
        }

        public async Task<List<Genero>> GetGenerosAsync()
        {
           return await _libreriaConext.Generos.ToListAsync();
        }
    }
}
