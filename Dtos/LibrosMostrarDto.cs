namespace WebApplication5.Dtos
{
    public class LibrosMostrarDto
    {
        public Guid Isbn { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaPublicacion { get; set; }

        public string nombreAutor { get; set; }

        public string nombreGenero { get; set; }
    }
}
