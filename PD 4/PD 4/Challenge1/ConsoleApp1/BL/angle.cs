using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.BL
{
    internal class angle
    {
        public int degree;
        public float minutes;
        public char direction;
        public angle(int degree, float minutes, char direction)
        {
            this.degree = degree;
            this.minutes = minutes;
            this.direction = direction;
        }
        public void changeangle(int degree, float minutes,char direction)
        { 
            this.degree = degree;
            this.minutes = minutes;
            this.direction = direction;
        }
        public string displayangle()
        {
            string angledir;
            angledir = this.degree + "\u00b0" + this.minutes + "'" + direction;
            return angledir;
        }
       
    }

}
