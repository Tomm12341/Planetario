using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Planetario
{
    internal class Vettore
    {
        public Vettore(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }   

        public static Vettore operator *(Vettore v1, Vettore v2)
        {
            return new Vettore(v1.X+v2.X, v1.Y+v2.Y);
        }

        public double Modulo(Vettore v1, Vettore v2)
        {
            double risultato = Math.Sqrt(Math.Pow(v1.X - v2.X, 2) + Math.Pow(v1.Y - v2.Y, 2));
            return risultato;

        }

    }
}
