
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
            Vettore forza = new Vettore(0,0);
           
            foreach (Pianeta a in this.Pianeti)
            {
                if (a != riferimento)
                {
                    forza = ForzaReale(a, riferimento);
                    riferimento.Forza = forza + riferimento.Forza;
                }
                else
                {
                    riferimento.Forza = riferimento.Forza;
                }
            }
            return riferimento.Forza;
        }

        public Vettore Accelerazione(Pianeta a)
        {
           
            a.Accelerazione = ForzaTotale(a) / a.Massa;
            return a.Accelerazione;
        }

       

        public void MuoviPianeti()
        {
            foreach(Pianeta p in this.Pianeti)
            {
                p.Spostamento = p.Spostamento + (p.Velocita * dT) + (0.5 * p.Accelerazione * (dT * dT));
                p.Velocita = p.Velocita + (ForzaTotale(p) / p.Massa) * dT;
            }

        }


        
    }
}
