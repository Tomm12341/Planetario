
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
        const double dT = 0.001;

        
        public  double ForzaModulo2pianeti(Pianeta a, Pianeta b)
        {
            Vettore s = b.Spostamento - a.Spostamento;
            double f = G*((a.Massa * b.Massa) / Math.Pow((s.Modulo()), 2));
            return f;
        }
        public Vettore ForzaReale(Pianeta a, Pianeta b)
        {
            double forza = ForzaModulo2pianeti(a, b);
            return  forza * (a.Spostamento - b.Spostamento).Versore();
        }

        public Vettore ForzaTotale(Pianeta riferimento)
        {
            foreach(Pianeta a in this.Pianeti)
            {
                if(Pianeta a != Pianeta riferimento)
            }    
         
        
    }
}
