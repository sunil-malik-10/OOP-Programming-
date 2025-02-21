using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challeng_2.BL
{
    internal class Stats
    {
        public string name;
        public float damage;
        public string description;
        public float penetration;
        public float cost;
        public float heal;

        public Stats(string name, float damage, float penetration, float heal, float cost, string description)
        {
            this.name = name;
            this.damage = damage;
            this.penetration = penetration;
            this.heal = heal;
            this.cost = cost;
            this.description = description;
        }
        public bool CheckSkill(string skill)
        {
            if(skill ==this.name)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        public void showSkill()
        {
            Console.WriteLine("Name: {0}",name);
            Console.WriteLine("Damage: {0}", damage);
            Console.WriteLine("Energy required: {0}",cost);
            Console.WriteLine("Health points: {0}",heal);
            Console.WriteLine("Penetration power: {0}",penetration);
            Console.WriteLine("Description: {0}", description);
        }
    }
}
