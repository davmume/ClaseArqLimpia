namespace UserManagement.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }

        public Usuario(int id, string nombre, string email)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
        }
        public override bool Equals(object? obj)
        {
            if (obj is Usuario user)
            if (Nombre.Equals(user.Nombre) && Email.Equals(user.Email))
            {
                    return true;                
            }
            return false;
        }
    }
}