using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.OC
{
    public interface IArea {
        double Area();
    }
    public class Square: IArea {
        public double lado { get; set; }

        public double Area()
        {
            return lado*lado;
        }
    }
    public class Triangule: IArea {
        public double Base { get; set; }
        public double Heigth { get; set; }

        public double Area()
        {
            return Heigth*Base/2;
        }
    }
    public class Rectangulo : IArea
    {
        public double Base { get; set; }
        public double Heingth { get; set; }

        public double Area()
        {
            return Base*Heingth;
        }
    }
    public class Calculadora
    {
        public double Area(IArea obj) {
  
            return obj.Area();
        }
    }
}
