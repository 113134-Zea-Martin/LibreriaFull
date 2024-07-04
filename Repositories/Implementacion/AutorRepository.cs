using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Modelos;

namespace WebApplication5.Repositories.Implementacion
{
    public class AutorRepository : IAutorRepository
    {
        private readonly LibreriaConext _libreriaConext;

        public AutorRepository(LibreriaConext libreriaConext)
        {
            _libreriaConext = libreriaConext;
        }

        public async Task<List<Autor>> GetAutoressAsync()
        {
            return await _libreriaConext.Autores.ToListAsync();
        }
    }
}
