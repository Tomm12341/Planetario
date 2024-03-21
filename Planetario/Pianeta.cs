using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planetario
{
    public class Pianeta
    {

        public double Massa { get; set; }
        public Color colore { get; set; }
        public Vettore Spostamento { get; set; }    
        public Vettore Forza { get; set; }  
        public Vettore Accelerazione { get; set; } 
        public Vettore Velocita { get; set; }   

        public static bool operator ==(Pianeta a, Pianeta b)
        {
            if(a.Massa == b.Massa && a.Spostamento==b.Spostamento &&  a.Forza == b.Forza && a.Accelerazione==b.Accelerazione && a.Velocita == b.Velocita)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(Pianeta a, Pianeta b)
        {
            if (a.Massa != b.Massa || a.Spostamento != b.Spostamento || a.Forza != b.Forza || a.Accelerazione != b.Accelerazione || a.Velocita != b.Velocita)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{Massa};{colore};{Spostamento};{Forza};{Accelerazione};{Velocita}";
        }





    }
}
