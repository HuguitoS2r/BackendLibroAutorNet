namespace PruebaLibreria.Entities
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Anio { get; set; }
        public string Genero { get; set; }
        public int NumeroPaginas { get; set; }
        public string AutorRut { get; set; }  
        public Autor Autor { get; set; } 
    }
}
