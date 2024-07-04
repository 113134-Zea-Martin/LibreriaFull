namespace WebApplication5.Modelos
{
    public class Genero
    {
        public Guid IdGenero { get; set; }
        public string Nombre { get; set; }
        public List<Libro> Libros { get; set; } = new List<Libro>();
    }
}
