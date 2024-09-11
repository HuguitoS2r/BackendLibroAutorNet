using System.Text.Json.Serialization;

namespace PruebaLibreria.Entities
{
    public class Autor
    {
        public int id { get; set; }
        public string Rut { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CiudadProcedencia { get; set; }
        public string CorreoElectronico { get; set; }

        [JsonIgnore]  
        public ICollection<Libro> Libros { get; set; } = new List<Libro>();
    }

}
