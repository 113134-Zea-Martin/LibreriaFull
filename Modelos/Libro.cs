namespace WebApplication5.Modelos
{
    public class Libro
    {
        public Guid Isbn { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaPublicacion { get; set; }

        public Guid AutorId { get; set; }
        public virtual Autor Autor { get; set; }

        public Guid GeneroId { get; set; }
        public virtual Genero Genero { get; set; }
    }
}
