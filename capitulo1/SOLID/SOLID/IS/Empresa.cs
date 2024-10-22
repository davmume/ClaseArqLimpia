
namespace SOLID.IS
{
    public interface ICommons {
        void EntraAReuniones();
        void Registro();

    }
    public interface IDeveloper 
    {
        void Derarrollar();
    }
    public interface IGerente {
        void Gerenciar();
    }
    public interface IFinanzas
    {
        void AdministrarFacturas();
    }
    public class Developer : ICommons, IDeveloper
    {
        public void Derarrollar()
        {
            throw new NotImplementedException();
        }

        public void EntraAReuniones()
        {
            throw new NotImplementedException();
        }

        public void Registro()
        {
            throw new NotImplementedException();
        }
    }
    public class Venta : ICommons
    {
        public void EntraAReuniones()
        {
            throw new NotImplementedException();
        }

        public void Registro()
        {
            throw new NotImplementedException();
        }
    }
    public class Empresa
    {
    }
}
