using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.LS
{
    public interface IVolar {
        void volar();
    }
    public interface ICorrer
    {
        void correr();
    }
    public interface INadar
    {        
        void nadar();       
    }

    public class Pinguino : ICorrer, INadar
    {
        public void correr()
        {
            Console.WriteLine("corre chistoso");
        }
        public void nadar()
        {
            Console.WriteLine("si nada muy rápido!!!");
        }
    }

    public class Paloma : ICorrer, IVolar
    {
        public void correr()
        {
            Console.WriteLine("si corre");
        }

        public void volar()
        {
            Console.WriteLine("si vuela");
        }
    }

    public class Eagle : IVolar
    {
        public void volar()
        {
            Console.WriteLine("si vuela");
        }
    }
    public class AdminAve
    {
        private List<IVolar> voladores = new();
        public bool InsertVolador(Eagle ave)
        {
            voladores.Add(ave);
            return true;            
        }
    }
}
