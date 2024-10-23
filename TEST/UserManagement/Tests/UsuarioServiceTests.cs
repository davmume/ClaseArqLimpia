using Xunit;
using UserManagement.Models;
using UserManagement.Services;
using NuGet.Frameworks;

namespace UserManagement.Tests
{
    public class UsuarioServiceTests
    {
        [Fact]
        public void InsertUserTest() { 
            //Arranque
            var servicio= new UsuarioService();
            var usuario= new Usuario(1,"David","david@gmail.com");

            //Acci�n
            servicio.CrearUsuario(usuario);
            var result = servicio.ObtenerUsuarioPorId(usuario.Id);
            
            //Aserci�n
            Assert.NotNull(result);
            Assert.Equal(usuario.Nombre, result.Nombre);
            Assert.Equal(usuario.Email, result.Email);

        }
    }
}