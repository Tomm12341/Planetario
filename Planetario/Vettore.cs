﻿using System;
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


        public static Vettore Parse(string s)
        {
            string[]xy = s.Split(';');
            return new Vettore(double.Parse(xy[0]), double.Parse(xy[1]));

        }
        public override string ToString()
        {
            return $"{X};{Y}";
        }

        public static bool TryParse(string s, out Vettore v)
        {
            try {
                v = Vettore.Parse(s);
                    return true;
                }
            catch
            {
                v = null;
                return false;   
            }

        }

    }
}
