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
        public Address addr;    

        public DroneStation(string _name, double _stationLat, double _stationLng, double _coverRange, Address _addr)
        {
            name = _name;
            coverRange = _coverRange;
            stationLat = _stationLat;
            stationLng = _stationLng;
            addr = _addr;
        }

        public DroneStation(string _name, double _stationLat, double _stationLng, double _coverRange)
        {
            name = _name;
            coverRange = _coverRange;
            stationLat = _stationLat;
            stationLng = _stationLng;
        }

        public void updateChargingDrones(DateTime currentTime)
        {
            foreach(Drone droneElement in drones)
            {
                if(droneElement.returnStatus() == Drone.droneType.D_CHARGING)
                {
                    droneElement.charge(droneElement.getChargeStartTime(), currentTime); // battery charged from centerArrivalTime

                    if(droneElement.returnBattery() >= 100)
                    {
                        droneElement.setBattery(100);
                        droneElement.setStatus(Drone.droneType.D_IN_STATION);
                    }
                }
            }
        }

        public Address getStationAddress()
        {
            return addr;
        }

        public void setStationAddress(Address _addr)
        {
            addr = _addr;
        }
    }
}
