using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneTransferSimulator
{
    class DroneStation
    {
        public List<Drone> drones= new List<Drone>();
        public double coverRange;
        public double stationLng, stationLat;
        public DroneStation(double _coverRange, double _stationLat, double _stationLng)
        {
            coverRange = _coverRange;
            stationLat = _stationLat;
            stationLng = _stationLng;
        }
        public void updateChargingDrones(Time currentTime)
        {
            foreach(Drone droneElement in drones)
            {
                if(droneElement.returnStatus() ==2)
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
