using System.Text.Json.Serialization;

namespace EjercicioCapas.Bussiness.Entities
{
    public class Autor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        [JsonIgnore]
        public ICollection<Book> Books { get; set; }
    }
}
