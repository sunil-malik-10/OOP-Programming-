using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1.BL
{
    internal class Ship
    {
        public string shipNumber;
        public angle latitude;
        public angle longitude;

        public Ship(string shipNumber, angle latitude, angle longitude)
        {
            this.shipNumber = shipNumber;
            this.latitude = latitude;
            this.longitude = longitude;
        }
        public void printpostition()
        {
            string latidudeposition = this.latitude.displayangle();
            string longitudeposition = this.longitude.displayangle();
            Console.WriteLine("Ship is at {0} and {1}", latidudeposition, longitudeposition);
        }
        public bool checkShip(string shipNumber)
        {
            if (shipNumber == this.shipNumber)
            {
                return true;
            }
            else { return false; }
        }
        public bool locationCheck(string latitude, string longitude)
        {
            string currentlatitude =this.latitude.displayangle();
            string currentlongitude =this.longitude.displayangle();
            if (latitude == currentlatitude && longitude == currentlongitude)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void changePosition(int latitudeDegree,float latitudeMinutes,char latDirection,int longDegree,float longMinutes,char longDirection)
        {
            latitude.changeangle(latitudeDegree, latitudeMinutes, latDirection);
            longitude.changeangle(longDegree,longMinutes,longDirection);
        }
    }
}
