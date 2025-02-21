using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Challeng_2.BL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int skillCount = 0;
            int playerCount = 0;
            List<Player> players = new List<Player>();
            List<Stats> Stat = new List<Stats>();
            string option;
            while (true)
            { Console.Clear();
                option = mainInterface();
                if (option == "1")
                {
                    players.Add(addPlayer());
                    playerCount++;
                }
                if (option == "2")
                {
                    Stat.Add(addSkill());
                    skillCount++;
                }
                if (option == "3")
                {
                    showPlayers(players, playerCount);
                    Console.ReadKey();
                }
                if (option == "4")
                {
                    learnSkill(players, Stat, playerCount, skillCount);
                }
                if (option == "5")
                {
                    string attacker;
                    string target;
                    int attackerIndex;
                    int targetIndex;
                    string message = "";
                    Console.WriteLine("Enter name of attacker: ");
                    attacker = Console.ReadLine();
                    Console.WriteLine("Enter name of the target: ");
                    target = Console.ReadLine();
                    attackerIndex=findPlayer(players, playerCount,attacker);
                    targetIndex = findPlayer(players, playerCount, target);
                    if (attackerIndex != -1 && targetIndex!=-1)
                    {
                        message=players[attackerIndex].attack(players[targetIndex]);
                        Console.WriteLine(message);
                    }
                    else
                    {
                        if(attackerIndex == -1)
                        {
                            Console.WriteLine("Player {0} does not exist.",attacker);
                        }
                        if(targetIndex == -1)
                        {
                            Console.WriteLine("Player {0} does not exist.",target);

                        }
                    }
                    Console.ReadKey();


                }
                if (option == "6")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Try again");
                }
            }
        }
        static string mainInterface()
        {
            string choice;
            Console.WriteLine("1. Add Player");
            Console.WriteLine("2. Add Skill Statistics: ");
            Console.WriteLine("3. Display Player Info: ");
            Console.WriteLine("4. Learn a Skill: ");
            Console.WriteLine("5. Attack: ");
            Console.WriteLine("6. Exit: ");
            Console.WriteLine("Your choice: ");
            choice = Console.ReadLine();
            return choice;
        }
        static Player addPlayer()
        {
            string name;
            float health;
            float energy;
            float armor = -1;
            Console.WriteLine("Enter name of the player: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter health of the player: ");
            health = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter energy of the player: ");
            energy = float.Parse(Console.ReadLine());
            while (armor < 0 || armor > 100)
            {
                Console.WriteLine("Enter armor's health of the player(1-100): ");
                armor = float.Parse(Console.ReadLine());
            }
            Player player = new Player(name, health, energy, armor);
            return player;
        }
        static Stats addSkill()
        {
            string name;
            float damage;
            float penetration;
            float heal;
            float cost;
            string description;

            Console.WriteLine("Enter name of skill: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter the damage of skill: ");
            damage = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter armor penetration power of skill: ");
            penetration = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the amount of health increase (of attacker) by skill: ");
            heal = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the energy required for skill: ");
            cost = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the descryption of skill: ");
            description = Console.ReadLine();

            Stats stat = new Stats(name, damage, penetration, heal, cost, description);
            return stat;
        }
        static void showPlayers(List<Player> players, int playerCount)
        {
            for (int i = 0; i < playerCount; i++)
            {
                Console.WriteLine("Player {0}", i + 1);
                players[i].displayInfo();
                Console.WriteLine();
            }
        }
        static void learnSkill(List <Player> players,List <Stats> Stat,int playerCount,int skillCount) 
        {

            string playername="";
            int playerindex = -1;
            int skillindex = -1;
            string skillname="";
            Console.WriteLine("Enter Name of player: ");
            playername = Console.ReadLine();
            playerindex = findPlayer(players, playerCount, playername);
            Console.WriteLine();
            Console.WriteLine("Availabe Skills:");
            showSkill(Stat, skillCount);
            Console.WriteLine("Enter Name of skill: ");
            skillname = Console.ReadLine();
            skillindex = findSkill(Stat, skillCount, skillname);
            if (playerindex != -1 && skillindex!=-1 )
            {
                players[playerindex].skillStatistic = Stat[skillindex];                
            }
            else
            {
                if (skillindex == -1)
                {
                    Console.WriteLine("Skill {0} does not exists: ", skillname);
                    Console.ReadKey();
                }
                if(playerindex==-1)
                {
                    Console.WriteLine("Player {0} does not exists: ", playername);
                    Console.ReadKey();
                }

            }
        }
        static int findSkill(List<Stats> skill, int skillCount, string name)
        {
            for (int i = 0; i < skillCount; i++)
            {
                if (skill[i].CheckSkill(name))
                {
                    return i;
                }
            }
            return -1;
        }
        static int findPlayer(List<Player> Players, int playerCount, string name)
        {
            for (int i = 0; i < playerCount; i++)
            {
                if (Players[i].CheckPlayer(name))
                {
                    return i;
                }
            }
            return -1;
        }
        static void showSkill(List<Stats> stat,int skillCount)
        {
            for (int i = 0; i < skillCount; i++)
            {
                Console.WriteLine("Skill {0}", i + 1);
                stat[i].showSkill();
                Console.WriteLine();

            }
        }
    }
}

