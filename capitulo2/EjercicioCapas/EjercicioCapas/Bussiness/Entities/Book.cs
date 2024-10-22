namespace EjercicioCapas.Bussiness.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AutorId { get; set; }
        public Autor? Autor { get; set; }
    }
}
