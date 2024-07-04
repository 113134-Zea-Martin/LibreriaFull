using WebApplication5.Modelos;

namespace WebApplication5.Repositories
{
    public interface IGeneroRepository
    {
        Task<List<Genero>> GetGenerosAsync();
    }
}
