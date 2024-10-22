using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Polimorfismo
{
    public interface IFuntion
    {
        void Insertar();
        void Saludar(string mensaje);
    }

    public class Impl1 : IFuntion
    {
        public void Insertar()
        {
            Console.WriteLine("implementación 1");
        }

        //polimorfismo estatico: es la sobrecarga
        public void Insertar(int dato) { 

        }

        public void Saludar(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
    }
}
