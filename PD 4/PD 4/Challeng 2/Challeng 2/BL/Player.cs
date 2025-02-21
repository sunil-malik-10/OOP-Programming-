using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Challeng_2.BL
{
    internal class Player
    {
        public float hp;
        public float maxHp;
        public float energy;
        public float maxEnergy;
        public float armor;
        public string name;
        public Stats skillStatistic;

        public Player(string name,float health,float energy,float armor)
        {
            this.name = name;
            this.hp = health;
            this.maxHp = health;
            this.energy = energy;
            this.armor = armor;
            this.maxEnergy = energy;

        }
        public void updateName(string name)
        {
            this.name = name;
        }
        public void increaseHealth(float health)
        { 
            if(this.hp+health>this.maxHp)
            {
                this.hp = this.maxHp;
            }
            else
            {
                this.hp += health;
            }
        }
        public void decreaseHealth(float health)
        {
            if (this.hp - health < 0)
            {
                this.hp = 0;
            }
            else
            {
                this.hp -= health;
            }
        }
        public void increaseEnergy(float energy) 
        {
            if (this.energy + energy > this.maxEnergy)
            {
                this.energy = this.maxEnergy;
            }
            else
            {
                this.energy += energy;
            }
        }
        public void decreaseEnergy(float energy)
        {
            if (this.energy - energy < 0)
            {
                this.energy = 0;
            }
            else
            {
                this.energy -= energy;
            }
        }
        public void decreaseArmor(float armor)
        {
            if (this.armor - armor < 0)
            {
                this.armor = 0;
            }
            else
            {
                this.armor -= armor;
            }
        }
        public void learnSkill(Stats skill)
        {
            this.skillStatistic = skill;
        }
        public string attack(Player p)
        {
            float effectivearmor = 0f;
            float penetration = this.skillStatistic.penetration;
            float requiredenergy = this.skillStatistic.cost;
            string finalmessage;
            float caldamage;
            if (this.skillStatistic != null)
            {
                if (this.energy<requiredenergy)
                {
                    finalmessage= this.name+ " attempted to use"+skillStatistic.name+", but didn't have enough energy!";
                }
                else
                {
                    effectivearmor = p.armor - penetration;
                    p.decreaseArmor(penetration);
                    this.decreaseEnergy( requiredenergy);
                    caldamage = skillStatistic.damage * ((100 - effectivearmor) / 100);
                    p.decreaseHealth(caldamage);
                    this.increaseHealth(this.skillStatistic.heal);
                    finalmessage = this.name + " used skill " + this.skillStatistic.name + "," + this.skillStatistic.description + ", against " + p.name + " doing " + caldamage + " damage!";
                    if(this.skillStatistic.heal!=0)
                    {
                        finalmessage += this.name + " healed for " + this.skillStatistic.heal + " health.";
                    }
                    if(p.hp==0)
                    {
                        finalmessage += p.name + " died.";
                    }
                    else
                    {
                        finalmessage += p.name + " is at " + (p.hp * 100) / 100 + "% health.";
                    }
                }
            }
            else
            {
                finalmessage = this.name + " has not learnt any skill";
            }
                return finalmessage;

        }
        public void displayInfo()
        {
            Console.WriteLine("Name: {0}", this.name);
            Console.WriteLine("Current health: {0}", this.hp);
            Console.WriteLine("Current energy: {0}", this.energy);
            Console.WriteLine("Aromor health: {0}",this.armor);
            
        }
        public bool CheckPlayer(string name)
        {
            if (name == this.name)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

    }
}
