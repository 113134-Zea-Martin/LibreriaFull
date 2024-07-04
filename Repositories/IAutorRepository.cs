using WebApplication5.Modelos;

namespace WebApplication5.Repositories
{
    public interface IAutorRepository
    {
        Task<List<Autor>> GetAutoressAsync();
    }
}
