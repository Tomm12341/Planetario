﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Planetario
{
    public class Vettore
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

        public static Vettore operator *(double d, Vettore v1)
        {
            return new Vettore(d*v1.X, d*v1.Y);
        }
        public static Vettore operator *( Vettore v1,double d)
        {
            return new Vettore(v1.X*d  , v1.Y * d);
        }

        public static Vettore operator - (Vettore v1, Vettore v2)
        {
            return new Vettore(v1.X - v2.X, v1.Y - v2.Y);
        }
        public static Vettore operator +(Vettore v1, Vettore v2)
        {
            return new Vettore(v1.X + v2.X, v1.Y + v2.Y);
        }
        public static Vettore operator /(Vettore v1, double a)
        {
            return new Vettore(v1.X / a, v1.Y / a);
        }
        public static bool operator !=(Vettore v1, Vettore v2)
        {
            if (!(v1.X == v2.X && v1.Y == v2.Y))
            {
                return true;
            }
            else
                return false;
        }
        public static bool operator ==(Vettore v1, Vettore v2)
        {
            if (v1.X == v2.X && v1.Y == v2.Y)
            {
                return true;
            }
            else
                return false;
        }

        public double Modulo()
        {
            double risultato = Math.Sqrt(Math.Pow(X , 2) + Math.Pow(Y , 2));
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

        public Vettore Versore()
        {
            return new Vettore(X / Modulo(), Y / Modulo());
        }

    }
}
