using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.BL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Ship> shipss = new List<Ship>();
            int shipCount=0;
            int indexofship=-1;
            while (true) 
            { 
                Console.Clear();
                string choice = showinterface();
                if (choice == "1")
                {
                    shipss.Add(addShip());
                    shipCount++;
                }
                else if (choice == "2")
                {
                    string shipnumbertoSearch;
                    Console.WriteLine("Enter ship's number ");
                    shipnumbertoSearch = Console.ReadLine();
                    indexofship = searchShipbyserial(shipnumbertoSearch, shipCount, shipss);
                    if(indexofship == -1)
                    {
                        Console.WriteLine("Ship with serial number {0} not found",shipnumbertoSearch);
                    }
                    else
                    {
                        shipss[indexofship].printpostition();
                    }
                        Console.ReadKey();

                }
                else if (choice == "3")
                {
                    string latitudetosearch;
                    string longitudetosearch;
                    Console.WriteLine("Enter ship's latitude: ");
                    latitudetosearch = Console.ReadLine();
                    Console.WriteLine("Enter ship's longitude: ");
                    longitudetosearch = Console.ReadLine();
                    indexofship=searchbyangle(latitudetosearch, longitudetosearch,shipCount,shipss);
                    if (indexofship == -1)
                    {
                        Console.WriteLine("Ship at latitude {0} and longitude {1} not found", latitudetosearch,longitudetosearch);
                    }
                    else
                    {
                        Console.WriteLine(shipss[indexofship].shipNumber);
                    }
                        Console.ReadKey();
                }
                else if (choice == "4")
                {
                    string shipnumbertoSearch;
                    Console.WriteLine("Enter ship's number to want change: ");
                    shipnumbertoSearch = Console.ReadLine();
                    indexofship = searchShipbyserial(shipnumbertoSearch, shipCount, shipss);
                    if (indexofship == -1)
                    {
                        Console.WriteLine("Ship with serial number {0} not found", shipnumbertoSearch);
                    }
                    else
                    {
                        changePosition(shipss,indexofship);
                    }
                    Console.ReadKey();
                }
                else if (choice == "5") { break; }
                else { Console.WriteLine("Invalid choice"); }
            }
        }
        static string showinterface()
        {
            string choice;
            Console.WriteLine("1.Add Ship");
            Console.WriteLine("2.View Ship Position");
            Console.WriteLine("3.View Ship Serial Number");
            Console.WriteLine("4.Change Ship Position");
            Console.WriteLine("5.Exit");
            Console.WriteLine("Your choice: ");
            choice= Console.ReadLine();
            return choice;
        }
        static Ship addShip()
        {
            string shipNumber = "";
            int latidudeDegree = -01;
            float latitudeMinute = -1f;
            char latitudeDirection='A';
            int longitudalDegree = -01;
            float longitudalMinute = -1f;
            char longitudalDirection='A';
            Console.WriteLine("Enter ship number: ");
            shipNumber = Console.ReadLine();
            Console.WriteLine("Enter ship's Latidue");
            while (latidudeDegree>90 || latidudeDegree<0){
            Console.WriteLine("Enter latitude degree(1-90): ");
                latidudeDegree = int.Parse(Console.ReadLine());
            }
            while(latitudeMinute>60 || latitudeMinute<0)
            {
            Console.WriteLine("Enter latitude minutes(1-60): ");
                latitudeMinute = float.Parse(Console.ReadLine());
            }
            while(latitudeDirection!='N' && latitudeDirection != 'E' && latitudeDirection != 'W'&& latitudeDirection != 'S'){
                Console.WriteLine("Enter latitude direction(N/E/W/S): ");
            latitudeDirection=Char.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter ship's Longitudal");
            while(longitudalDegree<0 || longitudalDegree > 180)
            {
            Console.WriteLine("Enter Longitudal degree(1-180): ");
                longitudalDegree = int.Parse(Console.ReadLine());
            }
            while (longitudalMinute > 60|| longitudalMinute<0)
            {
                Console.WriteLine("Enter Longitudal minutes(1-60): ");
            longitudalMinute = float.Parse(Console.ReadLine());
            }
            while (longitudalDirection != 'N' && longitudalDirection != 'E' && longitudalDirection != 'W' && longitudalDirection != 'S')
            {

                Console.WriteLine("Enter Longitudal direction(N/E/W/S): ");
                longitudalDirection = Char.Parse(Console.ReadLine());
            }
            angle latitude=new angle(latidudeDegree, latitudeMinute, latitudeDirection);
            angle longitude=new angle(longitudalDegree,longitudalMinute,longitudalDirection);
            Ship ship = new Ship(shipNumber, latitude, longitude);
            return ship;
        }
        static int searchShipbyserial(string shipnumber,int shipCount,List<Ship> ship)
        {
            for (int i = 0;i<shipCount;i++)
            {
                if (ship[i].checkShip(shipnumber))
                {
                    return i;
                }
            }
            return -1;
        }
        static int searchbyangle(string latitude,string longitude, int shipCount, List<Ship> ship)
        {
            for (int i = 0; i < shipCount; i++)
            {
                if (ship[i].locationCheck(latitude,longitude))
                {
                    return i;
                }
            }
            return -1;
        }
        static void changePosition(List<Ship> ship,int index)
        {
            int latidudeDegree = -01;
            float latitudeMinute = -1f;
            char latitudeDirection = 'A';
            int longitudalDegree = -01;
            float longitudalMinute = -1f;
            char longitudalDirection = 'A';
            Console.WriteLine("Enter ship's Latidue");
            while (latidudeDegree > 90 || latidudeDegree < 0)
            {
                Console.WriteLine("Enter latitude degree: ");
                latidudeDegree = int.Parse(Console.ReadLine());
            }
            while (latitudeMinute > 60 || latitudeMinute < 0)
            {
                Console.WriteLine("Enter latitude minutes(1-60): ");
                latitudeMinute = float.Parse(Console.ReadLine());
            }
            while (latitudeDirection != 'N' && latitudeDirection != 'E' && latitudeDirection != 'W' && latitudeDirection != 'S')
            {
                Console.WriteLine("Enter latitude direction(N/E/W/S): ");
                latitudeDirection = Char.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter ship's Longitudal");
            while (longitudalDegree < 0 || longitudalDegree > 180)
            {
                Console.WriteLine("Enter Longitudal degree: ");
                longitudalDegree = int.Parse(Console.ReadLine());
            }
            while (longitudalMinute > 60 || longitudalMinute < 0)
            {
                Console.WriteLine("Enter Longitudal minutes(1-60): ");
                longitudalMinute = float.Parse(Console.ReadLine());
            }
            while (longitudalDirection != 'N' && longitudalDirection != 'E' && longitudalDirection != 'W' && longitudalDirection != 'S')
            {

                Console.WriteLine("Enter Longitudal direction(N/E/W/S): ");
                longitudalDirection = Char.Parse(Console.ReadLine());
            }
            ship[index].changePosition(latidudeDegree,latitudeMinute,latitudeDirection,longitudalDegree,longitudalMinute,longitudalDirection);
        }
    }
}
