using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planetario
{
    internal class Pianeta
    { 
        public double Massa { get; set; }
        public Vettore Spostamento { get; set; }    
        public Vettore Forza { get; set; }  
        public Vettore Accellerazione { get; set; } 
        public Vettore Velocita { get; set; }   

    }
}
