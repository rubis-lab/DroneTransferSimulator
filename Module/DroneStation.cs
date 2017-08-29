using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneTransferSimulator
{
    public class DroneStation
    {
        public List<Drone> drones = new List<Drone>();
        public double coverRange;
        public double stationLng, stationLat;
        public string name;
        public DroneStation(string _name, double _stationLat, double _stationLng, double _coverRange)
        {
            name = _name;
            coverRange = _coverRange;
            stationLat = _stationLat;
            stationLng = _stationLng;
        }
        public DroneStation(double _stationLat, double _stationLng, double _coverRange)
        {
            coverRange = _coverRange;
            stationLat = _stationLat;
            stationLng = _stationLng;
        }
        public void updateChargingDrones(Time currentTime)
        {
            foreach(Drone droneElement in drones)
            {
                if(droneElement.returnStatus() == 2)
                {
                    droneElement.charge(droneElement.getChargeStartTime(), currentTime); //battery charged from centerArrivalTime

                    if(droneElement.returnBattery() >= 100)
                    {
                        droneElement.setBattery(100);
                        droneElement.setStatus(0);
                    }
                }
            }
        }
    }
}
