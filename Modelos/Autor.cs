namespace WebApplication5.Modelos
{
    public class Autor
    {
        public Guid IdAutor { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public List<Libro> Libros { get; set; } = new List<Libro>();
    }
}
