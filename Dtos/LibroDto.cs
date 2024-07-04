using WebApplication5.Modelos;

namespace WebApplication5.Dtos
{
    public class LibroDto
    {
        public Guid Isbn { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaPublicacion { get; set; }

        public Guid AutorId { get; set; }

        public Guid GeneroId { get; set; }
    }
}
