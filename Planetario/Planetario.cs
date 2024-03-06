using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Planetario
{
    internal class Planetario
    {
        public List<Pianeta> Pianeti { get; set; }
        const double G = 6.673e-10;

        
        public  double ForzaModulo2pianeti(Pianeta a, Pianeta b)
        {
            Vettore s = a.Spostamento - b.Spostamento;
            double f = G*((a.Massa * b.Massa) / Math.Pow((s.Modulo), 2));
            return f;
        }
        public Vettore ForzaReale(Pianeta a, Pianeta b)
        {
            return new Vettore= ForzaModulo2pianeti(a, b) * (a.Spostamento - b.Spostamento).Versore();
        }
    }
}
