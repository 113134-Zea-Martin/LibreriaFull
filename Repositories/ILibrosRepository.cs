using WebApplication5.Modelos;

namespace WebApplication5.Repositories
{
    public interface ILibrosRepository
    {
        Task<List<Libro>> GetLibrosAsync();

        Task<Libro> GetLibroByISBNAsync(Guid ISBN);

        Task<Libro> PostLibroAsync(Libro libro);

        Task<Libro> PutLibroAsync(Guid ISBN, Libro libro);

        Task DeleteLibroAsync(Guid ISBN);
    }
}
